using Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MailManagement.Interfaces
{
    public interface IMailManagementService
    {
        ResponseBase SendMail(List<string> emailAdressess, string content, string subject);

        ResponseBase SendMail(string emailAddress, string content, string subject);
    }
}
