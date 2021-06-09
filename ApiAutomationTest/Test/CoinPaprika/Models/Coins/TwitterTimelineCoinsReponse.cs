using System;

namespace ApiAutomationTest.Test.CoinPaprika.Models
{
    class TwitterTimelineCoinsResponse
    {
        public DateTime date { get; set; }
        public string user_name { get; set; }
        public string user_image_link { get; set; }
        public string status { get; set; }
        public bool is_retweet { get; set; }
        public int retweet_count { get; set; }
        public int like_count { get; set; }
        public string status_link { get; set; }
        public string status_id { get; set; }
        public string media_link { get; set; }
        public string youtube_link { get; set; }
    }
}
