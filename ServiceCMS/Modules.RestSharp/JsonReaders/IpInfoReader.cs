using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.RestSharp.Modules;
using Newtonsoft.Json;
using RestSharp;

namespace Modules.RestSharp.JsonReaders
{
    public static class IpInfoReader
    {
        public static IpInfo GetIpInfo(string ip)
        {
            var restClient = new RestClient(IpInfo.API_ADDRES_FOR_COUNTRY_FROM_IP);
            var request = new RestRequest(ip,Method.GET);

            try
            {
                var response = JsonConvert.DeserializeObject<IpInfo>(restClient.Execute(request).Content);
                return response;
            }
            catch (Exception)
            {
               throw new JsonSerializationException();
            }
        }
    }
}
