using Prism.Navigation;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Ct.SubFinder.Mobile.App.Controllers;
using Xamarin.Forms;
using Ct.SubFinder.Mobile.App.Pages.Dashboard;
using Ct.SubFinder.Mobile.App.Pages.Contacts;
using Ct.SubFinder.Mobile.App.Pages.Messages;
using Ct.SubFinder.Mobile.App.Pages.Camera;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    public class NavigationMasterDetailViewModel : BindableBase
    {
        #region Private Properties

        private readonly AppController _appController;

        #endregion

        #region Bindable Properties        

        private bool _isFlyOutOpen;
        public bool IsFlyoutOpen
        {
            get { return _isFlyOutOpen; }
            set { SetProperty(ref _isFlyOutOpen, value); }
        }
        public string MenuTitle { get; private set; }

        public ObservableCollection<NavigationMasterDetailPageMenuItem> MenuItems { get; set; }
        public DelegateCommand<int?> ItemTappedCommand { get; private set; }

        private object _masterDetailPage;
        public object MasterDetailPage
        {
            get { return _masterDetailPage; }
            set { SetProperty(ref _masterDetailPage, value); }
        }
        
        #endregion

        #region Constructor

        public NavigationMasterDetailViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");

            ItemTappedCommand = new DelegateCommand<int?>(ItemTapped);
            MenuTitle = "Sub Finder";

            MenuItems = new ObservableCollection<NavigationMasterDetailPageMenuItem>(new[]
            {
                      new NavigationMasterDetailPageMenuItem { MenuId = 0, Title = "Dashboard", RouteAction = _appController.NavigateToDashboard },
                      new NavigationMasterDetailPageMenuItem { MenuId = 1, Title = "Contacts", RouteAction = _appController.NavigateToContacts },
                      new NavigationMasterDetailPageMenuItem { MenuId = 2, Title = "Messages", RouteAction = _appController.NavigateToMessages },
                      new NavigationMasterDetailPageMenuItem { MenuId = 3, Title = "Camera", RouteAction = _appController.NavigateToCamera },
                      new NavigationMasterDetailPageMenuItem { MenuId = 4, Title = "Log out", RouteAction = _appController.LogOut },
              });
        }

        #endregion

        #region Private Members

        private void ItemTapped(int? menuId)
        {
            IsFlyoutOpen = false;
           
            var menuItem = MenuItems.FirstOrDefault(m => m.MenuId == menuId);           
            if (menuItem?.RouteAction is Action)
            {
                menuItem.RouteAction();
            }            
        }

        #endregion
    }
}