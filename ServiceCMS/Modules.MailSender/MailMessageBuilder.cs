using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Logging.Interfaces;

namespace Modules.MailSender
{
    public class MailMessageBuilder : IMailMessageBuilder
    {
        public MailMessage Build(string topic, string content, string internalMail, string authorEmailAddress)
        {
            MailMessage message = BuildBaseMail(topic,content);
            message.From = new MailAddress(authorEmailAddress);
            message.To.Add(internalMail);

            return message;
        }

        public MailMessage Build(string topic, string content, string internalMail, List<string> receiversList )
        {
            MailMessage message = BuildBaseMail(topic, content);
            
            message.From = new MailAddress(internalMail);
            foreach (var receiver in receiversList)
            {
                message.To.Add(receiver);
            }

            return message;
        }

        private MailMessage BuildBaseMail(string topic, string content)
        {
            var baseMessage = new MailMessage()
            {
                Subject = topic,
                Body = content,
                IsBodyHtml = true,
                Priority = MailPriority.High,
            };

            return baseMessage;
        }
    }
}
