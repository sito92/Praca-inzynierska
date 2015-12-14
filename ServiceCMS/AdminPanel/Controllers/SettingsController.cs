﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Common.Models;
using Logic.Settings.Interfaces;

namespace AdminPanel.Controllers
{
    public class SettingsController : Controller
    {
        private ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ActionResult GetPropertyByName(string name)
        {
            var setting = _settingsService.GetPropertyByName(name);
            if (setting != null)
                return Json(new { success = true, data = setting }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _settingsService.Insert(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _settingsService.Update(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(SettingsModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _settingsService.Delete(model);
                return Json(new { success = true, data = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

    }
}