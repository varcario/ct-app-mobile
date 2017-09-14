using System;
using System.Collections.Generic;
using System.Text;

namespace Ct.SubFinder.Domain
{
    public class Credential
    {
        public string Token { get; set; }        
        public DateTime Expires { get; set; }
    }
}
