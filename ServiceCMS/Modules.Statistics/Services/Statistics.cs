using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Modules.Statistics.Interfaces;

namespace Modules.Statistics.Services
{
    public class Statistics : IStatistics
    {
        private const string API_ADDRES_FOR_COUNTRY_FROM_IP = "http://api.hostip.info/country.php";
        public bool IsEntryUnique(object userEntry)
        {
            throw new NotImplementedException();
        }

        public string GetCountryPerIpAddress(string ip)
        {
            return new WebClient().DownloadString(API_ADDRES_FOR_COUNTRY_FROM_IP);
        }
    }
}
