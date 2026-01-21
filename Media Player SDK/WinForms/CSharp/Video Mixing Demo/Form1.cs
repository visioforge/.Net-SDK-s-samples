namespace Video_Mixing_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.UI;

    /// <summary>
    /// Video mixing demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The list of PIP info.
        /// </summary>
        private readonly List<PIPInfo> _pipInfos;

        /// <summary>
        /// The last Z order.
        /// </summary>
        private int _lastZOrder = 8;

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
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;

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

            _pipInfos = new List<PIPInfo>();
        }

        /// <summary>
        /// Add file.
        /// </summary>
        private void AddFile(string filename)
        {
            var info = new PIPInfo();

            // first file should be added as usual, other files using PIP API
            if (MediaPlayer1.Playlist_GetCount() == 0)
            {
                MediaPlayer1.Playlist_Add(filename);
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

        /// <summary>
        /// Handles the bt add file to playlist click event.
        /// </summary>
        private void btAddFileToPlaylist_Click(object sender, EventArgs e)
        {
            var filename = edFilenameOrURL.Text;
            AddFile(filename);
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Link label 1 link clicked.
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
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
        /// Handles the bt test click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await MediaPlayer1.StopAsync();

            _pipInfos.Clear();
            MediaPlayer1.PIP_Sources_Clear();
            lbSourceFiles.Items.Clear();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        /// <summary>
        /// Handles the form 1 shown event.
        /// </summary>
        private void Form1_Shown(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            edScreenshotsFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Handles the lb source files selected index changed event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt update rect click event.
        /// </summary>
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

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
        }

        /// <summary>
        /// Handles the tb stream transparency scroll event.
        /// </summary>
        private void tbStreamTransparency_Scroll(object sender, EventArgs e)
        {
            lbStreamTransparency.Text = tbStreamTransparency.Value.ToString();
        }

        /// <summary>
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            BeginInvoke(new StopDelegate(StopDelegateMethod), null);
        }

        private delegate void StopDelegate();

        /// <summary>
        /// Stop delegate method.
        /// </summary>
        private void StopDelegateMethod()
        {
            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;
            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted(tbTimeline.Maximum);

            timer1.Tag = 0;
        }

        /// <summary>
        /// Handles the tb speed scroll event.
        /// </summary>
        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
        }

        /// <summary>
        /// Handles the tb timeline scroll event.
        /// </summary>
        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        /// <summary>
        /// Form 1 form closed.
        /// </summary>
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
