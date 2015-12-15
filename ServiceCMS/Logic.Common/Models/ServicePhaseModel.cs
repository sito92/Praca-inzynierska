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
        public int DelayInMinutes { get; set; }
        public int DurationInMinutes { get; set; }
        public int Order { get; set; }
        public int ServiceTypeId { get; set; }


        public ServicePhaseModel()
        {

        }

        public ServicePhaseModel(ServicePhase entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            DelayInMinutes = entity.DelayInMinutes;
            DurationInMinutes = entity.DurationInMinutes;
            Order = entity.Order;
            ServiceTypeId = entity.ServiceTypeId;
        }

        public ServicePhase ToEntity()
        {
            return new ServicePhase()
            {
                Id = this.Id,
                Name = this.Name,
                DelayInMinutes = this.DelayInMinutes,
                DurationInMinutes = this.DurationInMinutes,
                Order = this.Order,
                ServiceTypeId = this.ServiceTypeId
            };
        }
    }
}
