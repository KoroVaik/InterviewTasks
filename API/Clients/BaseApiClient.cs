using API.Helpers;
using RestSharp;

namespace API.Clients
{
    public class BaseApiClient
    {
        private readonly RestClient _restClient;
        private readonly string _authorizationToken;

        public BaseApiClient(string url)
        {
            _restClient = new RestClient(url);
            _authorizationToken = GetAuthorizationToken();
        }

        public ApiResponse Execute(RestRequest restRequest)
        {
            restRequest.AddHeader("Authorization", _authorizationToken);
            var response = _restClient.Execute(restRequest);
            return new ApiResponse(response);
        }

        private string GetAuthorizationToken()
        {
            return string.Empty;
        }
    }
}
