using System.Diagnostics;
using Photos;
using VisioForge.Core;
using VisioForge.Core.GStreamer.OpenGL;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.OpenGL;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;
using Timer = System.Timers.Timer;

namespace MediaPlayer;

/// <summary>
/// The application delegate.
/// </summary>
[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    /// <summary>
    /// The pipeline.
    /// </summary>
    private MediaBlocksPipeline _pipeline;

    /// <summary>
    /// The source.
    /// </summary>
    private UniversalSourceBlock _source;

    /// <summary>
    /// The video renderer.
    /// </summary>
    private VideoRendererBlock _videoRenderer;

    /// <summary>
    /// The audio renderer.
    /// </summary>
    private MediaBlock _audioRenderer;

    /// <summary>
    /// The video view.
    /// </summary>
    private UIView _videoView;

    /// <summary>
    /// The custom view controller.
    /// </summary>
    private CustomViewController _vc;

    /// <summary>
    /// The seeking flag.
    /// </summary>
    private volatile bool _isSeeking;

    /// <summary>
    /// The position timer.
    /// </summary>
    private System.Timers.Timer _tmPosition = new Timer(1000);

    public override UIWindow? Window { get; set; }

        /// <summary>
        /// Show message.
        /// </summary>
    private void ShowMessage(string message)
    {
        var alert = new UIAlertController
        {
            Title = "Error",
            Message = message
        };
        alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
    }

        /// <summary>
        /// Finished launching.
        /// </summary>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        _vc = new CustomViewController(Window, out _videoView);
        
        _vc.SelectButton.TouchUpInside += async (sender, args) => 
        {
            _vc.OpenFilePicker();
        };

        _vc.PlayButton.TouchUpInside += async (sender, args) =>
        {
            if (_pipeline != null)
            {
                await StopAllAsync();
                _vc.SetPlaying(false);
            }
            else
            {
                var uri = _vc.GetURL();
                if (uri == null)
                {
                    ShowMessage("Please select a file first.");
                    return;
                }

                await StopAllAsync();
                await CreateEngineAsync();
                await _pipeline.StartAsync();
                _tmPosition.Start();
                _vc.SetPlaying(true);
            }
        };
        
        _vc.PositionSlider.ValueChanged += async (sender, args) =>
        {
            if (_pipeline == null)
            {
                return;
            }

            if (_isSeeking)
            {
                return;
            }

            _isSeeking = true;
            await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(_vc.PositionSlider.Value), seekToKeyframe: true);
            _isSeeking = false;
        };

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

        Window.RootViewController = _vc;

        Window.MakeKeyAndVisible();

        VisioForgeX.InitSDK();

        _tmPosition.Elapsed += async (sender, e) => await UpdatePositionAsync();

        return true;
    }

        /// <summary>
        /// Update position async.
        /// </summary>
    private async Task UpdatePositionAsync()
    {
        if (_pipeline == null || _isSeeking)
        {
            return;
        }

        var position = await _pipeline.Position_GetAsync();
        UIApplication.SharedApplication.InvokeOnMainThread(() =>
        {
            _vc.PositionSlider.Value = (float)position.TotalSeconds;
        });
    }

        /// <summary>
        /// Request photo library permissions.
        /// </summary>
    private void RequestPhotoLibraryPermissions(Action<PHAuthorizationStatus> completionHandler)
    {
        PHPhotoLibrary.RequestAuthorization((status) => { completionHandler(status); });
    }

        /// <summary>
        /// Stop all async.
        /// </summary>
    private async Task StopAllAsync()
    {
        if (_pipeline == null || _pipeline.State == PlaybackState.Free)
        {
            return;
        }

        _tmPosition.Stop();

        if (_pipeline != null)
        {
            await _pipeline.StopAsync(force: true);
            await _pipeline.DisposeAsync();
            _pipeline = null;
        }
    }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task CreateEngineAsync()
    {
        if (_pipeline != null)
        {
            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }

        _pipeline = new MediaBlocksPipeline();

        _pipeline.OnError += pipeline_OnError;
        _pipeline.OnStart += pipeline_OnStart;
        _pipeline.OnStop += pipeline_OnStop;

        var sourceSettings = await UniversalSourceSettings.CreateAsync(_vc.GetURL());
        _source = new UniversalSourceBlock(sourceSettings);

        bool isVideo = sourceSettings.GetInfo().VideoStreams.Count > 0;
        bool isAudio = sourceSettings.GetInfo().AudioStreams.Count > 0;

        if (isVideo)
        {
            _videoRenderer = new VideoRendererBlock(_pipeline, _videoView as IVideoView) { IsSync = true };

            _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
        }

        if (isAudio)
        {
            _audioRenderer = new AudioRendererBlock() { IsSync = true };
            _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
        }
    }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
    private async void pipeline_OnStop(object sender, StopEventArgs e)
    {
        try
        {
            await StopAllAsync();

            // run in UI thread
            UIApplication.SharedApplication.InvokeOnMainThread(async () =>
            {
                _vc.PositionSlider.Value = 0;
                _vc.SetPlaying(false);
            });
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
    }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
    private void pipeline_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

        /// <summary>
        /// Handles the pipeline on start event.
        /// </summary>
    private void pipeline_OnStart(object sender, EventArgs e)
    {
        try
        {
            // run in UI thread
            UIApplication.SharedApplication.InvokeOnMainThread(async () =>
            {
                if (_pipeline == null)
                {
                    return;
                }

                var duration = (float)(await _pipeline.DurationAsync()).TotalSeconds;
                _vc.PositionSlider.MaxValue = duration;
            });
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
        }
    }
}