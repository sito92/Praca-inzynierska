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

        int GetUsersForSelectedMonth(int month, int year);

        Dictionary<int, int> GetUsersForEveryMonth(int year);

        void AddEntry(StatisticsInformationModel userEntry);

        Dictionary<string, int> GetUsersPerCountry();
    }
}
