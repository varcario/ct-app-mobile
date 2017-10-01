
using Ct.App.Infrastructure.Infrastructure;
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;

namespace Ct.SubFinder.Mobile.App.Agents.Profile
{
    public class PutProfileAgent : ServiceAgent<AppState>
    {
        public PutProfileAgent(IPerformanceTrace performanceTrace) : base(performanceTrace) { }

        protected override AppState ExecuteService(AppState state)
        {
            return state;
        }
    }
}
