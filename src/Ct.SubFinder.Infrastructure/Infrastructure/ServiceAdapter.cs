using Ct.SubFinder.Infrastructure.Interfaces;
using System;


namespace Ct.SubFinder.Infrastructure.Infrastructure
{
    public abstract class ServiceAdapter<STATE, BUSINESS_LOGIC, RESPONSE> : IServiceAdapter<STATE, BUSINESS_LOGIC, RESPONSE> where BUSINESS_LOGIC: IBusinessLogic<STATE>
    {
        private readonly IPerformanceTrace _performanceTrace;
        private readonly BUSINESS_LOGIC _businessLogic;

        public ServiceAdapter(IPerformanceTrace performanceTrace, BUSINESS_LOGIC buseinssLogic)
        {
            _performanceTrace = performanceTrace ?? throw new ArgumentNullException("performanceTrace");
            _businessLogic = buseinssLogic != null ? buseinssLogic : throw new ArgumentNullException("bussinessLogic");
        }

        protected abstract STATE TranslateRequest(params object[] input);
        protected abstract RESPONSE TranslateResponse(STATE state);

        public RESPONSE InvokeServiceAdapter(params object[] input)
        {
            STATE state = default(STATE);
            RESPONSE response = default(RESPONSE);
            try
            {
                _performanceTrace.CreateLog(Marker.BEGIN);
                state = TranslateRequest(input);
            }catch(Exception ex)
            {
                _performanceTrace.CreateLog(Marker.ERROR);
            }
            _performanceTrace.CreateLog(Marker.END);

            try
            {
                _performanceTrace.CreateLog(Marker.BEGIN);
                state = _businessLogic.InvokeBusinessLogic(state);
            }
            catch(Exception ex)
            {
                _performanceTrace.CreateLog(Marker.ERROR);
            }
            _performanceTrace.CreateLog(Marker.END);

            try
            {
                _performanceTrace.CreateLog(Marker.BEGIN);
                response = TranslateResponse(state);
            }
            catch(Exception ex)
            {
                _performanceTrace.CreateLog(Marker.ERROR);
            }
            _performanceTrace.CreateLog(Marker.END);
            return response;
        }
    }
}
