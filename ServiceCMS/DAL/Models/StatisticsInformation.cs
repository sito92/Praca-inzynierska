using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StatisticsInformation
    {
        public int Id { get; set; }

        public string IP { get; set; }

        public DateTime Date { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }
    }
}
