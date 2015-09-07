using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        public ActionResult Test()
        {
            string content = "dsfsda sd sd asdf asd fdsf af [user;id=asfasdf]";
            var parsedContent = _insetParser.ParseContent(content);
            return Content(parsedContent);
        }

    }
}
