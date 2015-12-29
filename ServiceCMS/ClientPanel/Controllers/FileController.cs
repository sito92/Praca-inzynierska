using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using Logic.File.Interfaces;

namespace ClientPanel.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        //public ActionResult Download(int fileId)
        //{
        //    var response = _fileService.Download(fileId);

        //    return new JsonNetResult(new { success = response.IsSucceed }, JsonRequestBehavior.AllowGet);
        //}

    }
}
