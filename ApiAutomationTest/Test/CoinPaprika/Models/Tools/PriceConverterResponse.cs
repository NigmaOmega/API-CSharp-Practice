using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Tools
{
    class PriceConverterResponse
    {
        public string base_currency_id { get; set; }
        public string base_currency_name { get; set; }
        public DateTime base_price_last_updated { get; set; }
        public string quote_currency_id { get; set; }
        public string quote_currency_name { get; set; }
        public DateTime quote_price_last_updated { get; set; }
        public long amount { get; set; }
        public double price { get; set; }
    }
}
