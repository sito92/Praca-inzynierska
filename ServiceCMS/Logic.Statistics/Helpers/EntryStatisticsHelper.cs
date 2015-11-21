using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Logic.Common.Models;

namespace Logic.Statistics.Helpers
{
    public static class EntryStatisticsHelper
    {
        public static Dictionary<string, int> GetUsersPerCountry(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<string, int>();
            var statisticsEngine = new Modules.Statistics.Services.Statistics();

            foreach (var entity in entities)
            {
                var country = statisticsEngine.GetCountryPerIpAddress(entity.IP);

                if (result.ContainsKey(country))
                    result[country] += 1;
                else
                    result.Add(country, 1);
            }
            return result;
        }

        public static Dictionary<DateTime, int> GetUsersBetweenDates(IEnumerable<StatisticsInformation> entities, DateTime from, DateTime to)
        {
            var result = new Dictionary<DateTime, int>();

            foreach (var entity in entities)
            {
                if (entity.Date >= from && entity.Date <= to)
                {
                    if (result.ContainsKey(entity.Date))
                        result[entity.Date] += 1;
                    else
                        result.Add(entity.Date,1);
                }
            }
            return result;
        }

        public static Dictionary<int, int> GetUsersForSelectedMonth(IEnumerable<StatisticsInformation> entities,int month)
        {
            var result = new Dictionary<int, int>();

            foreach (var entity in entities)
            {
                if (entity.Date.Month == month)
                {
                    if (result.ContainsKey(entity.Date.Month))
                        result[entity.Date.Month] += 1;
                    else
                        result.Add(entity.Date.Month, 1);
                }
            }
            return result;
        }
    }
}
