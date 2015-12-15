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
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }

        public ServiceProviderModel ServiceProvider { get; set; }
        public ServiceTypeModel ServiceType { get; set; }

        public RegistratedServiceModel()
        {

        }

        public RegistratedServiceModel(RegistratedService entity)
        {
            Id = entity.Id;
            StartDate = entity.StartDate;
            ClientName = entity.ClientName;
            ClientSurname = entity.ClientSurname;
            ClientEmail = entity.ClientEmail;
            ClientPhoneNumber = entity.ClientPhoneNumber;
            ServiceProvider = entity.ServiceProvider == null ? null : new ServiceProviderModel(entity.ServiceProvider);
            ServiceType = entity.ServiceType == null ? null : new ServiceTypeModel(entity.ServiceType);
        }

        public RegistratedService ToEntity()
        {
            return new RegistratedService()
            {
                Id = this.Id,
                StartDate = this.StartDate,
                ClientName = this.ClientName,
                ClientSurname = this.ClientSurname,
                ClientEmail = this.ClientEmail,
                ClientPhoneNumber = this.ClientPhoneNumber,
                ServiceProvider = this.ServiceProvider == null ? null : this.ServiceProvider.ToEntity(),
                ServiceType = this.ServiceType == null ? null : this.ServiceType.ToEntity()
            };
        }

    }
}
