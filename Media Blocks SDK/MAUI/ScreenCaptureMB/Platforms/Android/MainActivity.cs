using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

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
