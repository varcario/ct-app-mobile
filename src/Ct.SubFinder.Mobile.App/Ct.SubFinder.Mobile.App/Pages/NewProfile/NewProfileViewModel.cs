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
        public string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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

        public DelegateCommand NextCommand { set; get; }

        #endregion

        #region Constructor

        public NewProfileViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");

            Title = "Your Profile";
            NextCommand = new DelegateCommand(OnNext);
        }

        #endregion

        #region Private Methods

        private  void OnNext()
        {
            _appController.State.User.Profile.FirstName = _firstName;
            _appController.State.User.Profile.LastName = _firstName;
            _appController.State.User.Profile.PhoneNumber = _phoneNumber;
            _appController.State.User.Profile.JobTitle = _jobTitle;
            _appController.State.User.Profile.Company = _company;
            
            _appController.NavigateToSearchArea();
        }

        #endregion
    }
}
