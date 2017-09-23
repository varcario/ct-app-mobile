using Ct.SubFinder.Core.GatewayService;
using Ct.SubFinder.Infrastructure.ApiServiceAgent;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Ct.SubFinder.Mobile.App.Core;

namespace Ct.SubFinder.Mobile.App
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }


        protected override void OnInitialized()
        {
            InitializeComponent();
            //NavigationService.NavigateAsync("MainPage");            
            NavigationService.NavigateAsync("app:///NavigationPage/HomeContentPage");
        }

        protected override void RegisterTypes()
        {                   
            Container.RegisterTypeForNavigation<ContentPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<TabbedPage>();
            Container.RegisterTypeForNavigation<CarouselPage>();

            Container.RegisterTypeForNavigation<Pages.Camera.CameraContentPage, Pages.Camera.CameraViewModel>();
            Container.RegisterTypeForNavigation<Pages.Contacts.ContactsContentPage, Pages.Contacts.ContactsViewModel>();
            Container.RegisterTypeForNavigation<Pages.Home.HomeContentPage, Pages.Home.HomeViewModel>();
            Container.RegisterTypeForNavigation<Pages.Login.LoginContentPage, Pages.Login.LoginViewModel>();
            Container.RegisterTypeForNavigation<Pages.Main.MainMasterDetailPage, Pages.Main.MainViewModel>();
            Container.RegisterTypeForNavigation<Pages.Messages.MessagesContentPage, Pages.Messages.MessagesContentPage>();
            Container.RegisterTypeForNavigation<Pages.Dashboard.DashboardContentPage, Pages.Dashboard.DashboardViewModel>();


            Container.RegisterTypeForNavigation<Pages.SignUp.SignUpContentPage, Pages.SignUp.SignUpViewModel>();
            Container.RegisterTypeForNavigation<Pages.NewAccount.NewAccountContentPage, Pages.NewAccount.NewAccountViewModel>();
            Container.RegisterTypeForNavigation<Pages.SearchArea.SearchAreaContentPage, Pages.SearchArea.SearchAreaViewModel>();

            Container.RegisterTypeForNavigation<Pages.ProfileSelection.ProfileSelectionContentPage, Pages.ProfileSelection.ProfileSelectionViewModel>();                        
            Container.RegisterTypeForNavigation<Pages.Navigation.NavigationTabbedPage, Pages.Navigation.NavigationViewModel>();            

            Container.RegisterType<IApiServiceAgent<ApiRequest, ApiResponse>, ApiServiceAgent>();
            Container.RegisterInstance(new AppStateObservable());
            
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            var gatewayApiService = Container.Resolve<GatewayApiServiceAgent>();
            //var session = gatewayApiService.GetNewSession();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
