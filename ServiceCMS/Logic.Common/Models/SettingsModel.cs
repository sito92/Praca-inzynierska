using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class SettingsModel
    {
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public string EmailPassword { get; set; }

        public string Salt { get; set; }

        public SettingsModel(Settings entity)
        {
            this.Id = entity.Id;
            this.EmailAddress = entity.EmailAddress;
            this.EmailPassword = entity.EmailPassword;
            this.Salt = entity.Salt;
        }

        public Settings ToEntity()
        {
            return new Settings()
            {
                Id = this.Id,
                EmailAddress = this.EmailAddress,
                EmailPassword = this.EmailPassword,
                Salt = this.Salt
            };
        }

    }
}
