using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.News.Interfaces;

namespace AdminPanel.Controllers
{
    public class NewsController : BaseController
    {
        private INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);

        }

    }
}
