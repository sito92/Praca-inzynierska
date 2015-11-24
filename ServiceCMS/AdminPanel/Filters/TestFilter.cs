using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.News.Interfaces;

namespace AdminPanel.Filters
{
    public class TestFilter : ActionFilterAttribute
    {
        public INewsService _newsService { get; set; }
        //public TestFilter(INewsService newsService)
        //{
        //    _newsService = newsService;
        //}
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _newsService.GetAll();
        }
    }
}