using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ConstStrings;

namespace Logic.Inset.Helpers
{
    public static class InsetHelper
    {
        private static char equalChar = '=';
        public static string GetName(string inset)
        {
            var insetWithOutTags = GetInsetWithOutTags(inset);

            var insetData = GetInsetData(insetWithOutTags);

            return insetData.First();
        }

        public static Dictionary<string, string> GetArgumetnsDictionary(string inset)
        {
            var insetWithOutTags = GetInsetWithOutTags(inset);

            var insetData = GetInsetData(insetWithOutTags).Where(x=>x.Contains(equalChar));

            return  insetData.Select(data => data.Split(equalChar)).ToDictionary(splitedArgument => splitedArgument[0], splitedArgument => splitedArgument[1]);
        }
        public static IEnumerable<string> GetArguments(string inset)
        {
            var insetWithOutTags = GetInsetWithOutTags(inset);

            var insetData = GetInsetData(insetWithOutTags);

            return insetData.Where(x => x.Contains(equalChar));
        }
        private static string GetInsetWithOutTags(string inset)
        {
            return inset.Replace(Tags.OpenInsetTag, "").Replace(Tags.CloseInsetTag, "");
        }

        private static string[] GetInsetData(string insetWithOutTags)
        {
            return insetWithOutTags.Split(Separators.InsetArgumentSpliter);
        }
    }
}
