using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class ServicePhaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DelayInSeconds { get; set; }
        public int DurationInSeconds { get; set; }
        public int Order { get; set; }
        public int ServiceTypeId { get; set; }


        public ServicePhaseModel()
        {

        }

        public ServicePhaseModel(ServicePhase entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            DelayInSeconds = entity.DelayInSeconds;
            DurationInSeconds = entity.DurationInSeconds;
            Order = entity.Order;
            ServiceTypeId = entity.ServiceTypeId;
        }

        public ServicePhase ToEntity()
        {
            return new ServicePhase()
            {
                Id = this.Id,
                Name = this.Name,
                DelayInSeconds = this.DelayInSeconds,
                DurationInSeconds = this.DurationInSeconds,
                Order = this.Order,
                ServiceTypeId = this.ServiceTypeId
            };
        }
    }
}
