using Prism.Navigation;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ct.SubFinder.Mobile.App.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        private readonly INavigationService _navigationService;

        public MainMasterDetailPage()
        {
            //_navigationService = navigationService ?? throw new ArgumentNullException("navigationService");

            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMasterDetailPageMenuItem;
            if (item == null)
                return;

            if (item.Title == "Log out")
            {
               // _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage");
            }
            else
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                page.Title = item.Title;

                Detail = new NavigationPage(page);
                IsPresented = false;

                MasterPage.ListView.SelectedItem = null;
            }
        }
    }
}