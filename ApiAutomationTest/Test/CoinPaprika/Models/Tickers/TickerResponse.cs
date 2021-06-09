using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Tickers
{
    class TickerResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public long circulating_supply { get; set; }
        public long total_supply { get; set; }
        public long max_supply { get; set; }
        public double beta_value { get; set; }
        public object quotes { get; set; }
    }
}
