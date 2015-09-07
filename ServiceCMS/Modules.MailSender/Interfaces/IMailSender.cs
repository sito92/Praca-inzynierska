using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

namespace Modules.MailSender
{
    public interface IMailSender
    {
        ResponseBase SendMail(string topic, 
            string content, 
            string internalMail, 
            string authorEmailAddress,
            SmtpClient client);

        ResponseBase SendMail(string topic, 
            string content, 
            string internalMail, 
            List<string> receivers,
            SmtpClient client);
    }
}
