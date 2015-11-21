using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logic.Inset.Interfaces;
using Logic.Statistics.Interfaces;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {

        private IStatisticsService _service;
        public TestController(IStatisticsService service)
        {
            _service = service;
        }
        //
        // GET: /Test/

        public ActionResult Test()
        {
            var a = _service.GetAllUsers();
            var b = _service.GetUniqueUsers();
            var c = _service.GetUsersForSelectedMonth(10);
            var d = _service.GetUsersTotalAmount();
            return View();
        }

    }
}
