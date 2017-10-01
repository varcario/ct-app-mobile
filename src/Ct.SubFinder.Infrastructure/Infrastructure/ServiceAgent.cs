
using Ct.App.Infrastructure.Interfaces;
using System;

namespace Ct.App.Infrastructure.Infrastructure
{
    public abstract class ServiceAgent<STATE> : IAgent<STATE>
    {
        private readonly IPerformanceTrace _performanceTrace;
        protected abstract STATE ExecuteService(STATE state);
        public ServiceAgent(IPerformanceTrace performanceTrace)
        {
            _performanceTrace = performanceTrace ?? throw new ArgumentNullException("performanceTrace");
        }
        public STATE SendRequest(STATE state)
        {
            try
            {
                _performanceTrace.CreateLog(Marker.BEGIN);
                ExecuteService(state);
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
