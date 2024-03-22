using API.Clients;

namespace API.Actions
{
    public class ResetLoginFailTotalApiService
    {
        protected readonly ResetLoginFailTotalApiClient _resetLoginFailTotalAPIClient;

        public ResetLoginFailTotalApiService(string url)
        {
            _resetLoginFailTotalAPIClient = new ResetLoginFailTotalApiClient(url);
        }

        public string ResetLoginFailTotal(string? userName, bool hasResponseWithError = false)
        {
            var response = _resetLoginFailTotalAPIClient.PutResetLoginFailTotal(userName);
            if (!hasResponseWithError) response.VerifySuccessfulStatusCode();
            return response.GetContent<string>();
        }
    }
}
