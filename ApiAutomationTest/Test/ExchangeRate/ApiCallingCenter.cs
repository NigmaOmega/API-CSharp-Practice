using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.ExchangeRate
{
   public static class ApiCallingCenter
    {
        public static IRestResponse PairExchangeRaiteWithAmount(string baseCurrency, string targetCurrency, string amount = "")
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("base-currency", baseCurrency);
            pathParameter.Add("target-currency", targetCurrency);
            pathParameter.Add("amount", amount);

            return ApiRest.Call(RestSharp.Method.GET, ExchangeRateUrl.PairConversionExchageRateWithAmount, null, null, null, pathParameter);
        }

        public static IRestResponse PairExchangeRaite(string baseCurrency, string targetCurrency)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("base-currency", baseCurrency);
            pathParameter.Add("target-currency", targetCurrency);   

            return ApiRest.Call(RestSharp.Method.GET, ExchangeRateUrl.PairConversionExchageRate, null, null, null, pathParameter);
        }

        public static IRestResponse GetStandardExchangeRate(string baseCurrency)
        {
            Dictionary<string, object> pathParameter = new Dictionary<string, object>();
            pathParameter.Add("base-currency", baseCurrency);

            return ApiRest.Call(RestSharp.Method.GET, ExchangeRateUrl.StandardExchageRate, null, null, null, pathParameter);
        }
    }
}
