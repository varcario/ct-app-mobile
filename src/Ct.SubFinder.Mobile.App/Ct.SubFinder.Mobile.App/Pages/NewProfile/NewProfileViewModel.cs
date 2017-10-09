using Ct.SubFinder.Domain;
using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.NewProfile
{
    public class NewProfileViewModel : BindableBase
    {
        #region Private Properties

        private readonly AppController _appController;

        #endregion

        #region Bindable Properties 
        public string Title { get; set; }

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

        public DelegateCommand ToggleIsGeneralContractorCommand { set; get; }
        public DelegateCommand ToggleIsSubContractorCommand { set; get; }
        public DelegateCommand NextCommand { set; get; }

        #endregion

        #region Constructor

        public NewProfileViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");

            Title = "Your Profile";
            ToggleIsGeneralContractorCommand = new DelegateCommand(ToggleIsGeneralContractor);
            ToggleIsSubContractorCommand = new DelegateCommand(ToggleIsSubContractor);
            NextCommand = new DelegateCommand(OnNext);
        }

        #endregion

        #region Private Methods

        private void ToggleIsGeneralContractor()
        {

        }

        private void ToggleIsSubContractor()
        {

        }

        private  void OnNext()
        {
            _appController.State.Profile.JobTitle = _jobTitle;
            _appController.State.Profile.Company = _company;

            if (_isGeneralContractor)
            {                
                _appController.State.Profile.User = new GeneralContractor
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    PhoneNumber = _phoneNumber
                };
            }
            else
            {
                _appController.State.Profile.User = new SubContractor
                {
                    FirstName = _firstName,
                    LastName = _lastName,
                    PhoneNumber = _phoneNumber
                };
            }
            _appController.CreateProfile();
        }

        #endregion
    }
}
