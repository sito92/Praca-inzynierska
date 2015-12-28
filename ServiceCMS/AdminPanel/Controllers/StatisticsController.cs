using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using AdminPanel.ViewModels;
using Logic.Statistics.Interfaces;

namespace AdminPanel.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private StatisticsViewModel viewModel;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPage(string name)
        {
            return PartialView("Pages/"+name);
        }
        public ActionResult GetUsersPerCountry()
        {
            var resultCollection = _statisticsService.GetUsersPerCountry();
            viewModel = new StatisticsViewModel()
            {
                Keys = resultCollection.Select(x => x.Key).ToList(),
                Visitors = resultCollection.Select(x => x.Value).ToList()
            };

            if(viewModel.Keys.Any() && viewModel.Visitors.Any())
                return new JsonNetResult(new {success = true,data = viewModel},JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersForSelectedMonth(int month, int year)
        {
            var resultCollection = _statisticsService.GetUsersForSelectedMonth(month, year);
            viewModel = new StatisticsViewModel()
            {
                Keys = resultCollection.Select(x => x.Key).ToList(),
                Visitors = resultCollection.Select(x => x.Value).ToList()
            };

            if (viewModel.Keys.Any() && viewModel.Visitors.Any())
                return new JsonNetResult(new { success = true, data = viewModel }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersForEveryMonth(int year)
        {
            var resultCollection = _statisticsService.GetUsersForEveryMonth(year);
            viewModel = new StatisticsViewModel()
            {
                Keys = resultCollection.Select(x => x.Key).ToList(),
                Visitors = resultCollection.Select(x => x.Value).ToList()
            };

            if (viewModel.Keys.Any() && viewModel.Visitors.Any())
                return new JsonNetResult(new { success = true, data = viewModel }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUsersBetweenDates(DateTime? from, DateTime? to, int? step)
        {
            var resultCollection = _statisticsService.GetUsersBetweenDates(from, to);
            
            //if (step != null)
            //    _statisticsService.RecalculateCollectionAccordingToStep(resultCollection, step);

            viewModel = new StatisticsViewModel()
            {
                Keys = resultCollection.Select(x => x.Key).ToList(),
                Visitors = resultCollection.Select(x => x.Value).ToList()
            };

            if (viewModel.Keys.Any() && viewModel.Visitors.Any())
                return new JsonNetResult(new { success = true, data = viewModel }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserActionsBetweenDates(DateTime? from, DateTime? to)
        {
            var resultCollection = _statisticsService.GetActionsBetweenDates(from, to);

            viewModel = new StatisticsViewModel()
            {
                Keys = resultCollection.Select(x => x.Key).ToList(),
                Visitors = resultCollection.Select(x => x.Value).ToList()
            };

            if (viewModel.Keys.Any() && viewModel.Visitors.Any())
                return new JsonNetResult(new { success = true, data = viewModel }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}
