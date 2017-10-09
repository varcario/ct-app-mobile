using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.SignUp
{
    public class SignUpViewModel : BindableBase
    {
        private readonly AppController _appController;

        public string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
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
        public DelegateCommand NextCommand { set; get; }

        public SignUpViewModel(AppController appController)
        {
            Title = "New Account";
            _appController = appController ?? throw new ArgumentException(nameof(appController));
            NextCommand = new DelegateCommand(OnNext);
        }

        private void OnNext()
        {
            _appController.State.Session.Username = _emailAddress;
            _appController.State.Session.Secrete = _password;
            _appController.NavigateToNewProfile();
        }
    }
}
