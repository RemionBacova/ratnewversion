using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;


namespace RatServer.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidJson(this string text)
        {
            text = text.Trim();
            if ((text.StartsWith("{") && text.EndsWith("}")) || //For object
                (text.StartsWith("[") && text.EndsWith("]"))) //For array
            {
                try
                {
                    _ = JToken.Parse(text);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static object ConvertToJson(this string text)
        {
            return text.IsValidJson() ? JToken.Parse(text) : (object)null;
        }

        public static string EnsureEndsWith(this string str, char c)
        {
            return str.EnsureEndsWith(c, StringComparison.Ordinal);
        }


        public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
        {
            return str == null ? throw new ArgumentNullException(nameof(str)) : str.EndsWith(c.ToString(), comparisonType) ? str : str + c;
        }


        public static string EnsureEndsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            return str == null
                ? throw new ArgumentNullException(nameof(str))
                : str.EndsWith(c.ToString(culture), ignoreCase, culture) ? str : str + c;
        }


        public static string EnsureStartsWith(this string str, char c)
        {
            return str.EnsureStartsWith(c, StringComparison.Ordinal);
        }


        public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
        {
            return str == null ? throw new ArgumentNullException(nameof(str)) : str.StartsWith(c.ToString(), comparisonType) ? str : c + str;
        }


        public static string EnsureStartsWith(this string str, char c, bool ignoreCase, CultureInfo culture)
        {
            return str == null
                ? throw new ArgumentNullException(nameof(str))
                : str.StartsWith(c.ToString(culture), ignoreCase, culture) ? str : c + str;
        }



        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// indicates whether this string is null, empty, or consists only of white-space characters.
        /// </summary>

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }


        public static string Left(this string str, int len)
        {
            return str == null
                ? throw new ArgumentNullException(nameof(str))
                : str.Length < len
                ? throw new ArgumentException("len argument can not be bigger than given string's length!")
                : str[..len];
        }


        public static string NormalizeLineEndings(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
        }


        public static int NthIndexOf(this string str, char c, int n)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != c)
                {
                    continue;
                }

                if (++count == n)
                {
                    return i;
                }
            }

            return -1;
        }


        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            if (str == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (postFixes == null || postFixes.Length == 0)
            {
                return str;
            }

            foreach (string postFix in postFixes)
            {
                if (str.EndsWith(postFix))
                {
                    return str.Left(str.Length - postFix.Length);
                }
            }

            return str;
        }


        public static string RemovePreFix(this string str, params string[] preFixes)
        {
            if (str == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if (preFixes == null || preFixes.Length == 0)
            {
                return str;
            }

            foreach (string preFix in preFixes)
            {
                if (str.StartsWith(preFix))
                {
                    return str.Right(str.Length - preFix.Length);
                }
            }

            return str;
        }


        public static string Right(this string str, int len)
        {
            return str == null
                ? throw new ArgumentNullException(nameof(str))
                : str.Length < len
                ? throw new ArgumentException("len argument can not be bigger than given string's length!")
                : str.Substring(str.Length - len, len);
        }


        public static string[] Split(this string str, string separator)
        {
            return str.Split(new[] { separator }, StringSplitOptions.None);
        }


        public static string[] Split(this string str, string separator, StringSplitOptions options)
        {
            return str.Split(new[] { separator }, options);
        }


        public static string[] SplitToLines(this string str)
        {
            return str.Split(Environment.NewLine);
        }


        public static string[] SplitToLines(this string str, StringSplitOptions options)
        {
            return str.Split(Environment.NewLine, options);
        }


        public static string ToCamelCase(this string str, bool invariantCulture = true)
        {
            return string.IsNullOrWhiteSpace(str)
                ? str
                : str.Length == 1
                ? invariantCulture ? str.ToLowerInvariant() : str.ToLower()
                : (invariantCulture ? char.ToLowerInvariant(str[0]) : char.ToLower(str[0])) + str[1..];
        }


        public static string ToCamelCase(this string str, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(str) ? str : str.Length == 1 ? str.ToLower(culture) : char.ToLower(str[0], culture) + str[1..];
        }


        public static string ToSentenceCase(this string str, bool invariantCulture = false)
        {
            return string.IsNullOrWhiteSpace(str)
                ? str
                : Regex.Replace(
                str,
                "[a-z][A-Z]",
                m => m.Value[0] + " " + (invariantCulture ? char.ToLowerInvariant(m.Value[1]) : char.ToLower(m.Value[1]))
            );
        }

        /// <summary>
        /// Converts given PascalCase/camelCase string to sentence (by splitting words by space).
        /// Example: "ThisIsSampleSentence" is converted to "This is a sample sentence".
        /// </summary>
        /// <param name="str">String to convert.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        public static string ToSentenceCase(this string str, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(str)
                ? str
                : Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1], culture));
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value)
            where T : struct
        {
            return value == null ? throw new ArgumentNullException(nameof(value)) : (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Converts string to enum value.
        /// </summary>
        /// <typeparam name="T">Type of enum</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>Returns enum object</returns>
        public static T ToEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            return value == null ? throw new ArgumentNullException(nameof(value)) : (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="invariantCulture">Invariant culture</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, bool invariantCulture = true)
        {
            return string.IsNullOrWhiteSpace(str)
                ? str
                : str.Length == 1
                ? invariantCulture ? str.ToUpperInvariant() : str.ToUpper()
                : (invariantCulture ? char.ToUpperInvariant(str[0]) : char.ToUpper(str[0])) + str[1..];
        }

        /// <summary>
        /// Converts camelCase string to PascalCase string in specified culture.
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <param name="culture">An object that supplies culture-specific casing rules</param>
        /// <returns>PascalCase of the string</returns>
        public static string ToPascalCase(this string str, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(str) ? str : str.Length == 1 ? str.ToUpper(culture) : char.ToUpper(str[0], culture) + str[1..];
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string Truncate(this string str, int maxLength)
        {
            return str == null ? null : str.Length <= maxLength ? str : str.Left(maxLength);
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds a "..." postfix to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength)
        {
            return str.TruncateWithPostfix(maxLength, "...");
        }

        /// <summary>
        /// Gets a substring of a string from beginning of the string if it exceeds maximum length.
        /// It adds given <paramref name="postfix"/> to end of the string if it's truncated.
        /// Returning string can not be longer than maxLength.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="str"/> is null</exception>
        public static string TruncateWithPostfix(this string str, int maxLength, string postfix)
        {
            if (str == null)
            {
                return null;
            }

            if (string.IsNullOrEmpty(str) || maxLength == 0)
            {
                return string.Empty;
            }

            return str.Length <= maxLength
                ? str
                : maxLength <= postfix.Length ? postfix.Left(maxLength) : str.Left(maxLength - postfix.Length) + postfix;
        }

        public static string ReplaceAll(this string seed, char[] chars, string replacementCharacter)
        {
            return chars.Aggregate(seed, (str, cItem) => str.Replace(cItem.ToString(), replacementCharacter));
        }
    }

    public static class JsonExtensions
    {
        public static bool IsNullOrEmpty(this JToken token)
        {
            return token == null ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == string.Empty) ||
                   token.Type == JTokenType.Null;
        }
    }
}
