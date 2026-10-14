using System;
using System.Diagnostics;
using ObjCRuntime;
using UniformTypeIdentifiers;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.UI.Apple;

namespace SimpleMediaPlayerMBMac;

/// <summary>
/// The view controller.
/// </summary>
public partial class ViewController : NSViewController
{
    /// <summary>
    /// The media player instance.
    /// </summary>
    private MediaPlayerCoreX _player;

    /// <summary>
    /// The timer.
    /// </summary>
    private Timer _timer;

    /// <summary>
    /// Flag to indicate if the timer is update.
    /// </summary>
    private bool _timerFlag;

    /// <summary>
    /// The video view.
    /// </summary>
    private VideoView _videoView;

    /// <summary>
    /// The audio output devices listed in the speakers list.
    /// </summary>
    private AudioOutputDeviceInfo[] _audioOutputs = Array.Empty<AudioOutputDeviceInfo>();

    /// <summary>
    /// The Start button, which also pauses and resumes.
    /// </summary>
    private NSButton _startButton;

    /// <summary>
    /// Flag to indicate if playback is paused.
    /// </summary>
    private bool _isPaused;

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewController"/> class.
    /// </summary>
    /// <param name="handle">The handle.</param>
    protected ViewController(NativeHandle handle) : base(handle)
    {
        // This constructor is required if the view controller is loaded from a xib or a storyboard.
        // Do not put any initialization here, use ViewDidLoad instead.
    }

    /// <summary>
    /// Gets or sets the represented object.
    /// </summary>
    public override NSObject RepresentedObject
    {
        get => base.RepresentedObject;
        set => base.RepresentedObject = value;
        // Update the view, if already loaded.
    }

        /// <summary>
        /// View did load.
        /// </summary>
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        _videoView = new VideoView(new CGRect(0, 0, videoViewHost.Bounds.Width, videoViewHost.Bounds.Height));
        videoViewHost.AddSubview(_videoView);

        VisioForgeX.InitSDK();

        edFilename.StringValue = "https://test-streams.mux.dev/x36xhzz/x36xhzz.m3u8";
        edFilename.PlaceholderString = "File path, or an HLS / HTTP / RTSP URL";

        _timer = new Timer(OnTimer);

