using ApiAutomationTest.Test.CoinPaprika.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class GlobalApiGet : BaseTest
    {
        [Test]
        public void GetGlobalInformation_Successfully()
        {
            var response = ApiCallingCenter.GetGlobalInformation();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            response.Content.ToString().IsValidJson();
            var body = response.Content.ToString().ToObject<GlobalResponse>();

            Assert.Greater(body.market_cap_usd, 0, "market_cap_usd");
            Assert.Greater(body.volume_24h_usd, 0, "volume_24h_usd");
            Assert.Greater(body.bitcoin_dominance_percentage, 0, "bitcoin_dominance_percentage");
            Assert.Greater(body.cryptocurrencies_number, 0, "cryptocurrencies_number");
            Assert.Greater(body.market_cap_ath_value, 0, "market_cap_ath_value");
            Assert.LessOrEqual(body.market_cap_ath_date, DateTime.Now, "market_cap_ath_date");
            Assert.Greater(body.volume_24h_ath_value, 0, "volume_24h_ath_value");
            Assert.LessOrEqual(body.volume_24h_ath_date, DateTime.Now, "volume_24h_ath_date");
            Assert.IsNotNull(body.market_cap_change_24h, "market_cap_change_24h");
            Assert.IsNotNull(body.volume_24h_change_24h, "volume_24h_change_24h");
            Assert.Greater(body.last_updated, 0, "last_updated");
        }

    }
}
