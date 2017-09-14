using Android.App;
using Android.Widget;
using Android.OS;

namespace Ct.SubFinder.Mobile.Android
{
    [Activity(Label = "Ct.SubFinder.Mobile.Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

