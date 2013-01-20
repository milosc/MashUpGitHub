using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Bizis.Site.Common.Utility
{
    public class TextUtility
    {
        public static string GetMD5Hash(string value)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2");
            return ret;
        }

        public static string RemoveWhitespaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            return Regex.Replace(input, @"\p{Z}|\n|\r|\t", "");
        }
        public static string TrimWhitespaces(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            string s = Regex.Replace(input, @"\p{Z}|\n|\r|\t", " ");
            return Regex.Replace(s, @"\s+", " ").Trim();

        }
    }
}
