using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Logic.Common.Models;

namespace Logic.Service.Interfaces
{
    public interface IServiceProviderService
    {
        ServiceProviderModel GetById(int id);

        IList<ServiceProviderModel> GetAll();

        ResponseBase Insert(ServiceProviderModel serviceProvider);

        ResponseBase Update(ServiceProviderModel serviceProvider);

        IList<ServiceProviderModel> GetAllProvidersWithAvailableServices(ServiceTypeModel serviceType);

        ResponseBase Delete(long id);
    }
}
