using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;

namespace ScreenCaptureMB
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public const int RequestMediaProjection = 1001;

        /// <summary>
        /// Signaled when OnActivityResult delivers the MediaProjection consent result.
        /// </summary>
        public static TaskCompletionSource<(Result resultCode, Intent data)> MediaProjectionResult { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Pad content by system-bar + cutout insets so controls stay clear of Android 15+ edge-to-edge bars.
            var content = FindViewById(Android.Resource.Id.Content);
            if (content != null)
            {
                ViewCompat.SetOnApplyWindowInsetsListener(content, new SystemBarsInsetsListener());
                ViewCompat.RequestApplyInsets(content);
            }
        }

        private sealed class SystemBarsInsetsListener : Java.Lang.Object, IOnApplyWindowInsetsListener
        {
            public WindowInsetsCompat OnApplyWindowInsets(Android.Views.View v, WindowInsetsCompat insets)
            {
                var bars = insets.GetInsets(WindowInsetsCompat.Type.SystemBars() | WindowInsetsCompat.Type.DisplayCutout());
                v.SetPadding(bars.Left, bars.Top, bars.Right, bars.Bottom);
                return insets;
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == RequestMediaProjection)
            {
                MediaProjectionResult?.TrySetResult((resultCode, data));
            }
        }
    }
}
