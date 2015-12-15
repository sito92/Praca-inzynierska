using Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Modules.MailManager.Services
{
    public static class MailManagerService
    {
        public static ResponseBase SendMailToGroup(Dictionary<string, string> settingsProperties, List<string> mailAddresses, string content, string subject, string emailFrom)
        {
            var client = ConfigureSmtpClient(settingsProperties);
            var message = BuildMailMessage(mailAddresses, content,subject,emailFrom);
            
            if(mailAddresses.Count > 0)
            {
		        client.Send(message);
            }

            return new ResponseBase() { IsSucceed = true};
        }

        public static ResponseBase SendMailToOne(Dictionary<string, string> settingsProperties, string mailAddress, string content, string subject, string emailFrom)
        {
            return new ResponseBase();
        }

        private static SmtpClient ConfigureSmtpClient(Dictionary<string, string> settingsProperties)
        {
            var client = new SmtpClient()
            {
                EnableSsl = true,
                Port = 587,
                Host = settingsProperties["EmailHost"],
                Credentials = new System.Net.NetworkCredential(settingsProperties["EmailUsername"],settingsProperties["EmailPassword"]),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            return client;
        }

        private static MailMessage BuildMailMessage(List<string> mailAddresses, string content, string subject, string emailFrom)
        {

            var message = new MailMessage()
            {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };

            foreach (var address in mailAddresses)
            {
                message.To.Add(address);   
            }

            return message;
        }
    }
}
