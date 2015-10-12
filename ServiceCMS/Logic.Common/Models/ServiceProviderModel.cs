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

        public List<ServiceTypeModel> AvailableServvices { get; set; }

        public ServiceProviderModel()
        {
            
        }

        public ServiceProviderModel(ServiceProvider entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            AvailableServvices = entity.AvailableServvices == null ? null :entity.AvailableServvices.Select(x => new ServiceTypeModel(x)).ToList();
        }

        public ServiceProvider ToEntity()
        {
            return new ServiceProvider()
            {
                Id = this.Id,
                Name = this.Name,
                AvailableServvices =
                    this.AvailableServvices == null ? null : this.AvailableServvices.Select(x => x.ToEntity()).ToList()
            };
        }
    }
}
