using System.Security.Cryptography;
using System.Text;

namespace DataLayer
{
    /// <summary>
    /// Class with string's extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Encryption input string by MD5 method
        /// </summary>
        /// <param name="inputstr">String for encryption</param>
        /// <returns>Encrypted input string by MD5 method</returns>
        public static string MD5Cryptography(this string inputstr)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(inputstr));
            StringBuilder resultstring = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                resultstring.Append(data[i].ToString("x2"));
            }
            return resultstring.ToString();
        }
    }
}
