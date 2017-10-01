using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.Home
{
    public class HomeViewModel : BindableBase
    {
        private readonly AppController _appController;

        public DelegateCommand LogInCommand { set; get; }
        public DelegateCommand SignUpCommand { set; get; }

        public HomeViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");

            LogInCommand = new DelegateCommand(Login);
            SignUpCommand = new DelegateCommand(SignUp);
        }

        private void Login()
        {
            _appController.NavigateToLogin();
        }

        private void SignUp()
        {
            _appController.NavigateToSignUp();
        }
    }
}
