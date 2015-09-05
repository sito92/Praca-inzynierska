using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using DAL.Models;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Newsletter.Interfaces;
using Modules.MailSender;

namespace Logic.Newsletter.Services
{
    public class NewsletterReceiverService : INewsletterReceiverService
    {
        private readonly MailSender _mailSender;
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public NewsletterReceiverService(MailSender mailSender, IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this._mailSender = mailSender;
            this._logger = logger;
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
            return _mailSender.NewsletterMail(topic, content); 
            //wydaje mi się, że sama treść newsletter potrzebuje
            //wypełnienia treści i tematu gdzie indziej. prawda?
        }
    }
}
