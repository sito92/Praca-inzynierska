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
    class LinkParser:Parser
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
            var textData = arguments[text];
            
            ParserTagBuilder.Attributes.Add("href",urlData);
            ParserTagBuilder.SetInnerText(textData);


            return ParserTagBuilder.ToString();

        }
    }
}
