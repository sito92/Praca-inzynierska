using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using AdminPanel.Models.File;
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
        
        public ActionResult GetAllFiles(FileTypeEnum fileType)
        {
            ICollection<FileModel> files = fileType != 0 ? _fileService.GetAllFiles(fileType) : _fileService.GetAllFiles();

            if (files != null)
                return Json(new { success = true, data = files }, JsonRequestBehavior.AllowGet);
            else
                return Json(new {success = false}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(FileModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Insert(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
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
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var modelString = Request.Form["model"];
            var response = _fileService.UploadWithInsert(file);
            return new JsonNetResult(new {success=response.IsSucceed,message=response.Message});
        }
        [HttpPost]
        public ActionResult Delete(FileModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _fileService.Delete(model.Id);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }
    }
}
