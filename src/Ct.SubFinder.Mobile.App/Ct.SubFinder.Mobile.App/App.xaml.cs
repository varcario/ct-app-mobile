using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using Ct.SubFinder.Mobile.App.Core;
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Agents.Session;
using Ct.SubFinder.Mobile.App.Services;
using Ct.SubFinder.Mobile.App.Controllers;
using Ct.SubFinder.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.State;
using Ct.SubFinder.Mobile.App.Agents.Profile;
using Ct.SubFinder.Mobile.App.Agents.User;
using System.Net.Http;

namespace Ct.SubFinder.Mobile.App
{
    public partial class App : PrismApplication
    {
        private AppController _appController;
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();            
        }

        protected override void RegisterTypes()
        {
            Container.RegisterInstance(new HttpClient());

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<TabbedPage>();
            Container.RegisterTypeForNavigation<CarouselPage>();

            Container.RegisterTypeForNavigation<Pages.Camera.CameraContentPage, Pages.Camera.CameraViewModel>();
            Container.RegisterTypeForNavigation<Pages.Contacts.ContactsContentPage, Pages.Contacts.ContactsViewModel>();
            Container.RegisterTypeForNavigation<Pages.Home.HomeContentPage, Pages.Home.HomeViewModel>();
            Container.RegisterTypeForNavigation<Pages.Login.LoginContentPage, Pages.Login.LoginViewModel>();            
            Container.RegisterTypeForNavigation<Pages.Messages.MessagesContentPage, Pages.Messages.MessagesContentPage>();
            Container.RegisterTypeForNavigation<Pages.Dashboard.DashboardContentPage, Pages.Dashboard.DashboardViewModel>();

            Container.RegisterTypeForNavigation<Pages.SignUp.SignUpContentPage, Pages.SignUp.SignUpViewModel>();
            Container.RegisterTypeForNavigation<Pages.NewProfile.NewProfileContentPage, Pages.NewProfile.NewProfileViewModel>();
            Container.RegisterTypeForNavigation<Pages.SearchRadius.SearchRadiusContentPage, Pages.SearchRadius.SearchRadiusViewModel>();

            Container.RegisterTypeForNavigation<Pages.Navigation.NavigationTabbedPage, Pages.Navigation.NavigationTabbedViewModel>();
            Container.RegisterTypeForNavigation<Pages.Navigation.NavigationMasterDetailPage, Pages.Navigation.NavigationMasterDetailViewModel>();

            Container.RegisterType<IAppState<AppState, AppStateEvent>, AppStateObservable>(
                new InjectionConstructor(
                    Container.Resolve<AppState>()
                ));
            Container.RegisterType<IPerformanceTrace, PerformanceTrace>();
            
            Container.RegisterType<IAgent<AppState>, GetSessionAgent>("GetSessionAgent");
            Container.RegisterType<IAgent<AppState>, PostSessionAgent>("PostSessionAgent");
            Container.RegisterType<IAgent<AppState>, PostProfileAgent>("PostUserAgent");
            Container.RegisterType<IAgent<AppState>, PostUserAgent>("PostProfileAgent");
            Container.RegisterType<IAgent<AppState>, PutProfileAgent>("PutProfileAgent");            

            Container.RegisterType<AppController>(
                new InjectionConstructor(
                    Container.Resolve<IAppState<AppState, AppStateEvent>>(),
                    Container.Resolve<IAgent<AppState>>("GetSessionAgent"),
                    Container.Resolve<IAgent<AppState>>("PostSessionAgent"),
                    Container.Resolve<IAgent<AppState>>("PostUserAgent"),
                    Container.Resolve<IAgent<AppState>>("PostProfileAgent"),
                    Container.Resolve<IAgent<AppState>>("PutProfileAgent")
                ));

            Container.RegisterInstance(Container.Resolve<IAppState<AppState, AppStateEvent>>());
            Container.RegisterInstance(Container.Resolve<IPerformanceTrace>());
            Container.RegisterInstance(Container.Resolve<IAgent<AppState>>("GetSessionAgent"));
            Container.RegisterInstance(Container.Resolve<IAgent<AppState>>("PostSessionAgent"));
            Container.RegisterInstance(Container.Resolve<IAgent<AppState>>("PostUserAgent"));
            Container.RegisterInstance(Container.Resolve<IAgent<AppState>>("PostProfileAgent"));
            Container.RegisterInstance(Container.Resolve<IAgent<AppState>>("PutProfileAgent"));
            Container.RegisterInstance(Container.Resolve<AppController>());
           

            _appController = Container.Resolve<AppController>();
        }
        protected override void OnStart()
        {            
            // Handle when your app starts
            _appController.Start(NavigationService);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            _appController.Sleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            _appController.Resume();
        }
    }
}
