// ReSharper disable InconsistentNaming

namespace Memory_Stream_Demo
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Types;

    public partial class Form1 : Form
    {
        private ManagedIStream _stream;

        private FileStream _fileStream;

        private MemoryStream _memoryStream;

        private byte[] _memorySource;

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

        private void tbTimeline_Scroll(object sender, EventArgs e)
        {
            if (Convert.ToInt32(timer1.Tag) == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmError.Text = string.Empty;

            if (rbSTreamTypeFile.Checked)
            {
                _fileStream = new FileStream(edFilename.Text, FileMode.Open);
                _stream = new ManagedIStream(_fileStream);

                // specifying settings
                MediaPlayer1.Source_Stream = _stream;
                MediaPlayer1.Source_Stream_Size = _fileStream.Length;
            }
            else
            {
                _memorySource = File.ReadAllBytes(edFilename.Text);
                _memoryStream = new MemoryStream(_memorySource);
                _stream = new ManagedIStream(_memoryStream);

                // specifying settings
                MediaPlayer1.Source_Stream = _stream;
                MediaPlayer1.Source_Stream_Size = _memoryStream.Length;
            }

            // video and audio present in file. tune this settings to play audio files or video files without audio
            if (rbVideoWithAudio.Checked)
            {
                MediaPlayer1.Source_Stream_VideoPresent = true;
                MediaPlayer1.Source_Stream_AudioPresent = true;
            }
            else if (rbVideoWithoutAudio.Checked)
            {
                MediaPlayer1.Source_Stream_VideoPresent = true;
                MediaPlayer1.Source_Stream_AudioPresent = false;
            }
            else
            {
                MediaPlayer1.Source_Stream_VideoPresent = false;
                MediaPlayer1.Source_Stream_AudioPresent = true;
            }

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.Memory_DS;

            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            if (FilterHelpers.Filter_Supported_EVR())
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (FilterHelpers.Filter_Supported_VMR9())
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else
            {
                MediaPlayer1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }

            MediaPlayer1.Debug_Mode = cbDebugMode.Checked;
            await MediaPlayer1.PlayAsync();

            tbTimeline.Maximum = (int)MediaPlayer1.Duration_Time().TotalSeconds;
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{MediaPlayer1.SDK_Version})";
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

        private async void btStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();
            timer1.Enabled = false;
            tbTimeline.Value = 0;

            _fileStream?.Dispose();
            _fileStream = null;

            _memoryStream?.Dispose();
            _memoryStream = null;

            _memorySource = null;
            _stream = null;
        }

        private void btNextFrame_Click(object sender, EventArgs e)
        {
            MediaPlayer1.NextFrame();
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.SetSpeed(tbSpeed.Value / 10.0);
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Volume_Set(0, tbVolume1.Value);
        }

        private void tbBalance1_Scroll(object sender, EventArgs e)
        {
            MediaPlayer1.Audio_OutputDevice_Balance_Set(0, tbBalance1.Value);
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

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmError.Text = mmError.Text + e.Message + Environment.NewLine;
                                   }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);
        }

        private void MediaPlayer1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       if (cbLicensing.Checked)
                                       {
                                           mmError.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
                                       }
                                   }));
        }
    }
}

// ReSharper restore InconsistentNaming