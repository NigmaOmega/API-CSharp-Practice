using ApiAutomationTest.Test.CoinPaprika.Models.Tickers;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class TickersApiGet : BaseTest
    {
        [Test]
        public void GetTickersForAllCoins_Succesfully()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "USD,BTC");
            var response = ApiCallingCenter.GetTickersForAllCoins(parameters);
            var body = response.Content.ToListObject<TickerResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(body.rank, 0);
            Assert.Greater(body.max_supply, 0);
        }

        [Test]
        public void GetTickersForAllCoins_WithInvalidQuotes_BadRequest()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "USDdd");
            var response = ApiCallingCenter.GetTickersForAllCoins(parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);

        }

        [Test]
        public void GetTickerInformationForSpecificCoin_Succesfully()
        {
            string coinId = "";

            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "USD,BTC");
            var response = ApiCallingCenter.GetTickerInformationForSpecificCoin(coinId, parameters);
            var body = response.Content.ToListObject<TickerResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(body.rank, 0);
            Assert.Greater(body.max_supply, 0);
        }

        [Test]
        public void GetTickerInformationForSpecificCoin_WithInvalidQuotes_BadRequest()
        {
            string coinId = "";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "USDdd");
            var response = ApiCallingCenter.GetTickerInformationForSpecificCoin(coinId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);

        }

        [Test]
        public void GetTickerInformationForSpecificCoin_WithInvalidCoinId_NotFound()
        {
            string coinId = "Invalid-CoinId";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "USD");
            var response = ApiCallingCenter.GetTickerInformationForSpecificCoin(coinId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("id not found", body.error);
        }

        [Test]
        public void GetHistoricalTickersForSpecificCoin_Successfully()
        {
            var coinId = "btc-bitcoin";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");
            parameters.Add("limit", 5000);
            parameters.Add("quotes", "usd");

            var response = ApiCallingCenter.GetHistoricalTickersForSpecificCoin(coinId, parameters);
            var body = response.Content.ToListObject<HistoricalTickersResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(body.price, 0);
        }

        [Test]
        public void GetHistoricalTickersForSpecificCoin_InvalidCoinId_NotFound()
        {
            var coinId = "invalid-coint";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");
            parameters.Add("limit", 5000);
            parameters.Add("quotes", "usd");

            var response = ApiCallingCenter.GetHistoricalTickersForSpecificCoin(coinId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("id not found", body.error);
        }

        [Test]
        public void GetHistoricalTickersForSpecificCoin_WithOutStartParameter_BadRequest()
        {
            var coinId = "btc-bitcoin";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("limit", 5000);
            parameters.Add("quotes", "usd");

            var response = ApiCallingCenter.GetHistoricalTickersForSpecificCoin(coinId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void GetHistoricalTickersForSpecificCoin_WithLimitParameterExceedLimit5000_BadRequest()
        {
            var coinId = "btc-bitcoin";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");
            parameters.Add("limit", 5001);
            parameters.Add("quotes", "usd");

            var response = ApiCallingCenter.GetHistoricalTickersForSpecificCoin(coinId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }


    }
}
