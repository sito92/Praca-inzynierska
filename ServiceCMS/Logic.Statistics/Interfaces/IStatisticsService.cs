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

        Dictionary<string, int> GetUsersBetweenDates(DateTime? from = null, DateTime? to = null);

        //Dictionary<string, int> RecalculateCollectionAccordingToStep(Dictionary<string,int> collection, int? step);

        Dictionary<string, int> GetUsersForSelectedMonth(int month, int year);

        Dictionary<string, int> GetUsersForEveryMonth(int year);

        void AddEntry(StatisticsInformationModel userEntry);

        Dictionary<string, int> GetActionsBetweenDates(DateTime? from, DateTime? to);

        Dictionary<string, int> GetUsersPerCountry();
    }
}
