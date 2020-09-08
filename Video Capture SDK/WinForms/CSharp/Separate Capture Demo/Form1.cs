using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Separate_Capture_Demo
{
    using System.Diagnostics;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.VideoEffects;

    public partial class Form1 : Form
    {
        private MFSettingsDialog mp4v11SettingsDialog;

        private MFSettingsDialog mpegTSSettingsDialog;

        private MFSettingsDialog movSettingsDialog;

        private MP4v10SettingsDialog mp4V10SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private readonly System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            cbOutputFormat.SelectedIndex = 6;

            foreach (var device in VideoCapture1.Video_CaptureDevicesInfo)
            {
                cbVideoInputDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
            }

            cbVideoInputDevice_SelectedIndexChanged(null, null);

            foreach (var device in VideoCapture1.Audio_CaptureDevicesInfo)
            {
                cbAudioInputDevice.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectedIndexChanged(null, null);
            }

            cbAudioInputLine.Items.Clear();

            if (!string.IsNullOrEmpty(cbAudioInputDevice.Text))
            {
                var deviceItem =
                    VideoCapture1.Audio_CaptureDevicesInfo.First(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
                    foreach (string line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                        cbAudioInputLine_SelectedIndexChanged(null, null);
                        cbAudioInputFormat_SelectedIndexChanged(null, null);
                    }
                }
            }

            string defaultAudioRenderer = string.Empty;
            foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices)
            {
                cbAudioOutputDevice.Items.Add(audioOutputDevice);

                if (audioOutputDevice.Contains("Default DirectSound Device"))
                {
                    defaultAudioRenderer = audioOutputDevice;
                }
            }

            if (cbAudioOutputDevice.Items.Count > 0)
            {
                if (string.IsNullOrEmpty(defaultAudioRenderer))
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
                else
                {
                    cbAudioOutputDevice.Text = defaultAudioRenderer;
                }
            }

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";
            edNewFilename.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output_new.mp4";

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

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            VideoCapture1.Audio_OutputDevice = "Default DirectSound Device";

            if (cbRecordAudio.Checked)
            {
                VideoCapture1.Audio_RecordAudio = true;
                VideoCapture1.Audio_PlayAudio = true;
            }
            else
            {
                VideoCapture1.Audio_RecordAudio = false;
                VideoCapture1.Audio_PlayAudio = false;
            }

            // apply capture parameters
            VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;
            VideoCapture1.Video_CaptureDevice_IsAudioSource = cbUseAudioInputFromVideoCaptureDevice.Checked;
            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;
            VideoCapture1.Audio_CaptureDevice_Format_UseBest = cbUseBestAudioInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice_Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
            VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;

            if (cbFramerate.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice_FrameRate = (float)Convert.ToDouble(cbFramerate.Text);
            }

            VideoCapture1.Mode = VFVideoCaptureMode.VideoCapture;
            VideoCapture1.Output_Filename = edOutput.Text;

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        var aviOutput = new VFAVIOutput();
                        SetAVIOutput(ref aviOutput);
                        VideoCapture1.Output_Format = aviOutput;

                        break;
                    }
                case 1:
                    {
                        var mkvOutput = new VFMKVv1Output();
                        SetMKVOutput(ref mkvOutput);
                        VideoCapture1.Output_Format = mkvOutput;

                        break;
                    }
                case 2:
                    {
                        var wmvOutput = new VFWMVOutput();
                        SetWMVOutput(ref wmvOutput);
                        VideoCapture1.Output_Format = wmvOutput;

                        break;
                    }
                case 3:
                    {
                        var dvOutput = new VFDVOutput();
                        SetDVOutput(ref dvOutput);
                        VideoCapture1.Output_Format = dvOutput;

                        break;
                    }
                case 4:
                    {
                        var webmOutput = new VFWebMOutput();
                        SetWebMOutput(ref webmOutput);
                        VideoCapture1.Output_Format = webmOutput;

                        break;
                    }
                case 5:
                    {
                        var mp4Output = new VFMP4v8v10Output();
                        SetMP4Output(ref mp4Output);
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 6:
                    {
                        var mp4Output = new VFMP4v11Output();
                        SetMP4v11Output(ref mp4Output);
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 7:
                    {
                        var encOutput = new VFMP4v8v10Output();
                        SetMP4Output(ref encOutput);
                        encOutput.Encryption = true;
                        encOutput.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                        VideoCapture1.Output_Format = encOutput;

                        break;
                    }
                case 8:
                    {
                        var tsOutput = new VFMPEGTSOutput();
                        SetMPEGTSOutput(ref tsOutput);
                        VideoCapture1.Output_Format = tsOutput;

                        break;
                    }
                case 9:
                    {
                        var movOutput = new VFMOVOutput();
                        SetMOVOutput(ref movOutput);
                        VideoCapture1.Output_Format = movOutput;

                        break;
                    }
            }

            // separate capture settings
            VideoCapture1.SeparateCapture_Enabled = true;
            if (rbSeparateCaptureStartManually.Checked)
            {
                VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.Normal;
                VideoCapture1.SeparateCapture_AutostartCapture = false;
            }
            else if (rbSeparateCaptureSplitByDuration.Checked)
            {
                VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.SplitByDuration;
                VideoCapture1.SeparateCapture_AutostartCapture = true;
                VideoCapture1.SeparateCapture_TimeThreshold = TimeSpan.FromMilliseconds(Convert.ToInt32(edSeparateCaptureDuration.Text));
            }
            else if (rbSeparateCaptureSplitBySize.Checked)
            {
                VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.SplitByFileSize;
                VideoCapture1.SeparateCapture_AutostartCapture = true;
                VideoCapture1.SeparateCapture_FileSizeThreshold = Convert.ToInt32(edSeparateCaptureFileSize.Text) * 1024 * 1024;
            }

            //VideoCapture1.Video_Effects_Enabled = true;
            //VideoCapture1.Video_Effects_Clear();
            //var tsEffect = new VFVideoEffectTextLogo(true) { Mode = TextLogoMode.Timestamp };
            //VideoCapture1.Video_Effects_Add(tsEffect);

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 4;
            tmRecording.Start();
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void tbAudioBalance_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value);
            VideoCapture1.Audio_OutputDevice_Balance_Get();
        }

        private void tbAudioVolume_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value);
        }

        private void btVideoCaptureDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text);
        }

        private void cbUseBestVideoInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbVideoInputFormat.Enabled = !cbUseBestVideoInputFormat.Checked;
        }

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputFormat.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text;
            }
            else
            {
                VideoCapture1.Video_CaptureDevice_Format = string.Empty;
            }
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;

                cbVideoInputFormat.Items.Clear();
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                foreach (string format in deviceItem.VideoFormats)
                {
                    cbVideoInputFormat.Items.Add(format);
                }

                if (cbVideoInputFormat.Items.Count > 0)
                {
                    cbVideoInputFormat.SelectedIndex = 0;
                    cbVideoInputFormat_SelectedIndexChanged(null, null);
                }

                cbFramerate.Items.Clear();
                foreach (string frameRate in deviceItem.VideoFrameRates)
                {
                    cbFramerate.Items.Add(frameRate);
                }

                if (cbFramerate.Items.Count > 0)
                {
                    cbFramerate.SelectedIndex = 0;
                }

                cbUseAudioInputFromVideoCaptureDevice.Enabled = deviceItem.AudioOutput;
                btVideoCaptureDeviceSettings.Enabled = deviceItem.DialogDefault;
            }
        }

        private void cbUseAudioInputFromVideoCaptureDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbVideoInputDevice.Text))
            {
                VideoCapture1.Video_CaptureDevice_IsAudioSource = cbUseAudioInputFromVideoCaptureDevice.Checked;
                cbAudioInputDevice_SelectedIndexChanged(null, null);

                cbAudioInputDevice.Enabled = !cbUseAudioInputFromVideoCaptureDevice.Checked;
                btAudioInputDeviceSettings.Enabled = !cbUseAudioInputFromVideoCaptureDevice.Checked;
            }
        }

        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Enabled = !cbUseBestAudioInputFormat.Checked;
        }

        private void cbAudioInputLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
        }

        private void cbAudioInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
        }

        private void btAudioInputDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1)
            {
                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
                cbAudioInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevicesInfo.First(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels";
                var defaultValueExists = false;
                foreach (string format in deviceItem.Formats)
                {
                    cbAudioInputFormat.Items.Add(format);

                    if (defaultValue == format)
                    {
                        defaultValueExists = true;
                    }
                }

                if (cbAudioInputFormat.Items.Count > 0)
                {
                    cbAudioInputFormat.SelectedIndex = 0;

                    if (defaultValueExists)
                    {
                        cbAudioInputFormat.Text = defaultValue;
                    }
                }

                cbAudioInputFormat_SelectedIndexChanged(null, null);

                cbAudioInputLine.Items.Clear();

                foreach (string line in deviceItem.Lines)
                {
                    cbAudioInputLine.Items.Add(line);
                }

                if (cbAudioInputLine.Items.Count > 0)
                {
                    cbAudioInputLine.SelectedIndex = 0;
                }

                cbAudioInputLine_SelectedIndexChanged(null, null);

                btAudioInputDeviceSettings.Enabled = deviceItem.DialogDefault;
            }
        }

        private void llVideoTutorials_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
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

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
        }

        private void SetMP4Output(ref VFMP4v8v10Output mp4Output)
        {
            if (mp4V10SettingsDialog == null)
            {
                mp4V10SettingsDialog = new MP4v10SettingsDialog();
            }

            mp4V10SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetWMVOutput(ref VFWMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetWebMOutput(ref VFWebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        private void SetMP4v11Output(ref VFMP4v11Output mp4Output)
        {
            if (mp4v11SettingsDialog == null)
            {
                mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
            }

            mp4v11SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMPEGTSOutput(ref VFMPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref VFMOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        private void SetDVOutput(ref VFDVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMP3Output(ref VFMP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        private void SetMKVOutput(ref VFMKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        private void cbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 7:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
                case 8:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
                    }
            }
        }

        private void btOutputConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (dvSettingsDialog == null)
                        {
                            dvSettingsDialog = new DVSettingsDialog();
                        }

                        dvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (mp4V10SettingsDialog == null)
                        {
                            mp4V10SettingsDialog = new MP4v10SettingsDialog();
                        }

                        mp4V10SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (mp4v11SettingsDialog == null)
                        {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                        }

                        mp4v11SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 7:
                    {
                        if (mp4V10SettingsDialog == null)
                        {
                            mp4V10SettingsDialog = new MP4v10SettingsDialog();
                        }

                        mp4V10SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 8:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
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

        private async void btSeparateCaptureStart_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text);
        }

        private async void btSeparateCapturePause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_PauseAsync();
        }

        private async void btSeparateCaptureResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_ResumeAsync();
        }

        private async void btSeparateCaptureStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_StopAsync();
        }

        private async void btSeparateCaptureChangeFilename_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text);
        }
    }
}
