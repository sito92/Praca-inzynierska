using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Common.ConstStrings;
using Logic.Inset.Helpers;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Services
{
    public class InsetParser:IInsetParser
    {
        private IInsetRecognizer _insetRecognizer;
        private IParsersFactory _parsersFactory;
        public InsetParser(IInsetRecognizer insetRecognizer, IParsersFactory parsersFactory)
        {
            _insetRecognizer = insetRecognizer;
           _parsersFactory = parsersFactory;
        }
        private string ParseInset(Match match)
        {
            var inset = match.Value;
            if (_insetRecognizer.IsValid(inset))
            {
                var parser = _parsersFactory.GetParser(InsetHelper.GetName(inset));
                //var insetModel = _insetRecognizer.GetInsetModel(inset);
                return parser.Parse(inset);
            }
            return inset;
        }

        public string ParseContent(string content)
        {
            var decodedContent = WebUtility.HtmlDecode(content);
            var parsed = Regex.Replace(decodedContent, RegularExpressions.Inset, ParseInset);
            return parsed;
        }
    }
}
