using Logic.Statistics.Interfaces;
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
using AdminPanel.Models.Calendar;
using Logic.Inset.Interfaces;
using Logic.MenuButton.Interfaces;
using Logic.Page.Interfaces;
using Logic.Service.Interfaces;
using Logic.Statistics.Filters;
using Logic.Statistics.Interfaces;
using Logic.News.Interfaces;
using Newtonsoft.Json;
using Logic.MailManagement.Interfaces;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private readonly IStatisticsService _service;
        private readonly IServiceProviderService _provider;
        private readonly IServiceTypeService _types;
        private readonly IMailManagementService _mail;
        private readonly IMenuButtonService _menuButton;
        private readonly IPageService _pageService;
        private readonly IServicesService _servicesService;
        private readonly IFileService _fileService;
        private readonly INewsService _newsService;

        public TestController(IMailManagementService mail, IServiceTypeService types, IServiceProviderService provider)
        {
            _provider = provider;
            _mail = mail;
            _types = types;
        }
        //
        // GET: /Test/
        [StatisticsFilter]
        public ActionResult Test()
        {   
            //var d = new DateTime(2015,12,1,10,0,0);
            //var d1 = new DateTime(2015, 12, 1, 9, 0, 0);
            //var d2 = new DateTime(2015, 12, 1, 11, 0, 0);
            //var d3 = new DateTime(2015, 12, 1, 11, 40, 0);
            //var d4 = new DateTime(2015, 12, 1, 10, 0, 0);
            //var d5 = new DateTime(2015, 12, 1, 10, 0, 0);
            //var d6 = new DateTime(2015, 12, 1, 10, 0, 0);

            //var provider = _provider.GetById(1);

            //var a = _types.GetServiceTypesMatchingTimeCriteria(d, provider); // M:false,false
            //var B = _types.GetServiceTypesMatchingTimeCriteria(d1, provider); //M:true,false
            //var c = _types.GetServiceTypesMatchingTimeCriteria(d2, provider); // 
            //var ee = _types.GetServiceTypesMatchingTimeCriteria(d3, provider); // M:true, false
            //var e = _types.GetServiceTypesMatchingTimeCriteria(d4, provider);
            //var f = _types.GetServiceTypesMatchingTimeCriteria(d5, provider);

            List<string> addresses = new List<string>()
            {
                "arturstelmach92@gmail.com",
                "kamil.slusarczyk@hotmail.com"
            };

            var a = _mail.SendMailToMany(addresses, "DUPA", "DUPA nie temat", "servicecmsthesis@gmail.com");

            return View();
        }

    }
}
