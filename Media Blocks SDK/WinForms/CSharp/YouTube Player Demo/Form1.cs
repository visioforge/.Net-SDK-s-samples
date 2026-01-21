namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.AudioRendering;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.MediaBlocks.VideoRendering;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Sources;

    using YoutubeExplode;
    using YoutubeExplode.Videos.Streams;

    /// <summary>
    /// The main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The video info list.
        /// </summary>
        private readonly List<IVideoStreamInfo> _videoInfoList = new List<IVideoStreamInfo>();

        /// <summary>
        /// The audio info list.
        /// </summary>
        private readonly List<IAudioStreamInfo> _audioInfoList = new List<IAudioStreamInfo>();

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

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void BtStart_Click(object sender, EventArgs e)
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
            var videoSourceSettings = await UniversalSourceSettings.CreateAsync(_videoInfoList[cbVideoStream.SelectedIndex].Url);
            var audioMuxed = videoSourceSettings.GetInfo().AudioStreams.Count > 0;
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
                    var audioSourceSettings = await UniversalSourceSettings.CreateAsync(_audioInfoList[cbAudioStream.SelectedIndex].Url);
                    _audioSource = new UniversalSourceBlock(audioSourceSettings);

                    _pipeline.Connect(_audioSource, _audioRenderer);
                }
            }

            // start
            await _pipeline.StartAsync();

            timer1.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void BtStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline.StopAsync();

            await DestroyEngineAsync();
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
            _videoInfoList.Clear();
            _audioInfoList.Clear();

            cbVideoStream.Items.Clear();
            cbAudioStream.Items.Clear();
            cbAudioStream.Items.Add("None");

            var youtube = new YoutubeClient();

            // You can specify video ID or URL
            var video = await youtube.Videos.GetAsync(edURL.Text);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id.Value);

            var videos = streamManifest.GetVideoOnlyStreams();
            foreach (var stream in videos)
            {
                cbVideoStream.Items.Add(stream.ToString());
                _videoInfoList.Add(stream);
            }

            var audios = streamManifest.GetAudioOnlyStreams();
            foreach (var stream in audios)
            {
                cbAudioStream.Items.Add($"{stream.ToString()} [{stream.Bitrate.ToString()}]");
                _audioInfoList.Add(stream);
            }

            if (cbVideoStream.Items.Count > 0)
            {
                cbVideoStream.SelectedIndex = 0;
            }

            cbAudioStream.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private async void Form1_Load(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            var duration = await _pipeline.DurationAsync();
            var position = await _pipeline.Position_GetAsync();

            lbTime.Text = position.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture) + " | " + duration.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }
    }
}
