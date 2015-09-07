using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;

namespace Modules.MailSender
{
    public interface IMailMessageBuilder
    {
        MailMessage Build(string topic, string content, string internalMail, string authorEmailAddress);
        MailMessage Build(string topic, string content, string internalMail, List<string> receiversList);
    }
}
