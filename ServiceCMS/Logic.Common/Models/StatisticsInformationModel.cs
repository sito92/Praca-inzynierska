using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace Logic.Common.Models
{
    public class StatisticsInformationModel
    {
        public int Id { get; set; }

        public string IP { get; set; }

        public DateTime Date { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public StatisticsInformationModel(StatisticsInformation entity)
        {
            Id = entity.Id;
            IP = entity.IP;
            Date = entity.Date;
            ControllerName = entity.ControllerName;
            ActionName = entity.ActionName;
        }

        public StatisticsInformationModel()
        {
            
        }

        public StatisticsInformation ToEntity()
        {
            return new StatisticsInformation()
            {
                Id = this.Id,
                IP = this.IP,
                Date = this.Date,
                ControllerName = this.ControllerName,
                ActionName = this.ActionName
            };
        }
    }
}
