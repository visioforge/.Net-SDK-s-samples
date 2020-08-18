using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;
// ReSharper disable CommentTypo

// ReSharper disable InconsistentNaming

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class FFMPEGEXESettingsDialog : Form
    {
        public FFMPEGEXESettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbFFEXEAspectRatio.SelectedIndex = 0;
            cbFFEXEAudioBitrate.SelectedIndex = 8;
            cbFFEXEAudioChannels.SelectedIndex = 0;
            cbFFEXEAudioSampleRate.SelectedIndex = 0;
            cbFFEXEProfile.SelectedIndex = 7;
            cbFFEXEH264Mode.SelectedIndex = 0;
            cbFFEXEH264Level.SelectedIndex = 0;
            cbFFEXEH264Preset.SelectedIndex = 0;
            cbFFEXEH264Profile.SelectedIndex = 0;
            cbFFEXEVideoConstraint.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads FFMPEG EXE settings.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// FFMPEG settings.
        /// </param>
        public void LoadSettings(VFFFMPEGEXEOutput ffmpegOutput)
        {
            cbFFMPEGEXEUsePipes.Checked = ffmpegOutput.UsePipe;
            edFFEXECustomParametersAudio.Text = ffmpegOutput.Custom_AdditionalAudioArgs;
            edFFEXECustomParametersVideo.Text = ffmpegOutput.Custom_AdditionalVideoArgs;

            if (string.IsNullOrEmpty(ffmpegOutput.Custom_AdditionalCommonArgs))
            {
                cbFFEXEUseOnlyAdditionalParameters.Checked = true;
                edFFEXECustomParametersCommon.Text = ffmpegOutput.Custom_AdditionalCommonArgs ;
            }
            else
            {
                cbFFEXEUseOnlyAdditionalParameters.Checked = false;
                edFFEXECustomParametersCommon.Text = ffmpegOutput.Custom_AllFFMPEGArgs;
            }

            switch (ffmpegOutput.OutputMuxer)
            {
                case VFFFMPEGEXEOutputMuxer.Mobile3G2:
                    cbFFEXEOutputFormat.SelectedIndex = 0;
                    break;
                case VFFFMPEGEXEOutputMuxer.Mobile3GP:
                    cbFFEXEOutputFormat.SelectedIndex = 1;
                    break;
                case VFFFMPEGEXEOutputMuxer.AC3:
                    cbFFEXEOutputFormat.SelectedIndex = 2;
                    break;
                case VFFFMPEGEXEOutputMuxer.ADTS:
                    cbFFEXEOutputFormat.SelectedIndex = 3;
                    break;
                case VFFFMPEGEXEOutputMuxer.AVI:
                    cbFFEXEOutputFormat.SelectedIndex = 4;
                    break;
                case VFFFMPEGEXEOutputMuxer.DTS:
                    cbFFEXEOutputFormat.SelectedIndex = 5;
                    break;
                case VFFFMPEGEXEOutputMuxer.DTSHD:
                    cbFFEXEOutputFormat.SelectedIndex = 6;
                    break;
                case VFFFMPEGEXEOutputMuxer.EAC3:
                    cbFFEXEOutputFormat.SelectedIndex = 8;
                    break;
                case VFFFMPEGEXEOutputMuxer.F4V:
                    cbFFEXEOutputFormat.SelectedIndex = 9;
                    break;
                case VFFFMPEGEXEOutputMuxer.FLAC:
                    cbFFEXEOutputFormat.SelectedIndex = 10;
                    break;
                case VFFFMPEGEXEOutputMuxer.FLV:
                    cbFFEXEOutputFormat.SelectedIndex = 11;
                    break;
                case VFFFMPEGEXEOutputMuxer.GIF:
                    cbFFEXEOutputFormat.SelectedIndex = 12;
                    break;
                case VFFFMPEGEXEOutputMuxer.H263:
                    cbFFEXEOutputFormat.SelectedIndex = 13;
                    break;
                case VFFFMPEGEXEOutputMuxer.H264:
                    cbFFEXEOutputFormat.SelectedIndex = 14;
                    break;
                case VFFFMPEGEXEOutputMuxer.HEVC:
                    cbFFEXEOutputFormat.SelectedIndex = 15;
                    break;
                case VFFFMPEGEXEOutputMuxer.Matroska:
                    cbFFEXEOutputFormat.SelectedIndex = 16;
                    break;
                case VFFFMPEGEXEOutputMuxer.M4V:
                    cbFFEXEOutputFormat.SelectedIndex = 17;
                    break;
                case VFFFMPEGEXEOutputMuxer.MJPEG:
                    cbFFEXEOutputFormat.SelectedIndex = 18;
                    break;
                case VFFFMPEGEXEOutputMuxer.MOV:
                    cbFFEXEOutputFormat.SelectedIndex = 19;
                    break;
                case VFFFMPEGEXEOutputMuxer.MP2:
                    cbFFEXEOutputFormat.SelectedIndex = 20;
                    break;
                case VFFFMPEGEXEOutputMuxer.MP3:
                    cbFFEXEOutputFormat.SelectedIndex = 21;
                    break;
                case VFFFMPEGEXEOutputMuxer.MP4:
                    cbFFEXEOutputFormat.SelectedIndex = 22;
                    break;
                case VFFFMPEGEXEOutputMuxer.MPEG:
                    cbFFEXEOutputFormat.SelectedIndex = 23;
                    break;
                case VFFFMPEGEXEOutputMuxer.MPEGTS:
                    cbFFEXEOutputFormat.SelectedIndex = 24;
                    break;
                case VFFFMPEGEXEOutputMuxer.MXF:
                    cbFFEXEOutputFormat.SelectedIndex = 25;
                    break;
                case VFFFMPEGEXEOutputMuxer.OGG:
                    cbFFEXEOutputFormat.SelectedIndex = 26;
                    break;
                case VFFFMPEGEXEOutputMuxer.OPUS:
                    cbFFEXEOutputFormat.SelectedIndex = 27;
                    break;
                case VFFFMPEGEXEOutputMuxer.PSP:
                    cbFFEXEOutputFormat.SelectedIndex = 28;
                    break;
                case VFFFMPEGEXEOutputMuxer.RAWVideo:
                    cbFFEXEOutputFormat.SelectedIndex = 29;
                    break;
                case VFFFMPEGEXEOutputMuxer.SVCD:
                    cbFFEXEOutputFormat.SelectedIndex = 30;
                    break;
                case VFFFMPEGEXEOutputMuxer.SWF:
                    cbFFEXEOutputFormat.SelectedIndex = 31;
                    break;
                case VFFFMPEGEXEOutputMuxer.TrueHD:
                    cbFFEXEOutputFormat.SelectedIndex = 32;
                    break;
                case VFFFMPEGEXEOutputMuxer.VC1:
                    cbFFEXEOutputFormat.SelectedIndex = 33;
                    break;
                case VFFFMPEGEXEOutputMuxer.VCD:
                    cbFFEXEOutputFormat.SelectedIndex = 34;
                    break;
                case VFFFMPEGEXEOutputMuxer.VOB:
                    cbFFEXEOutputFormat.SelectedIndex = 7;
                    break;
                case VFFFMPEGEXEOutputMuxer.WAV:
                    cbFFEXEOutputFormat.SelectedIndex = 35;
                    break;
                case VFFFMPEGEXEOutputMuxer.WebM:
                    cbFFEXEOutputFormat.SelectedIndex = 36;
                    break;
                case VFFFMPEGEXEOutputMuxer.WebP:
                    break;
                case VFFFMPEGEXEOutputMuxer.WTV:
                    cbFFEXEOutputFormat.SelectedIndex = 37;
                    break;
                case VFFFMPEGEXEOutputMuxer.WV:
                    cbFFEXEOutputFormat.SelectedIndex = 38;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (ffmpegOutput.Video_Encoder)
            {
                case VFFFMPEGEXEVideoEncoder.Auto:
                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    break;
                case VFFFMPEGEXEVideoEncoder.DVVideo:
                    cbFFEXEVideoCodec.SelectedIndex = 1;
                    break;
                case VFFFMPEGEXEVideoEncoder.FLV1:
                    cbFFEXEVideoCodec.SelectedIndex = 2;
                    break;
                case VFFFMPEGEXEVideoEncoder.GIF:
                    cbFFEXEVideoCodec.SelectedIndex = 3;
                    break;
                case VFFFMPEGEXEVideoEncoder.H263:
                    cbFFEXEVideoCodec.SelectedIndex = 4;
                    break;
                case VFFFMPEGEXEVideoEncoder.H264:
                    cbFFEXEVideoCodec.SelectedIndex = 5;
                    break;
                case VFFFMPEGEXEVideoEncoder.H264_QSV:
                    cbFFEXEVideoCodec.SelectedIndex = 6;
                    break;
                case VFFFMPEGEXEVideoEncoder.HEVC:
                    cbFFEXEVideoCodec.SelectedIndex = 7;
                    break;
                case VFFFMPEGEXEVideoEncoder.HEVC_QSV:
                    cbFFEXEVideoCodec.SelectedIndex = 8;
                    break;
                case VFFFMPEGEXEVideoEncoder.HuffYUV:
                    cbFFEXEVideoCodec.SelectedIndex = 9;
                    break;
                case VFFFMPEGEXEVideoEncoder.JPEG2000:
                    cbFFEXEVideoCodec.SelectedIndex = 10;
                    break;
                case VFFFMPEGEXEVideoEncoder.JPEGLS:
                    cbFFEXEVideoCodec.SelectedIndex = 11;
                    break;
                case VFFFMPEGEXEVideoEncoder.LJPEG:
                    cbFFEXEVideoCodec.SelectedIndex = 12;
                    break;
                case VFFFMPEGEXEVideoEncoder.MJPEG:
                    cbFFEXEVideoCodec.SelectedIndex = 13;
                    break;
                case VFFFMPEGEXEVideoEncoder.MPEG1Video:
                    cbFFEXEVideoCodec.SelectedIndex = 14;
                    break;
                case VFFFMPEGEXEVideoEncoder.MPEG2Video:
                    cbFFEXEVideoCodec.SelectedIndex = 15;
                    break;
                case VFFFMPEGEXEVideoEncoder.MPEG4:
                    cbFFEXEVideoCodec.SelectedIndex = 16;
                    break;
                case VFFFMPEGEXEVideoEncoder.PNG:
                    cbFFEXEVideoCodec.SelectedIndex = 17;
                    break;
                case VFFFMPEGEXEVideoEncoder.Theora:
                    cbFFEXEVideoCodec.SelectedIndex = 18;
                    break;
                case VFFFMPEGEXEVideoEncoder.VP8:
                    cbFFEXEVideoCodec.SelectedIndex = 19;
                    break;
                case VFFFMPEGEXEVideoEncoder.VP9:
                    cbFFEXEVideoCodec.SelectedIndex = 20;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ffmpegOutput.Video_AspectRatioW == 0 && ffmpegOutput.Video_AspectRatioH == 1)
            {
                cbFFEXEAspectRatio.SelectedIndex = 0;
            }
            else if (ffmpegOutput.Video_AspectRatioW == 1 && ffmpegOutput.Video_AspectRatioH == 1)
            {
                cbFFEXEAspectRatio.SelectedIndex = 1;
            }
            else if (ffmpegOutput.Video_AspectRatioW == 4 && ffmpegOutput.Video_AspectRatioH == 3)
            {
                cbFFEXEAspectRatio.SelectedIndex = 2;
            }
            else
            {
                cbFFEXEAspectRatio.SelectedIndex = 3;
            }

            if (Convert.ToInt32(edFFEXEVideoWidth.Text) == 0 || Convert.ToInt32(edFFEXEVideoHeight.Text) == 0)
            {
                cbFFEXEVideoResolutionOriginal.Checked = true;
            }
            else
            {
                cbFFEXEVideoResolutionOriginal.Checked = false;
            }

            switch (ffmpegOutput.Video_Mode)
            {
                case VFFFMPEGEXEVideoMode.CBR:
                    rbFFEXEVideoModeCBR.Checked = true;
                    break;
                case VFFFMPEGEXEVideoMode.ABR:
                    rbFFEXEVideoModeABR.Checked = true;
                    break;
                case VFFFMPEGEXEVideoMode.Quality:
                    rbFFEXEVideoModeQuality.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            edFFEXEVideoTargetBitrate.Text = ((int)(ffmpegOutput.Video_Bitrate / 1000.0)).ToString();
            edFFEXEVideoBitrateMax.Text = ((int)(ffmpegOutput.Video_MaxBitrate / 1000.0)).ToString();
            edFFEXEVideoBitrateMin.Text = ((int)(ffmpegOutput.Video_MinBitrate / 1000.0)).ToString();
            edFFEXEVBVBufferSize.Text = ffmpegOutput.Video_BufferSize.ToString();
            edFFEXEVideoGOPSize.Text = ffmpegOutput.Video_GOPSize.ToString();
            edFFEXEVideoBFramesCount.Text = ffmpegOutput.Video_BFrames.ToString();
            cbFFEXEVideoInterlace.Checked = ffmpegOutput.Video_Interlace;
            cbFFEXEVideoResolutionLetterbox.Checked = ffmpegOutput.Video_Letterbox;
            tbFFEXEVideoQuality.Value = ffmpegOutput.Video_Quality;
            tbFFEXEH264Quantizer.Value = ffmpegOutput.Video_H264_Quantizer;
            cbFFEXEH264Mode.SelectedIndex = (int) ffmpegOutput.Video_H264_Mode;
            cbFFEXEH264Preset.SelectedIndex = (int)ffmpegOutput.Video_H264_Preset;
            cbFFEXEH264Profile.SelectedIndex = (int)ffmpegOutput.Video_H264_Profile;
            cbFFEXEH264QuickTimeCompatibility.Checked = ffmpegOutput.Video_H264_QuickTime_Compatibility;
            cbFFEXEH264ZeroTolerance.Checked = ffmpegOutput.Video_H264_ZeroTolerance;
            cbFFEXEH264WebFastStart.Checked = ffmpegOutput.Video_H264_WebFastStart;
            cbFFEXEVideoConstraint.SelectedIndex = (int)ffmpegOutput.Video_TVSystem;

            switch (ffmpegOutput.Video_H264_Level)
            {
                case VFFFMPEGEXEH264Level.None:
                    cbFFEXEH264Level.SelectedIndex = 0;
                    break;
                case VFFFMPEGEXEH264Level.Level1:
                    cbFFEXEH264Level.SelectedIndex = 1;
                    break;
                case VFFFMPEGEXEH264Level.Level11:
                    cbFFEXEH264Level.SelectedIndex = 2;
                    break;
                case VFFFMPEGEXEH264Level.Level12:
                    cbFFEXEH264Level.SelectedIndex = 3;
                    break;
                case VFFFMPEGEXEH264Level.Level13:
                    cbFFEXEH264Level.SelectedIndex = 4;
                    break;
                case VFFFMPEGEXEH264Level.Level2:
                    cbFFEXEH264Level.SelectedIndex = 5;
                    break;
                case VFFFMPEGEXEH264Level.Level21:
                    cbFFEXEH264Level.SelectedIndex = 6;
                    break;
                case VFFFMPEGEXEH264Level.Level22:
                    cbFFEXEH264Level.SelectedIndex = 7;
                    break;
                case VFFFMPEGEXEH264Level.Level3:
                    cbFFEXEH264Level.SelectedIndex = 8;
                    break;
                case VFFFMPEGEXEH264Level.Level31:
                    cbFFEXEH264Level.SelectedIndex = 9;
                    break;
                case VFFFMPEGEXEH264Level.Level32:
                    cbFFEXEH264Level.SelectedIndex = 10;
                    break;
                case VFFFMPEGEXEH264Level.Level4:
                    cbFFEXEH264Level.SelectedIndex = 11;
                    break;
                case VFFFMPEGEXEH264Level.Level41:
                    cbFFEXEH264Level.SelectedIndex = 12;
                    break;
                case VFFFMPEGEXEH264Level.Level42:
                    cbFFEXEH264Level.SelectedIndex = 13;
                    break;
                case VFFFMPEGEXEH264Level.Level5:
                    cbFFEXEH264Level.SelectedIndex = 14;
                    break;
                case VFFFMPEGEXEH264Level.Level51:
                    cbFFEXEH264Level.SelectedIndex = 15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (ffmpegOutput.Audio_Encoder)
            {
                case VFFFMPEGEXEAudioEncoder.Auto:
                    cbFFEXEAudioCodec.SelectedIndex = 0;
                    break;
                case VFFFMPEGEXEAudioEncoder.AAC:
                    cbFFEXEAudioCodec.SelectedIndex = 1;
                    break;
                case VFFFMPEGEXEAudioEncoder.AC3:
                    cbFFEXEAudioCodec.SelectedIndex = 2;
                    break;
                case VFFFMPEGEXEAudioEncoder.adpcm_g722:
                    cbFFEXEAudioCodec.SelectedIndex = 3;
                    break;
                case VFFFMPEGEXEAudioEncoder.adpcm_g726:
                    cbFFEXEAudioCodec.SelectedIndex = 4;
                    break;
                case VFFFMPEGEXEAudioEncoder.adpcm_ms:
                    cbFFEXEAudioCodec.SelectedIndex = 5;
                    break;
                case VFFFMPEGEXEAudioEncoder.ALAC:
                    cbFFEXEAudioCodec.SelectedIndex = 6;
                    break;
                case VFFFMPEGEXEAudioEncoder.AMR_NB:
                    cbFFEXEAudioCodec.SelectedIndex = 7;
                    break;
                case VFFFMPEGEXEAudioEncoder.AMR_WB:
                    cbFFEXEAudioCodec.SelectedIndex = 8;
                    break;
                case VFFFMPEGEXEAudioEncoder.EAC3:
                    cbFFEXEAudioCodec.SelectedIndex = 9;
                    break;
                case VFFFMPEGEXEAudioEncoder.FLAC:
                    cbFFEXEAudioCodec.SelectedIndex = 10;
                    break;
                case VFFFMPEGEXEAudioEncoder.G723_1:
                    cbFFEXEAudioCodec.SelectedIndex = 11;
                    break;
                case VFFFMPEGEXEAudioEncoder.MP2:
                    cbFFEXEAudioCodec.SelectedIndex = 12;
                    break;
                case VFFFMPEGEXEAudioEncoder.MP3:
                    cbFFEXEAudioCodec.SelectedIndex = 13;
                    break;
                case VFFFMPEGEXEAudioEncoder.OPUS:
                    cbFFEXEAudioCodec.SelectedIndex = 14;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_ALAW:
                    cbFFEXEAudioCodec.SelectedIndex = 15;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_F32BE:
                    cbFFEXEAudioCodec.SelectedIndex = 16;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_F32LE:
                    cbFFEXEAudioCodec.SelectedIndex = 17;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_F64BE:
                    cbFFEXEAudioCodec.SelectedIndex = 18;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_F64LE:
                    cbFFEXEAudioCodec.SelectedIndex = 19;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_MULAW:
                    cbFFEXEAudioCodec.SelectedIndex = 20;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S16BE:
                    cbFFEXEAudioCodec.SelectedIndex = 21;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S16BE_Planar:
                    cbFFEXEAudioCodec.SelectedIndex = 22;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S16LE:
                    cbFFEXEAudioCodec.SelectedIndex = 23;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S16LE_Planar:
                    cbFFEXEAudioCodec.SelectedIndex = 24;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S24BE:
                    cbFFEXEAudioCodec.SelectedIndex = 25;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S24daud:
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S24LE:
                    cbFFEXEAudioCodec.SelectedIndex = 26;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S24LE_Planar:
                    cbFFEXEAudioCodec.SelectedIndex = 27;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S32BE:
                    cbFFEXEAudioCodec.SelectedIndex = 28;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S32LE:
                    cbFFEXEAudioCodec.SelectedIndex = 29;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S32LE_Planar:
                    cbFFEXEAudioCodec.SelectedIndex = 30;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S8:
                    cbFFEXEAudioCodec.SelectedIndex = 31;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_S8_Planar:
                    cbFFEXEAudioCodec.SelectedIndex = 32;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U16BE:
                    cbFFEXEAudioCodec.SelectedIndex = 33;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U16LE:
                    cbFFEXEAudioCodec.SelectedIndex = 34;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U24BE:
                    cbFFEXEAudioCodec.SelectedIndex = 35;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U24LE:
                    cbFFEXEAudioCodec.SelectedIndex = 36;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U32BE:
                    cbFFEXEAudioCodec.SelectedIndex = 37;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U32LE:
                    cbFFEXEAudioCodec.SelectedIndex = 38;
                    break;
                case VFFFMPEGEXEAudioEncoder.PCM_U8:
                    cbFFEXEAudioCodec.SelectedIndex = 39;
                    break;
                case VFFFMPEGEXEAudioEncoder.Speex:
                    cbFFEXEAudioCodec.SelectedIndex = 40;
                    break;
                case VFFFMPEGEXEAudioEncoder.Vorbis:
                    cbFFEXEAudioCodec.SelectedIndex = 41;
                    break;
                case VFFFMPEGEXEAudioEncoder.WavPack:
                    cbFFEXEAudioCodec.SelectedIndex = 42;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ffmpegOutput.Audio_Channels == 0)
            {
                cbFFEXEAudioChannels.SelectedIndex = 0;
            }
            else
            {
                cbFFEXEAudioChannels.Text = ffmpegOutput.Audio_Channels.ToString();
            }

            if (ffmpegOutput.Audio_SampleRate == 0)
            {
                cbFFEXEAudioSampleRate.SelectedIndex = 0;
            }
            else
            {
                cbFFEXEAudioSampleRate.Text = ffmpegOutput.Audio_SampleRate.ToString();
            }

            if (ffmpegOutput.Audio_Bitrate == 0)
            {
                cbFFEXEAudioBitrate.SelectedIndex = 0;
            }
            else
            {
                cbFFEXEAudioBitrate.Text = ffmpegOutput.Audio_Bitrate.ToString();
            }
            
            tbFFEXEAudioQuality.Value = ffmpegOutput.Audio_Quality;

            switch (ffmpegOutput.Audio_Mode)
            {
                case VFFFMPEGEXEAudioMode.None:
                case VFFFMPEGEXEAudioMode.CBR:
                    rbFFEXEAudioModeCBR.Checked = true;
                    break;
                case VFFFMPEGEXEAudioMode.ABR:
                    rbFFEXEAudioModeABR.Checked = true;
                    break;
                case VFFFMPEGEXEAudioMode.Quality:
                    rbFFEXEAudioModeQuality.Checked = true;
                    break;
                case VFFFMPEGEXEAudioMode.Lossless:
                    rbFFEXEAudioModeLossless.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SaveSettings(ref VFFFMPEGEXEOutput ffmpegOutput)
        {
            ffmpegOutput.UsePipe = cbFFMPEGEXEUsePipes.Checked;
            ffmpegOutput.Custom_AdditionalAudioArgs = edFFEXECustomParametersAudio.Text;
            ffmpegOutput.Custom_AdditionalVideoArgs = edFFEXECustomParametersVideo.Text;

            if (cbFFEXEUseOnlyAdditionalParameters.Checked)
            {
                ffmpegOutput.Custom_AllFFMPEGArgs = edFFEXECustomParametersCommon.Text;
            }
            else
            {
                ffmpegOutput.Custom_AdditionalCommonArgs = edFFEXECustomParametersCommon.Text;
            }

            switch (cbFFEXEOutputFormat.SelectedIndex)
            {
                case 0:
                    // 3G2
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.Mobile3G2;
                    break;
                case 1:
                    // 3GP
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.Mobile3GP;
                    break;
                case 2:
                    // AC3
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.AC3;
                    break;
                case 3:
                    // ADTS
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.ADTS;
                    break;
                case 4:
                    // AVI
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.AVI;
                    break;
                case 5:
                    // DTS
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.DTS;
                    break;
                case 6:
                    // DTS-HD
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.DTSHD;
                    break;
                case 7:
                    // DVD (VOB)
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.VOB;
                    break;
                case 8:
                    // E-AC3
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.EAC3;
                    break;
                case 9:
                    // F4V
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.F4V;
                    break;
                case 10:
                    // FLAC
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.FLAC;
                    break;
                case 11:
                    // FLV
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.FLV;
                    break;
                case 12:
                    // GIF
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.GIF;
                    break;
                case 13:
                    // H263
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.H263;
                    break;
                case 14:
                    // H264
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.H264;
                    break;
                case 15:
                    // HEVC
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.HEVC;
                    break;
                case 16:
                    // Matroska
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.Matroska;
                    break;
                case 17:
                    // M4V
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.M4V;
                    break;
                case 18:
                    // MJPEG
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MJPEG;
                    break;
                case 19:
                    // MOV
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MOV;
                    break;
                case 20:
                    // MP2
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MP2;
                    break;
                case 21:
                    // MP3
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MP3;
                    break;
                case 22:
                    // MP4
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MP4;
                    break;
                case 23:
                    // MPEG
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MPEG;
                    break;
                case 24:
                    // MPEGTS
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MPEGTS;
                    break;
                case 25:
                    // MXF
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.MXF;
                    break;
                case 26:
                    // OGG
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.OGG;
                    break;
                case 27:
                    // OPUS
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.OPUS;
                    break;
                case 28:
                    // PSP MP4
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.PSP;
                    break;
                case 29:
                    // RAWVideo
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.RAWVideo;
                    break;
                case 30:
                    // SVCD
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.SVCD;
                    break;
                case 31:
                    // SWF
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.SWF;
                    break;
                case 32:
                    // TrueHD
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.TrueHD;
                    break;
                case 33:
                    // VC1
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.VC1;
                    break;
                case 34:
                    // VCD
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.VCD;
                    break;
                case 35:
                    // WAV
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.WAV;
                    break;
                case 36:
                    // WebM
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.WebM;
                    break;
                case 37:
                    // WTV
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.WTV;
                    break;
                case 38:
                    // WV (WavPack)
                    ffmpegOutput.OutputMuxer = VFFFMPEGEXEOutputMuxer.WV;
                    break;
            }

            switch (cbFFEXEVideoCodec.SelectedIndex)
            {
                case 0:
                    // Auto
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.Auto;
                    break;
                case 1:
                    // DV
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.DVVideo;
                    break;
                case 2:
                    // FLV1
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.FLV1;
                    break;
                case 3:
                    // GIF
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.GIF;
                    break;
                case 4:
                    // H263
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.H263;
                    break;
                case 5:
                    // H264
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.H264;
                    break;
                case 6:
                    // H264 QSV
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.H264_QSV;
                    break;
                case 7:
                    // HEVC
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.HEVC;
                    break;
                case 8:
                    // HEVC QSV
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.HEVC_QSV;
                    break;
                case 9:
                    // HuffYUV
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.HuffYUV;
                    break;
                case 10:
                    // JPEG 2000
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.JPEG2000;
                    break;
                case 11:
                    // JPEG-LS
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.JPEGLS;
                    break;
                case 12:
                    // LJPEG
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.LJPEG;
                    break;
                case 13:
                    // MJPEG
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.MJPEG;
                    break;
                case 14:
                    // MPEG-1
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.MPEG1Video;
                    break;
                case 15:
                    // MPEG-2
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.MPEG2Video;
                    break;
                case 16:
                    // MPEG-4
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.MPEG4;
                    break;
                case 17:
                    // PNG
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.PNG;
                    break;
                case 18:
                    // Theora
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.Theora;
                    break;
                case 19:
                    // VP8
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.VP8;
                    break;
                case 20:
                    // VP9
                    ffmpegOutput.Video_Encoder = VFFFMPEGEXEVideoEncoder.VP9;
                    break;
            }

            switch (cbFFEXEAspectRatio.SelectedIndex)
            {
                case 0:
                    ffmpegOutput.Video_AspectRatioW = 0;
                    ffmpegOutput.Video_AspectRatioH = 1;
                    break;
                case 1:
                    ffmpegOutput.Video_AspectRatioW = 1;
                    ffmpegOutput.Video_AspectRatioH = 1;
                    break;
                case 2:
                    ffmpegOutput.Video_AspectRatioW = 4;
                    ffmpegOutput.Video_AspectRatioH = 3;
                    break;
                case 3:
                    ffmpegOutput.Video_AspectRatioW = 16;
                    ffmpegOutput.Video_AspectRatioH = 9;
                    break;
            }

            if (cbFFEXEVideoResolutionOriginal.Checked)
            {
                ffmpegOutput.Video_Width = 0;
                ffmpegOutput.Video_Height = 0;
            }
            else
            {
                ffmpegOutput.Video_Width = Convert.ToInt32(edFFEXEVideoWidth.Text);
                ffmpegOutput.Video_Height = Convert.ToInt32(edFFEXEVideoHeight.Text);
            }

            if (rbFFEXEVideoModeCBR.Checked)
            {
                ffmpegOutput.Video_Mode = VFFFMPEGEXEVideoMode.CBR;
            }
            else if (rbFFEXEVideoModeQuality.Checked)
            {
                ffmpegOutput.Video_Mode = VFFFMPEGEXEVideoMode.Quality;
            }
            else if (rbFFEXEVideoModeABR.Checked)
            {
                ffmpegOutput.Video_Mode = VFFFMPEGEXEVideoMode.ABR;
            }

            ffmpegOutput.Video_Bitrate = Convert.ToInt32(edFFEXEVideoTargetBitrate.Text) * 1000;
            ffmpegOutput.Video_MaxBitrate = Convert.ToInt32(edFFEXEVideoBitrateMax.Text) * 1000;
            ffmpegOutput.Video_MinBitrate = Convert.ToInt32(edFFEXEVideoBitrateMin.Text) * 1000;
            ffmpegOutput.Video_BufferSize = Convert.ToInt32(edFFEXEVBVBufferSize.Text);
            ffmpegOutput.Video_GOPSize = Convert.ToInt32(edFFEXEVideoGOPSize.Text);
            ffmpegOutput.Video_BFrames = Convert.ToInt32(edFFEXEVideoBFramesCount.Text);
            ffmpegOutput.Video_Interlace = cbFFEXEVideoInterlace.Checked;
            ffmpegOutput.Video_Letterbox = cbFFEXEVideoResolutionLetterbox.Checked;
            ffmpegOutput.Video_Quality = tbFFEXEVideoQuality.Value;

            ffmpegOutput.Video_H264_Quantizer = tbFFEXEH264Quantizer.Value;
            ffmpegOutput.Video_H264_Mode = (VFFFMPEGEXEH264Mode)cbFFEXEH264Mode.SelectedIndex;
            ffmpegOutput.Video_H264_Preset = (VFFFMPEGEXEH264Preset)cbFFEXEH264Preset.SelectedIndex;
            ffmpegOutput.Video_H264_Profile = (VFFFMPEGEXEH264Profile)cbFFEXEH264Profile.SelectedIndex;
            ffmpegOutput.Video_H264_QuickTime_Compatibility = cbFFEXEH264QuickTimeCompatibility.Checked;
            ffmpegOutput.Video_H264_ZeroTolerance = cbFFEXEH264ZeroTolerance.Checked;
            ffmpegOutput.Video_H264_WebFastStart = cbFFEXEH264WebFastStart.Checked;
            ffmpegOutput.Video_TVSystem = (VFFFMPEGEXETVSystem)cbFFEXEVideoConstraint.SelectedIndex;

            switch (cbFFEXEH264Level.SelectedIndex)
            {
                case 0:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.None;
                    break;
                case 1:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level1;
                    break;
                case 2:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level11;
                    break;
                case 3:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level12;
                    break;
                case 4:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level13;
                    break;
                case 5:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level2;
                    break;
                case 6:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level21;
                    break;
                case 7:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level22;
                    break;
                case 8:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level3;
                    break;
                case 9:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level31;
                    break;
                case 10:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level32;
                    break;
                case 11:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level4;
                    break;
                case 12:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level41;
                    break;
                case 13:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level42;
                    break;
                case 14:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level5;
                    break;
                case 15:
                    ffmpegOutput.Video_H264_Level = VFFFMPEGEXEH264Level.Level51;
                    break;
            }

            switch (cbFFEXEAudioCodec.SelectedIndex)
            {
                case 0:
                    // Auto
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.Auto;
                    break;
                case 1:
                    // AAC
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.AAC;
                    break;
                case 2:
                    // AC3
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.AC3;
                    break;
                case 3:
                    // G722
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.adpcm_g722;
                    break;
                case 4:
                    // G726
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.adpcm_g726;
                    break;
                case 5:
                    // ADPCM
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.adpcm_ms;
                    break;
                case 6:
                    // ALAC
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.ALAC;
                    break;
                case 7:
                    // AMR-NB
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.AMR_NB;
                    break;
                case 8:
                    // AMR-WB
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.AMR_WB;
                    break;
                case 9:
                    // E-AC3
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.EAC3;
                    break;
                case 10:
                    // FLAC
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.FLAC;
                    break;
                case 11:
                    // G723
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.G723_1;
                    break;
                case 12:
                    // MP2
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.MP2;
                    break;
                case 13:
                    // MP3
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.MP3;
                    break;
                case 14:
                    // OPUS
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.OPUS;
                    break;
                case 15:
                    // PCM ALAW
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_ALAW;
                    break;
                case 16:
                    // PCM F32BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_F32BE;
                    break;
                case 17:
                    // PCM F32LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_F32LE;
                    break;
                case 18:
                    // PCM F64BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_F64BE;
                    break;
                case 19:
                    // PCM F64LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_F64LE;
                    break;
                case 20:
                    // PCM MULAW
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_MULAW;
                    break;
                case 21:
                    // PCM S16BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S16BE;
                    break;
                case 22:
                    // PCM S16BE Planar
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S16BE_Planar;
                    break;
                case 23:
                    // PCM S16LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S16LE;
                    break;
                case 24:
                    // PCM S16LE Planar
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S16LE_Planar;
                    break;
                case 25:
                    // PCM S24BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S24BE;
                    break;
                case 26:
                    // PCM S24LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S24LE;
                    break;
                case 27:
                    // PCM S24LE Planar
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S24LE_Planar;
                    break;
                case 28:
                    // PCM S32BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S32BE;
                    break;
                case 29:
                    // PCM S32LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S32LE;
                    break;
                case 30:
                    // PCM S32LE Planar
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S32LE_Planar;
                    break;
                case 31:
                    // PCM S8
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S8;
                    break;
                case 32:
                    // PCM S8 Planar
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_S8_Planar;
                    break;
                case 33:
                    // PCM U16BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U16BE;
                    break;
                case 34:
                    // PCM U16LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U16LE;
                    break;
                case 35:
                    // PCM U24BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U24BE;
                    break;
                case 36:
                    // PCM U24LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U24LE;
                    break;
                case 37:
                    // PCM U32BE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U32BE;
                    break;
                case 38:
                    // PCM U32LE
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U32LE;
                    break;
                case 39:
                    // PCM U8
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.PCM_U8;
                    break;
                case 40:
                    // Speex
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.Speex;
                    break;
                case 41:
                    // Vorbis
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.Vorbis;
                    break;
                case 42:
                    // WavPack
                    ffmpegOutput.Audio_Encoder = VFFFMPEGEXEAudioEncoder.WavPack;
                    break;
            }

            if (cbFFEXEAudioChannels.SelectedIndex == 0)
            {
                ffmpegOutput.Audio_Channels = 0;
            }
            else
            {
                ffmpegOutput.Audio_Channels = Convert.ToInt32(cbFFEXEAudioChannels.Text);
            }

            if (cbFFEXEAudioSampleRate.SelectedIndex == 0)
            {
                ffmpegOutput.Audio_SampleRate = 0;
            }
            else
            {
                ffmpegOutput.Audio_SampleRate = Convert.ToInt32(cbFFEXEAudioSampleRate.Text);
            }

            if (cbFFEXEAudioBitrate.SelectedIndex == 0)
            {
                ffmpegOutput.Audio_Bitrate = 0;
            }
            else
            {
                ffmpegOutput.Audio_Bitrate = Convert.ToInt32(cbFFEXEAudioBitrate.Text) * 1000;
            }

            ffmpegOutput.Audio_Quality = tbFFEXEAudioQuality.Value;

            if (rbFFEXEAudioModeCBR.Checked)
            {
                ffmpegOutput.Audio_Mode = VFFFMPEGEXEAudioMode.CBR;
            }
            else if (rbFFEXEAudioModeQuality.Checked)
            {
                ffmpegOutput.Audio_Mode = VFFFMPEGEXEAudioMode.Quality;
            }
            else if (rbFFEXEAudioModeABR.Checked)
            {
                ffmpegOutput.Audio_Mode = VFFFMPEGEXEAudioMode.ABR;
            }
            else if (rbFFEXEAudioModeLossless.Checked)
            {
                ffmpegOutput.Audio_Mode = VFFFMPEGEXEAudioMode.Lossless;
            }
        }

        private void FFEXEDisableVideoMode()
        {
            rbFFEXEVideoModeABR.Enabled = false;
            rbFFEXEVideoModeABR.Checked = false;
            rbFFEXEVideoModeCBR.Enabled = false;
            rbFFEXEVideoModeCBR.Checked = false;
            rbFFEXEVideoModeQuality.Enabled = false;
            rbFFEXEVideoModeQuality.Checked = false;

            tbFFEXEVideoQuality.Enabled = false;
            edFFEXEVideoTargetBitrate.Enabled = false;
            edFFEXEVideoBitrateMax.Enabled = false;
            edFFEXEVideoBitrateMin.Enabled = false;
        }

        private void FFEXEEnableVideoCBR()
        {
            rbFFEXEVideoModeCBR.Enabled = true;
            rbFFEXEVideoModeCBR.Checked = true;

            edFFEXEVideoTargetBitrate.Enabled = true;
        }

        private void FFEXEEnableVideoABR()
        {
            rbFFEXEVideoModeABR.Enabled = true;
            rbFFEXEVideoModeABR.Checked = true;

            edFFEXEVideoTargetBitrate.Enabled = true;
            edFFEXEVideoBitrateMax.Enabled = true;
            edFFEXEVideoBitrateMin.Enabled = true;
        }

        private void FFEXEEnableVideoQuality()
        {
            rbFFEXEVideoModeQuality.Enabled = true;
            rbFFEXEVideoModeQuality.Checked = true;

            tbFFEXEVideoQuality.Enabled = true;
        }

        private void cbFFEXEProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFFEXEProfile.SelectedIndex)
            {
                // MPEG-1
                case 0:
                    cbFFEXEOutputFormat.SelectedIndex = 23;

                    cbFFEXEVideoCodec.SelectedIndex = 14;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MPEG-1 VCD
                case 1:
                    cbFFEXEOutputFormat.SelectedIndex = 34;

                    cbFFEXEVideoCodec.SelectedIndex = 14;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2
                case 2:
                    cbFFEXEOutputFormat.SelectedIndex = 23;

                    cbFFEXEVideoCodec.SelectedIndex = 15;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MPEG-2 SVCD
                case 3:
                    cbFFEXEOutputFormat.SelectedIndex = 30;

                    cbFFEXEVideoCodec.SelectedIndex = 15;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2 DVD
                case 4:
                    cbFFEXEOutputFormat.SelectedIndex = 7;

                    cbFFEXEVideoCodec.SelectedIndex = 15;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2 TS
                case 5:
                    cbFFEXEOutputFormat.SelectedIndex = 24;

                    cbFFEXEVideoCodec.SelectedIndex = 15;
                    cbFFEXEAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // Flash Video (FLV)
                case 6:
                    cbFFEXEOutputFormat.SelectedIndex = 11;

                    cbFFEXEVideoCodec.SelectedIndex = 5;
                    cbFFEXEAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 H264 / AAC
                case 7:
                    cbFFEXEOutputFormat.SelectedIndex = 22;

                    cbFFEXEVideoCodec.SelectedIndex = 5;
                    cbFFEXEAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 H264 / AAC QSV
                case 8:
                    cbFFEXEOutputFormat.SelectedIndex = 22;

                    cbFFEXEVideoCodec.SelectedIndex = 6;
                    cbFFEXEAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 HEVC / AAC
                case 9:
                    cbFFEXEOutputFormat.SelectedIndex = 22;

                    cbFFEXEVideoCodec.SelectedIndex = 7;
                    cbFFEXEAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 HEVC / AAC QSV
                case 10:
                    cbFFEXEOutputFormat.SelectedIndex = 22;

                    cbFFEXEVideoCodec.SelectedIndex = 8;
                    cbFFEXEAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // WebM
                case 11:
                    cbFFEXEOutputFormat.SelectedIndex = 36;

                    cbFFEXEVideoCodec.SelectedIndex = 19;
                    cbFFEXEAudioCodec.SelectedIndex = 41;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // AVI
                case 12:
                    cbFFEXEOutputFormat.SelectedIndex = 4;

                    cbFFEXEVideoCodec.SelectedIndex = 16;
                    cbFFEXEAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // OGG Vorbis
                case 13:
                    cbFFEXEOutputFormat.SelectedIndex = 26;

                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    cbFFEXEAudioCodec.SelectedIndex = 41;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // Opus
                case 14:
                    cbFFEXEOutputFormat.SelectedIndex = 27;

                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    cbFFEXEAudioCodec.SelectedIndex = 14;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // Speex
                case 15:
                    cbFFEXEOutputFormat.SelectedIndex = 26;

                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    cbFFEXEAudioCodec.SelectedIndex = 40;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // FLAC
                case 16:
                    cbFFEXEOutputFormat.SelectedIndex = 10;

                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    cbFFEXEAudioCodec.SelectedIndex = 10;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP3
                case 17:
                    cbFFEXEOutputFormat.SelectedIndex = 21;

                    cbFFEXEVideoCodec.SelectedIndex = 0;
                    cbFFEXEAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // DV
                case 18:
                    cbFFEXEOutputFormat.SelectedIndex = 4;

                    cbFFEXEVideoCodec.SelectedIndex = 1;
                    cbFFEXEAudioCodec.SelectedIndex = 23;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    cbFFEXEAudioChannels.SelectedIndex = 1;
                    cbFFEXEAudioSampleRate.SelectedIndex = 1;
                    break;

                // Custom
                case 19:
                    cbFFEXEOutputFormat.SelectedIndex = 4;

                    cbFFEXEVideoCodec.SelectedIndex = 16;
                    cbFFEXEAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;
            }
        }

        private void tbFFEXEH264Quantizer_Scroll(object sender, EventArgs e)
        {
            lbFFEXEH264Quantizer.Text = tbFFEXEH264Quantizer.Value.ToString();
        }

        private void FFEXEDisableAudioMode()
        {
            rbFFEXEAudioModeABR.Enabled = false;
            rbFFEXEAudioModeABR.Checked = false;
            rbFFEXEAudioModeCBR.Enabled = false;
            rbFFEXEAudioModeCBR.Checked = false;
            rbFFEXEAudioModeQuality.Enabled = false;
            rbFFEXEAudioModeQuality.Checked = false;
            rbFFEXEAudioModeLossless.Enabled = false;
            rbFFEXEAudioModeLossless.Checked = false;

            tbFFEXEAudioQuality.Enabled = false;
            cbFFEXEAudioBitrate.Enabled = false;
        }

        private void FFEXEEnableAudioCBR()
        {
            rbFFEXEAudioModeCBR.Enabled = true;
            rbFFEXEAudioModeCBR.Checked = true;

            cbFFEXEAudioBitrate.Enabled = true;
        }

        // ReSharper disable once UnusedMember.Local
        private void FFEXEEnableAudioABR()
        {
            rbFFEXEAudioModeABR.Enabled = true;
            rbFFEXEAudioModeABR.Checked = true;

            // edFFEXEAudioTargetBitrate.Enabled = true;
            // edFFEXEAudioBitrateMax.Enabled = true;
            // edFFEXEAudioBitrateMin.Enabled = true;
        }

        private void FFEXEEnableAudioQuality()
        {
            rbFFEXEAudioModeQuality.Enabled = true;
            rbFFEXEAudioModeQuality.Checked = true;

            tbFFEXEAudioQuality.Enabled = true;
        }

        private void FFEXEEnableAudioLossless()
        {
            rbFFEXEAudioModeLossless.Enabled = true;
            rbFFEXEAudioModeLossless.Checked = true;

            // tbFFEXEAudioQuality.Enabled = true;
        }

        private void cbFFEXEAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFEXEDisableAudioMode();
            lbFFEXEAudioNotes.Text = "Notes: None.";

            switch (cbFFEXEAudioCodec.SelectedIndex)
            {
                // Auto / None
                case 0:
                    {
                    }

                    break;

                // AAC
                case 1:
                    {
                        FFEXEEnableAudioCBR();
                    }

                    break;

                // AC3
                case 2:
                    {
                        FFEXEEnableAudioCBR();
                    }

                    break;

                // G722
                case 3:
                    {
                    }

                    break;

                // G726
                case 4:
                    {
                    }

                    break;

                // ADPCM
                case 5:
                    {
                    }

                    break;

                // ALAC
                case 6:
                    {
                        FFEXEEnableAudioCBR();
                        FFEXEEnableAudioLossless();
                    }

                    break;

                // AMR-NB
                case 7:
                    {
                    }

                    break;

                // AMR-WB
                case 8:
                    {
                    }

                    break;

                // E-AC3
                case 9:
                    {
                        FFEXEEnableAudioCBR();
                    }

                    break;

                // FLAC
                case 10:
                    {
                        lbFFEXEAudioNotes.Text = "Notes: Use Quality mode, trackbar set compression level (0-12, .";

                        FFEXEEnableAudioQuality();

                        tbFFEXEAudioQuality.Minimum = 0;
                        tbFFEXEAudioQuality.Maximum = 12;
                        tbFFEXEAudioQuality.Value = 5;
                        lbFFEXEAudioQuality.Text = tbFFEXEAudioQuality.Value.ToString();
                    }

                    break;

                // G723
                case 11:
                    {
                    }

                    break;

                // MP2
                case 12:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbFFEXEAudioQuality.Minimum = 0;
                        tbFFEXEAudioQuality.Maximum = 9;
                        tbFFEXEAudioQuality.Value = 0;
                        lbFFEXEAudioQuality.Text = tbFFEXEAudioQuality.Value.ToString();
                    }

                    break;

                // MP3
                case 13:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbFFEXEAudioQuality.Minimum = 0;
                        tbFFEXEAudioQuality.Maximum = 9;
                        tbFFEXEAudioQuality.Value = 4;
                        lbFFEXEAudioQuality.Text = tbFFEXEAudioQuality.Value.ToString();
                    }

                    break;

                // OPUS
                case 14:
                    {
                        FFEXEEnableAudioCBR();
                    }

                    break;

                // PCM ALAW
                case 15:
                    {
                    }

                    break;

                // PCM F32BE
                case 16:
                    {
                    }

                    break;

                // PCM F32LE
                case 17:
                    {
                    }

                    break;

                // PCM F64BE
                case 18:
                    {
                    }

                    break;

                // PCM F64LE
                case 19:
                    {
                    }

                    break;

                // PCM MULAW
                case 20:
                    {
                    }

                    break;

                // PCM S16BE
                case 21:
                    {
                    }

                    break;

                // PCM S16BE Planar
                case 22:
                    {
                    }

                    break;

                // PCM S16LE
                case 23:
                    {
                    }

                    break;

                // PCM S16LE Planar
                case 24:
                    {
                    }

                    break;

                // PCM S24BE
                case 25:
                    {
                    }

                    break;

                // PCM S24LE
                case 26:
                    {
                    }

                    break;

                // PCM S24LE Planar
                case 27:
                    {
                    }

                    break;

                // PCM S32BE
                case 28:
                    {
                    }

                    break;

                // PCM S32LE
                case 29:
                    {
                    }

                    break;

                // PCM S32LE Planar
                case 30:
                    {
                    }

                    break;

                // PCM S8
                case 31:
                    {
                    }

                    break;

                // PCM S8 Planar
                case 32:
                    {
                    }

                    break;

                // PCM U16BE
                case 33:
                    {
                    }

                    break;

                // PCM U16LE
                case 34:
                    {
                    }

                    break;

                // PCM U24BE
                case 35:
                    {
                    }

                    break;

                // PCM U24LE
                case 36:
                    {
                    }

                    break;

                // PCM U32BE     
                case 37:
                    {
                    }

                    break;

                // PCM U32LE
                case 38:
                    {
                    }

                    break;

                // PCM U8
                case 39:
                    {
                    }

                    break;

                // Speex
                case 40:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbFFEXEAudioQuality.Minimum = 0;
                        tbFFEXEAudioQuality.Maximum = 10;
                        tbFFEXEAudioQuality.Value = 5;
                        tbFFEXEAudioQuality_Scroll(null, null);
                    }

                    break;

                // Vorbis
                case 41:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbFFEXEAudioQuality.Minimum = -1;
                        tbFFEXEAudioQuality.Maximum = 10;
                        tbFFEXEAudioQuality.Value = 5;
                        tbFFEXEAudioQuality_Scroll(null, null);
                    }

                    break;

                // WavPack
                case 42:
                    {
                    }

                    break;
            }
        }

        private void tbFFEXEAudioQuality_Scroll(object sender, EventArgs e)
        {
            lbFFEXEAudioQuality.Text = tbFFEXEAudioQuality.Value.ToString();
        }

        private void cbFFEXEVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            edFFEXEVBVBufferSize.Text = "0";
            edFFEXEVideoGOPSize.Text = "0";
            edFFEXEVideoBFramesCount.Text = "0";
            tbFFEXEVideoQuality.Minimum = 1;
            tbFFEXEVideoQuality.Maximum = 31;

            lbFFEXEVideoNotes.Text = "Notes: None.";

            FFEXEDisableVideoMode();

            switch (cbFFEXEVideoCodec.SelectedIndex)
            {
                // Auto / None
                case 0:
                    {
                        FFEXEEnableVideoABR();
                        FFEXEEnableVideoQuality();
                    }

                    break;

                // DV
                case 1:
                    {
                        lbFFEXEVideoNotes.Text = "Notes: Specify constraint settings for PAL or NTSC DV output.";
                        cbFFEXEVideoConstraint.SelectedIndex = 1;
                    }

                    break;

                // FLV1
                case 2:
                    {
                        FFEXEEnableVideoCBR();
                        FFEXEEnableVideoQuality();
                    }

                    break;

                // GIF
                case 3:
                    {
                    }

                    break;

                // H263
                case 4:
                    {
                    }

                    break;

                // H264
                case 5:
                    {
                        cbFFEXEH264Mode.SelectedIndex = 0;
                        cbFFEXEH264Level.SelectedIndex = 0;
                        cbFFEXEH264Preset.SelectedIndex = 0;
                        cbFFEXEH264Profile.SelectedIndex = 0;
                        tbFFEXEH264Quantizer.Value = 23;
                        cbFFEXEH264QuickTimeCompatibility.Checked = true;
                        cbFFEXEH264ZeroTolerance.Checked = false;
                        cbFFEXEH264WebFastStart.Checked = false;
                    }

                    break;

                // H264 QSV
                case 6:
                    {
                        cbFFEXEH264Mode.SelectedIndex = 0;
                        cbFFEXEH264Level.SelectedIndex = 0;
                        cbFFEXEH264Preset.SelectedIndex = 0;
                        cbFFEXEH264Profile.SelectedIndex = 0;
                        tbFFEXEH264Quantizer.Value = 23;
                        cbFFEXEH264QuickTimeCompatibility.Checked = true;
                        cbFFEXEH264ZeroTolerance.Checked = false;
                        cbFFEXEH264WebFastStart.Checked = false;
                    }

                    break;

                // HEVC
                case 7:
                    {
                        cbFFEXEH264Mode.SelectedIndex = 0;
                        cbFFEXEH264Level.SelectedIndex = 0;
                        cbFFEXEH264Preset.SelectedIndex = 0;
                        cbFFEXEH264Profile.SelectedIndex = 0;
                        tbFFEXEH264Quantizer.Value = 23;
                        cbFFEXEH264QuickTimeCompatibility.Checked = true;
                        cbFFEXEH264ZeroTolerance.Checked = false;
                        cbFFEXEH264WebFastStart.Checked = false;
                    }

                    break;

                // HEVC QSV
                case 8:
                    {
                        cbFFEXEH264Mode.SelectedIndex = 0;
                        cbFFEXEH264Level.SelectedIndex = 0;
                        cbFFEXEH264Preset.SelectedIndex = 0;
                        cbFFEXEH264Profile.SelectedIndex = 0;
                        tbFFEXEH264Quantizer.Value = 23;
                        cbFFEXEH264QuickTimeCompatibility.Checked = true;
                        cbFFEXEH264ZeroTolerance.Checked = false;
                        cbFFEXEH264WebFastStart.Checked = false;
                    }

                    break;

                // HuffYUV
                case 9:
                    {
                    }

                    break;

                // JPEG 2000
                case 10:
                    {
                    }

                    break;

                // JPEG-LS
                case 11:
                    {
                    }

                    break;

                // LJPEG
                case 12:
                    {
                    }

                    break;

                // MJPEG
                case 13:
                    {
                        FFEXEEnableVideoQuality();

                        tbFFEXEVideoQuality.Value = 4;
                        tbFFEXEVideoQuality_Scroll(null, null);
                    }

                    break;

                // MPEG-1
                case 14:
                    {
                        FFEXEEnableVideoCBR();

                        edFFEXEVideoBitrateMin.Text = "1000";
                        edFFEXEVideoBitrateMax.Text = "2000";
                        edFFEXEVideoTargetBitrate.Text = "1800";
                    }

                    break;

                // MPEG-2
                case 15:
                    {
                        FFEXEEnableVideoCBR();

                        edFFEXEVideoBitrateMin.Text = "2000";
                        edFFEXEVideoBitrateMax.Text = "5000";
                        edFFEXEVideoTargetBitrate.Text = "4000";

                        edFFEXEVideoGOPSize.Text = "45";
                        edFFEXEVideoBFramesCount.Text = "2";
                    }

                    break;

                // MPEG-4
                case 16:
                    {
                        FFEXEEnableVideoCBR();

                        edFFEXEVideoBitrateMin.Text = "2000";
                        edFFEXEVideoBitrateMax.Text = "5000";
                        edFFEXEVideoTargetBitrate.Text = "4000";
                    }

                    break;

                // PNG
                case 17:
                    {
                    }

                    break;

                // Theora
                case 18:
                    {
                        FFEXEEnableVideoQuality();

                        tbFFEXEVideoQuality.Minimum = 0;
                        tbFFEXEVideoQuality.Maximum = 10;
                        tbFFEXEVideoQuality.Value = 7;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edFFEXEVideoTargetBitrate.Text = "2000";
                    }

                    break;

                // VP8
                case 19:
                    {
                        FFEXEEnableVideoQuality();
                        FFEXEEnableVideoCBR();

                        tbFFEXEVideoQuality.Minimum = 4;
                        tbFFEXEVideoQuality.Maximum = 63;
                        tbFFEXEVideoQuality.Value = 10;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edFFEXEVideoTargetBitrate.Text = "2000";
                    }

                    break;

                // VP9   
                case 20:
                    {
                        FFEXEEnableVideoQuality();
                        FFEXEEnableVideoCBR();

                        tbFFEXEVideoQuality.Minimum = 4;
                        tbFFEXEVideoQuality.Maximum = 63;
                        tbFFEXEVideoQuality.Value = 10;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edFFEXEVideoTargetBitrate.Text = "2000";
                    }

                    break;
            }
        }

        private void tbFFEXEVideoQuality_Scroll(object sender, EventArgs e)
        {
            lbFFEXEVideoQuality.Text = tbFFEXEVideoQuality.Value.ToString();
        }

        private void cbFFEXEH264Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFEXEDisableVideoMode();

            switch (cbFFEXEH264Mode.SelectedIndex)
            {
                case 0:
                    // CRF
                    break;
                case 1:
                    // CRF (limited bitrate)
                    FFEXEEnableVideoCBR();
                    break;
                case 2:
                    // CBR
                    FFEXEEnableVideoCBR();
                    break;
                case 3:
                    // ABR
                    FFEXEEnableVideoABR();
                    break;
                case 4:
                    // Lossless
                    break;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }
}
