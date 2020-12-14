using BestBuyApp.Model;
using CommonLibrary.RestRequest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyApp.Request
{
    public class RequestFactory
    {
        RestClientCustom restClient;

        public RequestFactory()
        {
            restClient = new RestClientCustom();
        }

        public IRestResponse GetAllProduct(string endpointUrl)
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse restResponse = restClient.SendGetRequest(restRequest);
            
            return restResponse;

        }

        public IRestResponse<RootProductDTO> GetAllProduct(string endpointUrl, Dictionary<string, object> queryParam)
        {
            IRestRequest restRequest = new RestRequest(endpointUrl);

            IRestResponse<RootProductDTO> restResponse = restClient.SendGetRequest<RootProductDTO>(restRequest, queryParam);

            return restResponse;

        }
    }
}
