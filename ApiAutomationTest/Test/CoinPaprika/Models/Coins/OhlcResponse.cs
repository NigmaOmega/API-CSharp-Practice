using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class OhlcResponse
    {
        public DateTime time_open { get; set; }
        public DateTime time_close { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double volume { get; set; }
        public long market_cap { get; set; }
    }
}
