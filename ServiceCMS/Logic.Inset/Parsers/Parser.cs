using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Profile;
using Logic.Common.Models;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Parsers
{
    abstract class Parser : IParser
    {
        private TagBuilder _tagBuilder;
        public abstract string Tag { get; }
        public TagBuilder ParserTagBuilder {
            get
            {

                if (this._tagBuilder == null)
                {
                    this._tagBuilder = new TagBuilder(Tag);
                }
                return _tagBuilder;
            
            }
        }

        public abstract string Parse(string inset);


    }
}
