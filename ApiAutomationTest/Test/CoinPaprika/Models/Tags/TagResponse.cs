using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Tags
{
    class TagResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public int coin_counter { get; set; }
        public int ico_counter { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public List<string> coins { get; set; }
        public List<string> icos { get; set; }
    }
}
