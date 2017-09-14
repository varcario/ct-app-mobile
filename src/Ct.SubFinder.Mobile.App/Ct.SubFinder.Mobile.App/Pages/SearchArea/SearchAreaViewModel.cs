using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ct.SubFinder.Mobile.App.Pages.SearchArea
{     

    public class SearchAreaViewModel : BindableBase
    {
        private const int DEFAULT_MILE_RADIUS = 20;
        private readonly INavigationService _navigationService;

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

        public SearchAreaViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException("navigationService");
            DoneCommand = new DelegateCommand(OnDone);
            MilesChangedCommand = new DelegateCommand<double?>(OnMilesChanged);
            Miles = DEFAULT_MILE_RADIUS;
        }

        private void OnDone()
        {
            _navigationService.NavigateAsync("app:///NavigationTabbedPage");
        }

        public void OnMilesChanged(double? miles)
        {
          // Miles = miles;
        }
    }
}
