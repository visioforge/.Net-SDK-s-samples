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
    using ManuHub.Ytdlp.NET;
using System.Diagnostics;

    /// <summary>
    /// YouTube player demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video info list.
        /// </summary>
        private readonly List<FormatMetadata> _videoInfoList = new List<FormatMetadata>();

        /// <summary>
        /// The audio info list.
        /// </summary>
        private readonly List<FormatMetadata> _audioInfoList = new List<FormatMetadata>();

        /// <summary>
        /// The time tag.
        /// </summary>
        private volatile int _timeTag;

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

                MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;
                MediaPlayer1.Audio_PlayAudio = false;

                MediaPlayer1.Audio_AdditionalStreams_Clear();

                MediaPlayer1.Playlist_Clear();
                var selectedVideoFormat = _videoInfoList[cbVideoStream.SelectedIndex];
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.Acodec) && selectedVideoFormat.Acodec != "none";

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

                var ytdlpPath = Path.Combine(AppContext.BaseDirectory, "tools", "yt-dlp.exe");
                var denoPath = Path.Combine(AppContext.BaseDirectory, "tools", "deno.exe");

                await using var ytdlp = new Ytdlp(ytdlpPath)
                    .WithJsRuntime(Runtime.Deno, denoPath);

                var metadata = await ytdlp.GetMetadataAsync(edURL.Text);
                var formats = metadata?.Formats;

                if (formats == null)
                {
                    MessageBox.Show(this, "Could not retrieve formats.");
                    return;
                }

                var videos = formats.Where(f =>
                    !string.IsNullOrEmpty(f.Vcodec) && f.Vcodec != "none" &&
                    (string.IsNullOrEmpty(f.Acodec) || f.Acodec == "none") &&
                    !string.IsNullOrEmpty(f.Url));

                foreach (var stream in videos)
                {
                    cbVideoStream.Items.Add($"{stream.Format ?? stream.FormatId} [{stream.Ext}]");
                    _videoInfoList.Add(stream);
                }

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
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _timeTag = 1;
                tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

                int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
                if ((value > 0) && (value < tbTimeline.Maximum))
                {
                    tbTimeline.Value = value;
                }

                lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

                _timeTag = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (_timeTag == 0)
                {
                    await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
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
