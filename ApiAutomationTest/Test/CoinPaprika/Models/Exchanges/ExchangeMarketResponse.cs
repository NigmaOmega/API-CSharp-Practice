using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Exchanges
{
    class ExchangeMarketResponse
    {
        public string pair { get; set; }
        public string base_currency_id { get; set; }
        public string base_currency_name { get; set; }
        public string quote_currency_id { get; set; }
        public string quote_currency_name { get; set; }
        public string market_url { get; set; }
        public string category { get; set; }
        public string fee_type { get; set; }
        public bool outlier { get; set; }
        public double reported_volume_24h_share { get; set; }
        public Quotes quotes { get; set; }
        public DateTime last_updated { get; set; }
    }
}
