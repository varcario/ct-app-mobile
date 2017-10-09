using Prism.Mvvm;
using Prism.Navigation;

namespace Ct.SubFinder.Mobile.App.Pages.ForgotPassword
{
    public class ForgotPasswordViewModel : BindableBase
    {
        public string _title;  

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ForgotPasswordViewModel()
        {
            Title = "Password Reset";
        }
    }
}
