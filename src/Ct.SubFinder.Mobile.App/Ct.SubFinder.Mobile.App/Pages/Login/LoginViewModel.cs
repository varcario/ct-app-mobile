using Ct.SubFinder.Core.GatewayService;
using Ct.SubFinder.Mobile.App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.Login
{
    public class LoginViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly GatewayApiServiceAgent _gatewayApi;
        private readonly AppStateObservable _appState;

        private string _emailAddress = string.Empty;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { SetProperty(ref _emailAddress, value); }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LogInCommand { set; get; }

        public LoginViewModel(INavigationService navigationService, GatewayApiServiceAgent gatewayApi, AppStateObservable appState)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
            _gatewayApi = gatewayApi ?? throw new ArgumentException("gatewayApi");
            _appState = appState ?? throw new ArgumentNullException("appState");

            LogInCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            var identity = _gatewayApi.Login(_emailAddress, _password);
            //_gatewayApi.GetNewSession();
            if(identity != null)
            {
                _appState.ChangeState(identity, (appState, i) => { appState.State.Identity = i; });
                _navigationService.NavigateAsync("app:///MainMasterDetailPage");
            }            
        }
    }
}
