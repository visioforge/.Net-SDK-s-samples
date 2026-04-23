namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;

    using ManuHub.Ytdlp.NET;
using System.Diagnostics;

    /// <summary>
    /// The main form of the application.
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
        /// Destroy engine async.
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

                // video stream
                var selectedVideoFormat = _videoInfoList[cbVideoStream.SelectedIndex];
                var audioMuxed = !string.IsNullOrEmpty(selectedVideoFormat.Acodec) && selectedVideoFormat.Acodec != "none";
                var videoSourceSettings = await UniversalSourceSettings.CreateAsync(new Uri(selectedVideoFormat.Url!), ignoreMediaInfoReader: true);
                _videoSource = new UniversalSourceBlock(videoSourceSettings);

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                _pipeline.Connect(_videoSource, _videoRenderer);

                // audio stream
                var audioOutputs = await AudioRendererBlock.GetDevicesAsync(VisioForge.Core.Types.X.Output.AudioOutputDeviceAPI.DirectSound);
                _audioRenderer = new AudioRendererBlock(audioOutputs[cbAudioOutput.SelectedIndex]);

                if (audioMuxed)
                {
                    _pipeline.Connect(_videoSource, _audioRenderer);
                }
                else
                {
                    if (cbAudioStream.SelectedIndex > 0)
                    {
                        var audioSourceSettings = await UniversalSourceSettings.CreateAsync(new Uri(_audioInfoList[cbAudioStream.SelectedIndex - 1].Url!), ignoreMediaInfoReader: true);
                        _audioSource = new UniversalSourceBlock(audioSourceSettings);

                        _pipeline.Connect(_audioSource, _audioRenderer);
                    }
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

                await _pipeline.StopAsync();

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

                // Video-only streams
                var videos = formats.Where(f =>
                    !string.IsNullOrEmpty(f.Vcodec) && f.Vcodec != "none" &&
                    (string.IsNullOrEmpty(f.Acodec) || f.Acodec == "none") &&
                    !string.IsNullOrEmpty(f.Url));

                foreach (var stream in videos)
                {
                    cbVideoStream.Items.Add($"{stream.Format ?? stream.FormatId} [{stream.Ext}]");
                    _videoInfoList.Add(stream);
                }

                // Audio-only streams
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
