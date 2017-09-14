using Ct.SubFinder.Domain;
using Ct.SubFinder.Infrastructure.ApiServiceAgent;
using Ct.SubFinder.Infrastructure.Messages;
using System;

namespace Ct.SubFinder.Core.GatewayService
{
    public class GatewayApiServiceAgent 
    {
        private readonly IApiServiceAgent<ApiRequest, ApiResponse> _apiServiceAgent;
        private Content<ApiRequest, ApiResponse> _content;

        public GatewayApiServiceAgent(IApiServiceAgent<ApiRequest, ApiResponse> apiServiceAgent)
        {
            _apiServiceAgent = apiServiceAgent ?? throw new ArgumentNullException("apiService");
            _content = new Content<ApiRequest, ApiResponse>();            
        }

        public Session GetNewSession()
        {
            _content.Request = new ApiRequest
            {
                Url = "http://localhost:32775/api/Session/new ",
                Method = ApiMethod.GET,
                returnType = typeof(Session)
            };

            _apiServiceAgent.Invoke(_content);

            var session = _content.Response?.Body as Session;

            if (session != null)
            {
                return session;
            }

            //throw new LoginException();
            return session;
        }

        /// <summary>
        /// Log in into the system and retreive a token.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="secrete"></param>
        /// <returns></returns>
        public User Login(string email, string secrete)
        {
            _content.Request = new LoginApiRequest
            {
                Url = "http://api.mydomain.com/login/",
                Method = ApiMethod.GET,
                Token = "",
                Email = email,
                Secrete = secrete
            };

           // _apiServiceAgent.Invoke(_content);

            var loginResponse = _content.Response as LoginApiResponse;

            if(loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
            {                
                return loginResponse.Identity; 
            }

            //throw new LoginException();
            return new User { FirstName = "user@subfinder.com" };
        }        
    }
}
