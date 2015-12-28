using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Filters;
using Logic.MailManagement.Interfaces;
using Logic.Settings.Interfaces;


namespace ClientPanel.Controllers
{
    [StatisticsFilter]
    public class MailController : Controller
    {
        private readonly IMailManagementService _mailManagementService;
        private readonly ISettingsService _settingsService;

        public MailController(IMailManagementService mailManagementService, ISettingsService settingsService)
        {
            _settingsService = settingsService;
            _mailManagementService = mailManagementService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendMail(string content, string subject)
        {
            var emailAddress = _settingsService.GetPropertyByName("EmailUsername");
            var response = _mailManagementService.SendMail(emailAddress, content, subject);

            if(emailAddress != null && !String.IsNullOrEmpty(content) && !String.IsNullOrEmpty(subject))
                return new JsonNetResult(new { success = response.IsSucceed}, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false}, JsonRequestBehavior.AllowGet);
        }

    }
}
