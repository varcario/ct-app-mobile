using Ct.SubFinder.Infrastructure.Messages;
using System;
using System.Collections.Generic;

namespace Ct.SubFinder.Infrastructure.ApiServiceAgent
{
    public class ApiRequest : Request
    {        
        public ApiMethod Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public object Body { get; set; }
        public string Token { get; set; }
        public string Url { get; set; }
        public Type returnType { get; set; }
    }
}
