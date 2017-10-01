using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.Login
{
    public class LoginViewModel : BindableBase
    {        
        private readonly AppController _appController;

        #region Bindable Properties

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
        public ICommand LogInCommand { set; get; }

        #endregion

        #region Constructor

        public LoginViewModel(AppController appController)
        {            
            _appController = appController ?? throw new ArgumentException("appController");
            Title = "Log in";
            LogInCommand = new DelegateCommand(Login);
        }

        #endregion

        private void Login()
        {
            _appController.State.Session.Username = _emailAddress;
            _appController.State.Session.Secrete = _password;
            _appController.UpdateSession();
        }
    }

}
