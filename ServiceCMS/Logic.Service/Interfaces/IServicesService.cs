using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Service.Interfaces
{
    public interface IServicesService
    {
        ResponseBase Insert(RegistratedServiceModel model);
        ResponseBase Update(RegistratedServiceModel model);
        ResponseBase Delete(int id);
        List<RegistratedServiceModel> GetAll();
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(ServiceProviderModel serviceProvider);
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date);
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date, ServiceProviderModel serviceProvider);
    }
}
