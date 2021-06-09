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
    class BySubBreadApiGet : BaseTest
    {
        [Test]
        public void GetListAllSubBreads_Successfully()
        {
            string breadName = "hound";
            var response = ApiCallingCenter.GetListAllSubBreads(breadName);
            var body = response.Content.ToObject<SubBreedsReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.GreaterOrEqual(body.message.Count, 0);
            foreach (var item in body.message)
            {
                Assert.IsNotEmpty(item);
            }
        }

        [Test]
        public void GetListAllSubBreads_WithInvalidBreadName_NotFound()
        {
            string breadName = "invalid-bread";
            var response = ApiCallingCenter.GetListAllSubBreads(breadName);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }


        [Test]
        public void GetListAllSubBreadsImages_Successfully()
        {
            string breadName = "hound";
            string subbreadName = "afghan";
            var response = ApiCallingCenter.GetListAllSubBreadsImages(breadName, subbreadName);
            var body = response.Content.ToObject<SubBreedsReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.GreaterOrEqual(body.message.Count, 0);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds");
            }
        }

        [Test]
        public void GetListAllSubBreadsImages_WithInvalidBreadName_NotFound()
        {
            string breadName = "invalid-bread";
            string subbreadName = "invalid-bread";
            var response = ApiCallingCenter.GetListAllSubBreadsImages(breadName, subbreadName);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void GetListAllSubBreadsImages_WithInvalidSubBreadName_NotFound()
        {
            string breadName = "hound";
            string subbreadName = "invalid-bread";
            var response = ApiCallingCenter.GetListAllSubBreadsImages(breadName, subbreadName);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (sub breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void GetSingleRandomImageFromASubBreadCollection_Successfully() {
            string breadName = "hound";
            string subbreadName = "afghan";
            var response = ApiCallingCenter.GetSingleRandomImageFromASubBreadCollection(breadName, subbreadName);
            var body = response.Content.ToObject<SingleImageReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            body.message.AreContain("https://images.dog.ceo/breeds");
        }


        [Test]
        public void GetSingleRandomImageFromASubBreadCollection_WithInvalidBreadName_NotFound()
        {
            string breadName = "invalid-bread";
            string subbreadName = "invalid-bread";
            var url = DogUrl.RandomSingleSubBreedsImage.Replace("{bread-name}", breadName).Replace("{sub-bread-name}", subbreadName);
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void GetSingleRandomImageFromASubBreadCollection_WithInvalidSubBreadName_NotFound()
        {
            string breadName = "hound";
            string subbreadName = "invalid-bread";
            var url = DogUrl.RandomSingleSubBreedsImage.Replace("{bread-name}", breadName).Replace("{sub-bread-name}", subbreadName);
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (sub breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void GetMultipleRandomImagesFromASubBreadCollection_Successfully()
        {
            int numberOfImage = 3;
            string breadName = "hound";
            string subbreadName = "afghan";
            var url = DogUrl.RandomMultipleSubBreedsImages.Replace("{bread-name}", breadName).Replace("{sub-bread-name}", subbreadName).Replace("{number-of-image}", numberOfImage.ToString()); 
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(numberOfImage, body.message.Count);
        }


        [Test]
        public void GetMultipleRandomImagesFromASubBreadCollection_WithInvalidBreadName_NotFound()
        {
            int numberOfImage = 3;
            string breadName = "invalid-bread";
            string subbreadName = "invalid-bread";
            var url = DogUrl.RandomMultipleSubBreedsImages.Replace("{bread-name}", breadName).Replace("{sub-bread-name}", subbreadName).Replace("{number-of-image}", numberOfImage.ToString());
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void GetMultipleRandomImagesFromASubBreadCollection_WithInvalidSubBreadName_NotFound()
        {
            int numberOfImage = 3;
            string breadName = "hound";
            string subbreadName = "invalid-bread";
            var url = DogUrl.RandomMultipleSubBreedsImages.Replace("{bread-name}", breadName).Replace("{sub-bread-name}", subbreadName).Replace("{number-of-image}", numberOfImage.ToString());
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (sub breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

    }
}
