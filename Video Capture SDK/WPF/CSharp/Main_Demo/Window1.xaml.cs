// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1601
// ReSharper disable CommentTypo
// ReSharper disable InlineOutVariableDeclaration

namespace Main_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.Dialogs.VideoEffects;
    using VisioForge.Controls.UI.WPF;
    using VisioForge.Shared.IPCameraDB;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.FFMPEGEXE;
    using VisioForge.Types.GPUVideoEffects;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;
    using VisioForge.Types.VideoEffects;

    using Application = System.Windows.Application;
    using Color = System.Windows.Media.Color;
    using HorizontalAlignment = System.Windows.HorizontalAlignment;
    using MessageBox = System.Windows.MessageBox;
    using VFM4AOutput = VisioForge.Types.OutputFormat.VFM4AOutput;

    // ReSharper disable InconsistentNaming

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class Window1
    {
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        private HWEncodersOutputSettingsDialog movSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private PCMSettingsDialog pcmSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGSettingsDialog ffmpegSettingsDialog;

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

        private readonly List<AudioChannelMapperItem> audioChannelMapperItems = new List<AudioChannelMapperItem>();

        // Zoom
        private double zoom = 1.0;
        private int zoomShiftX;
        private int zoomShiftY;

        // Dialogs
        private readonly FontDialog fontDialog = new FontDialog();
        private readonly Microsoft.Win32.SaveFileDialog outputFileSaveDialog = new Microsoft.Win32.SaveFileDialog();

        private readonly Microsoft.Win32.SaveFileDialog screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        };

        private readonly System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
        private readonly ColorDialog colorDialog1 = new ColorDialog();
        private readonly FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        private WindowCaptureForm windowCaptureForm;

        private static System.Drawing.Color ColorConv(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private static Color ColorConv(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public Window1()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void AddAudioEffects()
        {
            VideoCapture1.Audio_Effects_Clear(-1);

            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Amplify, cbAudAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Equalizer, cbAudEqualizerEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.DynamicAmplify, cbAudDynamicAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.Sound3D, cbAudSound3DEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, VFAudioEffectType.TrueBass, cbAudTrueBassEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
        }

        private void Form1_Load(object sender, RoutedEventArgs e)
        {
            Title += " (SDK v" + VideoCapture1.SDK_Version + ", " + VideoCapture1.SDK_State + ")";

            tmRecording.Elapsed += (senderx, args) =>
            {
                UpdateRecordingTime();
            };

            // font for text logo
            fontDialog.Color = System.Drawing.Color.White;
            fontDialog.Font = new Font(System.Drawing.FontFamily.GenericSansSerif, 32);

            // set combobox indexes
            cbOutputFormat.SelectedIndex = 22;
            cbResizeMode.SelectedIndex = 0;
            cbMotDetHLColor.SelectedIndex = 1;
            cbIPCameraType.SelectedIndex = 2;
            cbRotate.SelectedIndex = 0;
            cbBarcodeType.SelectedIndex = 0;
            cbNetworkStreamingMode.SelectedIndex = 0;
            cbDirect2DRotate.SelectedIndex = 0;

            cbCustomAudioSourceCategory.SelectedIndex = 0;
            cbCustomVideoSourceCategory.SelectedIndex = 0;

            cbCustomAudioSourceCategory_SelectionChanged(null, null);
            cbCustomVideoSourceCategory_SelectionChanged(null, null);

            cbFaceTrackingColorMode.SelectedIndex = 0;
            cbFaceTrackingScalingMode.SelectedIndex = 0;
            cbFaceTrackingSearchMode.SelectedIndex = 1;

            rbMotionDetectionExProcessor.SelectedIndex = 1;
            rbMotionDetectionExDetector.SelectedIndex = 1;

            pnChromaKeyColor.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 218, 128));

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

            cbPIPMode.SelectedIndex = 0;

            foreach (var screen in Screen.AllScreens)
            {
                cbScreenCaptureDisplayIndex.Items.Add(screen.DeviceName.Replace(@"\\.\DISPLAY", string.Empty));
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            edNewFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output_new.mp4");

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
                var deviceItem =
                    VideoCapture1.Audio_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbAudioInputDevice.Text);
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
                    }
                }
            }

            cbAudioInputFormat_SelectedIndexChanged(null, null);
            cbVideoInputFormat_SelectedIndexChanged(null, null);

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
            }

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

            List<string> names;
            List<string> descs;
            VideoCapture1.WMV_V8_Profiles(out names, out descs);

            // ReSharper disable once CoVariantArrayConversion
            foreach (var item in VideoCapture1.Audio_Effects_Equalizer_Presets())
            {
                cbAudEqualizerPreset.Items.Add(item);
            }

            cbAudEqualizerPreset.SelectedIndex = 0;

            // Decklink
            foreach (var device in VideoCapture1.Decklink_CaptureDevices)
            {
                cbDecklinkCaptureDevice.Items.Add(device.Name);
            }

            if (cbDecklinkCaptureDevice.Items.Count > 0)
            {
                cbDecklinkCaptureDevice.SelectedIndex = 0;
                cbDecklinkCaptureDevice_SelectionChanged(null, null);
            }

            btVirtualCameraRegister.IsEnabled = !VideoCapture1.DirectShow_Filters.Contains("VisioForge Virtual Camera");
        }

        private void cbVideoInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.Video_CaptureDevice = e.AddedItems[0].ToString();

                cbVideoInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
                if (deviceItem != null)
                {
                    foreach (var format in deviceItem.VideoFormats)
                    {
                        cbVideoInputFormat.Items.Add(format);
                    }

                    if (cbVideoInputFormat.Items.Count > 0)
                    {
                        cbVideoInputFormat.SelectedIndex = 0;
                        cbVideoInputFormat_SelectedIndexChanged(null, null);
                    }

                    //cbFramerate.Items.Clear();

                    //foreach (string frameRate in deviceItem.VideoFrameRates)
                    //{
                    //    cbFramerate.Items.Add(frameRate);
                    //}

                    //if (cbFramerate.Items.Count > 0)
                    //{
                    //    cbFramerate.SelectedIndex = 0;
                    //}

                    // currently device active, we can read TV Tuner name
                    var tvTuner = deviceItem.TVTuner;
                    if (tvTuner != null)
                    {
                        int k = cbTVTuner.Items.IndexOf(tvTuner);
                        if (k >= 0)
                        {
                            cbTVTuner.SelectedIndex = k;
                        }
                    }

                    cbCrossBarAvailable.IsEnabled =
                        VideoCapture1.Video_CaptureDevice_CrossBar_Init(e.AddedItems[0].ToString());
                    cbCrossBarAvailable.IsChecked = cbCrossBarAvailable.IsEnabled;

                    if (cbCrossBarAvailable.IsEnabled)
                    {
                        cbCrossbarInput.IsEnabled = true;
                        cbCrossbarOutput.IsEnabled = true;
                        rbCrossbarSimple.IsEnabled = true;
                        rbCrossbarAdvanced.IsEnabled = true;
                        cbCrossbarVideoInput.IsEnabled = true;
                        btConnect.IsEnabled = true;
                        cbConnectRelated.IsEnabled = true;
                        lbRotes.IsEnabled = true;

                        VideoCapture1.Video_CaptureDevice_CrossBar_ClearConnections();

                        cbCrossbarVideoInput.Items.Clear();
                        foreach (
                            string s in VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput("Video Decoder"))
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
                        for (int i = 0; i < cbCrossbarOutput.Items.Count; i++)
                        {
                            string input =
                                VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(
                                    cbCrossbarOutput.Text);

                            if (input != string.Empty)
                            {
                                lbRotes.Items.Add("Input: " + input + ", Output: " + cbCrossbarOutput.Items[i]);
                            }
                        }
                    }
                    else
                    {
                        cbCrossbarInput.IsEnabled = false;
                        cbCrossbarOutput.IsEnabled = false;
                        rbCrossbarSimple.IsEnabled = false;
                        rbCrossbarAdvanced.IsEnabled = false;
                        cbCrossbarVideoInput.IsEnabled = false;
                        btConnect.IsEnabled = false;
                        cbConnectRelated.IsEnabled = false;
                        lbRotes.IsEnabled = false;
                    }

                    // updating adjust settings
                    int max;
                    int defaultValue;
                    int min;
                    bool auto;
                    int step;
                    if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(
                        VFVideoHardwareAdjustment.Brightness,
                        out min,
                        out max,
                        out step,
                        out defaultValue,
                        out auto))
                    {
                        tbAdjBrightness.Minimum = min;
                        tbAdjBrightness.Maximum = max;
                        tbAdjBrightness.SmallChange = step;
                        tbAdjBrightness.Value = defaultValue;
                        cbAdjBrightnessAuto.IsChecked = auto;
                        lbAdjBrightnessMin.Content = "Min: " + Convert.ToString(min);
                        lbAdjBrightnessMax.Content = "Max: " + Convert.ToString(max);
                        lbAdjBrightnessCurrent.Content = "Current: " + Convert.ToString(defaultValue);
                    }

                    if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(
                        VFVideoHardwareAdjustment.Hue,
                        out min,
                        out max,
                        out step,
                        out defaultValue,
                        out auto))
                    {
                        tbAdjHue.Minimum = min;
                        tbAdjHue.Maximum = max;
                        tbAdjHue.SmallChange = step;
                        tbAdjHue.Value = defaultValue;
                        cbAdjHueAuto.IsChecked = auto;
                        lbAdjHueMin.Content = "Min: " + Convert.ToString(min);
                        lbAdjHueMax.Content = "Max: " + Convert.ToString(max);
                        lbAdjHueCurrent.Content = "Current: " + Convert.ToString(defaultValue);
                    }

                    if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(
                        VFVideoHardwareAdjustment.Saturation,
                        out min,
                        out max,
                        out step,
                        out defaultValue,
                        out auto))
                    {
                        tbAdjSaturation.Minimum = min;
                        tbAdjSaturation.Maximum = max;
                        tbAdjSaturation.SmallChange = step;
                        tbAdjSaturation.Value = defaultValue;
                        cbAdjSaturationAuto.IsChecked = auto;
                        lbAdjSaturationMin.Content = "Min: " + Convert.ToString(min);
                        lbAdjSaturationMax.Content = "Max: " + Convert.ToString(max);
                        lbAdjSaturationCurrent.Content = "Current: " + Convert.ToString(defaultValue);
                    }

                    if (VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRanges(
                        VFVideoHardwareAdjustment.Contrast,
                        out min,
                        out max,
                        out step,
                        out defaultValue,
                        out auto))
                    {
                        tbAdjContrast.Minimum = min;
                        tbAdjContrast.Maximum = max;
                        tbAdjContrast.SmallChange = step;
                        tbAdjContrast.Value = defaultValue;
                        cbAdjContrastAuto.IsChecked = auto;
                        lbAdjContrastMin.Content = "Min: " + Convert.ToString(min);
                        lbAdjContrastMax.Content = "Max: " + Convert.ToString(max);
                        lbAdjContrastCurrent.Content = "Current: " + Convert.ToString(defaultValue);
                    }

                    cbUseAudioInputFromVideoCaptureDevice.IsEnabled = deviceItem.AudioOutput;
                    btVideoCaptureDeviceSettings.IsEnabled = deviceItem.DialogDefault;
                }
            }
        }

        private void cbAudioInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            // ReSharper disable once MergeSequentialChecks
            if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat.Items.Clear();
                cbAudioInputLine.Items.Clear();

                if (cbUseAudioInputFromVideoCaptureDevice.IsChecked == true)
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

                        cbAudioInputFormat_SelectedIndexChanged(null, null);
                    }
                }
                else if (cbAudioInputDevice.SelectedIndex != -1)
                {
                    VideoCapture1.Audio_CaptureDevice = e.AddedItems[0].ToString();

                    var deviceItem = VideoCapture1.Audio_CaptureDevicesInfo.FirstOrDefault(device => device.Name == VideoCapture1.Audio_CaptureDevice);
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

                        btAudioInputDeviceSettings.IsEnabled = deviceItem.DialogDefault;
                    }
                }
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (outputFileSaveDialog.ShowDialog() == true)
            {
                edOutput.Text = outputFileSaveDialog.FileName;
            }
        }

        private void SelectScreenCaptureSource(out ScreenCaptureSourceSettings settings)
        {
            settings = new ScreenCaptureSourceSettings();
            if (rbScreenCaptureWindow.IsChecked == true)
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
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Incorrect window title for screen capture.");
                    return;
                }

                if (settings.WindowHandle == IntPtr.Zero)
                {
                    System.Windows.Forms.MessageBox.Show("Incorrect window title for screen capture.");
                    return;
                }
            }
            else
            {
                settings.Mode = VFScreenCaptureMode.Screen;
            }

            settings.FrameRate = (float)Convert.ToDouble(edScreenFrameRate.Text);
            settings.FullScreen = rbScreenFullScreen.IsChecked == true;
            settings.Top = Convert.ToInt32(edScreenTop.Text);
            settings.Bottom = Convert.ToInt32(edScreenBottom.Text);
            settings.Left = Convert.ToInt32(edScreenLeft.Text);
            settings.Right = Convert.ToInt32(edScreenRight.Text);
            settings.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.IsChecked
                                                                  == true;
            settings.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);
            settings.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.IsChecked == true;
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
                    settings.Type = VFIPSource.HTTP_MJPEG_LowLatency;
                    cbIPAudioCapture.IsChecked = false;
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

            settings.AudioCapture = cbIPAudioCapture.IsChecked == true;
            settings.Login = edIPLogin.Text;
            settings.Password = edIPPassword.Text;
            settings.ForcedFramerate = Convert.ToDouble(edIPForcedFramerate.Text);
            settings.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];
            settings.Debug_Enabled = cbDebugMode.IsChecked == true;
            settings.Debug_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "ip_cam_log.txt");
            settings.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.IsChecked == true;
            settings.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);

            if (settings.Type == VFIPSource.Auto_LAV)
            {
                settings.LAV_GPU_Use = lavGPU;
                settings.LAV_GPU_Mode = VFMediaPlayerSourceGPUDecoder.DXVA2CopyBack;
            }

            if (cbIPCameraONVIF.IsChecked == true)
            {
                settings.ONVIF_Source = true;

                if (cbONVIFProfile.SelectedIndex != -1)
                {
                    settings.ONVIF_SourceProfile = cbONVIFProfile.Text;
                }
            }

            if (cbIPDisconnect.IsChecked == true)
            {
                settings.DisconnectEventInterval = TimeSpan.FromSeconds(10);
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

        private void SetFFMPEGOutput(ref VFFFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        private void SetFLACOutput(ref VFFLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
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

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            if (onvifControl != null)
            {
                onvifControl.Disconnect();
                onvifControl.Dispose();
                onvifControl = null;

                btONVIFConnect.Content = "Connect";
            }

            zoom = 1.0;
            zoomShiftX = 0;
            zoomShiftY = 0;

            mmLog.Clear();

            if (cbPIPDevices.Items.Count > 0)
            {
                if (cbPIPDevices.Items.IndexOf("Main source") == -1)
                {
                    cbPIPDevices.Items.Insert(0, "Main source");
                }
            }

            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoCapture1.VLC_Path = Environment.GetEnvironmentVariable("VFVLCPATH");

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Video_Effects_Clear();
            lbImageLogos.Items.Clear();
            lbTextLogos.Items.Clear();

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

            VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = rbAddAudioStreamsMix.IsChecked == true;

            // Network streaming
            VideoCapture1.Network_Streaming_Enabled = cbNetworkStreaming.IsChecked == true;

            if (VideoCapture1.Network_Streaming_Enabled)
            {
                switch (cbNetworkStreamingMode.SelectedIndex)
                {
                    case 0:
                        {
                            VideoCapture1.Network_Streaming_Format = VFNetworkStreamingFormat.WMV;

                            if (rbNetworkStreamingUseMainWMVSettings.IsChecked == true)
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

                            if (rbNetworkUDPFFMPEG.IsChecked == true)
                            {
                                ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                            }
                            else
                            {
                                SetFFMPEGEXEOutput(ref ffmpegOutput);
                            }

                            ffmpegOutput.OutputMuxer = OutputMuxer.FLV;
                            ffmpegOutput.UsePipe = cbNetworkRTMPFFMPEGUsePipes.IsChecked == true;

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

                            if (rbNetworkUDPFFMPEG.IsChecked == true)
                            {
                                ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                            }
                            else
                            {
                                SetFFMPEGEXEOutput(ref ffmpegOutput);
                            }

                            ffmpegOutput.OutputMuxer = OutputMuxer.MPEGTS;
                            ffmpegOutput.UsePipe = cbNetworkUDPFFMPEGUsePipes.IsChecked == true;
                            VideoCapture1.Network_Streaming_Output = ffmpegOutput;

                            VideoCapture1.Network_Streaming_URL = edNetworkUDPURL.Text;

                            break;
                        }

                    case 5:
                        {
                            if (rbNetworkSSSoftware.IsChecked == true)
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

                                if (rbNetworkSSFFMPEGDefault.IsChecked == true)
                                {
                                    ffmpegOutput.FillDefaults(DefaultsProfile.MP4_H264_AAC, true);
                                }
                                else
                                {
                                    SetFFMPEGEXEOutput(ref ffmpegOutput);
                                }

                                ffmpegOutput.OutputMuxer = OutputMuxer.ISMV;
                                ffmpegOutput.UsePipe = cbNetworkSSUsePipes.IsChecked == true;
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
                                    Custom_HTTP_Server_Enabled = cbHLSEmbeddedHTTPServerEnabled.IsChecked == true,
                                    Custom_HTTP_Server_Port = Convert.ToInt32(edHLSEmbeddedHTTPServerPort.Text)
                                }
                            };
                            VideoCapture1.Network_Streaming_Output = hls;

                            if (cbHLSEmbeddedHTTPServerEnabled.IsChecked == true)
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

                VideoCapture1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.IsChecked == true;
            }

            if (VideoCapture1.Mode == VFVideoCaptureMode.ScreenPreview
                || VideoCapture1.Mode == VFVideoCaptureMode.ScreenCapture)
            {
                // from screen
                ScreenCaptureSourceSettings settings;
                SelectScreenCaptureSource(out settings);
                VideoCapture1.Screen_Capture_Source = settings;
            }
            else if (VideoCapture1.Mode == VFVideoCaptureMode.IPPreview
                     || VideoCapture1.Mode == VFVideoCaptureMode.IPCapture)
            {
                IPCameraSourceSettings settings;
                SelectIPCameraSource(out settings);
                VideoCapture1.IP_Camera_Source = settings;
            }
            else if (VideoCapture1.Mode == VFVideoCaptureMode.BDAPreview
                     || VideoCapture1.Mode == VFVideoCaptureMode.BDACapture)
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
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.CustomCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.CustomPreview))
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
            else if ((VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourceCapture) || (VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourcePreview))
            {
                VideoCapture1.Decklink_Source = new DecklinkSourceSettings
                {
                    Name = cbDecklinkCaptureDevice.Text,
                    VideoFormat = cbDecklinkCaptureVideoFormat.Text
                };
            }
            else
            {
                VideoCapture1.Video_CaptureDevice = cbVideoInputDevice.Text;
                VideoCapture1.Video_CaptureFormat = cbVideoInputFormat.Text;
                VideoCapture1.Video_CaptureFormat_UseBest = cbUseBestVideoInputFormat.IsChecked == true;

                try
                {
                    if (!string.IsNullOrEmpty(cbVideoInputFrameRate.Text))
                    {
                        VideoCapture1.Video_FrameRate = Convert.ToDouble(cbVideoInputFrameRate.Text);
                    }
                }
                catch
                {
                    VideoCapture1.Video_FrameRate = 25;
                }

                VideoCapture1.Video_CaptureDevice_IsAudioSource =
                    cbUseAudioInputFromVideoCaptureDevice.IsChecked == true;
                VideoCapture1.Video_CaptureDevice_UseClosedCaptions = cbUseClosedCaptions.IsChecked == true;
            }

            bool captureMode = this.VideoCapture1.Mode == VFVideoCaptureMode.AudioCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.BDACapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.CustomCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.IPCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.KinectCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.ScreenCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.DecklinkSourceCapture
                               || this.VideoCapture1.Mode == VFVideoCaptureMode.VideoCapture;

            if (captureMode)
            {
                VideoCapture1.Output_Filename = edOutput.Text;
            }

            VideoCapture1.Audio_RecordAudio = cbRecordAudio.IsChecked == true;
            VideoCapture1.Audio_PlayAudio = cbPlayAudio.IsChecked == true;

            if (captureMode)
            {
                VFVideoCaptureOutputFormat outputFormat = VFVideoCaptureOutputFormat.AVI;
                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.AVI;

                            var aviOutput = new VFAVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoCapture1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.MKVv1;

                            var mkvOutput = new VFMKVv1Output();
                            SetMKVOutput(ref mkvOutput);
                            VideoCapture1.Output_Format = mkvOutput;

                            break;
                        }
                    case 2:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.WMV;

                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Output_Format = wmvOutput;

                            break;
                        }

                    case 3:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DV;

                            var dvOutput = new VFDVOutput();
                            SetDVOutput(ref dvOutput);
                            VideoCapture1.Output_Format = dvOutput;

                            break;
                        }
                    case 4:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.PCM_ACM;

                            var acmOutput = new VFACMOutput();
                            SetACMOutput(ref acmOutput);
                            VideoCapture1.Output_Format = acmOutput;

                            break;
                        }
                    case 5:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.MP3;

                            var mp3Output = new VFMP3Output();
                            SetMP3Output(ref mp3Output);
                            VideoCapture1.Output_Format = mp3Output;

                            break;
                        }
                    case 6:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.M4A;

                            var m4aOutput = new VFM4AOutput();
                            SetM4AOutput(ref m4aOutput);
                            VideoCapture1.Output_Format = m4aOutput;

                            break;
                        }
                    case 7:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.WMA;

                            var wmaOutput = new VFWMAOutput();
                            SetWMAOutput(ref wmaOutput);
                            VideoCapture1.Output_Format = wmaOutput;

                            break;
                        }

                    case 8:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.FLAC;

                            var flacOutput = new VFFLACOutput();
                            SetFLACOutput(ref flacOutput);
                            VideoCapture1.Output_Format = flacOutput;

                            break;
                        }
                    case 9:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.OggVorbis;

                            var oggVorbisOutput = new VFOGGVorbisOutput();
                            SetOGGOutput(ref oggVorbisOutput);
                            VideoCapture1.Output_Format = oggVorbisOutput;

                            break;
                        }
                    case 10:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.Speex;

                            var speexOutput = new VFSpeexOutput();
                            SetSpeexOutput(ref speexOutput);
                            VideoCapture1.Output_Format = speexOutput;

                            break;
                        }
                    case 11:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.Custom;

                            var customOutput = new VFCustomOutput();
                            SetCustomOutput(ref customOutput);
                            VideoCapture1.Output_Format = customOutput;

                            break;
                        }
                    case 12:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureDV;
                            VideoCapture1.Output_Format = new VFDirectCaptureDVOutput();

                            break;
                        }
                    case 13:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureAVI;
                            VideoCapture1.Output_Format = new VFDirectCaptureAVIOutput();

                            break;
                        }
                    case 14:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureMPEG;
                            VideoCapture1.Output_Format = new VFDirectCaptureMPEGOutput();

                            break;
                        }
                    case 15:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureMKV;
                            VideoCapture1.Output_Format = new VFDirectCaptureMKVOutput();

                            break;
                        }
                    case 16:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureMP4_GDCL;

                            var directCaptureOutputGDCL = new VFDirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputGDCL);
                            directCaptureOutputGDCL.Muxer = VFDirectCaptureMP4Muxer.GDCL;
                            VideoCapture1.Output_Format = directCaptureOutputGDCL;

                            break;
                        }
                    case 17:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureMP4_Monogram;

                            var directCaptureOutputMG = new VFDirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputMG);
                            directCaptureOutputMG.Muxer = VFDirectCaptureMP4Muxer.Monogram;
                            VideoCapture1.Output_Format = directCaptureOutputMG;

                            break;
                        }
                    case 18:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.DirectCaptureCustom;

                            var directCaptureOutput = new VFDirectCaptureCustomOutput();
                            SetDirectCaptureCustomOutput(ref directCaptureOutput);
                            VideoCapture1.Output_Format = directCaptureOutput;

                            break;
                        }
                    case 19:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.WebM;

                            var webmOutput = new VFWebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoCapture1.Output_Format = webmOutput;

                            break;
                        }
                    case 20:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.FFMPEG;

                            var ffmpegOutput = new VFFFMPEGOutput();
                            SetFFMPEGOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 21:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.FFMPEG_EXE;

                            var ffmpegOutput = new VFFFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 22:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.MP4;
                            break;
                        }
                    case 23:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.MP4_HW;

                            var mp4Output = new VFMP4HWOutput();
                            SetMP4HWOutput(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 24:
                        {
                            outputFormat = VFVideoCaptureOutputFormat.AnimatedGIF;
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);
                            VideoCapture1.Output_Format = gifOutput;
                            break;
                        }
                    case 25:
                        outputFormat = VFVideoCaptureOutputFormat.Encrypted;
                        break;
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

                if (outputFormat == VFVideoCaptureOutputFormat.DirectCaptureMPEG)
                {
                    if (cbMPEGEncoder.SelectedIndex != -1)
                    {
                        VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = cbMPEGEncoder.Text;
                    }
                }
                else if ((outputFormat == VFVideoCaptureOutputFormat.MP4)
                         || ((outputFormat == VFVideoCaptureOutputFormat.Encrypted)
                             && (rbEncryptedH264SW.IsChecked == true))
                         || (VideoCapture1.Network_Streaming_Enabled
                             && (VideoCapture1.Network_Streaming_Format == VFNetworkStreamingFormat.RTSP_H264_AAC_SW)))
                {
                    var mp4Output = new VFMP4Output();
                    SetMP4Output(ref mp4Output);

                    if (outputFormat == VFVideoCaptureOutputFormat.Encrypted)
                    {
                        mp4Output.Encryption = true;
                        mp4Output.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                        if (rbEncryptionKeyString.IsChecked == true)
                        {
                            mp4Output.Encryption_KeyType = VFEncryptionKeyType.String;
                            mp4Output.Encryption_Key = edEncryptionKeyString.Text;
                        }
                        else if (rbEncryptionKeyFile.IsChecked == true)
                        {
                            mp4Output.Encryption_KeyType = VFEncryptionKeyType.File;
                            mp4Output.Encryption_Key = edEncryptionKeyFile.Text;
                        }
                        else
                        {
                            mp4Output.Encryption_KeyType = VFEncryptionKeyType.Binary;
                            mp4Output.Encryption_Key =
                                VideoCapture.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
                        }

                        if (rbEncryptionModeAES128.IsChecked == true)
                        {
                            mp4Output.Encryption_Mode = VFEncryptionMode.v8_AES128;
                        }
                        else
                        {
                            mp4Output.Encryption_Mode = VFEncryptionMode.v9_AES256;
                        }
                    }

                    VideoCapture1.Output_Format = mp4Output;
                }
            }

            // VU meter Pro
            if (cbVUMeterProEnabled.IsChecked == true)
            {
                VideoCapture1.Audio_VUMeter_Pro_Enabled = true;

                VideoCapture1.Audio_VUMeter_Pro_Volume = (int)tbVUMeterAmplification.Value;

                volumeMeter1.Boost = (float)tbVUMeterBoost.Value / 10.0F;
                volumeMeter2.Boost = (float)tbVUMeterBoost.Value / 10.0F;

                waveformPainter.Start();
                spectrumAnalyzer.Start();
                volumeMeter1.Start();
                volumeMeter2.Start();
            }
            else
            {
                VideoCapture1.Audio_VUMeter_Pro_Enabled = false;
            }

            // crossbar
            if (cbCrossBarAvailable.IsChecked == true)
            {
                // ReSharper disable RedundantIfElseBlock
                if (rbCrossbarSimple.IsChecked == true)
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

            // Virtual camera output
            VideoCapture1.Virtual_Camera_Output_Enabled = cbVirtualCamera.IsChecked == true;

            // Decklink output
            if (cbDecklinkOutput.IsChecked == true)
            {
                VideoCapture1.Decklink_Output = new DecklinkOutputSettings
                {
                    DVEncoding = cbDecklinkDV.IsChecked == true,
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
                                                            cbDecklinkOutputDownConversionAnalogOutput.IsChecked
                                                            == true,
                    AnalogOutput =
                                                            (DecklinkAnalogOutput)cbDecklinkOutputAnalog.SelectedIndex
                };
            }
            else
            {
                VideoCapture1.Decklink_Output = null;
            }

            VideoCapture1.Decklink_Input = (DecklinkInput)cbDecklinkSourceInput.SelectedIndex;
            VideoCapture1.Decklink_Input_SMPTE = cbDecklinkSourceComponentLevels.SelectedIndex == 0;
            VideoCapture1.Decklink_Input_IREUSA = cbDecklinkSourceNTSC.SelectedIndex == 0;
            VideoCapture1.Decklink_Input_Capture_Timecode_Source = (DecklinkCaptureTimecodeSource)cbDecklinkSourceTimecode.SelectedIndex;

            // Barcode detection
            VideoCapture1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.IsChecked == true;
            VideoCapture1.Barcode_Reader_Type = (VFBarcodeType)cbBarcodeType.SelectedIndex;

            // Video effects CPU
            ConfigureVideoEffects();

            // Video effects GPU
            VideoCapture1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.IsChecked == true;

            // Chromakey
            ConfigureChromaKey();

            // Object detection 
            ConfigureMotionDetectionEx();

            // Face tracking
            if (cbFaceTrackingEnabled.IsChecked == true)
            {
                VideoCapture1.Face_Tracking = new FaceTrackingSettings
                {
                    ColorMode = (CamshiftMode)cbFaceTrackingColorMode.SelectedIndex,
                    Highlight = cbFaceTrackingCHL.IsChecked == true,
                    MinimumWindowSize = int.Parse(edFaceTrackingMinimumWindowSize.Text),
                    ScalingMode = (ObjectDetectorScalingMode)cbFaceTrackingScalingMode.SelectedIndex,
                    SearchMode = (ObjectDetectorSearchMode)cbFaceTrackingSearchMode.SelectedIndex
                };

                // VideoCapture1.FaceTracking_ScaleFactor = int.Parse(edFaceTrackingScaleFactor.Text);
            }
            else
            {
                VideoCapture1.Face_Tracking = null;
            }

            VideoCapture1.Audio_CaptureDevice_Format_UseBest = cbUseBestAudioInputFormat.IsChecked == true;
            VideoCapture1.Video_CaptureFormat_UseBest = cbUseBestVideoInputFormat.IsChecked == true;

            VideoCapture1.Video_CaptureFormat = cbVideoInputFormat.Text;

            if (rbWPF.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRendererWPF.WPF;
            }
            else if (rbDirect2D.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRendererWPF.Direct2D;
            }
            else
            {
                VideoCapture1.Video_Renderer.Video_Renderer = VFVideoRendererWPF.None;
            }

            if (cbStretch.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            VideoCapture1.Video_Renderer.BackgroundColor = VideoCapture.ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);
            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            VideoCapture1.Background = pnVideoRendererBGColor.Fill;

            VideoCapture1.Video_ResizeOrCrop_Enabled = false;

            if (cbResize.IsChecked == true)
            {
                VideoCapture1.Video_ResizeOrCrop_Enabled = true;

                VideoCapture1.Video_Resize = new VideoResizeSettings
                {
                    Width = Convert.ToInt32(edResizeWidth.Text),
                    Height = Convert.ToInt32(edResizeHeight.Text),
                    LetterBox = cbResizeLetterbox.IsChecked == true
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

            if (cbCrop.IsChecked == true)
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

            // DV resolution
            if (rbDVResFull.IsChecked == true)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Full;
            }
            else if (rbDVResHalf.IsChecked == true)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Half;
            }
            else if (rbDVResQuarter.IsChecked == true)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.Quarter;
            }
            else
            {
                VideoCapture1.DV_Decoder_Video_Resolution = VFDVVideoResolution.DC;
            }

            // motion detection
            ConfigureMotionDetection();

            // Audio enhancement
            VideoCapture1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.IsChecked == true;
            if (VideoCapture1.Audio_Enhancer_Enabled)
            {
                VideoCapture1.Audio_Enhancer_Normalize(cbAudioNormalize.IsChecked == true);
                VideoCapture1.Audio_Enhancer_AutoGain(cbAudioAutoGain.IsChecked == true);

                ApplyAudioInputGains();
                ApplyAudioOutputGains();

                VideoCapture1.Audio_Enhancer_Timeshift((int)tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.IsChecked == true)
            {
                VideoCapture1.Audio_Channel_Mapper = new AudioChannelMapperSettings
                {
                    Routes = audioChannelMapperItems.ToArray(),
                    OutputChannelsCount =
                                                                 Convert.ToInt32(
                                                                     edAudioChannelMapperOutputChannels.Text)
                };
            }
            else
            {
                VideoCapture1.Audio_Channel_Mapper = null;
            }

            // Audio processing
            VideoCapture1.Audio_Effects_Enabled = cbAudioEffectsEnabled.IsChecked == true;
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
                    Color = VideoCapture.ColorConv(((SolidColorBrush)pnPIPChromaKeyColor.Fill).Color),
                    Tolerance1 = (int)tbPIPChromaKeyTolerance1.Value,
                    Tolerance2 = (int)tbPIPChromaKeyTolerance2.Value
                };

                VideoCapture1.PIP_ChromaKeySettings = chromaKey;
            }

            // separate capture
            VideoCapture1.SeparateCapture_Enabled = cbSeparateCaptureEnabled.IsChecked == true;
            if (VideoCapture1.SeparateCapture_Enabled)
            {
                if (rbSeparateCaptureStartManually.IsChecked == true)
                {
                    VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.Normal;
                    VideoCapture1.SeparateCapture_AutostartCapture = false;
                }
                else if (rbSeparateCaptureSplitByDuration.IsChecked == true)
                {
                    VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.SplitByDuration;
                    VideoCapture1.SeparateCapture_AutostartCapture = true;
                    VideoCapture1.SeparateCapture_TimeThreshold = TimeSpan.FromMilliseconds(Convert.ToInt32(edSeparateCaptureDuration.Text));
                }
                else if (rbSeparateCaptureSplitBySize.IsChecked == true)
                {
                    VideoCapture1.SeparateCapture_Mode = VFSeparateCaptureMode.SplitByFileSize;
                    VideoCapture1.SeparateCapture_AutostartCapture = true;
                    VideoCapture1.SeparateCapture_FileSizeThreshold = Convert.ToInt32(edSeparateCaptureFileSize.Text) * 1024 * 1024;
                }
            }

            // Output tags
            if (cbTagEnabled.IsChecked == true)
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

                if (imgTagCover.Tag != null)
                {
                    tags.Pictures = new[] { new Bitmap(imgTagCover.Tag.ToString()) };
                }

                VideoCapture1.Tags = tags;
            }

            // Start
            await VideoCapture1.StartAsync();

            edNetworkURL.Text = VideoCapture1.Network_Streaming_URL;

            tmRecording.Start();
        }

        private void ConfigureMotionDetectionEx()
        {
            if (cbMotionDetectionEx.IsChecked == true)
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

        private void ConfigureChromaKey()
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (VideoCapture1.ChromaKey != null)
            {
                VideoCapture1.ChromaKey.Dispose();
                VideoCapture1.ChromaKey = null;
            }

            if (cbChromaKeyEnabled.IsChecked == true)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show("Chroma-key background file doesn't exists.");
                    return;
                }

                VideoCapture1.ChromaKey = new ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
                {
                    Smoothing = (float)(tbChromaKeySmoothing.Value / 1000f),
                    ThresholdSensitivity = (float)(tbChromaKeyThresholdSensitivity.Value / 1000f),
                    Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color)
                };
            }
            else
            {
                VideoCapture1.ChromaKey = null;
            }
        }

        private void ConfigureVideoEffects()
        {
            VideoCapture1.Video_Effects_Enabled = cbEffects.IsChecked == true;
            VideoCapture1.Video_Effects_MergeImageLogos = cbMergeImageLogos.IsChecked == true;
            VideoCapture1.Video_Effects_MergeTextLogos = cbMergeTextLogos.IsChecked == true;
            VideoCapture1.Video_Effects_Clear();

            // Deinterlace
            if (cbDeinterlace.IsChecked == true && VideoCapture1.Mode != VFVideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VFVideoCaptureMode.ScreenPreview)
            {
                if (rbDeintBlendEnabled.IsChecked == true)
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
                else if (rbDeintCAVTEnabled.IsChecked == true)
                {
                    IVFVideoEffectDeinterlaceCAVT cavt;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VFVideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.IsChecked == true, Convert.ToInt32(edDeintCAVTThreshold.Text));
                        VideoCapture1.Video_Effects_Add(cavt);
                    }
                    else
                    {
                        cavt = effect as IVFVideoEffectDeinterlaceCAVT;
                    }

                    if (cavt == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Unable to configure deinterlace CAVT effect.");
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

            // Denoise
            if (cbDenoise.IsChecked == true && VideoCapture1.Mode != VFVideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VFVideoCaptureMode.ScreenPreview)
            {
                if (rbDenoiseCAST.IsChecked == true)
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

            if (cbGreyscale.IsChecked == true)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbInvert.IsChecked == true)
            {
                cbInvert_CheckedChanged(null, null);
            }

            if (cbZoomEnabled.IsChecked == true)
            {
                cbZoomEnabled_Checked(null, null);
            }

            if (cbPan.IsChecked == true)
            {
                cbPan_Checked(null, null);
            }

            if (cbFadeInOut.IsChecked == true)
            {
                cbFadeInOut_Checked(null, null);
            }

            if (cbFlipX.IsChecked == true)
            {
                CbFlipX_Checked(null, null);
            }

            if (cbFlipY.IsChecked == true)
            {
                CbFlipY_Checked(null, null);
            }

            if (cbLiveRotation.IsChecked == true)
            {
                cbLiveRotation_Checked(null, null);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Filters_Clear();
            await VideoCapture1.StopAsync();

            // if ((bool)cbUseAdditionalScreens.IsChecked)
            // {
            // pnScreen1.Refresh();
            // pnScreen2.Refresh();
            // pnScreen3.Refresh();
            // }

            waveformPainter.Stop();
            waveformPainter.Clear();

            spectrumAnalyzer.Stop();
            spectrumAnalyzer.Clear();

            volumeMeter1.Stop();
            volumeMeter1.Clear();

            volumeMeter2.Stop();
            volumeMeter2.Clear();

            cbPIPDevices.Items.Clear();

            lbFilters.Items.Clear();
            
            tmRecording.Stop();
        }

        private void cbAudioInputFormat_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_CaptureDevice_Format = e.AddedItems[0].ToString();
        }

        private void cbAudioInputLine_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_CaptureDevice_Line = e.AddedItems[0].ToString();
        }

        private void cbAudioOutputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_OutputDevice = e.AddedItems[0].ToString();
        }

        private void cbCrossbarInput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCrossbarInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                string relatedInput;
                string relatedOutput;
                VideoCapture1.Video_CaptureDevice_CrossBar_GetRelated(e.AddedItems[0].ToString(), cbCrossbarOutput.Text, out relatedInput, out relatedOutput);
            }
        }

        private void cbCrossbarOutput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            cbCrossbarInput.Items.Clear();

            if (cbCrossbarOutput.SelectedIndex != -1)
            {
                foreach (string s in VideoCapture1.Video_CaptureDevice_CrossBar_GetInputsForOutput(e.AddedItems[0].ToString()))
                {
                    cbCrossbarInput.Items.Add(s);
                }
            }

            string input = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(e.AddedItems[0].ToString());

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

        private void cbTVTuner_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbTVTuner.Items.Count > 0) && (cbTVTuner.SelectedIndex != -1) && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_Name = e.AddedItems[0].ToString();
                VideoCapture1.TVTuner_Read();

                cbTVMode.Items.Clear();
                foreach (string tunerMode in VideoCapture1.TVTuner_Modes())
                {
                    cbTVMode.Items.Add(tunerMode);
                }

                edVideoFreq.Text = Convert.ToString(VideoCapture1.TVTuner_VideoFrequency);
                edAudioFreq.Text = Convert.ToString(VideoCapture1.TVTuner_AudioFrequency);
                cbTVInput.SelectedIndex = cbTVInput.Items.IndexOf(VideoCapture1.TVTuner_InputType);
                cbTVMode.SelectedIndex = cbTVMode.Items.IndexOf(VideoCapture1.TVTuner_Mode.ToString());
                cbTVSystem.SelectedIndex = cbTVSystem.Items.IndexOf(VideoCapture1.TVTuner_TVFormat);
                cbTVCountry.SelectedIndex = cbTVCountry.Items.IndexOf(VideoCapture1.TVTuner_Country);
            }
        }

        private void cbVideoInputFormat_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbVideoInputDevice.SelectedValue.ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
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

        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVFVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.IsChecked == true;
                }
            }
        }

        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
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

        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.IsChecked == true);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVFVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.IsChecked == true;
                }
            }
        }

        private async void tbAdjContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Contrast, new VideoCaptureDeviceAdjustValue((int)tbAdjContrast.Value, cbAdjContrastAuto.IsChecked == true));

            if (lbAdjContrastCurrent != null)
            {
                lbAdjContrastCurrent.Content = "Current: " + Convert.ToString((int)tbAdjContrast.Value);
            }
        }

        private async void tbAdjHue_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Hue, new VideoCaptureDeviceAdjustValue((int)tbAdjHue.Value, cbAdjHueAuto.IsChecked == true));

            if (lbAdjHueCurrent != null)
            {
                lbAdjHueCurrent.Content = "Current: " + Convert.ToString((int)tbAdjHue.Value);
            }
        }

        private async void tbAdjSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VFVideoHardwareAdjustment.Saturation, new VideoCaptureDeviceAdjustValue((int)tbAdjSaturation.Value, cbAdjSaturationAuto.IsChecked == true));

            if (lbAdjSaturationCurrent != null)
            {
                lbAdjSaturationCurrent.Content = "Current: " + Convert.ToString((int)tbAdjSaturation.Value);
            }
        }

        private void cbUseAudioInputFromVideoCaptureDevice_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(cbVideoInputDevice.Text))
            {
                VideoCapture1.Video_CaptureDevice_IsAudioSource = cbUseAudioInputFromVideoCaptureDevice.IsChecked == true;
                cbAudioInputDevice_SelectedIndexChanged(null, null);

                cbAudioInputDevice.IsEnabled = cbUseAudioInputFromVideoCaptureDevice.IsChecked != true;
                btAudioInputDeviceSettings.IsEnabled = cbUseAudioInputFromVideoCaptureDevice.IsChecked != true;
            }
        }

        private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.Text);
        }

        private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.Text);
        }

        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            if ((cbCrossbarInput.SelectedIndex != -1) && (cbCrossbarOutput.SelectedIndex != -1))
            {
                VideoCapture1.Video_CaptureDevice_CrossBar_Connect(cbCrossbarInput.Text, cbCrossbarOutput.Text, cbConnectRelated.IsChecked == true);

                lbRotes.Items.Clear();
                for (int i = 0; i < cbCrossbarOutput.Items.Count; i++)
                {
                    string input = VideoCapture1.Video_CaptureDevice_CrossBar_GetConnectedInputForOutput(cbCrossbarOutput.Items[i].ToString());
                    lbRotes.Items.Add("Input: " + input + ", Output: " + cbCrossbarOutput.Items[i]);
                }
            }
        }

        private async void btDVFF_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.FastForward);
        }

        private async void btDVPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Pause);
        }

        private async void btDVRewind_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Rew);
        }

        private async void btDVPlay_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Play);
        }

        private async void btDVStepFWD_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepFw);
        }

        private async void btDVStepRev_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.StepRev);
        }

        private async void btDVStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(VFDVCommand.Stop);
        }

        private void btRefreshClients_Click(object sender, RoutedEventArgs e)
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

        private void btStartTune_Click(object sender, RoutedEventArgs e)
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

        private void btStopTune_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.TVTuner_TuneChannels_Stop();
        }

        private void btUseThisChannel_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(edChannel.Text) <= 10000)
            {
                // channel
                VideoCapture1.TVTuner_Channel = Convert.ToInt32(edChannel.Text);
            }
            else
            {
                VideoCapture1.TVTuner_Channel = -1;

                // must be -1 to use frequency
                VideoCapture1.TVTuner_Frequency = Convert.ToInt32(edChannel.Text);
            }

            if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
            {
                return;
            }

            VideoCapture1.TVTuner_Apply();
            VideoCapture1.TVTuner_Read();
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
        }

        private void cbTVCountry_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVCountry.SelectedIndex != -1)
            {
                VideoCapture1.TVTuner_Country = cbTVCountry.Text;
                edTVDefaultFormat.Text = VideoCapture1.TVTuner_Countries_GetPreferredFormatForCountry(VideoCapture1.TVTuner_Country);

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                if (VideoCapture1.Status == VFVideoCaptureStatus.Work)
                {
                    VideoCapture1.TVTuner_Apply();
                    VideoCapture1.TVTuner_Read();
                }
            }
        }

        private void cbTVMode_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVMode.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VFTVTunerMode mode;
                Enum.TryParse(e.AddedItems[0].ToString(), true, out mode);
                VideoCapture1.TVTuner_Mode = mode;

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                cbTVChannel.Items.Clear();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVChannel_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVChannel.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                int k = Convert.ToInt32(e.AddedItems[0].ToString());

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

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVInput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_InputType = e.AddedItems[0].ToString();

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbTVSystem_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVSystem.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_TVFormat = VideoCapture1.TVTuner_TVFormat_FromString(e.AddedItems[0].ToString());

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                VideoCapture1.TVTuner_Apply();
                VideoCapture1.TVTuner_Read();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency.ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAudioInputFormat.IsEnabled = cbUseBestAudioInputFormat.IsChecked != true;
        }

        private void cbUseBestVideoInputFormat_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbVideoInputFormat.IsEnabled = cbUseBestVideoInputFormat.IsChecked != true;
        }

        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_OutputDevice_Volume_Set((int)tbAudioVolume.Value);
        }

        private void tbAudioBalance_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set((int)tbAudioBalance.Value);
            VideoCapture1.Audio_OutputDevice_Balance_Get();
        }

        private void btSelectWMVProfileNetwork_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private void btMPEGEncoderShowDialog_Click(object sender, RoutedEventArgs e)
        {
            if (cbMPEGEncoder.SelectedIndex != -1)
            {
                VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = cbMPEGEncoder.Text;
            }

            VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_ShowDialog(IntPtr.Zero);
        }

        private void cbFilters_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                string name = e.AddedItems[0].ToString();
                btFilterSettings.IsEnabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                    VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btFilterAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                VideoCapture1.Video_Filters_Add(new VFCustomProcessingFilter(cbFilters.Text));
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

        private void btFilterSettings_Click(object sender, RoutedEventArgs e)
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

        private void btFilterSettings2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.SelectedValue.ToString();

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

        private void btFilterDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            lbFilters.Items.Clear();
            VideoCapture1.Video_Filters_Clear();
        }

        private void cbPIPDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPIPDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.Video_CaptureDevice = e.AddedItems[0].ToString();

                cbPIPFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
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

                    //cbPIPFrameRate.Items.Clear();
                    //foreach (string frameRate in deviceItem.VideoFrameRates)
                    //{
                    //    cbPIPFrameRate.Items.Add(frameRate);
                    //}

                    //if (cbPIPFrameRate.Items.Count > 0)
                    //{
                    //    cbPIPFrameRate.SelectedIndex = 0;
                    //}

                    cbPIPInput.Items.Clear();

                    VideoCapture1.PIP_Sources_Device_GetCrossbar(e.AddedItems[0].ToString());
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

        private void cbMPEGVideoDecoder_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMPEGVideoDecoder.SelectedIndex < 1 || e == null || e.AddedItems.Count > 0)
            {
                btMPEGVidDecSetting.IsEnabled = false;
            }
            else
            {
                string name = e.AddedItems[0].ToString();
                btMPEGVidDecSetting.IsEnabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                  VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void cbMPEGAudioDecoder_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMPEGAudioDecoder.SelectedIndex < 1 || e == null || e.AddedItems.Count > 0)
            {
                btMPEGAudDecSettings.IsEnabled = false;
            }
            else
            {
                string name = e.AddedItems[0].ToString();
                btMPEGAudDecSettings.IsEnabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                  VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btMPEGVidDecSetting_Click(object sender, RoutedEventArgs e)
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

        private void btMPEGAudDecSettings_Click(object sender, RoutedEventArgs e)
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

        private async void btScreenCaptureUpdate_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.Screen_Capture_UpdateParametersAsync(
                Convert.ToInt32(edScreenLeft.Text),
                Convert.ToInt32(edScreenTop.Text),
                cbScreenCapture_GrabMouseCursor.IsChecked == true);
        }

        private void cbPIPFormatUseBest_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbPIPFormat.IsEnabled = cbPIPFormatUseBest.IsChecked != true;
        }

        private async void btPIPUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                await VideoCapture1.PIP_Sources_SetSourcePositionAsync(
                    cbPIPDevices.SelectedIndex,
                    new Rectangle(
                        Convert.ToInt32(edPIPLeft.Text),
                        Convert.ToInt32(edPIPTop.Text),
                        Convert.ToInt32(edPIPWidth.Text),
                        Convert.ToInt32(edPIPHeight.Text)));
            }
            else
            {
                MessageBox.Show("Select device!");
            }
        }

        private void btPIPAddDevice_Click(object sender, RoutedEventArgs e)
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
                    cbPIPFormatUseBest.IsChecked == true,
                    Convert.ToDouble(frameRate),
                    input,
                    Convert.ToInt32(edPIPVidCapLeft.Text),
                    Convert.ToInt32(edPIPVidCapTop.Text),
                    Convert.ToInt32(edPIPVidCapWidth.Text),
                    Convert.ToInt32(edPIPVidCapHeight.Text));

                cbPIPDevices.Items.Add(cbPIPDevice.Text);
            }
        }

        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.IsChecked == true)
            {
                VideoCapture1.Motion_Detection = new MotionDetectionSettings
                {
                    Enabled = cbMotDetEnabled.IsChecked == true,
                    Compare_Red = cbCompareRed.IsChecked == true,
                    Compare_Green = cbCompareGreen.IsChecked == true,
                    Compare_Blue = cbCompareBlue.IsChecked == true,
                    Compare_Greyscale = cbCompareGreyscale.IsChecked == true,
                    Highlight_Color = (VFMotionCHLColor)cbMotDetHLColor.SelectedIndex,
                    Highlight_Enabled = cbMotDetHLEnabled.IsChecked == true,
                    Highlight_Threshold = (int)tbMotDetHLThreshold.Value,
                    FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text),
                    Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text),
                    Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text),
                    DropFrames_Enabled = cbMotDetDropFramesEnabled.IsChecked == true,
                    DropFrames_Threshold = (int)tbMotDetDropFramesThreshold.Value
                };
                VideoCapture1.MotionDetection_Update();
            }
            else
            {
                VideoCapture1.Motion_Detection = null;
            }
        }

        private void btMotDetUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetection();
        }

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
            Dispatcher?.BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        private void btAudEqRefresh_Click(object sender, RoutedEventArgs e)
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

        private async void btSignal_Click(object sender, RoutedEventArgs e)
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

        private void cbAudAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 0, cbAudAmplifyEnabled.IsChecked == true);
        }

        private void cbAudDynamicAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 2, cbAudDynamicAmplifyEnabled.IsChecked == true);
        }

        private void cbAudEqualizerEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 1, cbAudEqualizerEnabled.IsChecked == true);
        }

        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, 1, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        private void cbAudSound3DEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 3, cbAudSound3DEnabled.IsChecked == true);
        }

        private void cbAudTrueBassEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, 4, cbAudTrueBassEnabled.IsChecked == true);
        }

        private async void tbAdjBrightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(
                VFVideoHardwareAdjustment.Brightness,
                new VideoCaptureDeviceAdjustValue(
                    (int)tbAdjBrightness.Value,
                    cbAdjBrightnessAuto.IsChecked == true));

            if (lbAdjBrightnessCurrent != null)
            {
                lbAdjBrightnessCurrent.Content = "Current: " + Convert.ToString((int)tbAdjBrightness.Value);
            }
        }

        private void tbAud3DSound_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_Sound3D(-1, 3, (ushort)tbAud3DSound.Value);
        }

        private void tbAudDynAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, 2, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void tbAudAttack_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, 2, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void tbAudEq0_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 0, (sbyte)tbAudEq0.Value);
        }

        private void tbAudEq1_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 1, (sbyte)tbAudEq1.Value);
        }

        private void tbAudEq2_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 2, (sbyte)tbAudEq2.Value);
        }

        private void tbAudEq3_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 3, (sbyte)tbAudEq3.Value);
        }

        private void tbAudEq4_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 4, (sbyte)tbAudEq4.Value);
        }

        private void tbAudEq5_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 5, (sbyte)tbAudEq5.Value);
        }

        private void tbAudEq6_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 6, (sbyte)tbAudEq6.Value);
        }

        private void tbAudEq7_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 7, (sbyte)tbAudEq7.Value);
        }

        private void tbAudEq8_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 8, (sbyte)tbAudEq8.Value);
        }

        private void tbAudEq9_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, 1, 9, (sbyte)tbAudEq9.Value);
        }

        private void tbAudTrueBass_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_TrueBass(-1, 4, 200, false, (ushort)tbAudTrueBass.Value);
        }

        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, (int)tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVFVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = (int)tbContrast.Value;
                }
            }
        }

        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, (int)tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVFVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = (int)tbDarkness.Value;
                }
            }
        }

        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, (int)tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVFVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = (int)tbLightness.Value;
                }
            }
        }

        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                IVFVideoEffectSaturation saturation;
                var effect = VideoCapture1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VFVideoEffectSaturation((int)tbSaturation.Value);
                    VideoCapture1.Video_Effects_Add(saturation);
                }
                else
                {
                    saturation = effect as IVFVideoEffectSaturation;
                    if (saturation != null)
                    {
                        saturation.Value = (int)tbSaturation.Value;
                    }
                }
            }
        }

        // private void VideoCapture1_OnDVDeviceEvent(object sender, IVFVideoCapture4XEvents_OnDVDeviceEventEvent e)
        // {
        //    switch (e.eventCode)
        //    {
        //        case (int)VFDVCommand.DV_PLAY: VideoCapture1.Resume(); break;
        //        case (int)VFDVCommand.DV_PAUSE: VideoCapture1.Pause(); break;
        //        case (int)VFDVCommand.DV_STOP: VideoCapture1.Stop(); break;
        //        // other events codes - DV_x
        //    }
        // }

        // private void VideoCapture1_OnVUMeterImageS1I(object sender, IVFVideoCapture4XEvents_OnVUMeterImageS1IEvent e)
        // {
        //    Bitmap bmp = Bitmap.FromHbitmap((IntPtr)e.frame);
        //    pbVUMeter1.Image = bmp;
        // }

        // private void VideoCapture1_OnVUMeterImageS2I(object sender, IVFVideoCapture4XEvents_OnVUMeterImageS2IEvent e)
        // {
        //    Bitmap bmp = Bitmap.FromHbitmap((IntPtr)e.frame);
        //    pbVUMeter2.Image = bmp;
        // }

        // private void VideoCapture1_OnVUMeterValues(object sender, IVFVideoCapture4XEvents_OnVUMeterValuesEvent e)
        // {
        //    edVUMeterValues.Text = e.values;
        // }

        private void tbAudAmplifyAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_Amplify(-1, 0, (int)tbAudAmplifyAmp.Value * 10, false);
        }

        private void tbAudRelease_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, 2, (ushort)tbAudAttack.Value, (ushort)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void linkLabel1_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private static void DoEvents()
        {
            Application.Current.Dispatcher?.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }

        private void VideoCapture1_OnTVTunerTuneChannels(object sender, TVTunerTuneChannelsEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
            {
                DoEvents();

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

                DoEvents();
            }));
        }

        private void lbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.SelectedValue.ToString();
                btFilterSettings2.IsEnabled = VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.Default) ||
                                            VideoCapture.DirectShow_Filter_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private async void cbStretch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbStretch.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private void cbMPEGEncoder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMPEGEncoder.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_Name = e.AddedItems[0].ToString();
            }
        }

        private delegate void AFMotionDelegate(float level);

        private void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        private void VideoCapture1_OnObjectDetection(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        private void cbAFMotionDetection_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetectionEx();
        }

        private async void btSeparateCaptureStart_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text);
        }

        private async void btSeparateCaptureStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_StopAsync();
        }

        private async void btSeparateCaptureChangeFilename_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text);
        }

        private void btPIPAddIPCamera_Click(object sender, RoutedEventArgs e)
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

        private void btPIPAddScreenCapture_Click(object sender, RoutedEventArgs e)
        {
            ScreenCaptureSourceSettings screenSource;
            SelectScreenCaptureSource(out screenSource);

            VideoCapture1.PIP_Sources_Add_ScreenSource(
                screenSource,
                Convert.ToInt32(edPIPScreenCapLeft.Text),
                Convert.ToInt32(edPIPScreenCapTop.Text),
                Convert.ToInt32(edPIPScreenCapWidth.Text),
                Convert.ToInt32(edPIPScreenCapHeight.Text));

            cbPIPDevices.Items.Add("Screen Capture");
        }

        private void btPIPDevicesClear_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.PIP_Sources_Clear();
            cbPIPDevices.Items.Clear();
        }

        private void btPIPSetOutputSize_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.PIP_CustomOutputSize_Set(Convert.ToInt32(edPIPOutputWidth.Text), Convert.ToInt32(edPIPOutputHeight.Text));
        }

        private async void btPIPSet_Click(object sender, RoutedEventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                await VideoCapture1.PIP_Sources_SetSourceSettingsAsync(cbPIPDevices.SelectedIndex, (int)tbPIPTransparency.Value, false, false);
            }
            else
            {
                MessageBox.Show("Select device!");
            }
        }

        private async void btSeparateCapturePause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_PauseAsync();
        }

        private async void btSeparateCaptureResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_ResumeAsync();
        }

        private void btDVBTTune_Click(object sender, RoutedEventArgs e)
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

        private void cbZoomEnabled_Checked(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectZoom zoomEffect;
            var effect = VideoCapture1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VFVideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoomEnabled.IsChecked == true);
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
            zoomEffect.Enabled = cbZoomEnabled.IsChecked == true;
        }

        private void btEffZoomIn_Click(object sender, RoutedEventArgs e)
        {
            zoom += 0.1;
            zoom = Math.Min(zoom, 5);

            cbZoomEnabled_Checked(null, null);
        }

        private void btEffZoomOut_Click(object sender, RoutedEventArgs e)
        {
            zoom -= 0.1;
            zoom = Math.Max(zoom, 1);

            cbZoomEnabled_Checked(null, null);
        }

        private void btEffZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY += 20;

            cbZoomEnabled_Checked(null, null);
        }

        private void btEffZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        private void btEffZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX += 20;

            cbZoomEnabled_Checked(null, null);
        }

        private void btEffZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        private void cbPan_Checked(object sender, RoutedEventArgs e)
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

            pan.Enabled = cbPan.IsChecked == true;
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

        private void btBarcodeReset_Click(object sender, RoutedEventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoCapture1.Barcode_Reader_Enabled = true;
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

        private void VideoCapture1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            Dispatcher?.BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        private void btAddAdditionalAudioSource_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Additional_Audio_CaptureDevice_Add(cbAdditionalAudioSource.Text);
            MessageBox.Show(cbAdditionalAudioSource.Text + " added");
        }

        private void btPIPAddFileSource_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.PIP_Sources_Add_VideoFile(
                edPIPFileSoureFilename.Text,
                Convert.ToInt32(edPIPFileLeft.Text),
                Convert.ToInt32(edPIPFileTop.Text),
                Convert.ToInt32(edPIPFileWidth.Text),
                Convert.ToInt32(edPIPFileHeight.Text));
            cbPIPDevices.Items.Add("File source");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edPIPFileSoureFilename.Text = openFileDialog1.FileName;
            }
        }

        private void cbFadeInOut_Checked(object sender, RoutedEventArgs e)
        {
            if (rbFadeIn.IsChecked == true)
            {
                IVFVideoEffectFadeIn fadeIn;
                var effect = VideoCapture1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VFVideoEffectFadeIn(cbFadeInOut.IsChecked == true);
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

                fadeIn.Enabled = cbFadeInOut.IsChecked == true;
                fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
            else
            {
                IVFVideoEffectFadeOut fadeOut;
                var effect = VideoCapture1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VFVideoEffectFadeOut(cbFadeInOut.IsChecked == true);
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

                fadeOut.Enabled = cbFadeInOut.IsChecked == true;
                fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
        }

        private void label1291_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer);
            Process.Start(startInfo);
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder);
            Process.Start(startInfo);
        }

        private void VideoCapture1_OnFaceDetected(object sender, AFFaceDetectionEventArgs e)
        {
            Dispatcher?.BeginInvoke(new FaceDelegate(FaceDelegateMethod), e);
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

        private void label1291_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.IISSmoothStreaming);
            Process.Start(startInfo);
        }

        #region Full screen

        private bool fullScreen;

        private double windowLeft;

        private double windowTop;

        private double windowWidth;

        private double windowHeight;

        private Thickness controlMargin;

        private double controlWidth;

        private double controlHeight;

        private async void btFullScreen_Click(object sender, RoutedEventArgs e)
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

                controlMargin = VideoCapture1.Margin;
                controlWidth = VideoCapture1.Width;
                controlHeight = VideoCapture1.Height;

                // resizing window
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                Topmost = true;

                Left = 0;
                Top = 0;
                Width = Screen.AllScreens[0].Bounds.Width;
                Height = Screen.AllScreens[0].Bounds.Height;
                Margin = new Thickness(0);

                // resizing control
                VideoCapture1.Margin = new Thickness(0, 0, 0, 0);
                VideoCapture1.Width = Screen.AllScreens[0].Bounds.Width;
                VideoCapture1.Height = Screen.AllScreens[0].Bounds.Height;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoCapture1.Margin = controlMargin;
                VideoCapture1.Width = controlWidth;
                VideoCapture1.Height = controlHeight;

                VideoCapture1.Width = controlWidth;
                VideoCapture1.Height = controlHeight;
                //VideoCapture1.RenderSize = new System.Windows.Size(controlWidth, controlHeight);

                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                Topmost = false;
                ResizeMode = ResizeMode.CanResize;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        private void VideoCapture1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        #region VU meter Pro

        private delegate void AudioVUMeterProMaximumCalculatedDelegate(VUMeterMaxSampleEventArgs e);

        private void AudioVUMeterProMaximumCalculatedelegateMethod(VUMeterMaxSampleEventArgs e)
        {
            waveformPainter.AddValue(e.MaxSample, e.MinSample);
        }

        private void VideoCapture1_OnAudioVUMeterProMaximumCalculated(object sender, VUMeterMaxSampleEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProMaximumCalculatedDelegate(AudioVUMeterProMaximumCalculatedelegateMethod), e);
        }

        private delegate void AudioVUMeterProFFTCalculatedDelegate(VUMeterFFTEventArgs e);

        private void AudioVUMeterProFFTCalculatedDelegateMethod(VUMeterFFTEventArgs e)
        {
            spectrumAnalyzer.Update(e.Result);
        }

        private void VideoCapture1_OnAudioVUMeterProFFTCalculated(object sender, VUMeterFFTEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProFFTCalculatedDelegate(AudioVUMeterProFFTCalculatedDelegateMethod), e);
        }

        private delegate void AudioVUMeterProVolumeDelegate(AudioLevelEventArgs e);

        private void AudioVUMeterProVolumeDelegateMethod(AudioLevelEventArgs e)
        {
            volumeMeter1.Amplitude = e.ChannelLevelsDb[0];
            volumeMeter1.Update();

            if (e.ChannelLevelsDb.Length > 1)
            {
                volumeMeter2.Amplitude = e.ChannelLevelsDb[1];
                volumeMeter2.Update();
            }
        }

        private void VideoCapture1_OnAudioVUMeterProVolume(object sender, AudioLevelEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProVolumeDelegate(AudioVUMeterProVolumeDelegateMethod), e);
        }

        private void tbVUMeterAmplification_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.Audio_VUMeter_Pro_Volume = (int)tbVUMeterAmplification.Value;
            }
        }

        private void tbVUMeterBoost_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volumeMeter1.Boost = (float)tbVUMeterBoost.Value / 10.0F;
            volumeMeter2.Boost = (float)tbVUMeterBoost.Value / 10.0F;
        }

        #endregion

        private void cbLiveRotation_Checked(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                IVFVideoEffectRotate rotate;
                var effect = VideoCapture1.Video_Effects_Get("Rotate");
                if (effect == null)
                {
                    rotate = new VFVideoEffectRotate(
                        cbLiveRotation.IsChecked == true,
                        tbLiveRotationAngle.Value,
                        cbLiveRotationStretch.IsChecked == true);
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

                rotate.Enabled = cbLiveRotation.IsChecked == true;
                rotate.Angle = tbLiveRotationAngle.Value;
                rotate.Stretch = cbLiveRotationStretch.IsChecked == true;
            }
        }

        private void tbLiveRotationAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            cbLiveRotation_Checked(sender, e);
        }

        private void cbLiveRotationStretch_Checked(object sender, RoutedEventArgs e)
        {
            cbLiveRotation_Checked(sender, e);
        }

        private async void cbScreenFlipVertical_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void cbScreenFlipHorizontal_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void cbDirect2DRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(name);
                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        private async void btZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private async void pnVideoRendererBGColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnVideoRendererBGColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));

                pnVideoRendererBGColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                VideoCapture1.Background = pnVideoRendererBGColor.Fill;

                VideoCapture1.Video_Renderer.BackgroundColor = colorDialog1.Color;
                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        private void rbVR_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDirect2D != null)
            {
                bool direct2d = rbDirect2D.IsChecked == true;
                cbScreenFlipVertical.IsEnabled = direct2d;
                cbScreenFlipHorizontal.IsEnabled = direct2d;
                cbDirect2DRotate.IsEnabled = direct2d;
                pnZoom.IsEnabled = direct2d;
            }
        }

        private void cbCustomVideoSourceCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCustomVideoSourceFilter == null)
            {
                return;
            }

            if (cbCustomVideoSourceCategory.SelectedIndex == 0)
            {
                var filters = VideoCapture1.Video_CaptureDevicesInfo;
                var list = new List<string>();
                foreach (var info in filters)
                {
                    list.Add(info.Name);
                }

                cbCustomVideoSourceFilter.ItemsSource = list;

                if (filters.Count > 0)
                {
                    cbCustomVideoSourceFilter.SelectedIndex = 0;
                    cbCustomVideoSourceFilter_SelectionChanged(null, null);
                }
            }
            else if (cbCustomVideoSourceCategory.SelectedIndex == 1)
            {
                var filters = VideoCapture1.DirectShow_Filters;
                cbCustomVideoSourceFilter.ItemsSource = filters;

                if (filters.Count > 0)
                {
                    cbCustomVideoSourceFilter.SelectedIndex = 0;
                    cbCustomVideoSourceFilter_SelectionChanged(null, null);
                }
            }
        }

        private void cbCustomAudioSourceCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCustomAudioSourceFilter == null)
            {
                return;
            }

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

        private void cbCustomVideoSourceFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = string.Empty;
            if (cbCustomVideoSourceFilter.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                value = e.AddedItems[0].ToString();
            }

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            List<VideoCaptureDeviceFormat> formats;

            if (cbCustomVideoSourceCategory.SelectedIndex == 0)
            {
                VideoCapture1.DirectShow_Filter_GetVideoFormats(
                    VFFilterCategory.VideoCaptureSource,
                    value,
                    VFMediaCategory.Video,
                    out formats);
            }
            else
            {
                VideoCapture1.DirectShow_Filter_GetVideoFormats(
                    VFFilterCategory.DirectShowFilters,
                    value,
                    VFMediaCategory.Video,
                    out formats);
            }

            cbCustomVideoSourceFormat.ItemsSource = formats;
        }

        private void cbCustomAudioSourceFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value = string.Empty;
            if (cbCustomAudioSourceFilter.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                value = e.AddedItems[0].ToString();
            }

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            cbCustomAudioSourceFormat.Items.Clear();

            List<string> formats;

            if (cbCustomAudioSourceCategory.SelectedIndex == 0)
            {
                VideoCapture1.DirectShow_Filter_GetAudioFormats(
                    VFFilterCategory.AudioCaptureSource,
                    value,
                    VFMediaCategory.Audio,
                    out formats);
            }
            else
            {
                VideoCapture1.DirectShow_Filter_GetAudioFormats(
                    VFFilterCategory.DirectShowFilters,
                    value,
                    VFMediaCategory.Audio,
                    out formats);
            }

            foreach (var format in formats)
            {
                cbCustomAudioSourceFormat.Items.Add(format);
            }
        }

        private void cbAudioNormalize_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Enhancer_Normalize(cbAudioNormalize.IsChecked == true);
        }

        private void cbAudioAutoGain_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Enhancer_AutoGain(cbAudioAutoGain.IsChecked == true);
        }

        private void ApplyAudioInputGains()
        {
            VFAudioEnhancerGains gains = new VFAudioEnhancerGains
            {
                L = (float)tbAudioInputGainL.Value / 10.0f,
                C = (float)tbAudioInputGainC.Value / 10.0f,
                R = (float)tbAudioInputGainR.Value / 10.0f,
                SL = (float)tbAudioInputGainSL.Value / 10.0f,
                SR = (float)tbAudioInputGainSR.Value / 10.0f,
                LFE = (float)tbAudioInputGainLFE.Value / 10.0f
            };

            VideoCapture1.Audio_Enhancer_InputGains(gains);
        }

        private void tbAudioInputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainL.Content = (tbAudioInputGainL.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainC.Content = (tbAudioInputGainC.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainR.Content = (tbAudioInputGainR.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSL.Content = (tbAudioInputGainSL.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSR.Content = (tbAudioInputGainSR.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void tbAudioInputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainLFE.Content = (tbAudioInputGainLFE.Value / 10.0f).ToString("F1");

            ApplyAudioInputGains();
        }

        private void ApplyAudioOutputGains()
        {
            VFAudioEnhancerGains gains = new VFAudioEnhancerGains
            {
                L = (float)tbAudioOutputGainL.Value / 10.0f,
                C = (float)tbAudioOutputGainC.Value / 10.0f,
                R = (float)tbAudioOutputGainR.Value / 10.0f,
                SL = (float)tbAudioOutputGainSL.Value / 10.0f,
                SR = (float)tbAudioOutputGainSR.Value / 10.0f,
                LFE = (float)tbAudioOutputGainLFE.Value / 10.0f
            };

            VideoCapture1.Audio_Enhancer_OutputGains(gains);
        }

        private void tbAudioOutputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainL.Content = (tbAudioOutputGainL.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainC.Content = (tbAudioOutputGainC.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainR.Content = (tbAudioOutputGainR.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSL.Content = (tbAudioOutputGainSL.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSR.Content = (tbAudioOutputGainSR.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioOutputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainLFE.Content = (tbAudioOutputGainLFE.Value / 10.0f).ToString("F1");

            ApplyAudioOutputGains();
        }

        private void tbAudioTimeshift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioTimeshift.Content = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms";

            VideoCapture1.Audio_Enhancer_Timeshift((int)tbAudioTimeshift.Value);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void VideoCapture1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Log("(NOT ERROR) " + e.Message);
        }

        private delegate void FFMPEGInfoDelegate(string message);

        private void FFMPEGInfoDelegateMethod(string message)
        {
            mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine;
        }

        private void VideoCapture1_OnFFMPEGInfo(object sender, FFMPEGInfoEventArgs e)
        {
            Dispatcher?.BeginInvoke(new FFMPEGInfoDelegate(FFMPEGInfoDelegateMethod), e.Message);
        }

        private void btEncryptionOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        private void imgTagCover_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (openFileDialog2.ShowDialog() == true)
            {
                imgTagCover.Source = new BitmapImage(new Uri(openFileDialog2.FileName));
                imgTagCover.Tag = openFileDialog2.FileName;
            }
        }

        private void cbDecklinkCaptureDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string value;
            if (cbDecklinkCaptureDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                value = e.AddedItems[0].ToString();
            }
            else
            {
                return;
            }

            cbDecklinkCaptureVideoFormat.Items.Clear();

            var deviceItem = VideoCapture1.Decklink_CaptureDevices.FirstOrDefault(device => device.Name == value);
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

                // cbVideoInputFormat_SelectedIndexChanged(null, null);
            }
        }

        private void btAudioChannelMapperClear_Click(object sender, RoutedEventArgs e)
        {
            audioChannelMapperItems.Clear();
            lbAudioChannelMapperRoutes.Items.Clear();
        }

        private void btAudioChannelMapperAddNewRoute_Click(object sender, RoutedEventArgs e)
        {
            var item = new AudioChannelMapperItem
            {
                SourceChannel = Convert.ToInt32(edAudioChannelMapperSourceChannel.Text),
                TargetChannel = Convert.ToInt32(edAudioChannelMapperTargetChannel.Text),
                TargetChannelVolume = (float)tbAudioChannelMapperVolume.Value / 1000.0f
            };

            audioChannelMapperItems.Add(item);

            lbAudioChannelMapperRoutes.Items.Add(
                "Source: " + edAudioChannelMapperSourceChannel.Text + ", target: "
                + edAudioChannelMapperTargetChannel.Text + ", volume: "
                + (tbAudioChannelMapperVolume.Value / 1000.0f).ToString("F2"));
        }

        private void lbDownloadFFMPEG_Copy3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube);
            Process.Start(startInfo);
        }

        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher?.BeginInvoke(new NetworkStopDelegate(NetworkStopDelegateMethod));
        }

        private delegate void NetworkStopDelegate();

        private void NetworkStopDelegateMethod()
        {
            VideoCapture1.Stop();

            MessageBox.Show("Network source stopped or disconnected!");
        }

        private void tbGPULightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IVFGPUVideoEffectBrightness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBrightness(true, (int)tbGPULightness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectBrightness;
                if (intf != null)
                {
                    intf.Value = (int)tbGPULightness.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IVFGPUVideoEffectSaturation intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectSaturation(true, (int)tbGPUSaturation.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectSaturation;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUSaturation.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IVFGPUVideoEffectContrast intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectContrast(true, (int)tbGPUContrast.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as VFGPUVideoEffectContrast;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUContrast.Value;
                    intf.Update();
                }
            }
        }

        private void tbGPUDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IVFGPUVideoEffectDarkness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDarkness(true, (int)tbGPUDarkness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDarkness;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUDarkness.Value;
                    intf.Update();
                }
            }
        }

        private void cbGPUGreyscale_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectGrayscale intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectGrayscale(cbGPUGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectGrayscale;
                if (intf != null)
                {
                    intf.Enabled = cbGPUGreyscale.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUInvert_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectInvert intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectInvert(cbGPUInvert.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectInvert;
                if (intf != null)
                {
                    intf.Enabled = cbGPUInvert.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUNightVision_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectNightVision intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectNightVision(cbGPUNightVision.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectNightVision;
                if (intf != null)
                {
                    intf.Enabled = cbGPUNightVision.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUPixelate_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectPixelate intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectPixelate(cbGPUPixelate.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectPixelate;
                if (intf != null)
                {
                    intf.Enabled = cbGPUPixelate.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUDenoise_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectDenoise intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDenoise(cbGPUDenoise.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDenoise;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDenoise.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUDeinterlace_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectDeinterlaceBlend intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectDeinterlaceBlend;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDeinterlace.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void cbGPUOldMovie_Click(object sender, RoutedEventArgs e)
        {
            IVFGPUVideoEffectOldMovie intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectOldMovie(cbGPUOldMovie.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectOldMovie;
                if (intf != null)
                {
                    intf.Enabled = cbGPUOldMovie.IsChecked == true;
                    intf.Update();
                }
            }
        }

        private void btShowIPCamDatabase_Click(object sender, RoutedEventArgs e)
        {
            IPCameraDB.ShowWindow();
        }

        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                var connected = false;

                try
                {
                    btONVIFConnect.IsEnabled = false;
                    btONVIFConnect.Content = "Connecting";

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
                        lbONVIFCameraInfo.Content = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}";
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

                    btONVIFConnect.Content = "Disconnect";
                }
                finally
                {
                    btONVIFConnect.IsEnabled = true;

                    if (!connected)
                    {
                        btONVIFConnect.Content = "Connect";
                    }
                }
            }
            else
            {
                btONVIFConnect.Content = "Connect";

                if (onvifControl != null)
                {
                    onvifControl.Disconnect();
                    onvifControl.Dispose();
                    onvifControl = null;
                }
            }
        }

        private void btONVIFRight_Click(object sender, RoutedEventArgs e)
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

        private void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
            onvifControl?.PTZ_SetAbsolute(0, 0, 0);
        }

        private void btONVIFLeft_Click(object sender, RoutedEventArgs e)
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

        private void btONVIFUp_Click(object sender, RoutedEventArgs e)
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

        private void btONVIFDown_Click(object sender, RoutedEventArgs e)
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

        private void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
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

        private void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
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

        private void pnPIPChromaKeyColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnPIPChromaKeyColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnPIPChromaKeyColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
            }
        }

        private void tbPIPChromaKeyTolerance1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbPIPChromaKeyTolerance1.Content = tbPIPChromaKeyTolerance1.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void tbPIPChromaKeyTolerance2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbPIPChromaKeyTolerance2.Content = tbPIPChromaKeyTolerance2.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void btSelectHLSOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edHLSOutputFolder.Text = folderDialog.SelectedPath;
            }
        }

        private void lbHLSConfigure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.HLSStreaming);
            Process.Start(startInfo);
        }

        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void BtOutputConfigure_Click(object sender, RoutedEventArgs e)
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
                        if (ffmpegSettingsDialog == null)
                        {
                            ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }

                        ffmpegSettingsDialog.ShowDialog(this);

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
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(this);

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
                            mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 27:
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

        private void UpdateRecordingTime()
        {
            var ts = VideoCapture1.Duration_Time();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher?.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
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

        private void BtTextLogoEdit_Click(object sender, RoutedEventArgs e)
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

        private void BtTextLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
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

        private void BtImageLogoEdit_Click(object sender, RoutedEventArgs e)
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

        private void BtImageLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        private void CbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.IsChecked == true;
                }
            }
        }

        private void CbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVFVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVFVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.IsChecked == true;
                }
            }
        }

        private async void BtCCReadValues_Click(object sender, RoutedEventArgs e)
        {
            var pan = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Pan);
            if (pan != null)
            {
                tbCCPan.Minimum = pan.Min;
                tbCCPan.Maximum = pan.Max;
                tbCCPan.SmallChange = pan.Step;
                tbCCPan.Value = pan.Default;
                lbCCPanMin.Content = "Min: " + Convert.ToString(pan.Min);
                lbCCPanMax.Content = "Max: " + Convert.ToString(pan.Max);
                lbCCPanCurrent.Content = "Current: " + Convert.ToString(pan.Default);

                cbCCPanManual.IsChecked = (pan.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCPanAuto.IsChecked = (pan.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCPanRelative.IsChecked = (pan.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var tilt = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Tilt);
            if (tilt != null)
            {
                tbCCTilt.Minimum = tilt.Min;
                tbCCTilt.Maximum = tilt.Max;
                tbCCTilt.SmallChange = tilt.Step;
                tbCCTilt.Value = tilt.Default;
                lbCCTiltMin.Content = "Min: " + Convert.ToString(tilt.Min);
                lbCCTiltMax.Content = "Max: " + Convert.ToString(tilt.Max);
                lbCCTiltCurrent.Content = "Current: " + Convert.ToString(tilt.Default);

                cbCCTiltManual.IsChecked = (tilt.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCTiltAuto.IsChecked = (tilt.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCTiltRelative.IsChecked = (tilt.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var focus = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Focus);
            if (focus != null)
            {
                tbCCFocus.Minimum = focus.Min;
                tbCCFocus.Maximum = focus.Max;
                tbCCFocus.SmallChange = focus.Step;
                tbCCFocus.Value = focus.Default;
                lbCCFocusMin.Content = "Min: " + Convert.ToString(focus.Min);
                lbCCFocusMax.Content = "Max: " + Convert.ToString(focus.Max);
                lbCCFocusCurrent.Content = "Current: " + Convert.ToString(focus.Default);

                cbCCFocusManual.IsChecked = (focus.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCFocusAuto.IsChecked = (focus.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCFocusRelative.IsChecked = (focus.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }

            var zoom = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(VFCameraControlProperty.Zoom);
            if (zoom != null)
            {
                tbCCZoom.Minimum = zoom.Min;
                tbCCZoom.Maximum = zoom.Max;
                tbCCZoom.SmallChange = zoom.Step;
                tbCCZoom.Value = zoom.Default;
                lbCCZoomMin.Content = "Min: " + Convert.ToString(zoom.Min);
                lbCCZoomMax.Content = "Max: " + Convert.ToString(zoom.Max);
                lbCCZoomCurrent.Content = "Current: " + Convert.ToString(zoom.Default);

                cbCCZoomManual.IsChecked = (zoom.Flags & VFCameraControlFlags.Manual) == VFCameraControlFlags.Manual;
                cbCCZoomAuto.IsChecked = (zoom.Flags & VFCameraControlFlags.Auto) == VFCameraControlFlags.Auto;
                cbCCZoomRelative.IsChecked = (zoom.Flags & VFCameraControlFlags.Relative) == VFCameraControlFlags.Relative;
            }
        }

        private async void BtCCPanApply_Click(object sender, RoutedEventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCPanManual.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCPanAuto.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCPanRelative.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Pan, new VideoCaptureDeviceCameraControlValue((int)tbCCPan.Value, flags));
        }

        private async void BtCCTiltApply_Click(object sender, RoutedEventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCTiltManual.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCTiltAuto.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCTiltRelative.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Tilt, new VideoCaptureDeviceCameraControlValue((int)tbCCTilt.Value, flags));
        }

        private async void BtCCFocusApply_Click(object sender, RoutedEventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCFocusManual.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCFocusAuto.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCFocusRelative.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Focus, new VideoCaptureDeviceCameraControlValue((int)tbCCFocus.Value, flags));
        }

        private async void BtCCZoomApply_Click(object sender, RoutedEventArgs e)
        {
            VFCameraControlFlags flags = VFCameraControlFlags.None;

            if (cbCCZoomManual.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Manual;
            }

            if (cbCCZoomAuto.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Auto;
            }

            if (cbCCZoomRelative.IsChecked == true)
            {
                flags = flags | VFCameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(VFCameraControlProperty.Zoom, new VideoCaptureDeviceCameraControlValue((int)tbCCZoom.Value, flags));
        }

        private void btScreenSourceWindowSelect_Click(object sender, RoutedEventArgs e)
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

            lbScreenSourceWindowText.Content = e.Caption;
        }

        private void tbGPUBlur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVFGPUVideoEffectBlur intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBlur(tbGPUBlur.Value > 0, (int)tbGPUBlur.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IVFGPUVideoEffectBlur;
                if (intf != null)
                {
                    intf.Enabled = tbGPUBlur.Value > 0;
                    intf.Value = (int)tbGPUBlur.Value;
                    intf.Update();
                }
            }
        }

        private void cbAdjBrightnessAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjBrightness_Scroll(null, null);
        }

        private void cbAdjHueAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjHue_Scroll(null, null);
        }

        private void cbAdjContrastAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjContrast_Scroll(null, null);
        }

        private void cbAdjSaturationAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjSaturation_Scroll(null, null);
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

        private void btChromaKeySelectBGImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
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

        private void lbVLCRedist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx86UI);
            Process.Start(startInfo);
        }

        private void lbVLCRedist64_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistVLCx64UI);
            Process.Start(startInfo);
        }

        private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        private void btListNDISources_Click(object sender, RoutedEventArgs e)
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

        private async void btListONVIFSources_Click(object sender, RoutedEventArgs e)
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

        private void btVirtualCameraRegister_Click(object sender, RoutedEventArgs e)
        {
            btVirtualCameraRegister.IsEnabled = !VideoCapture1.CustomRedist_VirtualCameraRegister();
        }

        private void llXiphX86_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86);
            Process.Start(startInfo);
        }

        private void llXiphX64_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64);
            Process.Start(startInfo);
        }

        private void cbPIPFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbPIPFormat.SelectedValue?.ToString()))
            {
                return;
            }

            if (cbPIPDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevicesInfo.FirstOrDefault(device => device.Name == cbPIPDevice.SelectedValue.ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbPIPFormat.SelectedValue.ToString());
                if (videoFormat == null)
                {
                    return;
                }

                cbPIPFrameRate.Items.Clear();
                foreach (var frameRate in videoFormat.FrameRates)
                {
                    cbPIPFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
                }

                if (cbPIPFrameRate.Items.Count > 0)
                {
                    cbPIPFrameRate.SelectedIndex = 0;
                }
            }
        }
    }
}

// ReSharper restore InconsistentNaming