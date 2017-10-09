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

        public void CreateNewAccount()
        {
            _postProfileAgent.SendRequest(_appStateObservable.State);
            _appStateObservable.NotifySubscribers(AppStateEvent.ProfileCreated);
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

        public void NavigateToNewAccount()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/NewAccountContentPage");
        }

        public void NavigateToSignUp()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/NewAccountContentPage/SignUpContentPage");
        }

        public void NavigateToNewProfile()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/NewAccountContentPage/SignUpContentPage/NewProfileContentPage");
        }

        public void NavigateToSearchArea()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/NewAccountContentPage/SignUpContentPage/NewProfileContentPage/SearchRadiusContentPage");
        }

        public void NavigateToSkills()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/NewAccountContentPage/SignUpContentPage/NewProfileContentPage/SearchRadiusContentPage/SkillsContentPage");
        }

        public void NavigateToForgotPassword()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/ForgotPasswordContentPage?title=Forgot Password"); 
        }

        public void NavigateToMain()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/NavigationContentPage");
        }

        public void NavigateToDashboard()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/DashboardContentPage");
        }
        public void NavigateToContacts()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/ContactsContentPage");
        }
        public void NavigateToMessages()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/MessagesContentPage");
        }
        public void NavigateToCamera()
        {
            _navigationService.NavigateAsync("app:///NavigationMasterDetailPage/NavigationPage/CameraContentPage");
        }
    }
}
