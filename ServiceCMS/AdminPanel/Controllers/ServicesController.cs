﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using AdminPanel.Models.Calendar;
using Logic.Common.Models;
using Logic.Service.Interfaces;
using Newtonsoft.Json;

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

       // public ActionResult GetProviderServicesFromDate()

        public ActionResult GetProviderServicesAtDate(DateTime date)
        {
            var services = _servicesService.GetAllServicesWithMatchingCriteria(date);
            JsonEventsListViewModel events = new JsonEventsListViewModel(services.Where(x => x.ServiceProvider.Id == 3).ToList());

            return new JsonNetResult(new { success = true, data = events }, JsonRequestBehavior.AllowGet);
        }

    }
}
