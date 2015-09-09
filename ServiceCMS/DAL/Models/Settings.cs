using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Settings
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailDomain { get; set; }

       // public SecureString EmailPassword { get; set; }

        public ICollection<DomainAndPorts> DomainAndPorts { get; set; } 
    }
}
