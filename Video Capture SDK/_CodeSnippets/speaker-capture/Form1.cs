using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace speaker_capture
{
    using System.IO;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;

    /// <summary>
    /// Speaker capture demo main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private VideoCaptureCore VideoCapture1;

        private TimeSpan _currentTimestamp;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Log.
        /// </summary>
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
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCapture1 = new VideoCaptureCore();

            Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp3");

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnAudioFrameBuffer += VideoCapture1_OnAudioFrameBuffer;
        }

        /// <summary>
        /// Video capture 1 on audio frame buffer.
        /// </summary>
        private void VideoCapture1_OnAudioFrameBuffer(object sender, AudioFrameBufferEventArgs e)
        {
            _currentTimestamp = e.Frame.Timestamp;
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource("VisioForge What You Hear Source");
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = true;

            VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Audio_PlayAudio = true;

            VideoCapture1.Mode = VideoCaptureMode.AudioCapture;

            VideoCapture1.Output_Format = new MP3Output();
            VideoCapture1.Output_Filename = edOutput.Text;

            VideoCapture1.Audio_Sample_Grabber_Enabled = true;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;

            _currentTimestamp = TimeSpan.Zero;

            await VideoCapture1.StartAsync();

            timer1.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.StopAsync();

            timer1.Stop();
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTimestamp.Text = _currentTimestamp.ToString(@"hh\:mm\:ss");
        }
    }
}
