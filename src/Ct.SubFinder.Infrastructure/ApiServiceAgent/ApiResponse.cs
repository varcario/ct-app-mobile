using Ct.SubFinder.Infrastructure.Messages;
using System.Collections.Generic;

namespace Ct.SubFinder.Infrastructure.ApiServiceAgent
{
    public class ApiResponse : Response
    {
        public string Code { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public object Body { get; set; }
    }
}
