using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string s1, string s2)
        {
            if (s1 == null || s2 == null)
                return false;

            return s1.ToLower() == s2.ToLower();
        }
    }
}
