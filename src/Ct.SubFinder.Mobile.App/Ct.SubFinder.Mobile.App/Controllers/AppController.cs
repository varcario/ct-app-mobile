using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;
using Ct.SubFinder.Mobile.App.State;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ct.SubFinder.Mobile.App.Controllers
{
    public class AppController
    {        
        private INavigation _navigation;        
        private App _app;
        private MasterDetailPage _masterDetailPage;

        private readonly Dictionary<string, object[]> _viewModelConstructorParameters;
        private readonly Dictionary<string, Page> _pages;
        private readonly IAppState<AppState, AppStateEvent> _appStateObservable;
        private readonly IAgent<AppState> _getSessionAgent;
        private readonly IAgent<AppState> _postSessionAgent;
        private readonly IAgent<AppState> _postUserAgent;
        private readonly IAgent<AppState> _postProfileAgent;
        private readonly IAgent<AppState> _putProfileAgent;

        public AppState State { get { return _appStateObservable.State; } }

        public AppController(           
            IAppState<AppState, AppStateEvent> appStateObservable,            
            IAgent<AppState> getSessionAgent,
            IAgent<AppState> postSessionAgent,
            IAgent<AppState> postUserAgent,
            IAgent<AppState> postProfileAgent,
            IAgent<AppState> putProfileAgent
            )
        {            
            _appStateObservable = appStateObservable ?? throw new ArgumentNullException(nameof(appStateObservable));
            _getSessionAgent = getSessionAgent ?? throw new ArgumentNullException(nameof(getSessionAgent));
            _postSessionAgent = postSessionAgent ?? throw new ArgumentNullException(nameof(postSessionAgent));
            _postUserAgent = postUserAgent ?? throw new ArgumentNullException(nameof(postUserAgent));
            _postProfileAgent = postProfileAgent ?? throw new ArgumentNullException(nameof(postProfileAgent));
            _putProfileAgent = putProfileAgent ?? throw new ArgumentNullException(nameof(putProfileAgent));

            _pages = new Dictionary<string, Page>();
            _viewModelConstructorParameters = new Dictionary<string, object[]>
            {
                {"appController", new object[]{this } }
            };
        }

        public IDisposable SubscribeToEvents(IObserver<AppStateEvent> subscriber)
        {
            return _appStateObservable.Subscribe(subscriber);
        }
        
        public void Start(App app)
        {
            _app = app;
            _getSessionAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.SessionCreated);            
               
            NavigateToHome();
        }

        public void Sleep()
        {

        }

        public void Resume()
        {

        }

        public void UpdateSession()
        {
            _postSessionAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.SessionUpdated);
            NavigateToMain();
        }

        public void CreateNewAccount()
        {
            _postProfileAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.ProfileCreated);
            NavigateToMain();
        }

        public void LogOut()
        {
            _pages.Clear();
            NavigateToHome();
        }

        public async void NavigateToHome()
        {
            var navPage = GetNavigationPage<Pages.Home.HomeContentPage, Pages.Home.HomeViewModel>(_viewModelConstructorParameters["appController"]);
            _navigation = navPage.Navigation;
            await _navigation.PopToRootAsync();
            _app.MainPage = navPage;            
        }

        public async void NavigateToNewAccount()
        {            
            var page = GetContentPage<Pages.NewAccount.NewAccountContentPage, Pages.NewAccount.NewAccountViewModel>(_viewModelConstructorParameters["appController"]);
            await _navigation.PushAsync(page);
        }

        public async void NavigateToSignUp()
        {
            var page = GetContentPage<Pages.SignUp.SignUpContentPage, Pages.SignUp.SignUpViewModel>(_viewModelConstructorParameters["appController"]);
            await _navigation.PushAsync(page);
        }

        public async void NavigateToNewProfile()
        {
            var page = GetContentPage<Pages.NewProfile.NewProfileContentPage, Pages.NewProfile.NewProfileViewModel>(_viewModelConstructorParameters["appController"]);
            await _navigation.PushAsync(page);
        }

        public async void NavigateToSearchArea()
        {
            var page = GetContentPage<Pages.SearchRadius.SearchRadiusContentPage, Pages.SearchRadius.SearchRadiusViewModel>(_viewModelConstructorParameters["appController"]);
            await _navigation.PushAsync(page);
        }

        public async void NavigateToSkills()
        {
            var page = GetContentPage<Pages.Skills.SkillsContentPage, Pages.Skills.SkillsViewModel>(_viewModelConstructorParameters["appController"]);
            await _navigation.PushAsync(page);
        }

        public async void NavigateToForgotPassword()
        {
            var page = GetContentPage<Pages.ForgotPassword.ForgotPasswordContentPage, Pages.ForgotPassword.ForgotPasswordViewModel>();
            await _navigation.PushAsync(page);
        }

        public void NavigateToMain()
        {
            var navPage = GetNavigationMasterDetailPage<Pages.Navigation.NavigationContentPage, Pages.Navigation.NavigationContentViewModel>();
            _navigation = navPage.Detail.Navigation;
            _app.MainPage = navPage;
            _masterDetailPage = navPage;
        }

        public void NavigateToDashboard()
        {
            _masterDetailPage.Detail = GetNavigationPage<Pages.Navigation.NavigationContentPage, Pages.Navigation.NavigationContentViewModel>();
            _navigation = _masterDetailPage.Detail.Navigation;
        }
        public void NavigateToContacts()
        {
            _masterDetailPage.Detail = GetNavigationPage<Pages.Contacts.ContactsContentPage, Pages.Contacts.ContactsViewModel>();
            _navigation = _masterDetailPage.Detail.Navigation;
        }
        public void NavigateToMessages()
        {
            _masterDetailPage.Detail = GetNavigationPage<Pages.Messages.MessagesContentPage, Pages.Messages.MessagesViewModel>();
            _navigation = _masterDetailPage.Detail.Navigation;
        }
        public void NavigateToCamera()
        {
            _masterDetailPage.Detail = GetNavigationPage<Pages.Camera.CameraContentPage, Pages.Camera.CameraContentPage>();
            _navigation = _masterDetailPage.Detail.Navigation;
        }

        private ContentPage GetContentPage<P, VM>(params object[] viewModelConstructorParameters) where P: Page where VM: class
        {
            ContentPage page = null;
            var pageKey = $"cp-{typeof(P).ToString()}";
            if (_pages.ContainsKey(pageKey))
            {
                page = _pages[pageKey] as ContentPage;
            }
            else
            {
                page = Activator.CreateInstance<P>() as ContentPage;
                try
                {
                    page.BindingContext = Activator.CreateInstance(typeof(VM), viewModelConstructorParameters);
                }catch(Exception ex)
                {

                }
                _pages.Add(pageKey, page);
            }
            return page;
        }

        private NavigationPage GetNavigationPage<P, VM>(params object[] viewModelConstructorParameters) where P: Page where VM: class
        {
            NavigationPage page = null;
            var pageKey = $"np-{typeof(P).ToString()}";
            if (_pages.ContainsKey(pageKey))
            {
                page = _pages[pageKey] as NavigationPage;
            }
            else
            {                
                try
                {
                    page = new NavigationPage(Activator.CreateInstance(typeof(P)) as Page)
                    {
                        BindingContext = Activator.CreateInstance(typeof(VM), viewModelConstructorParameters)
                    };                    
                }
                catch (Exception ex)
                {

                }
                _pages.Add(pageKey, page);
            }
            return page;
        }

        private MasterDetailPage GetNavigationMasterDetailPage<P, VM>(params object[] viewModelConstructorParameters) where P : Page where VM : class
        {
            MasterDetailPage page = null;
            var pageKey = $"mdp-{typeof(P).ToString()}";
            if (_pages.ContainsKey(pageKey))
            {
                page = _pages[pageKey] as MasterDetailPage;
            }
            else
            {
                try
                {
                    page = new Pages.Navigation.NavigationMasterDetailPage()
                    {
                        BindingContext = new Pages.Navigation.NavigationMasterDetailViewModel(this),
                        Detail = GetNavigationPage<P, VM>(viewModelConstructorParameters)
                    } as MasterDetailPage;
                }
                catch (Exception ex)
                {

                }
                _pages.Add(pageKey, page);
            }
            return page;
        }
    }
}
