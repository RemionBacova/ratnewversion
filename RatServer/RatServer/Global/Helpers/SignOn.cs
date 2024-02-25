using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;


namespace RatServer.Global.Helpers
{
    public static class Base58Encoding
    {
        public const int CheckSumSizeInBytes = 4;

        public static byte[] AddCheckSum(byte[] data)
        {
            byte[] checkSum = GetCheckSum(data);
            byte[] dataWithCheckSum = ArrayHelpers.ConcatArrays(data, checkSum);
            return dataWithCheckSum;
        }

        //Returns null if the checksum is invalid
        public static byte[] VerifyAndRemoveCheckSum(byte[] data)
        {
            byte[] result = ArrayHelpers.SubArray(data, 0, data.Length - CheckSumSizeInBytes);
            byte[] givenCheckSum = ArrayHelpers.SubArray(data, data.Length - CheckSumSizeInBytes);
            byte[] correctCheckSum = GetCheckSum(result);
            return givenCheckSum.SequenceEqual(correctCheckSum) ? result : null;
        }

        private const string Digits = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static string Encode(byte[] data)
        {
            // Decode byte[] to BigInteger
            BigInteger intData = 0;
            for (int i = 0; i < data.Length; i++)
            {
                intData = (intData * 256) + data[i];
            }

            // Encode BigInteger to Base58 string
            string result = "";
            while (intData > 0)
            {
                int remainder = (int)(intData % 58);
                intData /= 58;
                result = Digits[remainder] + result;
            }

            // Append `1` for each leading 0 byte
            for (int i = 0; i < data.Length && data[i] == 0; i++)
            {
                result = '1' + result;
            }
            return result;
        }

        public static string EncodeWithCheckSum(byte[] data)
        {
            return Encode(AddCheckSum(data));
        }

        public static byte[] Decode(string s)
        {
            // Decode Base58 string to BigInteger 
            BigInteger intData = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int digit = Digits.IndexOf(s[i]); //Slow
                if (digit < 0)
                {
                    throw new FormatException(string.Format("Invalid Base58 character `{0}` at position {1}", s[i], i));
                }

                intData = (intData * 58) + digit;
            }

            // Encode BigInteger to byte[]
            // Leading zero bytes get encoded as leading `1` characters
            int leadingZeroCount = s.TakeWhile(c => c == '1').Count();
            System.Collections.Generic.IEnumerable<byte> leadingZeros = Enumerable.Repeat((byte)0, leadingZeroCount);
            System.Collections.Generic.IEnumerable<byte> bytesWithoutLeadingZeros =
                intData.ToByteArray()
                .Reverse()// to big endian
                .SkipWhile(b => b == 0);//strip sign byte
            byte[] result = leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();
            return result;
        }

        // Throws `FormatException` if s is not a valid Base58 string, or the checksum is invalid
        public static byte[] DecodeWithCheckSum(string s)
        {
            byte[] dataWithCheckSum = Decode(s);
            byte[] dataWithoutCheckSum = VerifyAndRemoveCheckSum(dataWithCheckSum);
            return dataWithoutCheckSum ?? throw new FormatException("Base58 checksum is invalid");
        }

