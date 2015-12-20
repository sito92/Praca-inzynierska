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
        List<RegistratedServiceModel> GetAll();
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date);
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date, ServiceProviderModel serviceProvider);
    }
}
