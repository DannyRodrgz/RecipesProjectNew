using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Forms.Platforms.Android.Core;
using Xamarin.Essentials;
using Firebase;

namespace Recipes.Droid
{
    [Activity(Label = "Recipes",
        Icon = "@drawable/icon", 
        Theme = "@style/MyTheme", 
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<App, FormsApp>, App, FormsApp>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            FirebaseApp.InitializeApp(Application.Context);
            base.OnCreate(savedInstanceState);
        }

        public override void OnBackPressed()
        {
            var id = Preferences.Get("UserId", "default");
            if (!id.Equals("159") || id.Equals("159")) return;

            base.OnBackPressed();
        }
    }
}