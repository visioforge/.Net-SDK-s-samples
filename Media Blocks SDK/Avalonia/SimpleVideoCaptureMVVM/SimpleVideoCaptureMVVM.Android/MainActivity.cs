using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using SimpleVideoCaptureMVVM.ViewModels;
using System;

namespace SimpleVideoCaptureMVVM.Android
{
    [Activity(
        Label = "SimpleVideoCaptureMVVMMB.Android",
        Theme = "@style/MyTheme.NoActionBar",
        Icon = "@drawable/icon",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    /// <summary>
    /// Represents the main activity.
    /// </summary>
    public class MainActivity : AvaloniaMainActivity<App>
    {
        /// <summary>
        /// Customize app builder.
        /// </summary>
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseReactiveUI();
        }

        /// <summary>
        /// On create.
        /// </summary>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //this.RequestedOrientation = global::Android.Content.PM.ScreenOrientation.Portrait;

            base.OnCreate(savedInstanceState);

            //MainViewModel.AndroidHelper = this;

            // Your existing initialization code

            // Call the method to request permissions
            RequestPermissions();
        }

        /// <summary>
        /// On request permissions result.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, global::Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            MainViewModel.Instance.InitAndLoad();
        }

        /// <summary>
        /// Request permissions.
        /// </summary>
        private void RequestPermissions()
        {
            RequestPermissions(
                new String[]{
                        Manifest.Permission.Internet,
                        Manifest.Permission.ReadExternalStorage,
                        Manifest.Permission.RecordAudio,
                        Manifest.Permission.Camera,
                        Manifest.Permission.ReadMediaVideo}, 1004);
        }
    }
}
