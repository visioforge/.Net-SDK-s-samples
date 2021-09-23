namespace Window_Capture
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI.Dialogs;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;

    public partial class Form1 : Form
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        private HWEncodersOutputSettingsDialog movSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private WindowCaptureForm windowCaptureForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            cbOutputFormat.SelectedIndex = 2;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");

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

        private void SetMP4Output(ref VFMP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
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
        
        private void SetMP4HWOutput(ref VFMP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMPEGTSOutput(ref VFMPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref VFMOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }
        
        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    VideoCapture1.Video_Codecs.ToArray(),
                    VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                aviOutput.MP3 = mp3Output;
            }
        }
        
        private ScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var source = new ScreenCaptureSourceSettings
                             {
                                 Mode = VFScreenCaptureMode.Window, 
                                 WindowHandle = IntPtr.Zero
                             };

            try
            {
                if (windowCaptureForm == null)
                {
                    MessageBox.Show("Window for screen capture is not specified.");
                    return null;
                }

                source.WindowHandle = windowCaptureForm.CapturedWindowHandle;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (source.WindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Incorrect window title for screen capture.");
                return null;
            }

            source.FrameRate = (float)Convert.ToDouble(edScreenFrameRate.Text);

            return source;
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            VideoCapture1.Screen_Capture_Source = CreateScreenCaptureSource();

            // audio source
            VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Audio_PlayAudio = false;
            
            // apply capture params
            VideoCapture1.Video_Effects_Enabled = false;
            VideoCapture1.Video_Effects_Clear();

            VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;
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
                        var wmvOutput = new VFWMVOutput();
                        SetWMVOutput(ref wmvOutput);
                        VideoCapture1.Output_Format = wmvOutput;

                        break;
                    }
                case 2:
                    {
                        var mp4Output = new VFMP4Output();
                        SetMP4Output(ref mp4Output);
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 3:
                    {
                        var mp4Output = new VFMP4HWOutput();
                        SetMP4HWOutput(ref mp4Output);
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 4:
                    {
                        var gifOutput = new VFAnimatedGIFOutput();
                        SetGIFOutput(ref gifOutput);

                        VideoCapture1.Output_Format = gifOutput;

                        break;
                    }
                case 5:
                    {
                        var tsOutput = new VFMPEGTSOutput();
                        SetMPEGTSOutput(ref tsOutput);
                        VideoCapture1.Output_Format = tsOutput;

                        break;
                    }
                case 6:
                    {
                        var movOutput = new VFMOVOutput();
                        SetMOVOutput(ref movOutput);
                        VideoCapture1.Output_Format = movOutput;

                        break;
                    }
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 2;
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
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

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
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
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 3:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 4:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(this);

                        break;
                    }
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
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

        private void btScreenSourceWindowSelect_Click(object sender, EventArgs e)
        {
            if (windowCaptureForm == null)
            {
                windowCaptureForm = new WindowCaptureForm();
                windowCaptureForm.OnCaptureHotkey += WindowCaptureForm_OnCaptureHotkey;
            }

            windowCaptureForm.StartCapture();
        }

        private void WindowCaptureForm_OnCaptureHotkey(object sender, WindowCaptureEventArgs e)
        {
            windowCaptureForm.StopCapture();
            windowCaptureForm.Hide();

            lbScreenSourceWindowText.Text = e.Caption;
        }
    }
}
