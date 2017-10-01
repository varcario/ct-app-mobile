
using Ct.App.Infrastructure.Infrastructure;
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;

namespace Ct.SubFinder.Mobile.App.Agents.User
{
    public class PostUserAgent : ServiceAgent<AppState>
    {
        public PostUserAgent(IPerformanceTrace performanceTrace) : base(performanceTrace) { }

        protected override AppState ExecuteService(AppState state)
        {
            return state;
        }
    }
}
