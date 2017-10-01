using Ct.App.Infrastructure.Interfaces;
using System;

namespace Ct.App.Infrastructure.Infrastructure
{
    public abstract class BusinessLogic<STATE> : IBusinessLogic<STATE>
    {
        private readonly IPerformanceTrace _performanceTrace;
        public BusinessLogic(IPerformanceTrace performanceTrace)
        {
            _performanceTrace = performanceTrace ?? throw new ArgumentNullException("performanceTrace");
        }
        public abstract STATE ExecuteLogic(STATE state);
        public STATE InvokeBusinessLogic(STATE state)
        {            
            try
            {
                _performanceTrace.CreateLog(Marker.BEGIN);
                ExecuteLogic(state);
            }
            catch (Exception ex)
            {
                _performanceTrace.CreateLog(Marker.ERROR);
            }
            _performanceTrace.CreateLog(Marker.END);
            return state;
        }
    }
}
