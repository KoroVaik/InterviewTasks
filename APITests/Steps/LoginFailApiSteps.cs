using API.Actions;
using API.Helpers;
using API.Models;
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

        public List<UserInfoResponse> FetchAllLoginFailTotals(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            return _loginFailTotalAPIService.FetchLoginFailTotal(userName, failCount, fetchLimit);
        }

        public ApiResponse FetchLoginFailTotalWithError(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            return _loginFailTotalAPIService.FetchLoginFailTotalWithError(userName, failCount, fetchLimit);
        }

        public void ResetLoginFailTotalForUser(string userName)
        {
            _resetLoginFailTotalApiService.ResetLoginFailTotal(userName, false);
        }

        public ApiResponse ResetLoginFailTotalWithError(string? userName)
        {
            return _resetLoginFailTotalApiService.ResetLoginFailTotal(userName, true);
        }
    }
}
