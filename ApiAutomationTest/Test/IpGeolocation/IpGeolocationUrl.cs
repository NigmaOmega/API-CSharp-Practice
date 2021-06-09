using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.IpGeolocation
{
    static class IpGeolocationUrl
    {
        public static string BaseUrl {get;} = "https://freegeoip.app";
        public static string IpGeolocation {get;} = BaseUrl + "/{format}";
        public static string IpGeolocationWithIpOrHostName {get;} = BaseUrl + "/{format}/{ip-or-hostname}";

    }
}
