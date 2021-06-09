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
    class StandardApiGet : BaseTest
    {
        [Test]
        public void GetStandardExchangeRate_Successfully()
        {
            string baseCurrency = "USD";
            var response = ApiCallingCenter.GetStandardExchangeRate(baseCurrency);
            var body = response.Content.ToObject<ExchangeRateResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.result);
            Assert.AreEqual(baseCurrency, body.base_code);
            Assert.AreEqual("https://www.exchangerate-api.com/docs", body.documentation);
            Assert.AreEqual("https://www.exchangerate-api.com/terms", body.terms_of_use);
            Assert.Less(body.time_last_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.Less(body.time_next_update_unix, DateTimeOffset.Now.ToUnixTimeMilliseconds());
            Assert.IsTrue(body.time_last_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
            Assert.IsTrue(body.time_next_update_utc.HasValidFormat(DateFormatChecker.RssFormat));
        }

        [Test]
        public void GetStadardExchangeRate_WithInvalidBaseCurrency()
        {
            string baseCurrency = "invalid-base-currency";;
            var response = ApiCallingCenter.GetStandardExchangeRate(baseCurrency);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            response.Content.AreContain("404 Not Found");
        }

    }
}
