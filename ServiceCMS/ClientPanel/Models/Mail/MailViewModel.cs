using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modules.Resources;

namespace ClientPanel.Models.Mail
{
    public class MailViewModel
    {
        [Required]
        public string Content { get; set; }

        [EmailAddress(ErrorMessage = "TO NIE")]
        public string ClientEmailAddres { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
