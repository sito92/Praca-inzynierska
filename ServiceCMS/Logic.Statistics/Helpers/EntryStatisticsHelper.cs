using System;
using System.Collections.Generic;
using System.Globalization;
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
                if(entity.IP != null && entity.Country == null)
                    entity.Country = IpInfoReader.GetIpInfo(entity.IP).country_name;

                if (result.ContainsKey(entity.Country))
                    result[entity.Country] += 1;
                else
                    result.Add(entity.Country, 1);
            }
            return result;
        }

        //public static Dictionary<DateTime, int> GetUsersBetweenDates(IEnumerable<StatisticsInformation> entities)
        //{
        //    var result = new Dictionary<DateTime, int>();

        //    foreach (var entity in entities)
        //    {
        //        if (result.ContainsKey(entity.Date.Date))
        //            result[entity.Date.Date] += 1;
        //        else
        //            result.Add(entity.Date.Date, 1);
        //    }
        //    return result;
        //}

        //public static Dictionary<DateTime, int> GetUsersForSelectedMonth(IEnumerable<StatisticsInformation> entities)
        //{
        //    var result = new Dictionary<DateTime, int>();

        //    foreach (var entity in entities)
        //    {
        //        if (result.ContainsKey(entity.Date.Date))
        //            result[entity.Date.Date] += 1;
        //        else
        //            result.Add(entity.Date.Date, 1);
        //    }
        //    return result;
        //}

        public static Dictionary<string, int> GetUsersForEveryMonth(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<string, int>();

            foreach (var entity in entities)
            {
                if (result.ContainsKey(entity.Date.ToString("MMMM",CultureInfo.InvariantCulture)))
                    result[entity.Date.ToString("MMMM",CultureInfo.InvariantCulture)] += 1;
                else
                    result.Add(entity.Date.ToString("MMMM", CultureInfo.InvariantCulture), 1);
            }
            return result;
        }

        public static Dictionary<string, int> GetUsersForStatistics(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<string, int>();

            foreach (var entity in entities)
            {
                if (result.ContainsKey(entity.Date.Day + "." + entity.Date.Month))
                    result[entity.Date.Day + "." +entity.Date.Month] += 1;
                else
                    result.Add(entity.Date.Day + "." + entity.Date.Month, 1);
            }
            return result;
        }

        public static Dictionary<string, int> GetUsersActionsForStatistics(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<string, int>();

            foreach (var entity in entities)
            {
                if (result.ContainsKey(entity.ControllerName + "/" + entity.ActionName))
                    result[entity.ControllerName + "/" + entity.ActionName] += 1;
                else
                    result.Add(entity.ControllerName + "/" + entity.ActionName, 1);
            }
            return result;
        }
    }
}
