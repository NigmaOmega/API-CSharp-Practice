using ApiAutomationTest.Test.CoinPaprika.Models;
using NUnit.Framework;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class PeopleApiGet : BaseTest
    {
        [Test]
        public void GetPeopleById_Successfully()
        {
            string personId = "vitalik-buterin";
            var response = ApiCallingCenter.GetPeopleById(personId);

            var body = response.Content.ToString().ToObject<PeopleResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(personId, body.id);
        }


        [Test]
        public void GetPeopleById_WithInvalidPersonId_NotFound()
        {
            string personId = "invalid-ID";
            var response = ApiCallingCenter.GetPeopleById(personId);

            var body = response.Content.ToString().ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("id not found", body.error);
        }
    }
}
