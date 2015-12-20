using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace Logic.Service.Services
{
    public class ServicesService : IServicesService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public ServicesService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
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
