using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Responses;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class ServiceProviderController : Controller
    {
        private IServiceProviderService _serviceProviderService;

        public ServiceProviderController(IServiceProviderService serviceProviderService)
        {
            _serviceProviderService = serviceProviderService;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var serviceProviders = _serviceProviderService.GetAll();
            return Json(new { success = true, data = serviceProviders }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id = 0)
        {
            var serviceProviders = _serviceProviderService.GetById(id);

            if(serviceProviders != null)
                return Json(new { success = true, data = serviceProviders }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(ServiceProviderModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _serviceProviderService.Insert(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Edit(ServiceProviderModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _serviceProviderService.Update(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var response = _serviceProviderService.Delete(id);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetAllServiceProvidersWithAvailableServices(ServiceTypeModel serviceType)
        {
            if (ModelState.IsValid)
            {
                var result = _serviceProviderService.GetAllProvidersWithAvailableServices(serviceType);
                return Json(new { success = true, data = result}, JsonRequestBehavior.AllowGet);
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
