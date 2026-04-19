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

                // Enumerate audio output devices on the DirectSound API.
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

                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;

                // Register the main source and all queued additional audio streams.
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
