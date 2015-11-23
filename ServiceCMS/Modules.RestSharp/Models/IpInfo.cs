using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serializers;

namespace Modules.RestSharp.Modules
{
    public class IpInfo
    {
        public string country_name { get; set; }
        public const string API_ADDRES_FOR_COUNTRY_FROM_IP = "http://www.freegeoip.net/json/";
    }
}
