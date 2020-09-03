// ReSharper disable InconsistentNaming

using VisioForge.Controls.UI;

namespace Main_Demo
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;

    using VisioForge.Types;
    using VisioForge.Controls.UI.WPF;

    using MessageBox = System.Windows.MessageBox;
    using VideoEdit = VisioForge.Controls.UI.WinForms.VideoEdit;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class Window1
    {
        // Dialogs
        private readonly FontDialog fontDialog = new FontDialog();
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
        private readonly ColorDialog colorDialog1 = new ColorDialog();

        public Window1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, RoutedEventArgs e)
        {
            Title += " (SDK v" + VideoEdit1.SDK_Version + ", " + VideoEdit1.SDK_State + ")";

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

            pnChromaKeyColor.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 128, 218, 128));
        }
        
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            
            VideoEdit1.Video_Effects_Clear();

            VideoEdit1.Output_Filename = edOutput.Text;

            VideoEdit1.Profile = (VFFFMPEGSDKProfile)cbOutputVideoFormat.SelectedIndex;

            VideoEdit1.Output_Audio_Channels = (VFFFMPEGSDKAudioChannels)cbAudioChannels.SelectedIndex;
            VideoEdit1.Output_Audio_SampleRate = Convert.ToInt32(cbAudioSampleRate.Text);
            VideoEdit1.Output_Audio_Bitrate = Convert.ToInt32(cbAudioBitrate.Text) * 1000;
            VideoEdit1.Output_Audio_Encoder = (VFFFMPEGSDKAudioEncoder)cbAudioEncoder.SelectedIndex;

            VideoEdit1.Output_Video_AspectRatio = (VFFFMPEGSDKAspectRatio)cbAspectRatio.SelectedIndex;
            VideoEdit1.Output_Video_Bitrate = Convert.ToInt32(edTargetBitrate.Text) * 1000;
            VideoEdit1.Output_Video_Encoder = (VFFFMPEGSDKVideoEncoder)cbVideoEncoder.SelectedIndex;
            VideoEdit1.Output_Video_FrameRate = (VFFFMPEGSDKFrameRate)cbFrameRate.SelectedIndex;

            VideoEdit1.Output_Muxer = (VFFFMPEGSDKMuxFormat)cbContainer.SelectedIndex;

            if (cbResize.IsChecked == true)
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

            if (cbAudAmplifyEnabled.IsChecked == true)
            {
                VideoEdit1.Audio_Effects_Add_Volume(tbAudAmplifyAmp.Value / 100.0);
            }

            if (cbAudEchoEnabled.IsChecked == true)
            {
                VideoEdit1.Audio_Effects_Add_Echo(
                    tbAudDelayGainIn.Value / 100.0,
                    tbAudDelayGainOut.Value / 100.0,
                    tbAudDelay.Value,
                    tbAudDelayDecay.Value / 100.0);
            }

            // Video processing
            VideoEdit1.Video_Effects_Clear();

            if (cbVideoEffects.IsChecked == true)
            {
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Lightness, TimeSpan.Zero, TimeSpan.Zero, (int)tbLightness.Value, 0);
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Contrast, TimeSpan.Zero, TimeSpan.Zero, (int)tbContrast.Value, 0);
                VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Saturation, TimeSpan.Zero, TimeSpan.Zero, (int)tbSaturation.Value, 0);

                if (cbInvert.IsChecked == true)
                {
                    VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Invert, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
                }

                if (cbGreyscale.IsChecked == true)
                {
                    VideoEdit1.Video_Effects_Add_Simple(VFVideoEffectType.Greyscale, TimeSpan.Zero, TimeSpan.Zero, 0, 0);
                }

                if (cbGraphicLogo.IsChecked == true)
                {
                    if (this.cbGraphicLogoShowAlways.IsChecked != true)
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

                if (cbTextLogo.IsChecked == true)
                {
                    if (!cbTextLogoShowAlways.IsChecked == true)
                    {
                        VideoEdit1.Video_Effects_Add_TextLogo(
                            TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edTextLogoStopTime.Text)),
                            edTextLogo.Text,
                            Convert.ToInt32(edTextLogoLeft.Text),
                            Convert.ToInt32(edTextLogoTop.Text),
                            fontDialog.Font,
                            VideoEditFFMPEG.ColorConv(fontDialog.Color),
                            Colors.Transparent);
                    }
                    else
                    {
                        VideoEdit1.Video_Effects_Add_TextLogo(
                            TimeSpan.Zero,
                            TimeSpan.Zero,
                            edTextLogo.Text,
                            Convert.ToInt32(edTextLogoLeft.Text),
                            Convert.ToInt32(edTextLogoTop.Text),
                            fontDialog.Font,
                            VideoEditFFMPEG.ColorConv(fontDialog.Color),
                            Colors.Transparent);
                    }
                }

                if (cbDeinterlace.IsChecked == true)
                {
                    VideoEdit1.Video_Effects_Add_Deinterlace();
                }

                if (cbDenoise.IsChecked == true)
                {
                    VideoEdit1.Video_Effects_Add_3DDenoise();
                }
            }

            if (cbZoomEnabled.IsChecked == true)
            {
                double zoom = tbZoom.Value / 10.0;
                VideoEdit1.Video_Effects_Add_Zoom(TimeSpan.Zero, TimeSpan.Zero, zoom, zoom, 0, 0);
            }

            if (cbPan.IsChecked == true)
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

            if (cbFadeInOut.IsChecked == true)
            {
                if (rbFadeIn.IsChecked == true)
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
            if (cbMotDetEnabled.IsChecked == true)
            {
                VideoEdit1.Motion_Detection = new MotionDetectionSettings();
                VideoEdit1.Motion_Detection.Enabled = cbMotDetEnabled.IsChecked == true;
                VideoEdit1.Motion_Detection.Compare_Red = cbCompareRed.IsChecked == true;
                VideoEdit1.Motion_Detection.Compare_Green = cbCompareGreen.IsChecked == true;
                VideoEdit1.Motion_Detection.Compare_Blue = cbCompareBlue.IsChecked == true;
                VideoEdit1.Motion_Detection.Compare_Greyscale = cbCompareGreyscale.IsChecked == true;
                VideoEdit1.Motion_Detection.Highlight_Color = (VFMotionCHLColor)cbMotDetHLColor.SelectedIndex;
                VideoEdit1.Motion_Detection.Highlight_Enabled = cbMotDetHLEnabled.IsChecked == true;
                VideoEdit1.Motion_Detection.Highlight_Threshold = (int)tbMotDetHLThreshold.Value;
                VideoEdit1.Motion_Detection.FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text);
                VideoEdit1.Motion_Detection.Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text);
                VideoEdit1.Motion_Detection.Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text);
                VideoEdit1.Motion_Detection.DropFrames_Enabled = cbMotDetDropFramesEnabled.IsChecked == true;
                VideoEdit1.Motion_Detection.DropFrames_Threshold = (int)tbMotDetDropFramesThreshold.Value;
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
            VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.IsChecked == true;
            VideoEdit1.Barcode_Reader_Type = (VFBarcodeType)cbBarcodeType.SelectedIndex;

            VideoEdit1.Start();
        }

        private static System.Drawing.Color ColorConv(System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private static System.Windows.Media.Color ColorConv(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void ConfigureChromaKey()
        {
            if (VideoEdit1 == null)
            {
                return;
            }

            if (VideoEdit1.ChromaKey != null)
            {
                VideoEdit1.ChromaKey.Dispose();
                VideoEdit1.ChromaKey = null;
            }
            
            if (cbChromaKeyEnabled.IsChecked == true)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show("Chroma-key background file doesn't exists.");
                    return;
                }

                VideoEdit1.ChromaKey = new ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
                                           {
                                               Smoothing = (float)(tbChromaKeySmoothing.Value / 1000f),
                                               ThresholdSensitivity = (float)(tbChromaKeyThresholdSensitivity.Value / 1000f),
                                               Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color)
                                           };
            }
            else
            {
                VideoEdit1.ChromaKey = null;
            }
        }

        private void ConfigureObjectDetection()
        {
            if (cbAFMotionDetection.IsChecked == true)
            {
                VideoEdit1.Object_Detection = new MotionDetectionExSettings();
                if (cbAFMotionHighlight.IsChecked == true)
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

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Stop();

            pbProgress.Value = 0;
        }


        private void btFont_Click(object sender, RoutedEventArgs e)
        {
            if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
        }

        private void btSelectImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog2.ShowDialog() == true)
            {
                edGraphicLogoFilename.Text = openFileDialog2.FileName;
            }
        }


        private void linkLabel1_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            VideoEdit1.Stop();
        }

        public delegate void AFErrorDelegate(string error);

        private void AFErrorDelegateMethod(string error)
        {
            mmLog.Text = mmLog.Text + error + Environment.NewLine;
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new AFErrorDelegate(AFErrorDelegateMethod), e.Message);
        }

        public delegate void ProgressDelegate(int progress);

        public void ProgressDelegateMethod(int progress)
        {
            //if (pbProgress.Value < progress)
            //{
                pbProgress.Value = progress;
            //}
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher.BeginInvoke(new ProgressDelegate(ProgressDelegateMethod), e.Progress);
        }

        public delegate void StopDelegate();

        public void StopDelegateMethod()
        {
            pbProgress.Value = 0;
            VideoEdit1.Sources_Clear();
            lbFiles.Items.Clear();

            MessageBox.Show("Complete");
        }

        private void VideoEdit1_OnStop(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(new StopDelegate(this.StopDelegateMethod));
        }


        private void btAddInputFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                string s = openFileDialog1.FileName;

                lbFiles.Items.Add(s);

                TimeSpan videoDuration;
                TimeSpan audioDuration;
                VideoEdit.GetFileLength(s, out videoDuration, out audioDuration);

                VideoEdit1.Sources_AddFile(s, videoDuration.TotalMilliseconds > 0, audioDuration.TotalMilliseconds > 0);
            }
        }

        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Sources_Clear();
        }

        private void btChromaKeySelectBGImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
                ConfigureChromaKey();
            }
        }

        private void cbAFMotionHighlight_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureObjectDetection();
        }

        private void cbAFMotionDetection_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureObjectDetection();
        }

        private void VideoEdit1_OnAForgeMotionDetection(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher.BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        public delegate void AFMotionDelegate(float level);

        public void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        public delegate void MotionDelegate(MotionDetectionEventArgs e);

        public void MotionDelegateMethod(MotionDetectionEventArgs e)
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
            Dispatcher.BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        #region Barcode detector

        public delegate void BarcodeDelegate(BarcodeEventArgs value);

        public void BarcodeDelegateMethod(BarcodeEventArgs value)
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

            Dispatcher.BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        private void btBarcodeReset_Click(object sender, RoutedEventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoEdit1.Barcode_Reader_Enabled = true;
        }

        private void cbFadeInOut_Checked(object sender, RoutedEventArgs e)
        {
            if (rbFadeIn.IsChecked == true)
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

        private void VideoEdit1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            if (cbLicensing.IsChecked == true)
            {
                mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message + Environment.NewLine;
            }
        }

        private void pnChromaKeyColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnChromaKeyColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                ConfigureChromaKey();
            }
        }

        private void tbChromaKeyThresholdSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ConfigureChromaKey();
        }

        private void tbChromaKeySmoothing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ConfigureChromaKey();
        }
    }
}

// ReSharper restore InconsistentNaming