﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Inset.Interfaces;
using Logic.Statistics.Filters;
using Logic.Statistics.Interfaces;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private readonly IStatisticsService _service;
        public TestController(IStatisticsService service)
        {
            _service = service;
        }
        //
        // GET: /Test/
        [StatisticsFilter]
        public ActionResult Test()
        {
            //var a = _service.GetAllUsers();
            //var b = _service.GetUniqueUsers();
            //var d = _service.GetUsersTotalAmount();
            var e = _service.GetUsersPerCountry();
            //var c = _service.GetUsersForSelectedMonth(10);
            //var f = _service.GetUsersForEveryMonth(2015);
            //var g = _service.GetUsersBetweenDates(new DateTime(2014, 1, 1), new DateTime(2016, 1, 1));
            return View();
        }

    }
}
