using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Service.Helpers;
using Logic.Service.Interfaces;

namespace Logic.Service.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;
        private IServiceTypeService _typeService;

        public ServiceProviderService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger, IServiceTypeService typeService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
            _typeService = typeService;
        }


        public ServiceProviderModel GetById(int id)
        {
            ServiceProviderModel serviceProviderModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.ServiceProviderRepository.GetByID(id);
                    if (entity != null)
                    {
                        serviceProviderModel = new ServiceProviderModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceProviderModel;
        }

        public IList<ServiceProviderModel> GetAll()
        {
            IList<ServiceProviderModel> serviceProviderModels = new List<ServiceProviderModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.ServiceProviderRepository.Get();
                    foreach (var entity in entities)
                    {
                        serviceProviderModels.Add(new ServiceProviderModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceProviderModels;
        }

        public ResponseBase Insert(ServiceProviderModel serviceProvider)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (serviceProvider != null)
                    {
                        unitOfWork.ServiceProviderRepository.Insert(serviceProvider.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase()
                    {
                        IsSucceed = true,
                        Message = Modules.Resources.Logic.ServiceProviderSaveSuccess
                    };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase()
                    {
                        IsSucceed = false,
                        Message = Modules.Resources.Logic.ServiceProviderSaveFailed
                    };
                }
                return response;
            }
        }

        public ResponseBase Update(ServiceProviderModel serviceProvider)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (serviceProvider != null)
                    {
                        unitOfWork.ServiceProviderRepository.Update(serviceProvider.ToEntity());
                    }
                    unitOfWork.Save();
                    response = new ResponseBase()
                    {
                        IsSucceed = true,
                        Message = Modules.Resources.Logic.ServiceProviderModifySuccess
                    };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase()
                    {
                        IsSucceed = false,
                        Message = Modules.Resources.Logic.ServiceProviderModifyFailed
                    };
                }
            }
            return response;
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.ServiceProviderRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase()
                    {
                        IsSucceed = true,
                        Message = Modules.Resources.Logic.ServiceProviderRemoveSuccess
                    };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase()
                    {
                        IsSucceed = false,
                        Message = Modules.Resources.Logic.ServiceProviderRemoveFailed
                    };
                }
            }
            return response;
        }

        public IList<ServiceProviderModel> GetAllWithAvailableServices(ServiceTypeModel serviceType)
        {
            IList<ServiceProviderModel> serviceProviderModels = new List<ServiceProviderModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var serviceProviders = unitOfWork.ServiceProviderRepository.Get();

                    foreach (var serviceProvider in serviceProviders)
                    {
                        foreach (var availableService  in serviceProvider.AvailableServices)
                        {
                            if(availableService.Name == serviceType.Name)
                                serviceProviderModels.Add(new ServiceProviderModel(serviceProvider));
                        }
                    }
                    //var result =
                    //    unitOfWork.ServiceProviderRepository.Get()
                    //        .Where(ServiceProviderHelper.CheckAvailability(serviceType.ToEntity()));

                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceProviderModels;
        }
    }
}
