using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using Logic.Common.Models;

namespace AdminPanel.ViewModels
{
    public class MailContentViewModel
    {
        public string Content { get; set; }

        public string Subject { get; set; }

        public List<NewsletterReceiverModel> Subscribers { get; set; }
    }
}