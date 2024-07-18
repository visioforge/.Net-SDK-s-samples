// ReSharper disable InconsistentNaming

namespace Memory_Stream_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using VisioForge.Core;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.UI;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.MediaInfo;
    using System.Threading.Tasks;

    public partial class Form1 : Form
    {
        private ManagedIStream _stream;

        private FileStream _fileStream;

        private MemoryStream _memoryStream;

        private byte[] _memorySource;

        private MediaPlayerCore MediaPlayer1;

        public Form1()
        {
            InitializeComponent();
        }

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
            mmError.Text = string.Empty;
            bool videoAvailable;
            bool audioAvailable;

            if (rbSTreamTypeFile.Checked)
            {
                _fileStream = new FileStream(edFilename.Text, FileMode.Open);
                _stream = new ManagedIStream(_fileStream);

                MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _fileStream.Length, out videoAvailable, out audioAvailable);

                // specifying settings
                MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoAvailable, audioAvailable, _fileStream.Length);
            }
            else
            {
                _memorySource = File.ReadAllBytes(edFilename.Text);
                _memoryStream = new MemoryStream(_memorySource);
                _stream = new ManagedIStream(_memoryStream);

                MediaInfoReader.GetStreamAvailabilityFromMemoryStream(MediaPlayer1.GetContext(), _stream, _memoryStream.Length, out videoAvailable, out audioAvailable);

                // specifying settings
                MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(_stream, videoAvailable, audioAvailable, _memoryStream.Length);
            }

            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS;

            if (audioAvailable)
            {
                MediaPlayer1.Audio_PlayAudio = true;
                MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";
            }
            else
            {
                MediaPlayer1.Audio_PlayAudio = false;
            }

            if (videoAvailable)
            {
                MediaPlayer1.Video_Renderer_SetAuto();
            }
            else
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            }

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            await MediaPlayer1.PlayAsync();

            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateEngine();

            Text += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.PauseAsync();
        }

        private async Task StopAsync()
        {
            await MediaPlayer1.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;

            if (_fileStream != null)
            {
                _fileStream.Dispose();
                _fileStream = null;
            }

            if (_memoryStream != null)
            {
                _memoryStream.Dispose();
                _memoryStream = null;
            }

            _memorySource = null;
            _stream = null;
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await StopAsync();
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
        }

        private async void tbSpeed_Scroll(object sender, EventArgs e)
        {
            await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
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

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await StopAsync();

            DestroyEngine();
        }
    }
}

// ReSharper restore InconsistentNaming