using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Screen_Capture
{
    /// <summary>
    /// Foreground service required for MediaProjection on Android 10+.
    /// Must be started before calling MediaProjectionManager.GetMediaProjection().
    /// </summary>
    [Service(ForegroundServiceType = ForegroundService.TypeMediaProjection, Exported = false)]
    public class ScreenCaptureService : Service
    {
        private const string CHANNEL_ID = "screen_capture_channel";
        private const int NOTIFICATION_ID = 1001;

        /// <summary>
        /// Signaled when StartForeground() has been called and the service is in foreground state.
        /// </summary>
        public static TaskCompletionSource<bool> ForegroundStarted { get; set; }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            CreateNotificationChannel();

            var notification = BuildNotification();

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
            {
                StartForeground(NOTIFICATION_ID, notification, ForegroundService.TypeMediaProjection);
            }
            else
            {
                StartForeground(NOTIFICATION_ID, notification);
            }

            ForegroundStarted?.TrySetResult(true);
            ForegroundStarted = null;

            return StartCommandResult.Sticky;
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    CHANNEL_ID,
                    "Screen Capture",
                    NotificationImportance.Low)
                {
                    Description = "Screen capture is running"
                };

                var manager = (NotificationManager)GetSystemService(NotificationService);
                manager.CreateNotificationChannel(channel);
            }
        }

        private Notification BuildNotification()
        {
            var builder = new Notification.Builder(this, CHANNEL_ID)
                .SetContentTitle("Screen Capture")
                .SetContentText("Recording screen...")
                .SetSmallIcon(Android.Resource.Drawable.IcMediaPlay)
                .SetOngoing(true);

            return builder.Build();
        }

        public override void OnDestroy()
        {
            StopForeground(StopForegroundFlags.Remove);
            base.OnDestroy();
        }
    }
}
