using Android;
using Android.Content;
using Android.Content.Res;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using SkiaSharp;
using VisioForge.Core.PhotoCapture;

namespace PhotoCapture
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private PhotoCaptureView _photoCapture;

        private bool _isPreview = false;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(PhotoCapture.Resource.Layout.activity_main);

            RequestPermissions(
             new String[]{
                        Manifest.Permission.Camera,
                        Manifest.Permission.Internet,
                        Manifest.Permission.ReadExternalStorage,
                        Manifest.Permission.WriteExternalStorage
             }, 1004);

            var btSelectCamera = FindViewById<Button>(Resource.Id.btSelectCamera);
            btSelectCamera.Click += btSelectCamera_Click;

            var btCaptureFrame = FindViewById<Button>(Resource.Id.btCaptureFrame);
            btCaptureFrame.Click += btCaptureFrame_Click;

            _photoCapture = FindViewById<PhotoCaptureView>(Resource.Id.photoCaptureView);

            CheckPermissionsAndStartPreview();
        }

        protected override void OnDestroy()
        {
            _photoCapture.Dispose();

            base.OnDestroy();
        }

        private void CheckPermissionsAndStartPreview()
        {
            if (CheckSelfPermission(Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                return;
            }

            //if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
            //{
            //    return;
            //}

            //if (CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted)
            //{
            //    return;
            //}


            Task.Run(async () =>
            {
                if (_isPreview)
                {
                    return;
                }

                _isPreview = true;

                _photoCapture.Camera = _photoCapture.Cameras[PhotoConfig.CurrentCamera];
                await StartPreviewAsync();
            });
        }


        private async Task StartPreviewAsync()
        {
            await _photoCapture.StartCameraAsync();
        }

        private async void btCaptureFrame_Click(object? sender, EventArgs e)
        {
            await _photoCapture.SavePhotoAsync($"{Guid.NewGuid()}.jpg");
        }
                
        private async void btSelectCamera_Click(object? sender, EventArgs e)
        {
            if (_photoCapture.Cameras.Count < 2)
            {
                return;
            }

            await _photoCapture.StopCameraAsync();

            if (PhotoConfig.CurrentCamera == 0)
            {
                PhotoConfig.CurrentCamera = 1;
                _photoCapture.Camera = _photoCapture.Cameras[PhotoConfig.CurrentCamera];
            }
            else
            {
                PhotoConfig.CurrentCamera = 0;
                _photoCapture.Camera = _photoCapture.Cameras[PhotoConfig.CurrentCamera];
            }

            await _photoCapture.StartCameraAsync();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            CheckPermissionsAndStartPreview();
        }
    }
}