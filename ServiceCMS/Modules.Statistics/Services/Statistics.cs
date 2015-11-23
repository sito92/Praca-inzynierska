using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Modules.Statistics.Interfaces;

namespace Modules.Statistics.Services
{
    public class Statistics : IStatistics
    {
        private const string API_ADDRES_FOR_COUNTRY_FROM_IP = "http://www.freegeoip.net/json/";

        public string GetCountryPerIpAddress(string ip)
        {
            
            return "";
        }
    }
}
