using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class CointEventsByIdResponse
    {
        public string id { get; set; }
        public DateTime date { get; set; }
        public string date_to { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool is_conference { get; set; }
        public string link { get; set; }
        public string proof_image_link { get; set; }
    }
}
