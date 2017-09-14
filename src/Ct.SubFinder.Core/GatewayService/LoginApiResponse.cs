using Ct.SubFinder.Domain;
using Ct.SubFinder.Infrastructure.ApiServiceAgent;

namespace Ct.SubFinder.Core.GatewayService
{
    public class LoginApiResponse : ApiResponse
    {
        public string Token { get; set; }
        public User Identity { get; set; }
    }
}
