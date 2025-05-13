using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using Simple_Player_MVVM.ViewModels;
using SimplePlayerMVVM;
using System;

namespace Simple_Player_MVVM.Android
{
    [Activity(
        Label = "Simple_Player_MVVM.Android",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>, IAndroidHelper
    {
        public static MainActivity Instance { get; private set; }

        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseReactiveUI();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, global::Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MainViewModel.AndroidHelper = this;

            // Your existing initialization code

            // Call the method to request permissions
            RequestPermissionsAsync();
        }

        private async void RequestPermissionsAsync()
        {
            RequestPermissions(
                new String[]{
                        Manifest.Permission.Internet,
                        Manifest.Permission.ReadExternalStorage,
                        Manifest.Permission.ReadMediaVideo}, 1004);
        }

        public Context GetContext()
        {
            return this;
        }
    }
}
