using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.IpGeolocation
{
   public static class ApiCallingCenter
    {
        public static IRestResponse GetIpGeolocationWithJsonFormat(string format)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("format", format);


            return ApiRest.Call(RestSharp.Method.GET, IpGeolocationUrl.IpGeolocation, null, null, null, pathParameter);
        }

        public static IRestResponse GetIpGeolocationWithIpOrHostName(string format,string ipOrHostName)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("format", format);
            pathParameter.Add("ip-or-hostname", ipOrHostName);


            return ApiRest.Call(RestSharp.Method.GET, IpGeolocationUrl.IpGeolocation, null, null, null, pathParameter);
        }
    }
}
