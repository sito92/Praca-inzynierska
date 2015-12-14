using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Enums;
using Logic.Common.Models;
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

        public ViewResult Index()
        {
            return View();
        }
        
        public ActionResult GetAllFiles()
        {
            var images = _fileService.GetAllFiles(FileTypeEnum.Image);
            if (images != null)
                return Json(new {success = true, data = images}, JsonRequestBehavior.AllowGet);
            else
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(FileModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Insert(model);
                return Json(new {success = true, data = response},JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(FileModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Update(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(FileModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Delete(model.Id);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
