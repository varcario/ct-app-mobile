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

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
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
            DoneCommand = new DelegateCommand(OnDone);
            MilesChangedCommand = new DelegateCommand<double?>(OnMilesChanged);
            Miles = DEFAULT_MILE_RADIUS;
        }

        private void OnDone()
        {
            _appController.State.Profile.ZipCode = _zipCode;
            _appController.State.Profile.Radius = _miles;

            _appController.UpdateProfile();
        }

        public void OnMilesChanged(double? miles)
        {
          // Miles = miles;
        }
    }
}
