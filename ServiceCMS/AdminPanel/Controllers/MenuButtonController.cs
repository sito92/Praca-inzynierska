using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using Logic.Common.Models;
using Logic.MenuButton.Interfaces;
using Logic.News.Interfaces;

namespace AdminPanel.Controllers
{
    public class MenuButtonController : Controller
    {
        private IMenuButtonService _menuButtonService;
        public MenuButtonController(IMenuButtonService menuButtonService)
        {
            _menuButtonService = menuButtonService;
        }
        
        public ActionResult GetAllRootButtons()
        {
            var buttons = _menuButtonService.GetAllRootButtons();

            return new JsonNetResult(new{success = true,data=buttons});
        }

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }
        [HttpPost]
        public ActionResult Edit(MenuButtonModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _menuButtonService.Update(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(MenuButtonModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _menuButtonService.Insert(model);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var response = _menuButtonService.Delete(id);
                return Json(new { success = true, message = response }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
