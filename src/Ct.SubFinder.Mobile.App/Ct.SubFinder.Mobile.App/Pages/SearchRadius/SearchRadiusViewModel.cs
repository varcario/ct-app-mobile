using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace Ct.SubFinder.Mobile.App.Pages.SearchRadius
{

    public class SearchRadiusViewModel : BindableBase
    {
        private readonly AppController _appController;
        private const int DEFAULT_MILE_RADIUS = 20;

        public string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }
        private string _radiusLabel;
        public string RadiusLabel
        {
            get { return _radiusLabel; }
            set { SetProperty(ref _radiusLabel, value); }
        }

        private double _miles;
        public double Miles
        {
            get { return _miles; }
            set { SetProperty(ref _miles, value); }
        }

        public ICommand DoneCommand { get; set;  }
        public DelegateCommand<double?> MilesChangedCommand { get; }

        public SearchRadiusViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException("appController");
            Title = "Your Profile";
            if(_appController.State.Account.AccountType == Domain.AccountType.GeneralContractor)
            {
                RadiusLabel = "Miles willing to search for sub contractors";
            }
            else
            {
                RadiusLabel = "Miles willing to travel";
            }
            DoneCommand = new DelegateCommand(OnDone);
            MilesChangedCommand = new DelegateCommand<double?>(OnMilesChanged);
            Miles = DEFAULT_MILE_RADIUS;
        }

        private void OnDone()
        {
            _appController.State.User.Profile.ZipCode = _zipCode;
            _appController.State.User.Profile.Radius = _miles;

            if (_appController.State.Account.AccountType == Domain.AccountType.GeneralContractor)
            {
                _appController.CreateNewAccount();
            }
            else
            {
                _appController.NavigateToSkills();
            }
        }

        public void OnMilesChanged(double? miles)
        {
          // Miles = miles;
        }
    }
}
