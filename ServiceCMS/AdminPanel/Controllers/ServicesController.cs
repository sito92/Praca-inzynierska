using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class ServicesController : Controller
    {
        private IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        public ActionResult Test()
        {
            return View();
        }

    }
}
