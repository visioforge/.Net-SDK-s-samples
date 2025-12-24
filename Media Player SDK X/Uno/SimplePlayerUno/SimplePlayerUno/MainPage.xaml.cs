using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Sources;

#if __IOS__ && !__MACCATALYST__
using Foundation;
#endif

namespace SimplePlayerUno;

public sealed partial class MainPage : Page
{
    private MediaPlayerCoreX? _player;
    private string? _filename;

    private readonly DispatcherTimer _tmPosition;
    private readonly DispatcherQueue _dispatcherQueue;

    private volatile bool _isTimerUpdate;
    private bool _sdkInitialized;

    public MainPage()
    {
        InitializeComponent();

        _dispatcherQueue = DispatcherQueue.GetForCurrentThread();

        _tmPosition = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(500)
        };
        _tmPosition.Tick += TmPosition_Tick;

        Loaded += MainPage_Loaded;
        Unloaded += MainPage_Unloaded;
    }

    private async void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (_sdkInitialized)
        {
            return;
        }

        try
        {
            await VisioForgeX.InitSDKAsync();

            _sdkInitialized = true;

            _player = new MediaPlayerCoreX(videoView);

            _player.OnError += Player_OnError;
            _player.OnStart += Player_OnStart;
            _player.OnStop += Player_OnStop;

#if !__IOS__ || __MACCATALYST__
            var audioOutputs = await _player.Audio_OutputDevicesAsync();
            if (audioOutputs.Length > 0)
            {
                _player.Audio_OutputDevice = new AudioRendererSettings(audioOutputs[0]);
            }
#endif
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"SDK init failed: {ex.Message}");
        }
    }

    private async void MainPage_Unloaded(object sender, RoutedEventArgs e)
    {
        _tmPosition.Stop();

        if (_player != null)
        {
            _player.OnError -= Player_OnError;
            _player.OnStart -= Player_OnStart;
            _player.OnStop -= Player_OnStop;

            await _player.StopAsync();
            await _player.DisposeAsync();
            _player = null;
        }

        if (_sdkInitialized)
        {
            VisioForgeX.DestroySDK();
            _sdkInitialized = false;
        }
    }

    private void Player_OnError(object? sender, ErrorsEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"Player error: {e.Message}");
    }

    private void Player_OnStart(object? sender, EventArgs e)
    {
        // Duration will be set in the position timer tick when available
    }

    private async void Player_OnStop(object? sender, StopEventArgs e)
    {
        try
        {
            await StopAllAsync();

            _dispatcherQueue.TryEnqueue(() =>
            {
                playStopIcon.Glyph = "\uE768"; // Play icon
                slSeeking.Value = 0;
                lbDuration.Text = "00:00:00";
                lbPosition.Text = "00:00:00";
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in OnStop: {ex.Message}");
        }
    }

    private async Task StopAllAsync()
    {
        _tmPosition.Stop();

        if (_player != null)
        {
            await _player.StopAsync();
        }
    }

    private void TmPosition_Tick(object? sender, object e)
    {
        if (_player == null)
        {
            return;
        }

        _ = UpdatePositionAsync();
    }

    private async Task UpdatePositionAsync()
    {
        if (_player == null)
        {
            return;
        }

        try
        {
            var pos = await _player.Position_GetAsync();
            var progress = (int)pos.TotalMilliseconds;

            _dispatcherQueue.TryEnqueue(() =>
            {
                if (_player == null)
                {
                    return;
                }

                _isTimerUpdate = true;

                var duration = _player.Duration();
                if (duration.TotalMilliseconds > 0 && slSeeking.Maximum != duration.TotalMilliseconds)
                {
                    slSeeking.Maximum = duration.TotalMilliseconds;
                }

                if (progress > slSeeking.Maximum)
                {
                    slSeeking.Value = slSeeking.Maximum;
                }
                else
                {
                    slSeeking.Value = progress;
                }

                lbPosition.Text = pos.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);
                lbDuration.Text = duration.ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture);

                _isTimerUpdate = false;
            });
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in timer update: {ex.Message}");
        }
    }

    private async void slSeeking_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        try
        {
            if (!_isTimerUpdate && _player != null)
            {
                await _player.Position_SetAsync(TimeSpan.FromMilliseconds(e.NewValue));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error setting position: {ex.Message}");
        }
    }

    private void slVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (_player != null)
        {
            _player.Audio_OutputDevice_Volume = e.NewValue / 100.0;
        }
    }

    private async void btPlayStop_Click(object sender, RoutedEventArgs e)
    {
        if (_player == null)
        {
            return;
        }

        switch (_player.State)
        {
            case PlaybackState.Play:
            case PlaybackState.Pause:
                // Stop playback
                await StopAllAsync();
                playStopIcon.Glyph = "\uE768"; // Play icon
                break;

            case PlaybackState.Free:
                // Get media URL from text box
                if (string.IsNullOrEmpty(_filename) && !string.IsNullOrWhiteSpace(txtMediaUrl.Text))
                {
                    _filename = txtMediaUrl.Text.Trim();
                }

                if (string.IsNullOrEmpty(_filename))
                {
                    return;
                }

                var sourceSettings = await CreateSourceSettingsAsync(_filename);
                await _player.OpenAsync(sourceSettings);
                await _player.PlayAsync();

                _tmPosition.Start();
                playStopIcon.Glyph = "\uE71A"; // Stop icon
                break;
        }
    }

    private static async Task<UniversalSourceSettings> CreateSourceSettingsAsync(string input)
    {
#if __IOS__ && !__MACCATALYST__
        NSUrl ResolveNsUrl(string value)
        {
            if (Uri.TryCreate(value, UriKind.Absolute, out var httpUri) && !httpUri.IsFile)
            {
                return NSUrl.FromString(value);
            }

            var path = value;
            if (!Path.IsPathRooted(path))
            {
                path = Path.GetFullPath(path);
            }

            return NSUrl.CreateFileUrl(path, null);
        }

        var nsUrl = ResolveNsUrl(input);
        return await UniversalSourceSettings.CreateAsync(nsUrl);
#else
        if (Uri.TryCreate(input, UriKind.Absolute, out var uri) && !uri.IsFile)
        {
            return await UniversalSourceSettings.CreateAsync(uri);
        }

        var filePath = input;
        if (!Path.IsPathRooted(filePath))
        {
            filePath = Path.GetFullPath(filePath);
        }

        return await UniversalSourceSettings.CreateAsync(new Uri(filePath));
#endif
    }

}
