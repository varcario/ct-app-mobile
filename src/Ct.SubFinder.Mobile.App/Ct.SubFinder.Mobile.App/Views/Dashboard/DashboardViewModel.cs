using Ct.SubFinder.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ct.SubFinder.Mobile.App.Views.Dashboard
{
    public class DashboardViewModel : BindableBase
    {
        public ObservableCollection<Profile> Profiles { get; set; }
        public DelegateCommand ClickMeCommand { get; set; }

        public DashboardViewModel()
        {
            Profiles = new ObservableCollection<Profile>()
            {
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} },
                new Profile{ User = new User { FirstName = "Profile Works!"} }
            };

            ClickMeCommand = new DelegateCommand(OnClickMe);
        }

        private void OnClickMe()
        {

        }
    }
}
