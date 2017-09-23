using Ct.SubFinder.Mobile.App.Views.Camera;
using Ct.SubFinder.Mobile.App.Views.Contacts;
using Ct.SubFinder.Mobile.App.Views.Dashboard;
using Ct.SubFinder.Mobile.App.Views.Messages;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ct.SubFinder.Mobile.App.Pages.Dashboard
{
    public class DashboardViewModel : BindableBase
    {
        public DelegateCommand<string> DashboardCommand { get; set; }
        public View _view;
        public View View
        {
            get { return _view; }
            set { SetProperty(ref _view, value); }
        }
        private Dictionary<string, View> _views { get; set; }

        public DashboardViewModel()
        {
            DashboardCommand = new DelegateCommand<string>(OnDashboard);
            _views = new Dictionary<string, View>
            {
                { "1", new CameraView() { BindingContext = new CameraViewModel() } },
                { "2", new ContactsView() { BindingContext = new ContactsViewModel() } },
                { "3", new DashboardView() { BindingContext = new Views.Dashboard.DashboardViewModel() } },
                { "4", new MessageView { BindingContext = new MessageViewModel() } },
                { "5", new Label() { Text = "Menu works!" } }
            };
            View = _views["5"];
        }

        private void OnDashboard(string viewIndex)
        {
            View = _views[viewIndex];
        }
    }
}
