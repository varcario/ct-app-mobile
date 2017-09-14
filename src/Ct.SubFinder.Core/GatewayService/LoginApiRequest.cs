using Ct.SubFinder.Infrastructure.ApiServiceAgent;

namespace Ct.SubFinder.Core.GatewayService
{
    public class LoginApiRequest : ApiRequest
    {
        public string Email { get; set; }
        public string Secrete { get; set; }
    }
}
