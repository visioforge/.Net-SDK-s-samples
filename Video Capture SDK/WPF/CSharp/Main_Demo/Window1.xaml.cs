




namespace Main_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security.Principal;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    using VisioForge.Core.Helpers;
    // Legacy ONVIF namespace removed - using new ONVIFX
    using VisioForge.Core.ONVIFDiscovery.Models;
    using VisioForge.Core.ONVIFX;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.AudioEffects;
    using VisioForge.Core.Types.Decklink;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.FFMPEGEXE;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.Types.VideoProcessing;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoCapture;
    using Application = System.Windows.Application;
    using Color = System.Windows.Media.Color;
    using M4AOutput = VisioForge.Core.Types.Output.M4AOutput;
    using MessageBox = System.Windows.MessageBox;
    using ScreenCaptureMode = VisioForge.Core.Types.VideoCapture.ScreenCaptureMode;

    

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class Window1
    {
        /// <summary>
        /// Audio effect identifier for amplify effect.
        /// </summary>
        private const string AUDIO_EFFECT_ID_AMPLIFY = "amplify";

        /// <summary>
        /// Audio effect identifier for equalizer effect.
        /// </summary>
        private const string AUDIO_EFFECT_ID_EQ = "eq";

        /// <summary>
        /// Audio effect identifier for dynamic amplify effect.
        /// </summary>
        private const string AUDIO_EFFECT_ID_DYN_AMPLIFY = "dyn_amplify";

        /// <summary>
        /// Audio effect identifier for 3D sound effect.
        /// </summary>
        private const string AUDIO_EFFECT_ID_SOUND_3D = "sound3d";

        /// <summary>
        /// Audio effect identifier for true bass effect.
        /// </summary>
        private const string AUDIO_EFFECT_ID_TRUE_BASS = "true_bass";

        /// <summary>
        /// The main video capture core engine instance.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// Settings dialog for MP4 hardware encoder output.
        /// </summary>
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        /// <summary>
        /// Settings dialog for MPEG-TS hardware encoder output.
        /// </summary>
        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        /// <summary>
        /// Settings dialog for MOV hardware encoder output.
        /// </summary>
        private HWEncodersOutputSettingsDialog movSettingsDialog;

        /// <summary>
        /// Settings dialog for MP4 output format.
        /// </summary>
        private MP4SettingsDialog mp4SettingsDialog;

        /// <summary>
        /// Settings dialog for AVI output format.
        /// </summary>
        private AVISettingsDialog aviSettingsDialog;

        /// <summary>
        /// Settings dialog for WMV output format.
        /// </summary>
        private WMVSettingsDialog wmvSettingsDialog;

        /// <summary>
        /// Settings dialog for DV output format.
        /// </summary>
        private DVSettingsDialog dvSettingsDialog;

        /// <summary>
        /// Settings dialog for PCM audio output format.
        /// </summary>
        private PCMSettingsDialog pcmSettingsDialog;

        /// <summary>
        /// Settings dialog for MP3 audio output format.
        /// </summary>
        private MP3SettingsDialog mp3SettingsDialog;

        /// <summary>
        /// Settings dialog for WebM output format.
        /// </summary>
        private WebMSettingsDialog webmSettingsDialog;

        /// <summary>
        /// Settings dialog for FFMPEG output format.
        /// </summary>
        private FFMPEGSettingsDialog ffmpegSettingsDialog;

        /// <summary>
        /// Settings dialog for FFMPEG executable output format.
        /// </summary>
        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        /// <summary>
        /// Settings dialog for FLAC audio output format.
        /// </summary>
        private FLACSettingsDialog flacSettingsDialog;

        /// <summary>
        /// Settings dialog for custom output format.
        /// </summary>
        private CustomFormatSettingsDialog customFormatSettingsDialog;

        /// <summary>
        /// Settings dialog for Ogg Vorbis audio output format.
        /// </summary>
        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        /// <summary>
        /// Settings dialog for Speex audio output format.
        /// </summary>
        private SpeexSettingsDialog speexSettingsDialog;

        /// <summary>
        /// Settings dialog for M4A audio output format.
        /// </summary>
        private M4ASettingsDialog m4aSettingsDialog;

        /// <summary>
        /// Settings dialog for GIF output format.
        /// </summary>
        private GIFSettingsDialog gifSettingsDialog;

        /// <summary>
        /// ONVIF client for IP camera control and communication.
        /// </summary>
        private ONVIFClientX onvifClient;

        /// <summary>
        /// List of audio channel mapper items for audio routing configuration.
        /// </summary>
        private readonly List<AudioChannelMapperItem> audioChannelMapperItems = new List<AudioChannelMapperItem>();

        /// <summary>
        /// Current zoom level for video display (1.0 = 100%).
        /// </summary>
        private double zoom = 1.0;

        /// <summary>
        /// Horizontal shift offset for zoomed video display.
        /// </summary>
        private int zoomShiftX;

        /// <summary>
        /// Vertical shift offset for zoomed video display.
        /// </summary>
        private int zoomShiftY;

        /// <summary>
        /// Font dialog for text logo customization.
        /// </summary>
        private readonly FontDialog fontDialog = new FontDialog();

        /// <summary>
        /// Save file dialog for output file selection.
        /// </summary>
        private readonly Microsoft.Win32.SaveFileDialog outputFileSaveDialog = new Microsoft.Win32.SaveFileDialog();

        /// <summary>
        /// Save file dialog for screenshot capture functionality.
        /// </summary>
        private readonly Microsoft.Win32.SaveFileDialog screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
        };

        /// <summary>
        /// Timer for updating recording time display.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// Open file dialog for file selection (instance 1).
        /// </summary>
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        /// <summary>
        /// Open file dialog for file selection (instance 2).
        /// </summary>
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog2 = new Microsoft.Win32.OpenFileDialog();

        /// <summary>
        /// Color dialog for color selection.
        /// </summary>
        private readonly ColorDialog colorDialog1 = new ColorDialog();

        /// <summary>
        /// Folder browser dialog for directory selection.
        /// </summary>
        private readonly FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        /// <summary>
        /// Form for window capture source selection.
        /// </summary>
        private WindowCaptureForm windowCaptureForm;

        private static System.Drawing.Color ColorConv(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// Color conv.
        /// </summary>
        private static Color ColorConv(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Add audio effects.
        /// </summary>
        private void AddAudioEffects()
        {
            VideoCapture1.Audio_Effects_Clear(-1);

            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            VideoCapture1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
        }

        /// <summary>
        /// Create engine async.
        /// </summary>
        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnBarcodeDetected += VideoCapture1_OnBarcodeDetected;
            VideoCapture1.OnAudioVUMeterProVolume += VideoCapture1_OnAudioVUMeterProVolume;
            VideoCapture1.OnMotion += VideoCapture1_OnMotion;
            VideoCapture1.OnMotionDetectionEx += VideoCapture1_OnMotionDetectionEx;
            VideoCapture1.OnAudioVUMeterProFFTCalculated += VideoCapture1_OnAudioVUMeterProFFTCalculated;
            VideoCapture1.OnTVTunerTuneChannels += VideoCapture1_OnTVTunerTuneChannels;
            VideoCapture1.OnNetworkSourceDisconnect += VideoCapture1_OnNetworkSourceDisconnect;
            VideoCapture1.OnFFMPEGInfo += VideoCapture1_OnFFMPEGInfo;
            VideoCapture1.OnFaceDetected += VideoCapture1_OnFaceDetected;
            VideoCapture1.OnAudioVUMeterProMaximumCalculated += VideoCapture1_OnAudioVUMeterProMaximumCalculated;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnBarcodeDetected -= VideoCapture1_OnBarcodeDetected;
                VideoCapture1.OnAudioVUMeterProVolume -= VideoCapture1_OnAudioVUMeterProVolume;
                VideoCapture1.OnMotion -= VideoCapture1_OnMotion;
                VideoCapture1.OnMotionDetectionEx -= VideoCapture1_OnMotionDetectionEx;
                VideoCapture1.OnAudioVUMeterProFFTCalculated -= VideoCapture1_OnAudioVUMeterProFFTCalculated;
                VideoCapture1.OnTVTunerTuneChannels -= VideoCapture1_OnTVTunerTuneChannels;
                VideoCapture1.OnNetworkSourceDisconnect -= VideoCapture1_OnNetworkSourceDisconnect;
                VideoCapture1.OnFFMPEGInfo -= VideoCapture1_OnFFMPEGInfo;
                VideoCapture1.OnFaceDetected -= VideoCapture1_OnFaceDetected;
                VideoCapture1.OnAudioVUMeterProMaximumCalculated -= VideoCapture1_OnAudioVUMeterProMaximumCalculated;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }

            tmRecording.Dispose();
            tmRecording = null;
        }

        /// <summary>
        /// Video capture 1 on motion detection ex.
        /// </summary>
        private void VideoCapture1_OnMotionDetectionEx(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher?.Invoke(() =>
            {
                pbAFMotionLevel.Value = e.LevelPercent;
            });
        }

        /// <summary>
        /// Form 1 load.
        /// </summary>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            await CreateEngineAsync();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

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

            foreach (var item in VideoCapture1.Decklink_Output_VideoRenderers())
            {
                cbDecklinkOutputVideoRenderer.Items.Add(item);
            }

            if (cbDecklinkOutputVideoRenderer.Items.Count > 0)
            {
                cbDecklinkOutputVideoRenderer.SelectedIndex = 0;
            }

            foreach (var item in VideoCapture1.Decklink_Output_AudioRenderers())
            {
                cbDecklinkOutputAudioRenderer.Items.Add(item);
            }

            if (cbDecklinkOutputAudioRenderer.Items.Count > 0)
            {
                cbDecklinkOutputAudioRenderer.SelectedIndex = 0;
            }

            cbFaceTrackingColorMode.SelectedIndex = 0;
            cbFaceTrackingScalingMode.SelectedIndex = 0;
            cbFaceTrackingSearchMode.SelectedIndex = 1;

            rbMotionDetectionExProcessor.SelectedIndex = 1;
            rbMotionDetectionExDetector.SelectedIndex = 1;

            pnChromaKeyColor.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 218, 128));

            var genres = new List<string>();
            foreach (var genre in VideoCapture1.Tags_GetDefaultVideoGenres())
            {
                genres.Add(genre);
            }

            foreach (var genre in VideoCapture1.Tags_GetDefaultAudioGenres())
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

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            edNewFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output_new.mp4");

            await VideoCapture1.TVTuner_ReadAsync();

            foreach (string tunerDevice in VideoCapture1.TVTuner_Devices())
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

            foreach (string tunerCountry in VideoCapture1.TVTuner_Countries())
            {
                cbTVCountry.Items.Add(tunerCountry);
            }

            cbTVCountry.SelectedIndex = 0;

            cbTVTuner_SelectedIndexChanged(null, null);

            foreach (var device in VideoCapture1.Video_CaptureDevices())
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

            foreach (var device in VideoCapture1.Audio_CaptureDevices())
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
            foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices())
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

            if (!string.IsNullOrEmpty(cbAudioInputDevice.SelectedValue.ToString()))
            {
                var deviceItem =
                    VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == cbAudioInputDevice.SelectedValue.ToString());
                if (deviceItem != null)
                {
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

            cbVideoInputFormat_SelectedIndexChanged(null, null);

            foreach (string specialFilter in VideoCapture1.Special_Filters(SpecialFilterType.HardwareVideoEncoder))
            {
                cbMPEGEncoder.Items.Add(specialFilter);
            }

            if (cbMPEGEncoder.Items.Count > 0)
            {
                cbMPEGEncoder.SelectedIndex = 0;
            }

            foreach (string directShowFilter in VideoCapture1.DirectShow_Filters())
            {
                cbFilters.Items.Add(directShowFilter);
            }

            cbMPEGVideoDecoder.Items.Add("(default)");
            cbMPEGAudioDecoder.Items.Add("(default)");

            foreach (string specialFilter in VideoCapture1.Special_Filters(SpecialFilterType.MPEG12VideoDecoder))
            {
                cbMPEGVideoDecoder.Items.Add(specialFilter);
            }

            cbMPEGVideoDecoder.SelectedIndex = 0;

            foreach (string specialFilter in VideoCapture1.Special_Filters(SpecialFilterType.MPEG1AudioDecoder))
            {
                cbMPEGAudioDecoder.Items.Add(specialFilter);
            }

            cbMPEGAudioDecoder.SelectedIndex = 0;

            cbMPEGVideoDecoder_SelectedIndexChanged(null, null);
            cbMPEGAudioDecoder_SelectedIndexChanged(null, null);

            List<string> names;
            List<string> descs;
            VideoCapture1.WMV_V8_Profiles(out names, out descs);

            
            foreach (var item in VideoCapture1.Audio_Effects_Equalizer_Presets())
            {
                cbAudEqualizerPreset.Items.Add(item);
            }

            cbAudEqualizerPreset.SelectedIndex = 0;

            foreach (var device in await VideoCapture1.Decklink_CaptureDevicesAsync())
            {
                cbDecklinkCaptureDevice.Items.Add(device.Name);
            }

            if (cbDecklinkCaptureDevice.Items.Count > 0)
            {
                cbDecklinkCaptureDevice.SelectedIndex = 0;
                cbDecklinkCaptureDevice_SelectionChanged(null, null);
            }

            btVirtualCameraRegister.IsEnabled = !VideoCapture1.DirectShow_Filters().Contains("VisioForge Virtual Camera");
        }

        /// <summary>
        /// Cb video input device selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbVideoInputFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
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
                                    cbCrossbarOutput.SelectedValue.ToString());

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
                    var brightnessRange = await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Brightness);
                    if (brightnessRange != null)
                    {
                        tbAdjBrightness.Minimum = brightnessRange.Min;
                        tbAdjBrightness.Maximum = brightnessRange.Max;
                        tbAdjBrightness.SmallChange = brightnessRange.Step;
                        tbAdjBrightness.Value = brightnessRange.Default;
                        cbAdjBrightnessAuto.IsChecked = brightnessRange.Auto;
                        lbAdjBrightnessMin.Content = "Min: " + Convert.ToString(brightnessRange.Min);
                        lbAdjBrightnessMax.Content = "Max: " + Convert.ToString(brightnessRange.Max);
                        lbAdjBrightnessCurrent.Content = "Current: " + Convert.ToString(brightnessRange.Default);
                    }

                    var hueRange = await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Hue);
                    if (hueRange != null)
                    {
                        tbAdjHue.Minimum = hueRange.Min;
                        tbAdjHue.Maximum = hueRange.Max;
                        tbAdjHue.SmallChange = hueRange.Step;
                        tbAdjHue.Value = hueRange.Default;
                        cbAdjHueAuto.IsChecked = hueRange.Auto;
                        lbAdjHueMin.Content = "Min: " + Convert.ToString(hueRange.Min);
                        lbAdjHueMax.Content = "Max: " + Convert.ToString(hueRange.Max);
                        lbAdjHueCurrent.Content = "Current: " + Convert.ToString(hueRange.Default);
                    }

                    var saturationRange = await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Saturation);
                    if (saturationRange != null)
                    {
                        tbAdjSaturation.Minimum = saturationRange.Min;
                        tbAdjSaturation.Maximum = saturationRange.Max;
                        tbAdjSaturation.SmallChange = saturationRange.Step;
                        tbAdjSaturation.Value = saturationRange.Default;
                        cbAdjSaturationAuto.IsChecked = saturationRange.Auto;
                        lbAdjSaturationMin.Content = "Min: " + Convert.ToString(saturationRange.Min);
                        lbAdjSaturationMax.Content = "Max: " + Convert.ToString(saturationRange.Max);
                        lbAdjSaturationCurrent.Content = "Current: " + Convert.ToString(saturationRange.Default);
                    }

                    var contrastRange = await VideoCapture1.Video_CaptureDevice_VideoAdjust_GetRangesAsync(VideoHardwareAdjustment.Contrast);
                    if (contrastRange != null)
                    {
                        tbAdjContrast.Minimum = contrastRange.Min;
                        tbAdjContrast.Maximum = contrastRange.Max;
                        tbAdjContrast.SmallChange = contrastRange.Step;
                        tbAdjContrast.Value = contrastRange.Default;
                        cbAdjContrastAuto.IsChecked = contrastRange.Auto;
                        lbAdjContrastMin.Content = "Min: " + Convert.ToString(contrastRange.Min);
                        lbAdjContrastMax.Content = "Max: " + Convert.ToString(contrastRange.Max);
                        lbAdjContrastCurrent.Content = "Current: " + Convert.ToString(contrastRange.Default);
                    }

                    btVideoCaptureDeviceSettings.IsEnabled = deviceItem.DialogDefault;
                }
            }
        }

        /// <summary>
        /// Cb audio input device selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbAudioInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat.Items.Clear();
                cbAudioInputLine.Items.Clear();

                var deviceItem = VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == cbAudioInputDevice.SelectedValue.ToString());
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

                    foreach (string line in deviceItem.Lines)
                    {
                        cbAudioInputLine.Items.Add(line);
                    }

                    if (cbAudioInputLine.Items.Count > 0)
                    {
                        cbAudioInputLine.SelectedIndex = 0;
                    }

                    btAudioInputDeviceSettings.IsEnabled = deviceItem.DialogDefault;
                }
            }
        }

        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (outputFileSaveDialog.ShowDialog() == true)
            {
                edOutput.Text = outputFileSaveDialog.FileName;
            }
        }

        /// <summary>
        /// Select screen capture source.
        /// </summary>
        /// <param name="settings">The settings.</param>
        private void SelectScreenCaptureSource(out ScreenCaptureSourceSettings settings)
        {
            settings = new ScreenCaptureSourceSettings();
            if (rbScreenCaptureWindow.IsChecked == true)
            {
                settings.Mode = ScreenCaptureMode.Window;
                settings.WindowHandle = IntPtr.Zero;

                try
                {
                    if (windowCaptureForm == null)
                    {
                        MessageBox.Show(this, "Window for screen capture is not specified.");
                        return;
                    }

                    settings.WindowHandle = windowCaptureForm.CapturedWindowHandle;
                }
                catch
                {
                    MessageBox.Show(this, "Incorrect window title for screen capture.");
                    return;
                }

                if (settings.WindowHandle == IntPtr.Zero)
                {
                    MessageBox.Show(this, "Incorrect window title for screen capture.");
                    return;
                }
            }
            else
            {
                settings.Mode = ScreenCaptureMode.Screen;
            }

            settings.FrameRate = new VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text));
            settings.FullScreen = rbScreenFullScreen.IsChecked == true;
            settings.Top = Convert.ToInt32(edScreenTop.Text);
            settings.Bottom = Convert.ToInt32(edScreenBottom.Text);
            settings.Left = Convert.ToInt32(edScreenLeft.Text);
            settings.Right = Convert.ToInt32(edScreenRight.Text);
            settings.GrabMouseCursor = cbScreenCapture_GrabMouseCursor.IsChecked == true;
            settings.MouseHighlight = cbScreenCapture_HighlightMouseCursor.IsChecked == true;

            settings.DisplayIndex = Convert.ToInt32(cbScreenCaptureDisplayIndex.SelectedValue);
            settings.AllowDesktopDuplicationEngine = cbScreenCapture_DesktopDuplication.IsChecked == true;
        }

        /// <summary>
        /// Select ip camera source.
        /// </summary>
        /// <param name="settings">The settings.</param>
        private void SelectIPCameraSource(out IPCameraSourceSettings settings)
        {
            settings = new IPCameraSourceSettings
            {
                URL = new Uri(cbIPURL.Text)
            };

            bool lavGPU = false;
            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    settings.Type = IPSourceEngine.Auto_VLC;
                    break;
                case 1:
                    settings.Type = IPSourceEngine.Auto_FFMPEG;
                    break;
                case 2:
                    settings.Type = IPSourceEngine.Auto_LAV;
                    break;
                case 3:
                    settings.Type = IPSourceEngine.Auto_LAV;
                    lavGPU = true;
                    break;
                case 4:
                    settings.Type = IPSourceEngine.MMS_WMV;
                    break;
                case 5:
                    settings.Type = IPSourceEngine.HTTP_MJPEG_LowLatency;
                    cbIPAudioCapture.IsChecked = false;
                    break;
                case 6:
                    settings.Type = IPSourceEngine.RTSP_LowLatency;
                    settings.RTSP_LowLatency_UseUDP = false;
                    break;
                case 7:
                    settings.Type = IPSourceEngine.RTSP_LowLatency;
                    settings.RTSP_LowLatency_UseUDP = true;
                    break;
                case 8:
                    settings.Type = IPSourceEngine.NDI;
                    break;
                case 9:
                    settings.Type = IPSourceEngine.NDI_Legacy;
                    break;
            }

            settings.AudioCapture = cbIPAudioCapture.IsChecked == true;
            settings.Login = edIPLogin.Text;
            settings.Password = edIPPassword.Text;
            settings.ForcedFramerate = new VideoFrameRate(Convert.ToInt32(edIPForcedFramerate.Text));
            settings.ForcedFramerate_InstanceID = edIPForcedFramerateID.Text[0];
            settings.Debug_Enabled = cbDebugMode.IsChecked == true;
            settings.Debug_Filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "ip_cam_log.txt");
            settings.VLC_ZeroClockJitterEnabled = cbVLCZeroClockJitter.IsChecked == true;
            settings.VLC_CustomLatency = Convert.ToInt32(edVLCCacheSize.Text);

            if (settings.Type == IPSourceEngine.Auto_LAV)
            {
                settings.LAV_GPU_Use = lavGPU;
                settings.LAV_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack;
            }

            if (cbIPCameraONVIF.IsChecked == true)
            {
                settings.ONVIF_Source = true;

                if (cbONVIFProfile.SelectedIndex != -1)
                {
                    settings.ONVIF_SourceProfile = cbONVIFProfile.SelectedValue.ToString();
                }
            }

            if (cbIPDisconnect.IsChecked == true)
            {
                settings.DisconnectEventInterval = TimeSpan.FromSeconds(10);
            }
            else
            {
                settings.DisconnectEventInterval = TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Set mp 3 output.
        /// </summary>
        /// <param name="mp3Output">The mp3 output.</param>
        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        /// <summary>
        /// Set mp 4 output.
        /// </summary>
        /// <param name="mp4Output">The mp4 output.</param>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set ffmpegexe output.
        /// </summary>
        /// <param name="ffmpegOutput">The ffmpeg output.</param>
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Set wmv output.
        /// </summary>
        /// <param name="wmvOutput">The wmv output.</param>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Set wma output.
        /// </summary>
        /// <param name="wmaOutput">The wma output.</param>
        private void SetWMAOutput(ref WMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoCapture1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        /// <summary>
        /// Set acm output.
        /// </summary>
        /// <param name="acmOutput">The acm output.</param>
        private void SetACMOutput(ref ACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1);
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        /// <summary>
        /// Set web m output.
        /// </summary>
        /// <param name="webmOutput">The webm output.</param>
        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        /// <summary>
        /// Set ffmpeg output.
        /// </summary>
        /// <param name="ffmpegOutput">The ffmpeg output.</param>
        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Set flac output.
        /// </summary>
        /// <param name="flacOutput">The flac output.</param>
        private void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        /// <summary>
        /// Set mp 4 hw output.
        /// </summary>
        /// <param name="mp4Output">The mp4 output.</param>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set mpegts output.
        /// </summary>
        /// <param name="mpegTSOutput">The mpeg ts output.</param>
        private void SetMPEGTSOutput(ref MPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        /// <summary>
        /// Set mov output.
        /// </summary>
        /// <param name="mkvOutput">The mkv output.</param>
        private void SetMOVOutput(ref MOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        /// <summary>
        /// Set speex output.
        /// </summary>
        /// <param name="speexOutput">The speex output.</param>
        private void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        /// <summary>
        /// Set m 4 a output.
        /// </summary>
        /// <param name="m4aOutput">The m4a output.</param>
        private void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        /// <summary>
        /// Set gif output.
        /// </summary>
        /// <param name="gifOutput">The gif output.</param>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Set direct capture custom output.
        /// </summary>
        /// <param name="directCaptureOutput">The direct capture output.</param>
        private void SetDirectCaptureCustomOutput(ref DirectCaptureCustomOutput directCaptureOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1);
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        /// <summary>
        /// Set direct capture custom output.
        /// </summary>
        /// <param name="directCaptureOutput">The direct capture output.</param>
        private void SetDirectCaptureCustomOutput(ref DirectCaptureMP4Output directCaptureOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1);
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        /// <summary>
        /// Set custom output.
        /// </summary>
        /// <param name="customOutput">The custom output.</param>
        private void SetCustomOutput(ref CustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1);
            }

            customFormatSettingsDialog.SaveSettings(ref customOutput);
        }

        /// <summary>
        /// Set dv output.
        /// </summary>
        /// <param name="dvOutput">The dv output.</param>
        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        /// <summary>
        /// Set avi output.
        /// </summary>
        /// <param name="aviOutput">The avi output.</param>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1);
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Set mkv output.
        /// </summary>
        /// <param name="mkvOutput">The mkv output.</param>
        private void SetMKVOutput(ref MKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoCapture1);
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Set ogg output.
        /// </summary>
        /// <param name="oggVorbisOutput">The ogg vorbis output.</param>
        private void SetOGGOutput(ref OGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null)
            {
                oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
            }

            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            VideoView1.StatusOverlay = null;

            if (onvifClient != null)
            {
                onvifClient.Dispose();
                onvifClient = null;

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
            //VideoCapture1.VLC_Path = Environment.GetEnvironmentVariable("VFVLCPATH");

            VideoCapture1.Video_Renderer.Zoom_Ratio = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftX = 0;
            VideoCapture1.Video_Renderer.Zoom_ShiftY = 0;

            VideoCapture1.Video_Effects_Clear();
            lbImageLogos.Items.Clear();
            lbTextLogos.Items.Clear();

            switch (cbMode.SelectedIndex)
            {
                case 0:
                    VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
                    break;
                case 1:
                    VideoCapture1.Mode = VideoCaptureMode.VideoCapture;
                    break;
                case 2:
                    VideoCapture1.Mode = VideoCaptureMode.AudioPreview;
                    break;
                case 3:
                    VideoCapture1.Mode = VideoCaptureMode.AudioCapture;
                    break;
                case 4:
                    VideoCapture1.Mode = VideoCaptureMode.ScreenPreview;
                    break;
                case 5:
                    VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;
                    break;
                case 6:
                    VideoCapture1.Mode = VideoCaptureMode.IPPreview;
                    break;
                case 7:
                    VideoCapture1.Mode = VideoCaptureMode.IPCapture;
                    break;
                case 8:
                    VideoCapture1.Mode = VideoCaptureMode.BDAPreview;
                    break;
                case 9:
                    VideoCapture1.Mode = VideoCaptureMode.BDACapture;
                    break;
                case 10:
                    VideoCapture1.Mode = VideoCaptureMode.CustomPreview;
                    break;
                case 11:
                    VideoCapture1.Mode = VideoCaptureMode.CustomCapture;
                    break;
                case 12:
                    VideoCapture1.Mode = VideoCaptureMode.DecklinkSourcePreview;
                    break;
                case 13:
                    VideoCapture1.Mode = VideoCaptureMode.DecklinkSourceCapture;
                    break;
            }

            VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.Text;

            VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.Text);
            VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.Text;
            VideoCapture1.Audio_CaptureDevice.Line = cbAudioInputLine.Text;
            VideoCapture1.Audio_CaptureDevice.Format_UseBest = cbUseBestAudioInputFormat.IsChecked == true;

            VideoCapture1.Additional_Audio_CaptureDevice_MixChannels = rbAddAudioStreamsMix.IsChecked == true;

            // Network streaming
            VideoCapture1.Network_Streaming_Enabled = cbNetworkStreaming.IsChecked == true;

            if (VideoCapture1.Network_Streaming_Enabled)
            {
                switch (cbNetworkStreamingMode.SelectedIndex)
                {
                    case 0:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.WMV;
                            WMVOutput wmvOutput;

                            if (rbNetworkStreamingUseMainWMVSettings.IsChecked == true)
                            {
                                wmvOutput = new WMVOutput();
                                SetWMVOutput(ref wmvOutput);                                
                            }
                            else
                            {
                                wmvOutput = new WMVOutput
                                {
                                    Mode = WMVMode.ExternalProfile,
                                    External_Profile_FileName = edNetworkStreamingWMVProfile.Text
                                };
                            }

                            wmvOutput.Network_Streaming_WMV_Maximum_Clients = Convert.ToInt32(edMaximumClients.Text);
                            VideoCapture1.Network_Streaming_Output = wmvOutput;

                            VideoCapture1.Network_Streaming_Network_Port = Convert.ToInt32(edWMVNetworkPort.Text);

                            break;
                        }

                    case 1:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.HTTP_MJPEG;
                            VideoCapture1.Network_Streaming_Output = new MJPEGOutput(Convert.ToInt32(edMJPEGPort.Text));
                            
                            break;
                        }

                    case 2:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW;

                            var mp4Output = new MP4Output();
                            SetMP4Output(ref mp4Output);
                            VideoCapture1.Network_Streaming_Output = mp4Output;

                            VideoCapture1.Network_Streaming_URL = edNetworkRTSPURL.Text;

                            break;
                        }

                    case 3:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.RTMP_FFMPEG_EXE;

                            var ffmpegOutput = new FFMPEGEXEOutput();

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

                            if (rbNetworkRTMPYouTube.IsChecked == true)
                            {
                                VideoCapture1.Network_Streaming_URL = "rtmp://a.rtmp.youtube.com/live2/" + edNetworkRTMPYouTube.Text;

                                if (cbNetworkStreamingAudioEnabled.IsChecked == false || cbPlayAudio.IsChecked == false)
                                {
                                    MessageBox.Show(this, "Audio streaming should be enabled to stream to YouTube.");
                                    cbNetworkStreamingAudioEnabled.IsChecked = true;
                                }
                            }
                            else if (rbNetworkRTMPFacebook.IsChecked == true)
                            {
                                VideoCapture1.Network_Streaming_URL = "rtmps://live-api-s.facebook.com:443/rtmp/" + edNetworkRTMPFacebook.Text;

                                if (cbNetworkStreamingAudioEnabled.IsChecked == false || cbPlayAudio.IsChecked == false)
                                {
                                    MessageBox.Show(this, "Audio streaming should be enabled to stream to Facebook Live.");
                                    cbNetworkStreamingAudioEnabled.IsChecked = true;
                                }
                            }
                            else
                            {
                                VideoCapture1.Network_Streaming_URL = edNetworkRTMPURL.Text;
                            }

                            break;
                        }

                    case 4:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.NDI;

                            var ndiOutput = new NDIOutput(edNDIName.Text);
                            VideoCapture1.Network_Streaming_Output = ndiOutput;
                            edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}";

                            break;
                        }

                    case 5:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.UDP_FFMPEG_EXE;

                            var ffmpegOutput = new FFMPEGEXEOutput();

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

                    case 6:
                        {
                            if (rbNetworkSSSoftware.IsChecked == true)
                            {
                                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.SSF_H264_AAC_SW;

                                var mp4Output = new MP4Output();
                                SetMP4Output(ref mp4Output);
                                VideoCapture1.Network_Streaming_Output = mp4Output;
                            }
                            else
                            {
                                VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.SSF_FFMPEG_EXE;

                                var ffmpegOutput = new FFMPEGEXEOutput();

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
                    case 7:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.HLS;

                            var hls = new HLSOutput
                            {
                                HLS =
                                {
                                    SegmentDuration = Convert.ToInt32(edHLSSegmentDuration.Text),
                                    NumSegments = Convert.ToInt32(edHLSSegmentCount.Text),
                                    OutputFolder = edHLSOutputFolder.Text,
                                    PlaylistType = (HLSPlaylistType)cbHLSMode.SelectedIndex,
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
                    case 8:
                        {
                            VideoCapture1.Network_Streaming_Format = NetworkStreamingFormat.External;

                            break;
                        }
                }

                VideoCapture1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.IsChecked == true;
            }

            if (VideoCapture1.Mode == VideoCaptureMode.ScreenPreview
                || VideoCapture1.Mode == VideoCaptureMode.ScreenCapture)
            {
                // from screen
                ScreenCaptureSourceSettings settings;
                SelectScreenCaptureSource(out settings);
                VideoCapture1.Screen_Capture_Source = settings;
            }
            else if (VideoCapture1.Mode == VideoCaptureMode.IPPreview
                     || VideoCapture1.Mode == VideoCaptureMode.IPCapture)
            {
                IPCameraSourceSettings settings;
                SelectIPCameraSource(out settings);
                VideoCapture1.IP_Camera_Source = settings;

                VideoView1.StatusOverlay = new TextStatusOverlay();
            }
            else if (VideoCapture1.Mode == VideoCaptureMode.BDAPreview
                     || VideoCapture1.Mode == VideoCaptureMode.BDACapture)
            {
                VideoCapture1.BDA_Source = new BDASourceSettings
                {
                    ReceiverName = cbBDAReceiver.Text,
                    SourceType = (BDAType)cbBDADeviceStandard.SelectedIndex,
                    SourceName = cbBDASourceDevice.Text
                };

                if (VideoCapture1.BDA_Source.SourceType == BDAType.DVBT)
                {
                    BDATuningParameters bdaTuningParameters = new BDATuningParameters
                    {
                        Frequency = Convert.ToInt32(edDVBTFrequency.Text),
                        ONID = Convert.ToInt32(edDVBTONID.Text),
                        SID = Convert.ToInt32(edDVBTSID.Text),
                        TSID = Convert.ToInt32(edDVBTTSID.Text)
                    };

                    VideoCapture1.BDA_SetParameters(bdaTuningParameters);
                }
            }
            else if ((VideoCapture1.Mode == VideoCaptureMode.CustomCapture) || (VideoCapture1.Mode == VideoCaptureMode.CustomPreview))
            {
                VideoCapture1.Custom_Source = new CustomSourceSettings();

                if (cbCustomVideoSourceCategory.SelectedIndex == 0)
                {
                    VideoCapture1.Custom_Source.VideoFilterCategory = FilterCategoryX.VideoCaptureSource;
                }
                else
                {
                    VideoCapture1.Custom_Source.VideoFilterCategory = FilterCategoryX.DirectShowFilters;
                }

                VideoCapture1.Custom_Source.VideoFilterName = cbCustomVideoSourceFilter.Text;
                VideoCapture1.Custom_Source.VideoFilterFormat = cbCustomVideoSourceFormat.Text;
                VideoCapture1.Custom_Source.VideoFilenameOrURL = edCustomVideoSourceURL.Text;

                if (string.IsNullOrEmpty(cbCustomVideoSourceFrameRate.Text))
                {
                    VideoCapture1.Custom_Source.VideoFilterFrameRate = VideoFrameRate.Empty;
                }
                else
                {
                    VideoCapture1.Custom_Source.VideoFilterFrameRate = new VideoFrameRate(Convert.ToDouble(cbCustomVideoSourceFrameRate.Text));
                }

                if (cbCustomAudioSourceCategory.SelectedIndex == 0)
                {
                    VideoCapture1.Custom_Source.AudioFilterCategory = FilterCategoryX.AudioCaptureSource;
                }
                else
                {
                    VideoCapture1.Custom_Source.AudioFilterCategory = FilterCategoryX.DirectShowFilters;
                }

                VideoCapture1.Custom_Source.AudioFilterName = cbCustomAudioSourceFilter.Text;
                VideoCapture1.Custom_Source.AudioFilterFormat = cbCustomAudioSourceFormat.Text;
                VideoCapture1.Custom_Source.AudioFilenameOrURL = edCustomAudioSourceURL.Text;
            }
            else if ((VideoCapture1.Mode == VideoCaptureMode.DecklinkSourceCapture) || (VideoCapture1.Mode == VideoCaptureMode.DecklinkSourcePreview))
            {
                VideoCapture1.Decklink_Source = new DecklinkSourceSettings
                {
                    Name = cbDecklinkCaptureDevice.Text,
                    VideoFormat = cbDecklinkCaptureVideoFormat.Text
                };
            }
            else
            {
                VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.Text);
                VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.Text;
                VideoCapture1.Video_CaptureDevice.Format_UseBest = cbUseBestVideoInputFormat.IsChecked == true;

                try
                {
                    if (!string.IsNullOrEmpty(cbVideoInputFrameRate.Text))
                    {
                        VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
                    }
                }
                catch
                {
                    VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(25);
                }

                VideoCapture1.Video_CaptureDevice.UseClosedCaptions = cbUseClosedCaptions.IsChecked == true;
            }

            bool captureMode = this.VideoCapture1.Mode == VideoCaptureMode.AudioCapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.BDACapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.CustomCapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.IPCapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.ScreenCapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.DecklinkSourceCapture
                               || this.VideoCapture1.Mode == VideoCaptureMode.VideoCapture;

            if (captureMode)
            {
                VideoCapture1.Output_Filename = edOutput.Text;
            }

            VideoCapture1.Audio_RecordAudio = cbRecordAudio.IsChecked == true;
            VideoCapture1.Audio_PlayAudio = cbPlayAudio.IsChecked == true;

            if (captureMode)
            {
                VideoCaptureOutputFormat outputFormat = VideoCaptureOutputFormat.AVI;
                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            outputFormat = VideoCaptureOutputFormat.AVI;

                            var aviOutput = new AVIOutput();
                            SetAVIOutput(ref aviOutput);
                            VideoCapture1.Output_Format = aviOutput;

                            break;
                        }
                    case 1:
                        {
                            outputFormat = VideoCaptureOutputFormat.MKVv1;

                            var mkvOutput = new MKVv1Output();
                            SetMKVOutput(ref mkvOutput);
                            VideoCapture1.Output_Format = mkvOutput;

                            break;
                        }
                    case 2:
                        {
                            outputFormat = VideoCaptureOutputFormat.WMV;

                            var wmvOutput = new WMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            VideoCapture1.Output_Format = wmvOutput;

                            break;
                        }

                    case 3:
                        {
                            outputFormat = VideoCaptureOutputFormat.DV;

                            var dvOutput = new DVOutput();
                            SetDVOutput(ref dvOutput);
                            VideoCapture1.Output_Format = dvOutput;

                            break;
                        }
                    case 4:
                        {
                            outputFormat = VideoCaptureOutputFormat.PCM_ACM;

                            var acmOutput = new ACMOutput();
                            SetACMOutput(ref acmOutput);
                            VideoCapture1.Output_Format = acmOutput;

                            break;
                        }
                    case 5:
                        {
                            outputFormat = VideoCaptureOutputFormat.MP3;

                            var mp3Output = new MP3Output();
                            SetMP3Output(ref mp3Output);
                            VideoCapture1.Output_Format = mp3Output;

                            break;
                        }
                    case 6:
                        {
                            outputFormat = VideoCaptureOutputFormat.M4A;

                            var m4aOutput = new M4AOutput();
                            SetM4AOutput(ref m4aOutput);
                            VideoCapture1.Output_Format = m4aOutput;

                            break;
                        }
                    case 7:
                        {
                            outputFormat = VideoCaptureOutputFormat.WMA;

                            var wmaOutput = new WMAOutput();
                            SetWMAOutput(ref wmaOutput);
                            VideoCapture1.Output_Format = wmaOutput;

                            break;
                        }

                    case 8:
                        {
                            outputFormat = VideoCaptureOutputFormat.FLAC;

                            var flacOutput = new FLACOutput();
                            SetFLACOutput(ref flacOutput);
                            VideoCapture1.Output_Format = flacOutput;

                            break;
                        }
                    case 9:
                        {
                            outputFormat = VideoCaptureOutputFormat.OggVorbis;

                            var oggVorbisOutput = new OGGVorbisOutput();
                            SetOGGOutput(ref oggVorbisOutput);
                            VideoCapture1.Output_Format = oggVorbisOutput;

                            break;
                        }
                    case 10:
                        {
                            outputFormat = VideoCaptureOutputFormat.Speex;

                            var speexOutput = new SpeexOutput();
                            SetSpeexOutput(ref speexOutput);
                            VideoCapture1.Output_Format = speexOutput;

                            break;
                        }
                    case 11:
                        {
                            outputFormat = VideoCaptureOutputFormat.Custom;

                            var customOutput = new CustomOutput();
                            SetCustomOutput(ref customOutput);
                            VideoCapture1.Output_Format = customOutput;

                            break;
                        }
                    case 12:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureDV;
                            VideoCapture1.Output_Format = new DirectCaptureDVOutput();

                            break;
                        }
                    case 13:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureAVI;
                            VideoCapture1.Output_Format = new DirectCaptureAVIOutput();

                            break;
                        }
                    case 14:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureMPEG;
                            VideoCapture1.Output_Format = new DirectCaptureMPEGOutput();

                            break;
                        }
                    case 15:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureMKV;
                            VideoCapture1.Output_Format = new DirectCaptureMKVOutput();

                            break;
                        }
                    case 16:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureMP4_GDCL;

                            var directCaptureOutputGDCL = new DirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputGDCL);
                            directCaptureOutputGDCL.Muxer = DirectCaptureMP4Muxer.GDCL;
                            VideoCapture1.Output_Format = directCaptureOutputGDCL;

                            break;
                        }
                    case 17:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureMP4_Monogram;

                            var directCaptureOutputMG = new DirectCaptureMP4Output();
                            SetDirectCaptureCustomOutput(ref directCaptureOutputMG);
                            directCaptureOutputMG.Muxer = DirectCaptureMP4Muxer.Monogram;
                            VideoCapture1.Output_Format = directCaptureOutputMG;

                            break;
                        }
                    case 18:
                        {
                            outputFormat = VideoCaptureOutputFormat.DirectCaptureCustom;

                            var directCaptureOutput = new DirectCaptureCustomOutput();
                            SetDirectCaptureCustomOutput(ref directCaptureOutput);
                            VideoCapture1.Output_Format = directCaptureOutput;

                            break;
                        }
                    case 19:
                        {
                            outputFormat = VideoCaptureOutputFormat.WebM;

                            var webmOutput = new WebMOutput();
                            SetWebMOutput(ref webmOutput);
                            VideoCapture1.Output_Format = webmOutput;

                            break;
                        }
                    case 20:
                        {
                            outputFormat = VideoCaptureOutputFormat.FFMPEG;

                            var ffmpegOutput = new FFMPEGOutput();
                            SetFFMPEGOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 21:
                        {
                            outputFormat = VideoCaptureOutputFormat.FFMPEG_EXE;

                            var ffmpegOutput = new FFMPEGEXEOutput();
                            SetFFMPEGEXEOutput(ref ffmpegOutput);
                            VideoCapture1.Output_Format = ffmpegOutput;

                            break;
                        }
                    case 22:
                        {
                            outputFormat = VideoCaptureOutputFormat.MP4;
                            break;
                        }
                    case 23:
                        {
                            outputFormat = VideoCaptureOutputFormat.MP4_HW;

                            var mp4Output = new MP4HWOutput();
                            SetMP4HWOutput(ref mp4Output);
                            VideoCapture1.Output_Format = mp4Output;

                            break;
                        }
                    case 24:
                        {
                            outputFormat = VideoCaptureOutputFormat.AnimatedGIF;
                            var gifOutput = new AnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);
                            VideoCapture1.Output_Format = gifOutput;
                            break;
                        }
                    case 25:
                        outputFormat = VideoCaptureOutputFormat.Encrypted;
                        break;
                    case 26:
                        {
                            var tsOutput = new MPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            VideoCapture1.Output_Format = tsOutput;

                            break;
                        }
                    case 27:
                        {
                            var movOutput = new MOVOutput();
                            SetMOVOutput(ref movOutput);
                            VideoCapture1.Output_Format = movOutput;

                            break;
                        }
                }

                if (outputFormat == VideoCaptureOutputFormat.DirectCaptureMPEG)
                {
                    if (cbMPEGEncoder.SelectedIndex != -1)
                    {
                        VideoCapture1.Video_CaptureDevice.InternalMPEGEncoder_Name = cbMPEGEncoder.Text;
                    }
                }
                else if ((outputFormat == VideoCaptureOutputFormat.MP4)
                         || ((outputFormat == VideoCaptureOutputFormat.Encrypted)
                             && (rbEncryptedH264SW.IsChecked == true))
                         || (VideoCapture1.Network_Streaming_Enabled
                             && (VideoCapture1.Network_Streaming_Format == NetworkStreamingFormat.RTSP_H264_AAC_SW)))
                {
                    var mp4Output = new MP4Output();
                    SetMP4Output(ref mp4Output);

                    if (outputFormat == VideoCaptureOutputFormat.Encrypted)
                    {
                        mp4Output.Encryption = true;
                        mp4Output.Encryption_Format = EncryptionFormat.MP4_H264_SW_AAC;

                        if (rbEncryptionKeyString.IsChecked == true)
                        {
                            mp4Output.Encryption_KeyType = EncryptionKeyType.String;
                            mp4Output.Encryption_Key = edEncryptionKeyString.Text;
                        }
                        else if (rbEncryptionKeyFile.IsChecked == true)
                        {
                            mp4Output.Encryption_KeyType = EncryptionKeyType.File;
                            mp4Output.Encryption_Key = edEncryptionKeyFile.Text;
                        }
                        else
                        {
                            mp4Output.Encryption_KeyType = EncryptionKeyType.Binary;
                            mp4Output.Encryption_Key = VideoCapture1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
                        }

                        if (rbEncryptionModeAES128.IsChecked == true)
                        {
                            mp4Output.Encryption_Mode = EncryptionMode.V8_AES128;
                        }
                        else
                        {
                            mp4Output.Encryption_Mode = EncryptionMode.V9_AES256;
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
                
            }

            // Virtual camera output
            VideoCapture1.Virtual_Camera_Output_Enabled = cbVirtualCamera.IsChecked == true;

            // Decklink output
            if (cbDecklinkOutput.IsChecked == true)
            {
                VideoCapture1.Decklink_Output = new DecklinkOutputSettings
                {
                    VideoRendererName = cbDecklinkOutputVideoRenderer.Text,
                    AudioRendererName = cbDecklinkOutputAudioRenderer.Text,
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
            VideoCapture1.Barcode_Reader_Type = (BarcodeType)cbBarcodeType.SelectedIndex;

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

            if (rbWPF.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;
            }
            else if (rbDirect2D.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D;
            }
            else
            {
                VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            }

            if (cbStretch.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            VideoView1.Background = pnVideoRendererBGColor.Fill;

            VideoCapture1.Video_ResizeOrCrop_Enabled = false;

            if (cbResize.IsChecked == true)
            {
                VideoCapture1.Video_ResizeOrCrop_Enabled = true;

                var resizeSettings = new VideoResizeSettings
                {
                    Width = Convert.ToInt32(edResizeWidth.Text),
                    Height = Convert.ToInt32(edResizeHeight.Text),
                    LetterBox = cbResizeLetterbox.IsChecked == true
                };

                switch (cbResizeMode.SelectedIndex)
                {
                    case 0:
                        resizeSettings.Mode = VideoResizeMode.NearestNeighbor;
                        break;
                    case 1:
                        resizeSettings.Mode = VideoResizeMode.Bilinear;
                        break;
                    case 2:
                        resizeSettings.Mode = VideoResizeMode.Bicubic;
                        break;
                    case 3:
                        resizeSettings.Mode = VideoResizeMode.Lancroz;
                        break;
                }

                VideoCapture1.Video_Resize = resizeSettings;
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
                    VideoCapture1.Video_Rotation = RotateMode.RotateNone;
                    break;
                case 1:
                    VideoCapture1.Video_Rotation = RotateMode.Rotate90;
                    break;
                case 2:
                    VideoCapture1.Video_Rotation = RotateMode.Rotate180;
                    break;
                case 3:
                    VideoCapture1.Video_Rotation = RotateMode.Rotate270;
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
                VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Full;
            }
            else if (rbDVResHalf.IsChecked == true)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Half;
            }
            else if (rbDVResQuarter.IsChecked == true)
            {
                VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.Quarter;
            }
            else
            {
                VideoCapture1.DV_Decoder_Video_Resolution = DVVideoResolution.DC;
            }

            // motion detection
            ConfigureMotionDetection();

            // Audio enhancement
            VideoCapture1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.IsChecked == true;
            if (VideoCapture1.Audio_Enhancer_Enabled)
            {
                await VideoCapture1.Audio_Enhancer_NormalizeAsync(cbAudioNormalize.IsChecked == true);
                await VideoCapture1.Audio_Enhancer_AutoGainAsync(cbAudioAutoGain.IsChecked == true);

                await ApplyAudioInputGainsAsync();
                await ApplyAudioOutputGainsAsync();

                await VideoCapture1.Audio_Enhancer_TimeshiftAsync((int)tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.IsChecked == true)
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
            VideoCapture1.Audio_Effects_Enabled = cbAudioEffectsEnabled.IsChecked == true;
            if (VideoCapture1.Audio_Effects_Enabled)
            {
                AddAudioEffects();
            }

            // PIP
            VideoCapture1.PIP_Mode = (PIPMode)cbPIPMode.SelectedIndex;
            VideoCapture1.PIP_ResizeQuality = (PIPResizeQuality)cbPIPResizeMode.SelectedIndex;

            if (VideoCapture1.PIP_Mode == PIPMode.ChromaKey)
            {
                var chromaKey = new PIPChromaKeySettings
                {
                    Color = VideoView.ColorConv(((SolidColorBrush)pnPIPChromaKeyColor.Fill).Color),
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
                    VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.Normal;
                    VideoCapture1.SeparateCapture_AutostartCapture = false;
                }
                else if (rbSeparateCaptureSplitByDuration.IsChecked == true)
                {
                    VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.SplitByDuration;
                    VideoCapture1.SeparateCapture_AutostartCapture = true;
                    VideoCapture1.SeparateCapture_TimeThreshold = TimeSpan.FromMilliseconds(Convert.ToInt32(edSeparateCaptureDuration.Text));
                }
                else if (rbSeparateCaptureSplitBySize.IsChecked == true)
                {
                    VideoCapture1.SeparateCapture_Mode = SeparateCaptureMode.SplitByFileSize;
                    VideoCapture1.SeparateCapture_AutostartCapture = true;
                    VideoCapture1.SeparateCapture_FileSizeThreshold = Convert.ToInt32(edSeparateCaptureFileSize.Text) * 1024 * 1024;
                }
            }

            // Output tags
            if (cbTagEnabled.IsChecked == true)
            {
                var tags = new MediaFileTags
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

        /// <summary>
        /// Configure motion detection ex.
        /// </summary>
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

        /// <summary>
        /// Configure chroma key.
        /// </summary>
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
                    MessageBox.Show(this, "Chroma-key background file doesn't exists.");
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

        /// <summary>
        /// Configure video effects.
        /// </summary>
        private void ConfigureVideoEffects()
        {
            VideoCapture1.Video_Effects_Enabled = cbEffects.IsChecked == true;
            VideoCapture1.Video_Effects_MergeImageLogos = cbMergeImageLogos.IsChecked == true;
            VideoCapture1.Video_Effects_MergeTextLogos = cbMergeTextLogos.IsChecked == true;
            VideoCapture1.Video_Effects_Clear();

            // Deinterlace
            if (cbDeinterlace.IsChecked == true && VideoCapture1.Mode != VideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VideoCaptureMode.ScreenPreview)
            {
                if (rbDeintBlendEnabled.IsChecked == true)
                {
                    IVideoEffectDeinterlaceBlend blend;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceBlend");
                    if (effect == null)
                    {
                        blend = new VideoEffectDeinterlaceBlend(true);
                        VideoCapture1.Video_Effects_Add(blend);
                    }
                    else
                    {
                        blend = effect as IVideoEffectDeinterlaceBlend;
                    }

                    if (blend == null)
                    {
                        MessageBox.Show(this, "Unable to configure deinterlace blend effect.");
                        return;
                    }

                    blend.Threshold1 = Convert.ToInt32(edDeintBlendThreshold1.Text);
                    blend.Threshold2 = Convert.ToInt32(edDeintBlendThreshold2.Text);
                    blend.Constants1 = Convert.ToInt32(edDeintBlendConstants1.Text) / 10.0;
                    blend.Constants2 = Convert.ToInt32(edDeintBlendConstants2.Text) / 10.0;
                }
                else if (rbDeintCAVTEnabled.IsChecked == true)
                {
                    IVideoEffectDeinterlaceCAVT cavt;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.IsChecked == true, Convert.ToInt32(edDeintCAVTThreshold.Text));
                        VideoCapture1.Video_Effects_Add(cavt);
                    }
                    else
                    {
                        cavt = effect as IVideoEffectDeinterlaceCAVT;
                    }

                    if (cavt == null)
                    {
                        MessageBox.Show(this, "Unable to configure deinterlace CAVT effect.");
                        return;
                    }

                    cavt.Threshold = Convert.ToInt32(edDeintCAVTThreshold.Text);
                }
                else
                {
                    IVideoEffectDeinterlaceTriangle triangle;
                    var effect = VideoCapture1.Video_Effects_Get("DeinterlaceTriangle");
                    if (effect == null)
                    {
                        triangle = new VideoEffectDeinterlaceTriangle(true, Convert.ToByte(edDeintTriangleWeight.Text));
                        VideoCapture1.Video_Effects_Add(triangle);
                    }
                    else
                    {
                        triangle = effect as IVideoEffectDeinterlaceTriangle;
                    }

                    if (triangle == null)
                    {
                        MessageBox.Show(this, "Unable to configure deinterlace triangle effect.");
                        return;
                    }

                    triangle.Weight = Convert.ToByte(edDeintTriangleWeight.Text);
                }
            }

            // Denoise
            if (cbDenoise.IsChecked == true && VideoCapture1.Mode != VideoCaptureMode.ScreenCapture
                && VideoCapture1.Mode != VideoCaptureMode.ScreenPreview)
            {
                if (rbDenoiseCAST.IsChecked == true)
                {
                    IVideoEffectDenoiseCAST cast;
                    var effect = VideoCapture1.Video_Effects_Get("DenoiseCAST");
                    if (effect == null)
                    {
                        cast = new VideoEffectDenoiseCAST(true);
                        VideoCapture1.Video_Effects_Add(cast);
                    }
                    else
                    {
                        cast = effect as IVideoEffectDenoiseCAST;
                    }

                    if (cast == null)
                    {
                        MessageBox.Show(this, "Unable to configure denoise CAST effect.");
                        return;
                    }
                }
                else
                {
                    IVideoEffectDenoiseMosquito mosquito;
                    var effect = VideoCapture1.Video_Effects_Get("DenoiseMosquito");
                    if (effect == null)
                    {
                        mosquito = new VideoEffectDenoiseMosquito(true);
                        VideoCapture1.Video_Effects_Add(mosquito);
                    }
                    else
                    {
                        mosquito = effect as IVideoEffectDenoiseMosquito;
                    }

                    if (mosquito == null)
                    {
                        MessageBox.Show(this, "Unable to configure denoise mosquito effect.");
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
                cbFlipX_Checked(null, null);
            }

            if (cbFlipY.IsChecked == true)
            {
                cbFlipY_Checked(null, null);
            }

            if (cbLiveRotation.IsChecked == true)
            {
                cbLiveRotation_Checked(null, null);
            }

            if (cbScrollingText.IsChecked == true)
            {
                cbScrollingText_Checked(null, null);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Cb audio output device selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbAudioOutputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_OutputDevice = e.AddedItems[0].ToString();
        }

        /// <summary>
        /// Cb crossbar input selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbCrossbarInput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCrossbarInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                string relatedInput;
                string relatedOutput;
                VideoCapture1.Video_CaptureDevice_CrossBar_GetRelated(e.AddedItems[0].ToString(), cbCrossbarOutput.SelectedValue.ToString(), out relatedInput, out relatedOutput);
            }
        }

        /// <summary>
        /// Cb crossbar output selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Cb tv tuner selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVTuner_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbTVTuner.Items.Count > 0) && (cbTVTuner.SelectedIndex != -1) && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_Name = e.AddedItems[0].ToString();
                await VideoCapture1.TVTuner_ReadAsync();

                cbTVMode.Items.Clear();
                foreach (string tunerMode in VideoCapture1.TVTuner_Modes())
                {
                    cbTVMode.Items.Add(tunerMode);
                }

                edVideoFreq.Text = Convert.ToString(VideoCapture1.TVTuner_VideoFrequency());
                edAudioFreq.Text = Convert.ToString(VideoCapture1.TVTuner_AudioFrequency());
                cbTVInput.SelectedIndex = cbTVInput.Items.IndexOf(VideoCapture1.TVTuner_InputType);
                cbTVMode.SelectedIndex = cbTVMode.Items.IndexOf(VideoCapture1.TVTuner_Mode.ToString());
                cbTVSystem.SelectedIndex = cbTVSystem.Items.IndexOf(VideoCapture1.TVTuner_TVFormat);
                cbTVCountry.SelectedIndex = cbTVCountry.Items.IndexOf(VideoCapture1.TVTuner_Country);
            }
        }

        /// <summary>
        /// Cb video input format selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbVideoInputFormat_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
            {
                return;
            }

            if (cbVideoInputDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInputDevice.SelectedValue.ToString());
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

        /// <summary>
        /// Handles the cb greyscale checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectGrayscale grayscale;
            var effect = VideoCapture1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_Add(grayscale);
            }
            else
            {
                grayscale = effect as IVideoEffectGrayscale;
                if (grayscale != null)
                {
                    grayscale.Enabled = cbGreyscale.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Handles the bt save screenshot click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog(this) == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Bmp, 0);
                        break;
                    case ".jpg":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Jpeg, 85);
                        break;
                    case ".gif":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Gif, 0);
                        break;
                    case ".png":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Png, 0);
                        break;
                    case ".tiff":
                        await VideoCapture1.Frame_SaveAsync(filename, ImageFormat.Tiff, 0);
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the cb invert checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectInvert invert;
            var effect = VideoCapture1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.IsChecked == true);
                VideoCapture1.Video_Effects_Add(invert);
            }
            else
            {
                invert = effect as IVideoEffectInvert;
                if (invert != null)
                {
                    invert.Enabled = cbInvert.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Handles the tb adj contrast scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAdjContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Contrast, new VideoCaptureDeviceAdjustValue((int)tbAdjContrast.Value, cbAdjContrastAuto.IsChecked == true));

            if (lbAdjContrastCurrent != null)
            {
                lbAdjContrastCurrent.Content = "Current: " + Convert.ToString((int)tbAdjContrast.Value);
            }
        }

        /// <summary>
        /// Handles the tb adj hue scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAdjHue_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Hue, new VideoCaptureDeviceAdjustValue((int)tbAdjHue.Value, cbAdjHueAuto.IsChecked == true));

            if (lbAdjHueCurrent != null)
            {
                lbAdjHueCurrent.Content = "Current: " + Convert.ToString((int)tbAdjHue.Value);
            }
        }

        /// <summary>
        /// Handles the tb adj saturation scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAdjSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(VideoHardwareAdjustment.Saturation, new VideoCaptureDeviceAdjustValue((int)tbAdjSaturation.Value, cbAdjSaturationAuto.IsChecked == true));

            if (lbAdjSaturationCurrent != null)
            {
                lbAdjSaturationCurrent.Content = "Current: " + Convert.ToString((int)tbAdjSaturation.Value);
            }
        }

        /// <summary>
        /// Handles the bt video capture device settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.SelectedValue.ToString());
        }

        /// <summary>
        /// Handles the bt audio input device settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.SelectedValue.ToString());
        }

        /// <summary>
        /// Handles the bt connect click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVFF_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.FastForward);
        }

        /// <summary>
        /// Handles the bt dv pause click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.Pause);
        }

        /// <summary>
        /// Handles the bt dv rewind click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVRewind_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.Rew);
        }

        /// <summary>
        /// Handles the bt dv play click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVPlay_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.Play);
        }

        /// <summary>
        /// Handles the bt dv step click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVStepFWD_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.StepFw);
        }

        /// <summary>
        /// Handles the bt dv step rev click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVStepRev_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.StepRev);
        }

        /// <summary>
        /// Handles the bt dv stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btDVStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.DV_SendCommandAsync(DVCommand.Stop);
        }

        /// <summary>
        /// Handles the bt refresh clients click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt start tune click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStartTune_Click(object sender, RoutedEventArgs e)
        {
            const int KHz = 1000;
            const int MHz = 1000000;

            await VideoCapture1.TVTuner_ReadAsync();
            cbTVChannel.Items.Clear();

            if ((cbTVMode.SelectedIndex != -1) && (cbTVMode.Text == "FM Radio"))
            {
                VideoCapture1.TVTuner_FM_Tuning_StartFrequency = 100 * MHz;
                VideoCapture1.TVTuner_FM_Tuning_StopFrequency = 110 * MHz;
                VideoCapture1.TVTuner_FM_Tuning_Step = 100 * KHz;
            }

            await VideoCapture1.TVTuner_TuneChannels_StartAsync();
        }

        /// <summary>
        /// Handles the bt stop tune click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStopTune_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.TVTuner_TuneChannels_StopAsync();
        }

        /// <summary>
        /// Handles the bt use this channel click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btUseThisChannel_Click(object sender, RoutedEventArgs e)
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

            await VideoCapture1.TVTuner_ApplyAsync();
            await VideoCapture1.TVTuner_ReadAsync();
            edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency().ToString(CultureInfo.InvariantCulture);
            edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency().ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Cb tv country selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVCountry_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVCountry.SelectedIndex != -1)
            {
                VideoCapture1.TVTuner_Country = cbTVCountry.SelectedValue.ToString();
                edTVDefaultFormat.Text = VideoCapture1.TVTuner_Countries_GetPreferredFormatForCountry(VideoCapture1.TVTuner_Country);

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                if (VideoCapture1.State() == PlaybackState.Play)
                {
                    await VideoCapture1.TVTuner_ApplyAsync();
                    await VideoCapture1.TVTuner_ReadAsync();
                }
            }
        }

        /// <summary>
        /// Cb tv mode selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVMode_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVMode.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                TVTunerMode mode;
                Enum.TryParse(e.AddedItems[0].ToString(), true, out mode);
                VideoCapture1.TVTuner_Mode = mode;

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                await VideoCapture1.TVTuner_ApplyAsync();
                await VideoCapture1.TVTuner_ReadAsync();
                cbTVChannel.Items.Clear();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency().ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency().ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Cb tv channel selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVChannel_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
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

                await VideoCapture1.TVTuner_ApplyAsync();
                await VideoCapture1.TVTuner_ReadAsync();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency().ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency().ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Cb tv input selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVInput_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVInput.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_InputType = e.AddedItems[0].ToString();

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                await VideoCapture1.TVTuner_ApplyAsync();
                await VideoCapture1.TVTuner_ReadAsync();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency().ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency().ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Cb tv system selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbTVSystem_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTVSystem.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                VideoCapture1.TVTuner_TVFormat = VideoCapture1.TVTuner_TVFormat_FromString(e.AddedItems[0].ToString());

                if (string.IsNullOrEmpty(VideoCapture1.TVTuner_Name))
                {
                    return;
                }

                await VideoCapture1.TVTuner_ApplyAsync();
                await VideoCapture1.TVTuner_ReadAsync();
                edVideoFreq.Text = VideoCapture1.TVTuner_VideoFrequency().ToString(CultureInfo.InvariantCulture);
                edAudioFreq.Text = VideoCapture1.TVTuner_AudioFrequency().ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Handles the cb use best audio input format checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbUseBestAudioInputFormat_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAudioInputFormat.IsEnabled = cbUseBestAudioInputFormat.IsChecked != true;
        }

        /// <summary>
        /// Handles the cb use best video input format checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbUseBestVideoInputFormat_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbVideoInputFormat.IsEnabled = cbUseBestVideoInputFormat.IsChecked != true;
        }

        /// <summary>
        /// Handles the tb audio volume scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioVolume_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_OutputDevice_Volume_Set((int)tbAudioVolume.Value);
        }

        /// <summary>
        /// Handles the tb audio balance scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudioBalance_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_OutputDevice_Balance_Set((int)tbAudioBalance.Value);
        }

        /// <summary>
        /// Handles the bt select wmv profile network click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectWMVProfileNetwork_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the bt mpeg encoder show dialog click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMPEGEncoderShowDialog_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_CaptureDevice_InternalMPEGEncoder_ShowDialog(IntPtr.Zero, cbMPEGEncoder.Text);
        }

        /// <summary>
        /// Cb filters selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbFilters_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                string name = e.AddedItems[0].ToString();
                btFilterSettings.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                    FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Handles the bt filter add click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                VideoCapture1.Video_Filters_Add(new CustomProcessingFilter(cbFilters.Text));
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

        /// <summary>
        /// Handles the bt filter settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterSettings_Click(object sender, RoutedEventArgs e)
        {
            string name = cbFilters.Text;

            if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Handles the bt filter settings 2 click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterSettings2_Click(object sender, RoutedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.SelectedValue.ToString();

                if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
                }
                else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
                }
            }
        }

        /// <summary>
        /// Handles the bt filter delete all click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            lbFilters.Items.Clear();
            VideoCapture1.Video_Filters_Clear();
        }

        /// <summary>
        /// Cb pip device selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbPIPDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbPIPDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbPIPFormat.Items.Clear();

                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
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

        /// <summary>
        /// Cb mpeg video decoder selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbMPEGVideoDecoder_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMPEGVideoDecoder.SelectedIndex < 1 || e == null || e.AddedItems.Count == 0)
            {
                btMPEGVidDecSetting.IsEnabled = false;
            }
            else
            {
                string name = e.AddedItems[0].ToString();
                btMPEGVidDecSetting.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                  FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Cb mpeg audio decoder selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbMPEGAudioDecoder_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbMPEGAudioDecoder.SelectedIndex < 1 || e == null || e.AddedItems.Count == 0)
            {
                btMPEGAudDecSettings.IsEnabled = false;
            }
            else
            {
                string name = e.AddedItems[0].ToString();
                btMPEGAudDecSettings.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                  FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Handles the bt mpeg vid dec setting click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMPEGVidDecSetting_Click(object sender, RoutedEventArgs e)
        {
            if (cbMPEGVideoDecoder.SelectedIndex > 0)
            {
                string name = cbMPEGVideoDecoder.Text;

                if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
                }
                else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
                }
            }
        }

        /// <summary>
        /// Handles the bt mpeg aud dec settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMPEGAudDecSettings_Click(object sender, RoutedEventArgs e)
        {
            if (cbMPEGAudioDecoder.SelectedIndex > 0)
            {
                string name = cbMPEGAudioDecoder.Text;

                if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
                }
                else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
                {
                    FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
                }
            }
        }

        /// <summary>
        /// Handles the bt screen capture update click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btScreenCaptureUpdate_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.Screen_Capture_UpdateParametersAsync(
                Convert.ToInt32(edScreenLeft.Text),
                Convert.ToInt32(edScreenTop.Text),
                cbScreenCapture_GrabMouseCursor.IsChecked == true,
                cbScreenCapture_HighlightMouseCursor.IsChecked == true);
        }

        /// <summary>
        /// Cb pip format use best checked changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbPIPFormatUseBest_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbPIPFormat.IsEnabled = cbPIPFormatUseBest.IsChecked != true;
        }

        /// <summary>
        /// Handles the bt pip update click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
                MessageBox.Show(this, "Select device!");
            }
        }

        /// <summary>
        /// Handles the bt pip add device click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
                    new VideoFrameRate(Convert.ToDouble(frameRate)),
                    input,
                    Convert.ToInt32(edPIPVidCapLeft.Text),
                    Convert.ToInt32(edPIPVidCapTop.Text),
                    Convert.ToInt32(edPIPVidCapWidth.Text),
                    Convert.ToInt32(edPIPVidCapHeight.Text));

                cbPIPDevices.Items.Add(cbPIPDevice.Text);
            }
        }

        /// <summary>
        /// Configure motion detection.
        /// </summary>
        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.IsChecked == true)
            {
                VideoCapture1.Motion_Detection = new MotionDetectionSettings
                {
                    Enabled = true,
                    Compare_Red = cbCompareRed.IsChecked == true,
                    Compare_Green = cbCompareGreen.IsChecked == true,
                    Compare_Blue = cbCompareBlue.IsChecked == true,
                    Compare_Greyscale = cbCompareGreyscale.IsChecked == true,
                    Highlight_Color = (MotionCHLColor)cbMotDetHLColor.SelectedIndex,
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

        /// <summary>
        /// Handles the bt mot det update settings click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMotDetUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetection();
        }

        /// <summary>
        /// Video capture 1 on motion.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MotionDetectionEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            Dispatcher?.Invoke((Action)(() =>
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
            }));
        }

        /// <summary>
        /// Handles the bt aud eq refresh click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudEqRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbAudEq0.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0);
            tbAudEq1.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1);
            tbAudEq2.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2);
            tbAudEq3.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3);
            tbAudEq4.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4);
            tbAudEq5.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5);
            tbAudEq6.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6);
            tbAudEq7.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7);
            tbAudEq8.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8);
            tbAudEq9.Value = VideoCapture1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9);
        }

        /// <summary>
        /// Handles the bt signal click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSignal_Click(object sender, RoutedEventArgs e)
        {
            if (await VideoCapture1.Video_CaptureDevice_SignalPresentAsync())
            {
                MessageBox.Show(this, "Signal present");
            }
            else
            {
                MessageBox.Show(this, "Signal not present");
            }
        }

        /// <summary>
        /// Handles the cb aud amplify enabled checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the cb aud dynamic amplify enabled checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudDynamicAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the cb aud equalizer enabled checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudEqualizerEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true);
        }

        /// <summary>
        /// Cb aud equalizer preset selected index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e == null || e.AddedItems.Count == 0)
            {
                return;
            }

            VideoCapture1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        /// <summary>
        /// Handles the cb aud sound 3 d enabled checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudSound3DEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the cb aud true bass enabled checked changed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudTrueBassEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the tb adj brightness scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAdjBrightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            await VideoCapture1.Video_CaptureDevice_VideoAdjust_SetValueAsync(
                VideoHardwareAdjustment.Brightness,
                new VideoCaptureDeviceAdjustValue(
                    (int)tbAdjBrightness.Value,
                    cbAdjBrightnessAuto.IsChecked == true));

            if (lbAdjBrightnessCurrent != null)
            {
                lbAdjBrightnessCurrent.Content = "Current: " + Convert.ToString((int)tbAdjBrightness.Value);
            }
        }

        /// <summary>
        /// Handles the tb aud 3 d sound scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAud3DSound_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, (ushort)tbAud3DSound.Value);
        }

        /// <summary>
        /// Handles the tb aud dyn amp scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudDynAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e) //-V3013
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Handles the tb aud attack scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudAttack_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 0 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq0_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, (sbyte)tbAudEq0.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 1 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq1_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, (sbyte)tbAudEq1.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 2 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq2_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, (sbyte)tbAudEq2.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 3 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq3_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, (sbyte)tbAudEq3.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 4 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq4_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, (sbyte)tbAudEq4.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 5 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq5_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, (sbyte)tbAudEq5.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 6 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq6_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, (sbyte)tbAudEq6.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 7 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq7_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, (sbyte)tbAudEq7.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 8 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq8_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, (sbyte)tbAudEq8.Value);
        }

        /// <summary>
        /// Handles the tb aud eq 9 scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq9_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, (sbyte)tbAudEq9.Value);
        }

        /// <summary>
        /// Handles the tb aud true bass scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudTrueBass_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, false, (ushort)tbAudTrueBass.Value);
        }

        /// <summary>
        /// Handles the tb contrast scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectContrast contrast;
            var effect = VideoCapture1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
                VideoCapture1.Video_Effects_Add(contrast);
            }
            else
            {
                contrast = effect as IVideoEffectContrast;
                if (contrast != null)
                {
                    contrast.Value = (int)tbContrast.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb darkness scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectDarkness darkness;
            var effect = VideoCapture1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
                VideoCapture1.Video_Effects_Add(darkness);
            }
            else
            {
                darkness = effect as IVideoEffectDarkness;
                if (darkness != null)
                {
                    darkness.Value = (int)tbDarkness.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb lightness scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectLightness lightness;
            var effect = VideoCapture1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
                VideoCapture1.Video_Effects_Add(lightness);
            }
            else
            {
                lightness = effect as IVideoEffectLightness;
                if (lightness != null)
                {
                    lightness.Value = (int)tbLightness.Value;
                }
            }
        }

        /// <summary>
        /// Handles the tb saturation scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                IVideoEffectSaturation saturation;
                var effect = VideoCapture1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VideoEffectSaturation((int)tbSaturation.Value);
                    VideoCapture1.Video_Effects_Add(saturation);
                }
                else
                {
                    saturation = effect as IVideoEffectSaturation;
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
        //        case (int)DVCommand.DV_PLAY: VideoCapture1.Resume(); break;
        //        case (int)DVCommand.DV_PAUSE: VideoCapture1.Pause(); break;
        //        case (int)DVCommand.DV_STOP: VideoCapture1.Stop(); break;
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

        /// <summary>
        /// Handles the tb aud amplify amp scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudAmplifyAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, (int)tbAudAmplifyAmp.Value * 10, false);
        }

        /// <summary>
        /// Handles the tb aud release scroll event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudRelease_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoCapture1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (ushort)tbAudAttack.Value, (ushort)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Link label 1 link clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void linkLabel1_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Do events.
        /// </summary>
        private static void DoEvents()
        {
            Application.Current.Dispatcher?.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }

        /// <summary>
        /// Video capture 1 on tv tuner tune channels.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TVTunerTuneChannelsEventArgs"/> instance containing the event data.</param>
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
                    MessageBox.Show(this, "AutoTune complete");
                }

                DoEvents();
            }));
        }

        /// <summary>
        /// Lb filters selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void lbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.SelectedValue.ToString();
                btFilterSettings2.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                                            FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Cb stretch checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbStretch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbStretch.IsChecked == true)
            {
                VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoCapture1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        private delegate void AFMotionDelegate(float level);

        /// <summary>
        /// Af motion delegate method.
        /// </summary>
        /// <param name="level">The level.</param>
        private void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        /// <summary>
        /// Video capture 1 on object detection.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MotionDetectionExEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnObjectDetection(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        /// <summary>
        /// Cb af motion detection checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAFMotionDetection_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetectionEx();
        }

        /// <summary>
        /// Handles the bt separate capture start click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSeparateCaptureStart_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_StartAsync(edOutput.Text);
        }

        /// <summary>
        /// Handles the bt separate capture stop click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSeparateCaptureStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_StopAsync();
        }

        /// <summary>
        /// Handles the bt separate capture change filename click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSeparateCaptureChangeFilename_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_ChangeFilenameOnTheFlyAsync(edNewFilename.Text);
        }

        /// <summary>
        /// Handles the bt pip add ip camera click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt pip add screen capture click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt pip devices clear click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btPIPDevicesClear_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.PIP_Sources_Clear();
            cbPIPDevices.Items.Clear();
        }

        /// <summary>
        /// Handles the bt pip set output size click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btPIPSetOutputSize_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.PIP_CustomOutputSize_Set(Convert.ToInt32(edPIPOutputWidth.Text), Convert.ToInt32(edPIPOutputHeight.Text));
        }

        /// <summary>
        /// Handles the bt pip set click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPIPSet_Click(object sender, RoutedEventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                await VideoCapture1.PIP_Sources_SetTransparencySettingsAsync(cbPIPDevices.SelectedIndex, tbPIPTransparency.Value / 255);
            }
            else
            {
                MessageBox.Show(this, "Select PIP device!");
            }
        }

        /// <summary>
        /// Handles the bt separate capture pause click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSeparateCapturePause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_PauseAsync();
        }

        /// <summary>
        /// Handles the bt separate capture resume click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSeparateCaptureResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.SeparateCapture_ResumeAsync();
        }

        /// <summary>
        /// Handles the bt dvbt tune click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btDVBTTune_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1.BDA_Source != null && VideoCapture1.BDA_Source.SourceType == BDAType.DVBT)
            {
                BDATuningParameters bdaTuningParameters = new BDATuningParameters
                {
                    Frequency = Convert.ToInt32(edDVBTFrequency.Text),
                    ONID = Convert.ToInt32(edDVBTONID.Text),
                    SID = Convert.ToInt32(edDVBTSID.Text),
                    TSID = Convert.ToInt32(edDVBTTSID.Text)
                };

                VideoCapture1.BDA_SetParameters(bdaTuningParameters);
            }
        }

        /// <summary>
        /// Cb zoom enabled checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbZoomEnabled_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectZoom zoomEffect;
            var effect = VideoCapture1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoomEnabled.IsChecked == true);
                VideoCapture1.Video_Effects_Add(zoomEffect);
            }
            else
            {
                zoomEffect = effect as IVideoEffectZoom;
            }

            if (zoomEffect == null)
            {
                MessageBox.Show(this, "Unable to configure zoom effect.");
                return;
            }

            zoomEffect.ZoomX = zoom;
            zoomEffect.ZoomY = zoom;
            zoomEffect.ShiftX = zoomShiftX;
            zoomEffect.ShiftY = zoomShiftY;
            zoomEffect.Enabled = cbZoomEnabled.IsChecked == true;
        }

        /// <summary>
        /// Handles the bt eff zoom in click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomIn_Click(object sender, RoutedEventArgs e)
        {
            zoom += 0.1;
            zoom = Math.Min(zoom, 5);

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the bt eff zoom out click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomOut_Click(object sender, RoutedEventArgs e)
        {
            zoom -= 0.1;
            zoom = Math.Max(zoom, 1);

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the bt eff zoom shift up click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY += 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the bt eff zoom shift down click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the bt eff zoom shift right click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX += 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the bt eff zoom shift left click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Cb pan checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbPan_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectPan pan;
            var effect = VideoCapture1.Video_Effects_Get("Pan");
            if (effect == null)
            {
                pan = new VideoEffectPan(true);
                VideoCapture1.Video_Effects_Add(pan);
            }
            else
            {
                pan = effect as IVideoEffectPan;
            }

            if (pan == null)
            {
                MessageBox.Show(this, "Unable to configure pan effect.");
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

        /// <summary>
        /// Handles the bt barcode reset click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btBarcodeReset_Click(object sender, RoutedEventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoCapture1.Barcode_Reader_Enabled = true;
        }

        #region Barcode detector

        private delegate void BarcodeDelegate(BarcodeEventArgs value);

        /// <summary>
        /// Barcode delegate method.
        /// </summary>
        /// <param name="value">The value.</param>
        private void BarcodeDelegateMethod(BarcodeEventArgs value)
        {
            edBarcode.Text = value.Value;
            edBarcodeMetadata.Text = string.Empty;
            foreach (var o in value.Metadata)
            {
                edBarcodeMetadata.Text += o.Key + ": " + o.Value + Environment.NewLine;
            }
        }

        /// <summary>
        /// Video capture 1 on barcode detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="BarcodeEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            Dispatcher?.BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        /// <summary>
        /// Handles the bt add additional audio source click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAddAdditionalAudioSource_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Additional_Audio_CaptureDevice_Add(cbAdditionalAudioSource.Text);
            MessageBox.Show(cbAdditionalAudioSource.Text + " added");
        }

        /// <summary>
        /// Handles the bt pip add file source click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the button click 1 event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edPIPFileSoureFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Cb fade in out checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbFadeInOut_Checked(object sender, RoutedEventArgs e)
        {
            if (rbFadeIn.IsChecked == true)
            {
                IVideoEffectFadeIn fadeIn;
                var effect = VideoCapture1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VideoEffectFadeIn(cbFadeInOut.IsChecked == true);
                    VideoCapture1.Video_Effects_Add(fadeIn);
                }
                else
                {
                    fadeIn = effect as IVideoEffectFadeIn;
                }

                if (fadeIn == null)
                {
                    MessageBox.Show(this, "Unable to configure fade-in effect.");
                    return;
                }

                fadeIn.Enabled = cbFadeInOut.IsChecked == true;
                fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
            else
            {
                IVideoEffectFadeOut fadeOut;
                var effect = VideoCapture1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VideoEffectFadeOut(cbFadeInOut.IsChecked == true);
                    VideoCapture1.Video_Effects_Add(fadeOut);
                }
                else
                {
                    fadeOut = effect as IVideoEffectFadeOut;
                }

                if (fadeOut == null)
                {
                    MessageBox.Show(this, "Unable to configure fade-out effect.");
                    return;
                }

                fadeOut.Enabled = cbFadeInOut.IsChecked == true;
                fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStartTime.Text));
                fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edFadeInOutStopTime.Text));
            }
        }

        /// <summary>
        /// Label 1291 mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void label1291_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Label mouse down 1.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Video capture 1 on face detected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AFFaceDetectionEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnFaceDetected(object sender, AFFaceDetectionEventArgs e)
        {
            Dispatcher?.BeginInvoke(new FaceDelegate(FaceDelegateMethod), e);
        }

        private delegate void FaceDelegate(AFFaceDetectionEventArgs e);

        /// <summary>
        /// Face delegate method.
        /// </summary>
        /// <param name="e">The <see cref="AFFaceDetectionEventArgs"/> instance containing the event data.</param>
        private void FaceDelegateMethod(AFFaceDetectionEventArgs e)
        {
            edFaceTrackingFaces.Text = string.Empty;

            foreach (var faceRectangle in e.FaceRectangles)
            {
                edFaceTrackingFaces.Text += "(" + faceRectangle.Left + ", " + faceRectangle.Top + "), ("
                                            + faceRectangle.Width + ", " + faceRectangle.Height + ")" + Environment.NewLine;
            }
        }

        /// <summary>
        /// Label 1291 copy mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt full screen click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

                controlMargin = VideoView1.Margin;
                controlWidth = VideoView1.Width;
                controlHeight = VideoView1.Height;

                // resizing window
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                Topmost = true;

                var dpi = VisualTreeHelper.GetDpi(this);

                Left = 0;
                Top = 0;
                Width = Screen.AllScreens[0].Bounds.Width / dpi.DpiScaleX;
                Height = Screen.AllScreens[0].Bounds.Height / dpi.DpiScaleY;
                Margin = new Thickness(0);

                // resizing control
                VideoView1.Margin = new Thickness(0, 0, 0, 0);
                VideoView1.Width = Screen.AllScreens[0].Bounds.Width / dpi.DpiScaleX;
                VideoView1.Height = Screen.AllScreens[0].Bounds.Height / dpi.DpiScaleY;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoView1.Margin = controlMargin;
                VideoView1.Width = controlWidth;
                VideoView1.Height = controlHeight;

                VideoView1.Width = controlWidth;
                VideoView1.Height = controlHeight;
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

        /// <summary>
        /// Video view 1 mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void VideoView1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        #region VU meter Pro

        private delegate void AudioVUMeterProMaximumCalculatedDelegate(VUMeterMaxSampleEventArgs e);

        /// <summary>
        /// Audio vu meter pro maximum calculatedelegate method.
        /// </summary>
        /// <param name="e">The <see cref="VUMeterMaxSampleEventArgs"/> instance containing the event data.</param>
        private void AudioVUMeterProMaximumCalculatedelegateMethod(VUMeterMaxSampleEventArgs e)
        {
            waveformPainter.AddValue(e.MaxSample, e.MinSample);
        }

        /// <summary>
        /// Video capture 1 on audio vu meter pro maximum calculated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VUMeterMaxSampleEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnAudioVUMeterProMaximumCalculated(object sender, VUMeterMaxSampleEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProMaximumCalculatedDelegate(AudioVUMeterProMaximumCalculatedelegateMethod), e);
        }

        private delegate void AudioVUMeterProFFTCalculatedDelegate(VUMeterFFTEventArgs e);

        /// <summary>
        /// Audio vu meter pro fft calculated delegate method.
        /// </summary>
        /// <param name="e">The <see cref="VUMeterFFTEventArgs"/> instance containing the event data.</param>
        private void AudioVUMeterProFFTCalculatedDelegateMethod(VUMeterFFTEventArgs e)
        {
            spectrumAnalyzer.Update(e.Result);
        }

        /// <summary>
        /// Video capture 1 on audio vu meter pro fft calculated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="VUMeterFFTEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnAudioVUMeterProFFTCalculated(object sender, VUMeterFFTEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProFFTCalculatedDelegate(AudioVUMeterProFFTCalculatedDelegateMethod), e);
        }

        private delegate void AudioVUMeterProVolumeDelegate(AudioLevelEventArgs e);

        /// <summary>
        /// Audio vu meter pro volume delegate method.
        /// </summary>
        /// <param name="e">The <see cref="AudioLevelEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Video capture 1 on audio vu meter pro volume.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AudioLevelEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnAudioVUMeterProVolume(object sender, AudioLevelEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AudioVUMeterProVolumeDelegate(AudioVUMeterProVolumeDelegateMethod), e);
        }

        /// <summary>
        /// Tb vu meter amplification value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbVUMeterAmplification_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.Audio_VUMeter_Pro_Volume = (int)tbVUMeterAmplification.Value;
            }
        }

        /// <summary>
        /// Tb vu meter boost value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbVUMeterBoost_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            volumeMeter1.Boost = (float)tbVUMeterBoost.Value / 10.0F;
            volumeMeter2.Boost = (float)tbVUMeterBoost.Value / 10.0F;
        }

        #endregion

        /// <summary>
        /// Cb live rotation checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbLiveRotation_Checked(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 != null)
            {
                IVideoEffectRotate rotate;
                var effect = VideoCapture1.Video_Effects_Get("Rotate");
                if (effect == null)
                {
                    rotate = new VideoEffectRotate(
                        cbLiveRotation.IsChecked == true,
                        tbLiveRotationAngle.Value,
                        cbLiveRotationStretch.IsChecked == true);
                    VideoCapture1.Video_Effects_Add(rotate);
                }
                else
                {
                    rotate = effect as IVideoEffectRotate;
                }

                if (rotate == null)
                {
                    MessageBox.Show(this, "Unable to configure rotate effect.");
                    return;
                }

                rotate.Enabled = cbLiveRotation.IsChecked == true;
                rotate.Angle = tbLiveRotationAngle.Value;
                rotate.Stretch = cbLiveRotationStretch.IsChecked == true;
            }
        }

        /// <summary>
        /// Tb live rotation angle value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbLiveRotationAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            cbLiveRotation_Checked(sender, e);
        }

        /// <summary>
        /// Cb live rotation stretch checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbLiveRotationStretch_Checked(object sender, RoutedEventArgs e)
        {
            cbLiveRotation_Checked(sender, e);
        }

        /// <summary>
        /// Cb screen flip vertical checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbScreenFlipVertical_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Cb screen flip horizontal checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbScreenFlipHorizontal_Checked(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Cb direct 2 d rotate selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbDirect2DRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                VideoCapture1.Video_Renderer.RotationAngle = Convert.ToInt32(name);
                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Handles the bt zoom shift up click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the bt zoom shift right click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the bt zoom shift left click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftX = VideoCapture1.Video_Renderer.Zoom_ShiftX - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the bt zoom shift down click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_ShiftY = VideoCapture1.Video_Renderer.Zoom_ShiftY - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the bt zoom out click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio - 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the bt zoom in click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            VideoCapture1.Video_Renderer.Zoom_Ratio = VideoCapture1.Video_Renderer.Zoom_Ratio + 10;
            await VideoCapture1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Pn video renderer bg color mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private async void pnVideoRendererBGColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnVideoRendererBGColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                VideoView1.Background = pnVideoRendererBGColor.Fill;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Rb checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Cb custom video source category selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbCustomVideoSourceCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VideoCapture1 == null || cbCustomVideoSourceFilter == null)
            {
                return;
            }

            if (cbCustomVideoSourceCategory.SelectedIndex == 0)
            {
                var filters = VideoCapture1.Video_CaptureDevices();
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
                var filters = VideoCapture1.DirectShow_Filters();
                cbCustomVideoSourceFilter.ItemsSource = filters;

                if (filters.Count > 0)
                {
                    cbCustomVideoSourceFilter.SelectedIndex = 0;
                    cbCustomVideoSourceFilter_SelectionChanged(null, null);
                }
            }
        }

        /// <summary>
        /// Cb custom audio source category selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbCustomAudioSourceCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VideoCapture1 == null || cbCustomAudioSourceFilter == null)
            {
                return;
            }

            cbCustomAudioSourceFilter.Items.Clear();
            cbCustomAudioSourceFilter.Items.Add(string.Empty);

            if (cbCustomAudioSourceCategory.SelectedIndex == 0)
            {
                var filters = VideoCapture1.Audio_CaptureDevices();
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
                var filters = VideoCapture1.DirectShow_Filters();
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

        /// <summary>
        /// Cb custom video source filter selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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
                    FilterCategoryX.VideoCaptureSource,
                    value,
                    MediaTypeCategory.Video,
                    out formats);
            }
            else
            {
                VideoCapture1.DirectShow_Filter_GetVideoFormats(
                    FilterCategoryX.DirectShowFilters,
                    value,
                    MediaTypeCategory.Video,
                    out formats);
            }

            cbCustomVideoSourceFormat.ItemsSource = formats;
        }

        /// <summary>
        /// Cb custom audio source filter selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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
                    FilterCategoryX.AudioCaptureSource,
                    value,
                    MediaTypeCategory.Audio,
                    out formats);
            }
            else
            {
                VideoCapture1.DirectShow_Filter_GetAudioFormats(
                    FilterCategoryX.DirectShowFilters,
                    value,
                    MediaTypeCategory.Audio,
                    out formats);
            }

            foreach (var format in formats)
            {
                cbCustomAudioSourceFormat.Items.Add(format);
            }
        }

        /// <summary>
        /// Cb audio normalize checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioNormalize_Checked(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.Audio_Enhancer_NormalizeAsync(cbAudioNormalize.IsChecked == true);
        }

        /// <summary>
        /// Cb audio auto gain checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioAutoGain_Checked(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.Audio_Enhancer_AutoGainAsync(cbAudioAutoGain.IsChecked == true);
        }

        /// <summary>
        /// Apply audio input gains async.
        /// </summary>
        private async Task ApplyAudioInputGainsAsync()
        {
            AudioEnhancerGains gains = new AudioEnhancerGains
            {
                L = (float)tbAudioInputGainL.Value / 10.0f,
                C = (float)tbAudioInputGainC.Value / 10.0f,
                R = (float)tbAudioInputGainR.Value / 10.0f,
                SL = (float)tbAudioInputGainSL.Value / 10.0f,
                SR = (float)tbAudioInputGainSR.Value / 10.0f,
                LFE = (float)tbAudioInputGainLFE.Value / 10.0f
            };

            await VideoCapture1.Audio_Enhancer_InputGainsAsync(gains);
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainL.Content = (tbAudioInputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainC.Content = (tbAudioInputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainR.Content = (tbAudioInputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSL.Content = (tbAudioInputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSR.Content = (tbAudioInputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Tb audio input gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainLFE.Content = (tbAudioInputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Apply audio output gains async.
        /// </summary>
        private async Task ApplyAudioOutputGainsAsync()
        {
            AudioEnhancerGains gains = new AudioEnhancerGains
            {
                L = (float)tbAudioOutputGainL.Value / 10.0f,
                C = (float)tbAudioOutputGainC.Value / 10.0f,
                R = (float)tbAudioOutputGainR.Value / 10.0f,
                SL = (float)tbAudioOutputGainSL.Value / 10.0f,
                SR = (float)tbAudioOutputGainSR.Value / 10.0f,
                LFE = (float)tbAudioOutputGainLFE.Value / 10.0f
            };

            await VideoCapture1.Audio_Enhancer_OutputGainsAsync(gains);
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainL.Content = (tbAudioOutputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainC.Content = (tbAudioOutputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainR.Content = (tbAudioOutputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSL.Content = (tbAudioOutputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSR.Content = (tbAudioOutputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio output gain value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainLFE.Content = (tbAudioOutputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Tb audio timeshift value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioTimeshift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioTimeshift.Content = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms";

            await VideoCapture1.Audio_Enhancer_TimeshiftAsync((int)tbAudioTimeshift.Value);
        }

        /// <summary>
        /// Log.
        /// </summary>
        /// <param name="txt">The text.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private delegate void FFMPEGInfoDelegate(string message);

        /// <summary>
        /// Ffmpeg info delegate method.
        /// </summary>
        /// <param name="message">The message.</param>
        private void FFMPEGInfoDelegateMethod(string message)
        {
            mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine;
        }

        /// <summary>
        /// Video capture 1 on ffmpeg info.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FFMPEGInfoEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnFFMPEGInfo(object sender, FFMPEGInfoEventArgs e)
        {
            Dispatcher?.BeginInvoke(new FFMPEGInfoDelegate(FFMPEGInfoDelegateMethod), e.Message);
        }

        /// <summary>
        /// Handles the bt encryption open file click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEncryptionOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Img tag cover mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void imgTagCover_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (openFileDialog2.ShowDialog() == true)
            {
                imgTagCover.Source = new BitmapImage(new Uri(openFileDialog2.FileName));
                imgTagCover.Tag = openFileDialog2.FileName;
            }
        }

        /// <summary>
        /// Cb decklink capture device selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbDecklinkCaptureDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

            var deviceItem = (await VideoCapture1.Decklink_CaptureDevicesAsync()).FirstOrDefault(device => device.Name == value);
            if (deviceItem != null)
            {
                foreach (var format in (await deviceItem.GetVideoFormatsAsync()))
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

        /// <summary>
        /// Handles the bt audio channel mapper clear click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudioChannelMapperClear_Click(object sender, RoutedEventArgs e)
        {
            audioChannelMapperItems.Clear();
            lbAudioChannelMapperRoutes.Items.Clear();
        }

        /// <summary>
        /// Handles the bt audio channel mapper add new route click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
        
        /// <summary>
        /// Handles the video capture 1 on network source disconnect event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(async () =>
            {
                await VideoCapture1.StopAsync();

                MessageBox.Show(this, "Network source stopped or disconnected!");
            }));
        }

        /// <summary>
        /// Tb gpu lightness value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPULightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IGPUVideoEffectBrightness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new GPUVideoEffectBrightness(true, (int)tbGPULightness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectBrightness;
                if (intf != null)
                {
                    intf.Value = (int)tbGPULightness.Value;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Tb gpu saturation value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IGPUVideoEffectSaturation intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new GPUVideoEffectSaturation(true, (int)tbGPUSaturation.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectSaturation;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUSaturation.Value;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Tb gpu contrast value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IGPUVideoEffectContrast intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new GPUVideoEffectContrast(true, (int)tbGPUContrast.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as GPUVideoEffectContrast;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUContrast.Value;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Tb gpu darkness value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            IGPUVideoEffectDarkness intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new GPUVideoEffectDarkness(true, (int)tbGPUDarkness.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectDarkness;
                if (intf != null)
                {
                    intf.Value = (int)tbGPUDarkness.Value;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu greyscale click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUGreyscale_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectGrayscale intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new GPUVideoEffectGrayscale(cbGPUGreyscale.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectGrayscale;
                if (intf != null)
                {
                    intf.Enabled = cbGPUGreyscale.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu invert click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUInvert_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectInvert intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new GPUVideoEffectInvert(cbGPUInvert.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectInvert;
                if (intf != null)
                {
                    intf.Enabled = cbGPUInvert.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu night vision click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUNightVision_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectNightVision intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new GPUVideoEffectNightVision(cbGPUNightVision.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectNightVision;
                if (intf != null)
                {
                    intf.Enabled = cbGPUNightVision.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu pixelate click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUPixelate_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectPixelate intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new GPUVideoEffectPixelate(cbGPUPixelate.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectPixelate;
                if (intf != null)
                {
                    intf.Enabled = cbGPUPixelate.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu denoise click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUDenoise_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDenoise intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new GPUVideoEffectDenoise(cbGPUDenoise.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectDenoise;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDenoise.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu deinterlace click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUDeinterlace_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDeinterlaceBlend intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectDeinterlaceBlend;
                if (intf != null)
                {
                    intf.Enabled = cbGPUDeinterlace.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb gpu old movie click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUOldMovie_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectOldMovie intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new GPUVideoEffectOldMovie(cbGPUOldMovie.IsChecked == true);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectOldMovie;
                if (intf != null)
                {
                    intf.Enabled = cbGPUOldMovie.IsChecked == true;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the bt onvif connect click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                try
                {
                    btONVIFConnect.IsEnabled = false;
                    btONVIFConnect.Content = "Connecting";

                    if (onvifClient != null)
                    {
                        onvifClient.Dispose();
                        onvifClient = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifClient = new ONVIFClientX();
                    var result = await onvifClient.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifClient = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    lbONVIFCameraInfo.Content = $"{onvifClient.DeviceInformation?.Model}, s/n {onvifClient.DeviceInformation?.SerialNumber}";

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifClient.GetProfilesAsync();
                    if (profiles != null)
                    {
                        foreach (var profile in profiles)
                        {
                            cbONVIFProfile.Items.Add($"{profile.Name}");
                        }
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;

                        // Get the stream URI for the first profile
                        if (profiles != null && profiles.Length > 0)
                        {
                            var mediaUri = await onvifClient.GetStreamUriAsync(profiles[0]);
                            if (mediaUri != null)
                            {
                                edONVIFLiveVideoURL.Text = cbIPURL.Text = mediaUri.Uri;
                            }
                        }
                    }

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    btONVIFConnect.Content = "Disconnect";
                }
                catch
                {
                    MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                    btONVIFConnect.Content = "Connect";
                }

                btONVIFConnect.IsEnabled = true;
            }
            else
            {
                btONVIFConnect.Content = "Connect";

                if (onvifClient != null)
                {
                    onvifClient.Dispose();
                    onvifClient = null;
                }
            }
        }

        /// <summary>
        /// Handles the bt onvif right click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFRight_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(0.5f, 0, 0);
        }

        /// <summary>
        /// Handles the bt onvifptz set default click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
            _ = onvifClient?.GotoHomePositionAsync();
        }

        /// <summary>
        /// Handles the bt onvif left click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFLeft_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(-0.5f, 0, 0);
        }

        /// <summary>
        /// Handles the bt onvif up click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFUp_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(0, 0.5f, 0);
        }

        /// <summary>
        /// Handles the bt onvif down click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFDown_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(0, -0.5f, 0);
        }

        /// <summary>
        /// Handles the bt onvif zoom in click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(0, 0, 0.5f);
        }

        /// <summary>
        /// Handles the bt onvif zoom out click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (onvifClient == null)
            {
                return;
            }

            _ = onvifClient.ContinuousMoveAsync(0, 0, -0.5f);
        }

        /// <summary>
        /// Pn pip chroma key color mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void pnPIPChromaKeyColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnPIPChromaKeyColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnPIPChromaKeyColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
            }
        }

        /// <summary>
        /// Tb pip chroma key tolerance 1 value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbPIPChromaKeyTolerance1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbPIPChromaKeyTolerance1.Content = tbPIPChromaKeyTolerance1.Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Tb pip chroma key tolerance 2 value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbPIPChromaKeyTolerance2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbPIPChromaKeyTolerance2.Content = tbPIPChromaKeyTolerance2.Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Handles the bt select hls output folder click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectHLSOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edHLSOutputFolder.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Lb hls configure mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void lbHLSConfigure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.HLSStreaming);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Cb output format selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt output configure click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoCapture1);
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
                            pcmSettingsDialog = new PCMSettingsDialog(VideoCapture1);
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
                        if (customFormatSettingsDialog == null) //-V3139
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1);
                        }

                        customFormatSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 12:
                case 13:
                case 14:
                case 15:
                    {
                        MessageBox.Show(this, "No settings available for selected output format.");

                        break;
                    }
                case 16:
                case 17:
                case 18:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoCapture1);
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

        /// <summary>
        /// Update recording time.
        /// </summary>
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

        /// <summary>
        /// Handles the bt text logo add click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VideoEffectTextLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbTextLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the bt text logo edit click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt text logo remove click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtTextLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Handles the bt image logo add click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoCapture1);
            var effect = new VideoEffectImageLogo(true, name);

            VideoCapture1.Video_Effects_Add(effect);
            lbImageLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the bt image logo edit click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the bt image logo remove click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btImageLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                VideoCapture1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipDown flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipDown;
                if (flip != null)
                {
                    flip.Enabled = cbFlipX.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipRight flip;
            var effect = VideoCapture1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
                VideoCapture1.Video_Effects_Add(flip);
            }
            else
            {
                flip = effect as IVideoEffectFlipRight;
                if (flip != null)
                {
                    flip.Enabled = cbFlipY.IsChecked == true;
                }
            }
        }

        /// <summary>
        /// Handles the bt cc read values click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btCCReadValues_Click(object sender, RoutedEventArgs e)
        {
            var pan = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Pan);
            if (pan != null)
            {
                tbCCPan.Minimum = pan.Min;
                tbCCPan.Maximum = pan.Max;
                tbCCPan.SmallChange = pan.Step;
                tbCCPan.Value = pan.Default;
                lbCCPanMin.Content = "Min: " + Convert.ToString(pan.Min);
                lbCCPanMax.Content = "Max: " + Convert.ToString(pan.Max);
                lbCCPanCurrent.Content = "Current: " + Convert.ToString(pan.Default);

                cbCCPanManual.IsChecked = (pan.Flags & CameraControlFlags.Manual) == CameraControlFlags.Manual;
                cbCCPanAuto.IsChecked = (pan.Flags & CameraControlFlags.Auto) == CameraControlFlags.Auto;
                cbCCPanRelative.IsChecked = (pan.Flags & CameraControlFlags.Relative) == CameraControlFlags.Relative;
            }

            var tilt = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Tilt);
            if (tilt != null)
            {
                tbCCTilt.Minimum = tilt.Min;
                tbCCTilt.Maximum = tilt.Max;
                tbCCTilt.SmallChange = tilt.Step;
                tbCCTilt.Value = tilt.Default;
                lbCCTiltMin.Content = "Min: " + Convert.ToString(tilt.Min);
                lbCCTiltMax.Content = "Max: " + Convert.ToString(tilt.Max);
                lbCCTiltCurrent.Content = "Current: " + Convert.ToString(tilt.Default);

                cbCCTiltManual.IsChecked = (tilt.Flags & CameraControlFlags.Manual) == CameraControlFlags.Manual;
                cbCCTiltAuto.IsChecked = (tilt.Flags & CameraControlFlags.Auto) == CameraControlFlags.Auto;
                cbCCTiltRelative.IsChecked = (tilt.Flags & CameraControlFlags.Relative) == CameraControlFlags.Relative;
            }

            var focus = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Focus);
            if (focus != null)
            {
                tbCCFocus.Minimum = focus.Min;
                tbCCFocus.Maximum = focus.Max;
                tbCCFocus.SmallChange = focus.Step;
                tbCCFocus.Value = focus.Default;
                lbCCFocusMin.Content = "Min: " + Convert.ToString(focus.Min);
                lbCCFocusMax.Content = "Max: " + Convert.ToString(focus.Max);
                lbCCFocusCurrent.Content = "Current: " + Convert.ToString(focus.Default);

                cbCCFocusManual.IsChecked = (focus.Flags & CameraControlFlags.Manual) == CameraControlFlags.Manual;
                cbCCFocusAuto.IsChecked = (focus.Flags & CameraControlFlags.Auto) == CameraControlFlags.Auto;
                cbCCFocusRelative.IsChecked = (focus.Flags & CameraControlFlags.Relative) == CameraControlFlags.Relative;
            }

            var zoomx = await VideoCapture1.Video_CaptureDevice_CameraControl_GetRangeAsync(CameraControlProperty.Zoom);
            if (zoomx != null)
            {
                tbCCZoom.Minimum = zoomx.Min;
                tbCCZoom.Maximum = zoomx.Max;
                tbCCZoom.SmallChange = zoomx.Step;
                tbCCZoom.Value = zoomx.Default;
                lbCCZoomMin.Content = "Min: " + Convert.ToString(zoomx.Min);
                lbCCZoomMax.Content = "Max: " + Convert.ToString(zoomx.Max);
                lbCCZoomCurrent.Content = "Current: " + Convert.ToString(zoomx.Default);

                cbCCZoomManual.IsChecked = (zoomx.Flags & CameraControlFlags.Manual) == CameraControlFlags.Manual;
                cbCCZoomAuto.IsChecked = (zoomx.Flags & CameraControlFlags.Auto) == CameraControlFlags.Auto;
                cbCCZoomRelative.IsChecked = (zoomx.Flags & CameraControlFlags.Relative) == CameraControlFlags.Relative;
            }
        }

        /// <summary>
        /// Handles the bt cc pan apply click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtCCPanApply_Click(object sender, RoutedEventArgs e)
        {
            CameraControlFlags flags = CameraControlFlags.None;

            if (cbCCPanManual.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Manual;
            }

            if (cbCCPanAuto.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Auto;
            }

            if (cbCCPanRelative.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Pan, new VideoCaptureDeviceCameraControlValue((int)tbCCPan.Value, flags));
        }

        /// <summary>
        /// Handles the bt cc tilt apply click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtCCTiltApply_Click(object sender, RoutedEventArgs e)
        {
            CameraControlFlags flags = CameraControlFlags.None;

            if (cbCCTiltManual.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Manual;
            }

            if (cbCCTiltAuto.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Auto;
            }

            if (cbCCTiltRelative.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Tilt, new VideoCaptureDeviceCameraControlValue((int)tbCCTilt.Value, flags));
        }

        /// <summary>
        /// Handles the bt cc focus apply click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtCCFocusApply_Click(object sender, RoutedEventArgs e)
        {
            CameraControlFlags flags = CameraControlFlags.None;

            if (cbCCFocusManual.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Manual;
            }

            if (cbCCFocusAuto.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Auto;
            }

            if (cbCCFocusRelative.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Focus, new VideoCaptureDeviceCameraControlValue((int)tbCCFocus.Value, flags));
        }

        /// <summary>
        /// Handles the bt cc zoom apply click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void BtCCZoomApply_Click(object sender, RoutedEventArgs e)
        {
            CameraControlFlags flags = CameraControlFlags.None;

            if (cbCCZoomManual.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Manual;
            }

            if (cbCCZoomAuto.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Auto;
            }

            if (cbCCZoomRelative.IsChecked == true)
            {
                flags = flags | CameraControlFlags.Relative;
            }

            await VideoCapture1.Video_CaptureDevice_CameraControl_SetAsync(CameraControlProperty.Zoom, new VideoCaptureDeviceCameraControlValue((int)tbCCZoom.Value, flags));
        }

        /// <summary>
        /// Handles the bt screen source window select click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btScreenSourceWindowSelect_Click(object sender, RoutedEventArgs e)
        {
            if (windowCaptureForm == null)
            {
                windowCaptureForm = new WindowCaptureForm();
                windowCaptureForm.OnCaptureHotkey += WindowCaptureForm_OnCaptureHotkey;
            }

            windowCaptureForm.StartCapture();
        }

        /// <summary>
        /// Window capture form on capture hotkey.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="WindowCaptureEventArgs"/> instance containing the event data.</param>
        private void WindowCaptureForm_OnCaptureHotkey(object sender, WindowCaptureEventArgs e)
        {
            windowCaptureForm.StopCapture();
            windowCaptureForm.Hide();

            lbScreenSourceWindowText.Content = e.Caption;
        }

        /// <summary>
        /// Tb gpu blur value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUBlur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IGPUVideoEffectBlur intf;
            var effect = VideoCapture1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new GPUVideoEffectBlur(tbGPUBlur.Value > 0, (int)tbGPUBlur.Value);
                VideoCapture1.Video_Effects_GPU_Add(intf);
            }
            else
            {
                intf = effect as IGPUVideoEffectBlur;
                if (intf != null)
                {
                    intf.Enabled = tbGPUBlur.Value > 0;
                    intf.Value = (int)tbGPUBlur.Value;
                    intf.Update();
                }
            }
        }

        /// <summary>
        /// Handles the cb adj brightness auto click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAdjBrightnessAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjBrightness_Scroll(null, null);
        }

        /// <summary>
        /// Handles the cb adj hue auto click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAdjHueAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjHue_Scroll(null, null);
        }

        /// <summary>
        /// Handles the cb adj contrast auto click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAdjContrastAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjContrast_Scroll(null, null);
        }

        /// <summary>
        /// Handles the cb adj saturation auto click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAdjSaturationAuto_Click(object sender, RoutedEventArgs e)
        {
            tbAdjSaturation_Scroll(null, null);
        }

        /// <summary>
        /// Pn chroma key color mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void pnChromaKeyColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnChromaKeyColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                ConfigureChromaKey();
            }
        }

        /// <summary>
        /// Handles the bt chroma key select bg image click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btChromaKeySelectBGImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
                ConfigureChromaKey();
            }
        }

        /// <summary>
        /// Tb chroma key threshold sensitivity value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbChromaKeyThresholdSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ConfigureChromaKey();
        }

        /// <summary>
        /// Tb chroma key smoothing value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbChromaKeySmoothing_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ConfigureChromaKey();
        }

        /// <summary>
        /// Lb ndi vendor mouse left button down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
      private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the bt list ndi sources click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await VideoCapture1.IP_Camera_NDI_ListSourcesAsync();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the bt list onvif sources click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();
            Action<DiscoveryDevice> onDeviceDiscovered = AddONVIFSource;
            await VideoCapture1.IP_Camera_ONVIF_ListSourcesAsyncEx(onDeviceDiscovered, null, null);
        }

        /// <summary>
        /// Add onvif source.
        /// </summary>
        /// <param name="discoveryDevice">The discovery device.</param>
        private void AddONVIFSource(DiscoveryDevice discoveryDevice)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                cbIPURL.Items.Add(discoveryDevice.XAdresses.FirstOrDefault());

                if (cbIPURL.Items.Count == 1)
                {
                    cbIPURL.SelectedIndex = 0;
                }
            }));
        }

        /// <summary>
        /// Is administrator.
        /// </summary>
        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// Handles the bt virtual camera register click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btVirtualCameraRegister_Click(object sender, RoutedEventArgs e)
        {
            var virtualCameraAvailable = VideoCapture1.Virtual_Camera_Output_IsAvailable();
            if (!virtualCameraAvailable)
            {
                if (!IsAdministrator())
                {
                    MessageBox.Show("Admin rights are required to register the camera. App will restart.");
                }

                VideoCapture1.Virtual_Camera_Output_RegisterAsAdmin(allowAppRestart: true);
            }
        }

        /// <summary>
        /// Ll xiph x 86 mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void llXiphX86_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Ll xiph x 64 mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void llXiphX64_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Cb pip format selection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbPIPFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbPIPFormat.SelectedValue?.ToString()))
            {
                return;
            }

            if (cbPIPDevice.SelectedIndex != -1)
            {
                var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbPIPDevice.SelectedValue.ToString());
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

        /// <summary>
        /// Window closing.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        /// <summary>
        /// Cb scrolling text checked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbScrollingText_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectScrollingTextLogo textLogo;
            var effect = VideoCapture1.Video_Effects_Get("ScrollingTextLogo");
            if (effect == null)
            {
                textLogo = new VideoEffectScrollingTextLogo(cbScrollingText.IsChecked == true);
                VideoCapture1.Video_Effects_Add(textLogo);
            }
            else
            {
                textLogo = effect as IVideoEffectScrollingTextLogo;
                if (textLogo != null)
                {
                    textLogo.Enabled = cbScrollingText.IsChecked == true;
                    textLogo.Reset();
                }
            }
        }

        /// <summary>
        /// Handles the cb pip check zoom click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbPIPCheckZoom_Click(object sender, RoutedEventArgs e)
        {
            // check zoom
            var range = await VideoCapture1.PIP_Video_CaptureDevice_CameraControl_GetRangeAsync(cbPIPDevice.Text, CameraControlProperty.Zoom);
            if (range != null)
            {
                slPIPCameraZoom.Maximum = range.Max;
                slPIPCameraZoom.Minimum = range.Min;
                slPIPCameraZoom.Value = range.Default;
                slPIPCameraZoom.IsEnabled = true;
            }
        }

        /// <summary>
        /// Sl pip camera zoom value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void slPIPCameraZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            await VideoCapture1.PIP_Video_CaptureDevice_CameraControl_SetAsync(
                cbPIPDevice.Text, 
                CameraControlProperty.Zoom, 
                new VideoCaptureDeviceCameraControlValue((int)slPIPCameraZoom.Value, CameraControlFlags.Manual));
        }

        /// <summary>
        /// Handles the cb pip flip click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbPIPFlip_Click(object sender, RoutedEventArgs e)
        {
            if (cbPIPDevices.SelectedIndex != -1)
            {
                await VideoCapture1.PIP_Sources_SetFlipSettingsAsync(cbPIPDevices.SelectedIndex, cbPIPFlipHorizontal.IsChecked == true, cbPIPFlipVertical.IsChecked == true);
            }
            else
            {
                MessageBox.Show(this, "Select PIP device!");
            }            
        }

        /// <summary>
        /// Handles the cb virtual camera click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbVirtualCamera_Click(object sender, RoutedEventArgs e)
        {
            var virtualCameraAvailable = VideoCapture1.Virtual_Camera_Output_IsAvailable();
            if (!virtualCameraAvailable)
            {
                MessageBox.Show(this, "The virtual camera is not yet registered. Admin rights are required to register the camera to be visible in external applications. Please click the Register Camera button.");
            }
        }
    }
}

