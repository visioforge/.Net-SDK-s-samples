using System;
using System.IO;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.VideoCapture;

namespace NDI_Source
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCore VideoCapture1;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }

        private void UpdateRecordingTime()
        {
            if (IsHandleCreated)
            {
                var ts = VideoCapture1.Duration_Time();

                if (Math.Abs(ts.TotalMilliseconds) < 0.01)
                {
                    return;
                }

                BeginInvoke(
                    (Action)(() =>
                    {
                        lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
                    }));
            }
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_RecordAudio = cbIPAudioCapture.Checked;
            VideoCapture1.Audio_PlayAudio = cbIPAudioCapture.Checked;

            VideoCapture1.Video_Renderer_SetAuto();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            // source
            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
            {
                URL = new Uri(cbIPURL.Text, System.UriKind.Absolute)
            };

            VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.NDI;

            VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.Checked;
            VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text;
            VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text;

            if (rbPreview.Checked)
            {
                VideoCapture1.Mode = VideoCaptureMode.IPPreview;
            }
            else if (rbCapture.Checked)
            {
                VideoCapture1.Mode = VideoCaptureMode.IPCapture;
                VideoCapture1.Output_Filename = edOutput.Text;

                var mp4Output = new MP4Output();
                VideoCapture1.Output_Format = mp4Output;
            }

            VideoView1.StatusOverlay = new TextStatusOverlay();

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void btListNDISources_Click(object sender, EventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await VideoCapture1.IP_Camera_NDI_ListSourcesAsync();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}