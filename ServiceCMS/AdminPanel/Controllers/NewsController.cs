using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using Logic.News.Interfaces;
using Logic.Statistics.Filters;
using Logic.Common.Models;

namespace AdminPanel.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        //[StatisticsFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCategories()
        {
            var categories = _newsService.GetAllCategories();

            return new JsonNetResult(new { success = true, categories = categories }, JsonRequestBehavior.AllowGet);
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

        public ActionResult GetNewestNewsesCollection()
        {
            var resultCollection = _newsService.GetNewestNewsesCollection();

            if(resultCollection.Any())
                return Json(new { success = true, data = resultCollection }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult Add(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsService.Insert(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Edit(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsService.Update(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var response = _newsService.Delete(id);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll()
        {
            var newses = _newsService.GetAll();
            return new JsonNetResult(new { success = true, data = newses }, JsonRequestBehavior.AllowGet);
        }

    }
}
