using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BestBuyTest.Test
{
    [TestClass]
    public class BestBuyProductAPITest : BaseTest
    {

        [TestMethod]
        public void VerifyGetProductAPI()
        {
            IRestResponse restResponse = requestFactory.GetAllProduct($"{endpointUrl}/{productResource}");

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            
        }

        [TestMethod]
        public void VerifyGetProductAPIWithQueryParam()
        {

            Dictionary<string, object> allQueryParam = new Dictionary<string, object>();

            int limit = 5;
            allQueryParam.Add("$limit", limit);

            string productEndpointUrl = $"{endpointUrl}/{productResource}";

            var restResponse = requestFactory.GetAllProduct(productEndpointUrl, allQueryParam);

            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);

            Assert.AreEqual(limit, restResponse.Data.limit);

        }
    }
}
