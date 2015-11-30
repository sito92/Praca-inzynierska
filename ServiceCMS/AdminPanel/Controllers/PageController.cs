﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Common.Models;
using Logic.Page.Interfaces;

namespace AdminPanel.Controllers
{
    public class PageController : BaseController
    {
        private IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        public ActionResult GetAll()
        {
            var pages = _pageService.GetAll();

            return Json(new {success= true,data = pages},JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var page = _pageService.GetById(id);
                return Json(new {success = true, data = page},JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {success = false});
            }
        }

        [HttpPost]
        public ActionResult Insert(PageModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _pageService.Insert(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult Update(PageModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _pageService.Update(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult Delete(PageModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _pageService.Delete(model.Id);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
