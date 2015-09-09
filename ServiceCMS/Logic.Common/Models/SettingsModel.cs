using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class SettingsModel
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailDomain { get; set; }

        public SecureString EmailPassword { get; set; }

        public ICollection<DomainAndPorts> DomainAndPorts { get; set; } 

        public SettingsModel(Settings entity)
        {
            this.Id = entity.Id;
            this.EmailAddress = entity.EmailAddress;
            this.DomainAndPorts = entity.DomainAndPorts;
            this.EmailDomain = EmailDomain;
            this.EmailPassword = EmailPassword;
        }

        public Settings ToEntity()
        {
            return new Settings()
            {
                Id = this.Id,
                EmailAddress = this.EmailAddress,
                EmailDomain = this.EmailDomain,
               // EmailPassword = this.EmailPassword,
                DomainAndPorts = this.DomainAndPorts
            };
        }

    }
}
