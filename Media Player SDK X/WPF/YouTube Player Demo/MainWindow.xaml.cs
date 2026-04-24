using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
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
        private readonly List<FormatData> _videoInfoList = new List<FormatData>();

        /// <summary>
        /// Audio-only format list populated by Read Formats.
        /// </summary>
        private readonly List<FormatData> _audioInfoList = new List<FormatData>();

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
        private DispatcherTimer _timer;

        /// <summary>
        /// Set while the user is dragging the timeline thumb. Suppresses timer writes to the
        /// slider so the tick doesn't yank the thumb out from under the user's finger.
        /// </summary>
        private volatile bool _seekDragging;

        /// <summary>
        /// Set while <see cref="Timer_Tick"/> is writing to the slider. Suppresses the
        /// ValueChanged-driven label refresh that would otherwise fire on every tick
        /// and undo the user's scrub preview.
        /// </summary>
        private volatile bool _seekTimerWriting;

        /// <summary>
        /// Re-entrancy guard for Start/Stop clicks.
        /// </summary>
        private bool _actionInFlight;

        /// <summary>
        /// Temp MPD files synthesized by <see cref="YouTubeDashMpdBuilder"/> for DASH
        /// formats. Deleted on Stop / Close / Dispose.
        /// </summary>
        private readonly List<string> _tempMpdFiles = new List<string>();

        /// <summary>
        /// Total media duration in seconds reported by yt-dlp for the current video.
        /// Used as the <c>mediaPresentationDuration</c> for generated MPDs; 0 means
        /// unknown and the builder will fall back to parsing <c>&amp;dur=…</c> from the URL.
        /// </summary>
        private double _videoDurationSeconds;

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

                _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(500) };
                _timer.Tick += Timer_Tick;

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

                var toolsDir = Path.Combine(AppContext.BaseDirectory, "tools");
                var ytdlpPath = Path.Combine(toolsDir, "yt-dlp.exe");

                // Ensure yt-dlp can find deno.exe (needed for YouTube JS challenge).
                var envPath = Environment.GetEnvironmentVariable("PATH") ?? string.Empty;
                if (!envPath.Contains(toolsDir, StringComparison.OrdinalIgnoreCase))
                {
                    Environment.SetEnvironmentVariable("PATH", toolsDir + Path.PathSeparator + envPath);
                }

                var ytdl = new YoutubeDL { YoutubeDLPath = ytdlpPath };
                var result = await ytdl.RunVideoDataFetch(edURL.Text);
                var formats = result.Data?.Formats;

                if (formats == null || !result.Success)
                {
                    lblStatus.Text = "Could not retrieve formats.";
                    return;
                }

                _videoDurationSeconds = result.Data?.Duration ?? 0;

                // All streams carrying video (both video-only and muxed video+audio).
                // Muxed formats are useful to select when debugging seek: they use a single
                // uridecodebin3 instead of two independent HTTP sources.
                // Sort progressive (plain https/http) ahead of fragmented DASH/HLS — GStreamer's
                // qtdemux seek on fragmented MP4 without sidx is unreliable, so listing
                // progressive first gives the user a seekable default.
                var videos = formats.Where(f =>
                    !string.IsNullOrEmpty(f.VideoCodec) && f.VideoCodec != "none" &&
                    !string.IsNullOrEmpty(f.Url))
                    .OrderByDescending(IsProgressiveFormat)
                    .ThenByDescending(f => f.Height ?? 0)
                    .ToList();

                foreach (var stream in videos)
                {
                    cbVideoStream.Items.Add(FormatVideoLabel(stream));
                    _videoInfoList.Add(stream);
                }

                // Audio-only streams — same progressive-first sort.
                var audios = formats.Where(f =>
                    !string.IsNullOrEmpty(f.AudioCodec) && f.AudioCodec != "none" &&
                    (string.IsNullOrEmpty(f.VideoCodec) || f.VideoCodec == "none") &&
                    !string.IsNullOrEmpty(f.Url))
                    .OrderByDescending(IsProgressiveFormat)
                    .ThenByDescending(f => f.AudioBitrate ?? 0)
                    .ToList();

                foreach (var stream in audios)
                {
                    cbAudioStream.Items.Add(FormatAudioLabel(stream));
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
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.AudioCodec) && selectedVideoFormat.AudioCodec != "none";

                LogSeekabilityFor("Video", selectedVideoFormat);
                if (!audioMuxed && cbAudioStream.SelectedIndex > 0)
                {
                    LogSeekabilityFor("Audio", _audioInfoList[cbAudioStream.SelectedIndex - 1]);
                }

                // Resolve selected audio output device.
                AudioOutputDeviceInfo selectedDevice = null;
                if (cbAudioOutput.SelectedIndex >= 0 && cbAudioOutput.SelectedIndex < _audioDevices.Count)
                {
                    selectedDevice = _audioDevices[cbAudioOutput.SelectedIndex];
                }

                if (selectedDevice == null)
                {
                    selectedDevice = _audioDevices.FirstOrDefault();
                }

                _player = new MediaPlayerCoreX(VideoView1);
                _player.OnError += Player_OnError;
                _player.OnStop += Player_OnStop;
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
                if (string.IsNullOrEmpty(selectedVideoFormat.Url))
                {
                    MessageBox.Show(this, "Selected stream has no URL.", "YouTube Player", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Decide how to feed the SDK:
                //  - progressive video (itag 18/22) → direct URL, seek works through qtdemux;
                //  - DASH video → synthesize an MPD wrapping the video (and, if the user picked
                //    one, the extra audio stream) so uridecodebin3 routes through dashdemux2
                //    and seek works via DASH OnDemand SegmentBase+indexRange.
                Uri sourceUri = new Uri(selectedVideoFormat.Url!);
                bool sourceRendersAudio = audioMuxed;
                bool mpdCombinesAudio = false;
                FormatData extraAudio = null;
                if (!audioMuxed && cbAudioStream.SelectedIndex > 0)
                {
                    extraAudio = _audioInfoList[cbAudioStream.SelectedIndex - 1];
                }

                if (!IsProgressiveFormat(selectedVideoFormat))
                {
                    AppendLog("Building DASH MPD wrapper for seek support...");
                    var mpdPath = await YouTubeDashMpdBuilder.BuildMpdAsync(
                        selectedVideoFormat,
                        extraAudio,
                        TimeSpan.FromSeconds(_videoDurationSeconds),
                        CancellationToken.None);
                    if (!string.IsNullOrEmpty(mpdPath))
                    {
                        _tempMpdFiles.Add(mpdPath);
                        sourceUri = new Uri(mpdPath);
                        sourceRendersAudio = audioMuxed || extraAudio != null; // audio is now inside the MPD
                        mpdCombinesAudio = extraAudio != null;
                        AppendLog($"MPD ready: {mpdPath}");
                    }
                    else
                    {
                        AppendLog("MPD probe failed, falling back to direct URL (seek will not work).");
                    }
                }

                var mainSource = await UniversalSourceSettings.CreateAsync(
                    sourceUri,
                    renderVideo: true,
                    renderAudio: sourceRendersAudio,
                    renderSubtitle: false,
                    ignoreMediaInfoReader: true);

                _player.Audio_AdditionalStreams_Clear();

                // Add a separate audio-only stream when the user selected one and the video
                // stream doesn't already carry audio. Skip when the MPD already bundles the
                // audio track — adding it a second time would spawn a second source bin and
                // drag audiomixer back into the pipeline.
                if (!audioMuxed && extraAudio != null && !mpdCombinesAudio)
                {
                    var audioSource = await UniversalSourceSettings.CreateAsync(
                        new Uri(extraAudio.Url!),
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

                // Tear down whatever was partially built — a half-opened player leaks
                // native resources, and a freshly-added temp MPD wrapper leaks to
                // the temp dir if we don't cover the failure path here.
                await DestroyPlayerAsync();
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
        /// Timeline slider value changed — only refreshes the scrub preview label while the
        /// user is dragging. Seeking happens on mouse-up, not per value change, because the
        /// old per-tick seek spammed the HTTP-backed YouTube streams with back-to-back seek
        /// requests that the pipeline rejected.
        /// </summary>
        private void sliderTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_seekTimerWriting || !_seekDragging || sliderTimeline.Maximum <= 0)
            {
                return;
            }

            double newValue = e.NewValue;
            double max = sliderTimeline.Maximum;
            if (double.IsNaN(newValue) || double.IsInfinity(newValue) || newValue < 0
                || double.IsNaN(max) || double.IsInfinity(max) || max < 0)
            {
                return;
            }

            lblTime.Text = TimeSpan.FromSeconds(newValue).ToString("hh\\:mm\\:ss")
                + " / " + TimeSpan.FromSeconds(max).ToString("hh\\:mm\\:ss");
        }

        /// <summary>
        /// Arms the drag flag when the user presses the left mouse button on the slider.
        /// Mirrors the guard used in Multi Audio Streams Demo so a middle/right-click or a
        /// click on an empty/pre-playback slider can't leave the flag stuck true.
        /// </summary>
        private void sliderTimeline_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton != System.Windows.Input.MouseButton.Left)
            {
                return;
            }

            if (_player == null || sliderTimeline.Maximum <= 0)
            {
                return;
            }

            _seekDragging = true;
        }

        /// <summary>
        /// Safety net for swallowed MouseUp (Alt-Tab, focus-stealing popup): clears the
        /// drag flag so the seek timer isn't silently blocked for the rest of the session.
        /// </summary>
        private void sliderTimeline_LostMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _seekDragging = false;
        }

        /// <summary>
        /// Performs the actual seek on mouse release. Logs the attempted position to
        /// <c>edLog</c> on both success and failure so the user can see which value was
        /// sent even when the pipeline rejects it (HTTP-backed YouTube streams sometimes
        /// refuse mid-playback seeks).
        /// </summary>
        private async void sliderTimeline_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Ignore MouseUp events that weren't paired with our own MouseDown —
            // synthetic MouseUps from Alt-Tab returning focus, popups closing, or touch
            // events without a matching Down would otherwise seek to the current thumb
            // position (often 0 before Play) every time they fire.
            if (!_seekDragging)
            {
                return;
            }

            var target = TimeSpan.Zero;
            try
            {
                double value = sliderTimeline.Value;
                if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
                {
                    return;
                }

                if (_player == null)
                {
                    return;
                }

                target = TimeSpan.FromSeconds(value);
                AppendLog($"Seeking to {target:hh\\:mm\\:ss}...");
                await _player.Position_SetAsync(target);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                AppendLog($"Seek to {target:hh\\:mm\\:ss} failed: {ex.Message}");
            }
            finally
            {
                _seekDragging = false;
            }
        }

        /// <summary>
        /// YouTube itags that are served as genuine progressive MP4 with a full moov
        /// at the start of the file (byte-range seekable through qtdemux). Everything
        /// NOT in this set is a DASH fragment even when yt-dlp reports
        /// <c>protocol=https</c> — because YouTube's fragmented MP4 responses are
        /// delivered as ordinary https byte-range downloads, the transport protocol
        /// is a useless signal here.
        /// </summary>
        private static readonly HashSet<string> ProgressiveYouTubeItags = new HashSet<string>(StringComparer.Ordinal)
        {
            "18", // 360p mp4 (avc1 + aac, muxed)
            "22", // 720p mp4 (avc1 + aac, muxed)
            "36", // 240p 3gp (legacy, rarely served now)
            "43", // 360p webm (legacy, rarely served now)
        };

        /// <summary>
        /// Returns <c>true</c> when the format is very likely to be seekable through
        /// GStreamer's qtdemux path. YouTube URLs are decided by itag (the only
        /// structural signal the format metadata carries); for other sources we fall
        /// back to protocol + container heuristics.
        /// </summary>
        private static bool IsProgressiveFormat(FormatData f)
        {
            if (f == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(f.FormatId) && ProgressiveYouTubeItags.Contains(f.FormatId))
            {
                return true;
            }

            var container = f.ContainerFormat?.ToLowerInvariant() ?? string.Empty;
            if (container.Contains("dash") || container.Contains("hls") || container.Contains("m3u8"))
            {
                return false;
            }

            var protocol = f.Protocol?.ToLowerInvariant() ?? string.Empty;
            if (protocol.Contains("dash") || protocol.Contains("m3u8") || protocol.Contains("hls"))
            {
                return false;
            }

            // For YouTube URLs that fell through the itag check, the format is DASH
            // even if the protocol is plain https. Detect by host — googlevideo.com
            // DASH responses look identical to progressive at the protocol level.
            if (!string.IsNullOrEmpty(f.Url) && f.Url.IndexOf("googlevideo.com", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return false;
            }

            return protocol == "https" || protocol == "http" || string.IsNullOrEmpty(protocol);
        }

        /// <summary>
        /// Short human tag highlighting whether seeking is expected to work for this format.
        /// </summary>
        private static string SeekabilityTag(FormatData f)
        {
            return IsProgressiveFormat(f) ? "[progressive]" : "[DASH]";
        }

        /// <summary>
        /// Builds a descriptive label for a video-bearing format. Shows codec, resolution,
        /// frame rate, muxed-audio presence (and its codec), container extension, transport
        /// protocol (with a progressive/DASH tag — DASH typically can't seek through our
        /// GStreamer qtdemux path), and an approximate download size.
        /// </summary>
        private static string FormatVideoLabel(FormatData f)
        {
            var parts = new List<string>(7);
            parts.Add(f.FormatId ?? "?");
            parts.Add(SeekabilityTag(f));

            string res;
            if (f.Width.HasValue && f.Height.HasValue)
            {
                res = $"{f.Width}x{f.Height}";
            }
            else
            {
                res = !string.IsNullOrEmpty(f.Resolution) ? f.Resolution : "?";
            }

            if (f.FrameRate.HasValue && f.FrameRate.Value > 0)
            {
                res += $"@{f.FrameRate.Value:0.#}fps";
            }

            var videoCodec = !string.IsNullOrEmpty(f.VideoCodec) && f.VideoCodec != "none" ? f.VideoCodec : "?";
            parts.Add($"{res} {videoCodec}");

            if (f.VideoBitrate.HasValue && f.VideoBitrate.Value > 0)
            {
                parts.Add($"{f.VideoBitrate.Value:0}kbps");
            }

            var audioCodec = !string.IsNullOrEmpty(f.AudioCodec) && f.AudioCodec != "none" ? f.AudioCodec : null;
            parts.Add(audioCodec != null ? $"audio: {audioCodec}" : "audio: NONE");

            if (!string.IsNullOrEmpty(f.Extension))
            {
                parts.Add(f.Extension);
            }

            var size = f.FileSize ?? f.ApproximateFileSize;
            if (size.HasValue && size.Value > 0)
            {
                parts.Add($"~{size.Value / (1024.0 * 1024.0):0.#}MB");
            }

            return string.Join(" | ", parts);
        }

        /// <summary>
        /// Builds a descriptive label for an audio-only format. Shows codec, bitrate,
        /// sampling rate, channel count, container extension, transport protocol tag,
        /// and approximate size.
        /// </summary>
        private static string FormatAudioLabel(FormatData f)
        {
            var parts = new List<string>(6);
            parts.Add(f.FormatId ?? "?");
            parts.Add(SeekabilityTag(f));

            var audioCodec = !string.IsNullOrEmpty(f.AudioCodec) && f.AudioCodec != "none" ? f.AudioCodec : "?";
            string codecLine = audioCodec;
            if (f.AudioBitrate.HasValue && f.AudioBitrate.Value > 0)
            {
                codecLine += $" @{f.AudioBitrate.Value:0}kbps";
            }

            parts.Add(codecLine);

            var extras = new List<string>(2);
            if (f.AudioSamplingRate.HasValue && f.AudioSamplingRate.Value > 0)
            {
                extras.Add($"{f.AudioSamplingRate.Value:0}Hz");
            }

            if (f.AudioChannels.HasValue && f.AudioChannels.Value > 0)
            {
                extras.Add($"{f.AudioChannels.Value}ch");
            }

            if (extras.Count > 0)
            {
                parts.Add(string.Join(" ", extras));
            }

            if (!string.IsNullOrEmpty(f.Extension))
            {
                parts.Add(f.Extension);
            }

            var size = f.FileSize ?? f.ApproximateFileSize;
            if (size.HasValue && size.Value > 0)
            {
                parts.Add($"~{size.Value / (1024.0 * 1024.0):0.#}MB");
            }

            return string.Join(" | ", parts);
        }

        /// <summary>
        /// Writes a short seekability hint for the selected format to <c>edLog</c> so the
        /// user knows up front whether seek is expected to work. For YouTube the decision
        /// is driven by itag (only 18 / 22 / 36 / 43 are progressive MP4 with a full moov
        /// — every other itag is a DASH fragment, even when yt-dlp reports
        /// <c>protocol=https</c>, because YouTube serves DASH over plain https byte
        /// ranges and the transport protocol therefore can't be trusted as a signal).
        /// </summary>
        private void LogSeekabilityFor(string kind, FormatData f)
        {
            if (f == null)
            {
                return;
            }

            var itag = string.IsNullOrEmpty(f.FormatId) ? "(unknown)" : f.FormatId;
            var protocol = string.IsNullOrEmpty(f.Protocol) ? "(unknown)" : f.Protocol;
            var container = string.IsNullOrEmpty(f.ContainerFormat) ? (f.Extension ?? "(unknown)") : f.ContainerFormat;
            if (IsProgressiveFormat(f))
            {
                AppendLog($"{kind} stream: itag={itag}, protocol={protocol}, container={container} — progressive, seek should work.");
            }
            else
            {
                AppendLog($"{kind} stream: itag={itag}, protocol={protocol}, container={container} — DASH fragments. Wrapping in a synthetic MPD so dashdemux2 can handle seek.");
            }
        }

        /// <summary>
        /// Appends a line to the on-screen log on the UI thread.
        /// </summary>
        private void AppendLog(string text)
        {
            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                return;
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                edLog.AppendText(text + Environment.NewLine);
            }));
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
        /// Player stop event — fires on natural EOS or explicit StopAsync. Resets the
        /// UI (timer, slider, status label) so it matches the stopped state, consistent
        /// with the other demos in the SDK that subscribe to OnStop.
        /// </summary>
        private void Player_OnStop(object sender, VisioForge.Core.Types.Events.StopEventArgs e)
        {
            if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            {
                return;
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                StopTimer();
                _seekDragging = false;
                sliderTimeline.Value = 0;
                lblTime.Text = "00:00:00 / 00:00:00";
                lblStatus.Text = "Stopped.";
            }));
        }

        /// <summary>
        /// Timer tick — refreshes the timeline slider and time label. Bails while the user
        /// is dragging so the tick never yanks the thumb away from the scrub position.
        /// Writes to the slider are bracketed by <see cref="_seekTimerWriting"/> so the
        /// ValueChanged handler knows to ignore them.
        /// </summary>
        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                var p = _player;
                if (p == null || _seekDragging)
                {
                    return;
                }

                var position = await p.Position_GetAsync();
                var duration = await p.DurationAsync();

                if (_seekDragging)
                {
                    return;
                }

                double total = duration.TotalSeconds;
                double pos = position.TotalSeconds;

                _seekTimerWriting = true;
                try
                {
                    if (total > 0 && Math.Abs(sliderTimeline.Maximum - total) > 0.5)
                    {
                        sliderTimeline.Maximum = total;
                    }

                    if (!double.IsNaN(pos) && pos >= sliderTimeline.Minimum && pos <= sliderTimeline.Maximum)
                    {
                        sliderTimeline.Value = pos;
                    }
                }
                finally
                {
                    _seekTimerWriting = false;
                }

                lblTime.Text = position.ToString("hh\\:mm\\:ss") + " / " + duration.ToString("hh\\:mm\\:ss");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Destroys the player, unsubscribing events and awaiting disposal. Also deletes
        /// every temp MPD wrapper we synthesized for DASH formats — they are only valid
        /// as long as the player session that was built from them, and YouTube URLs
        /// inside them expire after a few hours anyway.
        /// </summary>
        private async Task DestroyPlayerAsync()
        {
            StopTimer();
            // Clear the drag guard so a session ended mid-drag (user hit Stop while
            // holding the thumb) doesn't leave the next session with a locked-out timer.
            _seekDragging = false;

            if (_player != null)
            {
                _player.OnError -= Player_OnError;
                _player.OnStop -= Player_OnStop;
                await _player.DisposeAsync();
                _player = null;
            }

            DeleteTempMpdFiles();
        }

        /// <summary>
        /// Deletes every temp MPD file tracked in <see cref="_tempMpdFiles"/>. First
        /// attempt is synchronous; if the file is still locked (dashdemux2 may not have
        /// fully released it), we fire-and-forget a background task that retries a few
        /// times with short delays before giving up.
        /// </summary>
        private void DeleteTempMpdFiles()
        {
            foreach (var path in _tempMpdFiles)
            {
                if (TryDeleteFile(path))
                {
                    continue;
                }

                // File still locked — retry in the background without blocking the UI
                // thread. async void fire-and-forget is fine for a private best-effort
                // helper; exceptions inside are swallowed by TryDeleteFile.
                _ = DeleteWithRetriesAsync(path);
            }

            _tempMpdFiles.Clear();
        }

        private static bool TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static async Task DeleteWithRetriesAsync(string path)
        {
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(200);
                if (TryDeleteFile(path))
                {
                    return;
                }
            }

            // Final give-up: %TEMP% gets cleaned by Windows Disk Cleanup eventually.
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
        /// <see cref="VisioForgeX.DestroySDK"/> is in a <c>finally</c> so native SDK
        /// resources still get released when <see cref="DestroyPlayerAsync"/> throws.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                StopTimer();
                await DestroyPlayerAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                try
                {
                    VisioForgeX.DestroySDK();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
