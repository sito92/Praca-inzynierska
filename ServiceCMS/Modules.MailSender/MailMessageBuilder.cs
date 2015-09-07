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
    public class MailMessageBuilder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public MailMessageBuilder(IUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public MailMessage BuildContactFormMail(string authorEmailAddress, string topic, string content)
        {
            MailMessage message = null;
            try
            {
                message = new MailMessage()
                {
                    From = new MailAddress(authorEmailAddress),
                    Subject = topic,
                    Body = content,
                    IsBodyHtml = true,
                    Priority = MailPriority.High,
                };

                var settings = _unitOfWork.SettingsRepository.Get().FirstOrDefault();
                if (settings != null)
                    message.To.Add(settings.EmailAddress);
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
            }
            return message;
        }

        public MailMessage BuildNewsletterMail(string topic, string content)
        {
            MailMessage message = null;
            try
            {
                message = new MailMessage()
                {
                    From = new MailAddress(_unitOfWork.SettingsRepository.Get().FirstOrDefault().EmailAddress),
                    Subject = topic,
                    Body = content,
                    IsBodyHtml = true,
                    Priority = MailPriority.High,
                };

                var settings = _unitOfWork.NewsletterReceiverRepository.Get();
                if (settings != null)
                {
                    foreach (var entity in settings)
                    {
                        message.To.Add(new MailAddress(entity.EmailAddress));
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
            }
            return message;
        }
    }
}
