using System;
using System.Collections.Generic;
using System.Linq;
using Common.Responses;
using DAL.Interfaces;
using DAL.Models;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Newsletter.Interfaces;
using Logic.Settings.Interfaces;
using Logic.Settings.Services;
using Modules.MailSender;

namespace Logic.Newsletter.Services
{
    public class NewsletterReceiverService : INewsletterReceiverService
    {
        private readonly IMailSender _mailSender;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;
        private ISettingsService _settings;
        private SmtpClientDataRetrieval _smtpClient;

        public NewsletterReceiverService(IMailSender mailSender, 
            IUnitOfWorkFactory unitOfWorkFactory, 
            ILogger logger, 
            ISettingsService settingsService,
            SmtpClientDataRetrieval smtpClient)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this._mailSender = mailSender;
            this._logger = logger;
            this._settings = settingsService;
            this._smtpClient = smtpClient;
        }

        public ResponseBase Insert(NewsletterReceiverModel newsletterReceiver)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (newsletterReceiver != null)
                    {
                        unitOfWork.NewsletterReceiverRepository.Insert(newsletterReceiver.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsletterReceiverInsertSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsletterReceiverInsertFailed };
                }
                return response;
            }
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.NewsletterReceiverRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.NewsletterReceiverDeleteSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.NewsletterReceiverDeleteFailed };
                }
            }
            return response;
        }

        public ResponseBase Send(string topic, string content)
        {
            var set = _settings.Get();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                
            
            return _mailSender.SendMail(topic,
                content,
                set.EmailAddress,
                unitOfWork.NewsletterReceiverRepository.Get().Select(x => x.EmailAddress).ToList(), 
                _smtpClient.ConfigureClient()
                );
            }
        }
    }
}
