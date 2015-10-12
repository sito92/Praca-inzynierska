using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class RegistratedServiceModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
      
        public ServiceProviderModel ServiceProvider { get; set; }
        public ServiceTypeModel ServiceType { get; set; }

        public RegistratedServiceModel()
        {
            
        }

        public RegistratedServiceModel(RegistratedService entity)
        {
            Id = entity.Id;
            StartDate = entity.StartDate;
            ServiceProvider = entity.ServiceProvider == null ? null : new ServiceProviderModel(entity.ServiceProvider);
            ServiceType = entity.ServiceType == null ? null : new ServiceTypeModel(entity.ServiceType);
        }

        public RegistratedService ToEntity()
        {
            return new RegistratedService()
            {
                Id = this.Id,
                StartDate = this.StartDate,
                ServiceProvider = this.ServiceProvider == null ? null : this.ServiceProvider.ToEntity(),
                ServiceType = this.ServiceType == null ? null : this.ServiceType.ToEntity()
            };
        }

    }
}
