using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using Logic.File.Interfaces;
using Modules.FileManager.Interfaces;

namespace ClientPanel.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IFileManager _fileManager;
        public FileController(IFileService fileService,IFileManager fileManager)
        {
            _fileService = fileService;
            _fileManager = fileManager;
        }

        public ActionResult Download(int fileId)
        {
            var fileModel = _fileService.GetById(fileId);
            if (fileModel!=null)
            {
                var fileData = _fileManager.GetFileData(fileModel.Path);
                if (fileData != null)
                {
                    var pathFileName = Path.GetFileName(fileModel.Path);
                    var minme = MimeMapping.GetMimeMapping(pathFileName);
                    return File(fileData, minme, pathFileName);
                }
            }
            return View("Error");
           
        }

    }
}
