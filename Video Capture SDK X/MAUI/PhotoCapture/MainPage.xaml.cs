using System.Diagnostics;
using VisioForge.Core.UI.MAUI;


namespace PhotoCapture
{
    public partial class MainPage : ContentPage
    {
        private bool _isPreview = false;

        private VisioForge.Core.PhotoCapture.PhotoCaptureView _photoCaptureCore;

        /// <summary>
        /// Interaction logic for the MAUI Photo Capture demo's MainPage.
        /// Demonstrates how to initialize the camera, switch cameras, and capture photos using <see cref="VisioForge.Core.PhotoCapture.PhotoCaptureView"/>.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
        }

        /// <summary>
        /// Handles the Loaded event of the MainPage.
        /// Initiates the camera permission request process on supported platforms.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            try
            {
                // Ask for permissions
#if __ANDROID__ || __MACOS__ || __MACCATALYST__ || __IOS__
                await RequestCameraPermissionAsync();
#endif

#if __IOS__ && !__MACCATALYST__
                //RequestPhotoPermission();
#endif
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading page: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the layout changes of the page.
        /// Updates the camera preview on Android to ensure correct scaling and orientation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainPage_LayoutChanged(object? sender, EventArgs e)
        {
            Debug.WriteLine("MainPage_LayoutChanged");

#if __ANDROID__
            _photoCaptureCore?.UpdatePreview();
#endif
        }

        /// <summary>
        /// Handles the Loaded event of the ContentPage.
        /// Initializes the <see cref="VisioForge.Core.PhotoCapture.PhotoCaptureView"/> core logic and starts the camera.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ContentPage_Loaded(object? sender, EventArgs e)
        {
            try
            {
                this.SizeChanged += MainPage_LayoutChanged;

#if __ANDROID__ || __IOS__ || WINDOWS
                await RequestCameraPermissionAsync();
#endif

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    _photoCaptureCore = (photoCaptureView.Handler as PhotoCaptureViewHandler).Core;
                    
                    if (_photoCaptureCore != null && _photoCaptureCore.Cameras != null && _photoCaptureCore.Cameras.Count > 0)
                    {
                        _photoCaptureCore.Camera = _photoCaptureCore.Cameras[PhotoConfig.CurrentCamera];
                        await _photoCaptureCore.StartCameraAsync();
                    }
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in content page loaded: {ex.Message}");
            }
        }

        /// <summary>
        /// Asynchronously requests camera permissions from the user.
        /// Displays an alert if permission is denied but can be requested again.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
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
                    if (await DisplayAlertAsync(null, "You need to allow access to the Camera", "OK", "Cancel"))
                        await RequestCameraPermissionAsync();
                }
            }
        }

        /// <summary>
        /// Handles the Unloaded event of the ContentPage.
        /// Disposes of the camera resources to free up system hardware.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ContentPage_Unloaded(object? sender, EventArgs e)
        {
            _photoCaptureCore?.Dispose();
            _photoCaptureCore = null;
        }

        /// <summary>
        /// Handles the Click event of the camera switch button.
        /// Toggles between available cameras (e.g., front and back) and restarts the stream.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btCamera_Clicked(object? sender, EventArgs e)
        {
            try
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

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await _photoCaptureCore.StopCameraAsync();
                    await _photoCaptureCore.StartCameraAsync();
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error switching camera: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the Click event of the take photo button.
        /// Captures a photo and saves it to the device, requesting photo library permissions if necessary.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btPhoto_Clicked(object? sender, EventArgs e)
        {
            try
            {
#if WINDOWS
                // Windows doesn't require photo permission for saving to Pictures library
                await photoCaptureView.SavePhotoAsync($"{Guid.NewGuid()}.jpg");
#else
                var status = await Permissions.RequestAsync<Permissions.Photos>();
                if (status == PermissionStatus.Granted)
                {
                    // Access granted
                    await photoCaptureView.SavePhotoAsync($"{Guid.NewGuid()}.jpg");
                }
                else
                {
                    // Access denied
                    await DisplayAlertAsync("Permission Required", "Photo permission is required to save photos.", "OK");
                }
#endif
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error taking photo: {ex.Message}");
                await DisplayAlertAsync("Error", $"Failed to take photo: {ex.Message}", "OK");
            }
        }
    }

}
