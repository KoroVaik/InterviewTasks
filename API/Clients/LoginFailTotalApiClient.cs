using API.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class LoginFailTotalApiClient : BaseApiClient
    {
        private readonly string LoginFailTotal = "/loginfailtotal";
        public LoginFailTotalApiClient(string url) : base(url)
        {
        }

        public ApiResponse GetLoginFailTotalResponse(string? userName = null, int? failCount = null, int? fetchLimit = null)
        {
            var requestBuilder = new RequestBuilder().WithMethod(Method.Get).WithResource(LoginFailTotal);
            if (userName == null) requestBuilder.WithQueryParameter("userName", userName!);
            if (failCount == null) requestBuilder.WithQueryParameter("failCount", failCount.ToString()!);
            if (fetchLimit == null) requestBuilder.WithQueryParameter("fetchLimit", fetchLimit.ToString()!);
            return Execute(requestBuilder.CreateRequest());
        }
    }
}
