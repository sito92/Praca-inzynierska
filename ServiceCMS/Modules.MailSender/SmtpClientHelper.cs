using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Modules.MailSender
{
    public static class SmtpClientHelper
    {
        public static SmtpClient ConfigureSmtpClient()
        {
            var client = new SmtpClient()
            {
                Host = "smtp.gmail.com", //to będzie konfigurowalne
                Port = 587, // to też 
                EnableSsl = true,
                Timeout = 10000,
                //Credentials = 
            };
            return client;
        }
    }
}
