using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Inset.Interfaces;
using Logic.Inset.Parsers;

namespace Logic.Inset.Services
{
    public class ParsersFactory:IParsersFactory
    {
        
        private Dictionary<string, IParser> parsers = new Dictionary<string, IParser>()
        {
            {"link", new LinkParser()}
        };
        public IParser GetParser(string name)
        {
            return parsers[name];
        }
    }
}
