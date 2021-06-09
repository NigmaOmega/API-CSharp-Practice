using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models.Tools
{
    class SearchResponse
    {
        public List<Currency> currencies { get; set; }
        public List<Ico> icos { get; set; }
        public List<Exchanx> exchanges { get; set; }
        public List<Person> people { get; set; }
        public List<Tag> tags { get; set; }
    }

    public class Currency
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public int rank { get; set; }
        public bool is_new { get; set; }
        public bool is_active { get; set; }
        public string type { get; set; }
    }

    public class Ico
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public bool is_new { get; set; }
    }

    public class Exchanx
    {
        public string id { get; set; }
        public string name { get; set; }
        public int rank { get; set; }
    }

    public class Person
    {
        public string id { get; set; }
        public string name { get; set; }
        public int teams_count { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public int coin_counter { get; set; }
        public int ico_counter { get; set; }
    }
}
