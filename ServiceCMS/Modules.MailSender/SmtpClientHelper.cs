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
            SmtpClient client;
            try
            {
                client = new SmtpClient()
                {
                    Host = internalSmtpClient.Host,
                    Port = internalSmtpClient.Port,
                    EnableSsl = true,
                    Timeout = 10000,
                    Credentials = internalSmtpClient.Credentials
                };
                return client;
            }
            catch (Exception) 
            {
                throw new ApplicationException(); // <-- co tutaj?
            }
        }
    }
}
