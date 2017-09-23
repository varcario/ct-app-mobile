using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ct.SubFinder.Mobile.App.Pages.Dashboard
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DashboardContentPage : ContentPage
	{
		public DashboardContentPage ()
		{
            InitializeComponent();            
		}

        public DashboardContentPage(DashboardViewModel viewModel) => BindingContext = viewModel;
    }
}