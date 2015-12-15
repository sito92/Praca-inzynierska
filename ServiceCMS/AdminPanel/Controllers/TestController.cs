using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using Common.Enums;
using DAL.Factory;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using Logic.Common.Models;
using Logic.File.Interfaces;
=======
using AdminPanel.Models.Calendar;
>>>>>>> b37ea363cee5c77a0b7014e0e196d8c6c12f5e67
using Logic.Inset.Interfaces;
using Logic.MenuButton.Interfaces;
using Logic.Page.Interfaces;
using Logic.Service.Interfaces;
using Logic.Statistics.Filters;
using Logic.Statistics.Interfaces;
<<<<<<< HEAD
using Logic.News.Interfaces;
=======
using Newtonsoft.Json;
>>>>>>> b37ea363cee5c77a0b7014e0e196d8c6c12f5e67

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private readonly IStatisticsService _service;
        private readonly IServiceProviderService _provider;
        private readonly IServiceTypeService _types;
<<<<<<< HEAD
        private readonly IMenuButtonService _menuButton;
        private readonly IPageService _pageService;
        private readonly IServicesService _servicesService;
        private readonly IFileService _fileService;
        private readonly INewsService _newsService;
        public TestController(IServicesService servicesService, INewsService newsService,IFileService fileService,IPageService pageService,IMenuButtonService menuButton,IStatisticsService service, IServiceProviderService provider,IServiceTypeService types)
        {
            _servicesService = servicesService;
            _newsService = newsService;
            _fileService = fileService;
            _menuButton = menuButton;
=======
        private readonly IServicesService _services;
        public TestController(IStatisticsService service, IServiceProviderService provider,IServiceTypeService types,IServicesService services)
        {
            _services = services;
>>>>>>> b37ea363cee5c77a0b7014e0e196d8c6c12f5e67
            _service = service;
            _types = types;
            _provider = provider;
            _pageService = pageService;
        }
        //
        // GET: /Test/
        [StatisticsFilter]
        public ActionResult Test()
<<<<<<< HEAD
        {          

            var d = new DateTime(2015,12,1,10,0,0);

            var pr = _provider.GetById(1);
            var a = _types.GetServiceTypesMatchingTimeCriteria(d, pr);
=======
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
>>>>>>> b37ea363cee5c77a0b7014e0e196d8c6c12f5e67
            return View();
        }

    }
}