        InvokeOnMainThread(async () => await FillSpeakersAsync());
    }

    /// <summary>
    /// Lists the audio output devices and selects the system default one.
    /// </summary>
    private async Task FillSpeakersAsync()
    {
        _audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();

        cbSpeakers.RemoveAllItems();
        foreach (var device in _audioOutputs)
        {
            cbSpeakers.AddItem(device.Name);
        }

        var defaultIndex = Array.FindIndex(_audioOutputs, d => d.IsDefault);
        if (_audioOutputs.Length > 0)
        {
            cbSpeakers.SelectItem(defaultIndex >= 0 ? defaultIndex : 0);
        }
    }

        /// <summary>
        /// On timer.
        /// </summary>
    public async void OnTimer(object stateInfo)
    {
        if (_player == null) return;

        _timerFlag = true;

        var position = await _player.Position_GetAsync();
        var duration = await _player.DurationAsync();

        InvokeOnMainThread(() =>
        {
            slPosition.MaxValue = duration.TotalSeconds;

            if (slPosition.MaxValue >= position.TotalSeconds)
            {
                slPosition.DoubleValue = position.TotalSeconds;
            }
        });

        _timerFlag = false;
    }

        /// <summary>
        /// Show message.
        /// </summary>
    private void ShowMessage(string text)
    {
        var alert = new NSAlert
        {
            AlertStyle = NSAlertStyle.Informational,
            InformativeText = text,
            MessageText = "Message"
        };
        alert.RunModal();
    }

        /// <summary>
        /// Start async.
        /// </summary>
    private async Task StartAsync()
    {
        if (View.Window.Delegate == null)
        {
            View.Window.Delegate = new CustomWindowDelegate(this);
        }

        // A network URL (HLS, HTTP, RTSP) or a local file.
        var source = edFilename.StringValue.Trim();
        var isUrl = Uri.TryCreate(source, UriKind.Absolute, out var uri) && !uri.IsFile;
        if (!isUrl && !File.Exists(source))
        {
            ShowMessage("File not found: " + source);
            return;
        }

        var sourceSettings = isUrl
            ? await UniversalSourceSettings.CreateAsync(uri)
            : await UniversalSourceSettings.CreateAsync(source);
        if (sourceSettings == null)
        {
            ShowMessage("Unable to open " + source);
            return;
        }

        _player = new MediaPlayerCoreX(_videoView);

        // Play the audio through the speakers selected in the list.
        var speakers = (int)cbSpeakers.IndexOfSelectedItem;
        if (speakers >= 0 && speakers < _audioOutputs.Length)
        {
            _player.Audio_OutputDevice = new AudioRendererSettings(_audioOutputs[speakers]);
        }

        if (!await _player.OpenAsync(sourceSettings) || !await _player.PlayAsync())
        {
            await StopAsync();
            ShowMessage("Unable to play " + source);
            return;
        }

        _isPaused = false;
        _startButton.Title = "Pause";
        _timer.Change(0, 1000);
    }

        /// <summary>
        /// Stop async.
        /// </summary>
    public async Task StopAsync()
    {
        _timer.Change(Timeout.Infinite, Timeout.Infinite);

        _isPaused = false;
        if (_startButton != null)
        {
            _startButton.Title = "Start";
        }

        if (_player == null) return;

        await _player.StopAsync();
        await _player.DisposeAsync();

        _player = null;
    }

    /// <summary>
    /// Bt start click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void btStart_Click(NSObject sender)
    {
        _startButton = (NSButton)sender;

        InvokeOnMainThread(async () =>
        {
            if (_player == null)
            {
                await StartAsync();
            }
            else if (!_isPaused)
            {
                await _player.PauseAsync();
                _isPaused = true;
                _startButton.Title = "Resume";
            }
            else
            {
                await _player.ResumeAsync();
                _isPaused = false;
                _startButton.Title = "Pause";
            }
        });
    }

    /// <summary>
    /// Bt stop click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void btStop_Click(NSObject sender)
    {
        InvokeOnMainThread(async () => { await StopAsync(); });
    }

    /// <summary>
    /// Bt open click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void btOpen_Click(NSObject sender)
    {
        var dlg = NSOpenPanel.OpenPanel;
        dlg.CanChooseFiles = true;
        dlg.CanChooseDirectories = false;
        // Use AllowedContentTypes (macOS 12+) instead of deprecated AllowedFileTypes
        dlg.AllowedContentTypes = new[]
        {
            UTTypes.Mpeg4Movie,
            UTTypes.QuickTimeMovie,
            UTTypes.Movie,
            UTTypes.Audio,
            UTTypes.MP3,
            UTTypes.Wav
        };

        if (dlg.RunModal() == 1)
        {
            // Nab the first file
            var url = dlg.Urls[0].Path;

            if (url != null) edFilename.StringValue = url;
        }
    }

    /// <summary>
    /// Sl position changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    partial void slPositionChanged(NSObject sender)
    {
        if (sender is not NSSlider slider)
        {
            return;
        }

        var value = slider.FloatValue;

        InvokeOnMainThread(async () =>
        {
            if (!_timerFlag && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromSeconds(value));
            }
        });
    }
}

/// <summary>
/// Custom Window delegate to close the SDK.
/// </summary>
public class CustomWindowDelegate : NSWindowDelegate
{
    private readonly ViewController _viewController;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomWindowDelegate"/> class.
    /// </summary>
    /// <param name="viewController">The view controller.</param>
    public CustomWindowDelegate(ViewController viewController)
    {
        _viewController = viewController;
    }

    private bool _closing;

        /// <summary>
        /// Window should close.
        /// </summary>
    public override bool WindowShouldClose(NSObject sender)
    {
        // Teardown is async, so cancel this close, finish it, then close for real.
        if (!_closing)
        {
            _closing = true;
            _ = StopAndCloseAsync((NSWindow)sender);
        }

        return false;
    }

    private async Task StopAndCloseAsync(NSWindow window)
    {
        try
        {
            await _viewController.StopAsync();
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex);
        }
        finally
        {
            try
            {
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

            // Drop the delegate so Close() does not come back through WindowShouldClose, and
            // post it, so a teardown that completed synchronously does not close the window from
            // inside windowShouldClose:. In finally, so a failed teardown still closes.
            window.BeginInvokeOnMainThread(() =>
            {
                window.Delegate = null;
                window.Close();
            });
        }
    }
}