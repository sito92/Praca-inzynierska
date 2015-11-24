using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Service.Interfaces;

namespace AdminPanel.Controllers
{
    public class ServiceTypeController : Controller
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

    }
}
