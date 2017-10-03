using Prism.Mvvm;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;
using Prism.Commands;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    public class NavigationViewModel : BindableBase
    {
        public DelegateCommand<string> SwitchViewCommand { get; set; }
        IEnumerable<HomeViewModel> _pages;
        public IEnumerable<HomeViewModel> Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                SetProperty(ref _pages, value);
                CurrentPage = Pages.FirstOrDefault();
            }
        }

        HomeViewModel _currentPage;
        public HomeViewModel CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                SetProperty(ref _currentPage, value);
            }
        }

        public NavigationViewModel()
        {
            Pages = new List<HomeViewModel>() {
                new HomeViewModel { Title = "1", Background = Color.White, ImageSource = "ic_home_black_24dp.png" },
                new HomeViewModel { Title = "2", Background = Color.Red, ImageSource = "ic_message_black_24dp.png" },
                new HomeViewModel { Title = "3", Background = Color.Blue, ImageSource = "ic_contacts_black_24dp.png" },
                new HomeViewModel { Title = "4", Background = Color.Yellow, ImageSource = "ic_camera_enhance_black_24dp.png" },
                new HomeViewModel { Title = "5", Background = Color.Yellow, ImageSource = "ic_settings_black_24dp.png" },
            };

            CurrentPage = Pages.First();

            SwitchViewCommand = new DelegateCommand<string>(OnSwitchView);
        }

        private void OnSwitchView(string id)
        {
            CurrentPage = Pages.First((v) => v.Title.Equals(id));
        }
    }

    public class HomeViewModel : BindableBase, ITabProvider
    {
        public HomeViewModel() { }

        public string Title { get; set; }
        public Color Background { get; set; }
        public string ImageSource { get; set; }
    }

    public interface ITabProvider
    {
        string ImageSource { get; set; }
    }
}
