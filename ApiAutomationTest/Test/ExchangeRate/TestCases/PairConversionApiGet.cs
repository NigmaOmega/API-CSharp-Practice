using ApiAutomationTest.Test.ExchangeRate.Model;
using ApiAutomationTest.Test.ExchangeRate.Model.Standard;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.ExchangeRate.TestCases
{
    [TestFixture]
    [Ignore("Due to limited access!!!")]
    class PairConversionApiGet : BaseTest
    {
        [Test]
        public void PairExchangeRaite_Successfully() {
            string baseCurrency = "GBP";
            string targetCurrency = "EUR";
            var response = ApiCallingCenter.PairExchangeRaite(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.result);
            Assert.AreEqual(baseCurrency, body.base_code);
            Assert.AreEqual(targetCurrency, body.target_code);
            Assert.AreEqual("https://www.exchangerate-api.com/docs", body.documentation);
            Assert.AreEqual("https://www.exchangerate-api.com/terms", body.terms_of_use);
            Assert.Less(body.time_last_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.Less(body.time_next_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.IsTrue(body.time_last_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
            Assert.IsTrue(body.time_next_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
        }

        [Test]
        public void PairExchangeRaite_WithUnsupportedBaseCurrency_Error()
        {
            string baseCurrency = "GBC";
            string targetCurrency = "EUR";
            var response = ApiCallingCenter.PairExchangeRaite(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("unsupported-code", body.ErrorType);

        }

        [Test]
        public void PairExchangeRaite_WithInvalidBaseCodeFormat_Error()
        {
            string baseCurrency = "EURX";
            string targetCurrency = "EUR";
            var response = ApiCallingCenter.PairExchangeRaite(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("malformed-request", body.ErrorType);

        }


        [Test]
        public void PairExchangeRaite_WithUnsupportedTargetCurrency_Error()
        {
            string baseCurrency = "EUR";
            string targetCurrency = "GB";
            var response = ApiCallingCenter.PairExchangeRaite(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("unsupported-code", body.ErrorType);

        }

        [Test]
        public void PairExchangeRaite_WithInvalidTargetCodeFormat_Error()
        {
            string baseCurrency = "EUR";
            string targetCurrency = "EURX";
            var response = ApiCallingCenter.PairExchangeRaite(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("malformed-request", body.ErrorType);

        }


        [Test]
        public void PairExchangeRaiteWithAmount_Successfully()
        {
            string baseCurrency = "GBP";
            string targetCurrency = "EUR";
            string amount = "1234.1234";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency, amount);
            var body = response.Content.ToObject<ExchangeRateResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.result);
            Assert.AreEqual(baseCurrency, body.base_code);
            Assert.AreEqual(targetCurrency, body.target_code);
            Assert.AreEqual("https://www.exchangerate-api.com/docs", body.documentation);
            Assert.AreEqual("https://www.exchangerate-api.com/terms", body.terms_of_use);
            Assert.Less(body.time_last_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.Less(body.time_next_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.IsTrue(body.time_last_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
            Assert.IsTrue(body.time_next_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
        }

        [Test]
        public void PairExchangeRaiteWithAmount_WithUnsupportedBaseCurrency_Error()
        {
            string baseCurrency = "GBC";
            string targetCurrency = "EUR";
            string amount = "1234.1234";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency, amount);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("unsupported-code", body.ErrorType);

        }

        [Test]
        public void PairExchangeRaiteWithAmount_WithInvalidBaseCodeFormat_Error()
        {
            string baseCurrency = "EURX";
            string targetCurrency = "EUR";
            string amount = "1234.1234";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency, amount);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("malformed-request", body.ErrorType);

        }


        [Test]
        public void PairExchangeRaiteWithAmount_WithUnsupportedTargetCurrency_Error()
        {
            string baseCurrency = "EUR";
            string targetCurrency = "GB";
            string amount = "1234.1234";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency, amount);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("unsupported-code", body.ErrorType);

        }

        [Test]
        public void PairExchangeRaiteWithAmount_WithInvalidTargetCodeFormat_Error()
        {
            string baseCurrency = "EUR";
            string targetCurrency = "EURX";
            string amount = "1234.1234";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency, amount);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("malformed-request", body.ErrorType);

        }
    }
}
