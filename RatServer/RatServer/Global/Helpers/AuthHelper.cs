
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RatServer.Global.Helpers
{
    public class AuthHelper
    {

        protected AuthHelper()
        {

        }
        private static readonly RNGCryptoServiceProvider rngCsp = new();
        public static string GenerateAphanumericCode(int length)
        {
            byte[] randomNumber = new byte[1];
            rngCsp.GetBytes(randomNumber);

            StringBuilder sb = new();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            foreach (int i in Enumerable.Range(0, length))
            {
                rngCsp.GetBytes(randomNumber);
                _ = sb.Append(chars[randomNumber[0] % 35].ToString());
            }

            return sb.ToString();
        }
    }

}