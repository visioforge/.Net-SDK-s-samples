namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;

    using YoutubeExplode;
    using YoutubeExplode.Videos.Streams;

    public partial class Form1 : Form
    {
        private readonly List<IVideoStreamInfo> _videoInfoList = new List<IVideoStreamInfo>();

        private readonly List<IAudioStreamInfo> _audioInfoList = new List<IAudioStreamInfo>();

        private volatile int _timeTag;

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
                MessageBox.Show("Please read formats first.");
                return;
            }

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.LAV;
            MediaPlayer1.Audio_PlayAudio = false;

            MediaPlayer1.Audio_AdditionalStreams_Clear();

            MediaPlayer1.FilenamesOrURL.Clear();
            MediaPlayer1.FilenamesOrURL.Add(_videoInfoList[cbVideoStream.SelectedIndex].Url);

            if (_videoInfoList[cbVideoStream.SelectedIndex].ToString().Contains("Muxed"))
            {
                MediaPlayer1.Audio_PlayAudio = true;
            }

            if (cbAudioStream.SelectedIndex > 0)
            {
                MediaPlayer1.Audio_PlayAudio = true;
                MediaPlayer1.Audio_AdditionalStreams_Add(_audioInfoList[cbAudioStream.SelectedIndex].Url);
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
                cbAudioStream.Items.Add(stream.ToString());
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
            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _timeTag = 1;
            tbTimeline.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;

            int value = (int)MediaPlayer1.Position_Get_Time().TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            _timeTag = 0;
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (_timeTag == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }
    }
}
