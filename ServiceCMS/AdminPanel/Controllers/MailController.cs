using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel.Extensions;
using AdminPanel.ViewModels;
using Logic.Common.Models;
using Logic.MailManagement.Interfaces;
using Logic.NewsletterReceiver.Interfaces;

namespace AdminPanel.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailManagementService _mailManagementService;
        private readonly INewsletterReceiverService _newsletterReceiverService;

        public MailController(IMailManagementService mailManagementService,
            INewsletterReceiverService newsletterReceiverService)
        {
            _newsletterReceiverService = newsletterReceiverService;
            _mailManagementService = mailManagementService;
        }
        public PartialViewResult GetModal(string name)
        {
            return PartialView("Modals/" + name);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewsletterReceiver(NewsletterReceiverModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsletterReceiverService.Insert(model);
                return new JsonNetResult(new {success = response.IsSucceed, message = response.Message},JsonRequestBehavior.AllowGet);
            }
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateNewsletterReceiver(NewsletterReceiverModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsletterReceiverService.Update(model);
                return new JsonNetResult(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteNewsletterReceiver(NewsletterReceiverModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _newsletterReceiverService.Delete(model.Id);
                return new JsonNetResult(new { success = response.IsSucceed, message = response.Message }, JsonRequestBehavior.AllowGet);
            }
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllNewsletterReceivers()
        {
            var result = _newsletterReceiverService.GetAll();
                return new JsonNetResult(new { success = true, data = result }, JsonRequestBehavior.AllowGet); 

        }

        public ActionResult GetByIdNewsletterReceiver(NewsletterReceiverModel model)
        {
            NewsletterReceiverModel result = null;
            if(ModelState.IsValid)
                result = _newsletterReceiverService.GetById(model.Id);
            
            if(result != null)
                return new JsonNetResult(new { success = true, data = result }, JsonRequestBehavior.AllowGet);
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet); 
        }
        [HttpPost]
        public ActionResult SendMail(MailContentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subscribers = model.Subscribers.Select(x => x.EmailAddress).ToList();
                var response = _mailManagementService.SendMail(subscribers, model.Content, model.Subject);
                return new JsonNetResult(new { success = true}, JsonRequestBehavior.AllowGet);
            }
            else
                return new JsonNetResult(new { success = false }, JsonRequestBehavior.AllowGet); 
        }
    }
}
