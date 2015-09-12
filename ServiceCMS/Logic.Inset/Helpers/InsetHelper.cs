using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.WebPages;
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
            var result = new Dictionary<string,string>();
            var insetWithOutTags = GetInsetWithOutTags(inset);

            var insetData = GetInsetData(insetWithOutTags).Where(x => x.Contains(equalChar)).Distinct();


            foreach (var data in insetData)
            {
                var splited = Regex.Split(data, RegularExpressions.ArgumentValue,RegexOptions.ExplicitCapture);
                var argument = splited.Last().Remove(0, 1);

                result.Add(splited.First(), argument.Remove(argument.Length-1));
            }



            return result;

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
            return Regex.Split(insetWithOutTags, RegularExpressions.InsetSeparator,RegexOptions.ExplicitCapture);
            return insetWithOutTags.Split();
        }
    }
}
