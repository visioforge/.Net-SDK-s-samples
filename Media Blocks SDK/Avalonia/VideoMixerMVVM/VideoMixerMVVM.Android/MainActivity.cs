using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using VideoMixerMVVM.ViewModels;
using System;

namespace VideoMixerMVVM.Android
{
    [Activity(
        Label = "VideoMixerMVVM",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity<App>
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseReactiveUI();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestPermissions();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            MainViewModel.Instance?.InitAndLoad();
        }

        private void RequestPermissions()
        {
            RequestPermissions(
                new String[]{
                    Manifest.Permission.Internet,
                    Manifest.Permission.ReadExternalStorage,
                    Manifest.Permission.Camera,
                    Manifest.Permission.ReadMediaVideo}, 1004);
        }
    }
}
