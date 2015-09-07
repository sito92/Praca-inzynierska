using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using DAL.Models;
using Logic.ContactForm.Interfaces;
using Modules.MailSender;

namespace Logic.ContactForm.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly MailSender _mailSender;
        private IUnitOfWork _unitOfWork;
        private Settings _settings;

        public ContactFormService(MailSender mailSender, IUnitOfWork unitOfWork)
        {
            _mailSender = mailSender;
            _unitOfWork = unitOfWork;
            _settings = unitOfWork.SettingsRepository.Get().FirstOrDefault();
        }

        public ResponseBase Send(string authorEmailAddress, string topic, string content)
        {
            //sprawdzenie, czy mail który podał klient jest mailem - do przeniesienia
            //if(!EmailAddressValidation.CheckIfEmailAddress(authorEmailAddress))
            //    return new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.ContactFormEmailSendFailed };

            return _mailSender.SendMail(topic,
                content,
                _settings.EmailAddress,
                authorEmailAddress,
                ConfigureClient(authorEmailAddress));
        }

        private SmtpClient ConfigureClient(string authorEmailAddress)
        {
            var selectedEmailSettings = _settings.SmtpClientDictionary.
                FirstOrDefault(x => x.Key.Contains( authorEmailAddress.Substring(authorEmailAddress.LastIndexOf('@')+1)));

            var client = new SmtpClient()
            {
                Host =  selectedEmailSettings.Key,
                Port = selectedEmailSettings.Value,
            };

            return client;
        }
    }
}
