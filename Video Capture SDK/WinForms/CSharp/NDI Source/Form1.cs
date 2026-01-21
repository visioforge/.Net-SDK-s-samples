using System;
using System.IO;
using System.Threading.Tasks;
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

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the tab page 1 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CreateEngineAsync();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
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

        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">The text.</param>
        private void Log(string txt)
        {
            if (IsHandleCreated)
            {
                Invoke((Action)(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; }));
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the bt list ndi sources click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Form 1 form closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyEngine();
        }
    }
}