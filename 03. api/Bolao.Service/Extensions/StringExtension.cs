using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bolao.Service//.Extensions
{
    public static class StringExtension
    {
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var pattern = @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+";

            if (!string.IsNullOrEmpty(pattern))
                return Regex.Match(email, pattern).Success;

            return false;
        }

        public static bool IsValidUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            var pattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()!@:%_\+.~#?&\/\/=]*)";

            if (!string.IsNullOrEmpty(pattern))
                return Regex.Match(url, pattern).Success;

            return false;
        }
    }
}
