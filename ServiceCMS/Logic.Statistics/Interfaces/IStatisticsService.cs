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

        Dictionary<DateTime, int> GetUsersBetweenDates(DateTime? from = null, DateTime? to = null);

        Dictionary<DateTime, int> GetUsersForSelectedMonth(int month, int year);

        Dictionary<DateTime, int> GetUsersForEveryMonth(int year);

        void AddEntry(StatisticsInformationModel userEntry);

        Dictionary<string, int> GetActionsBetweenDates(DateTime? from, DateTime? to);

        Dictionary<string, int> GetUsersPerCountry();
    }
}
