﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public NavigationMasterDetailPageMaster()
        {
            InitializeComponent();         
        }
    }
}