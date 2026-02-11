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
using System.Diagnostics;

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

        public event EventHandler<string> FilePicked;

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
        /// On request permissions result.
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, global::Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        /// <summary>
        /// On create.
        /// </summary>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MainViewModel.AndroidHelper = this;

            // Your existing initialization code

            // Call the method to request permissions
            RequestPermissionsAsync();
        }

        /// <summary>
        /// Request permissions async.
        /// </summary>
        private async void RequestPermissionsAsync()
        {
            try
            {
                RequestPermissions(
                    new String[]{
                            Manifest.Permission.Internet,
                            Manifest.Permission.ReadExternalStorage,
                            Manifest.Permission.ReadMediaVideo}, 1004);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Get context.
        /// </summary>
        public Context GetContext()
        {
            return this;
        }
    }
}
