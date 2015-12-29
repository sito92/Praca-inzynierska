using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Filters;
using Logic.News.Interfaces;

namespace ClientPanel.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [StatisticsFilter]
        public ViewResult Index()
        {
            return View();
        }

        [StatisticsFilter]
        public ViewResult Show(int id)
        {
            var result = _newsService.GetById(id);

            if (result != null)
                return View(result);
            else
                return View("NewsNotFoundError");
        }

        public ActionResult GetLatestNews(int amount,int page)
        {
            var resultCollection = _newsService.GetNewestNewsesCollection().OrderBy(x => x.LastModifiedTimeStamp).Take(amount*page).Skip(amount*page-amount).ToList();
            var newsAmount = _newsService.GetNewestNewsesCollection().Count();
            if(resultCollection.Any())
                return new JsonNetResult(new { success = true, data = resultCollection, newsAmount = newsAmount }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNewsCount()
        {
            var newsAmount = _newsService.GetNewestNewsesCollection().Count();

            if (newsAmount > 0)
                return new JsonNetResult(new { success = true, data = newsAmount }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
