using API.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Clients
{
    public class ResetLoginFailTotalApiClient : BaseApiClient
    {
        private readonly string ResetLoginFailTotal = "/resetloginfailtotal";
        public ResetLoginFailTotalApiClient(string url) : base(url)
        {
        }

        public ApiResponse PutResetLoginFailTotal(string? userName = null)
        {
            var requestBuilder = new RequestBuilder().WithMethod(Method.Put).WithResource(ResetLoginFailTotal);
            if (userName == null) requestBuilder.WithQueryParameter("userName", userName!);
            return Execute(requestBuilder.CreateRequest());
        }
    }
}
