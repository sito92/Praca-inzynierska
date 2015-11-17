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

        public int VisitsAmount { get; set; }

        public string Country { get; set; }

        public DateTime Date { get; set; }
    }
}
