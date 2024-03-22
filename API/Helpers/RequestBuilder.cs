using RestSharp;

namespace API.Helpers
{
    public class RequestBuilder
    {
        private readonly RestRequest _request;

        public RequestBuilder()
        {
            _request = new RestRequest();
        }

        public RequestBuilder WithResource(string resource)
        {
            _request.Resource = resource;
            return this;
        }

        public RequestBuilder WithMethod(Method method)
        {
            _request.Method = method;
            return this;
        }

        public RequestBuilder WithHeader(string key, string value)
        {
            _request.AddHeader(key, value);
            return this;
        }

        public RequestBuilder WithQueryParameter(string key, string value)
        {
            _request.AddQueryParameter(key, value);
            return this;
        }

        public RequestBuilder WithBody(string requestBody)
        {
            _request.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return this;
        }

        public RestRequest CreateRequest() => _request;
    }
}
