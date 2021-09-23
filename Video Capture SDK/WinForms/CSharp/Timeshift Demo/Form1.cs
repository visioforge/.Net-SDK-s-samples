using VisioForge.Types.Sources;
using VisioForge.Types.VideoEffects;

namespace VC_Timeshift_Demo
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";
            cbIPCameraType.SelectedIndex = 2;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.avi");

            foreach (var device in VideoCapture1.Video_CaptureDevicesInfo)
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
                cbVideoInputDevice_SelectedIndexChanged(null, null);
            }

            foreach (var device in VideoCapture1.Audio_CaptureDevicesInfo)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            cbOutputFormat.SelectedIndex = 0;

            if (VideoCapture.Filter_Supported_EVR())
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (VideoCapture.Filter_Supported_VMR9())
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (var format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format.Name);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                    cbVideoInputFormat_SelectedIndexChanged(null, null);
                }
                
                cbUseAudioInputFromVideoCaptureDevice.Enabled = deviceItem.AudioOutput;
            }
        }

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.Text))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.Text);
                if (videoFormat == null)
                {
                    return;
                }

                cbVideoInputFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Items.Clear();
            cbAudioInputLine.Items.Clear();

            if (cbUseAudioInputFromVideoCaptureDevice.Checked)
            {
                var deviceItem =
                    VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (string format in deviceItem.AudioFormats)
                    {
                        cbAudioInputFormat.Items.Add(format);
                    }

                    if (cbAudioInputFormat.Items.Count > 0)
                    {
                        cbAudioInputFormat.SelectedIndex = 0;
                    }
                }
            }
            else if (cbAudioInputDevice.SelectedIndex != -1)
            {
                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;

                var deviceItem = VideoCapture1.Audio_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (string format in deviceItem.Formats)
                    {
                        cbAudioInputFormat.Items.Add(format);
                    }

                    if (cbAudioInputFormat.Items.Count > 0)
                    {
                        cbAudioInputFormat.SelectedIndex = 0;
                    }

                    foreach (string line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                    }
                }
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

            if (rbVideoCaptureDevice.Checked)
            {
                VideoCapture1.Mode = VFVideoCaptureMode.VideoPreview;

                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
                VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
                VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
                VideoCapture1.Audio_CaptureDevice_Format_UseBest = cbUseBestAudioInputFormat.Checked;

                VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;
                VideoCapture1.Video_CaptureDevice_IsAudioSource = cbUseAudioInputFromVideoCaptureDevice.Checked;
                VideoCapture1.Video_CaptureDevice_Format_UseBest = cbUseBestVideoInputFormat.Checked;
                VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text;

                if (cbVideoInputFrameRate.SelectedIndex != -1)
                {
                    VideoCapture1.Video_CaptureDevice_FrameRate = Convert.ToDouble(cbVideoInputFrameRate.Text, CultureInfo.CurrentCulture);
                }
            }
            else
            {
                VideoCapture1.Mode = VFVideoCaptureMode.IPPreview;
                VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings
                {
                    URL = cbIPURL.Text
                };

                switch (cbIPCameraType.SelectedIndex)
                {
                    case 0:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_VLC;
                        break;
                    case 1:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_FFMPEG;
                        break;
                    case 2:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.Auto_LAV;
                        break;
                    case 3:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_Live555;
                        break;
                    case 4:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.MMS_WMV;
                        break;
                    case 5:
                        {
                            // audio not supported
                            VideoCapture1.IP_Camera_Source.Type = VFIPSource.HTTP_MJPEG_LowLatency;
                            VideoCapture1.Audio_RecordAudio = false;
                            VideoCapture1.Audio_PlayAudio = false;
                            cbIPAudioCapture.Checked = false;
                        }
                        break;
                    case 6:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                        VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = false;
                        break;
                    case 7:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.RTSP_LowLatency;
                        VideoCapture1.IP_Camera_Source.RTSP_LowLatency_UseUDP = true;
                        break;
                    case 8:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.NDI;
                        break;
                    case 9:
                        VideoCapture1.IP_Camera_Source.Type = VFIPSource.NDI_Legacy;
                        break;
                }

                VideoCapture1.IP_Camera_Source.AudioCapture = cbIPAudioCapture.Checked;
                VideoCapture1.IP_Camera_Source.Login = edIPLogin.Text;
                VideoCapture1.IP_Camera_Source.Password = edIPPassword.Text;
            }

            VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Audio_PlayAudio = false;

            VideoCapture1.Timeshift_Settings = new TimeshiftSettings
            {
                Player_Screen = MediaPlayer1,
                TempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "SBE"),
                Player_AudioOutput_Enabled = cbPlayerPlayAudio.Checked
            };

            var mp4Settings = new VFMP4Output
                                  {
                                      Video =
                                          {
                                              IDR_Period = 5
                                          }
                                  };

            VideoCapture1.Timeshift_Settings.EncodingSettings = mp4Settings;

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    {
                        VideoCapture1.Mode = rbVideoCaptureDevice.Checked
                            ? VFVideoCaptureMode.VideoCapture
                            : VFVideoCaptureMode.IPCapture;

                        VideoCapture1.Output_Filename = edOutput.Text;
                        
                        var output = new VFAVIOutput();
                        VideoCapture1.Output_Format = output;
                    }

                    break;
                case 2:
                    {
                        VideoCapture1.Mode = rbVideoCaptureDevice.Checked
                            ? VFVideoCaptureMode.VideoCapture
                            : VFVideoCaptureMode.IPCapture;

                        VideoCapture1.Output_Filename = edOutput.Text;
                        var output = new VFMP4Output();
                        VideoCapture1.Output_Format = output;
                    }

                    break;
                case 3:
                    {
                        VideoCapture1.Mode = rbVideoCaptureDevice.Checked
                            ? VFVideoCaptureMode.VideoCapture
                            : VFVideoCaptureMode.IPCapture;

                        VideoCapture1.Output_Filename = edOutput.Text;
                        var output = new VFWebMOutput();
                        VideoCapture1.Output_Format = output;
                    }

                    break;
            }

            VideoCapture1.Video_Effects_Clear();
            VideoCapture1.Video_Effects_Enabled = true;
            VideoCapture1.Video_Effects_Add(new VFVideoEffectTextLogo(true) {Mode = TextLogoMode.Timestamp, Text = string.Empty, Left = 150, Top = 10});

            await VideoCapture1.StartAsync();

            timer1.Interval = 1000;
            timer1.Enabled = true;
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.StopAsync();
            await VideoCapture1.StopAsync();
        }

        private async void btPlayerPause_Click(object sender, EventArgs e)
        {
            //VideoCapture1.Test();
            await MediaPlayer1.PauseAsync();
        }

        private async void btPlayerResume_Click(object sender, EventArgs e)
        {
            await MediaPlayer1.ResumeAsync();
        }

        private string FormatTime(TimeSpan span)
        {
            return span.ToString(@"hh\:mm\:ss");
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            var spanDur = await MediaPlayer1.Duration_TimeAsync();
            lbDuration.Text = FormatTime(spanDur);

            tbTimeline.Maximum = (int)spanDur.TotalSeconds;

            TimeSpan spanPos;
            var pos = await MediaPlayer1.Position_Get_TimeAsync();
            if (pos < spanDur)
            {
                spanPos = pos;
                tbTimeline.Value = (int)pos.TotalSeconds;
            }
            else
            {
                spanPos = spanDur;
                tbTimeline.Value = (int)spanDur.TotalSeconds;
            }

            lbPostion.Text = FormatTime(spanPos);
        }

        private void tbTimeline_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        private async void tbTimeline_MouseUp(object sender, MouseEventArgs e)
        {
            await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));

            timer1.Enabled = true;
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

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void VideoCapture1_OnTimeshiftFileCreated(object sender, TimeshiftFileEventArgs e)
        {
            MediaPlayer1.Debug_Mode = true;
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            string filename = e.Filename;

            MediaPlayer1.FilenamesOrURL.Clear();
            MediaPlayer1.FilenamesOrURL.Add(filename);

            MediaPlayer1.Source_Mode = VFMediaPlayerSource.Timeshift;

            await MediaPlayer1.PlayAsync();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
