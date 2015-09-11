using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic.Inset.Interfaces;
using Logic.Inset.Parsers;
using Logic.User.Interfaces;

namespace Logic.Inset.Services
{
    public class ParsersFactory : IParsersFactory
    {
        private static IUserService _userService;

        public ParsersFactory(IUserService userService)
        {
            _userService = userService;
        }
        private Dictionary<string, Func<IParser>> parsers = new Dictionary<string, Func<IParser>>()
        {
            {"externalLink", ()=>new ExternalLinkParser()},
            {"user",()=>new UserParser(_userService)}
        };
        public IParser GetParser(string name)
        {
            return parsers[name]();
        }

    }
}
