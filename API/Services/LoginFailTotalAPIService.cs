using A.Models;
using API.Clients;
using API.Helpers;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class LoginFailTotalAPIService
    {
        protected readonly LoginFailTotalApiClient _loginFailTotalApiClient;

        public LoginFailTotalAPIService(string url)
        {
            _loginFailTotalApiClient = new(url);
        }

        public List<UserInfoResponse> FetchLoginFailTotal(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            var response = _loginFailTotalApiClient.GetLoginFailTotalResponse(userName, failCount, fetchLimit);
            response.VerifySuccessfulStatusCode();
            return response.GetContent<List<UserInfoResponse>>();
        }

        public ApiResponse FetchLoginFailTotalWithError(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            var response = _loginFailTotalApiClient.GetLoginFailTotalResponse(userName, failCount, fetchLimit);
            return response;
        }
    }
}
