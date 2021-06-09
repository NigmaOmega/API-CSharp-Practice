using ApiAutomationTest.Test.IpGeolocation.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiAutomationTest.Test.IpGeolocation.TestCases
{
    [TestFixture]
    class IpGeolocationGetApi : BaseTest
    {
        [Test]
        public void GetIpGeolocationWithJsonFormat_Successfully() {
            string format = "json";
            var response = ApiCallingCenter.GetIpGeolocationWithJsonFormat(format);
            var body = response.Content.ToObject<IpGeolocationResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(body.ip,"ip");
            Assert.IsNotEmpty(body.country_code, "country_code");
            Assert.IsNotEmpty(body.country_name, "country_name");
            Assert.IsNotEmpty(body.region_name, "region_name");
            Assert.IsNotEmpty(body.city, "city");
            Assert.IsNotEmpty(body.time_zone, "time_zone");
            Assert.IsNotEmpty(body.time_zone, "time_zone");
            Assert.IsNotNull(body.latitude, "latitude");
            Assert.IsNotNull(body.longitude, "longitude");
            Assert.IsNotNull(body.metro_code, "metro_code");
        }

        [Test]
        public void GetIpGeolocationWithHtmlFormat_Successfully()
        {
            string format = "xml";
            var response = ApiCallingCenter.GetIpGeolocationWithJsonFormat(format);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Content.IsXmlFormat());
        }

        [Test]
        public void GetIpGeolocationWithInvalidFormat_NotFound()
        {
            string format = "invalid-format";
            var response = ApiCallingCenter.GetIpGeolocationWithJsonFormat(format);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.True(response.Content.IsHtmlFormat());

        }

        [Test]
        public void GetIpGeolocationWithJsonFormatAndHostName_Successfully()
        {
            string format = "json";
            string hostname = "google.com";
            var response = ApiCallingCenter.GetIpGeolocationWithIpOrHostName(format, hostname);
            var body = response.Content.ToObject<IpGeolocationResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(body.ip, "ip");
            Assert.IsNotNull(body.country_code, "country_code");
            Assert.IsNotNull(body.country_name, "country_name");
            Assert.IsNotNull(body.region_name, "region_name");
            Assert.IsNotNull(body.city, "city");
            Assert.IsNotNull(body.time_zone, "time_zone");
            Assert.IsNotNull(body.time_zone, "time_zone");
            Assert.IsNotNull(body.latitude, "latitude");
            Assert.IsNotNull(body.longitude, "longitude");
            Assert.IsNotNull(body.metro_code, "metro_code");
        }

        [Test]
        public void GetIpGeolocationWithJsonFormatAndInvalidHostName_NotFound()
        {
            string format = "invalid-format";
            string hostname = "google.comxx";
            var response = ApiCallingCenter.GetIpGeolocationWithIpOrHostName(format, hostname);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.True(response.Content.IsHtmlFormat());

        }


        [Test]
        public void GetIpGeolocationWithJsonFormatAndIp_Successfully()
        {
            string format = "json";
            string ip = "203.41.99.98";
            var response = ApiCallingCenter.GetIpGeolocationWithIpOrHostName(format, ip);
            var body = response.Content.ToObject<IpGeolocationResponse>();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(body.ip, "ip");
            Assert.IsNotNull(body.country_code, "country_code");
            Assert.IsNotNull(body.country_name, "country_name");
            Assert.IsNotNull(body.region_name, "region_name");
            Assert.IsNotNull(body.city, "city");
            Assert.IsNotNull(body.time_zone, "time_zone");
            Assert.IsNotNull(body.time_zone, "time_zone");
            Assert.IsNotNull(body.latitude, "latitude");
            Assert.IsNotNull(body.longitude, "longitude");
            Assert.IsNotNull(body.metro_code, "metro_code");
        }


        [Test]
        public void GetIpGeolocationWithJsonFormatAndInvalidIp_NotFound()
        {
            string format = "invalid-format";
            string ip = "203.41.99.999";
            var response = ApiCallingCenter.GetIpGeolocationWithIpOrHostName(format, ip);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.True(response.Content.IsHtmlFormat());

        }
    }
}
