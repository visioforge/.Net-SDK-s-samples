namespace VR_360_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.UI;

    /// <summary>
    /// VR 360 demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The VR 360 effect.
        /// </summary>
        private IGPUVideoEffectVR360Base vr = new GPUVideoEffectVR360Base(false);

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// The X coordinate.
        /// </summary>
        private int _x = 0;

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        private int _y = 0;

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
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
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
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            _x = 0;
            _y = 0;

            mmError.Clear();

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer_SetAuto();

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;


            MediaPlayer1.Video_Effects_GPU_Enabled = true;
            MediaPlayer1.Video_Effects_GPU_Clear();

            if (rbVRCubemap.Checked)
            {
                vr = new GPUVideoEffectEquiangularCubemap360(true, 0, 0, 0, 80, "VR");
            }
            else
            {
                vr = new GPUVideoEffectEquirectangular360(true, 0, 0, 0, 80, "VR");
            }

            MediaPlayer1.Video_Effects_GPU_Add(vr);
            // MediaPlayer1.Video_Effects_GPU_Add(new GPUVideoEffectEquirectangular360(true));

            await MediaPlayer1.PlayAsync();

            // set audio volume for each stream
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);

            timer1.Enabled = true;
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();

            timer1.Enabled = false;
            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        /// <summary>
        /// Handles the tb volume 1 scroll event.
        /// </summary>
        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        /// <summary>
        /// Handles the tb balance 1 scroll event.
        /// </summary>
        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
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
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        /// <summary>
        /// Media player 1 on stop.
        /// </summary>
        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));
        }

        /// <summary>
        /// Handles the bt 360 left click event.
        /// </summary>
        private void bt360Left_Click(object sender, EventArgs e)
        {
            vr.Yaw -= 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the bt 360 right click event.
        /// </summary>
        private void bt360Right_Click(object sender, EventArgs e)
        {
            vr.Yaw += 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the bt 360 up click event.
        /// </summary>
        private void bt360Up_Click(object sender, EventArgs e)
        {
            vr.Pitch -= 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the bt 360 down click event.
        /// </summary>
        private void bt360Down_Click(object sender, EventArgs e)
        {
            vr.Pitch += 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the bt zoom in click event.
        /// </summary>
        private void btZoomIn_Click(object sender, EventArgs e)
        {
            vr.Fov -= 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the bt zoom out click event.
        /// </summary>
        private void btZoomOut_Click(object sender, EventArgs e)
        {
            vr.Fov += 2.0f;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Handles the tb roll scroll event.
        /// </summary>
        private void tbRoll_Scroll(object sender, EventArgs e)
        {
            vr.Roll = tbRoll.Value;
            vr.UpdateRequired = true;
        }

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Video view 1 mouse down.
        /// </summary>
        private void VideoView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left))
            {
                _x = e.X;
                _y = e.Y;
            }
        }

        /// <summary>
        /// Video view 1 mouse move.
        /// </summary>
        private void VideoView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (VideoView1 is null)
            {
                return;
            }

            if (e.Button.HasFlag(MouseButtons.Left))
            {
                vr.Yaw += (e.X - _x) * 2;
                _x = e.X;

                vr.Pitch += (e.Y - _y) * 2;
                _y = e.Y;

                vr.UpdateRequired = true;
            }
        }
    }
}
