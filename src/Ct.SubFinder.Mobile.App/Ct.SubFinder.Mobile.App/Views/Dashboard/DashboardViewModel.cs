using Ct.SubFinder.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Ct.SubFinder.Mobile.App.Views.Dashboard
{
    public class DashboardViewModel : BindableBase
    {
        public ObservableCollection<Profile> Profiles { get; set; }
        public DelegateCommand<string> SearchCommand { get; set; }

        public DashboardViewModel()
        {
            Profiles = new ObservableCollection<Profile>()
            {
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" },
                new Profile{ User = new User { FirstName = "Profile Works!" }, ImageUrl = "contact.png", Location = "Fort Worth" }
            };

            SearchCommand = new DelegateCommand<string>(OnSearch);
        }

        private void OnSearch(string searchTerm)
        {

        }
    }
}
