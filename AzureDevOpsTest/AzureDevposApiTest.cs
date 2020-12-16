using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace AzureDevOpsTest
{
    [TestClass]
    public class AzureDevposApiTest
    {
        [TestMethod]
        public void GetAllProjectList()
        {
            string endpointUrl = "https://dev.azure.com/qatechhub/_apis/projects";

            IRestClient restClient = new RestClient 
            {

                Authenticator = new HttpBasicAuthenticator("saurabh.d2106@gmail.com", "tlikmpcshqwzxzgnwhtrcj4jjezd6bd3meocdiz5u46hh5vqoo5q")

            };

            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse restResponse = restClient.Get(restRequest);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            System.Console.WriteLine(restResponse.Content);

    }
    }
}
