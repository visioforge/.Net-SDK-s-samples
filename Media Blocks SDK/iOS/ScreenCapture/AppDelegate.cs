using CoreAnimation;
using Photos;
using System.Diagnostics;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Apple.Sources;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.Apple;

namespace ScreenCapture
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private MediaBlocksPipeline _pipeline;

        private string _filename;

        private MediaBlock _videoRenderer;

        private MediaBlock _videoSource;

        private UILabel timeLabel;

        private NSTimer timer;

        // private MediaBlock _audioSource;

        private MediaBlock _videoEncoder;

        // private AACEncoderBlock _audioEncoder;

        private MediaBlock _sink;

        private TeeBlock _videoTee;

        private IVideoView _videoView;

        public override UIWindow? Window { get; set; }

        private async Task CreateEngineAsync(bool capture)
        {
            //capture = false;

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += _pipeline_OnError;

            // video source
            _videoSource = new ScreenSourceBlock(new IOSScreenSourceSettings());

            // create video tee
            _videoTee = new TeeBlock(2);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView);

            // connect video pads
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);

            // optional capture
            if (capture)
            {
                // video
                _videoEncoder = new H264EncoderBlock(new AppleMediaH264EncoderSettings());
                _pipeline.Connect(_videoTee.Outputs[1], _videoEncoder.Input);

                var libraryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                    "Library");
                if (!Directory.Exists(libraryPath))
                {
                    Directory.CreateDirectory(libraryPath);
                }

                var fileName = $"video_{DateTime.Now.Ticks}.mp4";
                _filename = Path.Combine(libraryPath, fileName);

                _sink = new MP4SinkBlock(new MP4SinkSettings(_filename));
                _pipeline.Connect(_videoEncoder.Output,
                    (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Video));

                //// audio
                //_audioSource = new SystemAudioSourceBlock(new IOSAudioSourceSettings());

                //_audioEncoder = new AACEncoderBlock();
                //_pipeline.Connect(_audioSource.Output, _audioEncoder.Input);
                //_pipeline.Connect(_audioEncoder.Output,
                //    (_sink as MP4SinkBlock).CreateNewInput(MediaBlockPadMediaType.Audio));
            }
        }

        private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
        {
            PHPhotoLibrary.RequestAuthorization((status) => { completionHandler(status); });
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _pipeline_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private void _pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void AddButtons(UIView parent)
        {
            // start capture
            var btStartCapture = new UIButton(new CGRect(50, 50, 150, 40))
            {
                BackgroundColor = UIColor.Gray,
                AutoresizingMask = UIViewAutoresizing.All,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center
            };
            btStartCapture.SetTitle("START", UIControlState.Normal);
            btStartCapture.TouchUpInside += async (sender, e) =>
            {
                if (_pipeline != null)
                {
                    await StopCamera();
                    btStartCapture.SetTitle("START", UIControlState.Normal);
                }
                else
                {
                    await StartCapture();
                    btStartCapture.SetTitle("STOP", UIControlState.Normal);
                }
            };

            parent!.AddSubview(btStartCapture);
        }

        private void SaveVideoToPhotoLibrary(string filePath)
        {
            PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
            {
                PHAssetCreationRequest creationRequest = PHAssetCreationRequest.CreationRequestForAsset();
                creationRequest.AddResource(PHAssetResourceType.Video, NSUrl.FromFilename(filePath), null);
            }, (success, error) =>
            {
                if (success)
                {
                    var msg = "Video was successfully saved in the photo library";
                    Debug.WriteLine(msg);

                    InvokeOnMainThread(() =>
                    {
                        Toast.Show(msg, Window.RootViewController);
                    });                    
                }
                else
                {
                    // Handle errors here
                }
            });
        }

        private async Task StopCamera()
        {
            if (_pipeline == null)
            {
                return;
            }

            // var dot = _pipeline.Debug_GetPipeline();

            await _pipeline.StopAsync();

            await DestroyEngineAsync();

            // we need to share videoto Photos library
            if (!string.IsNullOrEmpty(_filename))
            {
                Thread.Sleep(1000);

                InvokeOnMainThread(() =>
                {
                    SaveVideoToPhotoLibrary(_filename);
                    _filename = null;
                });
            }

            (_videoView as UIView).Hidden = true;
        }

        private async Task StartCapture()
        {
            await StopCamera();

            (_videoView as UIView).Hidden = false;

            await CreateEngineAsync(true);

            await _pipeline.StartAsync();
        }

        private void AddVideoView(UIView view)
        {
            var rect = new CGRect(Window!.Frame.Width / 3, Window!.Frame.Height / 3, Window!.Frame.Width / 3, Window!.Frame.Height / 3);
            _videoView = new VideoView(rect);
            (_videoView as UIView).Hidden = true;

            view!.AddSubview(_videoView as UIView);
        }

        private void AddRainbow(UIView view)
        {
            // Create a new UIView
            UIView gradientView = new UIView
            {
                Frame = new CGRect(0, 0, view.Bounds.Width, view.Bounds.Height)
            };

            // Create the gradient layer
            CAGradientLayer gradientLayer = new CAGradientLayer
            {
                Frame = gradientView.Bounds,
                Colors = new CGColor[]
                {
                    UIColor.Red.CGColor,
                    UIColor.Orange.CGColor,
                    UIColor.Yellow.CGColor,
                    UIColor.Green.CGColor,
                    UIColor.Blue.CGColor,
                    UIColor.SystemIndigo.CGColor,
                    UIColor.Magenta.CGColor
                },
                StartPoint = new CGPoint(0, 0),
                EndPoint = new CGPoint(1, 1)
            };

            // Add the gradient layer to the view
            gradientView.Layer.InsertSublayer(gradientLayer, 0);

            // Add the gradient view to the main view
            view.AddSubview(gradientView);
        }

        private void AddTimeLabel(UIView view)
        {
            // Create and configure the time label
            timeLabel = new UILabel
            {
                Frame = new CoreGraphics.CGRect(20, 100, 300, 70),
                TextColor = UIColor.Green,
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.SystemFontOfSize(36)
            };
            view.AddSubview(timeLabel);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var vc = new UIViewController();

            vc.View.BackgroundColor = UIColor.Yellow;

            AddRainbow(vc.View);

            AddButtons(vc.View);

            AddTimeLabel(vc.View);

            AddVideoView(vc.View);

            // Initialize and start the timer to update the label every second
            timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromSeconds(1), (t) =>
            {
                UpdateTime();
            });

            // Initial time update
            UpdateTime();

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

            VisioForgeX.InitSDK();

            return true;
        }

        private void UpdateTime()
        {
            // Get the current time and update the label
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
