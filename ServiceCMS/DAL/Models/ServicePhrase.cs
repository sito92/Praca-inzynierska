using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ServicePhase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DelayInSeconds { get; set; }
        public int DurationInSeconds { get; set; }
        public int Order { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
