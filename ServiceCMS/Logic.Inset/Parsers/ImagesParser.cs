using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Logic.File.Interfaces;
using Logic.Inset.Helpers;
using Modules.FileManager.Interfaces;

namespace Logic.Inset.Parsers
{
    class ImagesParser:Parser
    {
        private string ids = "ids";
        private char idsSeparator = ',';
        private string srcAttribiute = "src";
        private string dataMime = "data:";
        private string base64 = ";base64,";
        private readonly IFileService _fileService;
        private readonly IFileManager _fileManager;
        public ImagesParser(IFileService fileService,IFileManager fileManager)
        {
            _fileService = fileService;
            _fileManager = fileManager;
        }
        public override string Tag
        {
            get { return "div"; }
        }

        public override string Parse(string inset)
        {
            var arguments = InsetHelper.GetArgumetnsDictionary(inset);
            TagBuilder[] imagesBuilders;
            var idsString = arguments[ids];
            var idsAray = idsString.Split(idsSeparator);
            string test = "";
            foreach (var id in idsAray)
            {
                var intId = Convert.ToInt32(id);
                var file = _fileService.GetById(intId);
                if (file != null)
                {
                    var imageData = _fileManager.GetFileData(file.Path);
                    if (imageData!=null)
                    {
                        var mimeFileName = Path.GetFileName(file.Path);
                        var mime = MimeMapping.GetMimeMapping(mimeFileName);
                        var imageString = Convert.ToBase64String(imageData);
                        TagBuilder imageBuilder = new TagBuilder("img");
                        TagBuilder divBuilder = new TagBuilder("div");
                        divBuilder.AddCssClass("inset-image-container");
                        imageBuilder.AddCssClass("inset-image");
                        imageBuilder.Attributes.Add(srcAttribiute, dataMime+mime+base64+imageString);
                        divBuilder.InnerHtml = imageBuilder.ToString();
                        ParserTagBuilder.InnerHtml += divBuilder.ToString();
                    }
                  
                }
            }
            

            //if (arguments.ContainsKey(text))
            //{
            //    var textData = arguments[text];
            //    ParserTagBuilder.SetInnerText(textData);
            //}

            ParserTagBuilder.AddCssClass("inset-images");
            return ParserTagBuilder.ToString();
        }
    }
}
