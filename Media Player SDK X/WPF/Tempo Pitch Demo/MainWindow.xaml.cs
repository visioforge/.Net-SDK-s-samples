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
using VisioForge.Core.Types.X.AudioEffects;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace Tempo_Pitch_Demo_X
{
    /// <summary>
    /// Tempo / Pitch demo for MediaPlayerCoreX. Plays a main video file (which may or may not
    /// have its own audio) plus any number of user-supplied additional audio streams. Tempo and
    /// Pitch are applied via a single GStreamer PitchAudioEffect (soundtouch 'pitch' element)
    /// attached downstream of the AudioMixerBlock, so they affect the combined audio — every
    /// stream at once, no matter how many there are.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayerCoreX _player;

        // Single PitchAudioEffect owns both Tempo and Pitch. The GStreamer 'pitch' element exposes
        // independent `tempo` and `pitch` properties, so we can vary speed without pitch shift and
        // vice versa — all on the mixer output.
        private const string PITCH_EFFECT_NAME = "pitch_effect";

        private PitchAudioEffect _pitchEffect;

        // Tempo / pitch permille: 500 = 0.5x, 1000 = normal, 2000 = 2.0x.
        private const int DEFAULT_TEMPO = 1000;
        private const int MIN_TEMPO = 500;
        private const int MAX_TEMPO = 2000;
        private const int TEMPO_STEP = 50;

        private const int DEFAULT_PITCH = 1000;
        private const int MIN_PITCH = 500;
        private const int MAX_PITCH = 2000;
        private const int PITCH_STEP = 50;

        private int _currentPitch = DEFAULT_PITCH;
        private int _currentTempo = DEFAULT_TEMPO;

        // Additional audio streams registered by the user before Play. All are mixed together
        // (not queued sequentially) by the AudioMixerBlock inside MediaPlayerCoreX.
        private readonly List<string> _pendingAudioStreams = new List<string>();

        // Audio output device list, populated once on window load.
        private List<AudioOutputDeviceInfo> _audioDevices = new List<AudioOutputDeviceInfo>();

        // Seek timer + drag guards.
        private System.Timers.Timer _seekTimer;
        private volatile bool _seekDragging;
        private volatile bool _seekTimerWriting;

        // Guard flag for the two-phase Window_Closing pattern. Because DisposeAsync is async, we
        // cancel the first close, await disposal, then re-invoke Close() which fires Window_Closing
        // again; the flag lets the second invocation fall through without cancelling.
        private bool _isClosing;

        // True between a successful PlayAsync and the next Stop/Destroy. Gates
        // sliderVolume_ValueChanged from writing to _player before the audio renderer exists.
        private bool _isPlaying;

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

                using (var probe = new MediaPlayerCoreX())
                {
                    var devices = await probe.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                    _audioDevices = devices?.ToList() ?? new List<AudioOutputDeviceInfo>();
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
            // resources and double the gain of that track in the AudioMixerBlock.
            if (_pendingAudioStreams.Any(existing => string.Equals(existing, entry, StringComparison.OrdinalIgnoreCase)))
            {
                lblStatus.Text = "Duplicate audio stream ignored: " + entry;
                // Clear the textbox here too so the duplicate path matches the success path —
                // otherwise users keep hitting Add on the same stale entry without realising why
                // nothing changes.
                textBoxAudioFile.Text = string.Empty;
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
            Dispatcher.BeginInvoke(new Action(() => lblStatus.Text = e.Message));
        }

        private async Task DestroyPlayerAsync()
        {
            _isPlaying = false;
            StopSeekTimer();

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                await _player.DisposeAsync();
                _player = null;
            }

            _pitchEffect = null;
        }

        private async void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            // Disable Play/Stop on entry to block re-entrant clicks. async void handlers don't
            // await one another, so a rapid double-click would race concurrent DestroyPlayerAsync
            // and `new MediaPlayerCoreX` calls on _player.
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

                var mainUri = ToUri(videoPath);
                if (mainUri == null)
                {
                    lblStatus.Text = "Invalid video path/URL: " + videoPath;
                    return;
                }

                var mainSource = await UniversalSourceSettings.CreateAsync(mainUri);
                _player.Audio_AdditionalStreams_Clear();
                foreach (var path in _pendingAudioStreams)
                {
                    var extraUri = ToUri(path);
                    if (extraUri == null)
                    {
                        lblStatus.Text = "Invalid additional audio path/URL: " + path;
                        continue;
                    }

                    var extra = await UniversalSourceSettings.CreateAsync(extraUri);
                    if (extra != null)
                    {
                        _player.Audio_AdditionalStreams_Add(extra);
                    }
                }

                await _player.OpenAsync(mainSource);

                // Preserve the user's chosen tempo/pitch across Stop/Play cycles. The ratios
                // match the math used in UpdateTempo / UpdatePitch (value / DEFAULT_*) so the
                // new effect boots with the currently-displayed values rather than resetting
                // the pipeline to defaults and silently discarding the user's choice.
                UpdateLabels();

                // One shared effect drives both sliders, sitting downstream of AudioMixerBlock
                // so it acts on every input (main + additional) at once.
                _pitchEffect = new PitchAudioEffect
                {
                    Name = PITCH_EFFECT_NAME,
                    Pitch = _currentPitch / (float)DEFAULT_PITCH,
                    Tempo = _currentTempo / (float)DEFAULT_TEMPO,
                    Rate = 1.0f
                };
                _player.Audio_Effects_AddOrUpdate(_pitchEffect);

                // Set volume BEFORE PlayAsync — MediaPlayerCoreX caches the value and applies it
                // to the AudioRendererBlock at build time, so there's no 100%-volume burst
                // between renderer creation and a post-Play assignment. Also removes the need to
                // re-assign after every Play.
                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;

                await _player.PlayAsync();
                _isPlaying = true;

                StartSeekTimer();

                // Playback is now live — editing the additional-audio list has no effect on the
                // running pipeline, so disable the relevant buttons until Stop/Close.
                SetAudioListEditable(false);

                lblStatus.Text = _pendingAudioStreams.Count > 0
                    ? $"Playing on '{selectedDevice.Name}'. {_pendingAudioStreams.Count} additional audio stream(s) mixed in."
                    : $"Playing on '{selectedDevice.Name}'.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                // Play failed — tear down the half-built _player so we don't leak the OnError
                // subscription and the native pipeline. Without this, a retried Play leaves the
                // old instance wired up (via OnError) for the remaining window lifetime.
                try { await DestroyPlayerAsync(); } catch { /* best-effort */ }
                _isPlaying = false;
                // Keep audio editing available so the user can fix the list.
                SetAudioListEditable(true);
            }
            finally
            {
                buttonPlay.IsEnabled = true;
                buttonStop.IsEnabled = true;
            }
        }

        private async void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            // Disable Play/Stop on entry to block re-entrant clicks. See buttonPlay_Click for
            // the re-entrancy rationale.
            buttonPlay.IsEnabled = false;
            buttonStop.IsEnabled = false;

            try
            {
                _isPlaying = false;
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
                buttonPlay.IsEnabled = true;
                buttonStop.IsEnabled = true;
            }
        }

        /// <summary>
        /// Toggle the Add / Remove / Clear buttons for the additional-audio list. The list is only
        /// consumed once, at Play time (Audio_AdditionalStreams_Add is called before OpenAsync),
        /// so mutating it during playback is a no-op — disabling the buttons makes this obvious.
        /// </summary>
        private void SetAudioListEditable(bool editable)
        {
            buttonAudioAdd.IsEnabled = editable;
            buttonAudioRemove.IsEnabled = editable;
            buttonAudioClear.IsEnabled = editable;
        }

        private void buttonTempoMin_Click(object sender, RoutedEventArgs e) => UpdateTempo(_currentTempo - TEMPO_STEP);
        private void buttonTempoNormal_Click(object sender, RoutedEventArgs e) => UpdateTempo(DEFAULT_TEMPO);
        private void buttonTempoPlus_Click(object sender, RoutedEventArgs e) => UpdateTempo(_currentTempo + TEMPO_STEP);

        private void buttonPitchMin_Click(object sender, RoutedEventArgs e) => UpdatePitch(_currentPitch - PITCH_STEP);
        private void buttonPitchNormal_Click(object sender, RoutedEventArgs e) => UpdatePitch(DEFAULT_PITCH);
        private void buttonPitchPlus_Click(object sender, RoutedEventArgs e) => UpdatePitch(_currentPitch + PITCH_STEP);

        private void UpdateTempo(int value)
        {
            if (value < MIN_TEMPO) value = MIN_TEMPO;
            if (value > MAX_TEMPO) value = MAX_TEMPO;

            bool valueChanged = value != _currentTempo;
            if (valueChanged)
            {
                // Always record the user's choice and refresh the label, even before playback
                // has created the effect. Otherwise pre-Play +/- clicks are silently dropped and
                // the next Play boots the effect at defaults, ignoring what the user asked for.
                _currentTempo = value;
                UpdateLabels();
            }

            // Always re-assert the pipeline value when the effect exists — even if _currentTempo
            // didn't change. This resyncs any hypothetical drift between the cached int and the
            // live float on the effect (and makes re-click of Normal/+/- after the first click a
            // no-op instead of a silently-skipped write that would hide a drift bug).
            if (_pitchEffect != null)
            {
                _pitchEffect.Tempo = _currentTempo / (float)DEFAULT_TEMPO;
            }
        }

        private void UpdatePitch(int value)
        {
            if (value < MIN_PITCH) value = MIN_PITCH;
            if (value > MAX_PITCH) value = MAX_PITCH;

            bool valueChanged = value != _currentPitch;
            if (valueChanged)
            {
                _currentPitch = value;
                UpdateLabels();
            }

            // See UpdateTempo: always re-assert so cache/pipeline drift can't linger invisibly.
            if (_pitchEffect != null)
            {
                _pitchEffect.Pitch = _currentPitch / (float)DEFAULT_PITCH;
            }
        }

        private void UpdateLabels()
        {
            lblTempo.Text = _currentTempo.ToString();
            lblPitch.Text = _currentPitch.ToString();
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

            // Only treat the input as a path-like if it actually resembles a path. Otherwise
            // `Path.GetFullPath("some weird string")` succeeds by prepending the current working
            // directory, and we'd hand back a bogus file:// URI for input the caller never meant
            // as a file — the error message downstream ends up confusing ("file not found at
            // C:\Cwd\some weird string") instead of honest ("input not a path or URL").
            bool looksLikePath = pathOrUrl.Contains('\\')
                || pathOrUrl.Contains('/')
                || (pathOrUrl.Length >= 2 && pathOrUrl[1] == ':');
            if (!looksLikePath)
            {
                return null;
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
                // Expected race: Player was disposed between the null-check and the await.
            }
            catch (InvalidOperationException)
            {
                // SDK reported the pipeline isn't in a state that allows querying — benign during
                // Stop/Dispose transitions.
            }
            catch (Exception ex)
            {
                // Collapsing every exception into a bare catch hides real bugs (null deref, bad
                // state) that are worth surfacing. Post to lblStatus via the dispatcher if it's
                // still alive — otherwise just drop the message so we don't crash on shutdown.
                if (!Dispatcher.HasShutdownStarted && !Dispatcher.HasShutdownFinished)
                {
                    Dispatcher.BeginInvoke(new Action(() => lblStatus.Text = "Seek timer: " + ex.Message));
                }
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
            // PreviewMouseDown fires for every mouse button; a right- or middle-click on the track
            // would otherwise set _seekDragging=true and a matching PreviewMouseUp would then issue
            // Position_SetAsync even though the user never intended to seek.
            if (e.ChangedButton != System.Windows.Input.MouseButton.Left)
            {
                return;
            }

            // Don't arm the flag before there's something to seek. Pre-Play clicks on the
            // disabled slider would otherwise leave _seekDragging true if the user drags off the
            // slider, silently suppressing later timer updates.
            if (_player == null || sliderSeek.Maximum <= 0)
            {
                return;
            }

            _seekDragging = true;
        }

        private void sliderSeek_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // Guarantee _seekDragging can't stick true if WPF swallows MouseUp (focus stolen by
            // Alt-Tab, popup, etc.). Without this the seek-timer path is silently suppressed for
            // the rest of the window's life.
            _seekDragging = false;
        }

        private async void sliderSeek_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                double value = sliderSeek.Value;
                if (!double.IsFinite(value) || value < 0)
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
                if (!double.IsFinite(newValue) || newValue < 0 || !double.IsFinite(max) || max < 0)
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

            // Only write to the player when it's actually playing — between `new MediaPlayerCoreX`
            // and PlayAsync the audio renderer doesn't exist yet, and the assignment either
            // silently no-ops or (worse) throws into the WPF unhandled-exception handler because
            // this handler has no try/catch.
            if (_player == null || !_isPlaying)
            {
                return;
            }

            try
            {
                _player.Audio_OutputDevice_Volume = e.NewValue / 100.0;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Volume: " + ex.Message;
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
            // Proactively stop the seek timer + clear the drag flag so neither can interact with
            // the player during DisposeAsync. This closes two fragile couplings at once: (a)
            // StopSeekTimer previously only ran inside DestroyPlayerAsync, so future code paths
            // that start the timer pre-Play would leak it, and (b) _seekDragging could still be
            // true if the user force-closed mid-drag (no MouseUp ever fires).
            StopSeekTimer();
            _seekDragging = false;

            try
            {
                await DestroyPlayerAsync();
            }
            catch (Exception ex)
            {
                // Never block shutdown on a dispose failure — the user wants out. DisposeAsync
                // may complete on a thread-pool continuation; writing lblStatus.Text from a
                // non-UI thread would throw InvalidOperationException. The user can't see
                // lblStatus anyway while the window is closing, so log-and-drop is safer.
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
