using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToURL(this string s)
        {
            string text = s.ToLower();

            text = text.Replace("ı", "i")
                       .Replace("ş", "s")
                       .Replace("ğ", "g")
                       .Replace("ç", "c")
                       .Replace("ü", "u")
                       .Replace("ö", "o");

            text = Regex.Replace(text, @"[^\w\d\s]", "");
            text = Regex.Replace(text, @"\s+", " ");
            text = text.Trim();
            text = text.Replace(" ", "-");

            return text;
        }
    }
}
