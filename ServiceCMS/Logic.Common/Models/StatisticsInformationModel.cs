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

        public int VisitsAmount { get; set; }

        public string Country { get; set; }

        public DateTime Date { get; set; }

        public StatisticsInformationModel(StatisticsInformation entity)
        {
            Id = entity.Id;
            IP = entity.IP;
            VisitsAmount = entity.VisitsAmount;
            Country = entity.Country;
            Date = entity.Date;
        }

        public StatisticsInformation ToEntity()
        {
            return new StatisticsInformation()
            {
                Id = this.Id,
                IP = this.IP,
                VisitsAmount = this.VisitsAmount,
                Country = this.Country,
                Date = this.Date
            };
        }
    }
}
