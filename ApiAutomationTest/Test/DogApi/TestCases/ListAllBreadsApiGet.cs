using ApiAutomationTest.Test.DogApi.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.DogApi.TestCases
{
    [TestFixture]
    class ListAllBreadsApiGet : BaseTest
    {
        [Test]
        public void GetListAllBreads_Successfully()
        {
            var response = ApiRest.Call(RestSharp.Method.GET, DogUrl.ListAllBreeds);
            var body = response.Content.ToObject<BreadsReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            body.message.ToString().AreContain("affenpinscher");
        }
    }
}
