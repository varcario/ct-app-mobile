using Prism.Navigation;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;

namespace Ct.SubFinder.Mobile.App.Pages.Main
{
    public class MainViewModel : BindableBase
    {
        #region Private Properties

        private readonly INavigationService _navigationService;

        #endregion

        #region Bindable Properties        

        private bool _isFlyOutOpen;
        public bool IsFlyoutOpen
        {
            get { return _isFlyOutOpen; }
            set { SetProperty(ref _isFlyOutOpen, value); }
        }
        public string MenuTitle { get; private set; }
   
        public ObservableCollection<MainMasterDetailPageMenuItem> MenuItems { get; set; }
        public DelegateCommand<int?> ItemTappedCommand { get; private set; }

        #endregion

        #region Constructor

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
            ItemTappedCommand = new DelegateCommand<int?>(ItemTapped);
            MenuTitle = "Sub Finder";

            MenuItems = new ObservableCollection<MainMasterDetailPageMenuItem>(new[]
            {
                    new MainMasterDetailPageMenuItem { MenuId = 0, Title = "Settings" },
                    new MainMasterDetailPageMenuItem { MenuId = 1, Title = "Page 2" },
                    new MainMasterDetailPageMenuItem { MenuId = 2, Title = "Page 3" },
                    new MainMasterDetailPageMenuItem { MenuId = 3, Title = "Page 4" },
                    new MainMasterDetailPageMenuItem { MenuId = 4, Title = "Log out", Route = "app:///NavigationPage/HomeContentPage" },
            });
        }

        #endregion

        #region Private Members

        private void ItemTapped(int? menuId)
        {
            if(menuId == null)
            {
                return;
            }

            IsFlyoutOpen = false;
            var menuItem = MenuItems.FirstOrDefault(m => m.MenuId == menuId);
            if (!string.IsNullOrWhiteSpace(menuItem.Route))
            {
                _navigationService.NavigateAsync(menuItem.Route);
            }
            

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;
            //Detail = new NavigationPage(page);

            //MasterPage.ListView.SelectedItem = null;
        }

        #endregion
    }
}
