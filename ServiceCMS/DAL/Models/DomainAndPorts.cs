using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DomainAndPorts
    {
        public int Id { get; set; }

        public string DomainName { get; set; }

        public int DomainPort { get; set; }
    }
}
