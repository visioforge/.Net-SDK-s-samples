namespace Video_Mixing_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.UI;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.MediaPlayer;

    public partial class Form1 : Form
    {
        private readonly List<PIPInfo> _pipInfos;

        private int _lastZOrder = 8;

        private MediaPlayerCore MediaPlayer1;

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        private void DestroyEngine()
        {
            MediaPlayer1.OnError -= MediaPlayer1_OnError;
            MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

            MediaPlayer1.Dispose();
            MediaPlayer1 = null;
        }

        public Form1()
        {
            InitializeComponent();

            _pipInfos = new List<PIPInfo>();
        }

        private void AddFile(string filename)
        {
            var info = new PIPInfo();

            // first file should be added as usual, other files using PIP API
            if (MediaPlayer1.FilenamesOrURL.Count == 0)
            {
                MediaPlayer1.FilenamesOrURL.Add(filename);
                lbSourceFiles.Items.Add($@"{filename} (entire screen)");
                info.Rect = new Rectangle(0, 0, 0, 0);
                info.Alpha = 1.0f;
            }
            else
            {
                int left = Convert.ToInt32(edPIPFileLeft.Text);
                int top = Convert.ToInt32(edPIPFileTop.Text);
                int width = Convert.ToInt32(edPIPFileWidth.Text);
                int height = Convert.ToInt32(edPIPFileHeight.Text);

                MediaPlayer1.PIP_Sources_Add(filename, left, top, width, height);
                lbSourceFiles.Items.Add($@"{filename} ({left}.{top}px, width: {width}px, height: {height}px)");
                info.Rect = new Rectangle(left, top, width, height);

                info.Alpha = tbStreamTransparency.Value / 100.0f;
            }

            info.Filename = filename;
            info.ZOrder = _lastZOrder--;

            _pipInfos.Add(info);

            //lbSourceFiles.SelectedIndex = _pipInfos.Count - 1;
        }

        private void btAddFileToPlaylist_Click(object sender, EventArgs e)
        {
            var filename = edFilenameOrURL.Text;
            AddFile(filename);
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            MediaPlayer1.Info_UseLibMediaInfo = true;

            mmLog.Clear();

            MediaPlayer1.Video_Renderer.Zoom_Ratio = 0;
            MediaPlayer1.Video_Renderer.Zoom_ShiftX = 0;
            MediaPlayer1.Video_Renderer.Zoom_ShiftY = 0;

            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9;
            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;

            await MediaPlayer1.PlayAsync();

            await MediaPlayer1.PIP_Sources_SetSourcePositionAsync(0, _pipInfos[0].Rect, 1.0f);

            lbSourceFiles.SelectedIndex = 0;

            timer1.Start();
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            string filename1 = @"e:\_movies\The Mighty Boosh.Saliour Tour 2009.mkv";
            string filename2 = @"e:\_TV\The Mighty Boosh\s02e05.mkv";
            //string filename2 = @"c:\samples\!video.avi";
            //string filename2 = @"c:\samples\!video.avi";
            //string filename2 = @"c:\samples\Biking_Girl_Alpha.mov";

            AddFile(filename1);
            AddFile(filename2);
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await MediaPlayer1.StopAsync();

            _pipInfos.Clear();
            MediaPlayer1.PIP_Sources_Clear();
            lbSourceFiles.Items.Clear();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            edScreenshotsFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private void lbSourceFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSourceFiles.SelectedIndex >= 0)
            {
                var pip = _pipInfos[lbSourceFiles.SelectedIndex];
                edPIPFileLeft.Text = pip.Rect.Left.ToString();
                edPIPFileTop.Text = pip.Rect.Top.ToString();
                edPIPFileWidth.Text = pip.Rect.Width.ToString();
                edPIPFileHeight.Text = pip.Rect.Height.ToString();

                edZOrder.Text = pip.ZOrder.ToString();
                tbStreamTransparency.Value = (int)(pip.Alpha * 100);
            }
        }

        private async void btUpdateRect_Click(object sender, EventArgs e)
        {
            int index = lbSourceFiles.SelectedIndex;
            if (index >= 0)
            {
                int left = Convert.ToInt32(edPIPFileLeft.Text);
                int top = Convert.ToInt32(edPIPFileTop.Text);
                int width = Convert.ToInt32(edPIPFileWidth.Text);
                int height = Convert.ToInt32(edPIPFileHeight.Text);
                _pipInfos[index].Rect = new Rectangle(left, top, width, height);

                _pipInfos[index].ZOrder = Convert.ToInt32(edZOrder.Text);
                _pipInfos[index].Alpha = tbStreamTransparency.Value / 100.0f;

                if (left == 0 && top == 0 && width == 0 && height == 0)
                {
                    lbSourceFiles.Items[index] = $@"{_pipInfos[index].Filename} (entire screen)";
                }
                else
                {
                    lbSourceFiles.Items[index] = $@"{_pipInfos[index].Filename} ({left}.{top}px, width: {width}px, height: {height}px)";
                }

                var transp = tbStreamTransparency.Value / 100.0f;
                await MediaPlayer1.PIP_Sources_SetSourcePositionAsync(
                        index,
                        _pipInfos[index].Rect,
                        transp);
                await MediaPlayer1.PIP_Sources_SetSourceOrderAsync(index, _pipInfos[index].ZOrder);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            cbSourceMode.SelectedIndex = 0;
        }

        private void tbStreamTransparency_Scroll(object sender, EventArgs e)
        {
            lbStreamTransparency.Text = tbStreamTransparency.Value.ToString();
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate(StopDelegateMethod), null);
        }

        private delegate void StopDelegate();

        private void StopDelegateMethod()
        {
            tbTimeline.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;

            int value = (int)MediaPlayer1.Position_Get_Time().TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            timer1.Tag = 0;
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.SetSpeed(tbSpeed.Value / 10.0);
        }

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MediaPlayer1.State() != PlaybackState.Free)
            {
                await MediaPlayer1.StopAsync();
            }

            DestroyEngine();
        }
    }
}
