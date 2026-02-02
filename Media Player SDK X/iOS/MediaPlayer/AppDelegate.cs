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
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;
using Timer = System.Timers.Timer;

namespace MediaPlayer;

/// <summary>
/// The app delegate.
/// </summary>
[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    /// <summary>
    /// The media player instance.
    /// </summary>
    private MediaPlayerCoreX _player;

    /// <summary>
    /// The video view.
    /// </summary>
    private UIView _videoView;

    /// <summary>
    /// The view controller.
    /// </summary>
    private CustomViewController _vc;

    /// <summary>
    /// Flag to indicate if the seeking is in progress.
    /// </summary>
    private volatile bool _isSeeking;

    /// <summary>
    /// The position timer.
    /// </summary>
    private System.Timers.Timer _tmPosition = new Timer(1000);

    /// <summary>
    /// Gets or sets the window.
    /// </summary>
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
            if (_player != null)
            {
                await StopAllAsync();

                _vc.PlayButton.SetTitle("PLAY", UIControlState.Normal);
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

                await _player.PlayAsync();
                
                _tmPosition.Start();

                _vc.PlayButton.SetTitle("STOP", UIControlState.Normal);
            }
        };
        
        _vc.PositionSlider.ValueChanged += async (sender, args) =>
        {
            if (_player == null)
            {
                return;
            }

            if (_isSeeking)
            {
                return;
            }

            _isSeeking = true;
            await _player.Position_SetAsync(TimeSpan.FromSeconds(_vc.PositionSlider.Value), seekToKeyframe: true);
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
        if (_player == null || _isSeeking)
        {
            return;
        }

        var position = await _player.Position_GetAsync();
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
        if (_player == null || _player.State == PlaybackState.Free)
        {
            return;
        }

        _tmPosition.Stop();

        if (_player != null)
        {
            await _player.StopAsync();
            await _player.DisposeAsync();
            _player = null;
        }
    }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task CreateEngineAsync()
    {
        if (_player != null)
        {
            await _player.StopAsync();
            await _player.DisposeAsync();
        }

        _player = new MediaPlayerCoreX(_videoView as IVideoView);

        _player.OnError += PlayerOnError;
        _player.OnStart += PlayerOnStart;
        _player.OnStop += PlayerOnStop;

        var sourceSettings = await UniversalSourceSettings.CreateAsync(_vc.GetURL());
        
        _player.Video_Play = sourceSettings.GetInfo().VideoStreams.Count > 0;
        _player.Audio_Play = sourceSettings.GetInfo().AudioStreams.Count > 0;

        await _player.OpenAsync(sourceSettings);
    }

        /// <summary>
        /// Player on stop.
        /// </summary>
    private async void PlayerOnStop(object sender, StopEventArgs e)
    {
        await StopAllAsync();

        // run in UI thread
        UIApplication.SharedApplication.InvokeOnMainThread(async () =>
        {
            _vc.PositionSlider.Value = 0;
            _vc.PlayButton.SetTitle("PLAY", UIControlState.Normal);
        });
    }

        /// <summary>
        /// Player on error.
        /// </summary>
    private void PlayerOnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
    {
        Debug.WriteLine(e.Message);
    }

        /// <summary>
        /// Handles the player on start event.
        /// </summary>
    private void PlayerOnStart(object sender, EventArgs e)
    {
        try
        {
            // run in UI thread
            UIApplication.SharedApplication.InvokeOnMainThread(async () =>
            {
                if (_player == null)
                {
                    return;
                }

                var duration = (float)(await _player.DurationAsync()).TotalSeconds;
                _vc.PositionSlider.MaxValue = duration;
            });
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception);
        }
    }
}