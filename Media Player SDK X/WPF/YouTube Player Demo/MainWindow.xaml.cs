using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ManuHub.Ytdlp.NET;
using VisioForge.Core;
using VisioForge.Core.MediaPlayerX;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;

namespace youtube_player_x
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Video-only format list populated by Read Formats.
        /// </summary>
        private readonly List<FormatMetadata> _videoInfoList = new List<FormatMetadata>();

        /// <summary>
        /// Audio-only format list populated by Read Formats.
        /// </summary>
        private readonly List<FormatMetadata> _audioInfoList = new List<FormatMetadata>();

        /// <summary>
        /// Cached audio output devices, populated once on window load.
        /// </summary>
        private List<AudioOutputDeviceInfo> _audioDevices = new List<AudioOutputDeviceInfo>();

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCoreX _player;

        /// <summary>
        /// Seek timer — fires every 500 ms to update the timeline and time label.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// Flag to prevent the timer from fighting the user's seek drag.
        /// </summary>
        private volatile bool _timerFlag;

        /// <summary>
        /// Re-entrancy guard for Start/Stop clicks.
        /// </summary>
        private bool _actionInFlight;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Window loaded — initialises the SDK and populates the audio output device list.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                lblStatus.Text = "Initializing SDK...";

                await VisioForgeX.InitSDKAsync();

                Title += $" (SDK v{MediaPlayerCoreX.SDK_Version})";

                // Enumerate DirectSound output devices using a temporary probe instance.
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

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += Timer_Elapsed;

                lblStatus.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblStatus.Text = "SDK init error: " + ex.Message;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        /// <summary>
        /// Reads available video and audio formats for the entered YouTube URL via yt-dlp.
        /// </summary>
        private async void btReadFormats_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                btReadFormats.IsEnabled = false;
                lblStatus.Text = "Reading formats...";

                _videoInfoList.Clear();
                _audioInfoList.Clear();

                cbVideoStream.Items.Clear();
                cbAudioStream.Items.Clear();
                cbAudioStream.Items.Add("None");

                var ytdlpPath = Path.Combine(AppContext.BaseDirectory, "tools", "yt-dlp.exe");
                var denoPath = Path.Combine(AppContext.BaseDirectory, "tools", "deno.exe");

                await using var ytdlp = new Ytdlp(ytdlpPath)
                    .WithJsRuntime(Runtime.Deno, denoPath);

                var metadata = await ytdlp.GetMetadataAsync(edURL.Text);
                var formats = metadata?.Formats;

                if (formats == null)
                {
                    lblStatus.Text = "Could not retrieve formats.";
                    return;
                }

                // Video-only streams (have video codec, no audio codec).
                var videos = formats.Where(f =>
                    !string.IsNullOrEmpty(f.Vcodec) && f.Vcodec != "none" &&
                    (string.IsNullOrEmpty(f.Acodec) || f.Acodec == "none") &&
                    !string.IsNullOrEmpty(f.Url));

                foreach (var stream in videos)
                {
                    cbVideoStream.Items.Add($"{stream.Format ?? stream.FormatId} [{stream.Ext}]");
                    _videoInfoList.Add(stream);
                }

                // Audio-only streams.
                var audios = formats.Where(f =>
                    !string.IsNullOrEmpty(f.Acodec) && f.Acodec != "none" &&
                    (string.IsNullOrEmpty(f.Vcodec) || f.Vcodec == "none") &&
                    !string.IsNullOrEmpty(f.Url));

                foreach (var stream in audios)
                {
                    cbAudioStream.Items.Add($"{stream.Format ?? stream.FormatId} [{stream.Abr?.ToString("F0") ?? "?"} kbps]");
                    _audioInfoList.Add(stream);
                }

                if (cbVideoStream.Items.Count > 0)
                {
                    cbVideoStream.SelectedIndex = 0;
                }

                cbAudioStream.SelectedIndex = 0;

                lblStatus.Text = $"Found {_videoInfoList.Count} video stream(s), {_audioInfoList.Count} audio stream(s).";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblStatus.Text = "Error reading formats: " + ex.Message;
            }
            finally
            {
                btReadFormats.IsEnabled = true;
            }
        }

        /// <summary>
        /// Starts playback of the selected video and audio streams.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (_actionInFlight)
            {
                return;
            }

            _actionInFlight = true;
            SetPlaybackButtonsEnabled(false);

            try
            {
                if (_videoInfoList.Count == 0)
                {
                    MessageBox.Show(this, "Please read formats first.", "YouTube Player", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                edLog.Clear();

                await DestroyPlayerAsync();

                var selectedVideoFormat = _videoInfoList[cbVideoStream.SelectedIndex];
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.Acodec) && selectedVideoFormat.Acodec != "none";

                // Resolve selected audio output device.
                AudioOutputDeviceInfo selectedDevice = null;
                if (cbAudioOutput.SelectedIndex >= 0 && cbAudioOutput.SelectedIndex < _audioDevices.Count)
                {
                    selectedDevice = _audioDevices[cbAudioOutput.SelectedIndex];
                }

                if (selectedDevice == null)
                {
                    var probe = new MediaPlayerCoreX();
                    try
                    {
                        var devices = await probe.Audio_OutputDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                        selectedDevice = devices?.FirstOrDefault();
                    }
                    finally
                    {
                        await probe.DisposeAsync();
                    }
                }

                _player = new MediaPlayerCoreX(VideoView1);
                _player.OnError += Player_OnError;
                _player.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
                _player.Debug_Mode = cbDebugMode.IsChecked == true;

                if (selectedDevice != null)
                {
                    _player.Audio_OutputDevice = new AudioRendererSettings(selectedDevice);
                }

                bool needAudio = audioMuxed || cbAudioStream.SelectedIndex > 0;
                _player.Audio_Play = needAudio;

                // Build the main video source. For video-only streams disable audio rendering
                // so the decoder doesn't stall waiting for a non-existent audio track.
                var mainSource = await UniversalSourceSettings.CreateAsync(
                    new Uri(selectedVideoFormat.Url!),
                    renderVideo: true,
                    renderAudio: audioMuxed,
                    renderSubtitle: false,
                    ignoreMediaInfoReader: true);

                _player.Audio_AdditionalStreams_Clear();

                // Add a separate audio-only stream when the user selected one and the video
                // stream doesn't already carry audio.
                if (!audioMuxed && cbAudioStream.SelectedIndex > 0)
                {
                    var audioFormat = _audioInfoList[cbAudioStream.SelectedIndex - 1];
                    var audioSource = await UniversalSourceSettings.CreateAsync(
                        new Uri(audioFormat.Url!),
                        renderVideo: false,
                        renderAudio: true,
                        renderSubtitle: false,
                        ignoreMediaInfoReader: true);

                    _player.Audio_AdditionalStreams_Add(audioSource);
                }

                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;

                await _player.OpenAsync(mainSource);
                await _player.PlayAsync();

                StartTimer();

                lblStatus.Text = selectedDevice != null
                    ? $"Playing on '{selectedDevice.Name}'."
                    : "Playing.";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                edLog.Text += $"Start error: {ex.Message}{Environment.NewLine}";
                lblStatus.Text = "Playback error.";
            }
            finally
            {
                _actionInFlight = false;
                SetPlaybackButtonsEnabled(true);
            }
        }

        /// <summary>
        /// Stops playback and destroys the player instance.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_actionInFlight)
            {
                return;
            }

            _actionInFlight = true;
            SetPlaybackButtonsEnabled(false);

            try
            {
                StopTimer();

                if (_player != null)
                {
                    await _player.StopAsync();
                    await DestroyPlayerAsync();
                }

                Dispatcher.Invoke(() =>
                {
                    sliderTimeline.Value = 0;
                    lblTime.Text = "00:00:00 / 00:00:00";
                    lblStatus.Text = "Stopped.";
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _actionInFlight = false;
                SetPlaybackButtonsEnabled(true);
            }
        }

        /// <summary>
        /// Pauses playback.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_player != null)
                {
                    await _player.PauseAsync();
                    lblStatus.Text = "Paused.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Resumes paused playback.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_player != null)
                {
                    await _player.ResumeAsync();
                    lblStatus.Text = "Playing.";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles timeline seek drag.
        /// </summary>
        private async void sliderTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!_timerFlag && _player != null)
                {
                    await _player.Position_SetAsync(TimeSpan.FromSeconds(sliderTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Applies volume to the running player immediately.
        /// </summary>
        private void sliderVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_player != null)
            {
                _player.Audio_OutputDevice_Volume = sliderVolume.Value / 100.0;
            }
        }

        /// <summary>
        /// Player error event — appends the error message to the log.
        /// </summary>
        private void Player_OnError(object sender, ErrorsEventArgs e)
        {
            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                return;
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                edLog.Text += e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Timer tick — updates the timeline slider and time label.
        /// </summary>
        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timerFlag = true;

                if (_player == null)
                {
                    return;
                }

                var position = await _player.Position_GetAsync();
                var duration = await _player.DurationAsync();

                Dispatcher.Invoke(() =>
                {
                    sliderTimeline.Maximum = duration.TotalSeconds;
                    lblTime.Text = position.ToString("hh\\:mm\\:ss") + " / " + duration.ToString("hh\\:mm\\:ss");

                    if (sliderTimeline.Maximum >= position.TotalSeconds)
                    {
                        sliderTimeline.Value = position.TotalSeconds;
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _timerFlag = false;
            }
        }

        /// <summary>
        /// Destroys the player, unsubscribing events and awaiting disposal.
        /// </summary>
        private async Task DestroyPlayerAsync()
        {
            StopTimer();

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                await _player.DisposeAsync();
                _player = null;
            }
        }

        /// <summary>
        /// Starts the seek timer.
        /// </summary>
        private void StartTimer()
        {
            _timer?.Start();
        }

        /// <summary>
        /// Stops the seek timer.
        /// </summary>
        private void StopTimer()
        {
            _timer?.Stop();
        }

        /// <summary>
        /// Enables or disables the playback control buttons.
        /// </summary>
        private void SetPlaybackButtonsEnabled(bool enabled)
        {
            btStart.IsEnabled = enabled;
            btStop.IsEnabled = enabled;
            btPause.IsEnabled = enabled;
            btResume.IsEnabled = enabled;
        }

        /// <summary>
        /// Window closing — stops the timer, destroys the player, and shuts down the SDK.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                StopTimer();

                await DestroyPlayerAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
