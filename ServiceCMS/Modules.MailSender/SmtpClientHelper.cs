using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Modules.MailSender
{
    public static class SmtpClientHelper
    {
        public static SmtpClient ConfigureSmtpClient(SmtpClient internalSmtpClient)
        {
            var client = new SmtpClient()
            {
                Host = internalSmtpClient.Host, 
                Port = internalSmtpClient.Port,
                EnableSsl = true,
                Timeout = 10000,           
            };

            if (internalSmtpClient.Credentials != null)
                client.Credentials = internalSmtpClient.Credentials;

            return client;
        }
    }
}
