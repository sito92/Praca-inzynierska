using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.MailManagement.Interfaces;
using Logic.Service.Interfaces;
using Logic.Settings.Interfaces;

namespace Logic.Service.Services
{
    public class ServicesService : IServicesService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;
        private readonly ISettingsService _settingsService;
        private readonly IMailManagementService _mailManagementService;

        public ServicesService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger, ISettingsService settingsService, IMailManagementService mailManagementService)
        {
            _mailManagementService = mailManagementService;
            _settingsService = settingsService;
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public ResponseBase Insert(RegistratedServiceModel model)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (model != null)
                    {
                        unitOfWork.RegistratedServiceRepository.Insert(model.ToEntity());
                    }
                    unitOfWork.Save();
                    ComposeClientEmail(model);
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ServiceTypeSaveSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ServiceTypeSaveFailed };
                }
                return response;
            }
        }

        private void ComposeClientEmail(RegistratedServiceModel model)
        {
            var listOfAddresses = new List<string>()
            {
                model.ClientEmail,
                _settingsService.GetPropertyByName("EmailUsername")
            };

            _mailManagementService.SendMail(listOfAddresses,
                ClientConfirmationEmail.CONTENT + model.ServiceType.Name + ClientConfirmationEmail.CONTENT_2 + model.StartDate + ClientConfirmationEmail.CONTENT_3 + ClientConfirmationEmail.FOOTER,
                ClientConfirmationEmail.SUBJECT);
        }

        public List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date)
        {
            List<RegistratedServiceModel> serviceModels = new List<RegistratedServiceModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.RegistratedServiceRepository.Get(x=>x.StartDate.Day == date.Date.Day 
                                                                               && x.StartDate.Month == date.Date.Month 
                                                                               && x.StartDate.Year == date.Date.Year);
                    foreach (var entity in entities)
                    {
                        serviceModels.Add(new RegistratedServiceModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceModels;
        }

        public List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(ServiceProviderModel serviceProvider)
        {
            List<RegistratedServiceModel> serviceModels = new List<RegistratedServiceModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities =
                        unitOfWork.RegistratedServiceRepository.Get(x => x.ServiceProviderId == serviceProvider.Id);

                    foreach (var entity in entities)
                    {
                        serviceModels.Add(new RegistratedServiceModel(entity));
                    }
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceModels;
        }

        public List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date, ServiceProviderModel serviceProvider)
        {
            List<RegistratedServiceModel> serviceModels = new List<RegistratedServiceModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.RegistratedServiceRepository.Get(x => x.StartDate.Day == date.Date.Day
                                                                               && x.StartDate.Month == date.Date.Month
                                                                               && x.StartDate.Year == date.Date.Year
                                                                               && x.ServiceProviderId == serviceProvider.Id);
                    foreach (var entity in entities)
                    {
                        serviceModels.Add(new RegistratedServiceModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceModels;
        }

        public List<RegistratedServiceModel> GetAll()
        {
            List<RegistratedServiceModel> serviceModels = new List<RegistratedServiceModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.RegistratedServiceRepository.Get();
                    foreach (var entity in entities)
                    {
                        serviceModels.Add(new RegistratedServiceModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceModels;
        }
    }
}
