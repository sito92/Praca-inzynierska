using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Models.Calendar;
using Logic.Inset.Interfaces;
using Logic.Service.Interfaces;
using Logic.Statistics.Filters;
using Logic.Statistics.Interfaces;
using Newtonsoft.Json;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private readonly IStatisticsService _service;
        private readonly IServiceProviderService _provider;
        private readonly IServiceTypeService _types;
        private readonly IServicesService _services;
        public TestController(IStatisticsService service, IServiceProviderService provider,IServiceTypeService types,IServicesService services)
        {
            _services = services;
            _service = service;
            _types = types;
            _provider = provider;
        }
        //
        // GET: /Test/
        [StatisticsFilter]
        public ActionResult Test()
        {
            //var a = _service.GetAllUsers();
            //var b = _service.GetUniqueUsers();
            //var d = _service.GetUsersTotalAmount();
            //var e = _service.GetUsersPerCountry();
            //var c = _service.GetUsersForSelectedMonth(10,2015);
            //var f = _service.GetUsersForEveryMonth(2015);
            //var g = _service.GetUsersBetweenDates(new DateTime(2014, 1, 1), new DateTime(2016, 1, 1));
            //var g1 = _service.GetUsersBetweenDates(null, new DateTime(2016, 1, 1));
            //var g2 = _service.GetUsersBetweenDates(new DateTime(2014, 1, 1), null);
            //var g3 = _service.GetUsersBetweenDates(null,null);
            //var h = _service.GetActionsBetweenDates(null, null);
            //var a = _types.GetById(1);
            //var i = _provider.GetAllProvidersWithAvailableServices(a);
            var allServices = _services.GetAll();

            JsonEventsListViewModel events= new JsonEventsListViewModel(allServices);
            JsonEventViewModel model = new JsonEventViewModel();
            model.Title = "Asdfasdfasd";

            var jsonObject = JsonConvert.SerializeObject(model);
            return View();
        }

    }
}
