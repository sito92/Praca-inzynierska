using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ConstStrings
{
    public static class RegularExpressions
    {
        public const string NotInQuotes = @"(?<=^(([^""]*(?<!\\)""[^""]*(?<!\\)""[^""]*)*|[^""]*))";
        public const string Inset = NotInQuotes+@"\[(.*?)\]";
        public const string InsetSeparator = NotInQuotes+@";";
        public const string ArgumentValue = NotInQuotes + @"=";
        public const string ArgumentCollectionSeparator = NotInQuotes + ",";

    }
}
