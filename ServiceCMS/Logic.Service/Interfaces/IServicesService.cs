using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Common.Models;

namespace Logic.Service.Interfaces
{
    public interface IServicesService
    {
        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date);

        List<RegistratedServiceModel> GetAllServicesWithMatchingCriteria(DateTime date, ServiceProviderModel serviceProvider);
    }
}
