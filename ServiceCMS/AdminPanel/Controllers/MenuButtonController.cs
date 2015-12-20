using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Common.Models;
using Logic.MenuButton.Interfaces;

namespace AdminPanel.Controllers
{
    public class MenuButtonController : BaseController
    {
        private readonly IMenuButtonService _menuButtonService;

        public MenuButtonController(IMenuButtonService menuButtonService)
        {
            _menuButtonService = menuButtonService;
        }

        public ActionResult GetById(int id)
        {
            var result = _menuButtonService.GetById(id);

            if(result != null)
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            var result = _menuButtonService.GetAll();

            if (result != null)
                return Json(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(MenuButtonModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _menuButtonService.Insert(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(MenuButtonModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _menuButtonService.Update(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var response = _menuButtonService.Delete(id);

                return Json(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
