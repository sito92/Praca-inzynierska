using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.File.Interfaces;

namespace AdminPanel.Controllers
{
    public class FileController : BaseController
    {

        private IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        //
        // GET: /File/
        public ActionResult GetAllImages()
        {
            var images = _fileService.GetAllImages();

            return Json(new {success = true, data = images},JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
