using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common.Responses;
using DAL.Interfaces;
using DAL.Models;
using Logic.Common.Models;
using Logic.ContactForm.Interfaces;

namespace Logic.ContactForm.Services
{
    public class ContactFormService : IContactFormService
    {
        //private readonly IMailSender _mailSender;
        //private ISettingsService _settings;
        //private SmtpClientDataRetrieval _smtpClient;

        //public ContactFormService(IMailSender mailSender, ISettingsService settingsService, SmtpClientDataRetrieval smtpClient)
        //{
        //    _mailSender = mailSender;
        //    _settings = settingsService;
        //    _smtpClient = smtpClient;
        //}

        //public ResponseBase Send(string authorEmailAddress, string topic, string content)
        //{
        //    //sprawdzenie, czy mail który podał klient jest mailem - do przeniesienia
        //    //if(!EmailAddressValidation.CheckIfEmailAddress(authorEmailAddress))
        //    //    return new ResponseBase() {IsSucceed = false, Message = Modules.Resources.Logic.ContactFormEmailSendFailed };

        //    var set = _settings.Get();

        //    return _mailSender.SendMail(topic,
        //        content,
        //        set.EmailAddress,
        //        authorEmailAddress,
        //        _smtpClient.ConfigureClient());
        //}

        
    }
}
