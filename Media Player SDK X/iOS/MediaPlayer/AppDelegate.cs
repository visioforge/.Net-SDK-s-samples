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
    /// Flag to indicate if playback is paused.
    /// </summary>
    private bool _isPaused;

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
        var rootViewController = Window?.RootViewController;
        rootViewController?.PresentViewController(alert, true, null);
    }

    /// <summary>
    /// Builds the UI into the window of the connecting scene. Called from <c>SceneDelegate.WillConnect</c>.
    /// </summary>
    /// <param name="window">The window created for the scene.</param>
    public void SetupWindow(UIWindow window)
    {
        Window = window;

        // create a UIViewController with a single UILabel
        _vc = new CustomViewController(Window, out _videoView);

        _vc.SelectButton.TouchUpInside += (sender, args) =>
        {
            _vc.OpenFilePicker();
        };

        _vc.PlayButton.TouchUpInside += async (sender, args) =>
        {
            if (_player == null)
            {
                var uri = _vc.GetURL();
                if (uri == null)
                {
                    ShowMessage("Enter a URL or select a file first.");
                    return;
                }

                _vc.SourceField.ResignFirstResponder();

                if (!await CreateEngineAsync(uri) || !await _player.PlayAsync())
                {
                    await StopAllAsync();
                    ShowMessage($"Unable to play {uri}.");
                    return;
                }

                _isPaused = false;
                _tmPosition.Start();
                _vc.PlayButton.SetTitle("PAUSE", UIControlState.Normal);
            }
            else if (!_isPaused)
            {
                await _player.PauseAsync();
                _isPaused = true;
                _vc.PlayButton.SetTitle("RESUME", UIControlState.Normal);
            }
            else
            {
                await _player.ResumeAsync();
                _isPaused = false;
                _vc.PlayButton.SetTitle("PAUSE", UIControlState.Normal);
            }
        };

        _vc.StopButton.TouchUpInside += async (sender, args) =>
        {
            await StopAllAsync();
            ResetControls();
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
        var duration = await _player.DurationAsync();
        UIApplication.SharedApplication.InvokeOnMainThread(() =>
        {
            _vc.PositionSlider.Value = (float)position.TotalSeconds;
            _vc.PositionLabel.Text = $"{position:hh\\:mm\\:ss} / {duration:hh\\:mm\\:ss}";
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
        _tmPosition.Stop();

        if (_player == null)
        {
            return;
        }

        var player = _player;
        _player = null;

        await player.StopAsync();
        await player.DisposeAsync();
    }

        /// <summary>
        /// Reset the controls to the stopped state.
        /// </summary>
    private void ResetControls()
    {
        _isPaused = false;
        _vc.PositionSlider.Value = 0;
        _vc.PositionLabel.Text = "00:00:00 / 00:00:00";
        _vc.PlayButton.SetTitle("PLAY", UIControlState.Normal);
    }

        /// <summary>
        /// Create engine async.
        /// </summary>
    private async Task<bool> CreateEngineAsync(NSUrl uri)
    {
        await StopAllAsync();

        _player = new MediaPlayerCoreX(_videoView as IVideoView);

        _player.OnError += PlayerOnError;
        _player.OnStart += PlayerOnStart;
        _player.OnStop += PlayerOnStop;

        // A file or an HLS / HTTP / RTSP URL; audio plays through the default output.
        var sourceSettings = await UniversalSourceSettings.CreateAsync(uri);
        return sourceSettings != null && await _player.OpenAsync(sourceSettings);
    }

        /// <summary>
        /// Player on stop.
        /// </summary>
    private async void PlayerOnStop(object sender, StopEventArgs e)
    {
        await StopAllAsync();

        UIApplication.SharedApplication.InvokeOnMainThread(ResetControls);
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
        // run in UI thread
        UIApplication.SharedApplication.InvokeOnMainThread(async () =>
        {
            try
            {
                if (_player == null)
                {
                    return;
                }

                var duration = (float)(await _player.DurationAsync()).TotalSeconds;
                _vc.PositionSlider.MaxValue = duration;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        });
    }
}