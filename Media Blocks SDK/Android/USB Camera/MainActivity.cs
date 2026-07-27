using Android;
using Android.OS;
using Android.Util;
using VisioForge.Core;
using VisioForge.Core.GStreamer.Android.UVC;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources.AndroidUVC;
using Activity = Android.App.Activity;

namespace USB_Camera
{
    /// <summary>
    /// Shows a live preview from a USB (UVC) camera attached over OTG.
    /// </summary>
    [Activity(Label = "@string/app_name", MainLauncher = true, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@android:style/Theme.NoTitleBar.Fullscreen")]
    public class MainActivity : Activity
    {
        private const string TAG = "USBCamera";

        private const int CameraPermissionRequest = 1004;

        private VisioForge.Core.UI.Android.VideoViewGL _videoView;

        private TextView _tbStatus;

        private MediaBlocksPipeline _pipeline;

        private AndroidUVCSourceBlock _videoSource;

        private VideoRendererBlock _videoRenderer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            // Android refuses to hand a USB video device to an app without this permission,
            // even though the Camera2 API is not used at all.
            RequestPermissions(new[] { Manifest.Permission.Camera }, CameraPermissionRequest);

            _videoView = FindViewById<VisioForge.Core.UI.Android.VideoViewGL>(Resource.Id.videoView);
            _tbStatus = FindViewById<TextView>(Resource.Id.tbStatus);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode != CameraPermissionRequest)
            {
                return;
            }

            if (AndroidUVCDevices.HasCameraPermission())
            {
                _ = StartPreviewAsync();
            }
            else
            {
                SetStatus("Camera permission is required to use a USB camera.");
            }
        }

        private void SetStatus(string text)
        {
            Log.Info(TAG, text);
            RunOnUiThread(() => _tbStatus.Text = text);
        }

        private async Task StartPreviewAsync()
        {
            try
            {
                await StartPreviewCoreAsync();
            }
            catch (Exception ex)
            {
                // Nothing awaits this method, so an escaping exception would be lost.
                SetStatus(ex.Message);
            }
        }

        private async Task StartPreviewCoreAsync()
        {
            var cameras = AndroidUVCDevices.FindCameras();
            if (cameras.Count == 0)
            {
                SetStatus("No USB camera found. Connect one over OTG.");
                return;
            }

            var camera = cameras[0];
            SetStatus($"Found {camera.ProductName}. Requesting access...");

            if (!await AndroidUVCDevices.RequestPermissionAsync(camera))
            {
                SetStatus("Access to the USB camera was denied.");
                return;
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            // Unplugging the camera ends the stream, which arrives here - without it the preview
            // would just freeze on the last frame with the status still reading "Streaming".
            _pipeline.OnStop += Pipeline_OnStop;

            var settings = new AndroidUVCSourceSettings
            {
                Device = camera,
                Width = 1280,
                Height = 720,
                FrameRate = new VideoFrameRate(30),
            };

            _videoSource = new AndroidUVCSourceBlock(settings);
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView) { IsSync = false };

            _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);

            if (!await _pipeline.StartAsync())
            {
                SetStatus("Unable to start. Another app may be using the camera - check the log.");

                // The camera was already claimed while building, so hand it back before returning.
                await DisposePipelineAsync();
                return;
            }

            SetStatus($"Streaming from {camera.ProductName}");
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            SetStatus(e.Message);
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            SetStatus("The camera was disconnected.");
        }

        private async Task DisposePipelineAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _pipeline.OnError -= Pipeline_OnError;
            _pipeline.OnStop -= Pipeline_OnStop;

            await _pipeline.DisposeAsync();
            _pipeline = null;
        }

        protected override async void OnDestroy()
        {
            // FIRST, before anything that can await. Android checks that the base implementation ran
            // by the time this method returns, and an await returns to the runtime early - putting
            // this at the end throws SuperNotCalledException and kills the process.
            base.OnDestroy();

            try
            {
                await DisposePipelineAsync();
            }
            catch (Exception ex)
            {
                // A teardown failure must not stop DestroySDK from running.
                Log.Error(TAG, ex.ToString());
            }

            VisioForgeX.DestroySDK();
        }
    }
}
