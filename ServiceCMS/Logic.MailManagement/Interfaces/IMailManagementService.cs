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
        ResponseBase SendMailToMany(List<string> emailAdressess, string content, string subject, string emailFrom);

        ResponseBase SendMailToOne(string emailAddress, string content, string subject, string emailFrom);
    }
}
