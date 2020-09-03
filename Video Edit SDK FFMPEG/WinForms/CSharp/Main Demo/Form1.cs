// ReSharper disable InconsistentNaming

namespace VideoEdit_CS_Demo
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;

    /// <summary>
    /// Main demo form.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Sources_Clear();
        }

        private void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = this.OpenDialog1.FileName;

                lbFiles.Items.Add(s);

                VideoEdit.GetFileLength(s, out var videoDuration, out var audioDuration);

                VideoEdit1.Sources_AddFile(s, videoDuration.TotalMilliseconds > 0, audioDuration.TotalMilliseconds > 0);
            }
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (SDK v" + VideoEdit1.SDK_Version + ", " + VideoEdit1.SDK_State + ")";

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.avi";
            VideoEdit1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";

            cbFrameRate.SelectedIndex = 7;
            cbOutputVideoFormat.SelectedIndex = 1;
            cbMotDetHLColor.SelectedIndex = 1;
            cbBarcodeType.SelectedIndex = 0;

            cbAspectRatio.SelectedIndex = 0;
            cbAudioBitrate.SelectedIndex = 8;
            cbAudioChannels.SelectedIndex = 1;
            cbAudioEncoder.SelectedIndex = 0;
            cbVideoEncoder.SelectedIndex = 1;
            cbAudioSampleRate.SelectedIndex = 0;
            cbContainer.SelectedIndex = 0;

            pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128);
        }

        private void ConfigureObjectDetection()
        {
            if (cbAFMotionDetection.Checked)
            {
                VideoEdit1.Object_Detection = new MotionDetectionExSettings();
                if (cbAFMotionHighlight.Checked)
                {
                    VideoEdit1.Object_Detection.ProcessorType = MotionProcessorType.MotionAreaHighlighting;
                }
                else
                {
                    VideoEdit1.Object_Detection.ProcessorType = MotionProcessorType.None;
                }
            }
            else
            {
                VideoEdit1.Object_Detection = null;
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            mmLog.Clear();

            VideoEdit1.Debug_Mode = cbDebugMode.Checked;

            VideoEdit1.Video_Effects_Clear();

            VideoEdit1.Output_Filename = edOutput.Text;

            VideoEdit1.Profile = (VFFFMPEGSDKProfile)cbOutputVideoFormat.SelectedIndex;

            VideoEdit1.Output_Audio_Channels = (VFFFMPEGSDKAudioChannels)cbAudioChannels.SelectedIndex;
            VideoEdit1.Output_Audio_SampleRate = Convert.ToInt32(cbAudioSampleRate.Text);
            VideoEdit1.Output_Audio_Bitrate = Convert.ToInt32(cbAudioBitrate.Text) * 1000;
            VideoEdit1.Output_Audio_Encoder = (VFFFMPEGSDKAudioEncoder)cbAudioEncoder.SelectedIndex;

            VideoEdit1.Output_Video_AspectRatio = (VFFFMPEGSDKAspectRatio)cbAspectRatio.SelectedIndex;
            VideoEdit1.Output_Video_Bitrate = Convert.ToInt32(edTargetBitrate.Text) * 1000;
            VideoEdit1.Output_Video_BufferSize = Convert.ToInt32(edBufferSize.Text) * 1000;
            VideoEdit1.Output_Video_Bitrate_Min = Convert.ToInt32(edMinimalBitrate.Text) * 1000;
            VideoEdit1.Output_Video_Bitrate_Max = Convert.ToInt32(edMaximalBitrate.Text) * 1000;
            VideoEdit1.Output_Video_Encoder = (VFFFMPEGSDKVideoEncoder)cbVideoEncoder.SelectedIndex;
            VideoEdit1.Output_Video_FrameRate = (VFFFMPEGSDKFrameRate)cbFrameRate.SelectedIndex;

            VideoEdit1.Output_Muxer = (VFFFMPEGSDKMuxFormat)cbContainer.SelectedIndex;

            if (cbResize.Checked)
            {
                VideoEdit1.Output_Video_Width = Convert.ToInt32(edWidth.Text);
                VideoEdit1.Output_Video_Height = Convert.ToInt32(edHeight.Text);
            }
            else
            {
                VideoEdit1.Output_Video_Width = 0;
                VideoEdit1.Output_Video_Height = 0;
            }

            // Audio processing
            VideoEdit1.Audio_Effects_Clear();

            if (cbAudAmplifyEnabled.Checked)
            {
                VideoEdit1.Audio_Effects_Add_Volume(tbAudAmplifyAmp.Value / 100.0);
            }

            if (cbAudEchoEnabled.Checked)
            {
                VideoEdit1.Audio_Effects_Add_Echo(
                    tbAudDelayGainIn.Value / 100.0,
                    tbAudDelayGainOut.Value / 100.0,
                    tbAudDelay.Value,
                    tbAudDelayGainDecay.Value / 100.0);
            }

            // Video processing
            VideoEdit1.Video_Effects_Clear();

            if (cbVideoEffects.Checked)
            {
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Lightness, TimeSpan.Zero, TimeSpan.Zero, tbLightness.Value, 0);
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Contrast, TimeSpan.Zero, TimeSpan.Zero, tbContrast.Value, 0);
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Saturation, TimeSpan.Zero, TimeSpan.Zero, tbSaturation.Value, 0);

                if (cbInvert.Checked)
                {
                    VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Invert, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
                }

                if (cbGreyscale.Checked)
                {
                    VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Greyscale, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
                }

                if (cbGraphicLogo.Checked)
                {
                    if (!cbGraphicLogoShowAlways.Checked)
                    {
                        VideoEdit1.Video_Effects_Add_ImageLogo(
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edGraphicLogoStartTime.Text)),
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edGraphicLogoStopTime.Text)),
                            edGraphicLogoFilename.Text,
                            Convert.ToInt32(edGraphicLogoLeft.Text),
                            Convert.ToInt32(edGraphicLogoTop.Text));
                    }
                    else
                    {
                        VideoEdit1.Video_Effects_Add_ImageLogo(
                            TimeSpan.Zero, 
                            TimeSpan.Zero, 
                            edGraphicLogoFilename.Text,
                            Convert.ToInt32(edGraphicLogoLeft.Text),
                            Convert.ToInt32(edGraphicLogoTop.Text));
                    }
                }

                if (cbTextLogo.Checked)
                {
                    if (!cbTextLogoShowAlways.Checked)
                    {
                        VideoEdit1.Video_Effects_Add_TextLogo(
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStartTime.Text)),
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStopTime.Text)),
                            edTextLogoValue.Text,
                            Convert.ToInt32(edTextLogoLeft.Text),
                            Convert.ToInt32(edTextLogoTop.Text),
                            FontDialog1.Font,
                            FontDialog1.Color,
                            Color.Transparent);
                    }
                    else
                    {
                        VideoEdit1.Video_Effects_Add_TextLogo(
                            TimeSpan.Zero, 
                            TimeSpan.Zero, 
                            edTextLogoValue.Text,
                            Convert.ToInt32(edTextLogoLeft.Text),
                            Convert.ToInt32(edTextLogoTop.Text),
                            FontDialog1.Font,
                            FontDialog1.Color,
                            Color.Transparent);
                    }
                }

                if (cbDeinterlace.Checked)
                {
                    VideoEdit1.Video_Effects_Add_Deinterlace();
                }

                if (cbDenoise.Checked)
                {
                    VideoEdit1.Video_Effects_Add_3DDenoise();
                }
            }

            if (cbZoom.Checked)
            {
                double zoom = tbZoom.Value / 10.0;
                VideoEdit1.Video_Effects_Add_Zoom(TimeSpan.Zero, TimeSpan.Zero, zoom, zoom, 0, 0);
            }

            if (cbPan.Checked)
            {
                VideoEdit1.Video_Effects_Add_Pan(
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStartTime.Text)),
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStopTime.Text)),
                    Convert.ToInt32(edPanSourceLeft.Text),
                    Convert.ToInt32(edPanSourceTop.Text),
                    Convert.ToInt32(edPanSourceWidth.Text),
                    Convert.ToInt32(edPanSourceHeight.Text),
                    Convert.ToInt32(edPanDestLeft.Text),
                    Convert.ToInt32(edPanDestTop.Text),
                    Convert.ToInt32(edPanDestWidth.Text),
                    Convert.ToInt32(edPanDestHeight.Text));
            }

            if (cbFadeInOut.Checked)
            {
                if (rbFadeIn.Checked)
                {
                    VideoEdit1.Video_Effects_Add_Simple(
                        VFVideoEffectType.FadeIn,
                        TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                        TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                        0,
                        0);
                }
                else
                {
                    VideoEdit1.Video_Effects_Add_Simple(
                        VFVideoEffectType.FadeOut,
                        TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                        TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                        0,
                        0);
                }
            }

            // motion detection
            if (cbMotDetEnabled.Checked)
            {
                VideoEdit1.Motion_Detection = new MotionDetectionSettings();
                VideoEdit1.Motion_Detection.Enabled = cbMotDetEnabled.Checked;
                VideoEdit1.Motion_Detection.Compare_Red = cbCompareRed.Checked;
                VideoEdit1.Motion_Detection.Compare_Green = cbCompareGreen.Checked;
                VideoEdit1.Motion_Detection.Compare_Blue = cbCompareBlue.Checked;
                VideoEdit1.Motion_Detection.Compare_Greyscale = cbCompareGreyscale.Checked;
                VideoEdit1.Motion_Detection.Highlight_Color = (VFMotionCHLColor)cbMotDetHLColor.SelectedIndex;
                VideoEdit1.Motion_Detection.Highlight_Enabled = cbMotDetHLEnabled.Checked;
                VideoEdit1.Motion_Detection.Highlight_Threshold = tbMotDetHLThreshold.Value;
                VideoEdit1.Motion_Detection.FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text);
                VideoEdit1.Motion_Detection.Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text);
                VideoEdit1.Motion_Detection.Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text);
                VideoEdit1.Motion_Detection.DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked;
                VideoEdit1.Motion_Detection.DropFrames_Threshold = tbMotDetDropFramesThreshold.Value;
            }
            else
            {
                VideoEdit1.Motion_Detection = null;
            }

            // Object detection
            ConfigureObjectDetection();

            // Chroma key
            ConfigureChromaKey();

            // Barcode detection
            VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked;
            VideoEdit1.Barcode_Reader_Type = (VFBarcodeType)cbBarcodeType.SelectedIndex;

            VideoEdit1.Start();
        }

        private void ConfigureChromaKey()
        {
            if (VideoEdit1.ChromaKey != null)
            {
                VideoEdit1.ChromaKey.Dispose();
                VideoEdit1.ChromaKey = null;
            }
            
            if (cbChromaKeyEnabled.Checked)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show("Chroma-key background file doesn't exists.");
                    return;
                }

                VideoEdit1.ChromaKey = new ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
                                           {
                                               Smoothing = tbChromaKeySmoothing.Value / 1000f,
                                               ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000f,
                                               Color = pnChromaKeyColor.BackColor
                                           };
            }
            else
            {
                VideoEdit1.ChromaKey = null;
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            VideoEdit1.Stop();
            ProgressBar1.Value = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            VideoEdit1.Stop();
        }

        private void btSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                edGraphicLogoFilename.Text = openFileDialog2.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private delegate void AFErrorDelegate(string error);

        private void AFErrorDelegateMethod(string error)
        {
            mmLog.Text = mmLog.Text + error + Environment.NewLine;
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            BeginInvoke(new AFErrorDelegate(AFErrorDelegateMethod), e.Message);
        }

        private delegate void ProgressDelegate(int progress);

        private void ProgressDelegateMethod(int progress)
        {
            ProgressBar1.Value = progress;
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            BeginInvoke(new ProgressDelegate(ProgressDelegateMethod), e.Progress);
        }

        private delegate void AFStopDelegate();

        private void AFStopDelegateMethod()
        {
            ProgressBar1.Value = 0;
            VideoEdit1.Sources_Clear();
            lbFiles.Items.Clear();

            MessageBox.Show("Complete", string.Empty, MessageBoxButtons.OK);
        }

        private void cbAFMotionDetection_CheckedChanged(object sender, EventArgs e)
        {
            ConfigureObjectDetection();
        }

        private void cbAFMotionHighlight_CheckedChanged(object sender, EventArgs e)
        {
            ConfigureObjectDetection();
        }

        private void btChromaKeySelectBGImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
                ConfigureChromaKey();
            }
        }

        private delegate void MotionDelegate(MotionDetectionEventArgs e);

        private void MotionDelegateMethod(MotionDetectionEventArgs e)
        {
            string s = string.Empty;
            foreach (byte b in e.Matrix)
            {
                s += b + " ";
            }

            mmMotDetMatrix.Text = s.Trim();
            pbMotionLevel.Value = e.Level;
        }

        private void VideoEdit1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        private delegate void AFMotionDelegate(float level);

        private void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        private void VideoEdit1_OnAForgeMotionDetection(object sender, MotionDetectionExEventArgs e)
        {
            BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        #region Barcode detector

        private delegate void BarcodeDelegate(BarcodeEventArgs value);

        private void BarcodeDelegateMethod(BarcodeEventArgs value)
        {
            edBarcode.Text = value.Value;
            edBarcodeMetadata.Text = string.Empty;
            foreach (var o in value.Metadata)
            {
                edBarcodeMetadata.Text += o.Key + ": " + o.Value + Environment.NewLine;
            }
        }

        private void VideoEdit1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        private void btBarcodeReset_Click(object sender, EventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoEdit1.Barcode_Reader_Enabled = true;
        }

        private void btFont_Click(object sender, EventArgs e)
        {
            FontDialog1.ShowDialog();
        }

        private void cbFadeInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFadeIn.Checked)
            {
                VideoEdit1.Video_Effects_Add_Simple(
                    VFVideoEffectType.FadeIn,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                    0,
                    0);
            }
            else
            {
                VideoEdit1.Video_Effects_Add_Simple(
                    VFVideoEffectType.FadeOut,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStartTime.Text)),
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInOutStopTime.Text)),
                    0,
                    0);
            }
        }
        
        private void VideoEdit1_OnStop(object sender, EventArgs e)
        {
            BeginInvoke(new AFStopDelegate(this.AFStopDelegateMethod));
        }

        private void VideoEdit1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (cbLicensing.Checked)
            {
                mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
            }
        }

        private void tbChromaKeyThresholdSensitivity_Scroll(object sender, EventArgs e)
        {
            ConfigureChromaKey();
        }

        private void tbChromaKeySmoothing_Scroll(object sender, EventArgs e)
        {
            ConfigureChromaKey();
        }

        private void pnChromaKeyColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnChromaKeyColor.BackColor = colorDialog1.Color;
                ConfigureChromaKey();
            }
        }
    }
}

// ReSharper restore InconsistentNaming