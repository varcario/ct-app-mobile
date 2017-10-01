using System;
using System.Collections.Generic;
using System.Text;

namespace Ct.App.Infrastructure.Interfaces
{
    public interface IBusinessLogic<STATE>
    {
        STATE InvokeBusinessLogic(STATE state);
    }
}
