using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.SignUp
{
    public class SignUpViewModel : BindableBase
    {
        private readonly AppController _appController;

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
        public ICommand NextCommand { set; get; }

        public SignUpViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");

            NextCommand = new DelegateCommand(Next);
        }

        private void Next()
        {
            _appController.State.Session.Username = _emailAddress;
            _appController.State.Session.Secrete = _password;
            _appController.CreateUser();
        }
    }
}
