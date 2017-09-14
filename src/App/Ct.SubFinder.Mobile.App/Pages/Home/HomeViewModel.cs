using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.Home
{
    public class HomeViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;


        public ICommand LogInCommand { set; get; }
        public ICommand SignUpCommand { set; get; }

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");

            LogInCommand = new DelegateCommand(Login);
            SignUpCommand = new DelegateCommand(SignUp);
        }        

        private void Login()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/LoginContentPage");
        }

        private void SignUp()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/SignUpContentPage");
        }
    }
}
