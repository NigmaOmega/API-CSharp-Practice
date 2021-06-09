using ApiAutomationTest.Test.CoinPaprika.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class ContractsApiGet : BaseTest
    {
        [Test]
        public void GetListContractsPlatforms_Successfully()
        {
            var response = ApiCallingCenter.GetListContractsPlatforms();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(response.Content.ToListObject<string>().Count, 0);
        }

        [Test]
        public void GetAllContractAddressesForPlatform_Successfully()
        {
            string platformId = "eth-ethereum";
            var response = ApiCallingCenter.GetAllContractAddressessForPlatform(platformId);
            var body = response.Content.ToListObject<ContractAddressesResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.Greater(body.Count, 0);
        }

        [Test]
        public void RedirectToTickerByContractAddress_Successfully()
        {
            string platformId = "eth-ethereum";
            string contractAddress = "0xd26114cd6ee289accf82350c8d8487fedb8a0c07";
            var response = ApiCallingCenter.RedirectToTickerByContractAddress(platformId, contractAddress);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void RedirectToTickerHistoricalValuesByContractAddress_Successfully()
        {
            string platformId = "eth-ethereum";
            string contractAddress = "0xd26114cd6ee289accf82350c8d8487fedb8a0c07";

            var parameters = new Dictionary<string, Object>();
            parameters.Add("start", "1518671700");

            var response = ApiCallingCenter.RedirectToTickerHistorical(platformId, contractAddress, parameters);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
