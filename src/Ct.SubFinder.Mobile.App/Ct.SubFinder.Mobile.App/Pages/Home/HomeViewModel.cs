using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.Home
{
    public class HomeViewModel : BindableBase
    {
        private readonly AppController _appController;

        public string Title { get; set; }
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

        public DelegateCommand SignInCommand { set; get; }
        public DelegateCommand SignUpCommand { set; get; }
        public DelegateCommand ForgotPasswordCommand { set; get; }

        public HomeViewModel(AppController appController)
        {
            Title = "Welcome to Sub Finder";
            _appController = appController ?? throw new ArgumentException("appController");

            SignInCommand = new DelegateCommand(OnSignIn);
            SignUpCommand = new DelegateCommand(OnSignUp);
            ForgotPasswordCommand = new DelegateCommand(OnForgotPassword);
        }

        private void OnSignIn()
        {
            _appController.State.Session.Username = _emailAddress;
            _appController.State.Session.Secrete = _password;
            _appController.UpdateSession();
        }

        private void OnSignUp()
        {
            _appController.NavigateToNewAccount();
        }

        private void OnForgotPassword()
        {
            _appController.NavigateToForgotPassword();
        }
    }
}
