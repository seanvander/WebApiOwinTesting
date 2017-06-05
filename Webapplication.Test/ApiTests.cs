using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Testing;
using System.Net.Http;

namespace WebApplication.Test
{
    [TestClass]
    public class ApiTests
    {
        protected TestServer _server;

        [TestInitialize]
        public void Initialize()
        {
            // Create an OWIN test server
            _server = TestServer.Create<Startup>();
        }

        [TestMethod]
        public void TestApi()
        {
            // Get the HttpClient from the OWIN test server
            HttpClient client = _server.HttpClient;

            // Use a mock url, but use a valid route
            var url = "http://mockserver/api/values";

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = client.SendAsync(request).ConfigureAwait(false).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            var responseContent = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            Assert.IsTrue(responseContent.Contains("value1"));
            Assert.IsTrue(responseContent.Contains("value2"));
        }
    }
}
