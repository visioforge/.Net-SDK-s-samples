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
            Dispatcher.Invoke(() => lblStatus.Text = e.Message);
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

            _pitchEffect = null;
        }

        private async void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string videoPath = textBoxVideoFile.Text?.Trim();
                if (string.IsNullOrEmpty(videoPath) || !File.Exists(videoPath))
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

                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;

                var mainSource = await UniversalSourceSettings.CreateAsync(ToUri(videoPath));
                _player.Audio_AdditionalStreams_Clear();
                foreach (var path in _pendingAudioStreams)
                {
                    var extra = await UniversalSourceSettings.CreateAsync(ToUri(path));
                    if (extra != null)
                    {
                        _player.Audio_AdditionalStreams_Add(extra);
                    }
                }

                await _player.OpenAsync(mainSource);

                _currentTempo = DEFAULT_TEMPO;
                _currentPitch = DEFAULT_PITCH;
                UpdateLabels();

                // One shared effect drives both sliders, sitting downstream of AudioMixerBlock
                // so it acts on every input (main + additional) at once.
                _pitchEffect = new PitchAudioEffect { Name = PITCH_EFFECT_NAME, Pitch = 1.0f, Tempo = 1.0f, Rate = 1.0f };
                _player.Audio_Effects_AddOrUpdate(_pitchEffect);

                await _player.PlayAsync();

                StartSeekTimer();

                lblStatus.Text = _pendingAudioStreams.Count > 0
                    ? $"Playing on '{selectedDevice.Name}'. {_pendingAudioStreams.Count} additional audio stream(s) mixed in."
                    : $"Playing on '{selectedDevice.Name}'.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
        }

        private async void buttonStop_Click(object sender, RoutedEventArgs e)
        {
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
            if (value == _currentTempo || _pitchEffect == null)
            {
                return;
            }

            _pitchEffect.Tempo = value / (float)DEFAULT_TEMPO;
            _currentTempo = value;
            UpdateLabels();
        }

        private void UpdatePitch(int value)
        {
            if (value < MIN_PITCH) value = MIN_PITCH;
            if (value > MAX_PITCH) value = MAX_PITCH;
            if (value == _currentPitch || _pitchEffect == null)
            {
                return;
            }

            _pitchEffect.Pitch = value / (float)DEFAULT_PITCH;
            _currentPitch = value;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            lblTempo.Text = _currentTempo.ToString();
            lblPitch.Text = _currentPitch.ToString();
        }

        private static Uri ToUri(string pathOrUrl)
        {
            if (IsSupportedUri(pathOrUrl))
            {
                return new Uri(pathOrUrl);
            }

            return new Uri(Path.GetFullPath(pathOrUrl));
        }

        private static bool IsSupportedUri(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            return s.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                || s.StartsWith("https://", StringComparison.OrdinalIgnoreCase)
                || s.StartsWith("rtsp://", StringComparison.OrdinalIgnoreCase)
                || s.StartsWith("rtmp://", StringComparison.OrdinalIgnoreCase)
                || s.StartsWith("file:///", StringComparison.OrdinalIgnoreCase);
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
            if (_player == null || _seekDragging)
            {
                return;
            }

            try
            {
                var position = await _player.Position_GetAsync();
                var duration = await _player.DurationAsync();

                Dispatcher.Invoke(() =>
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
                });
            }
            catch
            {
                // Timer may race with Stop/Dispose — swallow.
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
            _seekDragging = true;
        }

        private async void sliderSeek_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (_player != null)
                {
                    await _player.Position_SetAsync(TimeSpan.FromSeconds(sliderSeek.Value));
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
            if (_seekTimerWriting)
            {
                return;
            }

            if (_seekDragging)
            {
                lblTime.Text = $"{FormatTime(TimeSpan.FromSeconds(e.NewValue))} / {FormatTime(TimeSpan.FromSeconds(sliderSeek.Maximum))}";
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
            await DestroyPlayerAsync();
        }
    }
}
