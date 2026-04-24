namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using YoutubeDLSharp;
    using YoutubeDLSharp.Metadata;
    using System.Diagnostics;

    /// <summary>
    /// YouTube player demo main form.
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
        /// Set while the user is dragging or holding a key on the timeline. Tells the timer
        /// tick to skip its slider-write so it doesn't yank the thumb away from the scrub
        /// position mid-drag.
        /// </summary>
        private volatile bool _seekDragging;

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
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

                MediaPlayer1.Debug_Mode = cbDebugMode.Checked;

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

                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;
                MediaPlayer1.Audio_PlayAudio = false;

                MediaPlayer1.Audio_AdditionalStreams_Clear();

                MediaPlayer1.Playlist_Clear();
                var selectedVideoFormat = _videoInfoList[cbVideoStream.SelectedIndex];
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.AudioCodec) && selectedVideoFormat.AudioCodec != "none";

                LogSeekabilityFor("Video", selectedVideoFormat);
                if (!audioMuxed && cbAudioStream.SelectedIndex > 0)
                {
                    LogSeekabilityFor("Audio", _audioInfoList[cbAudioStream.SelectedIndex - 1]);
                }

                MediaPlayer1.Playlist_Add(selectedVideoFormat.Url!);

                if (audioMuxed)
                {
                    MediaPlayer1.Audio_PlayAudio = true;
                }

                if (cbAudioStream.SelectedIndex > 0)
                {
                    MediaPlayer1.Audio_PlayAudio = true;
                    MediaPlayer1.Audio_AdditionalStreams_Add(_audioInfoList[cbAudioStream.SelectedIndex - 1].Url!);
                }

                if (MediaPlayer1.Audio_PlayAudio)
                {
                    MediaPlayer1.Audio_OutputDevice = cbAudioOutput.Text;
                }

                await MediaPlayer1.PlayAsync();

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
                // Clear the drag guard so a Stop while the user was mid-drag
                // doesn't leave _seekDragging stuck true for the next Start.
                _seekDragging = false;

                await MediaPlayer1.StopAsync();
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
                    MessageBox.Show("Unable to read video formats.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Include muxed (video+audio) formats alongside video-only so the user can
                // see the audio situation per stream and pick a single-source format when
                // debugging seeking. Sort progressive (https/http) ahead of fragmented
                // DASH/HLS so the first listed item is the most likely to seek correctly.
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
                MessageBox.Show($"Unable to read video formats: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            // fill audio output devices
            var audioOutputs = MediaPlayer1.Audio_OutputDevices();
            foreach (var audioOutput in audioOutputs)
            {
                cbAudioOutput.Items.Add(audioOutput);
            }

            if (cbAudioOutput.Items.Count > 0)
            {
                cbAudioOutput.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the timer 1 tick event. Skips updates while the user is scrubbing so
        /// the thumb isn't yanked out from under the mouse/keys.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (MediaPlayer1 == null || _seekDragging)
                {
                    return;
                }

                int max = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;
                int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;

                if (_seekDragging)
                {
                    return;
                }

                if (max > 0 && tbTimeline.Maximum != max)
                {
                    tbTimeline.Maximum = max;
                }

                if (value > 0 && value < tbTimeline.Maximum)
                {
                    tbTimeline.Value = value;
                }

                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Timeline scroll — no longer seeks per tick. Just refreshes the preview label
        /// so the user sees the position they are scrubbing to. Seek is deferred to
        /// <see cref="tbTimeline_MouseUp"/> / <see cref="tbTimeline_KeyUp"/>.
        /// </summary>
        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (MediaPlayer1 == null)
                {
                    return;
                }

                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Arms the drag flag on left-button press so the timer doesn't fight the drag.
        /// </summary>
        private void tbTimeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (MediaPlayer1 == null || tbTimeline.Maximum <= 0)
            {
                return;
            }

            _seekDragging = true;
        }

        /// <summary>
        /// Performs the actual seek on mouse release. Gated on <see cref="_seekDragging"/>
        /// so a synthetic MouseUp without a matching MouseDown (touch, popup-steal, Alt-Tab
        /// returning focus) can't fire an unwanted seek.
        /// </summary>
        private async void tbTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_seekDragging)
            {
                return;
            }

            await PerformTimelineSeekAsync();
        }

        /// <summary>
        /// Same seek behavior for keyboard scrubbing (arrow / PageUp / PageDown / Home / End).
        /// Armed without a matching KeyDown because TrackBar's default handling already
        /// fires <see cref="tbTimeline_Scroll"/> on key press to update the preview; we only
        /// need KeyUp to commit the seek.
        /// </summary>
        private async void tbTimeline_KeyUp(object sender, KeyEventArgs e)
        {
            if (MediaPlayer1 == null || tbTimeline.Maximum <= 0)
            {
                return;
            }

            await PerformTimelineSeekAsync();
        }

        /// <summary>
        /// Shared body for MouseUp / KeyUp: reads the final slider value, logs the attempt,
        /// seeks via <see cref="MediaPlayerCore.Position_Set_TimeAsync"/>, and logs failure
        /// if the SDK returns <c>false</c> or throws.
        /// </summary>
        private async Task PerformTimelineSeekAsync()
        {
            var target = TimeSpan.Zero;
            try
            {
                if (MediaPlayer1 == null)
                {
                    return;
                }

                target = TimeSpan.FromSeconds(tbTimeline.Value);
                AppendLog($"Seeking to {target:hh\\:mm\\:ss}...");

                var ok = await MediaPlayer1.Position_Set_TimeAsync(target);
                if (!ok)
                {
                    AppendLog($"Seek to {target:hh\\:mm\\:ss} failed.");
                }
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
        /// protocol + container heuristics.
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
        /// protocol tag, and approximate size.
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
        /// Writes a short seekability hint for the selected format. For YouTube the
        /// decision is driven by itag (only 18 / 22 / 36 / 43 are progressive MP4
        /// with a full moov — everything else is a DASH fragment even when yt-dlp
        /// reports <c>protocol=https</c>).
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
                AppendLog($"{kind} stream: itag={itag}, protocol={protocol}, container={container} — DASH fragments (even though protocol reads {protocol}). For YouTube pick itag 18 or 22 to seek.");
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
            timer1.Stop();

            if (MediaPlayer1 != null)
            {
                await MediaPlayer1.StopAsync();
            }

            DestroyEngine();
        }
    }
}
