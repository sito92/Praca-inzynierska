using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.ContactForm.Interfaces;
using Modules.MailSender;

namespace Logic.ContactForm.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly MailSender _mailSender;

        public ContactFormService(MailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public ResponseBase Send(string authorEmailAddress, string topic, string content)
        {
            if(!EmailAddressValidation.CheckIfEmailAddress(authorEmailAddress))
                return new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.ContactFormEmailSendFailed };

            return _mailSender.ContactFormMail(authorEmailAddress, topic, content);
        }
    }
}
