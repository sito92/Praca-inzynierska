using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;

namespace Modules.MailSender
{
    public class MailSender : IMailSender
    {
        private MailMessage _message;
        private SmtpClient _client;
        private ILogger _logger;
        private IMailMessageBuilder _builder;

        public MailSender(ILogger logger, IMailMessageBuilder builder)
        {
            _logger = logger;
            _builder = builder;
        }

        public ResponseBase SendMail(string topic, string content, string internalMail, string authorEmailAddress, SmtpClient client )
        {
            _message = _builder.Build(topic, content, internalMail,authorEmailAddress);
            _client = SmtpClientHelper.ConfigureSmtpClient(client);

            try
            {
                _client.Send(_message);
                return new ResponseBase() { IsSucceed = true, Message = Resources.Logic.ContactFormEmailSendSuccess };
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return new ResponseBase() { IsSucceed = false, Message = Resources.Logic.ContactFormEmailSendFailed };
            }
        }

        public ResponseBase SendMail(string topic, string content,string internalMail, List<string> receivers, SmtpClient client)
        {
            _message = _builder.Build(topic, content,internalMail,receivers);
            _client = SmtpClientHelper.ConfigureSmtpClient(client);

            try
            {
                _client.Send(_message);
                return new ResponseBase() { IsSucceed = true, Message = Resources.Logic.SendNewsletterEmailSuccess };
            }
            catch (Exception e)
            {
                _logger.LogToFile(_logger.CreateErrorMessage(e));
                return new ResponseBase() { IsSucceed = false, Message = Resources.Logic.SendNewsletterEmailFailed };
            }
        }
    }
}
