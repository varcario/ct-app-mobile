using Ct.SubFinder.Domain;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ct.SubFinder.Mobile.App.Views.Dashboard
{
    public class DashboardViewModel : BindableBase
    {
        private List<Profile> _dummyDataSource;
        public ObservableCollection<Profile> Profiles { get; set; }
        public DelegateCommand<string> SearchCommand { get; set; }

        public DashboardViewModel()
        {
            Profiles = new ObservableCollection<Profile>();
            _dummyDataSource = new List<Profile>()
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
            Profiles.Clear();
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {                
                for(int i = 0; i < searchTerm.Length & i < _dummyDataSource.Count; i++)
                {
                    Profiles.Add(_dummyDataSource[i]);
                }              
            }
        }
    }
}
