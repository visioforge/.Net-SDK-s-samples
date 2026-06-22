using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Audio_Playback_Capture
{
    /// <summary>
    /// Foreground service required for MediaProjection on Android 10+.
    /// Must be started before calling MediaProjectionManager.GetMediaProjection().
    /// </summary>
    [Service(ForegroundServiceType = ForegroundService.TypeMediaProjection, Exported = false)]
    public class AudioCaptureService : Service
    {
        private const string CHANNEL_ID = "audio_capture_channel";
        private const int NOTIFICATION_ID = 1101;

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

            var tcs = ForegroundStarted;
            ForegroundStarted = null;

            try
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
                {
                    StartForeground(NOTIFICATION_ID, notification, ForegroundService.TypeMediaProjection);
                }
                else
                {
                    StartForeground(NOTIFICATION_ID, notification);
                }

                tcs?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                // Unblock the activity immediately instead of waiting out its timeout.
                Android.Util.Log.Error("AudioCaptureService", ex.ToString());
                tcs?.TrySetResult(false);
            }

            return StartCommandResult.Sticky;
        }

        private void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    CHANNEL_ID,
                    "Audio Playback Capture",
                    NotificationImportance.Low)
                {
                    Description = "Audio playback capture is running"
                };

                var manager = (NotificationManager)GetSystemService(NotificationService);
                manager.CreateNotificationChannel(channel);
            }
        }

        private Notification BuildNotification()
        {
            var builder = new Notification.Builder(this, CHANNEL_ID)
                .SetContentTitle("Audio Playback Capture")
                .SetContentText("Recording app audio...")
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
