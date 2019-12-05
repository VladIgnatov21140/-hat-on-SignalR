using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
    public static class StringExtensions
    {
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
