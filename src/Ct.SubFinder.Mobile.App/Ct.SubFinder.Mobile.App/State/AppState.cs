
using Ct.SubFinder.Domain;

namespace Ct.SubFinder.Mobile.App.Core
{
    public class AppState
    {
        public Profile Profile { get; set; }
        public Session Session { get; set; }

        public AppState()
        {
            Profile = new Profile { User = new User { } };
            Session = new Session { Credential = new Credential { } };
        }
    }
}
