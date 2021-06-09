using ApiAutomationTest.Test.CoinPaprika.Models.Tags;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApiAutomationTest.Test.CoinPaprika.TestCases
{
    [TestFixture]
    class TagApiGet : BaseTest
    {
        [Test]
        public void GetTagById_Successfully()
        {
            string tagId = "blockchain-service";

            var url = CoinPaprikaUrl.TagById.Replace("{tag_id}", tagId);

            var parameters = new Dictionary<string, Object>();
            parameters.Add("additional_fields", "coins,icos");

            var response = ApiRest.Call(RestSharp.Method.GET, url, null, null, parameters);
            var body = response.Content.ToObject<TagResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(tagId, body.id);
            Assert.GreaterOrEqual(body.coin_counter, 0);
        }

        [Test]
        public void GetTagById_WithInvalidAdditionalFields_BadRequest()
        {
            string tagId = "blockchain-service";

            var url = CoinPaprikaUrl.TagById.Replace("{tag_id}", tagId);

            var parameters = new Dictionary<string, Object>();
            parameters.Add("additional_fields", "invalid-field");

            var response = ApiRest.Call(RestSharp.Method.GET, url, null, null, parameters);

            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }

        [Test]
        public void GetTagById_WithInvalidTagId_NotFound()
        {
            string tagId = "invalid-tag";

            var url = CoinPaprikaUrl.TagById.Replace("{tag_id}", tagId);

            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("id not found", body.error);
        }

        [Test]
        public void GetListTags_Successfully()
        {

            var parameters = new Dictionary<string, Object>();
            parameters.Add("additional_fields", "coins,icos");

            var response = ApiCallingCenter.GetListTags(parameters);
            var body = response.Content.ToListObject<TagResponse>().First();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(body.id);
            Assert.GreaterOrEqual(body.coin_counter, 0);
        }

        [Test]
        public void GetListTags_WithInvalidAdditionalFields_NotFound()
        {
            var parameters = new Dictionary<string, Object>();
            parameters.Add("additional_fields", "invalid-field");

            var response = ApiCallingCenter.GetListTags(parameters);

            var body = response.Content.ToObject<CoinPaprikaErrorResponse>();

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("invalid parameters", body.error);
        }


    }
}
