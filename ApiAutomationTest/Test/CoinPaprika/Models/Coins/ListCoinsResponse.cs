namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    public class ListCoinsResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public bool is_new { get; set; }
        public bool is_active { get; set; }
        public string type { get; set; }
    }
}
