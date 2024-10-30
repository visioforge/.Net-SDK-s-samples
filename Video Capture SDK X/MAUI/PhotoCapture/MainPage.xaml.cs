using System.Diagnostics;
using VisioForge.Core.UI.MAUI;

namespace PhotoCapture
{
    public partial class MainPage : ContentPage
    {
        private bool _isPreview = false;

        private VisioForge.Core.PhotoCapture.PhotoCaptureView _photoCaptureCore;

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_LayoutChanged(object? sender, EventArgs e)
        {
            Debug.WriteLine("MainPage_LayoutChanged");

#if __ANDROID__
            _photoCaptureCore?.UpdatePreview();
#endif
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            this.LayoutChanged += MainPage_LayoutChanged;

#if __ANDROID__ || __IOS__
            await RequestCameraPermissionAsync();
#endif


            MainThread.BeginInvokeOnMainThread(async () =>
            {
                _photoCaptureCore = (photoCaptureView.Handler as PhotoCaptureViewHandler).Core;
                _photoCaptureCore.Camera = _photoCaptureCore.Cameras[PhotoConfig.CurrentCamera];

                await _photoCaptureCore.StartCameraAsync();
            });
        }

        private async Task RequestCameraPermissionAsync()
        {
            var result = await Permissions.RequestAsync<Permissions.Camera>();

            // Check result from permission request. If it is allowed by the user, connect to scanner
            if (result == PermissionStatus.Granted)
            {
            }
            else
            {
                if (Permissions.ShouldShowRationale<Permissions.Camera>())
                {
                    if (await DisplayAlert(null, "You need to allow access to the Camera", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        private void ContentPage_Unloaded(object sender, EventArgs e)
        {
            _photoCaptureCore?.Dispose();
            _photoCaptureCore = null;
        }

        private async void btCamera_Clicked(object sender, EventArgs e)
        {
            if (_photoCaptureCore.Cameras.Count < 2)
            {
                return;
            }

            if (PhotoConfig.CurrentCamera == 0)
            {
                PhotoConfig.CurrentCamera = 1;
                _photoCaptureCore.Camera = _photoCaptureCore.Cameras[PhotoConfig.CurrentCamera];
            }
            else
            {
                PhotoConfig.CurrentCamera = 0;
                _photoCaptureCore.Camera = _photoCaptureCore.Cameras[PhotoConfig.CurrentCamera];
            }

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await _photoCaptureCore.StopCameraAsync();

                await _photoCaptureCore.StartCameraAsync();
            });
        }

        private async void btPhoto_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.RequestAsync<Permissions.Photos>();
            if (status == PermissionStatus.Granted)
            {
                // Access granted
                await _photoCaptureCore.SavePhotoAsync($"{Guid.NewGuid()}.jpg");
            }
            else
            {
                // Access denied
            }
        }
    }

}
