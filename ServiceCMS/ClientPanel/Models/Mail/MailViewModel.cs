using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientPanel.Models.Mail
{
    public class MailViewModel
    {
        public string Content { get; set; }

        public string ClientEmailAddres { get; set; }

        public string Subject { get; set; }
    }
}
