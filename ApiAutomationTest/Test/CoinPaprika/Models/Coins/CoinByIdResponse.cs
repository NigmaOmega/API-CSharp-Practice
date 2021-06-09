using System;
using System.Collections.Generic;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{

    public class CoinByIdResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public Parent parent { get; set; }
        public int rank { get; set; }
        public bool is_new { get; set; }
        public bool is_active { get; set; }
        public string type { get; set; }
        public List<Tag> tags { get; set; }
        public List<Team> team { get; set; }
        public string description { get; set; }
        public string message { get; set; }
        public bool open_source { get; set; }
        public bool hardware_wallet { get; set; }
        public DateTime started_at { get; set; }
        public string development_status { get; set; }
        public string proof_type { get; set; }
        public string org_structure { get; set; }
        public string hash_algorithm { get; set; }
        public string contract { get; set; }
        public string platform { get; set; }
        public List<Contract> contracts { get; set; }
        public Links links { get; set; }
        public List<LinksExtended> links_extended { get; set; }
        public Whitepaper whitepaper { get; set; }
        public DateTime first_data_at { get; set; }
        public DateTime last_data_at { get; set; }
    }
    public class Parent
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Tag
    {
        public string id { get; set; }
        public string name { get; set; }
        public int coin_counter { get; set; }
        public int ico_counter { get; set; }
    }

    public class Team
    {
        public string id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }

    public class Contract
    {
        public string contract { get; set; }
        public string platform { get; set; }
        public string type { get; set; }
    }

    public class Links
    {
        public List<string> explorer { get; set; }
        public List<string> facebook { get; set; }
        public List<string> reddit { get; set; }
        public List<string> source_code { get; set; }
        public List<string> website { get; set; }
        public List<string> youtube { get; set; }
        public object medium { get; set; }
    }

    public class Stats
    {
        public int subscribers { get; set; }
        public int? contributors { get; set; }
        public int? stars { get; set; }
    }

    public class LinksExtended
    {
        public string url { get; set; }
        public string type { get; set; }
        public Stats stats { get; set; }
    }

    public class Whitepaper
    {
        public string link { get; set; }
        public string thumbnail { get; set; }
    }

}
