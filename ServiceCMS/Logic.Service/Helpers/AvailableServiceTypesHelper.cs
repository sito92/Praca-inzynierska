using DAL.Models;
using Logic.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Service.Helpers
{
    public static class AvailableServiceTypesHelper
    {
        public static Dictionary<ServiceTypeModel, bool> CheckAvailability(IEnumerable<RegistratedService> registratedServices, IEnumerable<ServiceType> serviceTypes)
        {
            var availableServiceTypes = new Dictionary<ServiceTypeModel, bool>();

            foreach(var part in serviceTypes)
            {
                
                //if()
                //{
                //    availableServiceTypes.Add(part,true);
                //}
                //else
                //{
                //    availableServiceTypes.Add(part,false);
                //}
            }
            
            return availableServiceTypes;
        }
    }
}
