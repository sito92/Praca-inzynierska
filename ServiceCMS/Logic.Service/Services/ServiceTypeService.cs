using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using DAL.Models;
using Logging.Interfaces;
using Logic.Common.Models;
using Logic.Service.Interfaces;

namespace Logic.Service.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        private ILogger _logger;

        public ServiceTypeService(IUnitOfWorkFactory unitOfWorkFactory, ILogger logger)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _logger = logger;
        }
        public ServiceTypeModel GetById(int id)
        {
            ServiceTypeModel serviceTypeModel = null;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entity = unitOfWork.ServiceTypeRepository.GetByID(id);
                    if (entity != null)
                    {
                        serviceTypeModel = new ServiceTypeModel(entity);
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceTypeModel;
        }

        public IList<ServiceTypeModel> GetAll()
        {
            IList<ServiceTypeModel> serviceTypeModels = new List<ServiceTypeModel>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var entities = unitOfWork.ServiceTypeRepository.Get();
                    foreach (var entity in entities)
                    {
                        serviceTypeModels.Add(new ServiceTypeModel(entity));
                    }
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return serviceTypeModels;
        }

        public ResponseBase Insert(ServiceTypeModel serviceType)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (serviceType != null)
                    {
                        unitOfWork.ServiceTypeRepository.Insert(serviceType.ToEntity());
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

        public ResponseBase Update(ServiceTypeModel serviceType)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    if (serviceType != null)
                    {
                        unitOfWork.ServiceTypeRepository.Update(serviceType.ToEntity());
                        UpdateServicePhases(serviceType.Phases,unitOfWork);
                    }
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ServiceTypeModifySuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ServiceTypeModifyFailed };
                }
            }
            return response;
        }

        private void UpdateServicePhases(ICollection<ServicePhaseModel> collection,IUnitOfWork unitOfWork)
        {
            foreach (var phase in collection)
            {               
                  unitOfWork.ServicePhaseRepository.Update(phase.ToEntity());                 
            }
        }

        public ResponseBase Delete(long id)
        {
            ResponseBase response;
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    unitOfWork.ServiceTypeRepository.Delete(id);
                    unitOfWork.Save();
                    response = new ResponseBase() { IsSucceed = true, Message = Modules.Resources.Logic.ServiceTypeRemoveSuccess };
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                    response = new ResponseBase() { IsSucceed = false, Message = Modules.Resources.Logic.ServiceTypeRemoveFailed };
                }
            }
            return response;
        }
    }
}
