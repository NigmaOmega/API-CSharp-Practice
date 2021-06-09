using Newtonsoft.Json;
using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class MarketsByCoinIdResponse
    {
        public string exchange_id { get; set; }
        public string exchange_name { get; set; }
        public string pair { get; set; }
        public string base_currency_id { get; set; }
        public string base_currency_name { get; set; }
        public string quote_currency_id { get; set; }
        public string quote_currency_name { get; set; }
        public string market_url { get; set; }
        public string category { get; set; }
        public string fee_type { get; set; }
        public bool outlier { get; set; }
        public double adjusted_volume_24h_share { get; set; }
        public Quotes quotes { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class KEY
    {
        public double price { get; set; }
        public double volume_24h { get; set; }
    }

    public class Quotes
    {
        [JsonProperty("$KEY")]
        public KEY KEY { get; set; }
    }
}
