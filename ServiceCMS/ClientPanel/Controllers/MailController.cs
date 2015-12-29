﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClientPanel.Extensions;
using ClientPanel.Filters;
using ClientPanel.Helpers;
using ClientPanel.Models.Mail;
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

        public ActionResult ContactForm()
        {
            var contactFormActive = _settingsService.GetPropertyByName("ContactFormEnabled");

            if (contactFormActive == "true")
                return View();
            else
                return View("PageNotFound");
        }

        public ActionResult SendMail(MailViewModel model)
        {
            var contactFormActive = _settingsService.GetPropertyByName("ContactFormEnabled");
            if (contactFormActive == "true")
            {
                var emailAddress = _settingsService.GetPropertyByName("EmailUsername");
                model.Content += ClientAddressEmailHelper.RefactorClientAddress(model.ClientEmailAddres);

                _mailManagementService.SendMail(emailAddress, model.Content, model.Subject);

            }
            else
            {
                return View("SiteNotFound");
            }
            return View();
        }

    }
}
