using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace API.Helpers
{
    public class ApiResponse
    {
        private readonly RestResponse _response;
        public HttpStatusCode StatusCode { get => _response.StatusCode; }
        public string? Content { get => _response.Content; }

        public ApiResponse(RestResponse responseMessage)
        {
            _response = responseMessage;
        }

        public T GetContent<T>()
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Content);
            }
            catch (Exception)
            {
                throw new Exception(
                    $"Error deserializing content. StatusCode = {StatusCode} \nContent = {Content}");
            }
        }

        public void VerifySuccessfulStatusCode()
        {
            if ((int)StatusCode >= 200 && (int)StatusCode < 300)
                return;
            else
                throw new Exception($"Error status is not successful. Actual status code is {StatusCode}");
        }
    }
}
