using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using Logic.Settings.Interfaces;

namespace ClientPanel.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ISettingsService _settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSettingsByName(string name)
        {
            var result = _settingsService.GetPropertyByName(name);

            if (result != null)
                return new JsonNetResult(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
