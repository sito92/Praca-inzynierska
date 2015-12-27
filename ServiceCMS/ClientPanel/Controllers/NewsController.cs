using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.News.Interfaces;
using Logic.Statistics.Filters;

namespace ClientPanel.Controllers
{
    [StatisticsFilter]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ViewResult Index()
        {
            return View();
        }

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

            if(resultCollection.Any())
                return Json(new { success = true, data = resultCollection }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNewsCount()
        {
            var newsAmount = _newsService.GetNewestNewsesCollection().Count();

            if (newsAmount > 0)
                return Json(new { success = true, data = newsAmount }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
