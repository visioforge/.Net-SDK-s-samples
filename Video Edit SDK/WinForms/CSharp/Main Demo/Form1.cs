// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable UnusedParameter.Local



// ReSharper disable NotAccessedVariable
// ReSharper disable InlineOutVariableDeclaration

// ReSharper disable StringLiteralTypo
namespace VideoEdit_CS_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    using VisioForge.Controls.UI;
    using VisioForge.Controls.UI.Dialogs.OutputFormats;
    using VisioForge.Controls.UI.Dialogs.VideoEffects;
    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Tools;
    using VisioForge.Types;
    using VisioForge.Types.FFMPEGEXE;
    using VisioForge.Types.GPUVideoEffects;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.VideoEffects;

    using VFM4AOutput = VisioForge.Types.OutputFormat.VFM4AOutput;

    /// <summary>
    /// Main demo form.
    /// </summary>
    public partial class Form1 : Form
    {
        private const int AUDIO_EFFECT_ID_AMPLIFY = 0;
        
        private const int AUDIO_EFFECT_ID_EQ = 1;

        private const int AUDIO_EFFECT_ID_DYN_AMPLIFY = 2;

        private const int AUDIO_EFFECT_ID_SOUND_3D = 3;

        private const int AUDIO_EFFECT_ID_TRUE_BASS = 4;

        private const int AUDIO_EFFECT_ID_FADE_IN = 5;

        private const int AUDIO_EFFECT_ID_FADE_OUT = 6;

        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

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

        private readonly List<AudioChannelMapperItem> audioChannelMapperItems = new List<AudioChannelMapperItem>();

        // Zoom
        private double zoom = 1.0;

        private int zoomShiftX;

        private int zoomShiftY;

        public Form1()
        {
            InitializeComponent();
        }

        private static string GetFileExt(string filename)
        {
            int k = filename.LastIndexOf('.');
            return filename.Substring(k, filename.Length - k);
        }

        private void btClearList_Click(object sender, EventArgs e)
        {
            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
        }

        private async void btAddInputFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                VideoEdit1.Video_FrameRate = Convert.ToDouble(cbFrameRate.Text, CultureInfo.InvariantCulture);

                string s = OpenDialog1.FileName;

                lbFiles.Items.Add(s);

                // resize if required
                int customWidth = 0;
                int customHeight = 0;

                if (cbResize.Checked)
                {
                    customWidth = Convert.ToInt32(edWidth.Text);
                    customHeight = Convert.ToInt32(edHeight.Text);
                }

                if ((string.Compare(GetFileExt(s), ".BMP", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".JPEG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".GIF", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".PNG", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    if (cbAddFullFile.Checked)
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s,  TimeSpan.FromMilliseconds(2000), null, VFVideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds( 2000), TimeSpan.FromMilliseconds( Convert.ToInt32(edInsertTime.Text)), VFVideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                    }
                    else
                    {
                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            await VideoEdit1.Input_AddImageFileAsync(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)), null, VFVideoEditStretchMode.Letterbox, 0, customWidth, customHeight);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddImageFileAsync(
                                s,
                                TimeSpan.FromMilliseconds( Convert.ToInt32(edStopTime.Text) - Convert.ToInt32(edStartTime.Text)),
                                TimeSpan.FromMilliseconds( Convert.ToInt32(edInsertTime.Text)),
                                VFVideoEditStretchMode.Letterbox,
                                0,
                                customWidth,
                                customHeight);
                        }
                    }
                }
                else
                    if ((string.Compare(GetFileExt(s), ".WAV", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".MP3", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".OGG", StringComparison.OrdinalIgnoreCase) == 0) ||
                   (string.Compare(GetFileExt(s), ".WMA", StringComparison.OrdinalIgnoreCase) == 0))
                {
                    if (cbAddFullFile.Checked)
                    {
                        var audioFile = new VFVEAudioSource(s, null, null, string.Empty, 0, tbSpeed.Value / 100.0);
                        if (cbInsertAfterPreviousFile.Checked)
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
                        var audioFile = new VFVEAudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), string.Empty, 0, tbSpeed.Value / 100.0);
                        if (cbInsertAfterPreviousFile.Checked)
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
                    if (cbAddFullFile.Checked)
                    {
                        var videoFile = new VFVEVideoSource(
                                s, null, null, VFVideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0);
                        var audioFile = new VFVEAudioSource(s, null, null, string.Empty, 0, tbSpeed.Value / 100.0);

                        if (cbInsertAfterPreviousFile.Checked)
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, null, 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, null, 0);
                        }
                        else
                        {
                            await VideoEdit1.Input_AddVideoFileAsync(videoFile, TimeSpan.FromMilliseconds( Convert.ToInt32(edInsertTime.Text)), 0, customWidth, customHeight);
                            await VideoEdit1.Input_AddAudioFileAsync(audioFile, TimeSpan.FromMilliseconds( Convert.ToInt32(edInsertTime.Text)), 0);
                        }
                    }
                    else
                    {
                        var videoFile = new VFVEVideoSource(
                                s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), VFVideoEditStretchMode.Letterbox, 0, tbSpeed.Value / 100.0);
                        var audioFile = new VFVEAudioSource(s, TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTime.Text)), string.Empty, 0, tbSpeed.Value / 100.0);

                        if (cbInsertAfterPreviousFile.Checked)
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

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutput.Text = SaveDialog1.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += $" (SDK v{VideoEdit1.SDK_Version})";

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            edOutputFileCut.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            edOutputFileJoin.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            VideoEdit1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            cbMode.SelectedIndex = 1;
            cbFrameRate.SelectedIndex = 0;
            cbOutputVideoFormat.SelectedIndex = 15;
            cbMotDetHLColor.SelectedIndex = 1;
            cbRotate.SelectedIndex = 0;
            cbBarcodeType.SelectedIndex = 0;
            cbNetworkStreamingMode.SelectedIndex = 0;
            cbDirect2DRotate.SelectedIndex = 0;
            cbMuxStreamsType.SelectedIndex = 0;

            cbDecklinkOutputAnalog.SelectedIndex = 0;
            cbDecklinkOutputBlackToDeck.SelectedIndex = 0;
            cbDecklinkOutputComponentLevels.SelectedIndex = 0;
            cbDecklinkOutputDownConversion.SelectedIndex = 0;
            cbDecklinkOutputDualLink.SelectedIndex = 0;
            cbDecklinkOutputHDTVPulldown.SelectedIndex = 0;
            cbDecklinkOutputNTSC.SelectedIndex = 0;

            pnChromaKeyColor.BackColor = Color.FromArgb(128, 218, 128);

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
            cbDecklinkOutputSingleField.SelectedIndex = 0;

            for (int i = 0; i < VideoEdit1.Video_Transition_Names().Count; i++)
            {
                cbTransitionName.Items.Add(VideoEdit1.Video_Transition_Names()[i]);
            }

            cbTransitionName.SelectedIndex = 0;

            // ReSharper disable once CoVariantArrayConversion
            cbAudEqualizerPreset.Items.AddRange(VideoEdit1.Audio_Effects_Equalizer_Presets().ToArray());
            cbAudEqualizerPreset.SelectedIndex = 0;

            if (rbEVR.Enabled)
            {
                rbEVR.Checked = true;
            }
            else if (!(rbVMR9.Enabled && rbEVR.Enabled))
            {
                rbVR.Checked = true;
            }
        }

        private void ConfigureVUMeters()
        {
            VideoEdit1.Audio_VUMeter_Enabled = cbVUMeter.Checked;
            VideoEdit1.Audio_VUMeter_Pro_Enabled = cbVUMeterPro.Checked;

            if (VideoEdit1.Audio_VUMeter_Pro_Enabled)
            {
                VideoEdit1.Audio_VUMeter_Pro_Volume = tbVUMeterAmplification.Value;

                volumeMeter1.Boost = tbVUMeterBoost.Value / 10.0F;
                volumeMeter2.Boost = tbVUMeterBoost.Value / 10.0F;

                waveformPainter1.Boost = tbVUMeterBoost.Value / 10.0F;
                waveformPainter2.Boost = tbVUMeterBoost.Value / 10.0F;
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
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetWMAOutput(ref VFWMAOutput wmaOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(VideoEdit1);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        private void SetACMOutput(ref VFACMOutput acmOutput)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1.Audio_Codecs.ToArray());
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

        private void SetCustomOutput(ref VFCustomOutput customOutput)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray(), VideoEdit1.DirectShow_Filters.ToArray());
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
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray());
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
                aviSettingsDialog = new AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray());
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

        private void ConfigureNetworkStreaming()
        {
            VideoEdit1.Network_Streaming_Enabled = cbNetworkStreaming.Checked;

            if (VideoEdit1.Network_Streaming_Enabled)
            {
                switch (cbNetworkStreamingMode.SelectedIndex)
                {
                    case 0:
                        {
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.WMV;

                            if (rbNetworkStreamingUseMainWMVSettings.Checked)
                            {
                                var wmvOutput = new VFWMVOutput();
                                SetWMVOutput(ref wmvOutput);
                                VideoEdit1.Network_Streaming_Output = wmvOutput;
                            }
                            else
                            {
                                var wmvOutput = new VFWMVOutput
                                {
                                    Mode = VFWMVMode.ExternalProfile,
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
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.RTSP_H264_AAC_SW;
                            VideoEdit1.Network_Streaming_URL = edNetworkRTSPURL.Text;

                            break;
                        }

                    case 2:
                        {
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.RTMP_FFMPEG_EXE;

                            var ffmpegOutput = new VFFFMPEGEXEOutput();

                            if (rbNetworkUDPFFMPEG.Checked)
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
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.NDI;

                            var ndiOutput = new VFNDIOutput(edNDIName.Text);
                            VideoEdit1.Network_Streaming_Output = ndiOutput;
                            edNDIURL.Text = $"ndi://{System.Net.Dns.GetHostName()}/{edNDIName.Text}";

                            break;
                        }
                    case 4:
                        {
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.UDP_FFMPEG_EXE;

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
                            VideoEdit1.Network_Streaming_Output = ffmpegOutput;

                            VideoEdit1.Network_Streaming_URL = edNetworkUDPURL.Text;

                            break;
                        }

                    case 5:
                        {
                            if (rbNetworkSSSoftware.Checked)
                            {
                                VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.SSF_H264_AAC_SW;
                            }
                            else
                            {
                                VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.SSF_FFMPEG_EXE;

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
                                VideoEdit1.Network_Streaming_Output = ffmpegOutput;
                            }

                            VideoEdit1.Network_Streaming_URL = edNetworkSSURL.Text;

                            break;
                        }

                    case 6:
                        {
                            VideoEdit1.Network_Streaming_Format = VFNetworkStreamingFormat.External;

                            break;
                        }
                }

                VideoEdit1.Network_Streaming_Audio_Enabled = cbNetworkStreamingAudioEnabled.Checked;
            }
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            VideoEdit1.Debug_Mode = cbDebugMode.Checked;
            VideoEdit1.Debug_Telemetry = cbTelemetry.Checked;

            zoom = 1.0;
            zoomShiftX = 0;
            zoomShiftY = 0;

            mmLog.Clear();

            VideoEdit1.Mode = (VFVideoEditMode)cbMode.SelectedIndex;
            
            VideoEdit1.Video_Resize = cbResize.Checked;
            
            if (VideoEdit1.Video_Resize)
            {
                VideoEdit1.Video_Resize_Width = Convert.ToInt32(edWidth.Text);
                VideoEdit1.Video_Resize_Height = Convert.ToInt32(edHeight.Text);
            }

            if (cbCrop.Checked)
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

            if (cbSubtitlesEnabled.Checked)
            {
                VideoEdit1.Video_Subtitles = new SubtitlesSettings(edSubtitlesFilename.Text);
            }
            else
            {
                VideoEdit1.Video_Subtitles = null;
            }

            VideoEdit1.Video_FrameRate = Convert.ToDouble(cbFrameRate.Text, CultureInfo.InvariantCulture);

            ConfigureVideoRenderer();

            ConfigureNetworkStreaming();
            
            VideoEdit1.Output_Filename = edOutput.Text;

            VFVideoEditOutputFormat outputFormat = VFVideoEditOutputFormat.AVI;
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                    {
                        outputFormat = VFVideoEditOutputFormat.AVI;

                        var aviOutput = new VFAVIOutput();
                        SetAVIOutput(ref aviOutput);
                        VideoEdit1.Output_Format = aviOutput;

                        break;
                    }
                case 1:
                    {
                        outputFormat = VFVideoEditOutputFormat.MKVv1;

                        var mkvOutput = new VFMKVv1Output();
                        SetMKVOutput(ref mkvOutput);
                        VideoEdit1.Output_Format = mkvOutput;

                        break;
                    }
                case 2:
                    {
                        outputFormat = VFVideoEditOutputFormat.WMV;

                        var wmvOutput = new VFWMVOutput();
                        SetWMVOutput(ref wmvOutput);
                        VideoEdit1.Output_Format = wmvOutput;

                        break;
                    }
                case 3:
                    {
                        outputFormat = VFVideoEditOutputFormat.DV;

                        var dvOutput = new VFDVOutput();
                        SetDVOutput(ref dvOutput);
                        VideoEdit1.Output_Format = dvOutput;

                        break;
                    }
                case 4:
                    {
                        outputFormat = VFVideoEditOutputFormat.PCM_ACM;

                        var acmOutput = new VFACMOutput();
                        SetACMOutput(ref acmOutput);
                        VideoEdit1.Output_Format = acmOutput;

                        break;
                    }
                case 5:
                    {
                        outputFormat = VFVideoEditOutputFormat.MP3;

                        var mp3Output = new VFMP3Output();
                        SetMP3Output(ref mp3Output);
                        VideoEdit1.Output_Format = mp3Output;

                        break;
                    }
                case 6:
                    {
                        outputFormat = VFVideoEditOutputFormat.M4A;

                        var m4aOutput = new VFM4AOutput();
                        SetM4AOutput(ref m4aOutput);
                        VideoEdit1.Output_Format = m4aOutput;

                        break;
                    }
                case 7:
                    {
                        outputFormat = VFVideoEditOutputFormat.WMA;

                        var wmaOutput = new VFWMAOutput();
                        SetWMAOutput(ref wmaOutput);
                        VideoEdit1.Output_Format = wmaOutput;

                        break;
                    }
                case 8:
                    {
                        outputFormat = VFVideoEditOutputFormat.OggVorbis;

                        var oggVorbisOutput = new VFOGGVorbisOutput();
                        SetOGGOutput(ref oggVorbisOutput);
                        VideoEdit1.Output_Format = oggVorbisOutput;

                        break;
                    }
                case 9:
                    {
                        outputFormat = VFVideoEditOutputFormat.FLAC;

                        var flacOutput = new VFFLACOutput();
                        SetFLACOutput(ref flacOutput);
                        VideoEdit1.Output_Format = flacOutput;

                        break;
                    }
                case 10:
                    {
                        outputFormat = VFVideoEditOutputFormat.Speex;

                        var speexOutput = new VFSpeexOutput();
                        SetSpeexOutput(ref speexOutput);
                        VideoEdit1.Output_Format = speexOutput;

                        break;
                    }
                case 11:
                    {
                        outputFormat = VFVideoEditOutputFormat.Custom;

                        var customOutput = new VFCustomOutput();
                        SetCustomOutput(ref customOutput);
                        VideoEdit1.Output_Format = customOutput;

                        break;
                    }
                case 12:
                    {
                        outputFormat = VFVideoEditOutputFormat.WebM;

                        var webmOutput = new VFWebMOutput();
                        SetWebMOutput(ref webmOutput);
                        VideoEdit1.Output_Format = webmOutput;

                        break;
                    }
                case 13:
                    {
                        outputFormat = VFVideoEditOutputFormat.FFMPEG;

                        var ffmpegOutput = new VFFFMPEGOutput();
                        SetFFMPEGOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;

                        break;
                    }
                case 14:
                    {
                        outputFormat = VFVideoEditOutputFormat.FFMPEG_EXE;

                        var ffmpegOutput = new VFFFMPEGEXEOutput();
                        SetFFMPEGEXEOutput(ref ffmpegOutput);
                        VideoEdit1.Output_Format = ffmpegOutput;

                        break;
                    }
                case 15:
                    outputFormat = VFVideoEditOutputFormat.MP4;
                    break;
                case 16:
                    {
                        outputFormat = VFVideoEditOutputFormat.MP4_HW;

                        var mp4Output = new VFMP4HWOutput();
                        SetMP4HWOutput(ref mp4Output);
                        VideoEdit1.Output_Format = mp4Output;

                        break;
                    }
                case 17:
                    {
                        outputFormat = VFVideoEditOutputFormat.AnimatedGIF;
                        var gifOutput = new VFAnimatedGIFOutput();
                        SetGIFOutput(ref gifOutput);
                        VideoEdit1.Output_Format = gifOutput;
                        break;
                    }
                case 18:
                    outputFormat = VFVideoEditOutputFormat.Encrypted;
                    break;
            }

            if ((outputFormat == VFVideoEditOutputFormat.MP4) ||
            ((outputFormat == VFVideoEditOutputFormat.Encrypted) && rbEncryptedH264SW.Checked) ||
                    (VideoEdit1.Network_Streaming_Enabled && (VideoEdit1.Network_Streaming_Format == VFNetworkStreamingFormat.RTSP_H264_AAC_SW)))
            {
                var mp4Output = new VFMP4Output();
                SetMP4Output(ref mp4Output);

                // encryption
                if (outputFormat == VFVideoEditOutputFormat.Encrypted)
                {
                    mp4Output.Encryption = true;
                    mp4Output.Encryption_Format = VFEncryptionFormat.MP4_H264_SW_AAC;

                    if (rbEncryptionKeyString.Checked)
                    {
                        mp4Output.Encryption_KeyType = VFEncryptionKeyType.String;
                        mp4Output.Encryption_Key = edEncryptionKeyString.Text;
                    }
                    else if (rbEncryptionKeyFile.Checked)
                    {
                        mp4Output.Encryption_KeyType = VFEncryptionKeyType.File;
                        mp4Output.Encryption_Key = edEncryptionKeyFile.Text;
                    }
                    else
                    {
                        mp4Output.Encryption_KeyType = VFEncryptionKeyType.Binary;
                        mp4Output.Encryption_Key = VideoEdit1.ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
                    }

                    if (rbEncryptionModeAES128.Checked)
                    {
                        mp4Output.Encryption_Mode = VFEncryptionMode.V8_AES128;
                    }
                    else
                    {
                        mp4Output.Encryption_Mode = VFEncryptionMode.V9_AES256;
                    }
                }

                VideoEdit1.Output_Format = mp4Output;
            }

            VideoEdit1.Audio_Preview_Enabled = true;

            // Audio enhancement
            VideoEdit1.Audio_Enhancer_Enabled = cbAudioEnhancementEnabled.Checked;
            if (VideoEdit1.Audio_Enhancer_Enabled)
            {
                VideoEdit1.Audio_Enhancer_Normalize(-1, cbAudioNormalize.Checked);
                VideoEdit1.Audio_Enhancer_AutoGain(-1, cbAudioAutoGain.Checked);

                ApplyAudioInputGains();
                ApplyAudioOutputGains();

                VideoEdit1.Audio_Enhancer_Timeshift(-1, tbAudioTimeshift.Value);
            }

            // Audio channels mapping
            if (cbAudioChannelMapperEnabled.Checked)
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

            // Audio effects
            VideoEdit1.Audio_Effects_Clear(-1);
            VideoEdit1.Audio_Effects_Enabled = cbAudioEffectsEnabled.Checked;
            if (VideoEdit1.Audio_Effects_Enabled)
            {
                VideoEdit1.Audio_Effects_Add(-1, VFAudioEffectType.Amplify, cbAudAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, VFAudioEffectType.Equalizer, cbAudEqualizerEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, VFAudioEffectType.DynamicAmplify, cbAudDynamicAmplifyEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, VFAudioEffectType.Sound3D, cbAudSound3DEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(-1, VFAudioEffectType.TrueBass, cbAudTrueBassEnabled.Checked, TimeSpan.Zero, TimeSpan.Zero);
                VideoEdit1.Audio_Effects_Add(
                    -1,
                    VFAudioEffectType.Fade, 
                    cbFadeInEnabled.Checked,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInStartTime.Text)),
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInStopTime.Text)));
                VideoEdit1.Audio_Effects_Add(
                    -1,
                    VFAudioEffectType.Fade, 
                    cbFadeOutEnabled.Checked,
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeOutStartTime.Text)),
                    TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeOutStopTime.Text)));

                tbAudAmplifyAmp_Scroll(sender, e);
                tbAudDynAmp_Scroll(sender, e);
                tbAudAttack_Scroll(sender, e);
                tbAudRelease_Scroll(sender, e);
                tbAud3DSound_Scroll(sender, e);
                tbAudTrueBass_Scroll(sender, e);

                tbAudEq0_Scroll(sender, e);
                tbAudEq1_Scroll(sender, e);
                tbAudEq2_Scroll(sender, e);
                tbAudEq3_Scroll(sender, e);
                tbAudEq4_Scroll(sender, e);
                tbAudEq5_Scroll(sender, e);
                tbAudEq6_Scroll(sender, e);
                tbAudEq7_Scroll(sender, e);
                tbAudEq8_Scroll(sender, e);
                tbAudEq9_Scroll(sender, e);

                cbFadeInEnabled_CheckedChanged(sender, e);
                cbFadeOutEnabled_CheckedChanged(sender, e);
            }
            
            // Object detection
            ConfigureObjectDetection();

            // Virtual camera output
            VideoEdit1.Virtual_Camera_Output_Enabled = cbVirtualCamera.Checked;

            // Audio VU meters
            ConfigureVUMeters();

            // Video effects CPU
            AddVideoEffects();

            // Video effects GPU
            VideoEdit1.Video_Effects_GPU_Enabled = cbVideoEffectsGPUEnabled.Checked;

            // Decklink output
            ConfigureDecklinkOutput();

            // Chroma key
            ConfigureChromaKey();

            // Barcode detection
            VideoEdit1.Barcode_Reader_Enabled = cbBarcodeDetectionEnabled.Checked;
            VideoEdit1.Barcode_Reader_Type = (VFBarcodeType)cbBarcodeType.SelectedIndex;

            // motion detection
            ConfigureMotionDetection();

            // video rotation
            switch (cbRotate.SelectedIndex)
            {
                case 0:
                    VideoEdit1.Video_Rotation = VFRotateMode.RotateNone;
                    break;
                case 1:
                    VideoEdit1.Video_Rotation = VFRotateMode.Rotate90;
                    break;
                case 2:
                    VideoEdit1.Video_Rotation = VFRotateMode.Rotate180;
                    break;
                case 3:
                    VideoEdit1.Video_Rotation = VFRotateMode.Rotate270;
                    break;
            }

            // Output tags
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

                VideoEdit1.Tags = tags;
            }

            await VideoEdit1.StartAsync();

            edNetworkURL.Text = VideoEdit1.Network_Streaming_URL;

            lbTransitions.Items.Clear();
        }

        private void AddVideoEffects()
        {
            VideoEdit1.Video_Effects_Enabled = cbEffects.Checked;

            // Deinterlace
            if (cbDeinterlace.Checked)
            {
                if (rbDeintBlendEnabled.Checked)
                {
                    IVFVideoEffectDeinterlaceBlend blend;
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceBlend");
                    if (effect == null)
                    {
                        blend = new VFVideoEffectDeinterlaceBlend(true);
                        VideoEdit1.Video_Effects_Add(blend);
                    }
                    else
                    {
                        // ReSharper disable once TryCastAlwaysSucceeds
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
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceCAVT");
                    if (effect == null)
                    {
                        cavt = new VFVideoEffectDeinterlaceCAVT(
                            rbDeintCAVTEnabled.Checked,
                            Convert.ToInt32(edDeintCAVTThreshold.Text));
                        VideoEdit1.Video_Effects_Add(cavt);
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
                    var effect = VideoEdit1.Video_Effects_Get("DeinterlaceTriangle");
                    if (effect == null)
                    {
                        triangle = new VFVideoEffectDeinterlaceTriangle(
                            true,
                            Convert.ToByte(edDeintTriangleWeight.Text));
                        VideoEdit1.Video_Effects_Add(triangle);
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
            if (cbDenoise.Checked)
            {
                VideoEdit1.Video_Effects_Enabled = true;
                if (rbDenoiseCAST.Checked)
                {
                    IVFVideoEffectDenoiseCAST cast;
                    var effect = VideoEdit1.Video_Effects_Get("DenoiseCAST");
                    if (effect == null)
                    {
                        cast = new VFVideoEffectDenoiseCAST(true);
                        VideoEdit1.Video_Effects_Add(cast);
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
                    var effect = VideoEdit1.Video_Effects_Get("DenoiseMosquito");
                    if (effect == null)
                    {
                        mosquito = new VFVideoEffectDenoiseMosquito(true);
                        VideoEdit1.Video_Effects_Add(mosquito);
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

            if (cbZoom.Checked)
            {
                cbZoom_CheckedChanged(null, null);
            }

            if (cbPan.Checked)
            {
                cbPan_CheckedChanged(null, null);
            }

            if (cbFlipX.Checked)
            {
                cbFlipX_CheckedChanged(null, null);
            }

            if (cbFlipY.Checked)
            {
                cbFlipY_CheckedChanged(null, null);
            }

            if (cbVideoFadeInOut.Checked)
            {
                cbFadeInOut_CheckedChanged(null, null);
            }
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            await VideoEdit1.StopAsync();

            lbFiles.Items.Clear();
            VideoEdit1.Input_Clear_List();
            ProgressBar1.Value = 0;

            // clear VU Meters
            peakMeterCtrl1.SetData(new int[19], 0, 19);
            peakMeterCtrl1.Stop();
            waveformPainter1.Clear();
            waveformPainter2.Clear();

            volumeMeter1.Clear();
            volumeMeter2.Clear();
            
            VideoEdit1.Video_Effects_Clear();

            lbImageLogos.Items.Clear();
            lbTextLogos.Items.Clear();
        }
        
        private void cbGreyscale_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectGrayscale grayscale;
            var effect = VideoEdit1.Video_Effects_Get("Grayscale");
            if (effect == null)
            {
                grayscale = new VFVideoEffectGrayscale(cbGreyscale.Checked);
                VideoEdit1.Video_Effects_Add(grayscale);
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

        private void cbInvert_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectInvert invert;
            var effect = VideoEdit1.Video_Effects_Get("Invert");
            if (effect == null)
            {
                invert = new VFVideoEffectInvert(cbInvert.Checked);
                VideoEdit1.Video_Effects_Add(invert);
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
        
        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            await VideoEdit1.StopAsync();
        }

        private void tbDarkness_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectDarkness darkness;
            var effect = VideoEdit1.Video_Effects_Get("Darkness");
            if (effect == null)
            {
                darkness = new VFVideoEffectDarkness(true, tbDarkness.Value);
                VideoEdit1.Video_Effects_Add(darkness);
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
            var effect = VideoEdit1.Video_Effects_Get("Lightness");
            if (effect == null)
            {
                lightness = new VFVideoEffectLightness(true, tbLightness.Value);
                VideoEdit1.Video_Effects_Add(lightness);
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
            var effect = VideoEdit1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VFVideoEffectSaturation(tbSaturation.Value);
                VideoEdit1.Video_Effects_Add(saturation);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void tbContrast_Scroll(object sender, EventArgs e)
        {
            IVFVideoEffectContrast contrast;
            var effect = VideoEdit1.Video_Effects_Get("Contrast");
            if (effect == null)
            {
                contrast = new VFVideoEffectContrast(true, tbContrast.Value);
                VideoEdit1.Video_Effects_Add(contrast);
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

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                string name = cbFilters.Text;
                btFilterSettings.Enabled = FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.Default) ||
                    FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btFilterAdd_Click(object sender, EventArgs e)
        {
            if (cbFilters.SelectedIndex != -1)
            {
                VideoEdit1.Video_Filters_Add(new VFCustomProcessingFilter(cbFilters.Text));
                lbFilters.Items.Add(cbFilters.Text);
            }
        }

        private void btFilterSettings_Click(object sender, EventArgs e)
        {
            string name = cbFilters.Text;

            if (FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.Default))
            {
                FilterHelpers.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, VFPropertyPage.Default);
            }
            else
                if (FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.VFWCompConfig))
            {
                FilterHelpers.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void lbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.Text;
                btFilterSettings2.Enabled = FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.Default) ||
                                            FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.VFWCompConfig);
            }
        }

        private void btFilterSettings2_Click(object sender, EventArgs e)
        {
            if (lbFilters.SelectedIndex != -1)
            {
                string name = lbFilters.Text;

                if (FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.Default))
                {
                    FilterHelpers.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, VFPropertyPage.Default);
                }
                else if (FilterHelpers.DirectShow_Filter_HasDialog(name, VFPropertyPage.VFWCompConfig))
                {
                    FilterHelpers.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
                }
            }
        }

        private void btFilterDeleteAll_Click(object sender, EventArgs e)
        {
            lbFilters.Items.Clear();
            VideoEdit1.Video_Filters_Clear();
        }

        private void cbAudAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_AMPLIFY, cbAudAmplifyEnabled.Checked);
        }

        private void tbAudAmplifyAmp_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Amplify(-1, AUDIO_EFFECT_ID_AMPLIFY, tbAudAmplifyAmp.Value * 10, false);
        }

        private void cbAudEqualizerEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_EQ, cbAudEqualizerEnabled.Checked);
        }

        private void tbAudEq0_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 0, tbAudEq0.Value);
        }

        private void tbAudEq1_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 1, tbAudEq1.Value);
        }

        private void tbAudEq2_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 2, tbAudEq2.Value);
        }

        private void tbAudEq3_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 3, tbAudEq3.Value);
        }

        private void tbAudEq4_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 4, tbAudEq4.Value);
        }

        private void tbAudEq5_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 5, tbAudEq5.Value);
        }

        private void tbAudEq6_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 6, tbAudEq6.Value);
        }

        private void tbAudEq7_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 7, tbAudEq7.Value);
        }

        private void tbAudEq8_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 8, tbAudEq8.Value);
        }

        private void tbAudEq9_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Band_Set(-1, AUDIO_EFFECT_ID_EQ, 9, tbAudEq9.Value);
        }

        private void cbAudEqualizerPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Equalizer_Preset_Set(-1, AUDIO_EFFECT_ID_EQ, (EqualizerPreset)cbAudEqualizerPreset.SelectedIndex);
            btAudEqRefresh_Click(sender, e);
        }

        private void btAudEqRefresh_Click(object sender, EventArgs e)
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

        private void cbAudDynamicAmplifyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, cbAudDynamicAmplifyEnabled.Checked);
        }

        private void tbAudDynAmp_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void tbAudAttack_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void tbAudRelease_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_DynamicAmplify(-1, AUDIO_EFFECT_ID_DYN_AMPLIFY, tbAudAttack.Value, tbAudDynAmp.Value, tbAudRelease.Value);
        }

        private void cbAudSound3DEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_SOUND_3D, cbAudSound3DEnabled.Checked);
        }

        private void tbAud3DSound_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Sound3D(-1, AUDIO_EFFECT_ID_SOUND_3D, tbAud3DSound.Value);
        }

        private void cbAudTrueBassEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_TRUE_BASS, cbAudTrueBassEnabled.Checked);
        }

        private void tbAudTrueBass_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_TrueBass(-1, AUDIO_EFFECT_ID_TRUE_BASS, 200, false, tbAudTrueBass.Value);
        }

        private void rbVR_CheckedChanged(object sender, EventArgs e)
        {
            cbScreenFlipVertical.Enabled = rbVMR9.Checked || rbDirect2D.Checked;
            cbScreenFlipHorizontal.Enabled = rbVMR9.Checked || rbDirect2D.Checked;

            ConfigureVideoRenderer();
        }

        private async void cbStretch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStretch.Checked)
            {
                VideoEdit1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoEdit1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        private async void cbScreenFlipVertical_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        private async void cbScreenFlipHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked;
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            lbSpeed.Text = Convert.ToInt32(tbSpeed.Value) + "%";
        }

        private void tbSeeking_Scroll(object sender, EventArgs e)
        {
            VideoEdit1.Position_Set(TimeSpan.FromMilliseconds(tbSeeking.Value));
        }

        private void VideoEdit1_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       mmLog.Text = mmLog.Text + e.Message + "(" + e.CallSite + ")" + Environment.NewLine;
                                   }));
        }

        private void VideoEdit1_OnStart(object sender, EventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       tbSeeking.Maximum = (int)VideoEdit1.Duration().TotalMilliseconds;
                                   }));
        }

        private void VideoEdit1_OnProgress(object sender, ProgressEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       ProgressBar1.Value = e.Progress;
                                   }));
        }

        private void VideoEdit1_OnStop(object sender, VideoEditStopEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       ProgressBar1.Value = 0;
                                       lbFiles.Items.Clear();
                                       lbTransitions.Items.Clear();

                                       // clear VU Meters
                                       peakMeterCtrl1.SetData(new int[19], 0, 19);
                                       peakMeterCtrl1.Stop();
                                       waveformPainter1.Clear();
                                       waveformPainter2.Clear();

                                       volumeMeter1.Clear();
                                       volumeMeter2.Clear();

                                       lbImageLogos.Items.Clear();
                                       lbTextLogos.Items.Clear();
                                   }));

            VideoEdit1.Input_Clear_List();
            VideoEdit1.Video_Transition_Clear();
            VideoEdit1.Video_Effects_Clear();

            if (e.Successful)
            {
                MessageBox.Show("Completed successfully", string.Empty, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Stopped with error", string.Empty, MessageBoxButtons.OK);
            }
        }

        private void ConfigureObjectDetection()
        {
            if (cbAFMotionDetection.Checked)
            {
                VideoEdit1.Motion_DetectionEx = new MotionDetectionExSettings();
                if (cbAFMotionHighlight.Checked)
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
            }
        }

        private void ConfigureMotionDetection()
        {
            if (cbMotDetEnabled.Checked)
            {
                VideoEdit1.Motion_Detection = new MotionDetectionSettings
                                                  {
                                                      Enabled = cbMotDetEnabled.Checked,
                                                      Compare_Red = cbCompareRed.Checked,
                                                      Compare_Green = cbCompareGreen.Checked,
                                                      Compare_Blue = cbCompareBlue.Checked,
                                                      Compare_Greyscale = cbCompareGreyscale.Checked,
                                                      Highlight_Color = (VFMotionCHLColor)cbMotDetHLColor.SelectedIndex,
                                                      Highlight_Enabled = cbMotDetHLEnabled.Checked,
                                                      Highlight_Threshold = tbMotDetHLThreshold.Value,
                                                      FrameInterval = Convert.ToInt32(edMotDetFrameInterval.Text),
                                                      Matrix_Height = Convert.ToInt32(edMotDetMatrixHeight.Text),
                                                      Matrix_Width = Convert.ToInt32(edMotDetMatrixWidth.Text),
                                                      DropFrames_Enabled = cbMotDetDropFramesEnabled.Checked,
                                                      DropFrames_Threshold = tbMotDetDropFramesThreshold.Value
                                                  };
                VideoEdit1.MotionDetection_Update();
            }
            else
            {
                VideoEdit1.Motion_Detection = null;
            }
        }

        private void btMotDetUpdateSettings_Click(object sender, EventArgs e)
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

        private void VideoEdit1_OnMotion(object sender, MotionDetectionEventArgs e)
        {
            BeginInvoke(new MotionDelegate(MotionDelegateMethod), e);
        }

        private delegate void AFMotionDelegate(float level);

        private void AFMotionDelegateMethod(float level)
        {
            pbAFMotionLevel.Value = (int)(level * 100);
        }

        private void VideoEdit1_OnObjectDetection(object sender, MotionDetectionExEventArgs e)
        {
            BeginInvoke(new AFMotionDelegate(AFMotionDelegateMethod), e.Level);
        }

        private void cbZoom_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectZoom zoomEffect;
            var effect = VideoEdit1.Video_Effects_Get("Zoom");
            if (effect == null)
            {
                zoomEffect = new VFVideoEffectZoom(zoom, zoom, zoomShiftX, zoomShiftY, cbZoom.Checked);
                VideoEdit1.Video_Effects_Add(zoomEffect);
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
            var effect = VideoEdit1.Video_Effects_Get("Pan");
            if (effect == null)
            {
                pan = new VFVideoEffectPan(true);
                VideoEdit1.Video_Effects_Add(pan);
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

        private void btRefreshClients_Click(object sender, EventArgs e)
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

        private void btSelectWMVProfileNetwork_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edNetworkStreamingWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        private void ConfigureDecklinkOutput()
        {
            if (cbDecklinkOutput.Checked)
            {
                VideoEdit1.Decklink_Output = new DecklinkOutputSettings
                {
                    DVEncoding = cbDecklinkDV.Checked,
                    AnalogOutputIREUSA = cbDecklinkOutputNTSC.SelectedIndex == 0,
                    AnalogOutputSMPTE =
                                                         cbDecklinkOutputComponentLevels.SelectedIndex == 0,
                    BlackToDeckInCapture =
                                                         (DecklinkBlackToDeckInCapture)
                                                         cbDecklinkOutputBlackToDeck.SelectedIndex,
                    DualLinkOutputMode =
                                                         (DecklinkDualLinkMode)cbDecklinkOutputDualLink.SelectedIndex,
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
            }
            else
            {
                VideoEdit1.Decklink_Output = null;
            }
        }

        private void ConfigureVideoRenderer()
        {
            if (rbVMR9.Checked)
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.VMR9;
            }
            else if (rbEVR.Checked)
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.EVR;
            }
            else if (rbVR.Checked)
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.VideoRenderer;
            }
            else if (rbDirect2D.Checked)
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.Direct2D;
            }
            else
            {
                VideoEdit1.Video_Renderer.Video_Renderer = VFVideoRenderer.None;
            }

            if (cbStretch.Checked)
            {
                VideoEdit1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Stretch;
            }
            else
            {
                VideoEdit1.Video_Renderer.StretchMode = VFVideoRendererStretchMode.Letterbox;
            }

            VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);

            VideoEdit1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor;
            VideoEdit1.Video_Renderer.Flip_Horizontal = cbScreenFlipHorizontal.Checked;
            VideoEdit1.Video_Renderer.Flip_Vertical = cbScreenFlipVertical.Checked;
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

        private void cbFadeInOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVideoFadeIn.Checked)
            {
                IVFVideoEffectFadeIn fadeIn;
                var effect = VideoEdit1.Video_Effects_Get("FadeIn");
                if (effect == null)
                {
                    fadeIn = new VFVideoEffectFadeIn(cbVideoFadeInOut.Checked);
                    VideoEdit1.Video_Effects_Add(fadeIn);
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

                fadeIn.Enabled = cbVideoFadeInOut.Checked;
                fadeIn.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStartTime.Text));
                fadeIn.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStopTime.Text));
            }
            else
            {
                IVFVideoEffectFadeOut fadeOut;
                var effect = VideoEdit1.Video_Effects_Get("FadeOut");
                if (effect == null)
                {
                    fadeOut = new VFVideoEffectFadeOut(cbVideoFadeInOut.Checked);
                    VideoEdit1.Video_Effects_Add(fadeOut);
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

                fadeOut.Enabled = cbVideoFadeInOut.Checked;
                fadeOut.StartTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStartTime.Text));
                fadeOut.StopTime = TimeSpan.FromMilliseconds(Convert.ToInt64(edVideoFadeInOutStopTime.Text));
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

                controlLeft = VideoEdit1.Left;
                controlTop = VideoEdit1.Top;
                controlWidth = VideoEdit1.Width;
                controlHeight = VideoEdit1.Height;

                // resizing window
                Left = 0;
                Top = 0;
                Width = Screen.AllScreens[0].WorkingArea.Width;
                Height = Screen.AllScreens[0].WorkingArea.Height;

                //TopMost = true;
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;

                // resizing control
                VideoEdit1.Left = 0;
                VideoEdit1.Top = 0;
                VideoEdit1.Width = Width;
                VideoEdit1.Height = Height;

                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;
                
                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                TopMost = false;
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;

                // restoring control
                VideoEdit1.Left = controlLeft;
                VideoEdit1.Top = controlTop;
                VideoEdit1.Width = controlWidth;
                VideoEdit1.Height = controlHeight;

                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
        }

        private void VideoEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (fullScreen)
            {
                btFullScreen_Click(null, null);
            }
        }

        #endregion

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingToAdobeFlashServer);
            Process.Start(startInfo);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.StreamingMSExpressionEncoder);
            Process.Start(startInfo);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.IISSmoothStreaming);
            Process.Start(startInfo);
        }

        private void btAddInputFile2_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = OpenDialog1.FileName;

                edSourceFileToCut.Text = s;

                string extNew = Path.GetExtension(s)?.ToLowerInvariant();
                string extOld = Path.GetExtension(edOutputFileCut.Text)?.ToLowerInvariant();
                if (extOld != null)
                {
                    edOutputFileCut.Text = edOutputFileCut.Text.Replace(extOld, extNew);
                }
            }
        }

        private void btAddInputFile3_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = OpenDialog1.FileName;
                lbFiles2.Items.Add(s);

                edSourceFileToCut.Text = s;

                string extNew = Path.GetExtension(s).ToLowerInvariant();
                string extOld = Path.GetExtension(edOutputFileJoin.Text)?.ToLowerInvariant();
                if (extOld != null)
                {
                    edOutputFileJoin.Text = edOutputFileJoin.Text.Replace(extOld, extNew);
                }
            }
        }

        private void btClearList3_Click(object sender, EventArgs e)
        {
            lbFiles2.Items.Clear();
        }

        private async void cbDirect2DRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoEdit1.Video_Renderer.RotationAngle = Convert.ToInt32(cbDirect2DRotate.Text);
            await VideoEdit1.Video_Renderer_UpdateAsync();
        }

        private async void pnVideoRendererBGColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pnVideoRendererBGColor.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnVideoRendererBGColor.BackColor = colorDialog1.Color;

                VideoEdit1.Video_Renderer.BackgroundColor = pnVideoRendererBGColor.BackColor;
                await VideoEdit1.Video_Renderer_UpdateAsync();
            }
        }

        private void btAddTransition_Click(object sender, EventArgs e)
        {
            // get id
            int id = VideoEdit1.Video_Transition_GetIDFromName(cbTransitionName.Text);

            // add transition
            VideoEdit1.Video_Transition_Add(TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStartTime.Text)), TimeSpan.FromMilliseconds(Convert.ToInt32(edTransStopTime.Text)), id);

            // add to list
            lbTransitions.Items.Add(cbTransitionName.Text +
            "(Start: " + edTransStartTime.Text + ", stop: " + edTransStopTime.Text + ")");
        }

        private void cbAudioNormalize_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Enhancer_Normalize(-1, cbAudioNormalize.Checked);
        }

        private void cbAudioAutoGain_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Enhancer_AutoGain(-1, cbAudioAutoGain.Checked);
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

            VideoEdit1.Audio_Enhancer_InputGains(-1, gains);
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

            VideoEdit1.Audio_Enhancer_OutputGains(-1, gains);
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

            VideoEdit1.Audio_Enhancer_Timeshift(-1, tbAudioTimeshift.Value);
        }

        private void VideoEdit1_OnLicenseRequired(object sender, LicenseEventArgs e)
        {
            Invoke((Action)(() =>
                                   {
                                       if (cbLicensing.Checked)
                                       {
                                           mmLog.Text += "(NOT ERROR) LICENSING:" + Environment.NewLine + e.Message
                                                         + Environment.NewLine;
                                       }
                                   }));
        }

        private delegate void FFMPEGInfoDelegate(string message);

        private void FFMPEGInfoDelegateMethod(string message)
        {
            // if (VideoCapture1.Debug_Mode)
            // {

            mmLog.Text += "(NOT ERROR) FFMPEG " + message + Environment.NewLine;

            // }
        }

        private void VideoEdit1_OnFFMPEGInfo(object sender, FFMPEGInfoEventArgs e)
        {
            BeginInvoke(new FFMPEGInfoDelegate(FFMPEGInfoDelegateMethod), e.Message);
        }

        private void btEncryptionOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        private void btStartCut_Click(object sender, EventArgs e)
        {
            VideoEdit1.FastEdit_CutFile(
                edSourceFileToCut.Text,
                 TimeSpan.FromMilliseconds(Convert.ToInt32(edStartTimeCut.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edStopTimeCut.Text)),
                edOutputFileCut.Text);
        }

        private void btStopCut_Click(object sender, EventArgs e)
        {
            VideoEdit1.FastEdit_Stop();
        }

        private void btStartJoin_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            foreach (var item in lbFiles2.Items)
            {
                files.Add(item.ToString());
            }

            VideoEdit1.FastEdit_JoinFiles(
                files.ToArray(),
                edOutputFileCut.Text);
        }

        private void btStopJoin_Click(object sender, EventArgs e)
        {
            VideoEdit1.FastEdit_Stop();
        }

        private void btSelectOutputCut_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFileCut.Text = SaveDialog1.FileName;
            }
        }

        private void btSelectOutputJoin_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edOutputFileJoin.Text = SaveDialog1.FileName;
            }
        }

        private void imgTagCover_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                imgTagCover.LoadAsync(openFileDialog2.FileName);
                imgTagCover.Tag = openFileDialog2.FileName;
            }
        }

        private void btStartMux_Click(object sender, EventArgs e)
        {
            var streams = new List<VFVEFFMPEGStream>();

            foreach (string item in lbMuxStreamsList.Items)
            {
                string prefix = item.Substring(0, 1);
                string filename = item.Substring(3);

                streams.Add(new VFVEFFMPEGStream
                {
                    Filename = filename,
                    ID = prefix
                });
            }

            VideoEdit1.FastEdit_MuxStreams(streams, cbMuxStreamsShortest.Checked, edMuxStreamsOutputFile.Text);
        }

        private void btMuxStreamsSelectFile_Click(object sender, EventArgs e)
        {
            if (OpenDialog1.ShowDialog() == DialogResult.OK)
            {
                edMuxStreamsSourceFile.Text = OpenDialog1.FileName;
            }
        }

        private void btMuxStreamsAdd_Click(object sender, EventArgs e)
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
            else if (cbMuxStreamsType.SelectedIndex == 2)
            {
                prefix = "s";
            }
            else
            {
                prefix = cbMuxStreamsType.Text;
            }

            lbMuxStreamsList.Items.Add(prefix + ": " + edMuxStreamsSourceFile.Text);
        }

        private void btMuxStreamsClear_Click(object sender, EventArgs e)
        {
            lbMuxStreamsList.Items.Clear();
        }

        private void btMuxStreamsSelectOutput_Click(object sender, EventArgs e)
        {
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                edMuxStreamsOutputFile.Text = SaveDialog1.FileName;
            }
        }

        private void btStopMux_Click(object sender, EventArgs e)
        {
            VideoEdit1.FastEdit_Stop();
        }

        private void btAudioChannelMapperClear_Click(object sender, EventArgs e)
        {
            audioChannelMapperItems.Clear();
            lbAudioChannelMapperRoutes.Items.Clear();
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

        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NetworkStreamingToYouTube);
            Process.Start(startInfo);
        }

        private void btSubtitlesSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogSubtitles.ShowDialog() == DialogResult.OK)
            {
                edSubtitlesFilename.Text = openFileDialogSubtitles.FileName;
            }
        }

        private void tbGPULightness_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectBrightness intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Brightness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBrightness(true, tbGPULightness.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Saturation");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectSaturation(true, tbGPUSaturation.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Contrast");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectContrast(true, tbGPUContrast.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Darkness");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDarkness(true, tbGPUDarkness.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Grayscale");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectGrayscale(cbGPUGreyscale.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Invert");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectInvert(cbGPUInvert.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("NightVision");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectNightVision(cbGPUNightVision.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Pixelate");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectPixelate(cbGPUPixelate.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("Denoise");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDenoise(cbGPUDenoise.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("DeinterlaceBlend");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectDeinterlaceBlend(cbGPUDeinterlace.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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
            var effect = VideoEdit1.Video_Effects_GPU_Get("OldMovie");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectOldMovie(cbGPUOldMovie.Checked);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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

        private delegate void VUDelegate(VUMeterEventArgs e);

        private void VUDelegateMethod(VUMeterEventArgs e)
        {
            peakMeterCtrl1.SetData(e.MeterData, 0, 19);
        }

        private void VideoEdit1_OnAudioVUMeter(object sender, VUMeterEventArgs e)
        {
            if (VideoEdit1.Status == VFVideoEditStatus.Free)
            {
                return;
            }

            BeginInvoke(new VUDelegate(VUDelegateMethod), e);
        }

        private void VideoEdit1_OnAudioVUMeterProVolume(object sender, AudioLevelEventArgs e)
        {
            Invoke((Action)(() =>
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

        private void btConfigure_Click(object sender, EventArgs e)
        {
            switch (cbOutputVideoFormat.SelectedIndex)
            {
                case 0:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(this);

                        break;
                    }
                case 1:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray());
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
                            pcmSettingsDialog = new PCMSettingsDialog(VideoEdit1.Audio_Codecs.ToArray());
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
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(VideoEdit1.Video_Codecs.ToArray(), VideoEdit1.Audio_Codecs.ToArray(), VideoEdit1.DirectShow_Filters.ToArray());
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
                case 18:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(this);

                        break;
                    }
            }
        }

        private void cbOutputVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
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
        
        private void btTextLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new TextLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VFVideoEffectTextLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
            lbTextLogos.Items.Add(effect.Name);
            dlg.Fill(effect);

            dlg.ShowDialog(this);
            dlg.Dispose();
        }

        private void btTextLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbTextLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbTextLogos.SelectedItem);
                lbTextLogos.Items.Remove(lbTextLogos.SelectedItem);
            }
        }

        private void btTextLogoEdit_Click(object sender, EventArgs e)
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

        private void btImageLogoAdd_Click(object sender, EventArgs e)
        {
            var dlg = new ImageLogoSettingsDialog();

            var name = dlg.GenerateNewEffectName(VideoEdit1);
            var effect = new VFVideoEffectImageLogo(true, name);

            VideoEdit1.Video_Effects_Add(effect);
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
                var effect = VideoEdit1.Video_Effects_Get((string)lbImageLogos.SelectedItem);

                dlg.Attach(effect);
                dlg.ShowDialog(this);
                dlg.Dispose();
            }
        }

        private void btImageLogoRemove_Click(object sender, EventArgs e)
        {
            if (lbImageLogos.SelectedItem != null)
            {
                VideoEdit1.Video_Effects_Remove((string)lbImageLogos.SelectedItem);
                lbImageLogos.Items.Remove(lbImageLogos.SelectedItem);
            }
        }

        private void cbFlipX_CheckedChanged(object sender, EventArgs e)
        {
            IVFVideoEffectFlipDown flip;
            var effect = VideoEdit1.Video_Effects_Get("FlipDown");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipHorizontal(cbFlipX.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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
            var effect = VideoEdit1.Video_Effects_Get("FlipRight");
            if (effect == null)
            {
                flip = new VFVideoEffectFlipVertical(cbFlipY.Checked);
                VideoEdit1.Video_Effects_Add(flip);
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

        private void cbFadeInEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_FADE_IN, cbFadeInEnabled.Checked);

            VideoEdit1.Audio_Effects_Fades(
                -1, 
                AUDIO_EFFECT_ID_FADE_IN, 
                0,
                100,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInStartTime.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeInStopTime.Text)), 
                false);
        }

        private void cbFadeOutEnabled_CheckedChanged(object sender, EventArgs e)
        {
            VideoEdit1.Audio_Effects_Enable(-1, AUDIO_EFFECT_ID_FADE_OUT, cbFadeOutEnabled.Checked);

            VideoEdit1.Audio_Effects_Fades(
                -1,
                AUDIO_EFFECT_ID_FADE_OUT,
                100,
                0,
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeOutStartTime.Text)),
                TimeSpan.FromMilliseconds(Convert.ToInt32(edFadeOutStopTime.Text)),
                false);
        }

        private void tbGPUBlur_Scroll(object sender, EventArgs e)
        {
            IVFGPUVideoEffectBlur intf;
            var effect = VideoEdit1.Video_Effects_GPU_Get("Blur");
            if (effect == null)
            {
                intf = new VFGPUVideoEffectBlur(tbGPUBlur.Value > 0, tbGPUBlur.Value);
                VideoEdit1.Video_Effects_GPU_Add(intf);
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

        private void pnChromaKeyColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pnChromaKeyColor.BackColor = colorDialog1.Color;
                ConfigureChromaKey();
            }
        }

        private void lbNDI_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
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
