using API.Actions;
using API.Clients;
using API.Services;

namespace APITests.Steps
{
    public class LoginFailApiSteps
    {
        private readonly LoginFailTotalAPIService _loginFailTotalAPIService;

        private readonly ResetLoginFailTotalApiService _resetLoginFailTotalApiService;

        public LoginFailApiSteps(string url) 
        {
            _loginFailTotalAPIService = new LoginFailTotalAPIService(url);
            _resetLoginFailTotalApiService = new ResetLoginFailTotalApiService(url);
        }

        public List<string> FetchAllLoginFailTotals(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            return _loginFailTotalAPIService.FetchLoginFailTotal(userName, failCount, fetchLimit);
        }

        public string FetchLoginFailTotalWithError(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            return _loginFailTotalAPIService.FetchLoginFailTotalWithError(userName, failCount, fetchLimit);
        }

        public void ResetLoginFailTotalForUser(string userName)
        {
            _resetLoginFailTotalApiService.ResetLoginFailTotal(userName, false);
        }

        public string ResetLoginFailTotalWithError(string? userName)
        {
            return _resetLoginFailTotalApiService.ResetLoginFailTotal(userName, true);
        }
    }
}
