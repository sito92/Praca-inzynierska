using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class ServiceTypeController : BaseController
    {
        private IServiceTypeService _serviceTypeService;
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
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
        public ActionResult Add(ServiceTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _serviceTypeService.Insert(model);

                return  Json(new {success=response.IsSucceed,message=response.Message}, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, errors = GetModelErrors() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(ServiceTypeModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _serviceTypeService.Update(model);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, errors = GetModelErrors() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id>0)
            {
                var response = _serviceTypeService.Delete(id);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, errors = GetModelErrors() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll()
        {
            var serviceTypes = _serviceTypeService.GetAll();

            return Json(new { success = true, data = serviceTypes }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetServiceTypesMatchingTimeCriteria(DateTime time, ServiceProviderModel provider)
        {
            var services = _serviceTypeService.GetServiceTypesMatchingTimeCriteria(time, provider);

            return new JsonNetResult(new { success = true, data = services.ToArray() }, JsonRequestBehavior.AllowGet);
        }
    }
}
