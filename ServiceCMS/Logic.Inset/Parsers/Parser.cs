using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Common.Models;
using Logic.Inset.Interfaces;

namespace Logic.Inset.Parsers
{
    abstract class Parser : IParser
    {
        public abstract string Parse(string inset);

    }
}
