// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600
// ReSharper disable UnusedParameter.Local
// ReSharper disable StyleCop.SA1650
// ReSharper disable NotAccessedVariable
// ReSharper disable InlineOutVariableDeclaration
// ReSharper disable CommentTypo

namespace VideoCapture_CSharp_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.Dialogs.VideoEffects;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Shared.IPCameraDB;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.FFMPEGEXE;
    using VisioForge.Types.GPUVideoEffects;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;
    using VisioForge.Types.VideoEffects;

    using VFM4AOutput = VisioForge.Types.OutputFormat.VFM4AOutput;

    /// <summary>
    /// Main form.
    /// </summary>
    public partial class Form1 : Form
    {
        private MFSettingsDialog mp4v11SettingsDialog;

        private MFSettingsDialog mpegTSSettingsDialog;

        private MFSettingsDialog movSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private PCMSettingsDialog pcmSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGDLLSettingsDialog ffmpegDLLSettingsDialog;

        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        private FLACSettingsDialog flacSettingsDialog;

        private CustomFormatSettingsDialog customFormatSettingsDialog;

        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        private SpeexSettingsDialog speexSettingsDialog;

        private M4ASettingsDialog m4aSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        private ONVIFControl onvifControl;

        private ONVIFPTZRanges onvifPtzRanges;

        private float onvifPtzX;

        private float onvifPtzY;

        private float onvifPtzZoom;

        private List<AudioChannelMapperItem> audioChannelMapperItems;

        // Zoom
        private double zoom = 1.0;

        private int zoomShiftX;

        private int zoomShiftY;

        private readonly List<Form> multiscreenWindows = new List<Form>();

        private WindowCaptureForm windowCaptureForm;

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\"
        };

        private readonly System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds audio effects.
        /// </summary>
        private void AddAudioEffects()
        {
            VideoCapture1.Audio_Effects_Clear(-1);

            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Amplify, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Equalizer, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.DynamicAmplify, cbAudDynamicAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Sound3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.TrueBass, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
        }

        /// <summary>
        /// Form load event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //VideoCapture1.CustomRedist_Enabled = true;
            //VideoCapture1.CustomRedist_Path = @"c:\Projects\_Projects\MediaFrameworkDotNet\_OUTPUT\FILTERS\";

            Text += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            audioChannelMapperItems = new List<AudioChannelMapperItem>();

            // set combobox indexes
            cbMode.SelectedIndex = 0;
            cbOutputFormat.SelectedIndex = 22;

            cbResizeMode.SelectedIndex = 0;
            cbMotDetHLColor.SelectedIndex = 1;
            cbIPCameraType.SelectedIndex = 2;
            cbRotate.SelectedIndex = 0;
            cbBarcodeType.SelectedIndex = 0;

            cbCustomAudioSourceCategory.SelectedIndex = 0;
            cbCustomVideoSourceCategory.SelectedIndex = 0;
            cbPIPResizeMode.SelectedIndex = 0;

            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;

            cbDecklinkOutputAnalog.SelectedIndex = 0;
            cbDecklinkOutputBlackToDeck.SelectedIndex = 0;
            cbDecklinkOutputComponentLevels.SelectedIndex = 0;
            cbDecklinkOutputDownConversion.SelectedIndex = 0;
            cbDecklinkOutputDualLink.SelectedIndex = 0;
            cbDecklinkOutputHDTVPulldown.SelectedIndex = 0;
            cbDecklinkOutputNTSC.SelectedIndex = 0;
            cbDecklinkOutputSingleField.SelectedIndex = 0;

            cbDecklinkSourceInput.SelectedIndex = 0;
            cbDecklinkSourceNTSC.SelectedIndex = 0;
            cbDecklinkSourceComponentLevels.SelectedIndex = 0;
            cbDecklinkSourceTimecode.SelectedIndex = 0;

            cbFaceTrackingColorMode.SelectedIndex = 0;
            cbFaceTrackingScalingMode.SelectedIndex = 0;
            cbFaceTrackingSearchMode.SelectedIndex = 1;

            cbNetworkStreamingMode.SelectedIndex = 0;

            cbDirect2DRotate.SelectedIndex = 0;

            rbMotionDetectionExProcessor.SelectedIndex = 1;
            rbMotionDetectionExDetector.SelectedIndex = 1;

            cbHLSMode.SelectedIndex = 0;

            pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128);

            var genres = new List<string>();
            foreach (var genre in VideoCapture.Tags_GetDefaultVideoGenres())
            {
                genres.Add(genre);
            }

            foreach (var genre in VideoCapture.Tags_GetDefaultAudioGenres())
            {
                genres.Add(genre);
            }

            genres.Sort();
            foreach (var genre in genres)
            {
                cbTagGenre.Items.Add(genre);
            }

            cbTagGenre.SelectedIndex = 0;

            edOutput.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output.mp4";
            edNewFilename.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\" + "output_new.mp4";

            VideoCapture1.TVTuner_Read();

            foreach (string tunerDevice in VideoCapture1.TVTuner_Devices)
            {
                cbTVTuner.Items.Add(tunerDevice);
            }

            if (cbTVTuner.Items.Count > 0)
            {
                cbTVTuner.SelectedIndex = 0;
            }

            foreach (string tunerTVFormat in VideoCapture1.TVTuner_TVFormats())
            {
                cbTVSystem.Items.Add(tunerTVFormat);
            }

            cbTVSystem.SelectedIndex = 0;

            foreach (string tunerCountry in VideoCapture1.TVTuner_Countries)
            {
                cbTVCountry.Items.Add(tunerCountry);
            }

            cbTVCountry.SelectedIndex = 0;

            cbTVTuner_SelectedIndexChanged(null, null);

            foreach (var device in VideoCapture1.Video_CaptureDevicesInfo)
            {
                cbVideoInputDevice.Items.Add(device.Name);
                cbPIPDevice.Items.Add(device.Name);
            }

            if (cbVideoInputDevice.Items.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
                cbVideoInputDevice_SelectedIndexChanged(null, null);
                cbPIPDevice.SelectedIndex = 0;
                cbPIPDevice_SelectedIndexChanged(null, null);
            }

            foreach (var device in VideoCapture1.Audio_CaptureDevicesInfo)
            {
                cbAudioInputDevice.Items.Add(device.Name);
                cbAdditionalAudioSource.Items.Add(device.Name);
            }

            if (cbAudioInputDevice.Items.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                cbAudioInputDevice_SelectedIndexChanged(null, null);

                cbAdditionalAudioSource.SelectedIndex = 0;
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

                cbAudioOutputDevice_SelectedIndexChanged(null, null);
            }

            if (!string.IsNullOrEmpty(cbAudioInputDevice.Text))
            {
                var audioInputDevice =
                    VideoCapture1.Audio_CaptureDevicesInfo.First(device => device.Name == cbAudioInputDevice.Text);
                if (audioInputDevice != null)
                {
                    foreach (string line in audioInputDevice.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                        cbAudioInputLine_SelectedIndexChanged(null, null);
                    }
                }
            }

            cbAudioInputFormat_SelectedIndexChanged(null, null);
            cbVideoInputFormat_SelectedIndexChanged(null, null);

            rbEVR.Enabled = VideoCapture.Filter_Supported_EVR();
            rbVMR9.Enabled = VideoCapture.Filter_Supported_VMR9();

            if (!(rbVMR9.Enabled && rbEVR.Enabled))
            {
                rbVR.Checked = true;
            }
            else if (rbEVR.Enabled)
            {
                rbEVR.Checked = true;
            }

            rbVR_CheckedChanged(null, null);

            foreach (string specialFilter in VideoCapture1.Special_Filters(VFSpecialFilterType.HardwareVideoEncoder))
            {
                cbMPEGEncoder.Items.Add(specialFilter);
            }

            if (cbMPEGEncoder.Items.Count > 0)
            {
                cbMPEGEncoder.SelectedIndex = 0;
            }

            foreach (string directShowFilter in VideoCapture1.DirectShow_Filters)
            {
                cbFilters.Items.Add(directShowFilter);
                cbMPEGDemuxer.Items.Add(directShowFilter);
            }

            // Video capture device MPEG decoders
            cbMPEGVideoDecoder.Items.Add("(default)");
            cbMPEGAudioDecoder.Items.Add("(default)");

            foreach (string specialFilter in VideoCapture1.Special_Filters(VFSpecialFilterType.MPEG12VideoDecoder))
            {
                cbMPEGVideoDecoder.Items.Add(specialFilter);
            }

            if (cbMPEGVideoDecoder.Items.Count > 0)
            {
                cbMPEGVideoDecoder.SelectedIndex = 0;
            }

            foreach (string specialFilter in VideoCapture1.Special_Filters(VFSpecialFilterType.MPEG1AudioDecoder))
            {
                cbMPEGAudioDecoder.Items.Add(specialFilter);
            }

            if (cbMPEGAudioDecoder.Items.Count > 0)
            {
                cbMPEGAudioDecoder.SelectedIndex = 0;
            }

            cbMPEGVideoDecoder_SelectedIndexChanged(null, null);
            cbMPEGAudioDecoder_SelectedIndexChanged(null, null);

            cbPIPMode.SelectedIndex = 0;

            // BDA
            foreach (string source in VideoCapture.BDA_Sources())
            {
                cbBDASourceDevice.Items.Add(source);
            }

            foreach (string receiver in VideoCapture.BDA_Receivers())
            {
                cbBDAReceiver.Items.Add(receiver);
            }

            if (cbBDASourceDevice.Items.Count > 0)
            {
                cbBDASourceDevice.SelectedIndex = 0;
            }

            if (cbBDAReceiver.Items.Count > 1)
            {
                cbBDAReceiver.SelectedIndex = 1;
            }

            cbBDADeviceStandard.SelectedIndex = 0;
            cbDVBSPolarisation.SelectedIndex = 0;
            cbDVBCModulation.SelectedIndex = 4;

            // ReSharper disable once CoVariantArrayConversion
            cbAudEqualizerPreset.Items.AddRange(VideoCapture1.Audio_Effects_Equalizer_Presets().ToArray());
            cbAudEqualizerPreset.SelectedIndex = 0;

            // Decklink
            foreach (var device in VideoCapture1.Decklink_CaptureDevices)
            {
                cbDecklinkCaptureDevice.Items.Add(device.Name);
            }

            if (cbDecklinkCaptureDevice.Items.Count > 0)
            {
                cbDecklinkCaptureDevice.SelectedIndex = 0;
                cbDecklinkCaptureDevice_SelectedIndexChanged(null, null);
            }

            btVirtualCameraRegister.Enabled = !VideoCapture1.DirectShow_Filters.Contains("VisioForge Virtual Camera");

            Form1_SizeChanged(this, EventArgs.Empty);
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbVideoInputDevice.Text);
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

                // currently device active, we can read TV Tuner name
                string tvTuner = deviceItem.TVTuner;
                if (!string.IsNullOrEmpty(tvTuner))
                {
                    int k = cbTVTuner.Items.IndexOf(tvTuner);
                    if (k >= 0)
                    {
                        cbTVTuner.SelectedIndex = k;
                    }
                }

                cbCrossBarAvailable.Enabled = VideoCapture1.Video_CaptureDevice_CrossBar_Init(cbVideoInputDevice.Text);
                cbCrossBarAvailable.Checked = cbCrossBarAvailable.Enabled;

                if (cbCrossBarAvailable.Enabled)
                {
                    cbCrossbarInput.Enabled = true;
                    cbCrossbarOutput.Enabled = true;
                    rbCrossbarSimple.Enabled = true;
                    rbCrossbarAdvanced.Enabled = true;
                    cbCrossbarVideoInput.Enabled = true;
                    btConnect.Enabled = true;
                    cbConnectRelated.Enabled = true;
                    lbRotes.Enabled = true;

                    VideoCapture1.Video_CaptureDevice_CrossBar_ClearConnections();

                    cbCrossbarVideoInput.Items.Clear();
                    foreach (string s in VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput("Video Decoder"))
                    {
                        cbCrossbarVideoInput.Items.Add(s);
                    }

                    cbCrossbarVideoInput.SelectedIndex = 0;

                    cbCrossbarOutput.Items.Clear();

                    foreach (string output in VideoCapture1.Video_CaptureDevice_CrossBar_Outputs())
                    {
                        cbCrossbarOutput.Items.Add(output);
                    }

                    if (cbCrossbarOutput.Items.Count > 0)
                    {
                        cbCrossbarOutput.SelectedIndex = 0;
                        cbCrossbarOutput_SelectedIndexChanged(null, null);
                    }

                    lbRotes.Items.Clear();
                    // ReSharper disable once ForCanBeConvertedToForeach
                    for (int i = 0; i < cbCrossbarOutput.Items.Count; i++)
                    {
                        string input = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Text);

                        if (input != string.Empty)
                        {
                            lbRotes.Items.Add("Input: " + input + ", Output: " + cbCrossbarOutput.Items[i]);
                        }
                    }
                }
                else
                {
                    cbCrossbarInput.Enabled = false;
                    cbCrossbarOutput.Enabled = false;
                    rbCrossbarSimple.Enabled = false;
                    rbCrossbarAdvanced.Enabled = false;
                    cbCrossbarVideoInput.Enabled = false;
                    btConnect.Enabled = false;
                    cbConnectRelated.Enabled = false;
                    lbRotes.Enabled = false;
                }

                // updating adjust settings
                int max;
                int defaultValue;
                int min;
                bool auto;
                int step;
                if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(VFVideoHardwareAdjustment.Brightness, out min, out max, out step, out defaultValue, out auto))
                {
                    tbAdjBrightness.Minimum = min;
                    tbAdjBrightness.Maximum = max;
                    tbAdjBrightness.SmallChange = step;
                    tbAdjBrightness.Value = defaultValue;
                    cbAdjBrightnessAuto.Checked = auto;
                    lbAdjBrightnessMin.Text = "Min: " + Convert.ToString(min);
                    lbAdjBrightnessMax.Text = "Max: " + Convert.ToString(max);
                    lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(defaultValue);
                }

                if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(VFVideoHardwareAdjustment.Hue, out min, out max, out step, out defaultValue, out auto))
                {
                    tbAdjHue.Minimum = min;
                    tbAdjHue.Maximum = max;
                    tbAdjHue.SmallChange = step;
                    tbAdjHue.Value = defaultValue;
                    cbAdjHueAuto.Checked = auto;
                    lbAdjHueMin.Text = "Min: " + Convert.ToString(min);
                    lbAdjHueMax.Text = "Max: " + Convert.ToString(max);
                    lbAdjHueCurrent.Text = "Current: " + Convert.ToString(defaultValue);
                }

                if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(VFVideoHardwareAdjustment.Saturation, out min, out max, out step, out defaultValue, out auto))
                {
                    tbAdjSaturation.Minimum = min;
                    tbAdjSaturation.Maximum = max;
                    tbAdjSaturation.SmallChange = step;
                    tbAdjSaturation.Value = defaultValue;
                    cbAdjSaturationAuto.Checked = auto;
                    lbAdjSaturationMin.Text = "Min: " + Convert.ToString(min);
                    lbAdjSaturationMax.Text = "Max: " + Convert.ToString(max);
                    lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(defaultValue);
                }

                if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(VFVideoHardwareAdjustment.Contrast, out min, out max, out step, out defaultValue, out auto))
                {
                    tbAdjContrast.Minimum = min;
                    tbAdjContrast.Maximum = max;
                    tbAdjContrast.SmallChange = step;
                    tbAdjContrast.Value = defaultValue;
                    cbAdjContrastAuto.Checked = auto;
                    lbAdjContrastMin.Text = "Min: " + Convert.ToString(min);
                    lbAdjContrastMax.Text = "Max: " + Convert.ToString(max);
                    lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(defaultValue);
                }

                cbUseAudioInputFromVideoCaptureDevice.Enabled = deviceItem.AudioOutput;
                btVideoCaptureDeviceSettings.Enabled = deviceItem.DialogDefault;
            }
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Items.Clear();
            cbAudioInputLine.Items.Clear();

            if (cbUseAudioInputFromVideoCaptureDevice.Checked)
            {
                var deviceItem =
                    VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbVideoInputDevice.Text);
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

                    cbAudioInputFormat_SelectedIndexChanged(null, null);
                }
            }
            else if (cbAudioInputDevice.SelectedIndex != -1)
            {
                VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;

                var deviceItem = VideoCapture1.Audio_CaptureDevicesInfo.First(device => device.Name == cbAudioInputDevice.Text);
                if (deviceItem != null)
                {
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
        }

        /// <summary>
        /// Selects output file.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Starts video preview or capture.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private async void btStart_Click(object sender, EventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.Checked;
            VideoCapture1.Debug_Dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VisioForge\\";
            VideoCapture1.Debug_Telemetry = cbTelemetry.Checked;

            zoom = 1.0;
            zoomShiftX = 0;
            zoomShiftY = 0;

            if (onvifControl != null)
            {
                onvifControl.Disconnect();
                onvifControl.Dispose();
                onvifControl = null;

                btONVIFConnect.Text = "Connect";
            }

            mmLog.Clear();

            if (cbPIPDevices.Items.Count > 0)
            {
                if (cbPIPDevices.Items.IndexOf("Main source") == -1)
                {
                    cbPIPDevices.Items.Insert(0, "Main source");
                }
            }

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.VLC_Path = Environment.GetEnvironmentVariable("VFVLCPATH");

            VideoCapture1.Video_Effects_Clear();
            lbTextLogos.Items.Clear();
            lbImageLogos.Items.Clear();

            switch (cbMode.SelectedIndex)
            {
                case 0:
                    VideoCapture1.Mode = VFVideoCaptureMode.VideoPreview;
                    break;
                case 1:
                    VideoCapture1.Mode = VFVideoCaptureMode.VideoCapture;
                    break;
                case 2:
                    VideoCapture1.Mode = VFVideoCaptureMode.AudioPreview;
                    break;
                case 3:
                    VideoCapture1.Mode = VFVideoCaptureMode.AudioCapture;
                    break;
                case 4:
                    VideoCapture1.Mode = VFVideoCaptureMode.ScreenPreview;
                    break;
                case 5:
                    VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;
                    break;
                case 6:
                    VideoCapture1.Mode = VFVideoCaptureMode.IPPreview;
                    break;
                case 7:
                    VideoCapture1.Mode = VFVideoCaptureMode.IPCapture;
                    break;
                case 8:
                    VideoCapture1.Mode = VFVideoCaptureMode.BDAPreview;
                    break;
                case 9:
                    VideoCapture1.Mode = VFVideoCaptureMode.BDACapture;
                    break;
                case 10:
                    VideoCapture1.Mode = VFVideoCaptureMode.CustomPreview;
                    break;
                case 11:
                    VideoCapture1.Mode = VFVideoCaptureMode.CustomCapture;
                    break;
                case 12:
                    VideoCapture1.Mode = VFVideoCaptureMode.DecklinkSourcePreview;
                    break;
                case 13:
                    VideoCapture1.Mode = VFVideoCaptureMode.DecklinkSourceCapture;
                    break;
            }

            VideoCapture1.Audio_CaptureDevice = cbAudioInputDevice.Text;
            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;
            VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
            VideoCapture1.Audio_CaptureDevice_Format_UseBest = cbUseBestAudioInputFormat.Checked;

            VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = rbAddAudioStreamsMix.Checked;

            if ((VideoCapture1.Mode == VFVideoCaptureMode.ScreenCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.ScreenPreview))
            {
                ScreenCaptureSourceSettings screenSource;
                SelectScreenSource(out screenSource);
                VideoCapture1.Screen_Capture_Source = screenSource;
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.IPCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.IPPreview))
            {
                // from IP camera
                IPCameraSourceSettings settings;
                SelectIPCameraSource(out settings);
                VideoCapture1.IP_Camera_Source = settings;
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.VideoCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.VideoPreview) ||
                (VideoCapture1.Mode == VFVideoCaptureMode.AudioCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.AudioPreview))
            {
                // from video capture device
                SelectVideoCaptureSource();
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.BDACapture) || (VideoCapture1.Mode == VFVideoCaptureMode.BDAPreview))
            {
                SelectBDASource();
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.CustomCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.CustomPreview))
            {
                SelectCustomSource();
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.PushSourceCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.PushSourcePreview))
            {
                VideoCapture1.Push_Source = new PushSourceSettings
                {
                    VideoWidth = 640,
                    VideoHeight = 480,
                    VideoFrameRate = 25.0f
                };
            }
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourceCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourcePreview))
            {
                VideoCapture1.Decklink_Source = new DecklinkSourceSettings
                {
                    Name = cbDecklinkCaptureDevice.Text,
                    VideoFormat = cbDecklinkCaptureVideoFormat.Text
                };
            }

            bool captureMode = VideoCapture1.Mode == VFVideoCaptureMode.AudioCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.BDACapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.CustomCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.IPCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.KinectCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.ScreenCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourceCapture
                               || VideoCapture1.Mode == VFVideoCaptureMode.VideoCapture;

            // Set file name
            if (captureMode)
            {
                SetFilename();
            }

            // network streaming
            VideoCapture1.Network_Streaming_Enabled = false;

            if (cbNetworkStreaming.Checked)
            {
                ConfigureNetworkStreaming();
            }

            VideoCapture1.Audio_RecordAudio = cbRecordAudio.Checked;
            VideoCapture1.Audio_PlayAudio = cbPlayAudio.Checked;

            // VU meters
            ConfigureVUMeters();

            // multiscreen
            ConfigureMultiscreen();

            // OSD
            VideoCapture1.OSD_Enabled = cbOSDEnabled.Checked;

            if (captureMode)
            {
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
                            var acmOutput = new VFACMOutput();
                            SetACMOutput(ref acmOutput);
                            VideoCapture1.Output_Format = acmOutput;

                            break;
                        }
                    case 5:
                        {
                            var mp3Output = new VFMP3Output();
                            SetMP3Output(ref mp3Output);
                            VideoCapture1.Output_Format = mp3Output;

                            break;
                        }
                    case 6:
                        {
                            var m4aOutput = new VFM4AOutput();
                            SetM4AOutput(ref m4aOutput);
                            VideoCapture1.Output_Format = m4aOutput;

                            break;
                        }
                    case 7:
                        {
                            var wmaOutput = new VFWMAOutput();
                            SetWMAOutput(ref wmaOutput);
                            VideoCapture1.Output_Format = wmaOutput;

                            break;
                        }
                    case 8:
                        {
                            var flacOutput = new VFFLACOutput();
                            SetFLACOutput(ref flacOutput);
                            VideoCapture1.Output_Format = flacOutput;

                            break;
                        }
                    case 9:
                        {
                            var oggVorbisOutput = new VFOGGVorbisOutput();
                            SetOGGOutput(ref oggVorbisOutput);
                            VideoCapture1.Output_Format = oggVorbisOutput;

                            break;
                        }
                    case 10:
                        {
                            var speexOutput = new VFSpeexOutput();
                            SetSpeexOutput(ref speexOutput);
                            VideoCapture1.Output_Format = speexOutput;

                            break;
                        }
                    case 11:
                        {
                            var customOutput = new VFCustomOutput();
                            SetCustomOutput(ref customOutput);
                            VideoCapture1.Output_Format = customOutput;

                            break;
                        }
                    case 12:
                        {
                            VideoCapture1.Output_Format = new VFDirectCaptureDVOutput();

                            break;
                        }
                    case 13:
                        {
                            VideoCapture1.Output_Format = new VFDirectCaptureAVIOutput();

                            break;
                        }
                    case 14:
                        {
                            VideoCapture1.Output_Format = new VFDirectCaptureMPEGOutput();

                            if (cbMPEGEncoder.SelectedIndex != -1)
                            {
                                VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = cbMPEGEncoder.Text;
                            }

                            break;
                        }
                    case 15:
                        {
                            VideoCapture1.Output_Format = new VFDirectCaptureMKVOutput();

                            break;
                        }
                    case 16:
                        {
                            var directCaptureOutputGDCL = new VFDirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputGDCL);
                            directCaptureOutputGDCL.Muxer = VFDirectCaptureMP4Muxer.GDCL;
                            VideoCapture1.Output_Format = directCaptureOutputGDCL;

                            break;
                        }
                    case 17:
                        {
                            var directCaptureOutputMG = new VFDirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputMG);
                            directCaptureOutputMG.Muxer = VFDirectCaptureMP4Muxer.Monogram;
                            VideoCapture1.Output_Format = directCaptureOutputMG;

                            break;
                        }
                    case 18:
                        {
                            var directCaptureOutput = new VFDirectCaptureCustomOutput();
                            SetDirectCaptureCustomOutput(ref directCaptureOutput);
                            VideoCapture1.Output_Format = directCaptureOutput;

                            break;
                        }
                    case 19:
                        {
                            var webmOutput = new VFWebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoCapture1.Output_Format = webmOutput;

                            break;
                        }
                    case 20:
                        {
                            var ffmpegDLLOutput = new VFFFMPEGOutput();
                            SetFFMPEGDLLOutput(ref ffmpegDLLOutput);
                            VideoCapture1.Output_Format = ffmpegDLLOutput;

                            break;
                        }
                    case 21:
                        {
                            var ffmpegOutput = new VFFFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 22:
                        {
                            var mp4Output = new VFMP4Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 23:
                        {
                            var mp4Output = new VFMP4v11Output();
                            SetMP4v11Output(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 24:
                        {
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);

                            VideoCapture1.Output_Format = gifOutput;

                            break;
                        }
                    case 25:
                        {
                            var encOutput = new VFMP4Output();
                            SetMP4Output(ref encOutput);
                            encOutput.Encryption = true;
                            encOutput.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                            VideoCapture1.Output_Format = encOutput;

                            break;
                        }
                    case 26:
                        {
                            var tsOutput = new VFMPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            VideoCapture1.Output_Format = tsOutput;

                            break;
                        }
                    case 27:
                        {
                            var movOutput = new VFMOVOutput();
                            SetMOVOutput(ref movOutput);
                            VideoCapture1.Output_Format = movOutput;

                            break;
                        }
                }
            }

            // crossbar
            SelectCrossbar();

            // Video effects CPU
            VideoCapture1.Video_Effects_Enabled = cbVideoEffects.Checked;
            VideoCapture1.Video_Effects_MergeImageLogos = cbMergeImageLogos.Checked;
            VideoCapture1.Video_Effects_MergeTextLogos = cbMergeTextLogos.Checked;
            VideoCapture1.Video_Effects_Clear();
            ConfigureVideoEffects();

            // Video effects GPU
            VideoCapture1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.Checked;

            // Virtual camera output
            VideoCapture1.Virtual_Camera_Output_Enabled = cbVirtualCamera.Checked;

            // Decklink output
            ConfigureDecklink();

            // Object detection 
            ConfigureMotionDetectionEx();

            // Face tracking
            ConfigureFaceTracking();

            // Barcode detection
            ConfigureBarcodeDetection();

            // Chroma key
            ConfigureChromaKey();

            // video renderer
            ConfigureVideoRenderer();

            // video resize and crop
            ConfigureResizeCropRotate();

            // MPEG / DV decoders
            ConfigureDecoders();

            // motion detection
            ConfigureMotionDetection();

            // Audio enhancement
            VideoCapture1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.Checked;
            if (VideoCapture1.Audio_Enhancer_Enabled)
            {
                VideoCapture1.Audio_Enhancer_Normalize(cbAudioNormalize.Checked);
                VideoCapture1.Audio_Enhancer_AutoGain(cbAudioAutoGain.Checked);

                ApplyAudioInputGains();
                ApplyAudioOutputGains();

                VideoCapture1.Audio_Enhancer_Timeshift(tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.Checked)
            {
                VideoCapture1.Audio_Channel_Mapper = new AudioChannelMapperSettings
                {
                    Routes = audioChannelMapperItems.ToArray(),
                    OutputChannelsCount = Convert.ToInt32(edAudioChannelMapperOutputChannels.Text)
                };
            }
            else
            {
                VideoCapture1.Audio_Channel_Mapper = null;
            }

            // Audio processing
            VideoCapture1.Audio_Effects_Enabled = cbAudioEffectsEnabled.Checked;
            if (VideoCapture1.Audio_Effects_Enabled)
            {
                AddAudioEffects();
            }

            // PIP
            VideoCapture1.PIP_Mode = (VFPIPMode)cbPIPMode.SelectedIndex;
            VideoCapture1.PIP_ResizeQuality = (VFPIPResizeQuality)cbPIPResizeMode.SelectedIndex;

            if (VideoCapture1.PIP_Mode == VFPIPMode.ChromaKey)
            {
                var chromaKey = new VFPIPChromaKeySettings
                {
                    Color = pnPIPChromaKeyColor.BackColor,
                    Tolerance1 = tbPIPChromaKeyTolerance1.Value,
                    Tolerance2 = tbPIPChromaKeyTolerance2.Value
                };

                VideoCapture1.PIP_ChromaKeySettings = chromaKey;
            }

            // Separate capture
            ConfigureSeparateCapture();

            // Output tags
            ConfigureOutputTags();

            // Disable video processing?
            if (cbDisableAllVideoProcessing.Checked)
            {
                VideoCapture1.Video_Effects_Enabled = false;
                VideoCapture1.Video_Effects_Clear();

                VideoCapture1.Video_Sample_Grabber_Enabled = false;
            }

            VideoCapture1.Video_Sample_Grabber_Enabled = true;

            // start
            await VideoCapture1.StartAsync();

            edNetworkURL.Text = VideoCapture1.Network_Streaming_URL;

            tmRecording.Start();
        }

        private void ConfigureDecoders()
        {
            // MPEG decoding (only for tuners with internal HW encoder)
            if (cbMPEGVideoDecoder.SelectedIndex < 1)
            {
                // default
                VideoCapture1.MPEG_Video_Decoder = string.Empty;
            }
            else
            {
                VideoCapture1.MPEG_Video_Decoder = cbMPEGVideoDecoder.Text;
            }

            if (cbMPEGAudioDecoder.SelectedIndex < 1)
            {
                // default
                VideoCapture1.MPEG_Audio_Decoder = string.Empty;
            }
            else
            {
                VideoCapture1.MPEG_Audio_Decoder = cbMPEGAudioDecoder.Text;
            }

            if (cbMPEGDemuxer.SelectedIndex < 1)
            {
                // default
                VideoCapture1.MPEG_Demuxer = string.Empty;
            }
            else
            {
                VideoCapture1.MPEG_Demuxer = cbMPEGDemuxer.Text;
            }

            // DV resolution
            if (rbDVResFull.Checked)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Full;
            }
            else if (rbDVResHalf.Checked)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Half;
            }
            else if (rbDVResQuarter.Checked)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Quarter;
            }
            else
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.DC;
            }
        }

        private void ConfigureOutputTags()
        {
            if (cbTagEnabled.Checked)
            {
                var tags = new VFFileTags
                {
                    Title = edTagTitle.Text,
                    Performers = new[] { edTagArtists.Text },
                    Album = edTagAlbum.Text,
                    Comment = edTagComment.Text,
                    Track = Convert.ToUInt32(edTagTrackID.Text),
                    Copyright = edTagCopyright.Text,
                    Year = Convert.ToUInt32(edTagYear.Text),
                    Composers = new[] { edTagComposers.Text },
                    Genres = new[] { cbTagGenre.Text },
                    Lyrics = edTagLyrics.Text
                };

                if (imgTagCover.Image != null)
                {
                    tags.Pictures = new[] { new Bitmap(imgTagCover.Image) };
                }

                VideoCapture1.Tags = tags;
            }
        }

        private void ConfigureSeparateCapture()
        {
            VideoCapture1.SeparateCapture_Enabled = cbSeparateCaptureEnabled.Checked;
            if (VideoCapture1.SeparateCapture_Enabled)
            {
                VideoCapture1.SeparateCapture_GMFMode = !cbSeparateCaptureBridgeEngine.Checked;

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
                    VideoCapture1.SeparateCapture_FileSizeThreshold = Convert.ToInt32(edSeparateCaptureFileSize.Text) * 1024
                                                                      * 1024;
                }
            }
        }

        private void ConfigureResizeCropRotate()
        {
            VideoCapture1.Video_ResizeOrCrop_Enabled = false;

            if (cbResize.Checked)
            {
                VideoCapture1.Video_ResizeOrCrop_Enabled = true;

                VideoCapture1.Video_Resize = new VideoResizeSettings
                {
                    Width = Convert.ToInt32(edResizeWidth.Text),
                    Height = Convert.ToInt32(edResizeHeight.Text),
                    LetterBox = cbResizeLetterbox.Checked
                };

                switch (cbResizeMode.SelectedIndex)
                {
                    case 0:
                        VideoCapture1.Video_Resize.Mode = VFResizeMode.NearestNeighbor;
                        break;
                    case 1:
                        VideoCapture1.Video_Resize.Mode = VFResizeMode.Bilinear;
                        break;
                    case 2:
                        VideoCapture1.Video_Resize.Mode = VFResizeMode.Bicubic;
                        break;
                    case 3:
                        VideoCapture1.Video_Resize.Mode = VFResizeMode.Lancroz;
                        break;
                }
            }
            else
            {
                VideoCapture1.Video_Resize = null;
            }

            if (cbCrop.Checked)
            {
                VideoCapture1.Video_ResizeOrCrop_Enabled = true;

                VideoCapture1.Video_Crop = new VideoCropSettings(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text));
            }
            else
            {
                VideoCapture1.Video_Crop = null;
            }

            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    VideoCapture1.Video_Rotation = VFRotateMode.RotateNone;
                    break;
                case 1:
                    VideoCapture1.Video_Rotation = VFRotateMode.Rotate90;
                    break;
                case 2:
                    VideoCapture1.Video_Rotation = VFRotateMode.Rotate180;
                    break;
                case 3:
                    VideoCapture1.Video_Rotation = VFRotateMode.Rotate270;
                    break;
            }
        }

        private void ConfigureVideoRenderer()
        {
            if (rbVMR9.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else if (rbEVR.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (rbVR.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
            else if (rbDirect2D.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.Direct2D;
            }
            else
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.None;
            }

            if (cbStretch.Checked)
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            VideoCapture1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor;
            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked;
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked;
        }

        private void ConfigureChromaKey()
        {
            if (VideoCapture1.ChromaKey != null)
            {
                VideoCapture1.ChromaKey.Dispose();
                VideoCapture1.ChromaKey = null;
            }

            if (cbChromaKeyEnabled.Checked)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show("Chroma-key background file doesn't exists.");
                    return;
                }

                VideoCapture1.ChromaKey = new ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
                {
                    Smoothing = tbChromaKeySmoothing.Value / 1000f,
                    ThresholdSensitivity = tbChromaKeyThresholdSensitivity.Value / 1000f,
                    Color = pnChromaKeyColor.BackColor
                };
            }
            else
            {
                VideoCapture1.ChromaKey = null;
            }
        }

        private static void ShowOnScreen(Form window, int screenNumber)
        {
            if (screenNumber >= 0 && screenNumber < Screen.AllScreens.Length)
            {
                window.Location = Screen.AllScreens[screenNumber].WorkingArea.Location;

                window.Show();

                window.Width = Screen.AllScreens[screenNumber].Bounds.Width;
                window.Height = Screen.AllScreens[screenNumber].Bounds.Height;
                window.Left = Screen.AllScreens[screenNumber].Bounds.Left;
                window.Top = Screen.AllScreens[screenNumber].Bounds.Top;
                window.TopMost = true;
                window.FormBorderStyle = FormBorderStyle.None;
                window.WindowState = FormWindowState.Maximized;
            }
        }

        private void ConfigureMultiscreen()
        {
            VideoCapture1.MultiScreen_Clear();
            VideoCapture1.MultiScreen_Enabled = cbMultiscreenDrawOnPanels.Checked || cbMultiscreenDrawOnExternalDisplays.Checked;

            if (!VideoCapture1.MultiScreen_Enabled)
            {
                return;
            }

            if (cbMultiscreenDrawOnPanels.Checked)
            {
                VideoCapture1.MultiScreen_AddScreen(pnScreen1.Handle, pnScreen1.Width, pnScreen1.Height);
                VideoCapture1.MultiScreen_AddScreen(pnScreen2.Handle, pnScreen2.Width, pnScreen2.Height);
                VideoCapture1.MultiScreen_AddScreen(pnScreen3.Handle, pnScreen3.Width, pnScreen3.Height);
            }

            if (cbMultiscreenDrawOnExternalDisplays.Checked)
            {
                if (Screen.AllScreens.Length > 1)
                {
                    for (int i = 1; i < Screen.AllScreens.Length; i++)
                    {
                        var additinalWindow1 = new Form();
                        ShowOnScreen(additinalWindow1, i);
                        VideoCapture1.MultiScreen_AddScreen(additinalWindow1.Handle, additinalWindow1.Width, additinalWindow1.Height);
                        multiscreenWindows.Add(additinalWindow1);
                    }
                }
            }
        }

        private void SetFilename()
        {
            if (!cbAutoFilename.Checked)
            {
                VideoCapture1.Output_Filename = edOutput.Text;
            }
            else
            {
                DateTime dt = DateTime.Now;
                string s = dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;

                string path = Path.GetDirectoryName(edOutput.Text);
                string ext = Path.GetExtension(edOutput.Text);
                VideoCapture1.Output_Filename = path + "\\" + s + ext;
            }
        }

        private void ConfigureVideoEffects()
        {
            // Deinterlace, except screen preview / capture
            if (cbDeinterlace.Checked && VideoCapture1.Mode != VFVideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VFVideoCaptureMode.ScreenPreview)
            {
                if (rbDeintBlendEnabled.Checked)
                {
                    IVFVideoEffectDeinterlaceBlend blend;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceBlend");
                    if (effect == null)
                    {
                        blend = new VFVideoEffectDeinterlaceBlend(true);
                        VideoCapture1.Video_Effects_Add(blend);
                    }
                    else
                    {
                        blend = effect as IVFVideoEffectDeinterlaceBlend;
                    }

                    if (blend == null)
                    {
                        MessageBox.Show("Unable to configure deinterlace blend effect.");
                        return;
                    }

                    blend.Threshold1 = Convert.ToInt32(edDeintBlendThreshold1.Text);
                    blend.Threshold2 = Convert.ToInt32(edDeintBlendThreshold2.Text);
                    blend.Constants1 = Convert.ToInt32(edDeintBlendConstants1.Text) / 10.0;
                    blend.Constants2 = Convert.ToInt32(edDeintBlendConstants2.Text) / 10.0;
                }
                else if (rbDeintCAVTEnabled.Checked)
                {
                    IVFVideoEffectDeinterlaceCAVT cavt;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VFVideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.Checked, Convert.ToInt32(edDeintCAVTThreshold.Text));
                        VideoCapture1.Video_Effects_Add(cavt);
                    }
                    else
                    {
                        cavt = effect as IVFVideoEffectDeinterlaceCAVT;
                    }

                    if (cavt == null)
                    {
                        MessageBox.Show("Unable to configure deinterlace CAVT effect.");
                        return;
                    }

                    cavt.Threshold = Convert.ToInt32(edDeintCAVTThreshold.Text);
                }
                else
                {
                    IVFVideoEffectDeinterlaceTriangle triangle;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceTriangle");
                    if (effect == null)
                    {
                        triangle = new VFVideoEffectDeinterlaceTriangle(true, Convert.ToByte(edDeintTriangleWeight.Text));
                        VideoCapture1.Video_Effects_Add(triangle);
                    }
                    else
                    {
                        triangle = effect as IVFVideoEffectDeinterlaceTriangle;
                    }

                    if (triangle == null)
                    {
                        MessageBox.Show("Unable to configure deinterlace triangle effect.");
                        return;
                    }

                    triangle.Weight = Convert.ToByte(edDeintTriangleWeight.Text);
                }
            }

            // Denoise, except screen preview / capture
            if (cbDenoise.Checked && VideoCapture1.Mode != VFVideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VFVideoCaptureMode.ScreenPreview)
            {
                if (rbDenoiseCAST.Checked)
                {
                    IVFVideoEffectDenoiseCAST cast;
                    var effect = VideoCapture1.Video_Effects_Get("DenoiseCAST");
                    if (effect == null)
                    {
                        cast = new VFVideoEffectDenoiseCAST(true);
                        VideoCapture1.Video_Effects_Add(cast);
                    }
                    else
                    {
                        cast = effect as IVFVideoEffectDenoiseCAST;
                    }

                    if (cast == null)
                    {
                        MessageBox.Show("Unable to configure denoise CAST effect.");
                        return;
                    }
                }
                else
                {
                    IVFVideoEffectDenoiseMosquito mosquito;
                    var effect = VideoCapture1.Video_Effects_Get("DenoiseMosquito");
                    if (effect == null)
                    {
                        mosquito = new VFVideoEffectDenoiseMosquito(true);
                        VideoCapture1.Video_Effects_Add(mosquito);
                    }
                    else
                    {
                        mosquito = effect as IVFVideoEffectDenoiseMosquito;
                    }

                    if (mosquito == null)
                    {
                        MessageBox.Show("Unable to configure denoise mosquito effect.");
                        return;
                    }
                }
            }

            // Other effects
            if (tbLightness.Value > 0)
            {
                tbLightness_Scroll(null, null);
            }

            if (tbSaturation.Value < 255)
            {
                tbSaturation_Scroll(null, null);
            }

            if (tbContrast.Value > 0)
            {
                tbContrast_Scroll(null, null);
            }

            if (tbDarkness.Value > 0)
            {
                tbDarkness_Scroll(null, null);
            }

            if (cbGreyscale.Checked)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbInvert.Checked)
            {
                cbInvert_CheckedChanged(null, null);
            }

            if (cbFlipX.Checked)
            {
                cbFlipX_CheckedChanged(null, null);
            }

            if (cbFlipY.Checked)
            {
                cbFlipY_CheckedChanged(null, null);
            }

            if (cbZoom.Checked)
            {
                cbZoom_CheckedChanged(null, null);
            }

            if (cbLiveRotation.Checked)
            {
                cbLiveRotation_CheckedChanged(null, null);
            }

            if (cbPan.Checked)
            {
                cbPan_CheckedChanged(null, null);
            }

            if (cbFadeInOut.Checked)
            {
                cbFadeInOut_CheckedChanged(null, null);
            }
        }

        private void ConfigureBarcodeDetection()
        {
            VideoCapture1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked;
            VideoCapture1.Barcode_Reader_Type = (VFBarcodeType)cbBarcodeType.SelectedIndex;
        }

        private void ConfigureFaceTracking()
        {
            if (cbFaceTrackingEnabled.Checked)
            {
                VideoCapture1.Face_Tracking = new FaceTrackingSettings
                {
                    ColorMode = (CamshiftMode)cbFaceTrackingColorMode.SelectedIndex,
                    Highlight = cbFaceTrackingCHL.Checked,
                    MinimumWindowSize =
                                                          int.Parse(edFaceTrackingMinimumWindowSize.Text),
                    ScalingMode =
                                                          (ObjectDetectorScalingMode)
                                                          cbFaceTrackingScalingMode.SelectedIndex,
                    SearchMode =
                                                          (ObjectDetectorSearchMode)
                                                          cbFaceTrackingSearchMode.SelectedIndex
                };

                // VideoCapture1.FaceTracking_ScaleFactor = int.Parse(edFaceTrackingScaleFactor.Text);
            }
            else
            {
                VideoCapture1.Face_Tracking = null;
            }
        }

        private void ConfigureMotionDetectionEx()
        {
            if (cbMotionDetectionEx.Checked)
            {
                VideoCapture1.Motion_DetectionEx = new MotionDetectionExSettings
                {
                    ProcessorType = (MotionProcessorType)rbMotionDetectionExProcessor.SelectedIndex,
                    DetectorType = (MotionDetectorType)rbMotionDetectionExDetector.SelectedIndex
                };
            }
            else
            {
                VideoCapture1.Motion_DetectionEx = null;
            }
        }

        private void ConfigureDecklink()
        {
            if (cbDecklinkOutput.Checked)
            {
                VideoCapture1.Decklink_Output = new DecklinkOutputSettings
                {
                    DVEncoding = cbDecklinkDV.Checked,
                    AnalogOutputIREUSA = cbDecklinkOutputNTSC.SelectedIndex == 0,
                    AnalogOutputSMPTE =
                                                            cbDecklinkOutputComponentLevels.SelectedIndex == 0,
                    BlackToDeckInCapture =
                                                            (DecklinkBlackToDeckInCapture)
                                                            cbDecklinkOutputBlackToDeck.SelectedIndex,
                    DualLinkOutputMode =
                                                            (DecklinkDualLinkMode)
                                                            cbDecklinkOutputDualLink.SelectedIndex,
                    HDTVPulldownOnOutput =
                                                            (DecklinkHDTVPulldownOnOutput)
                                                            cbDecklinkOutputHDTVPulldown.SelectedIndex,
                    SingleFieldOutputForSynchronousFrames =
                                                            (DecklinkSingleFieldOutputForSynchronousFrames)
                                                            cbDecklinkOutputSingleField.SelectedIndex,
                    VideoOutputDownConversionMode =
                                                            (DecklinkVideoOutputDownConversionMode)
                                                            cbDecklinkOutputDownConversion.SelectedIndex,
                    VideoOutputDownConversionModeAnalogUsed =
                                                            cbDecklinkOutputDownConversionAnalogOutput.Checked,
                    AnalogOutput =
                                                            (DecklinkAnalogOutput)cbDecklinkOutputAnalog.SelectedIndex
                };

                VideoCapture1.Decklink_Input = (DecklinkInput)cbDecklinkSourceInput.SelectedIndex;
                VideoCapture1.Decklink_Input_SMPTE = cbDecklinkSourceComponentLevels.SelectedIndex == 0;
                VideoCapture1.Decklink_Input_IREUSA = cbDecklinkSourceNTSC.SelectedIndex == 0;
                VideoCapture1.Decklink_Input_Capture_Timecode_Source =
                    (DecklinkCaptureTimecodeSource)cbDecklinkSourceTimecode.SelectedIndex;
            }
            else
            {
                VideoCapture1.Decklink_Output = null;
            }
        }

        private void SelectCrossbar()
        {
            if (VideoCapture1.Mode == VFVideoCaptureMode.VideoPreview || VideoCapture1.Mode == VFVideoCaptureMode.VideoCapture)
            {
                if (cbCrossBarAvailable.Enabled)
                {
                    // ReSharper disable RedundantIfElseBlock
                    if (rbCrossbarSimple.Checked)
                    {
                        if (cbCrossbarVideoInput.SelectedIndex != -1)
                        {
                            VideoCapture1.Video_CaptureDevice_CrossBar_ClearConnections();
                            VideoCapture1.Video_CaptureDevice_CrossBar_Connect(cbCrossbarVideoInput.Text, "Video Decoder", true);
                        }
                    }
                    else
                    {
                        // all routes must be already applied
                        // you don't need to do anything
                    }
                    // ReSharper restore RedundantIfElseBlock
                }
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

        private void SetMP4Output(ref VFMP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetFFMPEGEXEOutput(ref VFFFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
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

        private void SetWMAOutput(ref VFWMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        private void SetACMOutput(ref VFACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray());
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        private void SetWebMOutput(ref VFWebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        private void SetFFMPEGDLLOutput(ref VFFFMPEGOutput ffmpegDLLOutput)
        {
            if (ffmpegDLLSettingsDialog == null)
            {
                ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
            }

            ffmpegDLLSettingsDialog.SaveSettings(ref ffmpegDLLOutput);
        }

        private void SetFLACOutput(ref VFFLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
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

        private void SetSpeexOutput(ref VFSpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        private void SetM4AOutput(ref VFM4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetDirectCaptureCustomOutput(ref VFDirectCaptureCustomOutput directCaptureOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        private void SetDirectCaptureCustomOutput(ref VFDirectCaptureMP4Output directCaptureOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        private void SetCustomOutput(ref VFCustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref customOutput);
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
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        private void SetMKVOutput(ref VFMKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new VFMP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        private void SetOGGOutput(ref VFOGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null)
            {
                oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
            }

            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
        }

        private void ConfigureVUMeters()
        {
            VideoCapture1.Audio_VUMeter_Enabled = cbVUMeter.Checked;
            VideoCapture1.Audio_VUMeter_Pro_Enabled = cbVUMeterPro.Checked;

            if (VideoCapture1.Audio_VUMeter_Pro_Enabled)
            {
                VideoCapture1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value;

                volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F;
                volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F;

                waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F;
                waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F;
            }
        }

        private void ConfigureNetworkStreaming()
        {
            VideoCapture1.Network_Streaming_Enabled = true;

            switch (cbNetworkStreamingMode.SelectedIndex)
            {
                case 0:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.WMV;

                        if (rbNetworkStreamingUseMainWMVSettings.Checked)
                        {
                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Network_Streaming_Output = wmvOutput;
                        }
                        else
                        {
                            var wmvOutput = new VFWMVOutput
                            {
                                Mode = VFWMVMode.ExternalProfile,
                                External_Profile_FileName = edNetworkStreamingWMVProfile.Text
                            };
                            VideoCapture1.Network_Streaming_Output = wmvOutput;
                        }

                        VideoCapture1.Network_Streaming_WMV_Maximum_Clients = Convert.ToInt32(edMaximumClients.Text);
                        VideoCapture1.Network_Streaming_Network_Port = Convert.ToInt32(edWMVNetworkPort.Text);

                        break;
                    }

                case 1:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.RTSP_H264_AAC_SW;

                        var mp4Output = new VFMP4Output();
                        SetMP4Output(ref mp4Output);
                        VideoCapture1.Network_Streaming_Output = mp4Output;

                        VideoCapture1.Network_Streaming_URL = edNetworkRTSPURL.Text;

                        break;
                    }

                case 2:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.RTMP_FFMPEG_EXE;

                        var ffmpegOutput = new VFFFMPEGEXEOutput();

                        if (rbNetworkRTMPFFMPEGCustom.Checked)
                        {
                            ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                        }
                        else
                        {
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                        }

                        ffmpegOutput.OutputMuxer = OutputMuxer.FLV;
                        ffmpegOutput.UsePipe = cbNetworkRTMPFFMPEGUsePipes.Checked;

                        VideoCapture1.Network_Streaming_Output = ffmpegOutput;
                        VideoCapture1.Network_Streaming_URL = edNetworkRTMPURL.Text;

                        break;
                    }

                case 3:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.NDI;

                        var ndiOutput = new VFNDIOutput(edNDIName.Text);
                        VideoCapture1.Network_Streaming_Output = ndiOutput;
                        edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}";

                        break;
                    }

                case 4:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.UDP_FFMPEG_EXE;

                        var ffmpegOutput = new VFFFMPEGEXEOutput();

                        if (rbNetworkUDPFFMPEG.Checked)
                        {
                            ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                        }
                        else
                        {
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                        }

                        ffmpegOutput.OutputMuxer = OutputMuxer.MPEGTS;
                        ffmpegOutput.UsePipe = cbNetworkUDPFFMPEGUsePipes.Checked;
                        VideoCapture1.Network_Streaming_Output = ffmpegOutput;

                        VideoCapture1.Network_Streaming_URL = edNetworkUDPURL.Text;

                        break;
                    }

                case 5:
                    {
                        if (rbNetworkSSSoftware.Checked)
                        {
                            VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.SSF_H264_AAC_SW;

                            var mp4Output = new VFMP4Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Network_Streaming_Output = mp4Output;
                        }
                        else
                        {
                            VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.SSF_FFMPEG_EXE;

                            var ffmpegOutput = new VFFFMPEGEXEOutput();

                            if (rbNetworkSSFFMPEGDefault.Checked)
                            {
                                ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                            }
                            else
                            {
                                SetFFMPEGEXEOutput(ref ffmpegOutput);
                            }

                            ffmpegOutput.OutputMuxer = OutputMuxer.ISMV;
                            ffmpegOutput.UsePipe = cbNetworkSSUsePipes.Checked;
                            VideoCapture1.Network_Streaming_Output = ffmpegOutput;
                        }

                        VideoCapture1.Network_Streaming_URL = edNetworkSSURL.Text;

                        break;
                    }

                case 6:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.HLS;

                        var hls = new VFHLSOutput
                        {
                            HLS =
                            {
                                SegmentDuration = Convert.ToInt32(edHLSSegmentDuration.Text),
                                NumSegments = Convert.ToInt32(edHLSSegmentCount.Text),
                                OutputFolder = edHLSOutputFolder.Text,
                                PlaylistType = (VFHLSPlaylistType)cbHLSMode.SelectedIndex,
                                Custom_HTTP_Server_Enabled = cbHLSEmbeddedHTTPServerEnabled.Checked,
                                Custom_HTTP_Server_Port = Convert.ToInt32(edHLSEmbeddedHTTPServerPort.Text)
                            }
                        };

                        VideoCapture1.Network_Streaming_Output = hls;

                        if (cbHLSEmbeddedHTTPServerEnabled.Checked)
                        {
                            edHLSURL.Text = $"http://localhost:{edHLSEmbeddedHTTPServerPort.Text}/playlist.m3u8";
                        }
                        else
                        {
                            edHLSURL.Text = string.Empty;
                        }

                        break;
                    }

                case 7:
                    {
                        VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.External;

                        break;
                    }
            }

            VideoCapture1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.Checked;
        }

        private void SelectCustomSource()
        {
            VideoCapture1.Custom_Source = new CustomSourceSettings();

            if (cbCustomVideoSourceCategory.SelectedIndex == 0)
            {
                VideoCapture1.Custom_Source.VideoFilterCategory = VFFilterCategory.VideoCaptureSource;
            }
            else
            {
                VideoCapture1.Custom_Source.VideoFilterCategory = VFFilterCategory.DirectShowFilters;
            }

            VideoCapture1.Custom_Source.VideoFilterName = cbCustomVideoSourceFilter.Text;
            VideoCapture1.Custom_Source.VideoFilterFormat = cbCustomVideoSourceFormat.Text;
            VideoCapture1.Custom_Source.VideoFilenameOrURL = edCustomVideoSourceURL.Text;

            if (string.IsNullOrEmpty(cbCustomVideoSourceFrameRate.Text))
            {
                VideoCapture1.Custom_Source.VideoFilterFrameRate = 0f;
            }
            else
            {
                VideoCapture1.Custom_Source.VideoFilterFrameRate = Convert.ToDouble(cbCustomVideoSourceFrameRate.Text);
            }

            if (cbCustomAudioSourceCategory.SelectedIndex == 0)
            {
                VideoCapture1.Custom_Source.AudioFilterCategory = VFFilterCategory.AudioCaptureSource;
            }
            else
            {
                VideoCapture1.Custom_Source.AudioFilterCategory = VFFilterCategory.DirectShowFilters;
            }

            VideoCapture1.Custom_Source.AudioFilterName = cbCustomAudioSourceFilter.Text;
            VideoCapture1.Custom_Source.AudioFilterFormat = cbCustomAudioSourceFormat.Text;
            VideoCapture1.Custom_Source.AudioFilenameOrURL = edCustomAudioSourceURL.Text;
        }

        private void SelectBDASource()
        {
            VideoCapture1.BDA_Source = new BDASourceSettings
            {
                ReceiverName = cbBDAReceiver.Text,
                SourceType = (VFBDAType)cbBDADeviceStandard.SelectedIndex,
                SourceName = cbBDASourceDevice.Text
            };

            if (VideoCapture1.BDA_Source.SourceType == VFBDAType.DVBT)
            {
                VFBDATuningParameters bdaTuningParameters = new VFBDATuningParameters
                {
                    Frequency = Convert.ToInt32(edDVBTFrequency.Text),
                    ONID = Convert.ToInt32(edDVBTONID.Text),
                    SID = Convert.ToInt32(edDVBTSID.Text),
                    TSID = Convert.ToInt32(edDVBTTSID.Text)
                };

                VideoCapture1.BDA_SetParameters(bdaTuningParameters);
            }
        }

        private void SelectVideoCaptureSource()
        {
            VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;
            VideoCapture1.Video_CaptureDevice_IsAudioSource = cbUseAudioInputFromVideoCaptureDevice.Checked;
            VideoCapture1.Video_CaptureDevice_Format_UseBest = cbUseBestVideoInputFormat.Checked;
            VideoCapture1.Video_CaptureDevice_Format = cbVideoInputFormat.Text;

            if (cbVideoInputFrameRate.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice_FrameRate = Convert.ToDouble(cbVideoInputFrameRate.Text, CultureInfo.CurrentCulture);
            }

            VideoCapture1.Video_CaptureDevice_UseClosedCaptions = cbUseClosedCaptions.Checked;
        }

        private void SelectIPCameraSource(out IPCameraSourceSettings settings)
        {
            settings = new IPCameraSourceSettings
            {
                URL = cbIPURL.Text
            };

            bool lavGPU = false;
            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    settings.Type = VFIPSource.Auto_VLC;
                    break;
                case 1:
                    settings.Type = VFIPSource.Auto_FFMPEG;
                    break;
                case 2:
                    settings.Type = VFIPSource.Auto_LAV;
                    break;
                case 3:
                    settings.Type = VFIPSource.Auto_LAV;
                    lavGPU = true;
                    break;
                case 4:
                    settings.Type = VFIPSource.RTSP_Live555;
                    break;
                case 5:
                    settings.Type = VFIPSource.MMS_WMV;
                    break;
                case 6:
                    {
                        settings.Type = VFIPSource.HTTP_MJPEG_LowLatency;
                        cbIPAudioCapture.Checked = false;
                    }
                    break;
                case 7:
                    settings.Type = VFIPSource.RTSP_LowLatency;
                    settings.RTSP_LowLatency_UseUDP = false;
                    break;
                case 8:
                    settings.Type = VFIPSource.RTSP_LowLatency;
                    settings.RTSP_LowLatency_UseUDP = true;
                    break;
                case 9:
                    settings.Type = VFIPSource.NDI;
                    break;
                case 10:
                    settings.Type = VFIPSource.NDI_Legacy;
                    break;
            }

            settings.AudioCapture = cbIPAudioCapture.Checked;
            settings.Login = edIPLogin.Text;
            settings.Password = edIPPassword.Text;
            settings.ForcedFramerate = Convert.ToDouble(edIPForcedFramerate.Text);
            settings.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];
            settings.Debug_Enabled = cbDebugMode.Checked;
            settings.Debug_Filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                      + "\\VisioForge\\ip_cam_log.txt";
            settings.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.Checked;
            settings.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);

            if (settings.Type == VFIPSource.Auto_LAV)
            {
                settings.LAV_GPU_Use = lavGPU;
                settings.LAV_GPU_Mode = VFMediaPlayerSourceGPUDecoder.DXVA2CopyBack;
            }

            if (lbVLCParameters.Items.Count > 0)
            {
                var lst = new List<string>();
                foreach (var item in lbVLCParameters.Items)
                {
                    lst.Add(item.ToString());
                }

                settings.VLC_CustomParameters = lst.ToArray();
            }

            if (cbIPCameraONVIF.Checked)
            {
                settings.ONVIF_Source = true;

                if (cbONVIFProfile.SelectedIndex != -1)
                {
                    settings.ONVIF_SourceProfile = cbONVIFProfile.Text;
                }
            }

            if (cbIPDisconnect.Checked)
            {
                settings.DisconnectEventInterval = TimeSpan.FromSeconds(10);
            }
        }

        private void SelectScreenSource(out ScreenCaptureSourceSettings settings)
        {
            settings = new ScreenCaptureSourceSettings();

            if (rbScreenCaptureWindow.Checked)
            {
                settings.Mode = VFScreenCaptureMode.Window;

                settings.WindowHandle = IntPtr.Zero;

                try
                {
                    if (windowCaptureForm == null)
                    {
                        MessageBox.Show("Window for screen capture is not specified.");
                        return;
                    }

                    settings.WindowHandle = windowCaptureForm.CapturedWindowHandle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (settings.WindowHandle == IntPtr.Zero)
                {
                    MessageBox.Show("Incorrect window title for screen capture.");
                    return;
                }
            }
            else if (rbScreenCaptureColorSource.Checked)
            {
                settings.Mode = VFScreenCaptureMode.Color;

                settings.FullScreen = rbScreenFullScreen.Checked;
                settings.Top = Convert.ToInt32(edScreenTop.Text);
                settings.Bottom = Convert.ToInt32(edScreenBottom.Text);
                settings.Left = Convert.ToInt32(edScreenLeft.Text);
                settings.Right = Convert.ToInt32(edScreenRight.Text);
            }
            else
            {
                settings.Mode = VFScreenCaptureMode.Screen;

                settings.FullScreen = rbScreenFullScreen.Checked;
                settings.Top = Convert.ToInt32(edScreenTop.Text);
                settings.Bottom = Convert.ToInt32(edScreenBottom.Text);
                settings.Left = Convert.ToInt32(edScreenLeft.Text);
                settings.Right = Convert.ToInt32(edScreenRight.Text);

                settings.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);
            }

            settings.FrameRate = Convert.ToInt32(edScreenFrameRate.Text);

            settings.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.Checked;
            settings.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.Checked;
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            tmRecording.Stop();

            VideoCapture1.Video_Filters_Clear();
            await VideoCapture1.StopAsync();

            if (cbMultiscreenDrawOnPanels.Checked)
            {
                pnScreen1.Refresh();
                pnScreen2.Refresh();
                pnScreen3.Refresh();
            }

            foreach (var form in multiscreenWindows)
            {
                form.Close();
            }

            multiscreenWindows.Clear();

            // clear VU Meters
            peakMeterCtrl1.SetData(new int[19], 0, 19);
            peakMeterCtrl1.Stop();

            waveformPainter1.Clear();
            waveformPainter2.Clear();

            volumeMeter1.Clear();
            volumeMeter2.Clear();

            cbPIPDevices.Items.Clear();

            lbFilters.Items.Clear();
        }

        /// <summary>
        /// Audio input format combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once UnusedParameter.Local
        private void cbAudioInputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Format = cbAudioInputFormat.Text;
        }

        /// <summary>
        /// Audio input line combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbAudioInputLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_Line = cbAudioInputLine.Text;
        }

        /// <summary>
        /// Audio output device combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbAudioOutputDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;
        }

        /// <summary>
        /// Crossbar input combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbCrossbarInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCrossbarInput.SelectedIndex != -1)
            {
                string relatedInput;
                string relatedOutput;
                VideoCapture1.Video_CaptureDevice_CrossBar_GetRelated(cbCrossbarInput.Text, cbCrossbarOutput.Text, out relatedInput, out relatedOutput);
            }
        }

        /// <summary>
        /// Crossbar output combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbCrossbarOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCrossbarInput.Items.Clear();

            if (cbCrossbarOutput.SelectedIndex != -1)
            {
                foreach (string s in VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput(cbCrossbarOutput.Text))
                {
                    cbCrossbarInput.Items.Add(s);
                }
            }

            string input = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Text);

            if (input != null)
            {
                cbCrossbarInput.SelectedIndex = cbCrossbarInput.Items.IndexOf(input);
            }
            else
            {
                cbCrossbarInput.SelectedIndex = -1;
            }

            cbCrossbarInput_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// TV Tuner combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbTVTuner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbTVTuner.Items.Count > 0) && (cbTVTuner.SelectedIndex != -1))
            {
                VideoCapture1.TVTuner_Name = cbTVTuner.Text;
                VideoCapture1.TVTuner_Read();

                cbTVMode.Items.Clear();
                foreach (string tunerMode in VideoCapture1.TVTuner_Modes())
                {
                    cbTVMode.Items.Add(tunerMode);
                }

                edVideoFreq.Text = Convert.ToString(VideoCapture1.TVTuner_VideoFrequency);
                edAudioFreq.Text = Convert.ToString(VideoCapture1.TVTuner_AudioFrequency);
                cbTVInput.SelectedIndex = cbTVInput.Items.IndexOf(VideoCapture1.TVTuner_InputType);
                cbTVMode.SelectedIndex = cbTVMode.Items.IndexOf(VideoCapture1.TVTuner_Mode);
                cbTVSystem.SelectedIndex = cbTVSystem.Items.IndexOf(VideoCapture1.TVTuner_TVFormat);
                cbTVCountry.SelectedIndex = cbTVCountry.Items.IndexOf(VideoCapture1.TVTuner_Country);
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
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbVideoInputDevice.Text);
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.First(format => format.Name == cbVideoInputFormat.Text);
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

        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.Checked);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVFVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.Checked;
                }
            }
        }

        private async void btSaveScreenshot_Click(object sender, EventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == DialogResult.OK)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename)?.ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.BMP, 0);
                        break;
                    case ".jpg":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.JPEG, 85);
                        break;
                    case ".gif":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.GIF, 0);
                        break;
                    case ".png":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.PNG, 0);
                        break;
                    case ".tiff":
                        await VideoCapture1.Frame_SaveAsync(filename, VFImageFormat.TIFF, 0);
                        break;
                }
            }
        }

        private void cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.Checked);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVFVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.Checked;
                }
            }
        }

        private async void tbAdjContrast_Scroll(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Contrast, new VideoCaptureDeviceAdjustValue(tbAdjContrast.Value, cbAdjContrastAuto.Checked));
            lbAdjContrastCurrent.Text = "Current: " + Convert.ToString(tbAdjContrast.Value);
        }

        private async void tbAdjHue_Scroll(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Hue, new VideoCaptureDeviceAdjustValue(tbAdjHue.Value, cbAdjHueAuto.Checked));
            lbAdjHueCurrent.Text = "Current: " + Convert.ToString(tbAdjHue.Value);
        }

        private async void tbAdjSaturation_Scroll(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Saturation, new VideoCaptureDeviceAdjustValue(tbAdjSaturation.Value, cbAdjSaturationAuto.Checked));
            lbAdjSaturationCurrent.Text = "Current: " + Convert.ToString(tbAdjSaturation.Value);
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

        private void rbVR_CheckedChanged(object sender, EventArgs e)
        {
            bool flipAvailable = rbVMR9.Checked || rbDirect2D.Checked;

            cbScreenFlipVertical.Enabled = cbFlipVertical1.Enabled = cbFlipVertical2.Enabled = cbFlipVertical3.Enabled = flipAvailable;
            cbScreenFlipHorizontal.Enabled = cbFlipHorizontal1.Enabled = cbFlipHorizontal2.Enabled = cbFlipHorizontal3.Enabled = flipAvailable;
            cbDirect2DRotate.Enabled = rbDirect2D.Checked;

            if (rbVMR9.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else if (rbEVR.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (rbVR.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
            else if (rbDirect2D.Checked)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.Direct2D;
            }
            else
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRenderer.None;
            }
        }

        private void btVideoCaptureDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text);
        }

        private void btAudioInputDeviceSettings_Click(object sender, EventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if ((cbCrossbarInput.SelectedIndex != -1) && (cbCrossbarOutput.SelectedIndex != -1))
            {
                VideoCapture1.Video_CaptureDevice_CrossBar_Connect(cbCrossbarInput.Text, cbCrossbarOutput.Text, cbConnectRelated.Checked);

                lbRotes.Items.Clear();
                for (int i = 0; i < cbCrossbarOutput.Items.Count; i++)
                {
                    string input = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Items[i].ToString());
                    lbRotes.Items.Add("Input: " + input + ", Output: " + cbCrossbarOutput.Items[i]);
                }
            }
        }

        /// <summary>
        /// DV Fast Forward.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private async void btDVFF_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.FastForward);
        }

        /// <summary>
        /// DV pause.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private async void btDVPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Pause);
        }

        private async void btDVRewind_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Rew);
        }

        private async void btDVPlay_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Play);
        }

        private async void btDVStepFWD_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepFw);
        }

        private async void btDVStepRev_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepRev);
        }

        private async void btDVStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Stop);
        }

        private void btRefreshClients_Click(object sender, EventArgs e)
        {
            lbNetworkClients.Items.Clear();

            for (int i = 0; i < VideoCapture1.Network_Streaming_WMV_Clients_GetCount(); i++)
            {
                string dns;
                string address;
                int port;
                VideoCapture1.Network_Streaming_WMV_Clients_GetInfo(i, out port, out address, out dns);

                string client = "ID: " + i + ", Port: " + port + ", Address: " + address + ", DNS: " + dns;
                lbNetworkClients.Items.Add(client);
            }
        }

        private void btStartTune_Click(object sender, EventArgs e)
        {
            const int KHz = 1000;
            const int MHz = 1000000;

            VideoCapture1.TVTuner_Read();
            cbTVChannel.Items.Clear();

            if ((cbTVMode.SelectedIndex != -1) && (cbTVMode.Text == "FM Radio"))
            {
                VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 100 * MHz;
                VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 110 * MHz;
                VideoCapture1.TVTuner_FM_Tuning_Step = 100 * KHz;
            }

            VideoCapture1.TVTuner_TuneChannels_Start();
        }

        private void btStopTune_Click(object sender, EventArgs e)
        {
            VideoCapture1.TVTuner_TuneChannels_Stop();
        }

        private void btUseThisChannel_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(edChannel.Text) <= 10000)
            {
                // channel
                VideoCapture1.TVTuner_Channel = Convert.ToInt32(edChannel.Text);
            }
            else
            {
                // must be -1 to use frequency
                VideoCapture1.TVTuner_Channel = -1;
                VideoCapture1.TVTuner_Frequency = Convert.ToInt32(edChannel.Text);
            }

            VideoCapture1.TVTuner_Apply();
            VideoCapture1.TVTuner_Read();
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
        }

        private void cbTVCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTVCountry.SelectedIndex != -1)
            {
                VideoCapture1.TVTuner_Country = cbTVCountry.Text;
                edTVDefaultFormat.Text = VideoCapture1.TVTuner_Countries_GetPreferredFormatForCountry(VideoCapture1.TVTuner_Country);

                if (VideoCapture1.Status == VFVideoCaptureStatus.Work)
                {
                    VideoCapture1.TVTuner_Apply();
                    VideoCapture1.TVTuner_Read();
                }
            }
        }

        private async void cbStretch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStretch.Checked)
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private void cbTVMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTVMode.SelectedIndex != -1)
            {
                VFTVTunerMode mode;
                Enum.TryParse(cbTVMode.Text, true, out mode);
                VideoCapture1.TVTuner_Mode = mode;

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                cbTVChannel.Items.Clear();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTVChannel.SelectedIndex != -1)
            {
                int k = Convert.ToInt32(cbTVChannel.Text);

                if (k <= 10000)
                {
                    // channel
                    VideoCapture1.TVTuner_Channel = k;
                }
                else
                {
                    // must be -1 to use frequency
                    VideoCapture1.TVTuner_Channel = -1;
                    VideoCapture1.TVTuner_Frequency = k;
                }

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTVInput.SelectedIndex != -1)
            {
                VideoCapture1.TVTuner_InputType = cbTVInput.Text;
                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTVSystem.SelectedIndex != -1)
            {
                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                VideoCapture1.TVTuner_TVFormat = VideoCapture1.TVTuner_TVFormat_FromString(cbTVSystem.Text);
                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbAudioInputFormat.Enabled = !cbUseBestAudioInputFormat.Checked;
        }

        private void cbUseBestVideoInputFormat_CheckedChanged(object sender, EventArgs e)
        {
            cbVideoInputFormat.Enabled = !cbUseBestVideoInputFormat.Checked;
        }

        private void tbAudioVolume_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Volume_Set(tbAudioVolume.Value);
        }

        private void tbAudioBalance_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set(tbAudioBalance.Value);
            VideoCapture1.Audio_OutputDevice_Balance_Get();
        }

        private void btSelectWMVProfileNetwork_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private void btMPEGEncoderShowDialog_Click(object sender, EventArgs e)
        {
            if (cbMPEGEncoder.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = cbMPEGEncoder.Text;
                VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_ShowDialog(IntPtr.Zero);
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                string name = cbFilters.Text;
                btFilterSettings.Enabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                    VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btFilterAdd_Click(object sender, EventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                VideoCapture1.Video_Filters_Add(new VFCustomProcessingFilter(cbFilters.Text));
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

        private void btFilterSettings_Click(object sender, EventArgs e)
        {
            string name = cbFilters.Text;

            if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default))
            {
                VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
            }
            else if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
            {
                VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void lbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.Text;
                btFilterSettings2.Enabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                                            VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btFilterSettings2_Click(object sender, EventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.Text;

                if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
                }
                else if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
                }
            }
        }

        private void btFilterDeleteAll_Click(object sender, EventArgs e)
        {
            lbFilters.Items.Clear();
            VideoCapture1.Video_Filters_Clear();
        }

        private void cbPIPDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPIPDevice.SelectedIndex != -1)
            {
                cbPIPFormat.Items.Clear();
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.First(device => device.Name == cbPIPDevice.Text);
                if (deviceItem != null)
                {
                    foreach (var format in deviceItem.VideoFormats)
                    {
                        cbPIPFormat.Items.Add(format.Name);
                    }

                    if (cbPIPFormat.Items.Count > 0)
                    {
                        cbPIPFormat.SelectedIndex = 0;
                    }

                    cbPIPInput.Items.Clear();

                    VideoCapture1.PIP_Sources_Device_GetCrossbar(cbPIPDevice.Text);
                    foreach (string input in VideoCapture1.PIP_Sources_Device_GetCrossbarInputs())
                    {
                        cbPIPInput.Items.Add(input);
                    }

                    if (cbPIPInput.Items.Count > 0)
                    {
                        cbPIPInput.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cbMPEGVideoDecoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMPEGVideoDecoder.SelectedIndex < 1)
            {
                btMPEGVidDecSetting.Enabled = false;
            }
            else
            {
                string name = cbMPEGVideoDecoder.Text;
                btMPEGVidDecSetting.Enabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                  VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void cbMPEGAudioDecoder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMPEGAudioDecoder.SelectedIndex < 1)
            {
                btMPEGAudDecSettings.Enabled = false;
            }
            else
            {
                string name = cbMPEGVideoDecoder.Text;
                btMPEGAudDecSettings.Enabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                  VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btMPEGVidDecSetting_Click(object sender, EventArgs e)
        {
            if (cbMPEGVideoDecoder.SelectedIndex > 0)
            {
                string name = cbMPEGVideoDecoder.Text;

                if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
                }
                else if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
                }
            }
        }

        private void btMPEGAudDecSettings_Click(object sender, EventArgs e)
        {
            if (cbMPEGAudioDecoder.SelectedIndex > 0)
            {
                string name = cbMPEGAudioDecoder.Text;

                if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
                }
                else if (VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
                {
                    VideoCapture.DirectShow_Filter_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
                }
            }
        }

        private async void btScreenCaptureUpdate_Click(object sender, EventArgs e)
        {
            await VideoCapture1.Screen_Capture_UpdateParametersAsync(
                Convert.ToInt32(edScreenLeft.Text),
                Convert.ToInt32(edScreenTop.Text),
                cbScreenCapture_GrabMouseCursor.Checked);
        }

        private void cbPIPFormatUseBest_CheckedChanged(object sender, EventArgs e)
        {
            cbPIPFormat.Enabled = !cbPIPFormatUseBest.Checked;
        }

        private void btPIPAddDevice_Click(object sender, EventArgs e)
        {
            if (cbPIPDevice.SelectedIndex != -1)
            {
                string frameRate;
                if (cbPIPFrameRate.SelectedIndex != -1)
                {
                    frameRate = cbPIPFrameRate.Text;
                }
                else
                {
                    frameRate = "0";
                }

                string format;
                if (cbPIPFormat.SelectedIndex != -1)
                {
                    format = cbPIPFormat.Text;
                }
                else
                {
                    format = string.Empty;
                }

                string input;
                if (cbPIPInput.SelectedIndex != -1)
                {
                    input = cbPIPInput.Text;
                }
                else
                {
                    input = string.Empty;
                }

                VideoCapture1.PIP_Sources_Add_VideoCaptureDevice(
                    cbPIPDevice.Text,
                    format,
                    cbPIPFormatUseBest.Checked,
                    Convert.ToDouble(frameRate),
                    input,
                    Convert.ToInt32(edPIPVidCapLeft.Text),
                    Convert.ToInt32(edPIPVidCapTop.Text),
                    Convert.ToInt32(edPIPVidCapWidth.Text),
                    Convert.ToInt32(edPIPVidCapHeight.Text));

                cbPIPDevices.Items.Add(cbPIPDevice.Text);
            }
        }

        private void btOSDClearLayers_Click(object sender, EventArgs e)
        {
            VideoCapture1.OSD_Layers_Clear();
            lbOSDLayers.Items.Clear();
        }

        private void btOSDLayerAdd_Click(object sender, EventArgs e)
        {
            VideoCapture1.OSD_Layers_Create(
                Convert.ToInt32(edOSDLayerLeft.Text),
                Convert.ToInt32(edOSDLayerTop.Text),
                Convert.ToInt32(edOSDLayerWidth.Text),
                Convert.ToInt32(edOSDLayerHeight.Text),
                true);
            lbOSDLayers.Items.Add("layer " + Convert.ToString(lbOSDLayers.Items.Count + 1), CheckState.Checked);
        }

        private void btOSDSelectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                edOSDImageFilename.Text = openFileDialog2.FileName;
            }
        }

        private void btOSDImageDraw_Click(object sender, EventArgs e)
        {
            if (lbOSDLayers.SelectedIndex != -1)
            {
                if (cbOSDImageTranspColor.Checked)
                {
                    VideoCapture1.OSD_Layers_Draw_Image(
                        lbOSDLayers.SelectedIndex,
                        edOSDImageFilename.Text,
                        Convert.ToInt32(edOSDImageLeft.Text),
                        Convert.ToInt32(edOSDImageTop.Text),
                        true,
                        pnOSDColorKey.BackColor);
                }
                else
                {
                    VideoCapture1.OSD_Layers_Draw_Image(
                        lbOSDLayers.SelectedIndex,
                        edOSDImageFilename.Text,
                        Convert.ToInt32(edOSDImageLeft.Text),
                        Convert.ToInt32(edOSDImageTop.Text),
                        false,
                        Color.Black);
                }
            }
            else
            {
                MessageBox.Show(this, "Please select OSD layer.");
            }
        }

        private void btOSDSelectFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                edOSDText.Font = fontDialog1.Font;
                edOSDText.ForeColor = fontDialog1.Color;
            }
        }

        private void btOSDTextDraw_Click(object sender, EventArgs e)
        {
            if (lbOSDLayers.SelectedIndex != -1)
            {
                Font fnt = edOSDText.Font;
                Color color = edOSDText.ForeColor;

                VideoCapture1.OSD_Layers_Draw_Text(
                    lbOSDLayers.SelectedIndex,
                    Convert.ToInt32(edOSDTextLeft.Text),
                    Convert.ToInt32(edOSDTextTop.Text),
                    edOSDText.Text,
                    fnt,
                    color);
            }
            else
            {
                MessageBox.Show(this, "Please select OSD layer.");
            }
        }

        private void btOSDSetTransp_Click(object sender, EventArgs e)
        {
            if (lbOSDLayers.SelectedIndex != -1)
            {
                VideoCapture1.OSD_Layers_SetTransparency(lbOSDLayers.SelectedIndex, (byte)tbOSDTranspLevel.Value);
                VideoCapture1.OSD_Layers_Render();
            }
            else
            {
                MessageBox.Show(this, "Please select OSD layer.");
            }
        }

        private async void cbScreenFlipVertical_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void cbScreenFlipHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.Checked)
            {
                VideoCapture1.Motion_Detection = new MotionDetectionSettings
                {
                    Enabled = cbMotDetEnabled.Checked,
                    Compare_Red = cbCompareRed.Checked,
                    Compare_Green = cbCompareGreen.Checked,
                    Compare_Blue = cbCompareBlue.Checked,
                    Compare_Greyscale = cbCompareGreyscale.Checked,
                    Highlight_Color =
                                                             (VFMotionCHLColor)cbMotDetHLColor.SelectedIndex,
                    Highlight_Enabled = cbMotDetHLEnabled.Checked,
                    Highlight_Threshold = tbMotDetHLThreshold.Value,
                    FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text),
                    Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text),
                    Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text),
                    DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked,
                    DropFrames_Threshold = tbMotDetDropFramesThreshold.Value
                };
                VideoCapture1.MotionDetection_Update();
            }
            else
            {
                VideoCapture1.Motion_Detection = null;
            }
        }

        private void btMotDetUpdateSettings_Click(object sender, EventArgs e)
        {
            ConfigureMotionDetection();
        }

        #region Barcode detector

        private delegate void BarcodeDelegate(BarcodeEventArgs value);

        private void BarcodeDelegateMethod(BarcodeEventArgs value)
        {
            edBarcode.Text = value.Value;
            edBarcodeMetadata.Text = string.Empty;

            if (value.Metadata == null)
            {
                return;
            }

            foreach (var o in value.Metadata)
            {
                edBarcodeMetadata.Text += o.Key + ": " + o.Value + Environment.NewLine;
            }
        }

        private void VideoCapture1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        private delegate void MotionDelegate(MotionDetectionEventArgs e);

        private void MotionDelegateMethod(MotionDetectionEventArgs e)
        {
            string s = string.Empty;
            int k = 0;
            foreach (byte b in e.Matrix)
            {
                s += b.ToString("D3") + " ";

                if (k == VideoCapture1.Motion_Detection.Matrix_Width - 1)
                {
                    k = 0;
                    s += Environment.NewLine;
                }
                else
                {
                    k++;
                }
            }

            mmMotDetMatrix.Text = s.Trim();
            pbMotionLevel.Value = e.Level;
        }

        private void VideoCapture1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        private void btAudEqRefresh_Click(object sender, EventArgs e)
        {
            tbAudEq0.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 0);
            tbAudEq1.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 1);
            tbAudEq2.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 2);
            tbAudEq3.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 3);
            tbAudEq4.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 4);
            tbAudEq5.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 5);
            tbAudEq6.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 6);
            tbAudEq7.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 7);
            tbAudEq8.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 8);
            tbAudEq9.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, 1, 9);
        }

        private async void btSignal_Click(object sender, EventArgs e)
        {
            if (await VideoCapture1.Video_CaptureDevice_SignalPresentAsync())
            {
                MessageBox.Show("Signal present");
            }
            else
            {
                MessageBox.Show("Signal not present");
            }
        }

        private async void btZoomIn_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio + 5;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomOut_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio - 5;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftDown_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY - 2;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftLeft_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX - 2;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftRight_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX + 2;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftUp_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY + 2;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomReset_Click(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private void cbAudAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 0, cbAudAmplifyEnabled.Checked);
        }

        private void cbAudDynamicAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 2, cbAudDynamicAmplifyEnabled.Checked);
        }

        private void cbAudEqualizerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 1, cbAudEqualizerEnabled.Checked);
        }

        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, 1, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        private void cbAudSound3DEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 3, cbAudSound3DEnabled.Checked);
        }

        private void cbAudTrueBassEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 4, cbAudTrueBassEnabled.Checked);
        }

        private async void cbStretch1_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch1.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(0, stretch, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked);
        }

        private async void cbStretch2_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch2.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(1, stretch, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked);
        }

        private async void cbStretch3_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch3.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(2, stretch, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked);
        }

        private async void tbAdjBrightness_Scroll(object sender, EventArgs e)
        {
            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(
                VFVideoHardwareAdjustment.Brightness,
                new VideoCaptureDeviceAdjustValue(tbAdjBrightness.Value, cbAdjBrightnessAuto.Checked));
            lbAdjBrightnessCurrent.Text = "Current: " + Convert.ToString(tbAdjBrightness.Value);
        }

        private void tbAud3DSound_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Sound3D(-1, 3, (ushort)tbAud3DSound.Value);
        }

        private void tbAudDynAmp_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_DynamicAmplify(-1, 2, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void tbAudAttack_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_DynamicAmplify(-1, 2, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void tbAudEq0_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 0, (sbyte)tbAudEq0.Value);
        }

        private void tbAudEq1_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 1, (sbyte)tbAudEq1.Value);
        }

        private void tbAudEq2_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 2, (sbyte)tbAudEq2.Value);
        }

        private void tbAudEq3_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 3, (sbyte)tbAudEq3.Value);
        }

        private void tbAudEq4_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 4, (sbyte)tbAudEq4.Value);
        }

        private void tbAudEq5_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 5, (sbyte)tbAudEq5.Value);
        }

        private void tbAudEq6_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 6, (sbyte)tbAudEq6.Value);
        }

        private void tbAudEq7_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 7, (sbyte)tbAudEq7.Value);
        }

        private void tbAudEq8_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 8, (sbyte)tbAudEq8.Value);
        }

        private void tbAudEq9_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 9, (sbyte)tbAudEq9.Value);
        }

        private void tbAudTrueBass_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_TrueBass(-1, 4, 200, false, (ushort)tbAudTrueBass.Value);
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVFVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = tbContrast.Value;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVFVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = tbDarkness.Value;
                }
            }
        }

        private void tbLightness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVFVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectSaturation saturation;
            var effect = VideoCapture1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VFVideoEffectSaturation(tbSaturation.Value);
                VideoCapture1.Video_Effects_Add(saturation);
            }
            else
            {
                saturation = effect as IVFVideoEffectSaturation;
                if (saturation != null)
                {
                    saturation.Value = tbSaturation.Value;
                }
            }
        }

        private void tbAudAmplifyAmp_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_Amplify(-1, 0, tbAudAmplifyAmp.Value * 10, false);
        }

        private void tbAudRelease_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Effects_DynamicAmplify(-1, 2, (ushort)tbAudAttack.Value, (ushort)tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void pnOSDColorKey_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnOSDColorKey.BackColor = colorDialog1.Color;
            }
        }

        private async void cbFlipVertical1_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch1.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(0, stretch, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked);
        }

        private async void cbFlipHorizontal1_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch1.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(0, stretch, cbFlipHorizontal1.Checked, cbFlipVertical1.Checked);
        }

        private async void cbFlipVertical2_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch2.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(1, stretch, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked);
        }

        private async void cbFlipHorizontal2_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch2.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(1, stretch, cbFlipHorizontal2.Checked, cbFlipVertical2.Checked);
        }

        private async void cbFlipVertical3_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch3.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(2, stretch, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked);
        }

        private async void cbFlipHorizontal3_CheckedChanged(object sender, EventArgs e)
        {
            VFVideoRendererStretchMode stretch;
            if (cbStretch3.Checked)
            {
                stretch = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                stretch = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.MultiScreen_SetParametersAsync(2, stretch, cbFlipHorizontal3.Checked, cbFlipVertical3.Checked);
        }

        private void btChromaKeySelectBGImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
                ConfigureChromaKey();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void VideoCapture1_OnTVTunerTuneChannels(object sender, TVTunerTuneChannelsEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                Application.DoEvents();

                pbChannels.Value = e.Progress;

                if (e.SignalPresent)
                {
                    cbTVChannel.Items.Add(e.Channel.ToString(CultureInfo.InvariantCulture));
                }

                if (e.Channel == -1)
                {
                    pbChannels.Value = 0;
                    MessageBox.Show("AutoTune complete");
                }

                Application.DoEvents();
            }));
        }

        #region VU Meter

        private delegate void VUDelegate(VUMeterEventArgs e);

        private void VUDelegateMethod(VUMeterEventArgs e)
        {
            if (VideoCapture1.Status == VFVideoCaptureStatus.Free)
            {
                return;
            }

            peakMeterCtrl1.SetData(e.MeterData, 0, 19);
        }

        private void VideoCapture1_OnAudioVUMeter(object sender, VUMeterEventArgs e)
        {
            BeginInvoke(new VUDelegate(VUDelegateMethod), e);
        }

        #endregion

        private delegate void AFMotionDelegate(float level);

        private void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        private void VideoCapture1_OnMotionDetectionEx(object sender, MotionDetectionExEventArgs e)
        {
            BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        private void cbAFMotionDetection_CheckedChanged(object sender, EventArgs e)
        {
            ConfigureMotionDetectionEx();
        }

        private async void btSeparateCaptureStart_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text);
        }

        private async void btSeparateCaptureStop_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_StopAsync();
        }

        private async void btSeparateCaptureChangeFilename_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text);
        }

        private async void btCCReadValues_Click(object sender, EventArgs e)
        {
            var pan = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Pan);
            if (pan != null)
            {
                tbCCPan.Minimum = pan.Min;
                tbCCPan.Maximum = pan.Max;
                tbCCPan.SmallChange = pan.Step;
                tbCCPan.Value = pan.Default;
                lbCCPanMin.Text = "Min: " + Convert.ToString(pan.Min);
                lbCCPanMax.Text = "Max: " + Convert.ToString(pan.Max);
                lbCCPanCurrent.Text = "Current: " + Convert.ToString(pan.Default);

                cbCCPanManual.Checked = (pan.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCPanAuto.Checked = (pan.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCPanRelative.Checked = (pan.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var tilt = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Tilt);
            if (tilt != null)
            {
                tbCCTilt.Minimum = tilt.Min;
                tbCCTilt.Maximum = tilt.Max;
                tbCCTilt.SmallChange = tilt.Step;
                tbCCTilt.Value = tilt.Default;
                lbCCTiltMin.Text = "Min: " + Convert.ToString(tilt.Min);
                lbCCTiltMax.Text = "Max: " + Convert.ToString(tilt.Max);
                lbCCTiltCurrent.Text = "Current: " + Convert.ToString(tilt.Default);

                cbCCTiltManual.Checked = (tilt.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCTiltAuto.Checked = (tilt.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCTiltRelative.Checked = (tilt.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var focus = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Focus);
            if (focus != null)
            {
                tbCCFocus.Minimum = focus.Min;
                tbCCFocus.Maximum = focus.Max;
                tbCCFocus.SmallChange = focus.Step;
                tbCCFocus.Value = focus.Default;
                lbCCFocusMin.Text = "Min: " + Convert.ToString(focus.Min);
                lbCCFocusMax.Text = "Max: " + Convert.ToString(focus.Max);
                lbCCFocusCurrent.Text = "Current: " + Convert.ToString(focus.Default);

                cbCCFocusManual.Checked = (focus.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCFocusAuto.Checked = (focus.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCFocusRelative.Checked = (focus.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var zoomRange = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Zoom);
            if (zoomRange != null)
            {
                tbCCZoom.Minimum = zoomRange.Min;
                tbCCZoom.Maximum = zoomRange.Max;
                tbCCZoom.SmallChange = zoomRange.Step;
                tbCCZoom.Value = zoomRange.Default;
                lbCCZoomMin.Text = "Min: " + Convert.ToString(zoomRange.Min);
                lbCCZoomMax.Text = "Max: " + Convert.ToString(zoomRange.Max);
                lbCCZoomCurrent.Text = "Current: " + Convert.ToString(zoomRange.Default);

                cbCCZoomManual.Checked = (zoomRange.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCZoomAuto.Checked = (zoomRange.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCZoomRelative.Checked = (zoomRange.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }
        }

        private async void btCCPanApply_Click(object sender, EventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCPanManual.Checked)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCPanAuto.Checked)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCPanRelative.Checked)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Pan, new VideoCaptureDeviceCameraControlValue(tbCCPan.Value, flags));
        }

        private async void btCCTiltApply_Click(object sender, EventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCTiltManual.Checked)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCTiltAuto.Checked)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCTiltRelative.Checked)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Tilt, new VideoCaptureDeviceCameraControlValue(tbCCTilt.Value, flags));
        }

        private void btPIPAddIPCamera_Click(object sender, EventArgs e)
        {
            IPCameraSourceSettings ipCameraSource;
            SelectIPCameraSource(out ipCameraSource);

            VideoCapture1.PIP_Sources_Add_IPCamera(
                ipCameraSource,
                Convert.ToInt32(edPIPScreenCapLeft.Text),
                Convert.ToInt32(edPIPScreenCapTop.Text),
                Convert.ToInt32(edPIPScreenCapWidth.Text),
                Convert.ToInt32(edPIPScreenCapHeight.Text));

            cbPIPDevices.Items.Add("IP Capture");
        }

        private void btPIPAddScreenCapture_Click(object sender, EventArgs e)
        {
            ScreenCaptureSourceSettings screenSource;
            SelectScreenSource(out screenSource);

            VideoCapture1.PIP_Sources_Add_ScreenSource(
                screenSource,
                Convert.ToInt32(edPIPScreenCapLeft.Text),
                Convert.ToInt32(edPIPScreenCapTop.Text),
                Convert.ToInt32(edPIPScreenCapWidth.Text),
                Convert.ToInt32(edPIPScreenCapHeight.Text));

            cbPIPDevices.Items.Add("Screen Capture");
        }

        private void btPIPDevicesClear_Click(object sender, EventArgs e)
        {
            VideoCapture1.PIP_Sources_Clear();
            cbPIPDevices.Items.Clear();
        }

        private async void btPIPUpdate_Click(object sender, EventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                var pos = new Rectangle(
                    Convert.ToInt32(edPIPLeft.Text),
                    Convert.ToInt32(edPIPTop.Text),
                    Convert.ToInt32(edPIPWidth.Text),
                    Convert.ToInt32(edPIPHeight.Text));
                await VideoCapture1.PIP_Sources_SetSourcePositionAsync(cbPIPDevices.SelectedIndex, pos);
            }
            else
            {
                MessageBox.Show("Select device!");
            }
        }

        private async void btPIPSet_Click(object sender, EventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                await VideoCapture1.PIP_Sources_SetSourceSettingsAsync(cbPIPDevices.SelectedIndex, tbPIPTransparency.Value, false, false);
            }
            else
            {
                MessageBox.Show("Select device!");
            }
        }

        private void btPIPSetOutputSize_Click(object sender, EventArgs e)
        {
            VideoCapture1.PIP_CustomOutputSize_Set(Convert.ToInt32(edPIPOutputWidth.Text), Convert.ToInt32(edPIPOutputHeight.Text));
        }

        private void btDVBTTune_Click(object sender, EventArgs e)
        {
            if (VideoCapture1.BDA_Source != null && VideoCapture1.BDA_Source.SourceType == VFBDAType.DVBT)
            {
                VFBDATuningParameters bdaTuningParameters = new VFBDATuningParameters
                {
                    Frequency = Convert.ToInt32(edDVBTFrequency.Text),
                    ONID = Convert.ToInt32(edDVBTONID.Text),
                    SID = Convert.ToInt32(edDVBTSID.Text),
                    TSID = Convert.ToInt32(edDVBTTSID.Text)
                };

                VideoCapture1.BDA_SetParameters(bdaTuningParameters);
            }
        }

        private async void btSeparateCapturePause_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_PauseAsync();
        }

        private async void btSeparateCaptureResume_Click(object sender, EventArgs e)
        {
            await VideoCapture1.SeparateCapture_ResumeAsync();
        }

        private void cbZoom_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectZoom zoomEffect;
            var effect = VideoCapture1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VFVideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoom.Checked);
                VideoCapture1.Video_Effects_Add(zoomEffect);
            }
            else
            {
                zoomEffect = effect as IVFVideoEffectZoom;
            }

            if (zoomEffect == null)
            {
                MessageBox.Show("Unable to configure zoom effect.");
                return;
            }

            zoomEffect.ZoomX = zoom;
            zoomEffect.ZoomY = zoom;
            zoomEffect.ShiftX = zoomShiftX;
            zoomEffect.ShiftY = zoomShiftY;
            zoomEffect.Enabled = cbZoom.Checked;
        }

        private void btEffZoomIn_Click(object sender, EventArgs e)
        {
            zoom += 0.1;
            zoom = Math.Min(zoom, 5);

            cbZoom_CheckedChanged(null, null);
        }

        private void btEffZoomOut_Click(object sender, EventArgs e)
        {
            zoom -= 0.1;
            zoom = Math.Max(zoom, 1);

            cbZoom_CheckedChanged(null, null);
        }

        private void btEffZoomUp_Click(object sender, EventArgs e)
        {
            zoomShiftY += 20;

            cbZoom_CheckedChanged(null, null);
        }

        private void btEffZoomDown_Click(object sender, EventArgs e)
        {
            zoomShiftY -= 20;

            cbZoom_CheckedChanged(null, null);
        }

        private void btEffZoomRight_Click(object sender, EventArgs e)
        {
            zoomShiftX += 20;

            cbZoom_CheckedChanged(null, null);
        }

        private void btEffZoomLeft_Click(object sender, EventArgs e)
        {
            zoomShiftX -= 20;

            cbZoom_CheckedChanged(null, null);
        }

        private void cbPan_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectPan pan;
            var effect = VideoCapture1.Video_Effects_Get("Pan");
            if (effect == null)
            {
                pan = new VFVideoEffectPan(true);
                VideoCapture1.Video_Effects_Add(pan);
            }
            else
            {
                pan = effect as IVFVideoEffectPan;
            }

            if (pan == null)
            {
                MessageBox.Show("Unable to configure pan effect.");
                return;
            }

            pan.Enabled = cbPan.Checked;
            pan.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStartTime.Text));
            pan.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt32(edPanStopTime.Text));
            pan.StartX = Convert.ToInt32(edPanSourceLeft.Text);
            pan.StartY = Convert.ToInt32(edPanSourceTop.Text);
            pan.StartWidth = Convert.ToInt32(edPanSourceWidth.Text);
            pan.StartHeight = Convert.ToInt32(edPanSourceHeight.Text);
            pan.StopX = Convert.ToInt32(edPanDestLeft.Text);
            pan.StopY = Convert.ToInt32(edPanDestTop.Text);
            pan.StopWidth = Convert.ToInt32(edPanDestWidth.Text);
            pan.StopHeight = Convert.ToInt32(edPanDestHeight.Text);
        }

        private void btBarcodeReset_Click(object sender, EventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoCapture1.Barcode_Reader_Enabled = true;
        }

        private void btAddAdditionalAudioSource_Click(object sender, EventArgs e)
        {
            VideoCapture1.Additional_Audio_CaptureDevice_Add(cbAdditionalAudioSource.Text);
            MessageBox.Show(cbAdditionalAudioSource.Text + " added");
        }

        private void btPIPFileSourceAdd_Click(object sender, EventArgs e)
        {
            VideoCapture1.PIP_Sources_Add_VideoFile(
                edPIPFileSoureFilename.Text,
                Convert.ToInt32(edPIPFileLeft.Text),
                Convert.ToInt32(edPIPFileTop.Text),
                Convert.ToInt32(edPIPFileWidth.Text),
                Convert.ToInt32(edPIPFileHeight.Text));
            cbPIPDevices.Items.Add("File source");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edPIPFileSoureFilename.Text = openFileDialog1.FileName;
            }
        }

        private void cbFadeInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFadeIn.Checked)
            {
                IVFVideoEffectFadeIn fadeIn;
                var effect = VideoCapture1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VFVideoEffectFadeIn(cbFadeInOut.Checked);
                    VideoCapture1.Video_Effects_Add(fadeIn);
                }
                else
                {
                    fadeIn = effect as IVFVideoEffectFadeIn;
                }

                if (fadeIn == null)
                {
                    MessageBox.Show("Unable to configure fade-in effect.");
                    return;
                }

                fadeIn.Enabled = cbFadeInOut.Checked;
                fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
            else
            {
                IVFVideoEffectFadeOut fadeOut;
                var effect = VideoCapture1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VFVideoEffectFadeOut(cbFadeInOut.Checked);
                    VideoCapture1.Video_Effects_Add(fadeOut);
                }
                else
                {
                    fadeOut = effect as IVFVideoEffectFadeOut;
                }

                if (fadeOut == null)
                {
                    MessageBox.Show("Unable to configure fade-out effect.");
                    return;
                }

                fadeOut.Enabled = cbFadeInOut.Checked;
                fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer);
            Process.Start(startInfo);
        }

        private void VideoCapture1_OnBDAChannelFound(object sender, BDAChannelEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                Application.DoEvents();

                ListViewItem lvi = new ListViewItem(
                    new[]
                    {
                        e.Channel.Name,
                        e.Channel.Frequency.ToString(CultureInfo.InvariantCulture),
                        e.Channel.AudioPid.ToString(CultureInfo.InvariantCulture),
                        e.Channel.VideoPid.ToString(CultureInfo.InvariantCulture),
                        e.Channel.ServId.ToString(CultureInfo.InvariantCulture),
                        e.Channel.SymbolRate.ToString(CultureInfo.InvariantCulture)
                    });

                lvBDAChannels.Items.Add(lvi);

                Application.DoEvents();
            }));
        }

        private void btBDAChannelScanningStart_Click(object sender, EventArgs e)
        {
            lvBDAChannels.Items.Clear();
            VideoCapture1.BDA_ScanChannels();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder);
            Process.Start(startInfo);
        }

        private void VideoCapture1_OnFaceDetected(object sender, AFFaceDetectionEventArgs e)
        {
            BeginInvoke(new FaceDelegate(FaceDelegateMethod), e);
        }

        private delegate void FaceDelegate(AFFaceDetectionEventArgs e);

        private void FaceDelegateMethod(AFFaceDetectionEventArgs e)
        {
            edFaceTrackingFaces.Text = string.Empty;

            foreach (var faceRectangle in e.FaceRectangles)
            {
                edFaceTrackingFaces.Text += "(" + faceRectangle.Left + ", " + faceRectangle.Top + "), ("
                                            + faceRectangle.Width + ", " + faceRectangle.Height + ")" + Environment.NewLine;
            }
        }

        #region Full screen

        private bool fullScreen;

        private int windowLeft;

        private int windowTop;

        private int windowWidth;

        private int windowHeight;

        private int controlLeft;

        private int controlTop;

        private int controlWidth;

        private int controlHeight;

        private async void btFullScreen_Click(object sender, EventArgs e)
        {
            if (!fullScreen)
            {
                // going fullscreen
                fullScreen = true;

                // saving coordinates
                windowLeft = Left;
                windowTop = Top;
                windowWidth = Width;
                windowHeight = Height;

                controlLeft = VideoCapture1.Left;
                controlTop = VideoCapture1.Top;
                controlWidth = VideoCapture1.Width;
                controlHeight = VideoCapture1.Height;

                // Debug.WriteLine($"ON fullscreen: {controlLeft}x{controlTop} | {controlWidth}x{controlHeight}");

                // resizing window
                Left = 0;
                Top = 0;
                Width = Screen.AllScreens[0].WorkingArea.Width;
                Height = Screen.AllScreens[0].WorkingArea.Height;

                TopMost = true;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;

                // resizing control
                VideoCapture1.Left = 0;
                VideoCapture1.Top = 0;
                VideoCapture1.Width = Width;
                VideoCapture1.Height = Height;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoCapture1.Left = controlLeft;
                VideoCapture1.Top = controlTop;
                VideoCapture1.Width = controlWidth;
                VideoCapture1.Height = controlHeight;

                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                TopMost = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        private void VideoCapture1_MouseDown(object sender, MouseEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.IISSmoothStreaming);
            Process.Start(startInfo);
        }


        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Invoke((Action)(
                async () =>
                    {
                        await VideoCapture1.StopAsync();

                        MessageBox.Show("Network source stopped or disconnected!");
                    }));
        }

        private void VideoCapture1_OnAudioVUMeterProVolume(object sender, AudioLevelEventArgs e)
        {
            BeginInvoke((Action)(() =>
           {
               volumeMeter1.Amplitude = e.ChannelLevelsDb[0];
               waveformPainter1.AddMax(e.ChannelLevels[0] / 100f);

               if (e.ChannelLevelsDb.Length > 1)
               {
                   volumeMeter2.Amplitude = e.ChannelLevelsDb[1];
                   waveformPainter2.AddMax(e.ChannelLevels[1] / 100f);
               }
           }));
        }

        private void tbVUMeterAmplification_Scroll(object sender, EventArgs e)
        {
            VideoCapture1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value;
        }

        private void tbVUMeterBoost_Scroll(object sender, EventArgs e)
        {
            volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F;
            volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F;

            waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F;
            waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F;
        }

        private void cbLiveRotation_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectRotate rotate;
            var effect = VideoCapture1.Video_Effects_Get("Rotate");
            if (effect == null)
            {
                rotate = new VFVideoEffectRotate(
                    cbLiveRotation.Checked,
                    tbLiveRotationAngle.Value,
                    cbLiveRotationStretch.Checked);
                VideoCapture1.Video_Effects_Add(rotate);
            }
            else
            {
                rotate = effect as IVFVideoEffectRotate;
            }

            if (rotate == null)
            {
                MessageBox.Show("Unable to configure rotate effect.");
                return;
            }

            rotate.Enabled = cbLiveRotation.Checked;
            rotate.Angle = tbLiveRotationAngle.Value;
            rotate.Stretch = cbLiveRotationStretch.Checked;
        }

        private void tbLiveRotationDegree_Scroll(object sender, EventArgs e)
        {
            cbLiveRotation_CheckedChanged(sender, e);
        }

        private void cbLiveRotationStretch_CheckedChanged(object sender, EventArgs e)
        {
            cbLiveRotation_CheckedChanged(sender, e);
        }

        private async void cbDirect2DRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void pnVideoRendererBGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnVideoRendererBGColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnVideoRendererBGColor.BackColor = colorDialog1.Color;

                VideoCapture1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor;
                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        private void cbCustomVideoSourceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCustomVideoSourceFilter.Items.Clear();

            if (cbCustomVideoSourceCategory.SelectedIndex == 0)
            {
                var filters = VideoCapture1.Video_CaptureDevicesInfo;
                foreach (var item in filters)
                {
                    cbCustomVideoSourceFilter.Items.Add(item.Name);
                }

                if (filters.Count > 0)
                {
                    cbCustomVideoSourceFilter.SelectedIndex = 0;
                }
            }
            else if (cbCustomVideoSourceCategory.SelectedIndex == 1)
            {
                var filters = VideoCapture1.DirectShow_Filters;
                foreach (var item in filters)
                {
                    cbCustomVideoSourceFilter.Items.Add(item);
                }

                if (filters.Count > 0)
                {
                    cbCustomVideoSourceFilter.SelectedIndex = 0;
                }
            }
        }

        private void cbCustomAudioSourceCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCustomAudioSourceFilter.Items.Clear();
            cbCustomAudioSourceFilter.Items.Add(string.Empty);

            if (cbCustomAudioSourceCategory.SelectedIndex == 0)
            {
                var filters = VideoCapture1.Audio_CaptureDevicesInfo;
                foreach (var item in filters)
                {
                    cbCustomAudioSourceFilter.Items.Add(item.Name);
                }

                if (filters.Count > 0)
                {
                    cbCustomAudioSourceFilter.SelectedIndex = 0;
                }
            }
            else if (cbCustomAudioSourceCategory.SelectedIndex == 1)
            {
                var filters = VideoCapture1.DirectShow_Filters;
                foreach (var item in filters)
                {
                    cbCustomAudioSourceFilter.Items.Add(item);
                }

                if (filters.Count > 0)
                {
                    cbCustomAudioSourceFilter.SelectedIndex = 0;
                }
            }
        }

        private void cbCustomVideoSourceFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbCustomVideoSourceFilter.Text))
            {
                cbCustomVideoSourceFormat.Items.Clear();
                cbCustomVideoSourceFrameRate.Items.Clear();

                List<VideoCaptureDeviceFormat> formats;

                if (cbCustomVideoSourceCategory.SelectedIndex == 0)
                {
                    VideoCapture1.DirectShow_Filter_GetVideoFormats(
                        VFFilterCategory.VideoCaptureSource,
                        cbCustomVideoSourceFilter.Text,
                        VFMediaCategory.Video,
                        out formats);
                }
                else
                {
                    VideoCapture1.DirectShow_Filter_GetVideoFormats(
                        VFFilterCategory.DirectShowFilters,
                        cbCustomVideoSourceFilter.Text,
                        VFMediaCategory.Video,
                        out formats);
                }

                foreach (var format in formats)
                {
                    cbCustomVideoSourceFormat.Items.Add(format.Name);
                }
            }
        }

        private void cbCustomAudioSourceFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbCustomAudioSourceFilter.Text))
            {
                cbCustomAudioSourceFormat.Items.Clear();

                List<string> formats;

                if (cbCustomAudioSourceCategory.SelectedIndex == 0)
                {
                    VideoCapture1.DirectShow_Filter_GetAudioFormats(
                        VFFilterCategory.AudioCaptureSource,
                        cbCustomAudioSourceFilter.Text,
                        VFMediaCategory.Audio,
                        out formats);
                }
                else
                {
                    VideoCapture1.DirectShow_Filter_GetAudioFormats(
                        VFFilterCategory.DirectShowFilters,
                        cbCustomAudioSourceFilter.Text,
                        VFMediaCategory.Audio,
                        out formats);
                }

                foreach (var format in formats)
                {
                    cbCustomAudioSourceFormat.Items.Add(format);
                }
            }
        }

        private void cbAudioNormalize_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Enhancer_Normalize(cbAudioNormalize.Checked);
        }

        private void cbAudioAutoGain_CheckedChanged(object sender, EventArgs e)
        {
            VideoCapture1.Audio_Enhancer_AutoGain(cbAudioAutoGain.Checked);
        }

        private void ApplyAudioInputGains()
        {
            VFAudioEnhancerGains gains = new VFAudioEnhancerGains
            {
                L = tbAudioInputGainL.Value / 10.0f,
                C = tbAudioInputGainC.Value / 10.0f,
                R = tbAudioInputGainR.Value / 10.0f,
                SL = tbAudioInputGainSL.Value / 10.0f,
                SR = tbAudioInputGainSR.Value / 10.0f,
                LFE = tbAudioInputGainLFE.Value / 10.0f
            };

            VideoCapture1.Audio_Enhancer_InputGains(gains);
        }

        private void tbAudioInputGainL_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainL.Text = (tbAudioInputGainL.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainC_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainC.Text = (tbAudioInputGainC.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainR_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainR.Text = (tbAudioInputGainR.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainSL_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainSL.Text = (tbAudioInputGainSL.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainSR_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainSR.Text = (tbAudioInputGainSR.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainLFE_Scroll(object sender, EventArgs e)
        {
            lbAudioInputGainLFE.Text = (tbAudioInputGainLFE.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void ApplyAudioOutputGains()
        {
            VFAudioEnhancerGains gains = new VFAudioEnhancerGains
            {
                L = tbAudioOutputGainL.Value / 10.0f,
                C = tbAudioOutputGainC.Value / 10.0f,
                R = tbAudioOutputGainR.Value / 10.0f,
                SL = tbAudioOutputGainSL.Value / 10.0f,
                SR = tbAudioOutputGainSR.Value / 10.0f,
                LFE = tbAudioOutputGainLFE.Value / 10.0f
            };

            VideoCapture1.Audio_Enhancer_OutputGains(gains);
        }

        private void tbAudioOutputGainL_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainL.Text = (tbAudioOutputGainL.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainC_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainC.Text = (tbAudioOutputGainC.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainR_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainR.Text = (tbAudioOutputGainR.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainSL_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainSL.Text = (tbAudioOutputGainSL.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainSR_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainSR.Text = (tbAudioOutputGainSR.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainLFE_Scroll(object sender, EventArgs e)
        {
            lbAudioOutputGainLFE.Text = (tbAudioOutputGainLFE.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioTimeshift_Scroll(object sender, EventArgs e)
        {
            lbAudioTimeshift.Text = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms";

            VideoCapture1.Audio_Enhancer_Timeshift(tbAudioTimeshift.Value);
        }

        private delegate void FFMPEGInfoDelegate(string message);

        private void FFMPEGInfoDelegateMethod(string message)
        {
            mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine;
        }

        private void VideoCapture1_OnFFMPEGInfo(object sender, FFMPEGInfoEventArgs e)
        {
            BeginInvoke(new FFMPEGInfoDelegate(FFMPEGInfoDelegateMethod), e.Message);
        }

        private void imgTagCover_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                imgTagCover.LoadAsync(openFileDialog2.FileName);
                imgTagCover.Tag = openFileDialog2.FileName;
            }
        }

        private void cbDecklinkCaptureDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDecklinkCaptureVideoFormat.Items.Clear();

            var deviceItem = VideoCapture1.Decklink_CaptureDevices.First(device => device.Name == cbDecklinkCaptureDevice.Text);
            if (deviceItem != null)
            {
                foreach (var format in deviceItem.VideoFormats)
                {
                    cbDecklinkCaptureVideoFormat.Items.Add(format.Name);
                }

                if (cbDecklinkCaptureVideoFormat.Items.Count == 0)
                {
                    cbDecklinkCaptureVideoFormat.Items.Add("No input connected");
                }

                cbDecklinkCaptureVideoFormat.SelectedIndex = 0;
            }
        }

        private void btAudioChannelMapperAddNewRoute_Click(object sender, EventArgs e)
        {
            var item = new AudioChannelMapperItem
            {
                SourceChannel = Convert.ToInt32(edAudioChannelMapperSourceChannel.Text),
                TargetChannel = Convert.ToInt32(edAudioChannelMapperTargetChannel.Text),
                TargetChannelVolume = tbAudioChannelMapperVolume.Value / 1000.0f
            };

            audioChannelMapperItems.Add(item);

            lbAudioChannelMapperRoutes.Items.Add(
                "Source: " + edAudioChannelMapperSourceChannel.Text + ", target: "
                + edAudioChannelMapperTargetChannel.Text + ", volume: "
                + (tbAudioChannelMapperVolume.Value / 1000.0f).ToString("F2"));
        }

        private void btAudioChannelMapperClear_Click(object sender, EventArgs e)
        {
            audioChannelMapperItems.Clear();
            lbAudioChannelMapperRoutes.Items.Clear();
        }

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube);
            Process.Start(startInfo);
        }

        private void tbGPULightness_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectBrightness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBrightness(true, tbGPULightness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectBrightness;
                if (intf != null)
                {
                    intf.Value = tbGPULightness.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUSaturation_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectSaturation intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectSaturation(true, tbGPUSaturation.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectSaturation;
                if (intf != null)
                {
                    intf.Value = tbGPUSaturation.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUContrast_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectContrast intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectContrast(true, tbGPUContrast.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as VFGPUVideoEffectContrast;
                if (intf != null)
                {
                    intf.Value = tbGPUContrast.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUDarkness_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectDarkness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDarkness(true, tbGPUDarkness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDarkness;
                if (intf != null)
                {
                    intf.Value = tbGPUDarkness.Value;
                    intf.Update();
                }
            }
        }

        private void cbGPUGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectGrayscale intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectGrayscale(cbGPUGreyscale.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectGrayscale;
                if (intf != null)
                {
                    intf.Enabled = cbGPUGreyscale.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectInvert intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectInvert(cbGPUInvert.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectInvert;
                if (intf != null)
                {
                    intf.Enabled = cbGPUInvert.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUNightVision_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectNightVision intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectNightVision(cbGPUNightVision.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectNightVision;
                if (intf != null)
                {
                    intf.Enabled = cbGPUNightVision.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUPixelate_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectPixelate intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectPixelate(cbGPUPixelate.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectPixelate;
                if (intf != null)
                {
                    intf.Enabled = cbGPUPixelate.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUDenoise_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectDenoise intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDenoise(cbGPUDenoise.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDenoise;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDenoise.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUDeinterlace_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectDeinterlaceBlend intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDeinterlaceBlend;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDeinterlace.Checked;
                    intf.Update();
                }
            }
        }

        private void cbGPUOldMovie_CheckedChanged(object sender, EventArgs e)
        {
            IVFGPUVideoEffectOldMovie intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectOldMovie(cbGPUOldMovie.Checked);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectOldMovie;
                if (intf != null)
                {
                    intf.Enabled = cbGPUOldMovie.Checked;
                    intf.Update();
                }
            }
        }

        private void btShowIPCamDatabase_Click(object sender, EventArgs e)
        {
            IPCameraDB.ShowWindow();
        }

        private async void btONVIFConnect_Click(object sender, EventArgs e)
        {
            if (btONVIFConnect.Text == "Connect")
            {
                var connected = false;

                try
                {
                    btONVIFConnect.Enabled = false;
                    btONVIFConnect.Text = "Connecting";

                    if (onvifControl != null)
                    {
                        onvifControl.Disconnect();
                        onvifControl.Dispose();
                        onvifControl = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show("Please specify IP camera user name and password.");
                        return;
                    }

                    onvifControl = new ONVIFControl();
                    var result = await onvifControl.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifControl = null;
                        MessageBox.Show("Unable to connect to ONVIF camera.");
                        return;
                    }

                    var deviceInfo = await onvifControl.GetDeviceInformationAsync();
                    if (deviceInfo != null)
                    {
                        lbONVIFCameraInfo.Text = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}";
                    }

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifControl.GetProfilesAsync();
                    foreach (var profile in profiles)
                    {
                        cbONVIFProfile.Items.Add($"{profile.Name}");
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;
                    }

                    edONVIFLiveVideoURL.Text = cbIPURL.Text = await onvifControl.GetVideoURLAsync();

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    onvifPtzRanges = await onvifControl.PTZ_GetRangesAsync();
                    await onvifControl.PTZ_SetAbsoluteAsync(0, 0, 0);

                    onvifPtzX = 0;
                    onvifPtzY = 0;
                    onvifPtzZoom = 0;

                    btONVIFConnect.Text = "Disconnect";
                }
                finally
                {
                    btONVIFConnect.Enabled = true;

                    if (!connected)
                    {
                        btONVIFConnect.Text = "Connect";
                    }
                }
            }
            else
            {
                btONVIFConnect.Text = "Connect";

                if (onvifControl != null)
                {
                    onvifControl.Disconnect();
                    onvifControl.Dispose();
                    onvifControl = null;
                }
            }
        }

        private void btONVIFRight_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX - step;

            if (onvifPtzX < onvifPtzRanges.MinX)
            {
                onvifPtzX = onvifPtzRanges.MinX;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFPTZSetDefault_Click(object sender, EventArgs e)
        {
            onvifControl?.PTZ_SetAbsolute(0, 0, 0);
        }

        private void btONVIFLeft_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX + step;

            if (onvifPtzX > onvifPtzRanges.MaxX)
            {
                onvifPtzX = onvifPtzRanges.MaxX;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFUp_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY - step;

            if (onvifPtzY < onvifPtzRanges.MinY)
            {
                onvifPtzY = onvifPtzRanges.MinY;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFDown_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY + step;

            if (onvifPtzY > onvifPtzRanges.MaxY)
            {
                onvifPtzY = onvifPtzRanges.MaxY;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFZoomIn_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom + step;

            if (onvifPtzZoom > onvifPtzRanges.MaxZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MaxZoom;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFZoomOut_Click(object sender, EventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom - step;

            if (onvifPtzZoom < onvifPtzRanges.MinZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MinZoom;
            }

            onvifControl?.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void tbPIPChromaKeyTolerance1_Scroll(object sender, EventArgs e)
        {
            lbPIPChromaKeyTolerance1.Text = tbPIPChromaKeyTolerance1.Value.ToString();
        }

        private void tbPIPChromaKeyTolerance2_Scroll(object sender, EventArgs e)
        {
            lbPIPChromaKeyTolerance2.Text = tbPIPChromaKeyTolerance2.Value.ToString();
        }

        private void pnPIPChromaKeyColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnPIPChromaKeyColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnPIPChromaKeyColor.BackColor = colorDialog1.Color;
            }
        }

        private void btSelectHLSOutputFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                edHLSOutputFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void lbHLSConfigure_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.HLSStreaming);
            Process.Start(startInfo);
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
                        if (pcmSettingsDialog == null)
                        {
                            pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1.Audio_Codecs.ToArray());
                        }

                        pcmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 5:
                    {
                        if (mp3SettingsDialog == null)
                        {
                            mp3SettingsDialog = new MP3SettingsDialog();
                        }

                        mp3SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 6:
                    {
                        if (m4aSettingsDialog == null)
                        {
                            m4aSettingsDialog = new M4ASettingsDialog();
                        }

                        m4aSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 7:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
                        }

                        wmvSettingsDialog.WMA = true;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }

                case 8:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }

                        flacSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }

                        oggVorbisSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 10:
                    {
                        if (speexSettingsDialog == null)
                        {
                            speexSettingsDialog = new SpeexSettingsDialog();
                        }

                        speexSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 11:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray());
                        }

                        customFormatSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 12:
                case 13:
                case 14:
                case 15:
                    {
                        MessageBox.Show("No settings available for selected output format.");

                        break;
                    }
                case 16:
                case 17:
                case 18:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1.Video_Codecs.ToArray(), VideoCapture1.Audio_Codecs.ToArray(), VideoCapture1.DirectShow_Filters.ToArray());
                        }

                        customFormatSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 19:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 20:
                    {
                        if (ffmpegDLLSettingsDialog == null)
                        {
                            ffmpegDLLSettingsDialog = new FFMPEGDLLSettingsDialog();
                        }

                        ffmpegDLLSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 21:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        ffmpegEXESettingsDialog.ShowDialog(this);

                        break;
                    }
                case 22:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 23:
                    {
                        if (mp4v11SettingsDialog == null)
                        {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                        }

                        mp4v11SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 24:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 25:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 26:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 27:
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wav");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp3");
                        break;
                    }
                case 6:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".m4a");
                        break;
                    }
                case 7:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wma");
                        break;
                    }
                case 8:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 10:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 11:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 12:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 13:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 14:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mpg");
                        break;
                    }
                case 15:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mkv");
                        break;
                    }
                case 16:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 17:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 18:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 19:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 20:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 21:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 22:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 23:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 24:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 25:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
                case 26:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 27:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            uint dpiX;
            uint dpiY;
            Screen.PrimaryScreen.GetDpi(DpiType.Effective, out dpiX, out dpiY);

            VideoCapture1.Width = Width - VideoCapture1.Left - (int)(30 * dpiX / 96);
            VideoCapture1.Height = Height - VideoCapture1.Top - (int)(110 * dpiY / 96);
        }

        private void btTextLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VFVideoEffectTextLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbTextLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btTextLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        private void btTextLogoEdit_Click(object sender, EventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                var dlg = new TextLogoSettingsDialog();
                var effect = VideoCapture1.Video_Effects_Get((string)lbTextLogos.SelectedItem);
                dlg.Attach(effect);

                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        private void btImageLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VFVideoEffectImageLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbImageLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btImageLogoEdit_Click(object sender, EventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                var dlg = new ImageLogoSettingsDialog();
                var effect = VideoCapture1.Video_Effects_Get((string)lbImageLogos.SelectedItem);

                dlg.Attach(effect);
                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        private void btImageLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.Checked;
                }
            }
        }

        private void cbFlipY_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.Checked);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.Checked;
                }
            }
        }

        private async void btCCZoomApply_Click(object sender, EventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCZoomManual.Checked)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCZoomAuto.Checked)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCZoomRelative.Checked)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Zoom, new VideoCaptureDeviceCameraControlValue(tbCCZoom.Value, flags));
        }

        private async void btCCFocusApply_Click(object sender, EventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCFocusManual.Checked)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCFocusAuto.Checked)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCFocusRelative.Checked)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Focus, new VideoCaptureDeviceCameraControlValue(tbCCFocus.Value, flags));
        }

        private void btVLCAddParameter_Click(object sender, EventArgs e)
        {
            lbVLCParameters.Items.Add(edVLCParameter.Text);
            edVLCParameter.Text = string.Empty;
        }

        private void btVLCClearParameters_Click(object sender, EventArgs e)
        {
            lbVLCParameters.Items.Clear();
        }

        private void btOSDClearLayer_Click(object sender, EventArgs e)
        {
            if (lbOSDLayers.SelectedIndex != -1)
            {
                VideoCapture1.OSD_Layers_Clear(lbOSDLayers.SelectedIndex);
            }
            else
            {
                MessageBox.Show(this, "Please select OSD layer.");
            }
        }

        private void btOSDRenderLayers_Click(object sender, EventArgs e)
        {
            VideoCapture1.OSD_Layers_Render();
        }

        private void lbOSDLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            VideoCapture1.OSD_Layers_Enable(e.Index, e.NewValue == CheckState.Checked);
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

        private void tbGPUBlur_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectBlur intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBlur(tbGPUBlur.Value > 0, tbGPUBlur.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectBlur;
                if (intf != null)
                {
                    intf.Enabled = tbGPUBlur.Value > 0;
                    intf.Value = tbGPUBlur.Value;
                    intf.Update();
                }
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

        private void pnChromaKeyColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnChromaKeyColor.BackColor = colorDialog1.Color;
                ConfigureChromaKey();
            }
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI);
            Process.Start(startInfo);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI);
            Process.Start(startInfo);
        }

        private void lbNDI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        private void btListNDISources_Click(object sender, EventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = VideoCapture1.IP_Camera_NDI_ListSources();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private async void btListONVIFSources_Click(object sender, EventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await VideoCapture1.IP_Camera_ONVIF_ListSourcesAsync(null, null);
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private void btVirtualCameraRegister_Click(object sender, EventArgs e)
        {
            btVirtualCameraRegister.Enabled = !VideoCapture1.CustomRedist_VirtualCameraRegister();
        }

        private void llXiphX86_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86);
            Process.Start(startInfo);
        }

        private void llXiphX64_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64);
            Process.Start(startInfo);
        }
    }
}

// ReSharper restore InconsistentNaming