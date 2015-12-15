using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using DAL.Interfaces;
using DAL.Migrations;
using DAL.Models;
using Logic.Service.Helpers;
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
                        UpdateServicePhases(serviceType.Phases.Where(x => x.ServiceTypeId != 0).ToList(), unitOfWork);
                        AddServicePhases(serviceType.Phases.Where(x=>x.ServiceTypeId==0).ToList(),unitOfWork,serviceType.Id);
                        DeleteServicePhases(serviceType,unitOfWork);
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

        public Dictionary<ServiceTypeModel,bool> GetServiceTypesMatchingTimeCriteria(DateTime time, ServiceProviderModel provider)
        {
            var resultCollection = new Dictionary<ServiceTypeModel, bool>();
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                try
                {
                    var registratedServiceTypes = unitOfWork.RegistratedServiceRepository.Get(x => x.ServiceProviderId == provider.Id
                                                                                     && x.StartDate.Day == time.Date.Day
                                                                                     && x.StartDate.Month == time.Date.Month
                                                                                     && x.StartDate.Year == time.Date.Year);
                    var serviceTypes = unitOfWork.ServiceTypeRepository.Get();

                    resultCollection = AvailableServiceTypesHelper.CheckAvailability(time,registratedServiceTypes, serviceTypes.Select(x => new ServiceTypeModel(x)));
                }
                catch (Exception e)
                {
                    _logger.LogToFile(_logger.CreateErrorMessage(e));
                }
            }
            return resultCollection;
        }

        private void UpdateServicePhases(ICollection<ServicePhaseModel> collection,IUnitOfWork unitOfWork)
        {
            foreach (var phase in collection)
            {               
                  unitOfWork.ServicePhaseRepository.Update(phase.ToEntity());                 
            }
        }
        private void AddServicePhases(ICollection<ServicePhaseModel> collection, IUnitOfWork unitOfWork,int serviceTypeId)
        {
            foreach (var phase in collection)
            {
                phase.ServiceTypeId = serviceTypeId;
                unitOfWork.ServicePhaseRepository.Insert(phase.ToEntity());
            }
        }

        private void DeleteServicePhases(ServiceTypeModel serviceType, IUnitOfWork unitOfWork)
        {
            var oldIds = serviceType.Phases.Select(y => y.Id);
            var actualIds = unitOfWork.ServicePhaseRepository.Get(x => x.ServiceTypeId == serviceType.Id).Select(x=>x.Id);
            var idsToDelete = actualIds.Where(x => !oldIds.Contains(x));
            var phasesToDelete =
                unitOfWork.ServicePhaseRepository.Get(x => idsToDelete.Contains(x.Id));

            foreach (var phase in phasesToDelete)
            {
                unitOfWork.ServicePhaseRepository.Delete(phase);
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
