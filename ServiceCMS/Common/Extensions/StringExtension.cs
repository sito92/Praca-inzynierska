using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtension
    {
        public static string UpperFirst(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return string.Empty;
            }
            return char.ToUpper(val[0]) + val.Substring(1);
        }
    }
}
