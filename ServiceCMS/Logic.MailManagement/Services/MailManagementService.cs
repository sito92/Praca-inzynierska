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

        public ResponseBase SendMail(List<string> emailAdressess,string content, string subject)
        {
            var settingsDictionary = new Dictionary<string, string>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var settings = unitOfWork.SettingsRepository.Get(  x => x.Name == "EmailHost" 
                                                                || x.Name == "EmailUsername" 
                                                                || x.Name == "EmailPassword"
                                                                || x.Name == "EmailAddress");
                if(settings != null)
                { 
                    foreach (var setting in settings)
                    {
                        settingsDictionary.Add(setting.Name, setting.Value);
                    }
                }
            }

            var response = MailManagerService.SendMail(settingsDictionary, emailAdressess, content, subject);

            return response;
        }

        public ResponseBase SendMail(string emailAddress, string content, string subject)
        {
            var settingsDictionary = new Dictionary<string, string>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var settings = unitOfWork.SettingsRepository.Get(x => x.Name == "EmailHost"
                                                                || x.Name == "EmailUsername"
                                                                || x.Name == "EmailPassword"
                                                                || x.Name == "EmailAddress");
                if (settings != null)
                {
                    foreach (var setting in settings)
                    {
                        settingsDictionary.Add(setting.Name, setting.Value);
                    }
                }
            }

            var response = MailManagerService.SendMail(settingsDictionary, emailAddress, content, subject);

            return response;
        }
    }
}
