
using Ct.App.Infrastructure.Interfaces;
using Ct.SubFinder.Infrastructure.Interfaces;
using Ct.SubFinder.Mobile.App.Core;
using Ct.SubFinder.Mobile.App.State;
using Prism.Navigation;
using System;

namespace Ct.SubFinder.Mobile.App.Controllers
{
    public class AppController
    {
        private INavigationService _navigationService;
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
            _appStateObservable = appStateObservable ?? throw new ArgumentNullException("appStateObservable");
            _getSessionAgent = getSessionAgent ?? throw new ArgumentNullException("getSessionAgent");
            _postSessionAgent = postSessionAgent ?? throw new ArgumentNullException("postSessionAgent");
            _postUserAgent = postUserAgent ?? throw new ArgumentNullException("postUserAgent");
            _postProfileAgent = postProfileAgent ?? throw new ArgumentNullException("postProfileAgent");
            _putProfileAgent = putProfileAgent ?? throw new ArgumentNullException("putProfileAgent");
        }

        public IDisposable SubscribeToEvents(IObserver<AppStateEvent> subscriber)
        {
            return _appStateObservable.Subscribe(subscriber);
        }
        
        public void Start(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");

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

        public void CreateUser()
        {
            _postUserAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.UserCreated);
            NavigateToNewAccount();
        }

        public void CreateProfile()
        {
            _postProfileAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.ProfileCreated);
            NavigateToSearchArea();
        }

        public void UpdateProfile()
        {
            _putProfileAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.ProfileUpdated);
            NavigateToMain();
        }

        public void LogOut()
        {
            NavigateToHome();
        }

        public void NavigateToHome()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage");
        }
        public void NavigateToLogin()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/LoginContentPage");
        }

        public void NavigateToSignUp()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/SignUpContentPage");
        }

        public void NavigateToForgotPassword()
        {

        }

        public void NavigateToNewAccount()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/SignUpContentPage/NewProfileContentPage");
        }

        public void NavigateToSearchArea()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/SignUpContentPage/NewProfileContentPage/SearchRadiusContentPage");
        }

        public void NavigateToMain()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/NavigationContentPage");
            //_navigationService.NavigateAsync("app:///NavigationTabbedPage");
        }

        public void NavigateToDashboard()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/DashboardContentPage");
            //_navigationService.NavigateAsync("app:///NavigationTabbedPage");
        }
        public void NavigateToContacts()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/ContactsContentPage");
            //_navigationService.NavigateAsync("app:///NavigationTabbedPage");
        }
        public void NavigateToMessages()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/MessagesContentPage");
            //_navigationService.NavigateAsync("app:///NavigationTabbedPage");
        }
        public void NavigateToCamera()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/CameraContentPage");
            //_navigationService.NavigateAsync("app:///NavigationTabbedPage");

            //_navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/NavigationCarouselPage");
        }
    }
}
