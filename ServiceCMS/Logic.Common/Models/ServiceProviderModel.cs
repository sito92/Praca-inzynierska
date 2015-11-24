using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class ServiceProviderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ServiceTypeModel> AvailableServices { get; set; }

        public ServiceProviderModel()
        {
            
        }

        public ServiceProviderModel(ServiceProvider entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            AvailableServices = entity.AvailableServices == null ? null :entity.AvailableServices.Select(x => new ServiceTypeModel(x)).ToList();
        }

        public ServiceProvider ToEntity()
        {
            return new ServiceProvider()
            {
                Id = this.Id,
                Name = this.Name,
                AvailableServices =
                    this.AvailableServices == null ? null : this.AvailableServices.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
