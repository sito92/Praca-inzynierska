using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Logic.Common.Models;
using Logic.Service.Services;

namespace Logic.Service.Helpers
{
    public static class ServiceProviderHelper
    {
        public static Expression<Func<ServiceProvider, bool>> CheckAvailability(ServiceType model)
        {
            return x => x.AvailableServices.Contains(model);
        }
    }
}
