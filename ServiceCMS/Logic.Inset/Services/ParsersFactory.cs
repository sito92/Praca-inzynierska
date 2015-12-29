using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logic.File.Interfaces;
using Logic.Inset.Interfaces;
using Logic.Inset.Parsers;
using Logic.Page.Interfaces;
using Logic.User.Interfaces;
using Modules.FileManager.Interfaces;

namespace Logic.Inset.Services
{
    public class ParsersFactory : IParsersFactory
    {
        private static IUserService _userService;
        private static IFileService _fileService;
        private static IFileManager _fileManager;

        public ParsersFactory(IUserService userService, IFileService fileService,IFileManager fileManager)
        {
            _userService = userService;
            _fileService = fileService;
            _fileManager = fileManager;
        }
        private Dictionary<string, Func<IParser>> parsers = new Dictionary<string, Func<IParser>>()
        {
            {"externalLink", ()=>new ExternalLinkParser()},
            {"user",()=>new UserParser(_userService)},
            {"localLink",()=>new LocalLinkParser()},
            {"images",()=>new ImagesParser(_fileService,_fileManager)},


        };
        public IParser GetParser(string name)
        {
            return parsers[name]();
        }

    }
}
