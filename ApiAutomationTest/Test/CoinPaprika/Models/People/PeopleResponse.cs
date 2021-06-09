using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class PeopleResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int teams_count { get; set; }
        public Links links { get; set; }
        public List<Position> positions { get; set; }
    }

    public class Github
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Linkedin
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Twitter
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Additional
    {
        public string url { get; set; }
        public int followers { get; set; }
    }

    public class Position
    {
        public string coin_id { get; set; }
        public string coin_name { get; set; }
        public string position { get; set; }
    }
}
