using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class ExchangesCoinByIdResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Fiat> fiats { get; set; }
        public double adjusted_volume_24h_share { get; set; }
    }

    public class Fiat
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }
}
