using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Interfaces;
using Logic.News.Interfaces;

namespace ClientPanel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly string showPopUp = "ShowPopUp";
        private readonly INewsService _newsService;
        private readonly ISessionManager _sessionManager;
        public HomeController(INewsService newsService,ISessionManager sessionManager)
        {
            _newsService = newsService;
            _sessionManager = sessionManager;
        }

        public ActionResult Index()
        {

            if (!_sessionManager.IsSet(showPopUp))
            {
             _sessionManager.Set(showPopUp,true);
            }
            else
            {
                _sessionManager.Set(showPopUp,false);
            }
            var newses = _newsService.GetNewestNewsesCollection().ToList();
   
            if(newses.Any())
                return View(newses);

            return View("PageNotFound");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
