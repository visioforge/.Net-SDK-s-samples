// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable NotAccessedVariable

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
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.MediaInfo;
    using VisioForge.Core.MediaPlayer;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.AudioEffects;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.MediaPlayer;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.Types.VideoProcessing;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.UI.WPF;
    using Color = System.Windows.Media.Color;
    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class MainWindow
    {
        private const string AUDIO_EFFECT_ID_AMPLIFY = "amplify";

        private const string AUDIO_EFFECT_ID_EQ = "eq";

        private const string AUDIO_EFFECT_ID_DYN_AMPLIFY = "dyn_amplify";

        private const string AUDIO_EFFECT_ID_SOUND_3D = "sound3d";

        private const string AUDIO_EFFECT_ID_TRUE_BASS = "true_bass";

        private MediaPlayerCore MediaPlayer1;

        private readonly List<AudioChannelMapperItem> audioChannelMapperItems = new List<AudioChannelMapperItem>();

        // Zoom
        private double zoom = 1.0;
        private int zoomShiftX;
        private int zoomShiftY;

        // ReSharper disable InconsistentNaming

        private readonly MediaInfoReader MediaInfo = new MediaInfoReader();

        //Dialogs
        private readonly FontDialog fontDialog = new FontDialog();

        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        private readonly ColorDialog colorDialog1 = new ColorDialog();

        private readonly FolderBrowserDialog folderDialog = new FolderBrowserDialog();

        //timer
        private readonly DispatcherTimer timer = new DispatcherTimer();

#pragma warning disable S3168 // "async" methods should not return "void"
        private async void timer1_Tick()
#pragma warning restore S3168 // "async" methods should not return "void"
        {
            timer.Tag = 1;
            tbTimeline.Maximum = (int)(await MediaPlayer1.Duration_TimeAsync()).TotalSeconds;

            int value = (int)(await MediaPlayer1.Position_Get_TimeAsync()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTime.Content = MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Maximum);

            timer.Tag = 0;
        }

        private void InitTimer()
        {
            // ReSharper disable ConvertToLambdaExpression
            // ReSharper disable UnusedAnonymousMethodSignature

            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick +=
                delegate (object s, EventArgs a)
                {
                    timer1_Tick();
                };

            // ReSharper restore ConvertToLambdaExpression
            // ReSharper restore UnusedAnonymousMethodSignature
        }

        private static System.Drawing.Color ColorConv(Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private static Color ColorConv(System.Drawing.Color color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();
        }

        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            VideoView1.MouseDown += MediaPlayer1_MouseDown;
            MediaPlayer1.OnBarcodeDetected += MediaPlayer1_OnBarcodeDetected;
            MediaPlayer1.OnAudioVUMeterProVolume += MediaPlayer1_OnAudioVUMeterProVolume;
            MediaPlayer1.OnStop += MediaPlayer1_OnStop;
            MediaPlayer1.OnMIDIFileInfo += MediaPlayer1_OnMIDIFileInfo;
            MediaPlayer1.OnMotion += MediaPlayer1_OnMotion;
            MediaPlayer1.OnMotionDetectionEx += MediaPlayer1_OnMotionDetectionEx;
            MediaPlayer1.OnAudioVUMeterProFFTCalculated += MediaPlayer1_OnAudioVUMeterProFFTCalculated;
            MediaPlayer1.OnAudioVUMeterProMaximumCalculated += MediaPlayer1_OnAudioVUMeterProMaximumCalculated;

        }

        private void MediaPlayer1_OnMotionDetectionEx(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                pbAFMotionLevel.Value = Math.Min(100, e.Level * 100);
            }));
        }

        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                VideoView1.MouseDown -= MediaPlayer1_MouseDown;
                MediaPlayer1.OnBarcodeDetected -= MediaPlayer1_OnBarcodeDetected;
                MediaPlayer1.OnAudioVUMeterProVolume -= MediaPlayer1_OnAudioVUMeterProVolume;
                MediaPlayer1.OnStop -= MediaPlayer1_OnStop;
                MediaPlayer1.OnMIDIFileInfo -= MediaPlayer1_OnMIDIFileInfo;
                MediaPlayer1.OnMotion -= MediaPlayer1_OnMotion;
                MediaPlayer1.OnAudioVUMeterProFFTCalculated -= MediaPlayer1_OnAudioVUMeterProFFTCalculated;
                MediaPlayer1.OnAudioVUMeterProMaximumCalculated -= MediaPlayer1_OnAudioVUMeterProMaximumCalculated;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaPlayer1.SDK_Version()})";

            // font for text logo
            fontDialog.Color = System.Drawing.Color.White;
            fontDialog.Font = new Font(System.Drawing.FontFamily.GenericSansSerif, 32);

            // set combobox indexes
            cbSourceMode.SelectedIndex = 0;
            cbImageType.SelectedIndex = 1;
            cbMotDetHLColor.SelectedIndex = 1;
            cbBarcodeType.SelectedIndex = 0;
            cbDirect2DRotate.SelectedIndex = 0;

            rbMotionDetectionExProcessor.SelectedIndex = 1;
            rbMotionDetectionExDetector.SelectedIndex = 1;

            pnChromaKeyColor.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 218, 128));

            string defaultAudioRenderer = string.Empty;
            foreach (string audioOutputDevice in MediaPlayer1.Audio_OutputDevices())
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

            foreach (string directShowFilter in MediaPlayer1.DirectShow_Filters())
            {
                cbFilters.Items.Add(directShowFilter);
            }

            if (cbFilters.Items.Count > 0)
            {
                cbFilters.SelectedIndex = 0;
            }

            foreach (string filter in MediaPlayer1.DirectShow_Filters())
            {
                cbCustomAudioDecoder.Items.Add(filter);
                cbCustomVideoDecoder.Items.Add(filter);
                cbCustomSplitter.Items.Add(filter);
            }

            // ReSharper disable once CoVariantArrayConversion
            foreach (var item in MediaPlayer1.Audio_Effects_Equalizer_Presets())
            {
                cbAudEqualizerPreset.Items.Add(item);
            }

            cbAudEqualizerPreset.SelectedIndex = 0;

            edScreenshotsFolder.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            InitTimer();
        }

        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectLightness lightness;
            var effect = MediaPlayer1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
                MediaPlayer1.Video_Effects_Add(lightness);
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

        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 != null)
            {
                IVideoEffectSaturation saturation;
                var effect = MediaPlayer1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VideoEffectSaturation((int)tbSaturation.Value);
                    MediaPlayer1.Video_Effects_Add(saturation);
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

        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectDarkness darkness;
            var effect = MediaPlayer1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
                MediaPlayer1.Video_Effects_Add(darkness);
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

        private void cbGreyscale_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectGrayscale grayscale;
            var effect = MediaPlayer1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
                MediaPlayer1.Video_Effects_Add(grayscale);
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

        private void cbInvert_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectInvert invert;
            var effect = MediaPlayer1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.IsChecked == true);
                MediaPlayer1.Video_Effects_Add(invert);
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

        private void btSelectScreenshotsFolder_Click(object sender, RoutedEventArgs e)
        {
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edScreenshotsFolder.Text = folderDialog.SelectedPath;
            }
        }

        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            string s = dt.Hour + "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;

            int customWidth = 0;
            int customHeight = 0;

            if (cbScreenshotResize.IsChecked == true)
            {
                customWidth = Convert.ToInt32(edScreenshotWidth.Text);
                customHeight = Convert.ToInt32(edScreenshotHeight.Text);
            }

            switch (cbImageType.SelectedIndex)
            {
                case 0:
                    await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s + ".bmp"), ImageFormat.Bmp, 0, customWidth, customHeight);
                    break;
                case 1:
                    await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s + ".jpg"), ImageFormat.Jpeg, (int)tbJPEGQuality.Value, customWidth, customHeight);
                    break;
                case 2:
                    await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s + ".gif"), ImageFormat.Gif, 0, customWidth, customHeight);
                    break;
                case 3:
                    await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s + ".png"), ImageFormat.Png, 0, customWidth, customHeight);
                    break;
                case 4:
                    await MediaPlayer1.Frame_SaveAsync(Path.Combine(edScreenshotsFolder.Text, s + ".tiff"), ImageFormat.Tiff, 0, customWidth, customHeight);
                    break;
            }
        }

        private void tbBalance1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream1.IsChecked == true || MediaPlayer1.Audio_Streams_AllInOne())
            {
                MediaPlayer1.Audio_OutputDevice_Balance_Set(0, (int)tbBalance1.Value);
            }
        }

        private void tbBalance2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream2.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Balance_Set(1, (int)tbBalance2.Value);
            }
        }

        private void tbBalance3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream3.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Balance_Set(2, (int)tbBalance3.Value);
            }
        }

        private void tbBalance4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream4.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Balance_Set(3, (int)tbBalance4.Value);
            }
        }

        private async void tbSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

                await MediaPlayer1.SetSpeedAsync(tbSpeed.Value / 10.0);
        }

        private void tbVolume1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            if (cbAudioStream1.IsChecked == true || MediaPlayer1.Audio_Streams_AllInOne())
            {
                MediaPlayer1.Audio_OutputDevice_Volume_Set(0, (int)tbVolume1.Value);
            }
        }

        private void tbVolume2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream2.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Volume_Set(1, (int)tbVolume2.Value);
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Convert.ToInt32(timer.Tag) == 0)
            {
                await MediaPlayer1.Position_Set_TimeAsync(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }

        private void tbVolume3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream3.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Volume_Set(2, (int)tbVolume3.Value);
            }
        }

        private void tbVolume4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cbAudioStream4.IsChecked == true)
            {
                MediaPlayer1.Audio_OutputDevice_Volume_Set(3, (int)tbVolume4.Value);
            }
        }

        private void btReadInfo_Click(object sender, RoutedEventArgs e)
        {
            mmInfo.Clear();

            // clear audio controls
            cbAudioStream1.IsEnabled = false;
            cbAudioStream2.IsEnabled = false;
            cbAudioStream3.IsEnabled = false;
            cbAudioStream4.IsEnabled = false;
            tbVolume1.IsEnabled = false;
            tbVolume2.IsEnabled = false;
            tbVolume3.IsEnabled = false;
            tbVolume4.IsEnabled = false;
            tbBalance1.IsEnabled = false;
            tbBalance2.IsEnabled = false;
            tbBalance3.IsEnabled = false;
            tbBalance4.IsEnabled = false;

            MediaInfo.Filename = edFilenameOrURL.Text;

            SetSourceMode();

            if ((MediaPlayer1.Source_Mode == MediaPlayerSourceMode.File_DS) ||
                (MediaPlayer1.Source_Mode == MediaPlayerSourceMode.FFMPEG) ||
                (MediaPlayer1.Source_Mode == MediaPlayerSourceMode.LAV) ||
                (MediaPlayer1.Source_Mode == MediaPlayerSourceMode.Encrypted_File_DS))
            {
                // "Read info" button
                if (sender != null)
                {
                    FilePlaybackError ErrorCode;
                    string ErrorText;
                    // ReSharper disable once AccessToStaticMemberViaDerivedType
                    if (MediaInfoReader.IsFilePlayable(edFilenameOrURL.Text, out ErrorCode, out ErrorText))
                    {
                        mmInfo.Text += "This file is playable" + Environment.NewLine;
                    }
                    else
                    {
                        mmInfo.Text += "This file is not playable" + Environment.NewLine;
                    }
                }

                EncryptionKeyType keyType;
                object key;
                if (rbEncryptionKeyString.IsChecked == true)
                {
                    keyType = EncryptionKeyType.String;
                    key = edEncryptionKeyString.Text;
                }
                else if (rbEncryptionKeyFile.IsChecked == true)
                {
                    keyType = EncryptionKeyType.File;
                    key = edEncryptionKeyFile.Text;
                }
                else
                {
                    keyType = EncryptionKeyType.Binary;
                    key = MediaPlayer1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
                }

                MediaInfo.ReadFileInfo(MediaPlayer1.Source_Mode == MediaPlayerSourceMode.Encrypted_File_DS, key, keyType, cbUseLibMediaInfo.IsChecked == true);

                for (int i = 0; i < MediaInfo.VideoStreams.Count; i++)
                {
                    var stream = MediaInfo.VideoStreams[i];

                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Video #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + stream.Codec + Environment.NewLine;
                    mmInfo.Text += "Duration: " + stream.Duration.ToString() + Environment.NewLine;
                    mmInfo.Text += "Width: " + stream.Width + Environment.NewLine;
                    mmInfo.Text += "Height: " + stream.Height + Environment.NewLine;
                    mmInfo.Text += "FOURCC: " + stream.FourCC + Environment.NewLine;
                    mmInfo.Text += "Aspect Ratio: " + $"{stream.AspectRatio.Item1}:{stream.AspectRatio.Item2}" + Environment.NewLine;
                    mmInfo.Text += "Frame rate: " + stream.FrameRate + Environment.NewLine;
                    mmInfo.Text += "Bitrate: " + stream.Bitrate + Environment.NewLine;
                    mmInfo.Text += "Frames count: " + stream.FramesCount + Environment.NewLine;
                }

                for (int i = 0; i < MediaInfo.AudioStreams.Count; i++)
                {
                    var stream = MediaInfo.AudioStreams[i];

                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Audio #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + stream.Codec + Environment.NewLine;
                    mmInfo.Text += "Codec info: " + stream.CodecInfo + Environment.NewLine;
                    mmInfo.Text += "Duration: " + stream.Duration.ToString() + Environment.NewLine;
                    mmInfo.Text += "Bitrate: " + stream.Bitrate + Environment.NewLine;
                    mmInfo.Text += "Channels: " + stream.Channels + Environment.NewLine;
                    mmInfo.Text += "Sample rate: " + stream.SampleRate + Environment.NewLine;
                    mmInfo.Text += "BPS: " + stream.BPS + Environment.NewLine;
                    mmInfo.Text += "Language: " + stream.Language + Environment.NewLine;
                }

                for (int i = 0; i < MediaInfo.Subtitles.Count; i++)
                {
                    var stream = MediaInfo.Subtitles[i];

                    mmInfo.Text += string.Empty + Environment.NewLine;
                    mmInfo.Text += "Text #" + Convert.ToString(i + 1) + Environment.NewLine;
                    mmInfo.Text += "Codec: " + stream.Codec + Environment.NewLine;
                    mmInfo.Text += "Name: " + stream.Name + Environment.NewLine;
                    mmInfo.Text += "Language: " + stream.Language + Environment.NewLine;
                }

                // timeline
                if (MediaInfo.VideoStreams.Count > 0)
                {
                    tbTimeline.Maximum = (int)(MediaInfo.VideoStreams[0].Duration.TotalSeconds);
                }
                else if (MediaInfo.AudioStreams.Count > 0)
                {
                    tbTimeline.Maximum = (int)(MediaInfo.AudioStreams[0].Duration.TotalSeconds);
                }

                // set audio streams tab
                int count = MediaInfo.AudioStreams.Count;
                bool one_output = MediaInfo.Audio_Streams_AllInOne;

                cbAudioStream1.IsEnabled = true;
                cbAudioStream1.IsChecked = true;
                tbVolume1.IsEnabled = true;
                tbBalance1.IsEnabled = true;

                if (count == 0)
                {
                    return;
                }

                if (count > 1)
                {
                    cbAudioStream2.IsEnabled = true;
                    cbAudioStream2.IsChecked = false;
                    tbVolume2.IsEnabled = !one_output;
                    tbBalance2.IsEnabled = !one_output;
                }

                if (count > 2)
                {
                    cbAudioStream3.IsEnabled = true;
                    cbAudioStream3.IsChecked = false;
                    tbVolume3.IsEnabled = !one_output;
                    tbBalance3.IsEnabled = !one_output;
                }

                if (count > 3)
                {
                    cbAudioStream4.IsEnabled = true;
                    cbAudioStream4.IsChecked = false;
                    tbVolume4.IsEnabled = !one_output;
                    tbBalance4.IsEnabled = !one_output;
                }

                // additional audio streams added from other audio files
                int count2 = MediaPlayer1.Audio_AdditionalStreams_GetCount();

                if (count2 == 0)
                {
                    return;
                }

                int count3 = count2;

                if (count2 + count >= 4)
                {
                    cbAudioStream4.IsEnabled = true;
                    cbAudioStream4.IsChecked = true;
                    tbVolume4.IsEnabled = true;
                    tbBalance4.IsEnabled = true;
                    count3 = count3 - 1;
                }

                if ((count2 + count >= 3) && (count3 > 0))
                {
                    cbAudioStream3.IsEnabled = true;
                    cbAudioStream3.IsChecked = true;
                    tbVolume3.IsEnabled = true;
                    tbBalance3.IsEnabled = true;
                    count3 = count3 - 1;
                }

                if ((count2 + count >= 2) && (count3 > 0))
                {
                    cbAudioStream2.IsEnabled = true;
                    cbAudioStream2.IsChecked = true;
                    tbVolume2.IsEnabled = true;
                    tbBalance2.IsEnabled = true;
                    count3 = count3 - 1;
                }

                if ((count2 + count >= 1) && (count3 > 0))
                {
                    cbAudioStream1.IsEnabled = true;
                    cbAudioStream1.IsChecked = true;
                    tbVolume1.IsEnabled = true;
                    tbBalance1.IsEnabled = true;
                }
            }     
            else
            {
                cbAudioStream1.IsEnabled = true;
                cbAudioStream1.IsChecked = true;
                tbVolume1.IsEnabled = true;
                tbBalance1.IsEnabled = true;
            }
        }

        private FileStream memoryFileStream;

        private void LoadToMemory()
        {
            if (memoryFileStream != null)
            {
                memoryFileStream.Dispose();
                memoryFileStream = null;
            }

            memoryFileStream = new FileStream(edFilenameOrURL.Text, FileMode.Open);
            ManagedIStream stream = new ManagedIStream(memoryFileStream);

            // specifing settings
            MediaPlayer1.Source_MemoryStream = new MemoryStreamSource(stream, memoryFileStream.Length);
        }

        private void SetSourceMode()
        {
            switch (cbSourceMode.SelectedIndex)
            {
                case 0:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;
                    break;
                case 1:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.GPU;

                    if (rbGPUIntel.IsChecked == true)
                    {
                        MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.IntelQuickSync;
                    }
                    else if (rbGPUNVidia.IsChecked == true)
                    {
                        MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.NvidiaCUVID;
                    }
                    else if (rbGPUDXVANative.IsChecked == true)
                    {
                        MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.DXVA2Native;
                    }
                    else if (rbGPUDXVACopyBack.IsChecked == true)
                    {
                        MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.DXVA2CopyBack;
                    }
                    else if (rbGPUDirect3D.IsChecked == true)
                    {
                        MediaPlayer1.Source_GPU_Mode = LAVGPUDecoder.Direct3D11;
                    }

                    break;
                case 2:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.FFMPEG;
                    break;
                case 3:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_DS;
                    break;
                case 4:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.File_VLC;
                    break;
                case 5:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.BluRay;
                    break;
                case 6:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Memory_DS;
                    LoadToMemory();
                    break;
                case 7:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.MMS_WMV_DS;
                    break;
                case 8:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.HTTP_RTSP_VLC;
                    break;
                case 9:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.Encrypted_File_DS;
                    break;
                case 10:
                    MediaPlayer1.Source_Mode = MediaPlayerSourceMode.MIDI;
                    break;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Debug_Telemetry = cbTelemetry.IsChecked == true;
            MediaPlayer1.Debug_Mode = cbDebugMode.IsChecked == true;

            MediaPlayer1.Playlist_Reset();

            zoom = 1.0;
            zoomShiftX = 0;
            zoomShiftY = 0;

            mmLog.Clear();

            MediaPlayer1.Info_UseLibMediaInfo = cbUseLibMediaInfo.IsChecked == true;

            if (rbVideoDecoderDefault.IsChecked == true)
            {
                MediaPlayer1.Custom_Video_Decoder = string.Empty;
            }
            else if (rbVideoDecoderFFDShow.IsChecked == true)
            {
                MediaPlayer1.Custom_Video_Decoder = "ffdshow Video Decoder";
            }
            else if (rbVideoDecoderMS.IsChecked == true)
            {
                MediaPlayer1.Custom_Video_Decoder = "Microsoft DTV-DVD Video Decoder";
            }
            else if (rbVideoDecoderVFH264.IsChecked == true)
            {
                MediaPlayer1.Custom_Video_Decoder = "VisioForge H264 Decoder";
            }
            else if (rbVideoDecoderCustom.IsChecked == true)
            {
                MediaPlayer1.Custom_Video_Decoder = cbCustomVideoDecoder.Text;
            }

            if (rbSplitterCustom.IsChecked == true)
            {
                MediaPlayer1.Custom_Splitter = cbCustomSplitter.Text;
            }
            else
            {
                MediaPlayer1.Custom_Splitter = string.Empty;
            }

            if (rbAudioDecoderDefault.IsChecked == true)
            {
                MediaPlayer1.Custom_Audio_Decoder = string.Empty;
            }
            else if (rbAudioDecoderCustom.IsChecked == true)
            {
                MediaPlayer1.Custom_Audio_Decoder = cbCustomAudioDecoder.Text;
            }

            if (lbSourceFiles.Items.Count == 0)
            {
                MessageBox.Show(this, "Playlist is empty!");
            }

            foreach (var item in lbSourceFiles.Items)
            {
                MediaPlayer1.Playlist_Add(item.ToString());
            }

            MediaPlayer1.Loop = cbLoop.IsChecked == true;
            MediaPlayer1.Audio_PlayAudio = cbPlayAudio.IsChecked == true;

            SetSourceMode();

            btReadInfo_Click(null, null);

            MediaPlayer1.Audio_OutputDevice = cbAudioOutputDevice.Text;

            if (rbWPF.IsChecked == true)
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;
            }
            else if (rbDirect2D.IsChecked == true)
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D;
            }
            else if (rbEVR.IsChecked == true)
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.EVR;
            }
            else
            {
                MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            }

            MediaPlayer1.Virtual_Camera_Output_Enabled = rbVirtualCameraOutput.IsChecked == true;

            if (cbStretch.IsChecked == true)
            {
                MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            MediaPlayer1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            MediaPlayer1.Video_Renderer.BackgroundColor = VideoView.ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);
            MediaPlayer1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            MediaPlayer1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            VideoView1.Background = pnVideoRendererBGColor.Fill;

            MediaPlayer1.Video_Sample_Grabber_UseForVideoEffects = true;

            // Audio enhancement
            MediaPlayer1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.IsChecked == true;
            if (MediaPlayer1.Audio_Enhancer_Enabled)
            {
                await MediaPlayer1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.IsChecked == true);
                await MediaPlayer1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.IsChecked == true);

                await ApplyAudioInputGainsAsync();
                await ApplyAudioOutputGainsAsync();

                await MediaPlayer1.Audio_Enhancer_TimeshiftAsync(-1, (int)tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.IsChecked == true)
            {
                MediaPlayer1.Audio_Channel_Mapper = new AudioChannelMapperSettings
                {
                    Routes = audioChannelMapperItems.ToArray(),
                    OutputChannelsCount =
                                                                Convert.ToInt32(
                                                                    edAudioChannelMapperOutputChannels.Text)
                };
            }
            else
            {
                MediaPlayer1.Audio_Channel_Mapper = null;
            }

            // Audio processing
            MediaPlayer1.Audio_Effects_Clear(-1);
            MediaPlayer1.Audio_Effects_Enabled = cbAudioEffectsEnabled.IsChecked == true;
            if (MediaPlayer1.Audio_Effects_Enabled)
            {
                MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                MediaPlayer1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
            }

            // VU meter Pro
            if (cbVUMeterProEnabled.IsChecked == true)
            {
                MediaPlayer1.Audio_VUMeter_Pro_Enabled = true;

                MediaPlayer1.Audio_VUMeter_Pro_Volume = (int)tbVUMeterAmplification.Value;

                volumeMeter1.Boost = (float)tbVUMeterBoost.Value / 10.0F;
                volumeMeter2.Boost = (float)tbVUMeterBoost.Value / 10.0F;

                waveformPainter.Start();
                spectrumAnalyzer.Start();
                volumeMeter1.Start();
                volumeMeter2.Start();
            }
            else
            {
                MediaPlayer1.Audio_VUMeter_Pro_Enabled = false;
            }

            // Video effects CPU
            AddVideoEffects();

            // Configure chroma-key
            ConfigureChromaKey();

            // Video effects GPU
            MediaPlayer1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.IsChecked == true;

            // Motion detection
            ConfigureMotionDetection();

            // Barcode detection
            MediaPlayer1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.IsChecked == true;
            MediaPlayer1.Barcode_Reader_Type = (BarcodeType)cbBarcodeType.SelectedIndex;

            // Encryption
            if (rbEncryptionKeyString.IsChecked == true)
            {
                MediaPlayer1.Encryption_KeyType = EncryptionKeyType.String;
                MediaPlayer1.Encryption_Key = edEncryptionKeyString.Text;
            }
            else if (rbEncryptionKeyFile.IsChecked == true)
            {
                MediaPlayer1.Encryption_KeyType = EncryptionKeyType.File;
                MediaPlayer1.Encryption_Key = edEncryptionKeyFile.Text;
            }
            else
            {
                MediaPlayer1.Encryption_KeyType = EncryptionKeyType.Binary;
                MediaPlayer1.Encryption_Key = MediaPlayer1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
            }

            if (cbAdditionalVideoView.IsChecked == true)
            {
                MediaPlayer1.OnVideoFrameBufferWPF -= MediaPlayer1_OnVideoFrameBufferWPF;
                MediaPlayer1.OnVideoFrameBufferWPF += MediaPlayer1_OnVideoFrameBufferWPF;
            }

            await MediaPlayer1.PlayAsync().ConfigureAwait(true);

            // set audio volume for each stream
            if (MediaPlayer1.Source_Mode != MediaPlayerSourceMode.MMS_WMV_DS)
            {
                int count = MediaPlayer1.Audio_Streams_Count();

                if (count > 0)
                {
                    MediaPlayer1.Audio_OutputDevice_Balance_Set(0, (int)tbBalance1.Value);
                    MediaPlayer1.Audio_OutputDevice_Volume_Set(0, (int)tbVolume1.Value);
                }

                // independent audio output for each audio stream
                if (!MediaPlayer1.Audio_Streams_AllInOne())
                {
                    if (count > 1)
                    {
                        MediaPlayer1.Audio_OutputDevice_Balance_Set(1, (int)tbBalance2.Value);
                        MediaPlayer1.Audio_OutputDevice_Volume_Set(1, (int)tbVolume2.Value);
                        await MediaPlayer1.Audio_Streams_SetAsync(1, false); // disable stream
                    }

                    if (count > 2)
                    {
                        MediaPlayer1.Audio_OutputDevice_Balance_Set(2, (int)tbBalance3.Value);
                        MediaPlayer1.Audio_OutputDevice_Volume_Set(2, (int)tbVolume3.Value);
                        await MediaPlayer1.Audio_Streams_SetAsync(2, false); // disable stream
                    }

                    if (count > 3)
                    {
                        MediaPlayer1.Audio_OutputDevice_Balance_Set(3, (int)tbBalance4.Value);
                        MediaPlayer1.Audio_OutputDevice_Volume_Set(3, (int)tbVolume4.Value);
                        await MediaPlayer1.Audio_Streams_SetAsync(3, false); // disable stream
                    }
                }
                else
                {
                    tbBalance2.IsEnabled = false;
                    tbVolume2.IsEnabled = false;

                    tbBalance3.IsEnabled = false;
                    tbVolume3.IsEnabled = false;

                    tbBalance4.IsEnabled = false;
                    tbVolume4.IsEnabled = false;
                }
            }
            else
            {
                MediaPlayer1.Audio_OutputDevice_Balance_Set(0, (int)tbBalance1.Value);
                MediaPlayer1.Audio_OutputDevice_Volume_Set(0, (int)tbVolume1.Value);
            }

            timer.Start();
        }

        private void MediaPlayer1_OnVideoFrameBufferWPF(object sender, VideoFrameBufferEventArgs e)
        {
            videoViewAdditional.PushFrame(e.Frame);
        }

        private void AddVideoEffects()
        {
            MediaPlayer1.Video_Effects_Enabled = cbEffects.IsChecked == true;
            MediaPlayer1.Video_Effects_Clear();
            lbTextLogos.Items.Clear();
            lbImageLogos.Items.Clear();

            // Deinterlace
            if (cbDeinterlace.IsChecked == true)
            {
                MediaPlayer1.Video_Effects_Enabled = true;
                if (rbDeintBlendEnabled.IsChecked == true)
                {
                    IVideoEffectDeinterlaceBlend blend;
                    var effect = MediaPlayer1.Video_Effects_Get("DeinterlaceBlend");
                    if (effect == null)
                    {
                        blend = new VideoEffectDeinterlaceBlend(true);
                        MediaPlayer1.Video_Effects_Add(blend);
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
                    var effect = MediaPlayer1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.IsChecked == true, Convert.ToInt32(edDeintCAVTThreshold.Text));
                        MediaPlayer1.Video_Effects_Add(cavt);
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
                    var effect = MediaPlayer1.Video_Effects_Get("DeinterlaceTriangle");
                    if (effect == null)
                    {
                        triangle = new VideoEffectDeinterlaceTriangle(true, Convert.ToByte(edDeintTriangleWeight.Text));
                        MediaPlayer1.Video_Effects_Add(triangle);
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
            if (cbDenoise.IsChecked == true)
            {
                MediaPlayer1.Video_Effects_Enabled = true;
                if (rbDenoiseCAST.IsChecked == true)
                {
                    IVideoEffectDenoiseCAST cast;
                    var effect = MediaPlayer1.Video_Effects_Get("DenoiseCAST");
                    if (effect == null)
                    {
                        cast = new VideoEffectDenoiseCAST(true);
                        MediaPlayer1.Video_Effects_Add(cast);
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
                    var effect = MediaPlayer1.Video_Effects_Get("DenoiseMosquito");
                    if (effect == null)
                    {
                        mosquito = new VideoEffectDenoiseMosquito(true);
                        MediaPlayer1.Video_Effects_Add(mosquito);
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
                cbGreyscale_Checked(null, null);
            }

            if (cbInvert.IsChecked == true)
            {
                cbInvert_Checked(null, null);
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

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edFilenameOrURL.Text = openFileDialog1.FileName;
            }
        }

        private async void cbAudioStream1_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Streams_SetAsync(0, cbAudioStream1.IsChecked == true);
            if (cbAudioStream1.IsChecked == true)
            {
                tbVolume1_ValueChanged(null, null);

                if (MediaPlayer1.Audio_Streams_AllInOne())
                {
                    cbAudioStream2.IsChecked = false;
                    cbAudioStream3.IsChecked = false;
                    cbAudioStream4.IsChecked = false;
                }
            }
        }

        private async void cbAudioStream2_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Streams_SetAsync(1, cbAudioStream2.IsChecked == true);
            if (cbAudioStream2.IsChecked == true)
            {
                tbVolume2_ValueChanged(null, null);

                if (MediaPlayer1.Audio_Streams_AllInOne())
                {
                    cbAudioStream1.IsChecked = false;
                    cbAudioStream3.IsChecked = false;
                    cbAudioStream4.IsChecked = false;
                }
            }
        }

        private async void cbAudioStream3_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Streams_SetAsync(2, cbAudioStream3.IsChecked == true);
            if (cbAudioStream3.IsChecked == true)
            {
                tbVolume3_ValueChanged(null, null);

                if (MediaPlayer1.Audio_Streams_AllInOne())
                {
                    cbAudioStream1.IsChecked = false;
                    cbAudioStream2.IsChecked = false;
                    cbAudioStream4.IsChecked = false;
                }
            }
        }

        private async void cbAudioStream4_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Streams_SetAsync(3, cbAudioStream4.IsChecked == true);
            if (cbAudioStream4.IsChecked == true)
            {
                tbVolume4_ValueChanged(null, null);

                if (MediaPlayer1.Audio_Streams_AllInOne())
                {
                    cbAudioStream1.IsChecked = false;
                    cbAudioStream2.IsChecked = false;
                    cbAudioStream3.IsChecked = false;
                }
            }
        }

        private void ClearUI()
        {
            tbTimeline.Value = 0;

            waveformPainter.Stop();
            waveformPainter.Clear();

            spectrumAnalyzer.Stop();
            spectrumAnalyzer.Clear();

            volumeMeter1.Stop();
            volumeMeter1.Clear();

            volumeMeter2.Stop();
            volumeMeter2.Clear();
        }

        private async Task StopAll()
        {
            await MediaPlayer1.StopAsync().ConfigureAwait(false);

            timer.Stop();

            if (Dispatcher.CheckAccess())
            {
                ClearUI();
            }
            else
            {
                Dispatcher.Invoke(ClearUI);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await StopAll();
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.ResumeAsync().ConfigureAwait(false);
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.PauseAsync().ConfigureAwait(false);
        }

        private void btNextFrame_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer1.Video_Renderer.VideoRenderer != VideoRendererMode.EVR)
            {
                MessageBox.Show(this, "Please set video renderer to EVR to support frame step.");
                return;
            }

            MediaPlayer1.NextFrame();
        }

        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectContrast contrast;
            var effect = MediaPlayer1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
                MediaPlayer1.Video_Effects_Add(contrast);
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

        private void btAudEqRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbAudEq0.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0);
            tbAudEq1.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1);
            tbAudEq2.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2);
            tbAudEq3.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3);
            tbAudEq4.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4);
            tbAudEq5.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5);
            tbAudEq6.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6);
            tbAudEq7.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7);
            tbAudEq8.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8);
            tbAudEq9.Value = MediaPlayer1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9);
        }

        private void cbAudAmplifyEnabled_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true);
        }

        private void cbAudDynamicAmplifyEnabled_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true);
        }

        private void cbAudEqualizerEnabled_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true);
        }

        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(null, null);
        }

        private void cbAudSound3DEnabled_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true);
        }

        private void cbAudTrueBassEnabled_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true);
        }

        private void tbAud3DSound_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, (int)tbAud3DSound.Value);
        }

        private void tbAudAmplifyAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, (int)tbAudAmplifyAmp.Value * 10, false);
        }

        private void tbAudAttack_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void tbAudDynAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void tbAudEq0_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, (int)tbAudEq0.Value);
        }

        private void tbAudEq1_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, (int)tbAudEq1.Value);
        }

        private void tbAudEq2_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, (int)tbAudEq2.Value);
        }

        private void tbAudEq3_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, (int)tbAudEq3.Value);
        }

        private void tbAudEq4_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, (int)tbAudEq4.Value);
        }

        private void tbAudEq5_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, (int)tbAudEq5.Value);
        }

        private void tbAudEq6_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, (int)tbAudEq6.Value);
        }

        private void tbAudEq7_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, (int)tbAudEq7.Value);
        }

        private void tbAudEq8_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, (int)tbAudEq8.Value);
        }

        private void tbAudEq9_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, (int)tbAudEq9.Value);
        }

        private void tbAudRelease_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        private void tbAudTrueBass_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaPlayer1?.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, false, (int)tbAudTrueBass.Value);
        }

        private void tbJPEGQuality_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbJPEGQuality != null)
            {
                lbJPEGQuality.Content = tbJPEGQuality.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.IsChecked == true)
            {
                MediaPlayer1.Motion_Detection = new MotionDetectionSettings
                {
                    Enabled = true,
                    Compare_Red = cbCompareRed.IsChecked == true,
                    Compare_Green = cbCompareGreen.IsChecked == true,
                    Compare_Blue = cbCompareBlue.IsChecked == true,
                    Compare_Greyscale = cbCompareGreyscale.IsChecked == true,
                    Highlight_Color =
                                                            (MotionCHLColor)cbMotDetHLColor.SelectedIndex,
                    Highlight_Enabled = cbMotDetHLEnabled.IsChecked == true,
                    Highlight_Threshold = (int)tbMotDetHLThreshold.Value,
                    FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text),
                    Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text),
                    Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text),
                    DropFrames_Enabled =
                                                            cbMotDetDropFramesEnabled.IsChecked == true,
                    DropFrames_Threshold = (int)tbMotDetDropFramesThreshold.Value
                };
                MediaPlayer1.MotionDetection_Update();
            }
            else
            {
                MediaPlayer1.Motion_Detection = null;
            }
        }

        private void btMotDetUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetection();
        }

        private void btChromaKeySelectBGImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
                ConfigureChromaKey();
            }
        }

        private void ConfigureMotionDetectionEx()
        {
            if (cbMotionDetectionEx.IsChecked == true)
            {
                MediaPlayer1.Motion_DetectionEx = new MotionDetectionExSettings
                {
                    ProcessorType = (MotionProcessorType)rbMotionDetectionExProcessor.SelectedIndex,
                    DetectorType = (MotionDetectorType)rbMotionDetectionExDetector.SelectedIndex
                };
            }
            else
            {
                MediaPlayer1.Motion_DetectionEx = null;
            }
        }

        private void cbAFMotionDetection_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetectionEx();
        }

        private void ConfigureChromaKey()
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            if (MediaPlayer1.ChromaKey != null)
            {
                MediaPlayer1.ChromaKey.Dispose();
                MediaPlayer1.ChromaKey = null;
            }

            if (cbChromaKeyEnabled.IsChecked == true)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show(this, "Chroma-key background file doesn't exists.");
                    return;
                }

                MediaPlayer1.ChromaKey = new ChromaKeySettings(new Bitmap(edChromaKeyImage.Text))
                {
                    Smoothing = (float)(tbChromaKeySmoothing.Value / 1000f),
                    ThresholdSensitivity = (float)(tbChromaKeyThresholdSensitivity.Value / 1000f),
                    Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color)
                };
            }
            else
            {
                MediaPlayer1.ChromaKey = null;
            }
        }

        private delegate void MotionDelegate(MotionDetectionEventArgs e);

        private void MotionDelegateMethod(MotionDetectionEventArgs e)
        {
            string s = string.Empty;
            int k = 0;
            foreach (byte b in e.Matrix)
            {
                s += b.ToString("D3") + " ";

                if (k == MediaPlayer1.Motion_Detection.Matrix_Width - 1)
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

        private void MediaPlayer1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            Dispatcher?.BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        private void MediaPlayer1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher?.BeginInvoke(new StopDelegate(StopDelegateMethod), null);
        }

        private delegate void StopDelegate();

        private void StopDelegateMethod()
        {
            tbTimeline.Value = 0;

            waveformPainter.Stop();
            waveformPainter.Clear();

            spectrumAnalyzer.Stop();
            spectrumAnalyzer.Clear();

            volumeMeter1.Stop();
            volumeMeter1.Clear();

            volumeMeter2.Stop();
            volumeMeter2.Clear();

            if (memoryFileStream != null)
            {
                memoryFileStream.Dispose();
                memoryFileStream = null;
            }
        }

        private void cbZoomEnabled_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectZoom zoomEffect;
            var effect = MediaPlayer1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoomEnabled.IsChecked == true);
                MediaPlayer1.Video_Effects_Add(zoomEffect);
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
            IVideoEffectPan pan;
            var effect = MediaPlayer1.Video_Effects_Get("Pan");
            if (effect == null)
            {
                pan = new VideoEffectPan(true);
                MediaPlayer1.Video_Effects_Add(pan);
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

        private void btBarcodeReset_Click(object sender, RoutedEventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            MediaPlayer1.Barcode_Reader_Enabled = true;
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

        private void MediaPlayer1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            Dispatcher?.BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        private void btAddFileToPlaylist_Click(object sender, RoutedEventArgs e)
        {
            lbSourceFiles.Items.Add(edFilenameOrURL.Text);
        }

        private void cbFadeInOut_Checked(object sender, RoutedEventArgs e)
        {
            if (rbFadeIn.IsChecked == true)
            {
                IVideoEffectFadeIn fadeIn;
                var effect = MediaPlayer1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VideoEffectFadeIn(cbFadeInOut.IsChecked == true);
                    MediaPlayer1.Video_Effects_Add(fadeIn);
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
                var effect = MediaPlayer1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VideoEffectFadeOut(cbFadeInOut.IsChecked == true);
                    MediaPlayer1.Video_Effects_Add(fadeOut);
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

        private void label129_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
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

                controlMargin = VideoView1.Margin;
                controlWidth = VideoView1.Width;
                controlHeight = VideoView1.Height;

                // resizing window
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                Topmost = true;

                Left = 0;
                Top = 0;
                Width = SystemParameters.PrimaryScreenWidth;
                Height = SystemParameters.PrimaryScreenHeight;
                Margin = new Thickness(0);

                // resizing control
                VideoView1.Margin = new Thickness(0, 0, 0, 0);
                VideoView1.Width = SystemParameters.PrimaryScreenWidth;
                VideoView1.Height = SystemParameters.PrimaryScreenHeight;

                await MediaPlayer1.Video_Renderer_UpdateAsync();
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

                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                Topmost = false;
                ResizeMode = ResizeMode.CanResize;

                await MediaPlayer1.Video_Renderer_UpdateAsync();
            }
        }

        private void MediaPlayer1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        private void btReversePlayback_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.ReversePlayback_CacheSize = int.Parse(edReversePlaybackCacheSize.Text);

            if (MediaPlayer1.ReversePlayback_Enabled)
            {
                btReversePlayback.Content = "Go to reverse playback mode";
                MediaPlayer1.ReversePlayback_Enabled = false;
            }
            else
            {
                btReversePlayback.Content = "Go to normal playback mode";
                MediaPlayer1.ReversePlayback_Enabled = true;
            }
        }

        private void tbReversePlaybackTrackbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tbReversePlaybackTrackbar != null)
            {
                MediaPlayer1?.ReversePlayback_GoToFrame((int)tbReversePlaybackTrackbar.Value);
            }
        }

        #region VU meter Pro

        private void MediaPlayer1_OnAudioVUMeterProMaximumCalculated(object sender, VUMeterMaxSampleEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
                                                    {
                                                        waveformPainter.AddValue(e.MaxSample, e.MinSample);
                                                    }));
        }

        private void MediaPlayer1_OnAudioVUMeterProFFTCalculated(object sender, VUMeterFFTEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
                {
                    spectrumAnalyzer.Update(e.Result);
                }));
        }

        private void MediaPlayer1_OnAudioVUMeterProVolume(object sender, AudioLevelEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
                                                    {
                                                        volumeMeter1.Amplitude = e.ChannelLevelsDb[0];
                                                        volumeMeter1.Update();

                                                        if (e.ChannelLevelsDb.Length > 1)
                                                        {
                                                            volumeMeter2.Amplitude = e.ChannelLevelsDb[1];
                                                            volumeMeter2.Update();
                                                        }
                                                    }));
        }

        private void tbVUMeterAmplification_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.Audio_VUMeter_Pro_Volume = (int)tbVUMeterAmplification.Value;
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
            if (MediaPlayer1 != null)
            {
                IVideoEffectRotate rotate;
                var effect = MediaPlayer1.Video_Effects_Get("Rotate");
                if (effect == null)
                {
                    rotate = new VideoEffectRotate(
                        cbLiveRotation.IsChecked == true,
                        tbLiveRotationAngle.Value,
                        cbLiveRotationStretch.IsChecked == true);
                    MediaPlayer1.Video_Effects_Add(rotate);
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
            MediaPlayer1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void cbScreenFlipHorizontal_Checked(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void cbDirect2DRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                MediaPlayer1.Video_Renderer.RotationAngle = Convert.ToInt32(name);
                await MediaPlayer1.Video_Renderer_UpdateAsync();
            }
        }

        private async void btZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_ShiftY = MediaPlayer1.Video_Renderer.Zoom_ShiftY + 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_ShiftX = MediaPlayer1.Video_Renderer.Zoom_ShiftX + 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_ShiftX = MediaPlayer1.Video_Renderer.Zoom_ShiftX - 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_ShiftY = MediaPlayer1.Video_Renderer.Zoom_ShiftY - 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_Ratio = MediaPlayer1.Video_Renderer.Zoom_Ratio - 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Video_Renderer.Zoom_Ratio = MediaPlayer1.Video_Renderer.Zoom_Ratio + 10;
            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private async void pnVideoRendererBGColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnVideoRendererBGColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                VideoView1.Background = pnVideoRendererBGColor.Fill;

                MediaPlayer1.Video_Renderer.BackgroundColor = colorDialog1.Color;
                await MediaPlayer1.Video_Renderer_UpdateAsync();
            }
        }

        private async void cbStretch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbStretch.IsChecked == true)
            {
                MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                MediaPlayer1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            await MediaPlayer1.Video_Renderer_UpdateAsync();
        }

        private void rbVR_Checked(object sender, RoutedEventArgs e)
        {
            if (rbDirect2D != null && cbScreenFlipVertical != null && 
                cbScreenFlipHorizontal != null && cbDirect2DRotate != null &&
                pnZoom != null)
            {
                bool direct2d = rbDirect2D.IsChecked == true;
                cbScreenFlipVertical.IsEnabled = direct2d;
                cbScreenFlipHorizontal.IsEnabled = direct2d;
                cbDirect2DRotate.IsEnabled = direct2d;
                pnZoom.IsEnabled = direct2d;
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                string name = e.AddedItems[0].ToString();
                btFilterSettings.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                    FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        private void btFilterAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                MediaPlayer1.Video_Filters_Add(cbFilters.Text);
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

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

        private void btFilterDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                MediaPlayer1.Video_Filters_Delete((string)lbFilters.SelectedValue);
                lbFilters.Items.Remove(lbFilters.SelectedValue);
            }
        }

        private void btFilterDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            lbFilters.Items.Clear();
            MediaPlayer1.Video_Filters_Clear();
        }

        private void lbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.SelectedValue.ToString();
                btFilterSettings2.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                                            FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        private async void cbAudioNormalize_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.IsChecked == true);
        }

        private async void cbAudioAutoGain_Checked(object sender, RoutedEventArgs e)
        {
            await MediaPlayer1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.IsChecked == true);
        }

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

            await MediaPlayer1.Audio_Enhancer_InputGainsAsync(-1, gains);
        }

        private async void tbAudioInputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainL.Content = (tbAudioInputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        private async void tbAudioInputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainC.Content = (tbAudioInputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        private async void tbAudioInputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainR.Content = (tbAudioInputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        private async void tbAudioInputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSL.Content = (tbAudioInputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        private async void tbAudioInputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSR.Content = (tbAudioInputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        private async void tbAudioInputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainLFE.Content = (tbAudioInputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

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

            await MediaPlayer1.Audio_Enhancer_OutputGainsAsync(-1, gains);
        }

        private async void tbAudioOutputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainL.Content = (tbAudioOutputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioOutputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainC.Content = (tbAudioOutputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioOutputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainR.Content = (tbAudioOutputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioOutputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSL.Content = (tbAudioOutputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioOutputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSR.Content = (tbAudioOutputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioOutputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainLFE.Content = (tbAudioOutputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        private async void tbAudioTimeshift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioTimeshift.Content = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms";

            await MediaPlayer1.Audio_Enhancer_TimeshiftAsync(-1, (int)tbAudioTimeshift.Value);
        }

        private void btEncryptionOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        private void btReadTags_Click(object sender, RoutedEventArgs e)
        {
            var tags = MediaPlayer1.Tags_Read(edFilenameOrURL.Text);

            if (tags != null)
            {
                if (tags.Pictures?.Length > 0)
                {
                    imgTags.Source = tags.Pictures[0].ToBitmapSource();
                }

                edTags.Text = tags.ToString();
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

        private void tbGPULightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            IGPUVideoEffectBrightness intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new GPUVideoEffectBrightness(true, (int)tbGPULightness.Value);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void tbGPUSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            IGPUVideoEffectSaturation intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new GPUVideoEffectSaturation(true, (int)tbGPUSaturation.Value);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void tbGPUContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            IGPUVideoEffectContrast intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new GPUVideoEffectContrast(true, (int)tbGPUContrast.Value);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void tbGPUDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MediaPlayer1 == null)
            {
                return;
            }

            IGPUVideoEffectDarkness intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new GPUVideoEffectDarkness(true, (int)tbGPUDarkness.Value);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUGreyscale_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectGrayscale intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new GPUVideoEffectGrayscale(cbGPUGreyscale.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUInvert_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectInvert intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new GPUVideoEffectInvert(cbGPUInvert.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUNightVision_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectNightVision intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new GPUVideoEffectNightVision(cbGPUNightVision.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUPixelate_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectPixelate intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new GPUVideoEffectPixelate(cbGPUPixelate.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUDenoise_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDenoise intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new GPUVideoEffectDenoise(cbGPUDenoise.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUDeinterlace_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDeinterlaceBlend intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void cbGPUOldMovie_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectOldMovie intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new GPUVideoEffectOldMovie(cbGPUOldMovie.IsChecked == true);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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

        private void btReversePlaybackPrevFrame_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.ReversePlayback_PreviousFrame();
        }

        private void btReversePlaybackNextFrame_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.ReversePlayback_NextFrame();
        }

        private void btPrevFrame_Click(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer1.Video_Renderer.VideoRenderer != VideoRendererMode.EVR)
            {
                MessageBox.Show(this, "Please set video renderer to EVR to support frame step.");
                return;
            }

            MediaPlayer1.PreviousFrame();
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await StopAll();

            DestroyEngine();
        }

        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(MediaPlayer1);
            var effect = new VideoEffectTextLogo(true, name);

            MediaPlayer1.Video_Effects_Add(effect);
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
                var effect = MediaPlayer1.Video_Effects_Get((string)lbTextLogos.SelectedItem);
                dlg.Attach(effect);

                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        private void BtTextLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                MediaPlayer1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(MediaPlayer1);
            var effect = new VideoEffectImageLogo(true, name);

            MediaPlayer1.Video_Effects_Add(effect);
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
                var effect = MediaPlayer1.Video_Effects_Get((string)lbImageLogos.SelectedItem);

                dlg.Attach(effect);
                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        private void BtImageLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                MediaPlayer1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        private void CbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipDown flip;
            var effect = MediaPlayer1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                MediaPlayer1.Video_Effects_Add(flip);
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

        private void CbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipRight flip;
            var effect = MediaPlayer1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
                MediaPlayer1.Video_Effects_Add(flip);
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

        private void MediaPlayer1_OnMIDIFileInfo(object sender, MIDIInfoEventArgs e)
        {
            Dispatcher?.BeginInvoke((Action)(() =>
            {
                edTags.Text += "MIDI Info from OnMIDIFileInfo event:" + Environment.NewLine;
                edTags.Text += e.Info.ToString();
            }));
        }

        private void mnPlaylistRemoveAll_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Playlist_Clear();

            lbSourceFiles.Items.Clear();
        }

        private void mnPlaylistRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbSourceFiles.SelectedItem != null)
            {
                var filename = lbSourceFiles.SelectedItem.ToString();
                MediaPlayer1.Playlist_Remove(filename);

                lbSourceFiles.Items.Remove(lbSourceFiles.SelectedItem);
            }
        }

        private void tbGPUBlur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IGPUVideoEffectBlur intf;
            var effect = MediaPlayer1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new GPUVideoEffectBlur(tbGPUBlur.Value > 0, (int)tbGPUBlur.Value);
                MediaPlayer1.Video_Effects_GPU_Add(intf);
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