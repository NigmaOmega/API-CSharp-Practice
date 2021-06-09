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
    class RandomImage : BaseTest
    {
        [Test]
        public void DisplaySingleRandomImageFromAllDogsCollection_Successfully()
        {
            var response = ApiRest.Call(RestSharp.Method.GET, DogUrl.RandomAnImage);
            var body = response.Content.ToObject<SingleImageReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            body.message.AreContain("https://images.dog.ceo/breeds/");
        }

        [Test]
        public void DisplayMultiRandomImagesFromAllDogsCollection_Successfully()
        {
            int numberOfImages = 3;
            var url = DogUrl.RandomImages.Replace("{number-of-image}", numberOfImages.ToString());
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(numberOfImages, body.message.Count);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds/");
            }
        }

        [Test]
        public void DisplayMultiRandomImagesFromAllDogsCollection_WithNumberOfImagesLessThan1_Successfully()
        {
            int numberOfImages = -3;
            var url = DogUrl.RandomImages.Replace("{number-of-image}", numberOfImages.ToString());
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(1, body.message.Count);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds/");
            }
        }

        [Test]
        public void DisplayMultiRandomImagesFromAllDogsCollection_WithNumberOfImagesMoreThan50_Successfully()
        {
            int numberOfImages = 5000;
            var url = DogUrl.RandomImages.Replace("{number-of-image}", numberOfImages.ToString());
            var response = ApiRest.Call(RestSharp.Method.GET, url);
            var body = response.Content.ToObject<MultiImagesReponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("success", body.status);
            Assert.AreEqual(50, body.message.Count);
            foreach (var image in body.message)
            {
                image.AreContain("https://images.dog.ceo/breeds/");
            }
        }
    }
}
