
using Ct.SubFinder.Domain;

namespace Ct.SubFinder.Mobile.App.Core
{
    public class AppState
    {
        public Session Session { get; set; }
        public User User { get; set; }
        public Account Account { get; set; }

        public AppState()
        {
            Session = new Session { Credential = new Credential { } };
            User = new User {Profile = new Profile() };
            Account = new Account { Owner = new User { Profile = new Profile() } };
        }
    }
}
