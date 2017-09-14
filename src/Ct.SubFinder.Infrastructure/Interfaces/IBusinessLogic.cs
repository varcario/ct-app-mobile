using System;
using System.Collections.Generic;
using System.Text;

namespace Ct.SubFinder.Infrastructure.Interfaces
{
    public interface IBusinessLogic<STATE>
    {
        STATE InvokeBusinessLogic(STATE state);
    }
}
