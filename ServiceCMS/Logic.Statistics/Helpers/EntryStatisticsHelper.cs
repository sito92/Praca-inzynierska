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
                string country = "";
                if(entity.IP != null)
                    country = IpInfoReader.GetIpInfo(entity.IP).country_name;

                if (result.ContainsKey(country))
                    result[country] += 1;
                else
                    result.Add(country, 1);
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

        //public static Dictionary<DateTime, int> GetUsersForEveryMonth(IEnumerable<StatisticsInformation> entities)
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

        public static Dictionary<DateTime, int> GetUsersForStatistics(IEnumerable<StatisticsInformation> entities)
        {
            var result = new Dictionary<DateTime, int>();

            foreach (var entity in entities)
            {
                if (result.ContainsKey(entity.Date.Date))
                    result[entity.Date.Date] += 1;
                else
                    result.Add(entity.Date.Date, 1);
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
