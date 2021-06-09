using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Tickers
{
    class HistoricalTickersResponse
    {
        public DateTime timestamp { get; set; }
        public double price { get; set; }
        public long volume_24h { get; set; }
        public long market_cap { get; set; }
    }

}
