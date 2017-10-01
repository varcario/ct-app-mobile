
//using Android.App;
//using Android.Widget;
//using Android.OS;

//namespace Ct.SubFinder.Mobile.App.Droid
//{
//    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
//    public class SplashAvtivity : Activity
//    {
//        protected override void OnCreate(Bundle bundle)
//        {
//            base.OnCreate(bundle);

//            SetContentView(Resource.Layout.Main);
//            TextView versionText = FindViewById<TextView>(Resource.Id.version_number);
//            versionText.Text = "SomeVersionNumber";

//            Intent intent = new Intent(this, typeof(MainActivity)); //Start your FormsActivity
//            StartActivity(intent);
//            Finish();
//        }
//    }
//}