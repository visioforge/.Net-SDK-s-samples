



namespace Main_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.AudioEffects;
    using VisioForge.Core.Types.Decklink;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.FFMPEGEXE;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoEdit;
    using VisioForge.Core.Types.VideoEffects;
    using VisioForge.Core.Types.VideoProcessing;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
    using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
    using VisioForge.Core.UI.WPF;
    using VisioForge.Core.VideoEdit;
    using Color = System.Windows.Media.Color;
    using MessageBox = System.Windows.MessageBox;

    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class Window1
    {
        /// <summary>
        /// Audio effect ID for amplify.
        /// </summary>
        private const string AUDIO_EFFECT_ID_AMPLIFY = "amplify";

        /// <summary>
        /// Audio effect ID for equalizer.
        /// </summary>
        private const string AUDIO_EFFECT_ID_EQ = "eq";

        /// <summary>
        /// Audio effect ID for dynamic amplify.
        /// </summary>
        private const string AUDIO_EFFECT_ID_DYN_AMPLIFY = "dyn_amplify";

        /// <summary>
        /// Audio effect ID for sound 3D.
        /// </summary>
        private const string AUDIO_EFFECT_ID_SOUND_3D = "sound3d";

        /// <summary>
        /// Audio effect ID for true bass.
        /// </summary>
        private const string AUDIO_EFFECT_ID_TRUE_BASS = "true_bass";

        /// <summary>
        /// Audio effect ID for fade in.
        /// </summary>
        private const string AUDIO_EFFECT_ID_FADE_IN = "fade_in";

        /// <summary>
        /// Audio effect ID for fade out.
        /// </summary>
        private const string AUDIO_EFFECT_ID_FADE_OUT = "fade_out";

        /// <summary>
        /// The video edit core.
        /// </summary>
        private VideoEditCore VideoEdit1;

        /// <summary>
        /// MP4 HW settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        /// <summary>
        /// MP4 settings dialog.
        /// </summary>
        private MP4SettingsDialog mp4SettingsDialog;

        /// <summary>
        /// AVI settings dialog.
        /// </summary>
        private AVISettingsDialog aviSettingsDialog;

        /// <summary>
        /// WMV settings dialog.
        /// </summary>
        private WMVSettingsDialog wmvSettingsDialog;

        /// <summary>
        /// DV settings dialog.
        /// </summary>
        private DVSettingsDialog dvSettingsDialog;

        /// <summary>
        /// PCM settings dialog.
        /// </summary>
        private PCMSettingsDialog pcmSettingsDialog;

        /// <summary>
        /// MP3 settings dialog.
        /// </summary>
        private MP3SettingsDialog mp3SettingsDialog;

        /// <summary>
        /// WebM settings dialog.
        /// </summary>
        private WebMSettingsDialog webmSettingsDialog;

        /// <summary>
        /// FFMPEG settings dialog.
        /// </summary>
        private FFMPEGSettingsDialog ffmpegSettingsDialog;

        /// <summary>
        /// FFMPEG EXE settings dialog.
        /// </summary>
        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        /// <summary>
        /// FLAC settings dialog.
        /// </summary>
        private FLACSettingsDialog flacSettingsDialog;

        /// <summary>
        /// Custom format settings dialog.
        /// </summary>
        private CustomFormatSettingsDialog customFormatSettingsDialog;

        /// <summary>
        /// Ogg Vorbis settings dialog.
        /// </summary>
        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        /// <summary>
        /// Speex settings dialog.
        /// </summary>
        private SpeexSettingsDialog speexSettingsDialog;

        /// <summary>
        /// M4A settings dialog.
        /// </summary>
        private M4ASettingsDialog m4aSettingsDialog;

        /// <summary>
        /// GIF settings dialog.
        /// </summary>
        private GIFSettingsDialog gifSettingsDialog;

        /// <summary>
        /// List of audio channel mapper items.
        /// </summary>
        private readonly List<AudioChannelMapperItem> audioChannelMapperItems = new List<AudioChannelMapperItem>();

        // Zoom
        /// <summary>
        /// The zoom level.
        /// </summary>
        private double zoom = 1.0;

        /// <summary>
        /// The zoom shift X.
        /// </summary>
        private int zoomShiftX;

        /// <summary>
        /// The zoom shift Y.
        /// </summary>
        private int zoomShiftY;

        // Dialogs
        /// <summary>
        /// The font dialog.
        /// </summary>
        private readonly FontDialog fontDialog;

        /// <summary>
        /// The save file dialog.
        /// </summary>
        private readonly Microsoft.Win32.SaveFileDialog saveFileDialog1;

        /// <summary>
        /// The open file dialog 1.
        /// </summary>
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1;

        /// <summary>
        /// The open file dialog 2.
        /// </summary>
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog2;

        /// <summary>
        /// The color dialog.
        /// </summary>
        private readonly ColorDialog colorDialog1;

        /// <summary>
        /// Converts WPF Color to System.Drawing.Color.
        /// </summary>
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
        /// Gets the file extension from the specified filename.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The file extension including the dot.</returns>
        private static string GetFileExt(string filename)
        {
            int k = filename.LastIndexOf('.');
            return filename.Substring(k, filename.Length - k);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            

            fontDialog = new FontDialog();
            saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            openFileDialog1 = new Microsoft.Win32.OpenFileDialog();
            openFileDialog2 = new Microsoft.Win32.OpenFileDialog();
            colorDialog1 = new ColorDialog();
        }

        /// <summary>
        /// Creates the video editing engine and subscribes to events.
        /// </summary>
        private void CreateEngine()
        {
            VideoEdit1 = new VideoEditCore(VideoView1 as IVideoView);

            VideoEdit1.OnError += VideoEdit1_OnError;
            VideoEdit1.OnBarcodeDetected += VideoEdit1_OnBarcodeDetected;
            VideoEdit1.OnMotionDetection += VideoEdit1_OnMotion;
            VideoEdit1.OnFFMPEGInfo += VideoEdit1_OnFFMPEGInfo;
            VideoEdit1.OnStart += VideoEdit1_OnStart;
            VideoEdit1.OnStop += VideoEdit1_OnStop;
            VideoEdit1.OnProgress += VideoEdit1_OnProgress;
        }

        /// <summary>
        /// Destroys the video editing engine and unsubscribes from events.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoEdit1 != null)
            {
                VideoEdit1.OnError -= VideoEdit1_OnError;
                VideoEdit1.OnBarcodeDetected -= VideoEdit1_OnBarcodeDetected;
                VideoEdit1.OnMotionDetection -= VideoEdit1_OnMotion;
                VideoEdit1.OnFFMPEGInfo -= VideoEdit1_OnFFMPEGInfo;
                VideoEdit1.OnStart -= VideoEdit1_OnStart;
                VideoEdit1.OnStop -= VideoEdit1_OnStop;
                VideoEdit1.OnProgress -= VideoEdit1_OnProgress;

                VideoEdit1.Dispose();
                VideoEdit1 = null;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the engine, sets the SDK version in the title, and configures default UI values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngine();
            Title += $" (SDK v{VideoEdit1.SDK_Version()})";

            // font for text logo
            fontDialog.Color = System.Drawing.Color.White;
            fontDialog.Font = new Font(System.Drawing.FontFamily.GenericSansSerif, 32);

            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 15;
            cbMotDetHLColor.SelectedIndex = 1;
            cbRotate.SelectedIndex = 0;
            cbBarcodeType.SelectedIndex = 0;
            cbNetworkStreamingMode.SelectedIndex = 0;
            cbDirect2DRotate.SelectedIndex = 0;

            pnChromaKeyColor.Fill = new SolidColorBrush(Color.FromArgb(255, 128, 218, 128));

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            edOutputFileCut.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            edOutputFileJoin.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            for (int i = 0; i < VideoEdit1.Video_Transition_Names().Count; i++)
            {
                cbTransitionName.Items.Add(VideoEdit1.Video_Transition_Names()[i]);
            }

            cbTransitionName.SelectedIndex = 0;

            var genres = new List<string>();
            foreach (var genre in VideoEdit1.Tags_GetDefaultVideoGenres())
            {
                genres.Add(genre);
            }

            foreach (var genre in VideoEdit1.Tags_GetDefaultAudioGenres())
            {
                genres.Add(genre);
            }

            genres.Sort();
            foreach (var genre in genres)
            {
                cbTagGenre.Items.Add(genre);
            }

            cbTagGenre.SelectedIndex = 0;

            
            foreach (var item in VideoEdit1.Audio_Effects_Equalizer_Presets())
            {
                cbAudEqualizerPreset.Items.Add(item);
            }

            cbAudEqualizerPreset.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Configures the MP3 output settings.
        /// </summary>
        /// <param name="mp3Output">The MP3 output settings.</param>
        private void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        /// <summary>
        /// Configures the MP4 output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 output settings.</param>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the FFMPEG EXE output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG EXE output settings.</param>
        private void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the WMV output settings.
        /// </summary>
        /// <param name="wmvOutput">The WMV output settings.</param>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Configures the WMA output settings.
        /// </summary>
        /// <param name="wmaOutput">The WMA output settings.</param>
        private void SetWMAOutput(ref WMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        /// <summary>
        /// Configures the ACM (PCM) output settings.
        /// </summary>
        /// <param name="acmOutput">The ACM output settings.</param>
        private void SetACMOutput(ref ACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1);
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        /// <summary>
        /// Configures the WebM output settings.
        /// </summary>
        /// <param name="webmOutput">The WebM output settings.</param>
        private void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        /// <summary>
        /// Configures the FFMPEG output settings.
        /// </summary>
        /// <param name="ffmpegOutput">The FFMPEG output settings.</param>
        private void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Configures the FLAC output settings.
        /// </summary>
        /// <param name="flacOutput">The FLAC output settings.</param>
        private void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        /// <summary>
        /// Configures the MP4 hardware encoders output settings.
        /// </summary>
        /// <param name="mp4Output">The MP4 HW output settings.</param>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Configures the Speex output settings.
        /// </summary>
        /// <param name="speexOutput">The Speex output settings.</param>
        private void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        /// <summary>
        /// Configures the M4A output settings.
        /// </summary>
        /// <param name="m4aOutput">The M4A output settings.</param>
        public void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        /// <summary>
        /// Configures the Animated GIF output settings.
        /// </summary>
        /// <param name="gifOutput">The GIF output settings.</param>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Configures the custom output settings.
        /// </summary>
        /// <param name="customOutput">The custom output settings.</param>
        private void SetCustomOutput(ref CustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1);
            }

            customFormatSettingsDialog.SaveSettings(ref customOutput);
        }

        /// <summary>
        /// Configures the DV output settings.
        /// </summary>
        /// <param name="dvOutput">The DV output settings.</param>
        private void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        /// <summary>
        /// Configures the AVI output settings.
        /// </summary>
        /// <param name="aviOutput">The AVI output settings.</param>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
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
        /// Configures the MKV output settings.
        /// </summary>
        /// <param name="mkvOutput">The MKV output settings.</param>
        private void SetMKVOutput(ref MKVv1Output mkvOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
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
        /// Configures the Ogg Vorbis output settings.
        /// </summary>
        /// <param name="oggVorbisOutput">The Ogg Vorbis output settings.</param>
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
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
            VideoEdit1.Debug_Telemetry = cbTelemetry.IsChecked == true;

            zoom = 1.0;
            zoomShiftX = 0;
            zoomShiftY = 0;

            mmLog.Clear();

            VideoEdit1.Video_Renderer.Zoom_Ratio = 0;
            VideoEdit1.Video_Renderer.Zoom_ShiftX = 0;
            VideoEdit1.Video_Renderer.Zoom_ShiftY = 0;

            if (rbConvert.IsChecked == true)
            {
                VideoEdit1.Mode = VideoEditMode.Convert;
            }
            else
            {
                VideoEdit1.Mode = VideoEditMode.Preview;
            }

            VideoEdit1.Video_Resize = cbResize.IsChecked == true;

            if (VideoEdit1.Video_Resize)
            {
                VideoEdit1.Video_Resize_Width = Convert.ToInt32(edWidth.Text);
                VideoEdit1.Video_Resize_Height = Convert.ToInt32(edHeight.Text);
            }

            if (cbCrop.IsChecked == true)
            {
                VideoEdit1.Video_Crop = new VideoCropSettings(
                    Convert.ToInt32(edCropLeft.Text),
                    Convert.ToInt32(edCropTop.Text),
                    Convert.ToInt32(edCropRight.Text),
                    Convert.ToInt32(edCropBottom.Text));
            }
            else
            {
                VideoEdit1.Video_Crop = null;
            }

            if (cbSubtitlesEnabled.IsChecked == true)
            {
                VideoEdit1.Video_Subtitles = new SubtitlesSettings(edSubtitlesFilename.Text);
            }
            else
            {
                VideoEdit1.Video_Subtitles = null;
            }

            VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(cbFrameRate.Text));

            if (rbWPF.IsChecked == true)
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;
            }
            else if (rbDirect2D.IsChecked == true)
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.Direct2D;
            }
            else
            {
                VideoEdit1.Video_Renderer.VideoRenderer = VideoRendererMode.None;
            }

            if (cbStretch.IsChecked == true)
            {
                VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            VideoView1.Background = pnVideoRendererBGColor.Fill;

            // Network streaming
            VideoEdit1.Network_Streaming_Enabled = cbNetworkStreaming.IsChecked == true;

            if (VideoEdit1.Network_Streaming_Enabled)
            {
                switch (cbNetworkStreamingMode.SelectedIndex)
                {
                    case 0:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.WMV;

                            if (rbNetworkStreamingUseMainWMVSettings.IsChecked == true)
                            {
                                var wmvOutput = new WMVOutput();
                                SetWMVOutput(ref wmvOutput);
                                VideoEdit1.Network_Streaming_Output = wmvOutput;
                            }
                            else
                            {
                                var wmvOutput = new WMVOutput
                                {
                                    Mode = WMVMode.ExternalProfile,
                                    External_Profile_FileName = edNetworkStreamingWMVProfile.Text
                                };
                                VideoEdit1.Network_Streaming_Output = wmvOutput;
                            }

                            VideoEdit1.Network_Streaming_WMV_Maximum_Clients = Convert.ToInt32(edMaximumClients.Text);
                            VideoEdit1.Network_Streaming_Network_Port = Convert.ToInt32(edWMVNetworkPort.Text);

                            break;
                        }

                    case 1:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.RTSP_H264_AAC_SW;
                            VideoEdit1.Network_Streaming_URL = edNetworkRTSPURL.Text;

                            break;
                        }

                    case 2:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.RTMP_FFMPEG_EXE;

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

                            VideoEdit1.Network_Streaming_Output = ffmpegOutput;
                            VideoEdit1.Network_Streaming_URL = edNetworkRTMPURL.Text;

                            break;
                        }
                    case 3:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.NDI;

                            var ndiOutput = new NDIOutput(edNDIName.Text);
                            VideoEdit1.Network_Streaming_Output = ndiOutput;
                            edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}";

                            break;
                        }
                    case 4:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.UDP_FFMPEG_EXE;

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
                            VideoEdit1.Network_Streaming_Output = ffmpegOutput;

                            VideoEdit1.Network_Streaming_URL = edNetworkUDPURL.Text;

                            break;
                        }
                    case 5:
                        {
                            if (rbNetworkSSSoftware.IsChecked == true)
                            {
                                VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.SSF_H264_AAC_SW;
                            }
                            else
                            {
                                VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.SSF_FFMPEG_EXE;

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
                                VideoEdit1.Network_Streaming_Output = ffmpegOutput;
                            }

                            VideoEdit1.Network_Streaming_URL = edNetworkSSURL.Text;

                            break;
                        }
                    case 6:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.External;

                            break;
                        }
                    case 7:
                        {
                            VideoEdit1.Network_Streaming_Format = NetworkStreamingFormat.HLS;

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
                            VideoEdit1.Network_Streaming_Output = hls;

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
                }

                VideoEdit1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.IsChecked == true;
            }

            VideoEdit1.Output_Filename = edOutput.Text;

            VideoEditOutputFormat outputFormat = VideoEditOutputFormat.AVI;
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                    {
                        outputFormat = VideoEditOutputFormat.AVI;

                        var aviOutput = new AVIOutput();
                        SetAVIOutput(ref aviOutput);
                        VideoEdit1.Output_Format = aviOutput;

                        break;
                    }
                case 1:
                    {
                        outputFormat = VideoEditOutputFormat.MKVv1;

                        var mkvOutput = new MKVv1Output();
                        SetMKVOutput(ref mkvOutput);
                        VideoEdit1.Output_Format = mkvOutput;

                        break;
                    }
                case 2:
                    {
                        outputFormat = VideoEditOutputFormat.WMV;

                        var wmvOutput = new WMVOutput();
                        SetWMVOutput(ref wmvOutput);
                        VideoEdit1.Output_Format = wmvOutput;

                        break;
                    }
                case 3:
                    {
                        outputFormat = VideoEditOutputFormat.DV;

                        var dvOutput = new DVOutput();
                        SetDVOutput(ref dvOutput);
                        VideoEdit1.Output_Format = dvOutput;

                        break;
                    }
                case 4:
                    {
                        outputFormat = VideoEditOutputFormat.PCM_ACM;

                        var acmOutput = new ACMOutput();
                        SetACMOutput(ref acmOutput);
                        VideoEdit1.Output_Format = acmOutput;

                        break;
                    }
                case 5:
                    {
                        outputFormat = VideoEditOutputFormat.MP3;

                        var mp3Output = new MP3Output();
                        SetMP3Output(ref mp3Output);
                        VideoEdit1.Output_Format = mp3Output;

                        break;
                    }
                case 6:
                    {
                        outputFormat = VideoEditOutputFormat.M4A;

                        var m4aOutput = new M4AOutput();
                        SetM4AOutput(ref m4aOutput);
                        VideoEdit1.Output_Format = m4aOutput;

                        break;
                    }
                case 7:
                    {
                        outputFormat = VideoEditOutputFormat.WMA;

                        var wmaOutput = new WMAOutput();
                        SetWMAOutput(ref wmaOutput);
                        VideoEdit1.Output_Format = wmaOutput;

                        break;
                    }
                case 8:
                    {
                        outputFormat = VideoEditOutputFormat.OggVorbis;

                        var oggVorbisOutput = new OGGVorbisOutput();
                        SetOGGOutput(ref oggVorbisOutput);
                        VideoEdit1.Output_Format = oggVorbisOutput;

                        break;
                    }
                case 9:
                    {
                        outputFormat = VideoEditOutputFormat.FLAC;

                        var flacOutput = new FLACOutput();
                        SetFLACOutput(ref flacOutput);
                        VideoEdit1.Output_Format = flacOutput;

                        break;
                    }
                case 10:
                    {
                        outputFormat = VideoEditOutputFormat.Speex;

                        var speexOutput = new SpeexOutput();
                        SetSpeexOutput(ref speexOutput);
                        VideoEdit1.Output_Format = speexOutput;

                        break;
                    }
                case 11:
                    {
                        outputFormat = VideoEditOutputFormat.Custom;

                        var customOutput = new CustomOutput();
                        SetCustomOutput(ref customOutput);
                        VideoEdit1.Output_Format = customOutput;

                        break;
                    }
                case 12:
                    {
                        outputFormat = VideoEditOutputFormat.WebM;

                        var webmOutput = new WebMOutput();
                        SetWebMOutput(ref webmOutput);
                        VideoEdit1.Output_Format = webmOutput;

                        break;
                    }
                case 13:
                    {
                        outputFormat = VideoEditOutputFormat.FFMPEG;

                        var ffmpegOutput = new FFMPEGOutput();
                        SetFFMPEGOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;

                        break;
                    }
                case 14:
                    {
                        outputFormat = VideoEditOutputFormat.FFMPEG_EXE;

                        var ffmpegOutput = new FFMPEGEXEOutput();
                        SetFFMPEGEXEOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;

                        break;
                    }
                case 15:
                    outputFormat = VideoEditOutputFormat.MP4;
                    break;
                case 16:
                    {
                        outputFormat = VideoEditOutputFormat.MP4_HW;

                        var mp4Output = new MP4HWOutput();
                        SetMP4HWOutput(ref mp4Output);
                        VideoEdit1.Output_Format = mp4Output;

                        break;
                    }
                case 17:
                    {
                        outputFormat = VideoEditOutputFormat.AnimatedGIF;
                        var gifOutput = new AnimatedGIFOutput();
                        SetGIFOutput(ref gifOutput);
                        VideoEdit1.Output_Format = gifOutput;
                        break;
                    }
                case 18:
                    outputFormat = VideoEditOutputFormat.Encrypted;
                    break;
            }

            if ((outputFormat == VideoEditOutputFormat.MP4) ||
((outputFormat == VideoEditOutputFormat.Encrypted) && (rbEncryptedH264SW.IsChecked == true)) ||
                    (VideoEdit1.Network_Streaming_Enabled && (VideoEdit1.Network_Streaming_Format == NetworkStreamingFormat.RTSP_H264_AAC_SW)))
            {
                var mp4Output = new MP4Output();
                SetMP4Output(ref mp4Output);

                // encryption
                if (outputFormat == VideoEditOutputFormat.Encrypted)
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
                        mp4Output.Encryption_Key = VideoEdit1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
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

                VideoEdit1.Output_Format = mp4Output;
            }

            VideoEdit1.Audio_Preview_Enabled = true;

            // Audio enhancement
            VideoEdit1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.IsChecked == true;
            if (VideoEdit1.Audio_Enhancer_Enabled)
            {
                await VideoEdit1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.IsChecked == true);
                await VideoEdit1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.IsChecked == true);

                await ApplyAudioInputGainsAsync();
                await ApplyAudioOutputGainsAsync();

                await VideoEdit1.Audio_Enhancer_TimeshiftAsync(-1, (int)tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.IsChecked == true)
            {
                VideoEdit1.Audio_Channel_Mapper = new AudioChannelMapperSettings
                {
                    Routes = audioChannelMapperItems.ToArray(),
                    OutputChannelsCount =
                                                              Convert.ToInt32(edAudioChannelMapperOutputChannels.Text)
                };
            }
            else
            {
                VideoEdit1.Audio_Channel_Mapper = null;
            }

            // Audio processing
            VideoEdit1.Audio_Effects_Clear(-1);
            VideoEdit1.Audio_Effects_Enabled = cbAudioEffectsEnabled.IsChecked == true;
            if (VideoEdit1.Audio_Effects_Enabled)
            {
                VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Amplify, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Equalizer, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.DynamicAmplify, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.Sound3D, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, AudioEffectType.TrueBass, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true, TimeSpan.Zero, TimeSpan.Zero);

                tbAudAmplifyAmp_Scroll(sender, null);
                tbAudDynAmp_Scroll(sender, null);
                tbAudAttack_Scroll(sender, null);
                tbAudRelease_Scroll(sender, null);
                tbAud3DSound_Scroll(sender, null);
                tbAudTrueBass_Scroll(sender, null);

                tbAudEq0_Scroll(sender, null);
                tbAudEq1_Scroll(sender, null);
                tbAudEq2_Scroll(sender, null);
                tbAudEq3_Scroll(sender, null);
                tbAudEq4_Scroll(sender, null);
                tbAudEq5_Scroll(sender, null);
                tbAudEq6_Scroll(sender, null);
                tbAudEq7_Scroll(sender, null);
                tbAudEq8_Scroll(sender, null);
                tbAudEq9_Scroll(sender, null);
            }

            // Virtual camera output
            VideoEdit1.Virtual_Camera_Output_Enabled = cbVirtualCamera.IsChecked == true;

            // Video effects CPU
            AddVideoEffects();

            // Video effects GPU
            VideoEdit1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.IsChecked == true;

            // Chromakey
            ConfigureChromaKey();

            // Object detection
            ConfigureObjectDetection();

            VideoEdit1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.IsChecked == true;

            // Barcode detection
            VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.IsChecked == true;
            VideoEdit1.Barcode_Reader_Type = (BarcodeType)cbBarcodeType.SelectedIndex;

            // Decklink output
            ConfigureDecklinkOutput();

            // motion detection
            ConfigureMotionDetection();

            // video rotation
            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    VideoEdit1.Video_Rotation = RotateMode.RotateNone;
                    break;
                case 1:
                    VideoEdit1.Video_Rotation = RotateMode.Rotate90;
                    break;
                case 2:
                    VideoEdit1.Video_Rotation = RotateMode.Rotate180;
                    break;
                case 3:
                    VideoEdit1.Video_Rotation = RotateMode.Rotate270;
                    break;
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

                VideoEdit1.Tags = tags;
            }

            await VideoEdit1.StartAsync();

            lbTransitions.Items.Clear();

            edNetworkURL.Text = VideoEdit1.Network_Streaming_URL;
        }

        /// <summary>
        /// Configures and adds video effects to the engine.
        /// </summary>
        private void AddVideoEffects()
        {
            VideoEdit1.Video_Effects_Enabled = cbEffects.IsChecked == true;

            // Deinterlace
            if (cbDeinterlace.IsChecked == true)
            {
                if (rbDeintBlendEnabled.IsChecked == true)
                {
                    IVideoEffectDeinterlaceBlend blend;
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceBlend");
                    if (effect == null)
                    {
                        blend = new VideoEffectDeinterlaceBlend(true);
                        VideoEdit1.Video_Effects_Add(blend);
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
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VideoEffectDeinterlaceCAVT(rbDeintCAVTEnabled.IsChecked == true, Convert.ToInt32(edDeintCAVTThreshold.Text));
                        VideoEdit1.Video_Effects_Add(cavt);
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
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceTriangle");
                    if (effect == null)
                    {
                        triangle = new VideoEffectDeinterlaceTriangle(true, Convert.ToByte(edDeintTriangleWeight.Text));
                        VideoEdit1.Video_Effects_Add(triangle);
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
                if (rbDenoiseCAST.IsChecked == true)
                {
                    IVideoEffectDenoiseCAST cast;
                    var effect = VideoEdit1.Video_Effects_Get("DenoiseCAST");
                    if (effect == null)
                    {
                        cast = new VideoEffectDenoiseCAST(true);
                        VideoEdit1.Video_Effects_Add(cast);
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
                    var effect = VideoEdit1.Video_Effects_Get("DenoiseMosquito");
                    if (effect == null)
                    {
                        mosquito = new VideoEffectDenoiseMosquito(true);
                        VideoEdit1.Video_Effects_Add(mosquito);
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
                CbFlipX_Checked(null, null);
            }

            if (cbFlipY.IsChecked == true)
            {
                CbFlipY_Checked(null, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video editing engine and resets UI state.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.StopAsync();

            pbProgress.Value = 0;

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();

            VideoEdit1.Video_Effects_Clear();

            lbImageLogos.Items.Clear();
            lbTextLogos.Items.Clear();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbGreyscale control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectGrayscale grayscale;
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
                VideoEdit1.Video_Effects_Add(grayscale);
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
        /// Handles the CheckedChanged event of the cbInvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
        {
            IVideoEffectInvert invert;
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VideoEffectInvert(cbInvert.IsChecked == true);
                VideoEdit1.Video_Effects_Add(invert);
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
        /// Handles the SelectedIndexChanged event of the cbFilters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbFilters_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                string name = cbFilters.Text;
                btFilterSettings.IsEnabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                    FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
            }
        }

        /// <summary>
        /// Handles the Click event of the btFilterAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                VideoEdit1.Video_Filters_Add(new CustomProcessingFilter(cbFilters.Text));
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

        /// <summary>
        /// Handles the Click event of the btFilterSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the Click event of the btFilterSettings2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the Click event of the btFilterDeleteAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btFilterDeleteAll_Click(object sender, RoutedEventArgs e)
        {
            lbFilters.Items.Clear();
            VideoEdit1.Video_Filters_Clear();
        }

        /// <summary>
        /// Handles the Click event of the btAudEqRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudEqRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbAudEq0.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 0);
            tbAudEq1.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 1);
            tbAudEq2.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 2);
            tbAudEq3.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 3);
            tbAudEq4.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 4);
            tbAudEq5.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 5);
            tbAudEq6.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 6);
            tbAudEq7.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 7);
            tbAudEq8.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 8);
            tbAudEq9.Value = VideoEdit1.Audio_Effects_Equalizer_Band_Get(-1, AUDIO_EFFECT_ID_EQ, 9);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbAudAmplifyEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbAudDynamicAmplifyEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudDynamicAmplifyEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbAudEqualizerEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudEqualizerEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cbAudEqualizerPreset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbAudSound3DEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudSound3DEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbAudTrueBassEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAudTrueBassEnabled_CheckedChanged(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.IsChecked == true);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAud3DSound control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAud3DSound_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1?.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, (ushort)tbAud3DSound.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudDynAmp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudDynAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e) //-V3013
        {
            VideoEdit1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudAttack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudAttack_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (int)tbAudAttack.Value, (int)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq0 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq0_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, (sbyte)tbAudEq0.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq1_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, (sbyte)tbAudEq1.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq2_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, (sbyte)tbAudEq2.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq3_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, (sbyte)tbAudEq3.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq4 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq4_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, (sbyte)tbAudEq4.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq5 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq5_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, (sbyte)tbAudEq5.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq6 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq6_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, (sbyte)tbAudEq6.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq7 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq7_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, (sbyte)tbAudEq7.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq8 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq8_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, (sbyte)tbAudEq8.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudEq9 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudEq9_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, (sbyte)tbAudEq9.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudTrueBass control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudTrueBass_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, false, (ushort)tbAudTrueBass.Value);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbContrast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectContrast contrast;
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
                VideoEdit1.Video_Effects_Add(contrast);
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
        /// Handles the ValueChanged event of the tbDarkness control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbDarkness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectDarkness darkness;
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
                VideoEdit1.Video_Effects_Add(darkness);
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
        /// Handles the ValueChanged event of the tbLightness control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbLightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IVideoEffectLightness lightness;
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
                VideoEdit1.Video_Effects_Add(lightness);
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
        /// Handles the ValueChanged event of the tbSaturation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 != null)
            {
                IVideoEffectSaturation saturation;
                var effect = VideoEdit1.Video_Effects_Get("Saturation");
                if (effect == null)
                {
                    saturation = new VideoEffectSaturation((int)tbSaturation.Value);
                    VideoEdit1.Video_Effects_Add(saturation);
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

        /// <summary>
        /// Configures the Chroma Key settings.
        /// </summary>
        private void ConfigureChromaKey()
        {
            if (VideoEdit1.ChromaKey != null)
            {
                VideoEdit1.ChromaKey.Dispose();
                VideoEdit1.ChromaKey = null;
            }

            if (cbChromaKeyEnabled.IsChecked == true)
            {
                if (!File.Exists(edChromaKeyImage.Text))
                {
                    MessageBox.Show(this, "Chroma-key background file doesn't exists.");
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

        /// <summary>
        /// Configures the Decklink output settings.
        /// </summary>
        private void ConfigureDecklinkOutput()
        {
            if (cbDecklinkOutput.IsChecked == true)
            {
                VideoEdit1.Decklink_Output = new DecklinkOutputSettings
                {
                    DVEncoding = cbDecklinkDV.IsChecked == true,
                    AnalogOutputIREUSA = cbDecklinkOutputNTSC.SelectedIndex == 0,
                    AnalogOutputSMPTE = cbDecklinkOutputComponentLevels.SelectedIndex == 0,
                    BlackToDeckInCapture = (DecklinkBlackToDeckInCapture)cbDecklinkOutputBlackToDeck.SelectedIndex,
                    DualLinkOutputMode = (DecklinkDualLinkMode)cbDecklinkOutputDualLink.SelectedIndex,
                    HDTVPulldownOnOutput = (DecklinkHDTVPulldownOnOutput)cbDecklinkOutputHDTVPulldown.SelectedIndex,
                    SingleFieldOutputForSynchronousFrames = (DecklinkSingleFieldOutputForSynchronousFrames)cbDecklinkOutputSingleField.SelectedIndex,
                    VideoOutputDownConversionMode = (DecklinkVideoOutputDownConversionMode)cbDecklinkOutputDownConversion.SelectedIndex,
                    VideoOutputDownConversionModeAnalogUsed = cbDecklinkOutputDownConversionAnalogOutput.IsChecked == true,
                    AnalogOutput = (DecklinkAnalogOutput)cbDecklinkOutputAnalog.SelectedIndex
                };
            }
            else
            {
                VideoEdit1.Decklink_Output = null;
            }
        }

        /// <summary>
        /// Configures the object detection settings.
        /// </summary>
        private void ConfigureObjectDetection()
        {
            if (cbAFMotionDetection.IsChecked == true)
            {
                VideoEdit1.Motion_DetectionEx = new MotionDetectionExSettings();
                if (cbAFMotionHighlight.IsChecked == true)
                {
                    VideoEdit1.Motion_DetectionEx.ProcessorType = MotionProcessorType.MotionAreaHighlighting;
                }
                else
                {
                    VideoEdit1.Motion_DetectionEx.ProcessorType = MotionProcessorType.None;
                }
            }
            else
            {
                VideoEdit1.Motion_DetectionEx = null;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudAmplifyAmp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudAmplifyAmp_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1?.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, (int)tbAudAmplifyAmp.Value * 10, false);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudRelease control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbAudRelease_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1?.Audio_Effects_DynamicAmplify(
                -1, AUDIO_EFFECT_ID_DYN_AMPLIFY, (ushort)tbAudAttack.Value, (ushort)tbAudDynAmp.Value, (int)tbAudRelease.Value);
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the linkLabel1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void linkLabel1_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Closed event of the Window.
        /// Stops the engine and destroys resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Window_Closed(object sender, EventArgs e)
        {
            if (VideoEdit1 != null && VideoEdit1.State() == PlaybackState.Play)
            {
                await VideoEdit1.StopAsync();
            }

            DestroyEngine();
        }

        /// <summary>
        /// Handles the OnError event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher?.Invoke(() => { mmLog.Text = mmLog.Text + e.Message + Environment.NewLine; });
        }

        /// <summary>
        /// Handles the SelectionChanged event of the lbFilters control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the Checked event of the cbStretch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbStretch_Checked(object sender, RoutedEventArgs e)
        {
            if (cbStretch.IsChecked == true)
            {
                VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoEdit1.Video_Renderer.StretchMode = VideoRendererStretchMode.Letterbox;
            }

            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the OnProgress event of the VideoEdit1 control.
        /// Updates the progress bar.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ProgressEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Dispatcher?.Invoke(() => { pbProgress.Value = e.Progress; });

            // Application.DoEvents();
        }

        /// <summary>
        /// Delegate for the Stop event to be called on the UI thread.
        /// </summary>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        public delegate void StopDelegate(StopEventArgs e);

        /// <summary>
        /// Handles the Stop event on the UI thread.
        /// Resets the progress bar and shows a message box.
        /// </summary>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        public void StopDelegateMethod(StopEventArgs e)
        {
            pbProgress.Value = 0;
            if (e.Successful)
            {
                MessageBox.Show(this, "Completed successfully");
            }
            else
            {
                MessageBox.Show(this, "Stopped with error");
            }

            VideoEdit1.Input_Clear_List();
            lbFiles.Items.Clear();

            VideoEdit1.Video_Transition_Clear();
            lbTransitions.Items.Clear();

            VideoEdit1.Video_Effects_Clear();

            lbImageLogos.Items.Clear();
            lbTextLogos.Items.Clear();
        }

        /// <summary>
        /// Handles the OnStop event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher?.BeginInvoke(new StopDelegate(StopDelegateMethod), e);
        }

        /// <summary>
        /// Handles the OnStart event of the VideoEdit1 control.
        /// Sets the maximum value for the seeking slider.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnStart(object sender, EventArgs e)
        {
            Dispatcher?.Invoke(() => { tbSeeking.Maximum = (int)VideoEdit1.Duration().TotalMilliseconds; });
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile control.
        /// Opens a file dialog and adds the selected file(s) to the input list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btAddInputFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                VideoEdit1.Video_FrameRate = new VideoFrameRate(Convert.ToDouble(cbFrameRate.Text, CultureInfo.InvariantCulture));

                // resize if required
                int customWidth = 0;
                int customHeight = 0;

                if (cbResize.IsChecked == true)
                {
                    customWidth = Convert.ToInt32(edWidth.Text);
                    customHeight = Convert.ToInt32(edHeight.Text);
                }

                string s = openFileDialog1.FileName;

                lbFiles.Items.Add(s);

                if ((string.Compare(GetFileExt(s), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".PNG", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), null, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(2000), TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)), null, VideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddImageFileAsync(
                                s,
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)),
                                VideoEditStretchMode.Letterbox,
                                0,
                                customWidth,
                                customHeight);
                        }
                    }
                }
                else if ((string.Compare(GetFileExt(s), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        var audioFile = new AudioSource(s, null, null, string.Empty, 0, tbSpeed.Value / 100.0);
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0);
                        }
                    }
                    else
                    {
                        var audioFile = new AudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), string.Empty, 0, tbSpeed.Value / 100.0);
                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0);
                        }
                    }
                }
                else
                {
                    if (cbAddFullFile.IsChecked == true)
                    {
                        var videoFile = new VideoSource(
                                s, null, null, VideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0);
                        var audioFile = new AudioSource(s, null, null, string.Empty, 0, tbSpeed.Value / 100.0);

                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0);
                        }
                    }
                    else
                    {
                        var videoFile = new VideoSource(
                                s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), VideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0);
                        var audioFile = new AudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), string.Empty, 0, tbSpeed.Value / 100.0);

                        if (cbInsertAfterPreviousFile.IsChecked == true)
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds(Convert.ToInt32(edInsertTime.Text)), 0);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btClearList control.
        /// Clears the input list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btClearList_Click(object sender, RoutedEventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbSpeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbSpeed != null)
            {
                lbSpeed.Content = Convert.ToInt32(tbSpeed.Value) + "%";
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbSeeking control.
        /// Updates the playback position.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbSeeking_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoEdit1?.Position_Set(TimeSpan.FromMilliseconds(tbSeeking.Value));
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbChromaKeyContrastLow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbChromaKeyContrastLow_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //-V3013
        {
            if (VideoEdit1 != null)
            {
                ConfigureChromaKey();
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbChromaKeyContrastHigh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbChromaKeyContrastHigh_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 != null)
            {
                ConfigureChromaKey();
            }
        }

        /// <summary>
        /// Handles the Click event of the btChromaKeySelectBGImage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btChromaKeySelectBGImage_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edChromaKeyImage.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Checked event of the cbAFMotionHighlight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAFMotionHighlight_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureObjectDetection();
        }

        /// <summary>
        /// Handles the Checked event of the cbAFMotionDetection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbAFMotionDetection_Checked(object sender, RoutedEventArgs e)
        {
            ConfigureObjectDetection();
        }

        /// <summary>
        /// Handles the OnObjectDetection event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MotionDetectionExEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnObjectDetection(object sender, MotionDetectionExEventArgs e)
        {
            Dispatcher?.BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        /// <summary>
        /// Delegate for the AF motion event to be called on the UI thread.
        /// </summary>
        /// <param name="level">The motion level.</param>
        public delegate void AFMotionDelegate(float level);

        /// <summary>
        /// Handles the AF motion event on the UI thread.
        /// Updates the motion level progress bar.
        /// </summary>
        /// <param name="level">The motion level.</param>
        public void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        /// <summary>
        /// Configures the motion detection settings.
        /// </summary>
        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.IsChecked == true)
            {
                VideoEdit1.Motion_Detection = new MotionDetectionSettings
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
                VideoEdit1.MotionDetection_Update();
            }
            else
            {
                VideoEdit1.Motion_Detection = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btMotDetUpdateSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMotDetUpdateSettings_Click(object sender, RoutedEventArgs e)
        {
            ConfigureMotionDetection();
        }

        /// <summary>
        /// Delegate for the motion detection event to be called on the UI thread.
        /// </summary>
        /// <param name="e">The <see cref="MotionDetectionEventArgs"/> instance containing the event data.</param>
        public delegate void MotionDelegate(MotionDetectionEventArgs e);

        /// <summary>
        /// Handles the motion detection event on the UI thread.
        /// Updates the motion matrix text and motion level progress bar.
        /// </summary>
        /// <param name="e">The <see cref="MotionDetectionEventArgs"/> instance containing the event data.</param>
        public void MotionDelegateMethod(MotionDetectionEventArgs e)
        {
            string s = string.Empty;
            int k = 0;
            foreach (byte b in e.Matrix)
            {
                s += b.ToString("D3") + " ";

                if (k == VideoEdit1.Motion_Detection.Matrix_Width - 1)
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

        /// <summary>
        /// Handles the OnMotion event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MotionDetectionEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            Dispatcher?.BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        /// <summary>
        /// Handles the Checked event of the cbZoomEnabled control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbZoomEnabled_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectZoom zoomEffect;
            var effect = VideoEdit1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoomEnabled.IsChecked == true);
                VideoEdit1.Video_Effects_Add(zoomEffect);
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
        /// Handles the Click event of the btEffZoomIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomIn_Click(object sender, RoutedEventArgs e)
        {
            zoom += 0.1;
            zoom = Math.Min(zoom, 5);

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Click event of the btEffZoomOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomOut_Click(object sender, RoutedEventArgs e)
        {
            zoom -= 0.1;
            zoom = Math.Max(zoom, 1);

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Click event of the btEffZoomShiftUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY += 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Click event of the btEffZoomShiftDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftY -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Click event of the btEffZoomShiftRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX += 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Click event of the btEffZoomShiftLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEffZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            zoomShiftX -= 20;

            cbZoomEnabled_Checked(null, null);
        }

        /// <summary>
        /// Handles the Checked event of the cbPan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbPan_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectPan pan;
            var effect = VideoEdit1.Video_Effects_Get("Pan");
            if (effect == null)
            {
                pan = new VideoEffectPan(true);
                VideoEdit1.Video_Effects_Add(pan);
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

        #region Barcode detector

        /// <summary>
        /// Delegate for the barcode detected event to be called on the UI thread.
        /// </summary>
        /// <param name="value">The <see cref="BarcodeEventArgs"/> instance containing the event data.</param>
        public delegate void BarcodeDelegate(BarcodeEventArgs value);

        /// <summary>
        /// Handles the barcode detected event on the UI thread.
        /// Updates the barcode text and metadata.
        /// </summary>
        /// <param name="value">The <see cref="BarcodeEventArgs"/> instance containing the event data.</param>
        public void BarcodeDelegateMethod(BarcodeEventArgs value)
        {
            edBarcode.Text = value.Value;
            edBarcodeMetadata.Text = string.Empty;
            foreach (var o in value.Metadata)
            {
                edBarcodeMetadata.Text += o.Key + ": " + o.Value + Environment.NewLine;
            }
        }

        /// <summary>
        /// Handles the OnBarcodeDetected event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="BarcodeEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnBarcodeDetected(object sender, BarcodeEventArgs e)
        {
            e.DetectorEnabled = false;

            Dispatcher?.BeginInvoke(new BarcodeDelegate(BarcodeDelegateMethod), e);
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btBarcodeReset control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btBarcodeReset_Click(object sender, RoutedEventArgs e)
        {
            edBarcode.Text = string.Empty;
            edBarcodeMetadata.Text = string.Empty;
            VideoEdit1.Barcode_Reader_Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btSelectWMVProfileNetwork control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectWMVProfileNetwork_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        
        /// <summary>
        /// Handles the Click event of the btRefreshClients control.
        /// Refreshes the list of network streaming clients.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btRefreshClients_Click(object sender, RoutedEventArgs e)
        {
            lbNetworkClients.Items.Clear();

            for (int i = 0; i < VideoEdit1.Network_Streaming_WMV_Clients_GetCount(); i++)
            {
                string dns;
                string address;
                int port;
                VideoEdit1.Network_Streaming_WMV_Clients_GetInfo(i, out port, out address, out dns);

                string client = "ID: " + i + ", Port: " + port + ", Address: " + address + ", DNS: " + dns;
                lbNetworkClients.Items.Add(client);
            }
        }

        /// <summary>
        /// Handles the Checked event of the cbFadeInOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbFadeInOut_Checked(object sender, RoutedEventArgs e)
        {
            if (rbFadeIn.IsChecked == true)
            {
                IVideoEffectFadeIn fadeIn;
                var effect = VideoEdit1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VideoEffectFadeIn(cbFadeInOut.IsChecked == true);
                    VideoEdit1.Video_Effects_Add(fadeIn);
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
                var effect = VideoEdit1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VideoEffectFadeOut(cbFadeInOut.IsChecked == true);
                    VideoEdit1.Video_Effects_Add(fadeOut);
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
        /// Handles the MouseLeftButtonDown event of the label1291 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void label1291_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the Label control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder);
            Process.Start(startInfo);
        }

        #region Full screen

        /// <summary>
        /// Full screen flag.
        /// </summary>
        private bool fullScreen;

        /// <summary>
        /// Previous window left.
        /// </summary>
        private double windowLeft;

        /// <summary>
        /// Previous window top.
        /// </summary>
        private double windowTop;

        /// <summary>
        /// Previous window width.
        /// </summary>
        private double windowWidth;

        /// <summary>
        /// Previous window height.
        /// </summary>
        private double windowHeight;

        /// <summary>
        /// Previous control margin.
        /// </summary>
        private Thickness controlMargin;

        /// <summary>
        /// Previous control width.
        /// </summary>
        private double controlWidth;

        /// <summary>
        /// Previous control height.
        /// </summary>
        private double controlHeight;

        /// <summary>
        /// Handles the Click event of the btFullScreen control.
        /// Toggles full screen mode for the video renderer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
                VideoView1.Margin = new Thickness(0);
                VideoView1.Width = Screen.AllScreens[0].Bounds.Width / dpi.DpiScaleX;
                VideoView1.Height = Screen.AllScreens[0].Bounds.Height / dpi.DpiScaleY;

                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoView1.Margin = controlMargin;
                VideoView1.Width = controlWidth;
                VideoView1.Height = controlHeight;
                VideoView1.RenderSize = new System.Windows.Size(controlWidth, controlHeight);

                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                Topmost = false;
                ResizeMode = ResizeMode.CanResize;

                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the VideoView1 control.
        /// Exits full screen mode if active.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void VideoView1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the label1291_Copy control to open IIS Smooth Streaming documentation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void label1291_Copy_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.IISSmoothStreaming);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile2 control to select the source file for cutting.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAddInputFile2_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                string s = openFileDialog1.FileName;

                edSourceFileToCut.Text = s;

                string extNew = Path.GetExtension(s).ToLowerInvariant();
                string extOld = Path.GetExtension(edOutputFileCut.Text).ToLowerInvariant();
                if (!string.IsNullOrEmpty(extOld))
                {
                    edOutputFileCut.Text = edOutputFileCut.Text.Replace(extOld, extNew);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btAddInputFile3 control to add files to the join list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAddInputFile3_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                string s = openFileDialog1.FileName;
                lbFiles2.Items.Add(s);

                edSourceFileToCut.Text = s;

                string extNew = Path.GetExtension(s).ToLowerInvariant();
                string extOld = Path.GetExtension(edOutputFileJoin.Text).ToLowerInvariant();
                if (!string.IsNullOrEmpty(extOld))
                {
                    edOutputFileJoin.Text = edOutputFileJoin.Text.Replace(extOld, extNew);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btClearList3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btClearList3_Click(object sender, RoutedEventArgs e)
        {
            lbFiles2.Items.Clear();
        }

        /// <summary>
        /// Handles the Checked event of the cbScreenFlipVertical control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbScreenFlipVertical_Checked(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.IsChecked == true;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Checked event of the cbScreenFlipHorizontal control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbScreenFlipHorizontal_Checked(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.IsChecked == true;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbDirect2DRotate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbDirect2DRotate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name = ((ComboBoxItem)e.AddedItems[0]).Content.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(name);
                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Handles the Click event of the btZoomShiftUp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftUp_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_ShiftY = VideoEdit1.Video_Renderer.Zoom_ShiftY + 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Click event of the btZoomShiftRight control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftRight_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_ShiftX = VideoEdit1.Video_Renderer.Zoom_ShiftX + 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Click event of the btZoomShiftLeft control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftLeft_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_ShiftX = VideoEdit1.Video_Renderer.Zoom_ShiftX - 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Click event of the btZoomShiftDown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomShiftDown_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_ShiftY = VideoEdit1.Video_Renderer.Zoom_ShiftY - 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Click event of the btZoomOut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_Ratio = VideoEdit1.Video_Renderer.Zoom_Ratio - 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the Click event of the btZoomIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Video_Renderer.Zoom_Ratio = VideoEdit1.Video_Renderer.Zoom_Ratio + 10;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        /// <summary>
        /// Handles the MouseDown event of the pnVideoRendererBGColor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private async void pnVideoRendererBGColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnVideoRendererBGColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnVideoRendererBGColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
                VideoView1.Background = pnVideoRendererBGColor.Fill;

                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Handles the Checked event of the rbVR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the Click event of the btAddTransition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAddTransition_Click(object sender, RoutedEventArgs e)
        {
            // get id
            int id = VideoEdit1.Video_Transition_GetIDFromName(cbTransitionName.Text);

            // add transition
            VideoEdit1.Video_Transition_Add(TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStopTime.Text)), id);

            // add to list
            lbTransitions.Items.Add(cbTransitionName.Text +
            "(Start: " + edTransStartTime.Text + ", stop: " + edTransStopTime.Text + ")");
        }

        /// <summary>
        /// Handles the Checked event of the cbAudioNormalize control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioNormalize_Checked(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.Audio_Enhancer_NormalizeAsync(-1, cbAudioNormalize.IsChecked == true);
        }

        /// <summary>
        /// Handles the Checked event of the cbAudioAutoGain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioAutoGain_Checked(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.Audio_Enhancer_AutoGainAsync(-1, cbAudioAutoGain.IsChecked == true);
        }

        /// <summary>
        /// Applies the audio input gains.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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

            await VideoEdit1.Audio_Enhancer_InputGainsAsync(-1, gains);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainL.Content = (tbAudioInputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainC.Content = (tbAudioInputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainR.Content = (tbAudioInputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainSL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSL.Content = (tbAudioInputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainSR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainSR.Content = (tbAudioInputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioInputGainLFE control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioInputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioInputGainLFE.Content = (tbAudioInputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioInputGainsAsync();
        }

        /// <summary>
        /// Applies the audio output gains.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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

            await VideoEdit1.Audio_Enhancer_OutputGainsAsync(-1, gains);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainL.Content = (tbAudioOutputGainL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainC_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainC.Content = (tbAudioOutputGainC.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainR.Content = (tbAudioOutputGainR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainSL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainSL_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSL.Content = (tbAudioOutputGainSL.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainSR control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainSR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainSR.Content = (tbAudioOutputGainSR.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioOutputGainLFE control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioOutputGainLFE_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioOutputGainLFE.Content = (tbAudioOutputGainLFE.Value / 10.0f).ToString("F1");

            await ApplyAudioOutputGainsAsync();
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbAudioTimeshift control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbAudioTimeshift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbAudioTimeshift.Content = tbAudioTimeshift.Value.ToString(CultureInfo.InvariantCulture) + " ms";

            await VideoEdit1.Audio_Enhancer_TimeshiftAsync(-1, (int)tbAudioTimeshift.Value);
        }

        /// <summary>
        /// Delegate for the FFMPEG info event to be called on the UI thread.
        /// </summary>
        /// <param name="message">The info message.</param>
        public delegate void FFMPEGInfoDelegate(string message);

        /// <summary>
        /// Handles the FFMPEG info event on the UI thread.
        /// </summary>
        /// <param name="message">The info message.</param>
        public void FFMPEGInfoDelegateMethod(string message)
        {
            // if (VideoEdit1.Debug_Mode)
            // {

            mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine;

            // }
        }

        /// <summary>
        /// Handles the OnFFMPEGInfo event of the VideoEdit1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FFMPEGInfoEventArgs"/> instance containing the event data.</param>
        private void VideoEdit1_OnFFMPEGInfo(object sender, FFMPEGInfoEventArgs e)
        {
            Dispatcher?.Invoke(new FFMPEGInfoDelegate(FFMPEGInfoDelegateMethod), e.Message);
        }

        /// <summary>
        /// Handles the Click event of the btEncryptionOpenFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btEncryptionOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutputCut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutputCut_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutputFileCut.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStartCut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStartCut_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.FastEdit_CutFileAsync(
                edSourceFileToCut.Text,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTimeCut.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTimeCut.Text)),
                edOutputFileCut.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStopCut control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStopCut_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.FastEdit_StopAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStopJoin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStopJoin_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.FastEdit_StopAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStartJoin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btStartJoin_Click(object sender, RoutedEventArgs e)
        {
            List<string> files = new List<string>();
            foreach (var item in lbFiles2.Items)
            {
                files.Add(item.ToString());
            }

            VideoEdit1.FastEdit_JoinFilesAsync(
                files.ToArray(),
                edOutputFileCut.Text);
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutputJoin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutputJoin_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutputFileJoin.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the Grid control to set a cover image for tags.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (openFileDialog2.ShowDialog() == true)
            {
                imgTagCover.Source = new BitmapImage(new Uri(openFileDialog2.FileName));
                imgTagCover.Tag = openFileDialog2.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btMuxStreamsSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMuxStreamsSelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edMuxStreamsSourceFile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btMuxStreamsAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMuxStreamsAdd_Click(object sender, RoutedEventArgs e)
        {
            string prefix;
            if (cbMuxStreamsType.SelectedIndex == 0)
            {
                prefix = "v";
            }
            else if (cbMuxStreamsType.SelectedIndex == 1)
            {
                prefix = "a";
            }
            else
            {
                prefix = cbMuxStreamsType.Text;
            }

            lbMuxStreamsList.Items.Add(prefix + ": " + edMuxStreamsSourceFile.Text);
        }

        /// <summary>
        /// Handles the Click event of the btMuxStreamsClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMuxStreamsClear_Click(object sender, RoutedEventArgs e)
        {
            lbMuxStreamsList.Items.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btMuxStreamsSelectOutput control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btMuxStreamsSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edMuxStreamsOutputFile.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStopMux control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStopMux_Click(object sender, RoutedEventArgs e)
        {
            await VideoEdit1.FastEdit_StopAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStartMux control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStartMux_Click(object sender, RoutedEventArgs e)
        {
            var streams = new List<FFMPEGStream>();

            foreach (string item in lbMuxStreamsList.Items)
            {
                string prefix = item.Substring(0, 1);
                string filename = item.Substring(3);

                streams.Add(new FFMPEGStream
                {
                    Filename = filename,
                    ID = prefix
                });
            }

            await VideoEdit1.FastEdit_MuxStreamsAsync(streams, cbMuxStreamsShortest.IsChecked == true, edMuxStreamsOutputFile.Text);
        }

        /// <summary>
        /// Handles the Click event of the cbDebugMode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbDebugMode_Click(object sender, RoutedEventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.IsChecked == true;
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the lbDownloadFFMPEG_Copy3 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void lbDownloadFFMPEG_Copy3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Click event of the btAudioChannelMapperClear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btAudioChannelMapperClear_Click(object sender, RoutedEventArgs e)
        {
            audioChannelMapperItems.Clear();
            lbAudioChannelMapperRoutes.Items.Clear();
        }

        /// <summary>
        /// Handles the Click event of the btAudioChannelMapperAddNewRoute control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
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
        /// Handles the Click event of the btSubtitlesSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSubtitlesSelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edSubtitlesFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbGPULightness control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPULightness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null)
            {
                return;
            }

            IGPUVideoEffectBrightness intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new GPUVideoEffectBrightness(true, (int)tbGPULightness.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the ValueChanged event of the tbGPUSaturation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUSaturation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null)
            {
                return;
            }

            IGPUVideoEffectSaturation intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new GPUVideoEffectSaturation(true, (int)tbGPUSaturation.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the ValueChanged event of the tbGPUContrast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUContrast_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null)
            {
                return;
            }

            IGPUVideoEffectContrast intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new GPUVideoEffectContrast(true, (int)tbGPUContrast.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the ValueChanged event of the tbGPUDarkness control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbGPUDarkness_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoEdit1 == null)
            {
                return;
            }

            IGPUVideoEffectDarkness intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new GPUVideoEffectDarkness(true, (int)tbGPUDarkness.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUGreyscale control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUGreyscale_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectGrayscale intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new GPUVideoEffectGrayscale(cbGPUGreyscale.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUInvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUInvert_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectInvert intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new GPUVideoEffectInvert(cbGPUInvert.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUNightVision control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUNightVision_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectNightVision intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new GPUVideoEffectNightVision(cbGPUNightVision.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUPixelate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUPixelate_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectPixelate intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new GPUVideoEffectPixelate(cbGPUPixelate.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUDenoise control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUDenoise_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDenoise intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new GPUVideoEffectDenoise(cbGPUDenoise.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUDeinterlace control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUDeinterlace_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectDeinterlaceBlend intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new GPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the Click event of the cbGPUOldMovie control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void cbGPUOldMovie_Click(object sender, RoutedEventArgs e)
        {
            IGPUVideoEffectOldMovie intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new GPUVideoEffectOldMovie(cbGPUOldMovie.IsChecked == true);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the SelectionChanged event of the cbOutputVideoFormat control.
        /// Updates the output file extension based on the selected format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void CbOutputVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ogg");
                        break;
                    }
                case 9:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".flac");
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
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 13:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 14:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 15:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 16:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 17:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                        break;
                    }
                case 18:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".enc");
                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the Click event of the btOutputConfigure control.
        /// Opens the configuration dialog for the selected output video format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoEdit1);
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 2:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
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
                            pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1);
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
                            wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
                        }

                        wmvSettingsDialog.WMA = true;
                        wmvSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 8:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }

                        oggVorbisSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 9:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }

                        flacSettingsDialog.ShowDialog(this);

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
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1);
                        }

                        customFormatSettingsDialog.ShowDialog(this);

                        break;
                    }

                case 12:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 13:
                    {
                        if (ffmpegSettingsDialog == null)
                        {
                            ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }

                        ffmpegSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 14:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        ffmpegEXESettingsDialog.ShowDialog(this);

                        break;
                    }
                case 15:
                case 18:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
                case 16:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 17:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the Click event of the btTextLogoAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtTextLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VideoEffectTextLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
            lbTextLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the btTextLogoEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtTextLogoEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                var dlg = new TextLogoSettingsDialog();
                var effect = VideoEdit1.Video_Effects_Get((string)lbTextLogos.SelectedItem);
                dlg.Attach(effect);

                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        /// <summary>
        /// Handles the Click event of the btTextLogoRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtTextLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the btImageLogoAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtImageLogoAdd_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VideoEffectImageLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
            lbImageLogos.Items.Add(effect.Name);

            dlg.Fill(effect);
            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        /// <summary>
        /// Handles the Click event of the btImageLogoEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtImageLogoEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                var dlg = new ImageLogoSettingsDialog();
                var effect = VideoEdit1.Video_Effects_Get((string)lbImageLogos.SelectedItem);

                dlg.Attach(effect);
                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        /// <summary>
        /// Handles the Click event of the btImageLogoRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void BtImageLogoRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        private void CbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipDown flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
                VideoEdit1.Video_Effects_Add(flip);
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
        private void CbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            IVideoEffectFlipRight flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
                VideoEdit1.Video_Effects_Add(flip);
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
        /// Handles the ValueChanged event of the tbGPUBlur control to update the GPU blur effect.
        /// </summary>
        private void tbGPUBlur_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            IGPUVideoEffectBlur intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new GPUVideoEffectBlur(tbGPUBlur.Value > 0, (int)tbGPUBlur.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
        /// Handles the MouseDown event of the pnChromaKeyColor control to select the chroma key color.
        /// </summary>
        private void pnChromaKeyColor_MouseDown(object sender, MouseButtonEventArgs e)
        {
            colorDialog1.Color = ColorConv(((SolidColorBrush)pnChromaKeyColor.Fill).Color);

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnChromaKeyColor.Fill = new SolidColorBrush(ColorConv(colorDialog1.Color));
            }
        }

        /// <summary>
        /// Handles the MouseLeftButtonUp event of the lbNDI control to open NDI documentation.
        /// </summary>
        private void lbNDI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the MouseDown event of the llXiphX86 control to open Xiph x86 codecs documentation.
        /// </summary>
        private void llXiphX86_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx86);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the MouseDown event of the llXiphX64 control to open Xiph x64 codecs documentation.
        /// </summary>
        private void llXiphX64_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistXIPHx64);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Click event of the btSelectHLSOutputFolder control to select the HLS output directory.
        /// </summary>
        private void btSelectHLSOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edHLSOutputFolder.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the lbHLSConfigure control to open HLS streaming documentation.
        /// </summary>
        private void lbHLSConfigure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.HLSStreaming);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the MouseDown event of the llDecoders control to open LAV decoders documentation.
        /// </summary>
        private void llDecoders_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.RedistLAVx64);
            Process.Start(startInfo);
        }
    }
}

