using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Controllers
{
    public class PickerController : Controller
    {
        //
        // GET: /Picker/

        public ActionResult GetModal(string name)
        {
            return PartialView(name);
        }

    }
}
