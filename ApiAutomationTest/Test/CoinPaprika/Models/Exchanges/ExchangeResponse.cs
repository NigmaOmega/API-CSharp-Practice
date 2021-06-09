using System;
using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Exchanges
{
    class ExchangeResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public bool website_status { get; set; }
        public bool api_status { get; set; }
        public string description { get; set; }
        public string message { get; set; }
        public Links links { get; set; }
        public long markets_data_fetched { get; set; }
        public long? adjusted_rank { get; set; }
        public long? reported_rank { get; set; }
        public long currencies { get; set; }
        public long markets { get; set; }
        public List<Fiat> fiats { get; set; }
        public object quotes { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class Links
    {
        public List<string> website { get; set; }
        public List<string> twitter { get; set; }
    }

    public class Fiat
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }


}
