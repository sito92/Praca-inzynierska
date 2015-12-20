using Common.Responses;
using DAL.Interfaces;
using Logic.MailManagement.Interfaces;
using Modules.MailManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.MailManagement.Services
{
    public class MailManagementService : IMailManagementService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public MailManagementService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public ResponseBase SendMailToMany(List<string> emailAdressess,string content, string subject, string emailFrom)
        {
            var settingsDictionary = new Dictionary<string, string>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var settings = unitOfWork.SettingsRepository.Get(  x => x.Name == "EmailHost" 
                                                                || x.Name == "EmailUsername" 
                                                                || x.Name == "EmailPassword");
                if(settings != null)
                { 
                    foreach (var setting in settings)
                    {
                        settingsDictionary.Add(setting.Name, setting.Value);
                    }
                }
            }

            var response = MailManagerService.SendMailToGroup(settingsDictionary, emailAdressess, content, subject, emailFrom);

            return response;
        }

        public ResponseBase SendMailToOne(string emailAddress, string content, string subject, string emailFrom)
        {
            return new ResponseBase();
        }
    }
}
