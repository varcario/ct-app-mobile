using Ct.App.Infrastructure.Infrastructure;
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;

namespace Ct.SubFinder.Mobile.App.Agents.Session
{
    public class PostSessionAgent : ServiceAgent<AppState>
    {
        public PostSessionAgent(IPerformanceTrace performanceTrace) : base(performanceTrace) { }

        protected override AppState ExecuteService(AppState state)
        {
            if(state.Session.Username == "Ismar" && state.Session.Secrete == "password")
            {
                state.User.Profile = new Domain.Profile { FirstName = "Ismar" };
            }
            return state;
        }
    }
}
