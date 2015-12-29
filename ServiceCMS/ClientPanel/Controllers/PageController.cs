using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Filters;
using Logic.Inset.Interfaces;
using Logic.Page.Interfaces;


namespace ClientPanel.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IInsetParser _insetParser;
        public PageController(IPageService pageService,IInsetParser insetParser)
        {
            _pageService = pageService;
            _insetParser = insetParser;
        }

        [StatisticsFilter]
        public ViewResult Show(int id)
        {
            var result = _pageService.GetById(id);
            result.Content=_insetParser.ParseContent(result.Content);
            if (result != null)
                return View(result);
            else
                return View("PageNotFoundError");
        }

    }
}
