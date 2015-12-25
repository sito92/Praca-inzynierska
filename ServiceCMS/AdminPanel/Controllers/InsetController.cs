using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Inset.Interfaces;

namespace AdminPanel.Controllers
{
    public class InsetController : BaseController
    {
        private IInsetService _insetService;
        private IInsetRecognizer _insetRecognizer;
        public InsetController(IInsetService insetService,IInsetRecognizer insetRecognizer)
        {
            _insetService = insetService;
            _insetRecognizer = insetRecognizer;
        }

        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }

        public ActionResult GetAll()
        {
            var insets = _insetService.GetAll();
            var localizedName = insets[0].LocalizedName;
            return Json(new {success = true, data = insets},JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInsetPart(string name)
        {
            return PartialView("InsetParts/" + name);
        }

        public ActionResult Validate(string inset)
        {
            var isValid = _insetRecognizer.IsValid(inset);


            return Json(new {success = isValid},JsonRequestBehavior.AllowGet);
        }
    }
}
