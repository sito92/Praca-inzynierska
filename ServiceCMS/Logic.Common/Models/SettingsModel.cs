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

        public string Name { get; set; }

        public string Value { get; set; }


        public SettingsModel(Settings entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Value = entity.Value;
        }

        public Settings ToEntity()
        {
            return new Settings()
            {
                Id = this.Id,
                Name = this.Name,
                Value = this.Value
            };
        }

    }
}
