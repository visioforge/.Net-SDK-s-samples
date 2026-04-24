namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;

    using YoutubeDLSharp;
    using YoutubeDLSharp.Metadata;
    using System.Diagnostics;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video info list.
        /// </summary>
        private readonly List<FormatData> _videoInfoList = new List<FormatData>();

        /// <summary>
        /// The audio info list.
        /// </summary>
        private readonly List<FormatData> _audioInfoList = new List<FormatData>();

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private UniversalSourceBlock _videoSource;

        /// <summary>
        /// The audio source.
        /// </summary>
        private UniversalSourceBlock _audioSource;

        /// <summary>
        /// Temp MPD files synthesized by <see cref="YouTubeDashMpdBuilder"/> for DASH
        /// formats. Deleted on Stop / Close.
        /// </summary>
        private readonly List<string> _tempMpdFiles = new List<string>();

        /// <summary>
        /// Total duration in seconds reported by yt-dlp for the current video, used as
        /// <c>mediaPresentationDuration</c> when synthesizing a DASH MPD.
        /// </summary>
        private double _videoDurationSeconds;

        /// <summary>
        /// Destroy engine async. Also deletes every temp MPD wrapper synthesized for
        /// DASH formats — the URLs inside expire after a few hours and the files are
        /// no longer useful after the pipeline is gone.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();

                _pipeline.OnError -= MediaPlayer1_OnError;

                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            DeleteTempMpdFiles();
        }

        /// <summary>
        /// Deletes every temp MPD file tracked in <see cref="_tempMpdFiles"/>.
        /// </summary>
        private void DeleteTempMpdFiles()
        {
            foreach (var path in _tempMpdFiles)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch
                {
                    // best-effort — temp dir gets cleared by the OS eventually
                }
            }

            _tempMpdFiles.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void BtStart_Click(object sender, EventArgs e)
        {
            try
            {
                mmLog.Text = string.Empty;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += MediaPlayer1_OnError;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
                _pipeline.Debug_Mode = cbDebugMode.Checked;

                if (_videoInfoList.Count == 0)
                {
                    MessageBox.Show(this, "Please read formats first.");
                    return;
                }

                if (cbVideoStream.SelectedIndex < 0 || cbVideoStream.SelectedIndex >= _videoInfoList.Count)
                {
                    MessageBox.Show(this, "Please select a video stream.");
                    return;
                }

                // video stream
                var selectedVideoFormat = _videoInfoList[cbVideoStream.SelectedIndex];
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.AudioCodec) && selectedVideoFormat.AudioCodec != "none";

                LogSeekabilityFor("Video", selectedVideoFormat);
                FormatData extraAudio = null;
                if (!audioMuxed && cbAudioStream.SelectedIndex > 0)
                {
                    extraAudio = _audioInfoList[cbAudioStream.SelectedIndex - 1];
                    LogSeekabilityFor("Audio", extraAudio);
                }

                // Decide how to feed the SDK:
                //  - progressive video (itag 18/22) → direct URL, qtdemux handles seek;
                //  - DASH video → synthesize an MPD wrapping the video (and, if the user picked
                //    one, the extra audio stream) so uridecodebin3 routes through dashdemux2
                //    and seek works via DASH OnDemand SegmentBase+indexRange.
                Uri sourceUri = new Uri(selectedVideoFormat.Url!);
                bool sourceRendersAudio = audioMuxed;
                bool mpdCombinesAudio = false;

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
                        sourceRendersAudio = extraAudio != null; // audio is inside the MPD now
                        mpdCombinesAudio = extraAudio != null;
                        AppendLog($"MPD ready: {mpdPath}");
                    }
                    else
                    {
                        AppendLog("MPD probe failed, falling back to direct URL (seek will not work).");
                    }
                }

                var videoSourceSettings = await UniversalSourceSettings.CreateAsync(
                    sourceUri,
                    renderVideo: true,
                    renderAudio: sourceRendersAudio,
                    renderSubtitle: false,
                    ignoreMediaInfoReader: true);
                _videoSource = new UniversalSourceBlock(videoSourceSettings);

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                _pipeline.Connect(_videoSource, _videoRenderer);

                // audio stream
                var audioOutputs = await AudioRendererBlock.GetDevicesAsync(VisioForge.Core.Types.X.Output.AudioOutputDeviceAPI.DirectSound);
                _audioRenderer = new AudioRendererBlock(audioOutputs[cbAudioOutput.SelectedIndex]);

                if (audioMuxed || mpdCombinesAudio)
                {
                    // Single source carries both tracks — either a muxed YouTube itag
                    // (18/22) or our synthetic MPD bundling video + audio AdaptationSets.
                    _pipeline.Connect(_videoSource, _audioRenderer);
                }
                else if (extraAudio != null)
                {
                    // Separate audio URL (fallback path when MPD probe failed on a DASH
                    // video stream or the video is progressive but user picked extra audio).
                    var audioSourceSettings = await UniversalSourceSettings.CreateAsync(
                        new Uri(extraAudio.Url!),
                        renderVideo: false,
                        renderAudio: true,
                        renderSubtitle: false,
                        ignoreMediaInfoReader: true);
                    _audioSource = new UniversalSourceBlock(audioSourceSettings);

                    _pipeline.Connect(_audioSource, _audioRenderer);
                }

                // start
                await _pipeline.StartAsync();

                timer1.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void BtStop_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                await _pipeline.StopAsync(true);

                await DestroyEngineAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Handles the bt read formats click event.
        /// </summary>
        private async void BtReadFormats_Click(object sender, EventArgs e)
        {
            try
            {
                _videoInfoList.Clear();
                _audioInfoList.Clear();

                cbVideoStream.Items.Clear();
                cbAudioStream.Items.Clear();
                cbAudioStream.Items.Add("None");

                var toolsDir = Path.Combine(AppContext.BaseDirectory, "tools");
                var ytdlpPath = Path.Combine(toolsDir, "yt-dlp.exe");

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
                    MessageBox.Show(this, "Could not retrieve formats.");
                    return;
                }

                _videoDurationSeconds = result.Data?.Duration ?? 0;

                // All streams carrying video (both muxed and video-only). Sort
                // progressive (itag 18/22) ahead of DASH fragments so the first
                // item in the dropdown is the most likely to seek cleanly.
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                await VisioForgeX.InitSDKAsync();

                var audioOutputs = await AudioRendererBlock.GetDevicesAsync(VisioForge.Core.Types.X.Output.AudioOutputDeviceAPI.DirectSound);
                foreach (var audioOutput in audioOutputs)
                {
                    cbAudioOutput.Items.Add(audioOutput.Name);
                }

                if (cbAudioOutput.Items.Count > 0)
                {
                    cbAudioOutput.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var duration = await _pipeline.DurationAsync();
                var position = await _pipeline.Position_GetAsync();

                lbTime.Text = position.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture) + " | " + duration.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


        /// <summary>
        /// YouTube itags served as progressive MP4 with a full moov (byte-range seekable).
        /// Everything NOT in this set is a DASH fragment even when yt-dlp reports
        /// <c>protocol=https</c> — YouTube delivers fragmented MP4 via ordinary https
        /// byte ranges, so the transport protocol is not a reliable signal.
        /// </summary>
        private static readonly HashSet<string> ProgressiveYouTubeItags = new HashSet<string>(StringComparer.Ordinal)
        {
            "18", // 360p mp4 (avc1 + aac, muxed)
            "22", // 720p mp4 (avc1 + aac, muxed)
            "36", // 240p 3gp (legacy)
            "43", // 360p webm (legacy)
        };

        /// <summary>
        /// Returns <c>true</c> when the format is very likely to be seekable through
        /// the player. YouTube is decided by itag; other sources fall back to
        /// protocol + container + URL heuristics.
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

            if (!string.IsNullOrEmpty(f.Url) && f.Url.IndexOf("googlevideo.com", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return false;
            }

            return protocol == "https" || protocol == "http" || string.IsNullOrEmpty(protocol);
        }

        private static string SeekabilityTag(FormatData f)
        {
            return IsProgressiveFormat(f) ? "[progressive]" : "[DASH]";
        }

        /// <summary>
        /// Builds a descriptive label for a video-bearing format: codec, resolution,
        /// frame rate, muxed-audio presence, container, transport protocol tag, and
        /// approximate size.
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
        /// Builds a descriptive label for an audio-only format.
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
        /// Writes a short seekability hint for the selected format. For YouTube the
        /// decision is driven by itag; everything else is DASH regardless of what
        /// <c>protocol</c> reports.
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
            if (IsDisposed || Disposing)
            {
                return;
            }

            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => AppendLog(text)));
                return;
            }

            mmLog.Text = mmLog.Text + text + Environment.NewLine;
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                await DestroyEngineAsync();

                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
