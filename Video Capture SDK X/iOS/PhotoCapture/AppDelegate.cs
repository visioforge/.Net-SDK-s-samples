using Photos;
using System.Diagnostics;
using VisioForge.Core.Helpers;
using VisioForge.Core.PhotoCapture;
using VisioForge.Core.UI.Apple;

namespace PhotoCapture
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private int _cameraIndex = 1;

        private PhotoCaptureView _photoView;

        public override UIWindow? Window
        {
            get;
            set;
        }

        private void CreatePhotoView(UIView view)
        {
            var rect = new CGRect(0, 0, Window!.Frame.Width, Window!.Frame.Height);
            _photoView = new PhotoCaptureView(rect);
            _photoView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            view!.AddSubview(_photoView);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // create a UIViewController with a single UILabel
            var vc = new UIViewController();

            CreatePhotoView(vc.View);

            AddButtons(vc.View);

            RequestPhotoLibraryPermissions((status) =>
            {
                if (status == PHAuthorizationStatus.Authorized)
                {
                    // The app has permission to access the photo library
                    // Proceed with saving the video or other tasks
                }
                else
                {
                    // Handle the case where permission is denied
                }
            });

            Window.RootViewController = vc;

            Window.MakeKeyAndVisible();

            InvokeOnMainThread(async () =>
            {
                _photoView.Camera = _photoView.Cameras[0];
                await _photoView.StartCameraAsync();
            });

            return true;
        }

        private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
        {
            PHPhotoLibrary.RequestAuthorization((status) => { completionHandler(status); });
        }

        private void AddButtons(UIView parent)
        {
            // select camera
            var btSelectCamera = new UIButton(new CGRect(20, 20, 300, 70))
            {
                BackgroundColor = UIColor.Gray,
                AutoresizingMask = UIViewAutoresizing.All,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center
            };
            btSelectCamera.SetTitle("SWITCH CAMERA", UIControlState.Normal);
            btSelectCamera.TouchUpInside += async (sender, e) =>
            {
                if (_photoView.Cameras.Count < 2)
                {
                    return;
                }

                _cameraIndex = _cameraIndex == 0 ? 1 : 0;
                _photoView.Camera = _photoView.Cameras[_cameraIndex];
                await _photoView.StartCameraAsync();
            };

            parent!.AddSubview(btSelectCamera);

            // save photo
            var btSavePhoto = new UIButton(new CGRect(340, 20, 300, 70))
            {
                BackgroundColor = UIColor.Gray,
                AutoresizingMask = UIViewAutoresizing.All,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center
            };
            btSavePhoto.SetTitle("SAVE PHOTO", UIControlState.Normal);
            btSavePhoto.TouchUpInside += async (sender, e) =>
            {
                var image = await _photoView.TakePhotoAsync();

                if (image != null)
                {
                    var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library");
                    if (!Directory.Exists(libraryPath))
                    {
                        Directory.CreateDirectory(libraryPath);
                    }

                    var filename = $"image_{DateTime.Now.Ticks}.jpg";
                    filename = Path.Combine(libraryPath, filename);

                    SkiaHelper.SaveToFile(image, filename);

                    InvokeOnMainThread(() =>
                    {
                        SavePhotoToLibrary(filename);
                    });
                }
            };

            parent!.AddSubview(btSavePhoto);
        }

        private void SavePhotoToLibrary(string filePath)
        {
            PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
            {
                PHAssetCreationRequest creationRequest = PHAssetCreationRequest.CreationRequestForAsset();
                creationRequest.AddResource(PHAssetResourceType.Photo, NSUrl.FromFilename(filePath), null);
            }, (success, error) =>
            {
                if (success)
                {
                    Debug.WriteLine("Photo was successfully saved in the library");
                }
                else
                {
                    // Handle errors here
                }
            });
        }
    }
}
