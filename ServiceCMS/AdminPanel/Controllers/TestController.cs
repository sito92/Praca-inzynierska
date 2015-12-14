using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Enums;
using DAL.Factory;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using Logic.Common.Models;
using Logic.File.Interfaces;
using Logic.Inset.Interfaces;
using Logic.MenuButton.Interfaces;
using Logic.Page.Interfaces;
using Logic.Service.Interfaces;
using Logic.Statistics.Filters;
using Logic.Statistics.Interfaces;
using Logic.News.Interfaces;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private readonly IStatisticsService _service;
        private readonly IServiceProviderService _provider;
        private readonly IServiceTypeService _types;
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
            _service = service;
            _types = types;
            _provider = provider;
            _pageService = pageService;
        }
        //
        // GET: /Test/
        [StatisticsFilter]
        public ActionResult Test()
        {          

            var d = new DateTime(2015,12,1,10,0,0);

            var pr = _provider.GetById(1);
            var a = _types.GetServiceTypesMatchingTimeCriteria(d, pr);
            return View();
        }

    }
}
