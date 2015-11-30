﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DAL.Factory;
using DAL.UnitOfWork;
using Logging;
using Logic.Common.Models;
using Logic.Statistics.Interfaces;
using Logic.Statistics.Services; //DO WYJEBANIA

namespace Logic.Statistics.Filters
{
    //public class MyAuthorizeAttribute : FilterAttribute { }

    public class StatisticsFilter : ActionFilterAttribute
    {
        //private readonly IStatisticsService _service;

        //public StatisticsFilter(IStatisticsService service)
        //{
        //    _service = service;
        //}

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
           var _service = new StatisticsService(new UnitOfWorkFactory(), new Logger());
            base.OnActionExecuted(filterContext);
            if (filterContext.IsChildAction) //if action call was from view like @Html.Action do nothing
                return;

            //do testów
            //var userIp = filterContext.HttpContext.Request.UserHostAddress;
            //string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            //string actionName = filterContext.ActionDescriptor.ActionName;
            //var timeStamp = filterContext.HttpContext.Timestamp;
            
            var siteEntry = new StatisticsInformationModel()
            {
                IP = filterContext.HttpContext.Request.UserHostAddress,
                ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                ActionName = filterContext.ActionDescriptor.ActionName,
                Date = filterContext.HttpContext.Timestamp
            };
            _service.AddEntry(siteEntry);
        }

    }
}