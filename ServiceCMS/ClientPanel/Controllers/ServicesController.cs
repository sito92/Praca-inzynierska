using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Models.Calendar;
using Logic.Common.Models;
using Logic.MailManagement.Interfaces;
using Logic.Service.Interfaces;
using Logic.Settings.Interfaces;

namespace ClientPanel.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterService(RegistratedServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _servicesService.Insert(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetAll()
        {
            var services = _servicesService.GetAll();
            JsonEventsListViewModel events = new JsonEventsListViewModel(services.Where(x=>x.ServiceProvider.Id==3).ToList());

            return new JsonNetResult(new { success = true, data = events }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetProviderServicesAtDate(ServiceProviderModel provider,DateTime date)
        {
            var services = _servicesService.GetAllServicesWithMatchingCriteria(date,provider);
            JsonEventsListViewModel events = new JsonEventsListViewModel(services);

            return new JsonNetResult(new { success = true, data = events }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllRegisteredServices()
        {
            var registeredServices = _servicesService.GetAll();
            
            if(registeredServices.Count > 0)
                return Json(new { success = true, data = registeredServices }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRegisteredServicesWithMatchingProvider(ServiceProviderModel serviceProvider)
        {
            if(ModelState.IsValid)
            { 
                var registeredServices = _servicesService.GetAllServicesWithMatchingCriteria(serviceProvider);
                return Json(new { success = true, data = registeredServices }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }

    }
}
