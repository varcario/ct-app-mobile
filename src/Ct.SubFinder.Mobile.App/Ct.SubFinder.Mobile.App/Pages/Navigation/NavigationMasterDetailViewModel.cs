using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Ct.SubFinder.Mobile.App.Controllers;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    public class NavigationMasterDetailViewModel : BindableBase
    {
        #region Private Properties

        private readonly AppController _appController;

        #endregion

        #region Bindable Properties        
        public string EmailAddress { get; set; }
        private bool _isFlyOutOpen;
        public bool IsFlyoutOpen
        {
            get { return _isFlyOutOpen; }
            set { SetProperty(ref _isFlyOutOpen, value); }
        }       
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
            EmailAddress = _appController.State.Session.Username;

            ItemTappedCommand = new DelegateCommand<int?>(ItemTapped);
           
            MenuItems = new ObservableCollection<NavigationMasterDetailPageMenuItem>(new[]
            {
                      new NavigationMasterDetailPageMenuItem { MenuId = 0, Title = "Home", RouteAction = _appController.NavigateToDashboard },
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