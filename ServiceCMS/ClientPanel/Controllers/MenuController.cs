using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Models.Menu;
using Logic.MenuButton.Interfaces;
using Logic.Settings.Interfaces;

namespace ClientPanel.Controllers
{
    public class MenuController : Controller
    {
        private IMenuButtonService _menuButtonService;
        private ISettingsService _settingsService;

        public MenuController(IMenuButtonService menuButtonService,ISettingsService settingsService)
        {
            _menuButtonService = menuButtonService;
            _settingsService = settingsService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMenuData()
        {
            var buttons = _menuButtonService.GetAllRootButtons();
            var companyName = _settingsService.GetPropertyByName("CompanyName");
            var setttings = _settingsService.GetAll();
            MenuDataViewModel model = new MenuDataViewModel() { Buttons = buttons.ToList(), CompanyName = companyName, Settings = setttings };

            return new JsonNetResult(new {success = true,data= model});
        }
    }
}
