using ApiAutomationTest.Test.CoinPaprika.Models.Exchanges;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class ExchangesApiGet : BaseTest
    {
        [Test]
        public void GetListExchanges_Successfully()
        {
            var response = ApiCallingCenter.GetListEchanges();
            var body = response.Content.ToListObject<ExchangeResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Less(body.last_updated, DateTime.Now);
            Assert.Greater(body.currencies, 0);
        }

        [Test]
        public void GetListExchanges_WithInvalidQuote_BadRequest()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "invalid-quote");
            var response = ApiCallingCenter.GetListEchanges(parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void GetExchangeById_Successfully()
        {
            var exchangeId = "binance";
            var response = ApiCallingCenter.GetExchangeById(exchangeId);
            var body = response.Content.ToObject<ExchangeResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Less(body.last_updated, DateTime.Now);
            Assert.Greater(body.currencies, 0);
        }

        [Test]
        public void GetExchangeById_WithInvalidQuote_BadRequest()
        {
            var exchangeId = "binance";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "invalid-quote");
            var response = ApiCallingCenter.GetExchangeById(exchangeId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }


        [Test]
        public void GetMarketsByExchangeId_Successfully()
        {
            var exchangeId = "binance";
            var response = ApiCallingCenter.GetMarketsByExchangeId(exchangeId);
            var body = response.Content.ToListObject<ExchangeMarketResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Less(body.last_updated, DateTime.Now);
        }


        [Test]
        public void GetMarketsByExchangeId_WithInvalidQuote_BadRequest()
        {
            var exchangeId = "binance";
            var parameters = new Dictionary<string, Object>();
            parameters.Add("quotes", "invalid-quote");
            var response = ApiCallingCenter.GetMarketsByExchangeId(exchangeId, parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }
    }
}
