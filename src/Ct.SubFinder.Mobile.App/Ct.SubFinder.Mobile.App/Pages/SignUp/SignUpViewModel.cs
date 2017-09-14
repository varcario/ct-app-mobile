using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.SignUp
{
    public class SignUpViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

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

        public SignUpViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");

            NextCommand = new DelegateCommand(Next);
        }

        private void Next()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/HomeContentPage/SignUpContentPage/NewAccountContentPage");
        }
    }
}
