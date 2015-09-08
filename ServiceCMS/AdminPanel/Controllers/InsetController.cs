using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class InsetController : Controller
    {
        //
        // GET: /Inset/

        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);

        }
    }
}
