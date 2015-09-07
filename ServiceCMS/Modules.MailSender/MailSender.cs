using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;

namespace Modules.MailSender
{
    public class MailSender:IMailSender
    {
        private MailMessage _message;
        private SmtpClient _client;
        private ILogger _logger;

        public MailSender(ILogger logger)
        {
            _logger = logger;
        }

        public ResponseBase ContactFormMail(string authorEmailAddress, string topic, string content)
        {
            //_message = 
            _client = SmtpClientHelper.ConfigureSmtpClient();

            try
            {
                _client.Send(_message);
                return new ResponseBase() {IsSucceed = true, Message = Resources.Logic.ContactFormEmailSendSuccess};
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return new ResponseBase() { IsSucceed = false, Message = Resources.Logic.ContactFormEmailSendFailed};
            }
        }

        public ResponseBase NewsletterMail(string topic, string content)
        {
            //_message = 
            _client = SmtpClientHelper.ConfigureSmtpClient();

            try
            {
                _client.Send(_message);
                return new ResponseBase() { IsSucceed = true, Message = Resources.Logic };
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return new ResponseBase() { IsSucceed = false, Message = Resources.Logic };
            }
        }
    }
}
