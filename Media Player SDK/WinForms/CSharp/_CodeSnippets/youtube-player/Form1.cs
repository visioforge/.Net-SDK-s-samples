namespace youtube_player
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using VisioForge.Types;

    public partial class Form1 : Form
    {
        private List<YouTubeVideoInfo> _videoInfoList;

        public Form1()
        {
            InitializeComponent();

            _videoInfoList = new List<YouTubeVideoInfo>();
        }

        private async void BtStart_Click(object sender, EventArgs e)
        {
            if (_videoInfoList.Count == 0)
            {
                MessageBox.Show("Please read formats first.");
                return;
            }

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.LAV;
            MediaPlayer1.FilenamesOrURL.Clear();
            MediaPlayer1.FilenamesOrURL.Add(_videoInfoList[cbFormat.SelectedIndex].Uri);

            await MediaPlayer1.PlayAsync();
        }

        private async void BtStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void MediaPlayer1_OnYouTubeVideoPlayback(object sender, YouTubeVideoPlaybackEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       if (cbFormat.Items.Count > 0)
                                       {
                                           e.SelectedFormatIndex = cbFormat.SelectedIndex;
                                       }
                                   }));
        }

        private void BtReadFormats_Click(object sender, EventArgs e)
        {
            cbFormat.Items.Clear();
            _videoInfoList = MediaPlayer1.YouTube_GetURLInfo(edURL.Text);
            foreach (var info in _videoInfoList)
            {
                cbFormat.Items.Add(info.ToString());
            }

            cbFormat.SelectedIndex = 0;
        }
    }
}
