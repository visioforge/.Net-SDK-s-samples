namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using YoutubeExplode;
    using YoutubeExplode.Videos.Streams;

    public partial class Form1 : Form
    {
        private readonly List<IVideoStreamInfo> _videoInfoList = new List<IVideoStreamInfo>();

        private readonly List<IAudioStreamInfo> _audioInfoList = new List<IAudioStreamInfo>();

        private volatile int _timeTag;

        private MediaPlayerCore MediaPlayer1;

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
        }

        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void BtStart_Click(object sender, EventArgs e)
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
            MediaPlayer1.Playlist_Add(_videoInfoList[cbVideoStream.SelectedIndex].Url);

            if (_videoInfoList[cbVideoStream.SelectedIndex].ToString().Contains("Muxed"))
            {
                MediaPlayer1.Audio_PlayAudio = true;
            }

            if (cbAudioStream.SelectedIndex > 0)
            {
                MediaPlayer1.Audio_PlayAudio = true;
                MediaPlayer1.Audio_AdditionalStreams_Add(_audioInfoList[cbAudioStream.SelectedIndex].Url);
            }

            if (MediaPlayer1.Audio_PlayAudio)
            {
                MediaPlayer1.Audio_OutputDevice = cbAudioOutput.Text;
            }

            await MediaPlayer1.PlayAsync();

            timer1.Start();
        }

        private async void BtStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await MediaPlayer1.StopAsync();
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                                   }));
        }

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

        private async void timer1_Tick(object sender, EventArgs e)
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

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (_timeTag == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
