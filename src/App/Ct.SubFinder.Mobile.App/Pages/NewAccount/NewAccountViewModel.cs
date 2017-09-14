using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.NewAccount
{
    public class NewAccountViewModel : BindableBase
    {
        #region Private Properties

        private readonly INavigationService _navigationService;

        #endregion

        #region Bindable Properties 
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _jobTitle;
        public string JobTitle
        {
            get { return _jobTitle; }
            set { SetProperty(ref _jobTitle, value); }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private bool _isGeneralContractor;
        private bool IsGeneralContractor
        {
            get { return _isGeneralContractor; }
            set { SetProperty(ref _isGeneralContractor, value); }
        }

        private bool _isSubContractor;
        private bool IsSubContractor
        {
            get { return _isSubContractor; }
            set { SetProperty(ref _isSubContractor, value); }
        }
        #endregion

        #region Bindable Commands

        public ICommand ToggleIsGeneralContractorCommand { set; get; }
        public ICommand ToggleIsSubContractorCommand { set; get; }
        public ICommand NextCommand { set; get; }

        #endregion

        #region Constructor

        public NewAccountViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");

            ToggleIsGeneralContractorCommand = new DelegateCommand(ToggleIsGeneralContractor);
            ToggleIsSubContractorCommand = new DelegateCommand(ToggleIsSubContractor);
            NextCommand = new DelegateCommand(Next);
        }

        #endregion

        #region Private Methods

        private void ToggleIsGeneralContractor()
        {

        }

        private void ToggleIsSubContractor()
        {

        }

        private  void Next()
        {
            _navigationService.NavigateAsync("app:///NavigationPage/MainContentPage/SignUpContentPage/NewAccountContentPage/SearchAreaContentPage");
        }

        #endregion
    }
}
