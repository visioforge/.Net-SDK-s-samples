using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace Multi_Audio_Streams_Demo_X
{
    /// <summary>
    /// Multi Audio Streams Demo — plays a main video file (audio optional) and mixes in any
    /// number of user-provided additional audio streams via MediaPlayerCoreX.Audio_AdditionalStreams_Add.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;

        // Additional audio streams registered by the user before Play. All are mixed together
        // (not queued sequentially) by the AudioMixerBlock inside MediaPlayerCoreX.
        // Each entry is a path or URL; resolved to UniversalSourceSettings inside buttonPlay_Click.
        private readonly List<string> _pendingAudioStreams = new List<string>();

        // Audio output device list, populated once on window load.
        private List<AudioOutputDeviceInfo> _audioDevices = new List<AudioOutputDeviceInfo>();

        // Seek timer pulls position/duration at 500 ms. Drag flag suppresses auto-updates
        // while the user moves the thumb so it doesn't fight live playback.
        private System.Timers.Timer _seekTimer;
        private volatile bool _seekDragging;
        private volatile bool _seekTimerWriting;

        // Guard flag for the two-phase Window_Closing pattern. Because DisposeAsync is async, we
        // cancel the first close, await disposal, then re-invoke Close() which fires Window_Closing
        // again; the flag lets the second invocation fall through without cancelling.
        private bool _isClosing;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                lblStatus.Text = "Initializing SDK...";
                await VisioForgeX.InitSDKAsync();

                Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

                // Enumerate audio output devices on the DirectSound API. DisposeAsync invokes
                // IAsyncDisposable (StopAsync + CloseAsync) instead of the sync Dispose path
                // (CloseX), which can deadlock or drop cleanup on GStreamer pads that are still
                // finalizing. try/finally is used instead of `await using` for net472 compatibility
                // (C# 7.3 in legacy multi-targets does not support asynchronous using).
                var probe = new MediaPlayerCoreX();
                try
                {
                    var devices = await probe.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                    _audioDevices = devices?.ToList() ?? new List<AudioOutputDeviceInfo>();
                }
                finally
                {
                    await probe.DisposeAsync();
                }

                cbAudioOutput.Items.Clear();
                foreach (var dev in _audioDevices)
                {
                    cbAudioOutput.Items.Add(dev.Name);
                }

                if (cbAudioOutput.Items.Count > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }

                lblStatus.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "SDK init error: " + ex.Message;
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void buttonBrowseVideo_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Video files|*.mp4;*.mkv;*.webm;*.avi;*.mov;*.ts;*.m4v;*.mpg;*.mpeg|All files|*.*",
            };

            if (dlg.ShowDialog() == true)
            {
                textBoxVideoFile.Text = dlg.FileName;
            }
        }

        private void buttonBrowseAudio_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Audio files|*.mp3;*.m4a;*.aac;*.wav;*.ogg;*.opus;*.flac;*.wma|All files|*.*",
            };

            if (dlg.ShowDialog() == true)
            {
                textBoxAudioFile.Text = dlg.FileName;
            }
        }

        private void buttonAudioAdd_Click(object sender, RoutedEventArgs e)
        {
            string entry = textBoxAudioFile.Text?.Trim();
            if (string.IsNullOrEmpty(entry))
            {
                return;
            }

            // Silently skip duplicates — adding the same audio path twice would waste pipeline
            // resources and double the gain of that track in the AudioMixerBlock. URIs are
            // case-sensitive (signed query strings, RTSP auth tokens) while local file paths on
            // NTFS are case-insensitive; pick the comparer accordingly to avoid rejecting two
            // genuinely different signed URLs that happen to share a case-insensitive match.
            var comparer = IsSupportedUri(entry) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            if (_pendingAudioStreams.Any(existing => string.Equals(existing, entry, comparer)))
            {
                lblStatus.Text = "Duplicate audio stream ignored: " + entry;
                return;
            }

            _pendingAudioStreams.Add(entry);
            listAudioStreams.Items.Add(entry);
            textBoxAudioFile.Text = string.Empty;
        }

        private void buttonAudioRemove_Click(object sender, RoutedEventArgs e)
        {
            int idx = listAudioStreams.SelectedIndex;
            if (idx < 0 || idx >= _pendingAudioStreams.Count)
            {
                return;
            }

            _pendingAudioStreams.RemoveAt(idx);
            listAudioStreams.Items.RemoveAt(idx);
        }

        private void buttonAudioClear_Click(object sender, RoutedEventArgs e)
        {
            _pendingAudioStreams.Clear();
            listAudioStreams.Items.Clear();
        }

        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            // A late error signal firing during window teardown (between Window_Closing and
            // DestroyPlayerAsync's OnError unsubscribe) would post into a shutting-down
            // dispatcher; WPF usually discards the action, but logs the warning. Skip upfront.
            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                return;
            }

            Dispatcher.BeginInvoke(new Action(() => lblStatus.Text = e.Message));
        }

        private async Task DestroyPlayerAsync()
        {
            StopSeekTimer();

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                await _player.DisposeAsync();
                _player = null;
            }
        }

        // Re-entrancy guard shared by Play and Stop. Without this, a rapid double-click on Play
        // kicks off two concurrent DestroyPlayerAsync / new MediaPlayerCoreX sequences on the
        // same VideoView — the second call double-disposes or leaks the first instance.
        private bool _playOrStopInFlight;

        private async void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (_playOrStopInFlight)
            {
                return;
            }

            _playOrStopInFlight = true;
            buttonPlay.IsEnabled = false;
            buttonStop.IsEnabled = false;
            try
            {
                string videoPath = textBoxVideoFile.Text?.Trim();
                if (string.IsNullOrEmpty(videoPath) || (!IsSupportedUri(videoPath) && !File.Exists(videoPath)))
                {
                    lblStatus.Text = "Video file not found: " + videoPath;
                    return;
                }

                // Validate additional streams up-front so we don't start a half-broken pipeline.
                foreach (var path in _pendingAudioStreams)
                {
                    if (!IsSupportedUri(path) && !File.Exists(path))
                    {
                        lblStatus.Text = "Additional audio not found: " + path;
                        return;
                    }
                }

                await DestroyPlayerAsync();

                _player = new MediaPlayerCoreX(VideoView1);
                _player.OnError += Player_OnError;
                _player.Audio_Play = true;

                // Pick the selected output device (fallback to first available).
                AudioOutputDeviceInfo selectedDevice = null;
                if (cbAudioOutput.SelectedIndex >= 0 && cbAudioOutput.SelectedIndex < _audioDevices.Count)
                {
                    selectedDevice = _audioDevices[cbAudioOutput.SelectedIndex];
                }

                if (selectedDevice == null)
                {
                    var devices = await _player.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                    selectedDevice = devices?.FirstOrDefault();
                }

                if (selectedDevice != null)
                {
                    _player.Audio_OutputDevice = new AudioRendererSettings(selectedDevice);
                }
                else
                {
                    lblStatus.Text = "No audio output device available.";
                    return;
                }

                // Register the main source and all queued additional audio streams.
                var mainUri = ToUri(videoPath);
                if (mainUri == null)
                {
                    lblStatus.Text = "Invalid video path/URL: " + videoPath;
                    return;
                }

                var mainSource = await UniversalSourceSettings.CreateAsync(mainUri);
                _player.Audio_AdditionalStreams_Clear();

                // Per-stream error handling: an individual stream failure (TOCTOU: file deleted
                // between validation and CreateAsync, unsupported codec, transient network error)
                // shouldn't abort the whole Play. Collect failures and surface them in lblStatus
                // after the loop so the user can see which streams were skipped.
                var skipped = new List<string>();
                foreach (var path in _pendingAudioStreams)
                {
                    try
                    {
                        var extraUri = ToUri(path);
                        if (extraUri == null)
                        {
                            skipped.Add(path + " (invalid path/URL)");
                            continue;
                        }

                        // renderVideo:false forces the extra to expose only its audio pad,
                        // matching what Audio_AdditionalStreams_AddAsync does internally — without
                        // this an unconnected video pad upstream stalls uridecodebin.
                        var extra = await UniversalSourceSettings.CreateAsync(
                            extraUri,
                            renderVideo: false,
                            renderAudio: true,
                            renderSubtitle: false);
                        _player.Audio_AdditionalStreams_Add(extra);
                    }
                    catch (Exception ex)
                    {
                        skipped.Add($"{path} ({ex.Message})");
                    }
                }

                // Set volume BEFORE OpenAsync — MediaPlayerCoreX caches the value and applies it
                // to the AudioRendererBlock at pipeline build time, so there's no 100%-volume
                // burst between renderer creation and a post-Play assignment.
                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;

                await _player.OpenAsync(mainSource);
                await _player.PlayAsync();

                StartSeekTimer();

                // Playback is now live — editing the additional-audio list has no effect on the
                // running pipeline (the SDK actually throws InvalidOperationException on mutation),
                // so disable all list-editing controls including Browse / TextBox until Stop.
                SetAudioListEditable(false);

                if (skipped.Count > 0)
                {
                    lblStatus.Text = $"Playing on '{selectedDevice.Name}' with {_pendingAudioStreams.Count - skipped.Count} extras; skipped: {string.Join("; ", skipped)}";
                }
                else
                {
                    lblStatus.Text = _pendingAudioStreams.Count > 0
                        ? $"Playing on '{selectedDevice.Name}'. {_pendingAudioStreams.Count} additional audio stream(s) mixed in."
                        : $"Playing on '{selectedDevice.Name}'.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                // Play failed — keep audio editing available so the user can fix the list.
                SetAudioListEditable(true);
            }
            finally
            {
                _playOrStopInFlight = false;
                buttonPlay.IsEnabled = true;
                buttonStop.IsEnabled = true;
            }
        }

        private async void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            if (_playOrStopInFlight)
            {
                return;
            }

            _playOrStopInFlight = true;
            buttonPlay.IsEnabled = false;
            buttonStop.IsEnabled = false;
            try
            {
                StopSeekTimer();

                if (_player != null)
                {
                    await _player.StopAsync();
                }

                sliderSeek.Value = 0;
                lblTime.Text = "00:00:00 / 00:00:00";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
            finally
            {
                // Pipeline is stopped — re-enable audio list editing regardless of outcome.
                SetAudioListEditable(true);
                _playOrStopInFlight = false;
                buttonPlay.IsEnabled = true;
                buttonStop.IsEnabled = true;
            }
        }

        /// <summary>
        /// Toggle every control that mutates the additional-audio list. The list is captured
        /// once, during Play (Audio_AdditionalStreams_Add before OpenAsync); attempting to
        /// mutate it during playback actually throws InvalidOperationException on the SDK side,
        /// so we must disable Browse and the path TextBox too — leaving them live would let a
        /// user type a path that goes nowhere.
        /// </summary>
        private void SetAudioListEditable(bool editable)
        {
            buttonAudioAdd.IsEnabled = editable;
            buttonAudioRemove.IsEnabled = editable;
            buttonAudioClear.IsEnabled = editable;
            buttonBrowseAudio.IsEnabled = editable;
            textBoxAudioFile.IsEnabled = editable;
        }

        private static Uri ToUri(string pathOrUrl)
        {
            if (string.IsNullOrEmpty(pathOrUrl))
            {
                return null;
            }

            if (IsSupportedUri(pathOrUrl) && Uri.TryCreate(pathOrUrl, UriKind.Absolute, out var u))
            {
                return u;
            }

            try
            {
                var full = Path.GetFullPath(pathOrUrl);
                return Uri.TryCreate(full, UriKind.Absolute, out var fileUri) ? fileUri : null;
            }
            catch
            {
                return null;
            }
        }

        private static bool IsSupportedUri(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            if (!Uri.TryCreate(s, UriKind.Absolute, out var u))
            {
                return false;
            }

            return u.IsFile
                || u.Scheme == Uri.UriSchemeHttp
                || u.Scheme == Uri.UriSchemeHttps
                || u.Scheme == "rtsp"
                || u.Scheme == "rtmp"
                || u.Scheme == "file";
        }

        private void StartSeekTimer()
        {
            StopSeekTimer();
            _seekTimer = new System.Timers.Timer(500);
            _seekTimer.Elapsed += SeekTimer_Elapsed;
            _seekTimer.Start();
        }

        private void StopSeekTimer()
        {
            if (_seekTimer != null)
            {
                _seekTimer.Stop();
                _seekTimer.Elapsed -= SeekTimer_Elapsed;
                _seekTimer.Dispose();
                _seekTimer = null;
            }
        }

        private async void SeekTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Capture the current player reference locally so a concurrent DestroyPlayerAsync
            // nulling _player on the UI thread during the awaits below can't null-deref us or
            // cause ObjectDisposedException on the second call.
            var p = _player;
            if (p == null || _seekDragging)
            {
                return;
            }

            try
            {
                var position = await p.Position_GetAsync();
                var duration = await p.DurationAsync();

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (_seekDragging)
                    {
                        return;
                    }

                    double total = duration.TotalSeconds;
                    double pos = position.TotalSeconds;

                    _seekTimerWriting = true;
                    try
                    {
                        if (total > 0 && Math.Abs(sliderSeek.Maximum - total) > 0.5)
                        {
                            sliderSeek.Maximum = total;
                        }

                        if (!double.IsNaN(pos) && pos >= sliderSeek.Minimum && pos <= sliderSeek.Maximum)
                        {
                            sliderSeek.Value = pos;
                        }
                    }
                    finally
                    {
                        _seekTimerWriting = false;
                    }

                    lblTime.Text = $"{FormatTime(position)} / {FormatTime(duration)}";
                }));
            }
            catch (ObjectDisposedException)
            {
                // _player was disposed by DestroyPlayerAsync after our local capture but
                // before the SDK finished the in-flight call. Safe to ignore.
            }
            catch
            {
                // Swallow: the timer may race with Stop/Dispose.
            }
        }

        private static string FormatTime(TimeSpan t)
        {
            if (t < TimeSpan.Zero)
            {
                t = TimeSpan.Zero;
            }

            return t.ToString("hh\\:mm\\:ss");
        }

        private void sliderSeek_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Only respond to the left button — PreviewMouseDown fires for every button, so a
            // middle/right-click on the track would otherwise flip _seekDragging=true and
            // suppress the seek timer without any release ever clearing it.
            if (e.ChangedButton != System.Windows.Input.MouseButton.Left)
            {
                return;
            }

            // Don't arm the flag if there's nothing to seek yet (pre-Play click on an empty
            // slider). Without this, a click on the disabled slider before Play would leave
            // _seekDragging=true permanently because no MouseUp path clears it while the slider
            // has no meaningful range.
            if (_player == null || sliderSeek.Maximum <= 0)
            {
                return;
            }

            _seekDragging = true;
        }

        private void sliderSeek_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // WPF occasionally swallows MouseUp if focus is stolen (Alt-Tab, a popup); clearing
            // here guarantees _seekDragging never sticks true and silently blocks the seek timer
            // for the rest of the window's life.
            _seekDragging = false;
        }

        private async void sliderSeek_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                double value = sliderSeek.Value;
                if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
                {
                    return;
                }

                if (_player != null)
                {
                    await _player.Position_SetAsync(TimeSpan.FromSeconds(value));
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
            finally
            {
                _seekDragging = false;
            }
        }

        private void sliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderSeek.Maximum <= 0)
            {
                return;
            }

            if (_seekTimerWriting)
            {
                return;
            }

            if (_seekDragging)
            {
                double newValue = e.NewValue;
                double max = sliderSeek.Maximum;
                if (double.IsNaN(newValue) || double.IsInfinity(newValue) || newValue < 0 || double.IsNaN(max) || double.IsInfinity(max) || max < 0)
                {
                    return;
                }

                lblTime.Text = $"{FormatTime(TimeSpan.FromSeconds(newValue))} / {FormatTime(TimeSpan.FromSeconds(max))}";
            }
        }

        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lblVolume != null)
            {
                lblVolume.Text = ((int)e.NewValue).ToString() + "%";
            }

            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume = e.NewValue / 100.0;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // async void + Close() race: the WPF Close() path doesn't await us, so the player
            // could outlive the window. Cancel the initial close, dispose asynchronously, then
            // re-invoke Close() on the dispatcher. The second invocation sees _isClosing=true
            // and falls through so the window actually closes.
            if (_isClosing)
            {
                return;
            }

            e.Cancel = true;
            _isClosing = true;

            try
            {
                await DestroyPlayerAsync();
            }
            catch (Exception ex)
            {
                // Never block shutdown on a dispose failure — the user wants out. DisposeAsync
                // may resume on a thread-pool continuation; writing lblStatus.Text from a
                // non-UI thread throws InvalidOperationException, and the user can't see the
                // label anyway while the window is closing. Log-and-drop is the right tradeoff.
                System.Diagnostics.Debug.WriteLine($"Dispose error: {ex.Message}");
            }

            // DestroySDK must run even when _player was never created (e.g. user closes before
            // Play), otherwise InitSDKAsync state leaks across window lifetimes.
            try
            {
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DestroySDK error: {ex.Message}");
            }

            Dispatcher.BeginInvoke(new Action(() => Close()));
        }
    }
}
