using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.ExchangeRate
{
    static class ExchangeRateUrl
    {
        public static string BaseUrl { get; } = "https://v6.exchangerate-api.com/v6/" + ExchangeRateConstants.Key;
        public static string StandardExchageRate { get; } = BaseUrl + "/latest/{base-currency}";
        public static string PairConversionExchageRate { get; } = BaseUrl + "/pair/{base-currency}/{target-currency}";
        public static string PairConversionExchageRateWithAmount { get; } = BaseUrl + "/pair/{base-currency}/{target-currency}/{amount}";
        public static string EnrichedExchageRate { get; } = BaseUrl + "/enriched/{base-currency}/{target-currency}";

    }
}
