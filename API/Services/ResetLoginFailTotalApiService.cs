using API.Clients;
using API.Helpers;

namespace API.Actions
{
    public class ResetLoginFailTotalApiService
    {
        protected readonly ResetLoginFailTotalApiClient _resetLoginFailTotalAPIClient;

        public ResetLoginFailTotalApiService(string url)
        {
            _resetLoginFailTotalAPIClient = new ResetLoginFailTotalApiClient(url);
        }

        public ApiResponse ResetLoginFailTotal(string? userName, bool hasResponseWithError = false)
        {
            var response = _resetLoginFailTotalAPIClient.PutResetLoginFailTotal(userName);
            if (!hasResponseWithError) response.VerifySuccessfulStatusCode();
            return response;
        }
    }
}
