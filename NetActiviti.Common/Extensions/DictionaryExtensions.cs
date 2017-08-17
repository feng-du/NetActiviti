using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetActiviti.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            if (dict == null)
                return default(TValue);

            if (dict.ContainsKey(key))
                return dict[key];
            else
                return default(TValue);
        }
    }

    
}
