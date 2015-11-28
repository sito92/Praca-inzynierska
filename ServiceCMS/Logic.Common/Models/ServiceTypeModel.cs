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

        public ICollection<ServicePhaseModel> Phases { get; set; } 

        public ServiceTypeModel()
        {
            
        }

        public ServiceTypeModel(ServiceType entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Phases = entity.Phases.Select(x=>new ServicePhaseModel(x)).OrderBy(x=>x.Order).ToList();
        }

        public ServiceType ToEntity()
        {
            return new ServiceType()
            {
                Id = this.Id,
                Name = this.Name,
                Phases = this.Phases.Select(x => x.ToEntity()).OrderBy(x => x.Order).ToList()
            };
        }
    }
}
