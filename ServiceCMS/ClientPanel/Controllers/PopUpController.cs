using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using Logic.PopUp.Interfaces;

namespace ClientPanel.Controllers
{
    public class PopUpController : Controller
    {
        private readonly IPopUpService _popUpService;

        public PopUpController(IPopUpService popUpService)
        {
            _popUpService = popUpService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetActivePopUp()
        {
            var result = _popUpService.GetActivePopUp();

            if (result != null)
                return new JsonNetResult(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
