using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using AdminPanel.Models.PopUp;
using Logic.Common.Models;
using Logic.PopUp.Interfaces;

namespace AdminPanel.Controllers
{
    public class PopUpController : BaseController
    {
        private IPopUpService _popUpService;

        public PopUpController(IPopUpService popUpService)
        {
            _popUpService = popUpService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAll()
        {
            ListPopUpsViewModel model = new ListPopUpsViewModel();
           
            var popUps = _popUpService.GetAll();
            model.PopUps = popUps.ToList();
            return new JsonNetResult(new { success = true, data = model }, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var response = _popUpService.Delete(id);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public ActionResult UpdateAll(ListPopUpsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _popUpService.Update(model.PopUps);
                return Json(new { success = response.IsSucceed, data = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false });
            }
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }
    }
}
