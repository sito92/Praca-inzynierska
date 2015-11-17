using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Logic.Common.Models;

namespace Logic.Statistics.Interfaces
{
    public interface IStatisticsService
    {
        List<StatisticsInformationModel> GetUniqueUsers();

        Dictionary<DateTime, int> GetUsersPerMonth(DateTime from, DateTime to);

        void AddEntry(object userEntry);

        Dictionary<string, int> GetUsersPerCountry();
    }
}
