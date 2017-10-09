using System;
using System.Collections.Generic;
using System.Text;

namespace Ct.SubFinder.Domain
{
    public class Account
    {
        public AccountType AccountType { get; set; }
        public User Owner { get; set; }
    }
}
