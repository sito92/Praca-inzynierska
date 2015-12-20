using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Common.Models;
using Logic.PopUp.Interfaces;

namespace AdminPanel.Controllers
{
    public class PopUpController : Controller
    {
        private IPopUpService _popUpService;

        public PopUpController(IPopUpService popUpService)
        {
            _popUpService = popUpService;
        }

        [HttpPost]
        public ActionResult Add(PopUpModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _popUpService.Insert(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new {success = false});
            }
        }

        [HttpPost]
        public ActionResult Update(PopUpModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _popUpService.Update(model);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
