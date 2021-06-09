using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    public class GlobalResponse
    {
        public long market_cap_usd { get; set; }
        public long volume_24h_usd { get; set; }
        public double bitcoin_dominance_percentage { get; set; }
        public int cryptocurrencies_number { get; set; }
        public long market_cap_ath_value { get; set; }
        public DateTime market_cap_ath_date { get; set; }
        public long volume_24h_ath_value { get; set; }
        public DateTime volume_24h_ath_date { get; set; }
        public double market_cap_change_24h { get; set; }
        public double volume_24h_change_24h { get; set; }
        public long last_updated { get; set; }
    }
}
