using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Common.Extensions
{
    public static class ListExtensions
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            if (list == null)
                return true;

            if (list.Count <= 0)
                return true;

            return false;
        }
    }
}
