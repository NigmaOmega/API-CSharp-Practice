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
    class ByBreadApiGet : BaseTest
    {
        [Test]
        public void GetAllImagesByBreed_Successfully()
        {
            string breadName = "bulldog";
            var response = ApiCallingCenter.GetAllImagesByBreed(breadName);
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.GreaterOrEqual(body.message.Count, 0);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds/");
            }
        }

        [Test]
        public void GetAllImagesByBreed_WithInvalidBreadName_NotFound()
        {
            string breadName = "invalid-bread";
            var response = ApiCallingCenter.GetAllImagesByBreed(breadName);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void RandomImageFromABreedCollection_Successfully()
        {
            string breadName = "bulldog";
            var response = ApiCallingCenter.RandomImageFromABreedCollection(breadName);
            var body = response.Content.ToObject<SingleImageReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            body.message.AreContain("https://images.dog.ceo/breeds");
        }

        [Test]
        public void RandomImageFromABreedCollection_WithInvalidBreadName_NotFound()
        {
            string breadName = "invalid-bread";
            var response = ApiCallingCenter.RandomImageFromABreedCollection(breadName);
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

        [Test]
        public void RandomMultiImagesFromABreedCollection_Successfully()
        {
            int numberOfImages = 3;
            string breadName = "bulldog";
            var response = ApiCallingCenter.RandomMultiImagesFromABreedCollection(breadName,numberOfImages.ToString());
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(numberOfImages, body.message.Count);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds");
            }
        }

        [Test]
        public void RandomMultiImagesFromABreedCollection_WithNumberOfImageLessThan1_Successfully()
        {
            int numberOfImages = 0;
            string breadName = "bulldog";
            var response = ApiCallingCenter.RandomMultiImagesFromABreedCollection(breadName, numberOfImages.ToString());
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(1, body.message.Count);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds");
            }
        }

        [Test]
        public void RandomMultiImagesFromABreedCollection_WithInvalidBreadName_NotFound()
        {
            int numberOfImages = 3;
            string breadName = "invalid-bread";
            var response = ApiCallingCenter.RandomMultiImagesFromABreedCollection(breadName, numberOfImages.ToString());
            var body = response.Content.ToObject<DogApiErrorReponse>();

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("error", body.status);
            Assert.AreEqual("Breed not found (master breed does not exist)", body.message);
            Assert.AreEqual(404, body.code);
        }

    }
}
