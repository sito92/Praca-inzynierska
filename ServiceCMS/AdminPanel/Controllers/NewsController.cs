using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.News.Interfaces;
using Logic.Statistics.Filters;
using Logic.Common.Models;

namespace AdminPanel.Controllers
{
    public class NewsController : BaseController
    {
        private INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        //[StatisticsFilter]
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }

        public ActionResult GetRestoreNewsesCollection(NewsModel news, bool rootPageExcluded)
        {
            if (ModelState.IsValid)
            {
                var result = _newsService.GetRestoreNewsesCollection(news, rootPageExcluded);
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
