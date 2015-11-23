using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Logic.Common.Models;
using Modules.RestSharp.JsonReaders;

namespace Logic.Statistics.Helpers
{
    public static class EntryStatisticsHelper
    {
        public static Dictionary<string, int> GetUsersPerCountry(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<string, int>();
 

            foreach (var entity in entities)
            {
                var country = IpInfoReader.GetIpInfo(entity.IP).country_name;

                if (result.ContainsKey(country))
                    result[country] += 1;
                else
                    result.Add(country, 1);
            }
            return result;
        }

        public static Dictionary<DateTime, int> GetUsersBetweenDates(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<DateTime, int>();

            foreach (var entity in entities)
            {
                if (result.ContainsKey(entity.Date))
                    result[entity.Date] += 1;
                else
                    result.Add(entity.Date, 1);

            }
            return result;
        }

        public static int GetUsersForSelectedMonth(IEnumerable<StatisticsInformation> entities)
        {
            var result = 0;

            foreach (var entity in entities)
            {
                
            }
            return result;
        }

        public static Dictionary<int, int> GetUsersAmountForEveryMonth(IEnumerable<StatisticsInformation> entities)
        {
            throw new NotImplementedException();
        }
    }
}
