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
        IList<StatisticsInformationModel> GetUniqueUsers();

        int GetUsersTotalAmount();

        IList<StatisticsInformationModel> GetAllUsers();

        Dictionary<DateTime, int> GetUsersBetweenDates(DateTime from, DateTime to);

        Dictionary<int, int> GetUsersForSelectedMonth(int month);

        Dictionary<int, int> GetUsersForEveryMonth(int month);

        void AddEntry(object userEntry);

        Dictionary<string, int> GetUsersPerCountry();
    }
}
