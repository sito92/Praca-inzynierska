using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Filters;
using Logic.Inset.Interfaces;

namespace AdminPanel.Controllers
{
    public class TestController : BaseController
    {
        private IInsetParser _insetParser;

        public TestController(IInsetParser insetParser)
        {
            _insetParser = insetParser;
        }
        //
        // GET: /Test/
        [TestFilter]
        public ActionResult Test()
        {
            string content = @"[externalLink;url=""asfa=sdf""]";
            var parsedContent = _insetParser.ParseContent(content);
            return Content(parsedContent);
        }

    }
}
