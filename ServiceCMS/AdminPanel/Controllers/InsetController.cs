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

        public InsetController(IInsetService insetService)
        {
            _insetService = insetService;
        }
        public ActionResult Index()
        {
            return View();
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
    }
}
