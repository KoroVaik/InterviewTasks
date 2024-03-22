using API.Clients;
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

        public List<string> FetchLoginFailTotal(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            var response = _loginFailTotalApiClient.GetLoginFailTotalResponse(userName, failCount, fetchLimit);
            response.VerifySuccessfulStatusCode();
            return response.GetContent<List<string>>();
        }

        public string FetchLoginFailTotalWithError(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            var response = _loginFailTotalApiClient.GetLoginFailTotalResponse(userName, failCount, fetchLimit);
            return response.GetContent<string>();
        }
    }
}
