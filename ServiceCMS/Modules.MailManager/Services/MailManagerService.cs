using Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Modules.Resources;

namespace Modules.MailManager.Services
{
    public static class MailManagerService
    {
        public static ResponseBase SendMail(Dictionary<string, string> settingsProperties, List<string> mailAddresses, string content, string subject)
        {
            ResponseBase response;
            var client = ConfigureSmtpClient(settingsProperties);
            var message = BuildMailMessage(mailAddresses, content,subject,settingsProperties["EmailUsername"]);

            try
            {
                client.Send(message);
                response = new ResponseBase() { IsSucceed = true,Message = Logic.MailSendSuccess };
            }
            catch (Exception e)
            {
                response = new ResponseBase() { IsSucceed = false, Message = Logic.ModifyUserFailed };
                throw new SmtpException();
            }

            return response;
        }

        public static ResponseBase SendMail(Dictionary<string, string> settingsProperties, string mailAddress, string content, string subject)
        {
            ResponseBase response;
            var client = ConfigureSmtpClient(settingsProperties);
            var message = BuildMailMessage(mailAddress, content, subject, settingsProperties["EmailUsername"]);

            try
            {
                client.Send(message);
                response = new ResponseBase() { IsSucceed = true, Message = Logic.MailSendSuccess };
            }
            catch (Exception e)
            {
                response = new ResponseBase() { IsSucceed = false, Message = Logic.ModifyUserFailed };
                throw new SmtpException();
            }

            return response;
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

        private static MailMessage BuildMailMessage(string mailAddresses, string content, string subject, string emailFrom)
        {

            var message = new MailMessage()
            {
                From = new MailAddress(emailFrom),
                Subject = subject,
                Body = content,
                IsBodyHtml = true,
            };

            message.To.Add(mailAddresses);

            return message;
        }
    }
}
