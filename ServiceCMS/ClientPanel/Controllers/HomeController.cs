using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.News.Interfaces;

namespace ClientPanel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            var newses = _newsService.GetAll().ToList();
   
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
