using ApiAutomationTest.Test.CoinPaprika.Models.Tools;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class ToolsApiGet : BaseTest
    {
        [Test]
        public void Search_Successfully()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("q", "btc");
            var response = ApiCallingCenter.Search(parameters);
            var body = response.Content.ToObject<SearchResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(body.currencies.Count, 0);

        }

        [Test]
        public void Search_WithOutQParameter_BadRequest()
        {
            var response = ApiCallingCenter.Search();
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void Search_WithLimitParameterExceed250_BadRequest()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("q", "btc");
            parameters.Add("limit", 251);
            var response = ApiCallingCenter.Search(parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void GetPriceConverter_Successfully()
        {
            var parameters = new Dictionary<string, Object>();
            string baseCurrencyId = "btc-bitcoin";
            string quoteCurrencyId = "usd-us-dollars";
            parameters.Add("base_currency_id", baseCurrencyId);
            parameters.Add("quote_currency_id", quoteCurrencyId);
            var response = ApiCallingCenter.GetPriceConverter(parameters);
            var body = response.Content.ToObject<PriceConverterResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(baseCurrencyId, body.base_currency_id);
            Assert.AreEqual(quoteCurrencyId, body.quote_currency_id);

        }

        [Test]
        public void GetPriceConverter_WithOutBaseCurrencyIdParameter_BadRequest()
        {
            var parameters = new Dictionary<string, Object>();
            string baseCurrencyId = "btc-bitcoin";
            parameters.Add("base_currency_id", baseCurrencyId);
            var response = ApiCallingCenter.GetPriceConverter(parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void GetPriceConverter_WithOutQuoteCurrencyIdParameter_BadRequest()
        {
            var parameters = new Dictionary<string, Object>();
            string quoteCurrencyId = "btc-bitcoin";
            parameters.Add("quote_currency_id", quoteCurrencyId);
            var response = ApiCallingCenter.GetPriceConverter(parameters);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

    }
}
