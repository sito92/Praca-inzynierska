using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using AdminPanel.Extensions;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class RegistratedServicesController : BaseController
    {
        private IServicesService _servicesService;
        public RegistratedServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);

        }

      
        [HttpPost]
        public ActionResult Edit(RegistratedServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _servicesService.Update(model);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult(new { success = false, errors = GetModelErrors() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var response = _servicesService.Delete(id);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return new JsonNetResult(new { success = false, errors = GetModelErrors() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll()
        {
            var services = _servicesService.GetAll();

            return new JsonNetResult(new { success = true, data = services }, JsonRequestBehavior.AllowGet);
        }
    }
}
