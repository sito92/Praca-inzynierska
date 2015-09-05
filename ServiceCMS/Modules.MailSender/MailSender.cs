using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

namespace Modules.MailSender
{
    public class MailSender:IMailSender
    {
        public ResponseBase ContactFormMail(string authorEmailAddress, string topic, string content)
        {
            throw new NotImplementedException();
        }

        public ResponseBase NewsletterMail(string topic, string content)
        {
            throw new NotImplementedException();
        }
    }
}
