using Prism.Mvvm;
using System.Collections.Generic;
using Xamarin.Forms;
using Prism.Commands;
using Ct.SubFinder.Mobile.App.Views.Camera;
using Ct.SubFinder.Mobile.App.Views.Contacts;
using Ct.SubFinder.Mobile.App.Views.Messages;
using Ct.SubFinder.Mobile.App.Views.Dashboard;
using Ct.SubFinder.Mobile.App.Views.Settings;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    public class NavigationContentViewModel : BindableBase
    {
        public DelegateCommand<string> SwitchViewCommand { get; set; }
        private int _position;
        public int Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }
        IEnumerable<View> _views;
        public IEnumerable<View> Views
        {
            get
            {
                return _views;
            }
            set
            {
                SetProperty(ref _views, value);
            }
        }

        public NavigationContentViewModel()
        {
            Position = 0;
            SwitchViewCommand = new DelegateCommand<string>(OnSwitchView);
            Views = new List<View>
            {
                new DashboardView(),
                new MessagesView(),
                new ContactsView(),                
                new CameraView(), 
                new SettingsView()
            };            
        }

        private void OnSwitchView(string id)
        {
            switch (id)
            {
                case "1":
                    Position = 0;
                    break;
                case "2":
                    Position = 1;
                    break;
                case "3":
                    Position = 2;
                    break;
                case "4":
                    Position = 3;
                    break;
                case "5":
                    Position = 4;
                    break;
            }            
        }
    }
}
