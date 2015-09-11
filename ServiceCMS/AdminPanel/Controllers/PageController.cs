using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Page.Interfaces;

namespace AdminPanel.Controllers
{
    public class PageController : BaseController
    {
        private IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        public ActionResult GetAll()
        {
            var pages = _pageService.GetAll();

            return Json(new {success= true,data = pages},JsonRequestBehavior.AllowGet);
        }

    }
}