        private static byte[] GetCheckSum(byte[] data)
        {
            SHA256 sha256 = new SHA256Managed();
            byte[] hash1 = sha256.ComputeHash(data);
            byte[] hash2 = sha256.ComputeHash(hash1);

            byte[] result = new byte[CheckSumSizeInBytes];
            Buffer.BlockCopy(hash2, 0, result, 0, result.Length);

            return result;
        }
    }
    public class ArrayHelpers
    {
        public static T[] ConcatArrays<T>(params T[][] arrays)
        {
            T[] result = new T[arrays.Sum(arr => arr.Length)];
            int offset = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                T[] arr = arrays[i];
                Buffer.BlockCopy(arr, 0, result, offset, arr.Length);
                offset += arr.Length;
            }
            return result;
        }

        public static T[] ConcatArrays<T>(T[] arr1, T[] arr2)
        {
            T[] result = new T[arr1.Length + arr2.Length];
            Buffer.BlockCopy(arr1, 0, result, 0, arr1.Length);
            Buffer.BlockCopy(arr2, 0, result, arr1.Length, arr2.Length);
            return result;
        }

        public static T[] SubArray<T>(T[] arr, int start, int length)
        {
            T[] result = new T[length];
            Buffer.BlockCopy(arr, start, result, 0, length);
            return result;
        }

        public static T[] SubArray<T>(T[] arr, int start)
        {
            return SubArray(arr, start, arr.Length - start);
        }
    }
    internal class Point
    {
        public static readonly Point INFINITY = new(null, default, default);
        public CurveFp Curve { get; private set; }
        public BigInteger X { get; private set; }
        public BigInteger Y { get; private set; }

        public Point(CurveFp curve, BigInteger x, BigInteger y)
        {
            Curve = curve;
            X = x;
            Y = y;
        }
        public Point Double()
        {
            if (this == INFINITY)
            {
                return INFINITY;
            }

            BigInteger p = Curve.p;
            BigInteger a = Curve.a;
            BigInteger l = ((3 * X * X) + a) * InverseMod(2 * Y, p) % p;
            BigInteger x3 = ((l * l) - (2 * X)) % p;
            BigInteger y3 = ((l * (X - x3)) - Y) % p;
            return new Point(Curve, x3, y3);
        }

        public static Point operator +(Point left, Point right)
        {
            if (right == INFINITY)
            {
                return left;
            }

            if (left == INFINITY)
            {
                return right;
            }

            if (left.X == right.X)
            {
                return (left.Y + right.Y) % left.Curve.p == 0 ? INFINITY : left.Double();
            }

            BigInteger p = left.Curve.p;
            BigInteger l = (right.Y - left.Y) * InverseMod(right.X - left.X, p) % p;
            BigInteger x3 = ((l * l) - left.X - right.X) % p;
            BigInteger y3 = ((l * (left.X - x3)) - left.Y) % p;
            return new Point(left.Curve, x3, y3);
        }
        public static Point operator *(Point left, BigInteger right)
        {
            BigInteger e = right;
            if (e == 0 || left == INFINITY)
            {
                return INFINITY;
            }

            BigInteger e3 = 3 * e;
            Point negativeLeft = new(left.Curve, left.X, -left.Y);
            BigInteger i = LeftmostBit(e3) / 2;
            Point result = left;
            while (i > 1)
            {
                result = result.Double();
                if ((e3 & i) != 0 && (e & i) == 0)
                {
                    result += left;
                }

                if ((e3 & i) == 0 && (e & i) != 0)
                {
                    result += negativeLeft;
                }

                i /= 2;
            }
            return result;
        }

        private static BigInteger LeftmostBit(BigInteger x)
        {
            BigInteger result = 1;
            while (result <= x)
            {
                result = 2 * result;
            }

            return result / 2;
        }
        private static BigInteger InverseMod(BigInteger a, BigInteger m)
        {
            while (a < 0)
            {
                a += m;
            }

            if (a < 0 || m <= a)
            {
                a %= m;
            }

            BigInteger c = a;
            BigInteger d = m;

            BigInteger uc = 1;
            BigInteger vc = 0;
            BigInteger ud = 0;
            BigInteger vd = 1;

            while (c != 0)
            {
                //q, c, d = divmod( d, c ) + ( c, );
                BigInteger q = BigInteger.DivRem(d, c, out BigInteger r);
                d = c;
                c = r;

                //uc, vc, ud, vd = ud - q*uc, vd - q*vc, uc, vc;
                BigInteger uct = uc;
                BigInteger vct = vc;
                BigInteger udt = ud;
                BigInteger vdt = vd;
                uc = udt - (q * uct);
                vc = vdt - (q * vct);
                ud = uct;
                vd = vct;
            }
            return ud > 0 ? ud : ud + m;
        }
    }
    internal class CurveFp
    {
        public BigInteger p { get; private set; }
        public BigInteger a { get; private set; }
        public BigInteger b { get; private set; }
        public CurveFp(BigInteger p, BigInteger a, BigInteger b)
        {
            this.p = p;
            this.a = a;
            this.b = b;
        }
    }
    public static class SignOn
    {
        private static readonly Random random = new();
        public static bool VerifySignature(string message, string publicKey, string signature)
        {
            Org.BouncyCastle.Asn1.X9.X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters domain = new(curve.Curve, curve.G, curve.N, curve.H);

            byte[] publicKeyBytes = Base58Encoding.Decode(publicKey);

            Org.BouncyCastle.Math.EC.ECPoint q = curve.Curve.DecodePoint(publicKeyBytes);

            ECPublicKeyParameters keyParameters = new
(q,
            domain);

            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");

            signer.Init(false, keyParameters);
            signer.BlockUpdate(Encoding.ASCII.GetBytes(message), 0, message.Length);

            byte[] signatureBytes = Base58Encoding.Decode(signature);

            return signer.VerifySignature(signatureBytes);
        }
        public static string GetSignature(string privateKey, string message)
        {
            Org.BouncyCastle.Asn1.X9.X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters domain = new(curve.Curve, curve.G, curve.N, curve.H);

            ECPrivateKeyParameters keyParameters = new
(new Org.BouncyCastle.Math.BigInteger(privateKey),
            domain);

            ISigner signer = SignerUtilities.GetSigner("SHA-256withECDSA");

            signer.Init(true, keyParameters);
            signer.BlockUpdate(Encoding.ASCII.GetBytes(message), 0, message.Length);
            byte[] signature = signer.GenerateSignature();
            return Base58Encoding.Encode(signature);
        }
        public static string GetPublicKeyFromPrivateKeyEx(string privateKey)
        {
            Org.BouncyCastle.Asn1.X9.X9ECParameters curve = SecNamedCurves.GetByName("secp256k1");
            ECDomainParameters domain = new(curve.Curve, curve.G, curve.N, curve.H);

            Org.BouncyCastle.Math.BigInteger d = new(privateKey);
            Org.BouncyCastle.Math.EC.ECPoint q = domain.G.Multiply(d);

            ECPublicKeyParameters publicKey = new(q, domain);
            return Base58Encoding.Encode(publicKey.Q.GetEncoded());
        }
        public static string GeneratePrivateKey()
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 77)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
