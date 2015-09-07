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
        public override string Parse(string inset)
        {
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);
            var urlData = arguments[url];

            TagBuilder tagBuilder = new TagBuilder("<a>");
            tagBuilder.Attributes.Add(url,urlData);

            return tagBuilder.ToString(TagRenderMode.SelfClosing);

        }
    }
}
