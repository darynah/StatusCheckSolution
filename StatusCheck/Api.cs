using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusCheck
{
    public class Api
    {
        public Api(string restClientUrl)
        {
            _baseUrl = restClientUrl;
            _restClient = new RestClient(_baseUrl);
        }

        private readonly string _baseUrl;
        private readonly RestClient _restClient;
        private static RestRequest _restRequest(string apiUrl, Method method) => new RestRequest(apiUrl, method);

        public IRestResponse ExecuteRequest(string addToUrl = "", Method method = Method.GET)
        {
            var requestUrl = _baseUrl + (addToUrl.Length > 0 ? $"&{addToUrl}" : addToUrl);
            var result = _restClient.Execute(_restRequest(requestUrl, method));

            return result;
        }

    }
}
