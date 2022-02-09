namespace VR_360_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.UI;
    using VisioForge.MediaFramework;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.MediaPlayer;
    using VisioForge.Types.VideoEffects;

    public partial class Form1 : Form
    {
        private IGPUVideoEffectVR360Base vr = new GPUVideoEffectVR360Base(false);

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
        }

        private void btSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private async void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Clear();

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;

            MediaPlayer1.FilenamesOrURL.Add(edFilename.Text);
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            if (FilterHelpers.Filter_Supported_EVR())
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR;
            }
            else if (FilterHelpers.Filter_Supported_VMR9())
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.VMR9;
            }
            else
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.VideoRenderer;
            }

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

        private async void btStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();

            timer1.Enabled = false;
            tbTimeline.Value = 0;
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

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

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbTimeline.Value = 0;
                                   }));
        }

        private void bt360Left_Click(object sender, EventArgs e)
        {
            vr.Yaw -= 2.0f;
            vr.UpdateRequired = true;
        }

        private void bt360Right_Click(object sender, EventArgs e)
        {
            vr.Yaw += 2.0f;
            vr.UpdateRequired = true;
        }

        private void bt360Up_Click(object sender, EventArgs e)
        {
            vr.Pitch -= 2.0f;
            vr.UpdateRequired = true;
        }

        private void bt360Down_Click(object sender, EventArgs e)
        {
            vr.Pitch += 2.0f;
            vr.UpdateRequired = true;
        }

        private void btZoomIn_Click(object sender, EventArgs e)
        {
            vr.Fov -= 2.0f;
            vr.UpdateRequired = true;
        }

        private void btZoomOut_Click(object sender, EventArgs e)
        {
            vr.Fov += 2.0f;
            vr.UpdateRequired = true;
        }

        private void tbRoll_Scroll(object sender, EventArgs e)
        {
            vr.Roll = tbRoll.Value;
            vr.UpdateRequired = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}
