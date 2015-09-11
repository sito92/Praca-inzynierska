using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Logic.Common.Models;
using Logic.Inset.Helpers;

namespace Logic.Inset.Parsers
{
    class ExternalLinkParser:Parser
    {
        private string url = "url";
        private string text = "text";

        public override string Tag
        {
            get { return "a"; }
        }

        public override string Parse(string inset)
        {
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);

            var urlData = arguments[url];
            ParserTagBuilder.Attributes.Add("href", urlData);

            if (arguments.ContainsKey(text))
            {
                var textData = arguments[text];
                ParserTagBuilder.SetInnerText(textData);
            }
            
            
            
           


            return ParserTagBuilder.ToString();

        }
    }
}
