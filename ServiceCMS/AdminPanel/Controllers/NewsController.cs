﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using Logic.News.Interfaces;
using Logic.Statistics.Filters;
using Logic.Common.Models;
using Logic.NewsCategory.Interfaces;

namespace AdminPanel.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly INewsCategoryService _newsCategoryService;

        public NewsController(INewsService newsService,INewsCategoryService newsCategoryService)
        {
            _newsCategoryService = newsCategoryService;
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllCategories()
        {
            var categories = _newsService.GetAllCategories();

            return new JsonNetResult(new { success = true, data = categories }, JsonRequestBehavior.AllowGet);
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
                return new JsonNetResult(new { success = true, data = resultCollection }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
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

        public ActionResult GetCategoryById(int id)
        {
            var category = _newsService.GetById(id);

            if(category != null)
                return new JsonNetResult(new { success = true, data = category }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddCategory(NewsCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsCategoryService.Insert(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditCategory(NewsCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsCategoryService.Update(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            if (id > 0)
            {
                var response = _newsCategoryService.Delete(id);
                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
