using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Models.Calendar;
using Logic.Common.Models;
using Logic.Service.Interfaces;
using Logic.Settings.Interfaces;
using Modules.Resources;

namespace ClientPanel.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesService _servicesService;
        private readonly ISettingsService _settingsService;
        public ServicesController(IServicesService servicesService,ISettingsService settingsService)
        {
            _servicesService = servicesService;
            _settingsService = settingsService;
        }

        public ViewResult Register()
        {
            var registerServiceEnabled = _settingsService.GetPropertyByName("RegisterServiceEnabled");

            return registerServiceEnabled == "True" ? View() : View("SiteNotFound");
        }

        [HttpPost]
        public ActionResult RegisterService(RegistratedServiceModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _servicesService.Insert(model);
                return Json(new { success = response.IsSucceed, message = Presentation.SuccessRegisterService }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false ,message = Presentation.FailedRegisterService}, JsonRequestBehavior.AllowGet);

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
