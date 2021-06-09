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
    class EnrichedApiGet : BaseTest
    {

        [Test]
        public void PairExchangeRaiteWithAmount_WithUnsupportedBaseCurrency_Error()
        {
            string baseCurrency = "GBC";
            string targetCurrency = "EUR";
            var response = ApiCallingCenter.PairExchangeRaiteWithAmount(baseCurrency, targetCurrency);
            var body = response.Content.ToObject<ExchangeRateErrorResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("error", body.result);
            Assert.AreEqual("unsupported-code", body.ErrorType);

        }
    }
}
