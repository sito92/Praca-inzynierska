using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class ServiceTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DurationInSeconds { get; set; }

        public ServiceTypeModel()
        {
            
        }

        public ServiceTypeModel(ServiceType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            DurationInSeconds = entity.DurationInSeconds;
        }

        public ServiceType ToEntity()
        {
            return new ServiceType()
            {
                Id = this.Id,
                Name = this.Name,
                DurationInSeconds = this.DurationInSeconds
            };
        }
    }
}
