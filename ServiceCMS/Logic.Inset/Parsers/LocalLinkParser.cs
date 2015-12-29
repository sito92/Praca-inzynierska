using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Inset.Helpers;
using Logic.Page.Interfaces;

namespace Logic.Inset.Parsers
{
    class LocalLinkParser:Parser
    {
        private string id = "id";
        private string pagesUrl = "/Page/Show/";
        private string text = "text";
        public override string Tag
        {
            get { return "a"; }
        }

        public override string Parse(string inset)
        {
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);

            var pageId = arguments[id];
            ParserTagBuilder.Attributes.Add("href", pagesUrl+pageId);

            if (arguments.ContainsKey(text))
            {
                var textData = arguments[text];
                ParserTagBuilder.SetInnerText(textData);
            }


            return ParserTagBuilder.ToString();
        }
    }
}
