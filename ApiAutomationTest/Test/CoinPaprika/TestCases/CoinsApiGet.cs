using ApiAutomationTest.Test.CoinPaprika.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class CoinsApiGet : BaseTest
    {
        [Test]
        public void GetListCoins_Successfully()
        {
            var response = ApiCallingCenter.GetListCoins();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().ToListObject<ListCoinsResponse>();

            var firstRankItem = body.First(s => s.rank == 1);

            Assert.IsNotNull(firstRankItem.is_active, "is_active");
            Assert.IsNotNull(firstRankItem.is_new, "is_new");
            Assert.IsNotNull(firstRankItem.name, "name");
            Assert.IsNotNull(firstRankItem.symbol, "symbol");

            Assert.AreEqual(1, firstRankItem.rank, "rank");

            Assert.Greater(body.Count, 0);
        }

        [Test]
        public void GetCoinById_Successfully()
        {
            string coinId = "btc-bitcoin";
            var response = ApiCallingCenter.GetCoinById(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().ToObject<CoinByIdResponse>();

            Assert.AreEqual(coinId, body.id);
            Assert.Greater(body.rank, 0);
        }

        [Test]
        public void GetCoinById_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            var response = ApiCallingCenter.GetCoinById(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }


        [Test]
        public void GetTwitterTimelineForCoin_Successfully()
        {

            string coinId = "btc-bitcoin";

            var response = ApiCallingCenter.GetTwitterTimelineForCoin(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<TwitterTimelineCoinsResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0);
            Assert.Less(firstItem.date, DateTime.Now);
            Assert.IsNotNull(firstItem.user_name);
        }

        [Test]
        public void GetTwitterTimelineForCoin_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";

            var response = ApiCallingCenter.GetTwitterTimelineForCoin(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }

        [Test]
        public void GetCoinEventsByCoinId_Successfully()
        {

            string coinId = "btc-bitcoin";
            var response = ApiCallingCenter.GetCoinEventsByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<CointEventsByIdResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0);
            Assert.Less(firstItem.date, DateTime.Now);
            Assert.IsNotNull(firstItem.id);
        }

        [Test]
        public void GetCoinEventsByCoinId_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            var response = ApiCallingCenter.GetCoinEventsByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }

        [Test]
        public void GetExchangesByCoinId_Successfully()
        {

            string coinId = "btc-bitcoin";
            var response = ApiCallingCenter.GetExchangesByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<ExchangesCoinByIdResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0);

            Assert.Greater(firstItem.adjusted_volume_24h_share, 0);
            Assert.IsNotNull(firstItem.id);
        }

        [Test]
        public void GetExchangesByCoinId_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";

            var response = ApiCallingCenter.GetExchangesByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }


        [Test]
        public void GetMarketsByCoinId_Successfully()
        {
            string coinId = "btc-bitcoin";
            var response = ApiCallingCenter.GetMarketsByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<MarketsByCoinIdResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0);

            Assert.Greater(firstItem.adjusted_volume_24h_share, 0);
            Assert.IsNotNull(firstItem.exchange_id, "exchange_id");
            Assert.IsNotNull(firstItem.exchange_name, "exchange_name");
            Assert.IsNotNull(firstItem.base_currency_id, "base_currency_id");
            Assert.IsNotNull(firstItem.base_currency_name, "base_currency_name");
        }

        [Test]
        public void GetMarketsByCoinId_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            var response = ApiCallingCenter.GetMarketsByCoinId(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }


        [Test]
        public void GetOhlcForLastFullDay_Successfully()
        {
            string coinId = "btc-bitcoin";
            var response = ApiCallingCenter.GetOhlcForLastFullDay(coinId);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<OhlcResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0L);

            Assert.Less(firstItem.time_open, firstItem.time_close);
            Assert.Less(firstItem.time_open, DateTime.Now);
            Assert.Less(firstItem.time_close, DateTime.Now);
            Assert.Greater(firstItem.volume, 0);
        }

        [Test]
        public void GetOhlcForLastFullDay_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            var response = ApiCallingCenter.GetOhlcForLastFullDay(coinId);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }


        [Test]
        public void GetHistoricalOhlc_Successfully()
        {
            string coinId = "btc-bitcoin";
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");
            parameters.Add("limit", "12");
            parameters.Add("quote", "btc");

            var response = ApiCallingCenter.GetHistoricalOhlc(coinId, parameters);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<OhlcResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0L);

            Assert.Less(firstItem.time_open, firstItem.time_close);
            Assert.Less(firstItem.time_open, DateTime.Now);
            Assert.Less(firstItem.time_close, DateTime.Now);
            Assert.Greater(firstItem.volume, 0);
        }

        [Test]
        public void GetHistoricalOhlc_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");
            parameters.Add("limit", "12");
            parameters.Add("quote", "btc");

            var response = ApiCallingCenter.GetHistoricalOhlc(coinId, parameters);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }


        [Test]
        public void GetTodayOhlc_Successfully()
        {

            string coinId = "btc-bitcoin";

            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            parameters.Add("quote", "btc");

            var response = ApiCallingCenter.GetTodayOhlc(coinId, parameters);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var body = response.Content.ToString().Trim().ToListObject<OhlcResponse>();
            var firstItem = body.First();

            Assert.Greater(body.Count, 0L);

            Assert.Less(firstItem.time_open, firstItem.time_close);
            Assert.Less(firstItem.time_open, DateTime.Now);
            Assert.Less(firstItem.time_close, DateTime.Now);
            Assert.Greater(firstItem.volume, 0);
        }

        [Test]
        public void GetTodayOhlc_WithInvalidCoinId_NotFound()
        {
            string coinId = "invalid-id";
            Dictionary<string, Object> parameters = new Dictionary<string, Object>();
            parameters.Add("quote", "btc");
            var response = ApiCallingCenter.GetTodayOhlc(coinId, parameters);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            var body = response.Content.ToString().Trim().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual("id not found", body.error);
        }




    }
}
