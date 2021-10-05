// <copyright file="FFMPEGEXESettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    using VisioForge.Types.FFMPEGEXE;

    /// <summary>
    /// FFMPEG.exe settings dialog.
    /// </summary>
    public partial class FFMPEGEXESettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FFMPEGEXESettingsDialog"/> class.
        /// </summary>
        public FFMPEGEXESettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbAspectRatio.SelectedIndex = 0;
            cbAudioBitrate.SelectedIndex = 8;
            cbAudioChannels.SelectedIndex = 0;
            cbAudioSampleRate.SelectedIndex = 0;
            cbProfile.SelectedIndex = 7;
            cbH264Mode.SelectedIndex = 0;
            cbH264Level.SelectedIndex = 0;
            cbH264Usage.SelectedIndex = 0;
            cbH264Profile.SelectedIndex = 0;
            cbVideoConstraint.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads FFMPEG EXE settings.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// FFMPEG settings.
        /// </param>
        public void LoadSettings(VFFFMPEGEXEOutput ffmpegOutput)
        {
            cbUsePipes.Checked = ffmpegOutput.UsePipe;
            edCustomParametersAudio.Text = ffmpegOutput.Custom_AdditionalAudioArgs;
            edCustomParametersVideo.Text = ffmpegOutput.Custom_AdditionalVideoArgs;

            if (string.IsNullOrEmpty(ffmpegOutput.Custom_AdditionalCommonArgs))
            {
                cbUseOnlyAdditionalParameters.Checked = true;
                edCustomParametersCommon.Text = ffmpegOutput.Custom_AdditionalCommonArgs;
            }
            else
            {
                cbUseOnlyAdditionalParameters.Checked = false;
                edCustomParametersCommon.Text = ffmpegOutput.Custom_AllFFMPEGArgs;
            }

            switch (ffmpegOutput.OutputMuxer)
            {
                case OutputMuxer.Mobile3G2:
                    cbOutputFormat.SelectedIndex = 0;
                    break;
                case OutputMuxer.Mobile3GP:
                    cbOutputFormat.SelectedIndex = 1;
                    break;
                case OutputMuxer.AC3:
                    cbOutputFormat.SelectedIndex = 2;
                    break;
                case OutputMuxer.ADTS:
                    cbOutputFormat.SelectedIndex = 3;
                    break;
                case OutputMuxer.AVI:
                    cbOutputFormat.SelectedIndex = 4;
                    break;
                case OutputMuxer.DTS:
                    cbOutputFormat.SelectedIndex = 5;
                    break;
                case OutputMuxer.DTSHD:
                    cbOutputFormat.SelectedIndex = 6;
                    break;
                case OutputMuxer.EAC3:
                    cbOutputFormat.SelectedIndex = 8;
                    break;
                case OutputMuxer.F4V:
                    cbOutputFormat.SelectedIndex = 9;
                    break;
                case OutputMuxer.FLAC:
                    cbOutputFormat.SelectedIndex = 10;
                    break;
                case OutputMuxer.FLV:
                    cbOutputFormat.SelectedIndex = 11;
                    break;
                case OutputMuxer.GIF:
                    cbOutputFormat.SelectedIndex = 12;
                    break;
                case OutputMuxer.H263:
                    cbOutputFormat.SelectedIndex = 13;
                    break;
                case OutputMuxer.H264:
                    cbOutputFormat.SelectedIndex = 14;
                    break;
                case OutputMuxer.HEVC:
                    cbOutputFormat.SelectedIndex = 15;
                    break;
                case OutputMuxer.Matroska:
                    cbOutputFormat.SelectedIndex = 16;
                    break;
                case OutputMuxer.M4V:
                    cbOutputFormat.SelectedIndex = 17;
                    break;
                case OutputMuxer.MJPEG:
                    cbOutputFormat.SelectedIndex = 18;
                    break;
                case OutputMuxer.MOV:
                    cbOutputFormat.SelectedIndex = 19;
                    break;
                case OutputMuxer.MP2:
                    cbOutputFormat.SelectedIndex = 20;
                    break;
                case OutputMuxer.MP3:
                    cbOutputFormat.SelectedIndex = 21;
                    break;
                case OutputMuxer.MP4:
                    cbOutputFormat.SelectedIndex = 22;
                    break;
                case OutputMuxer.MPEG:
                    cbOutputFormat.SelectedIndex = 23;
                    break;
                case OutputMuxer.MPEGTS:
                    cbOutputFormat.SelectedIndex = 24;
                    break;
                case OutputMuxer.MXF:
                    cbOutputFormat.SelectedIndex = 25;
                    break;
                case OutputMuxer.OGG:
                    cbOutputFormat.SelectedIndex = 26;
                    break;
                case OutputMuxer.OPUS:
                    cbOutputFormat.SelectedIndex = 27;
                    break;
                case OutputMuxer.PSP:
                    cbOutputFormat.SelectedIndex = 28;
                    break;
                case OutputMuxer.RAWVideo:
                    cbOutputFormat.SelectedIndex = 29;
                    break;
                case OutputMuxer.SVCD:
                    cbOutputFormat.SelectedIndex = 30;
                    break;
                case OutputMuxer.SWF:
                    cbOutputFormat.SelectedIndex = 31;
                    break;
                case OutputMuxer.TrueHD:
                    cbOutputFormat.SelectedIndex = 32;
                    break;
                case OutputMuxer.VC1:
                    cbOutputFormat.SelectedIndex = 33;
                    break;
                case OutputMuxer.VCD:
                    cbOutputFormat.SelectedIndex = 34;
                    break;
                case OutputMuxer.VOB:
                    cbOutputFormat.SelectedIndex = 7;
                    break;
                case OutputMuxer.WAV:
                    cbOutputFormat.SelectedIndex = 35;
                    break;
                case OutputMuxer.WebM:
                    cbOutputFormat.SelectedIndex = 36;
                    break;
                case OutputMuxer.WebP:
                    break;
                case OutputMuxer.WTV:
                    cbOutputFormat.SelectedIndex = 37;
                    break;
                case OutputMuxer.WV:
                    cbOutputFormat.SelectedIndex = 38;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (ffmpegOutput.Video.Encoder)
            {
                case VideoEncoder.Auto:
                    cbVideoCodec.SelectedIndex = 0;
                    break;
                case VideoEncoder.DVVideo:
                    cbVideoCodec.SelectedIndex = 1;
                    break;
                case VideoEncoder.FLV1:
                    cbVideoCodec.SelectedIndex = 2;
                    break;
                case VideoEncoder.GIF:
                    cbVideoCodec.SelectedIndex = 3;
                    break;
                case VideoEncoder.H263:
                    cbVideoCodec.SelectedIndex = 4;
                    break;
                case VideoEncoder.H264:
                    cbVideoCodec.SelectedIndex = 5;
                    break;
                case VideoEncoder.H264_QSV:
                    cbVideoCodec.SelectedIndex = 6;
                    break;
                case VideoEncoder.HEVC:
                    cbVideoCodec.SelectedIndex = 7;
                    break;
                case VideoEncoder.HEVC_QSV:
                    cbVideoCodec.SelectedIndex = 8;
                    break;
                case VideoEncoder.HuffYUV:
                    cbVideoCodec.SelectedIndex = 9;
                    break;
                case VideoEncoder.JPEG2000:
                    cbVideoCodec.SelectedIndex = 10;
                    break;
                case VideoEncoder.JPEGLS:
                    cbVideoCodec.SelectedIndex = 11;
                    break;
                case VideoEncoder.LJPEG:
                    cbVideoCodec.SelectedIndex = 12;
                    break;
                case VideoEncoder.MJPEG:
                    cbVideoCodec.SelectedIndex = 13;
                    break;
                case VideoEncoder.MPEG1Video:
                    cbVideoCodec.SelectedIndex = 14;
                    break;
                case VideoEncoder.MPEG2Video:
                    cbVideoCodec.SelectedIndex = 15;
                    break;
                case VideoEncoder.MPEG4:
                    cbVideoCodec.SelectedIndex = 16;
                    break;
                case VideoEncoder.PNG:
                    cbVideoCodec.SelectedIndex = 17;
                    break;
                case VideoEncoder.Theora:
                    cbVideoCodec.SelectedIndex = 18;
                    break;
                case VideoEncoder.VP8:
                    cbVideoCodec.SelectedIndex = 19;
                    break;
                case VideoEncoder.VP9:
                    cbVideoCodec.SelectedIndex = 20;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ffmpegOutput.Video.AspectRatioW == 0 && ffmpegOutput.Video.AspectRatioH == 1)
            {
                cbAspectRatio.SelectedIndex = 0;
            }
            else if (ffmpegOutput.Video.AspectRatioW == 1 && ffmpegOutput.Video.AspectRatioH == 1)
            {
                cbAspectRatio.SelectedIndex = 1;
            }
            else if (ffmpegOutput.Video.AspectRatioW == 4 && ffmpegOutput.Video.AspectRatioH == 3)
            {
                cbAspectRatio.SelectedIndex = 2;
            }
            else
            {
                cbAspectRatio.SelectedIndex = 3;
            }

            if (Convert.ToInt32(edVideoWidth.Text) == 0 || Convert.ToInt32(edVideoHeight.Text) == 0)
            {
                cbVideoResolutionOriginal.Checked = true;
            }
            else
            {
                cbVideoResolutionOriginal.Checked = false;
            }

            switch (ffmpegOutput.Video.BasicMode)
            {
                case VideoMode.CBR:
                    rbVideoModeCBR.Checked = true;
                    break;
                case VideoMode.ABR:
                    rbVideoModeABR.Checked = true;
                    break;
                case VideoMode.Quality:
                    rbVideoModeQuality.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            edVideoTargetBitrate.Text = ((int)(ffmpegOutput.Video.Bitrate / 1000.0)).ToString();
            edVideoBitrateMax.Text = ((int)(ffmpegOutput.Video.MaxBitrate / 1000.0)).ToString();
            edVideoBitrateMin.Text = ((int)(ffmpegOutput.Video.MinBitrate / 1000.0)).ToString();
            edVBVBufferSize.Text = ffmpegOutput.VideoBufferSize.ToString();
            cbVideoInterlace.Checked = ffmpegOutput.Video.Interlace;
            cbVideoResolutionLetterbox.Checked = ffmpegOutput.Video.Letterbox;
            tbVideoQuality.Value = ffmpegOutput.Video.Quality;
            cbVideoConstraint.SelectedIndex = (int)ffmpegOutput.Video.TVSystem;

            if (ffmpegOutput.Video.GetType() == typeof(H264MFSettings)
                || ffmpegOutput.Video.GetType() == typeof(HEVCMFSettings))
            {
                edVideoTargetBitrate.Enabled = true;
                tbVideoQuality.Enabled = true;

                var mf = (CommonMFSettings)ffmpegOutput.Video;

                //edVideoGOPSize.Text = ffmpegOutput.Video.GOPSize.ToString();
                //edVideoBFramesCount.Text = ffmpegOutput.Video.BFrames.ToString();
                cbH264Mode.SelectedIndex = (int)mf.RateControl;
                cbForceHWEncoding.Checked = mf.ForceHWEncoding;

                //cbH264Usage.SelectedIndex = (int)ffmpegOutput.Video.H264_Preset;
                //cbH264Profile.SelectedIndex = (int)ffmpegOutput.Video_H264_Profile;
                //cbH264QuickTimeCompatibility.Checked = ffmpegOutput.Video_H264_QuickTime_Compatibility;
                //cbH264ZeroTolerance.Checked = ffmpegOutput.Video_H264_ZeroTolerance;
                //cbH264WebFastStart.Checked = ffmpegOutput.Video_X264_WebFastStart;

                //switch (ffmpegOutput.Video_H264_Level)
                //{
                //    case H264Level.None:
                //        cbH264Level.SelectedIndex = 0;
                //        break;
                //    case H264Level.Level1:
                //        cbH264Level.SelectedIndex = 1;
                //        break;
                //    case H264Level.Level11:
                //        cbH264Level.SelectedIndex = 2;
                //        break;
                //    case H264Level.Level12:
                //        cbH264Level.SelectedIndex = 3;
                //        break;
                //    case H264Level.Level13:
                //        cbH264Level.SelectedIndex = 4;
                //        break;
                //    case H264Level.Level2:
                //        cbH264Level.SelectedIndex = 5;
                //        break;
                //    case H264Level.Level21:
                //        cbH264Level.SelectedIndex = 6;
                //        break;
                //    case H264Level.Level22:
                //        cbH264Level.SelectedIndex = 7;
                //        break;
                //    case H264Level.Level3:
                //        cbH264Level.SelectedIndex = 8;
                //        break;
                //    case H264Level.Level31:
                //        cbH264Level.SelectedIndex = 9;
                //        break;
                //    case H264Level.Level32:
                //        cbH264Level.SelectedIndex = 10;
                //        break;
                //    case H264Level.Level4:
                //        cbH264Level.SelectedIndex = 11;
                //        break;
                //    case H264Level.Level41:
                //        cbH264Level.SelectedIndex = 12;
                //        break;
                //    case H264Level.Level42:
                //        cbH264Level.SelectedIndex = 13;
                //        break;
                //    case H264Level.Level5:
                //        cbH264Level.SelectedIndex = 14;
                //        break;
                //    case H264Level.Level51:
                //        cbH264Level.SelectedIndex = 15;
                //        break;
                //    default:
                //        throw new ArgumentOutOfRangeException();
                //}
            }

            switch (ffmpegOutput.Audio.Encoder)
            {
                case AudioEncoder.Auto:
                    cbAudioCodec.SelectedIndex = 0;
                    break;
                case AudioEncoder.AAC:
                    cbAudioCodec.SelectedIndex = 1;
                    break;
                case AudioEncoder.AC3:
                    cbAudioCodec.SelectedIndex = 2;
                    break;
                case AudioEncoder.ADPCM_G722:
                    cbAudioCodec.SelectedIndex = 3;
                    break;
                case AudioEncoder.ADPCM_G726:
                    cbAudioCodec.SelectedIndex = 4;
                    break;
                case AudioEncoder.ADPCM_MS:
                    cbAudioCodec.SelectedIndex = 5;
                    break;
                case AudioEncoder.ALAC:
                    cbAudioCodec.SelectedIndex = 6;
                    break;
                case AudioEncoder.AMR_NB:
                    cbAudioCodec.SelectedIndex = 7;
                    break;
                case AudioEncoder.AMR_WB:
                    cbAudioCodec.SelectedIndex = 8;
                    break;
                case AudioEncoder.EAC3:
                    cbAudioCodec.SelectedIndex = 9;
                    break;
                case AudioEncoder.FLAC:
                    cbAudioCodec.SelectedIndex = 10;
                    break;
                case AudioEncoder.G723_1:
                    cbAudioCodec.SelectedIndex = 11;
                    break;
                case AudioEncoder.MP2:
                    cbAudioCodec.SelectedIndex = 12;
                    break;
                case AudioEncoder.MP3:
                    cbAudioCodec.SelectedIndex = 13;
                    break;
                case AudioEncoder.OPUS:
                    cbAudioCodec.SelectedIndex = 14;
                    break;
                case AudioEncoder.PCM_ALAW:
                    cbAudioCodec.SelectedIndex = 15;
                    break;
                case AudioEncoder.PCM_F32BE:
                    cbAudioCodec.SelectedIndex = 16;
                    break;
                case AudioEncoder.PCM_F32LE:
                    cbAudioCodec.SelectedIndex = 17;
                    break;
                case AudioEncoder.PCM_F64BE:
                    cbAudioCodec.SelectedIndex = 18;
                    break;
                case AudioEncoder.PCM_F64LE:
                    cbAudioCodec.SelectedIndex = 19;
                    break;
                case AudioEncoder.PCM_MULAW:
                    cbAudioCodec.SelectedIndex = 20;
                    break;
                case AudioEncoder.PCM_S16BE:
                    cbAudioCodec.SelectedIndex = 21;
                    break;
                case AudioEncoder.PCM_S16BE_Planar:
                    cbAudioCodec.SelectedIndex = 22;
                    break;
                case AudioEncoder.PCM_S16LE:
                    cbAudioCodec.SelectedIndex = 23;
                    break;
                case AudioEncoder.PCM_S16LE_Planar:
                    cbAudioCodec.SelectedIndex = 24;
                    break;
                case AudioEncoder.PCM_S24BE:
                    cbAudioCodec.SelectedIndex = 25;
                    break;
                case AudioEncoder.PCM_S24daud:
                    break;
                case AudioEncoder.PCM_S24LE:
                    cbAudioCodec.SelectedIndex = 26;
                    break;
                case AudioEncoder.PCM_S24LE_Planar:
                    cbAudioCodec.SelectedIndex = 27;
                    break;
                case AudioEncoder.PCM_S32BE:
                    cbAudioCodec.SelectedIndex = 28;
                    break;
                case AudioEncoder.PCM_S32LE:
                    cbAudioCodec.SelectedIndex = 29;
                    break;
                case AudioEncoder.PCM_S32LE_Planar:
                    cbAudioCodec.SelectedIndex = 30;
                    break;
                case AudioEncoder.PCM_S8:
                    cbAudioCodec.SelectedIndex = 31;
                    break;
                case AudioEncoder.PCM_S8_Planar:
                    cbAudioCodec.SelectedIndex = 32;
                    break;
                case AudioEncoder.PCM_U16BE:
                    cbAudioCodec.SelectedIndex = 33;
                    break;
                case AudioEncoder.PCM_U16LE:
                    cbAudioCodec.SelectedIndex = 34;
                    break;
                case AudioEncoder.PCM_U24BE:
                    cbAudioCodec.SelectedIndex = 35;
                    break;
                case AudioEncoder.PCM_U24LE:
                    cbAudioCodec.SelectedIndex = 36;
                    break;
                case AudioEncoder.PCM_U32BE:
                    cbAudioCodec.SelectedIndex = 37;
                    break;
                case AudioEncoder.PCM_U32LE:
                    cbAudioCodec.SelectedIndex = 38;
                    break;
                case AudioEncoder.PCM_U8:
                    cbAudioCodec.SelectedIndex = 39;
                    break;
                case AudioEncoder.Speex:
                    cbAudioCodec.SelectedIndex = 40;
                    break;
                case AudioEncoder.Vorbis:
                    cbAudioCodec.SelectedIndex = 41;
                    break;
                case AudioEncoder.WavPack:
                    cbAudioCodec.SelectedIndex = 42;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ffmpegOutput.Audio.Channels == 0)
            {
                cbAudioChannels.SelectedIndex = 0;
            }
            else
            {
                cbAudioChannels.Text = ffmpegOutput.Audio.Channels.ToString();
            }

            if (ffmpegOutput.Audio.SampleRate == 0)
            {
                cbAudioSampleRate.SelectedIndex = 0;
            }
            else
            {
                cbAudioSampleRate.Text = ffmpegOutput.Audio.SampleRate.ToString();
            }

            if (ffmpegOutput.Audio.Bitrate == 0)
            {
                cbAudioBitrate.SelectedIndex = 0;
            }
            else
            {
                cbAudioBitrate.Text = ffmpegOutput.Audio.Bitrate.ToString();
            }

            tbAudioQuality.Value = ffmpegOutput.Audio.Quality;

            switch (ffmpegOutput.Audio.Mode)
            {
                case AudioMode.None:
                case AudioMode.CBR:
                    rbAudioModeCBR.Checked = true;
                    break;
                case AudioMode.ABR:
                    rbAudioModeABR.Checked = true;
                    break;
                case AudioMode.Quality:
                    rbAudioModeQuality.Checked = true;
                    break;
                case AudioMode.Lossless:
                    rbAudioModeLossless.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// Output settings.
        /// </param>
        public void SaveSettings(ref VFFFMPEGEXEOutput ffmpegOutput)
        {
            ffmpegOutput.UsePipe = cbUsePipes.Checked;
            ffmpegOutput.Custom_AdditionalAudioArgs = edCustomParametersAudio.Text;
            ffmpegOutput.Custom_AdditionalVideoArgs = edCustomParametersVideo.Text;

            if (cbUseOnlyAdditionalParameters.Checked)
            {
                ffmpegOutput.Custom_AllFFMPEGArgs = edCustomParametersCommon.Text;
            }
            else
            {
                ffmpegOutput.Custom_AdditionalCommonArgs = edCustomParametersCommon.Text;
            }

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    // 3G2
                    ffmpegOutput.OutputMuxer = OutputMuxer.Mobile3G2;
                    break;
                case 1:
                    // 3GP
                    ffmpegOutput.OutputMuxer = OutputMuxer.Mobile3GP;
                    break;
                case 2:
                    // AC3
                    ffmpegOutput.OutputMuxer = OutputMuxer.AC3;
                    break;
                case 3:
                    // ADTS
                    ffmpegOutput.OutputMuxer = OutputMuxer.ADTS;
                    break;
                case 4:
                    // AVI
                    ffmpegOutput.OutputMuxer = OutputMuxer.AVI;
                    break;
                case 5:
                    // DTS
                    ffmpegOutput.OutputMuxer = OutputMuxer.DTS;
                    break;
                case 6:
                    // DTS-HD
                    ffmpegOutput.OutputMuxer = OutputMuxer.DTSHD;
                    break;
                case 7:
                    // DVD (VOB)
                    ffmpegOutput.OutputMuxer = OutputMuxer.VOB;
                    break;
                case 8:
                    // E-AC3
                    ffmpegOutput.OutputMuxer = OutputMuxer.EAC3;
                    break;
                case 9:
                    // F4V
                    ffmpegOutput.OutputMuxer = OutputMuxer.F4V;
                    break;
                case 10:
                    // FLAC
                    ffmpegOutput.OutputMuxer = OutputMuxer.FLAC;
                    break;
                case 11:
                    // FLV
                    ffmpegOutput.OutputMuxer = OutputMuxer.FLV;
                    break;
                case 12:
                    // GIF
                    ffmpegOutput.OutputMuxer = OutputMuxer.GIF;
                    break;
                case 13:
                    // H263
                    ffmpegOutput.OutputMuxer = OutputMuxer.H263;
                    break;
                case 14:
                    // H264
                    ffmpegOutput.OutputMuxer = OutputMuxer.H264;
                    break;
                case 15:
                    // HEVC
                    ffmpegOutput.OutputMuxer = OutputMuxer.HEVC;
                    break;
                case 16:
                    // Matroska
                    ffmpegOutput.OutputMuxer = OutputMuxer.Matroska;
                    break;
                case 17:
                    // M4V
                    ffmpegOutput.OutputMuxer = OutputMuxer.M4V;
                    break;
                case 18:
                    // MJPEG
                    ffmpegOutput.OutputMuxer = OutputMuxer.MJPEG;
                    break;
                case 19:
                    // MOV
                    ffmpegOutput.OutputMuxer = OutputMuxer.MOV;
                    break;
                case 20:
                    // MP2
                    ffmpegOutput.OutputMuxer = OutputMuxer.MP2;
                    break;
                case 21:
                    // MP3
                    ffmpegOutput.OutputMuxer = OutputMuxer.MP3;
                    break;
                case 22:
                    // MP4
                    ffmpegOutput.OutputMuxer = OutputMuxer.MP4;
                    break;
                case 23:
                    // MPEG
                    ffmpegOutput.OutputMuxer = OutputMuxer.MPEG;
                    break;
                case 24:
                    // MPEGTS
                    ffmpegOutput.OutputMuxer = OutputMuxer.MPEGTS;
                    break;
                case 25:
                    // MXF
                    ffmpegOutput.OutputMuxer = OutputMuxer.MXF;
                    break;
                case 26:
                    // OGG
                    ffmpegOutput.OutputMuxer = OutputMuxer.OGG;
                    break;
                case 27:
                    // OPUS
                    ffmpegOutput.OutputMuxer = OutputMuxer.OPUS;
                    break;
                case 28:
                    // PSP MP4
                    ffmpegOutput.OutputMuxer = OutputMuxer.PSP;
                    break;
                case 29:
                    // RAWVideo
                    ffmpegOutput.OutputMuxer = OutputMuxer.RAWVideo;
                    break;
                case 30:
                    // SVCD
                    ffmpegOutput.OutputMuxer = OutputMuxer.SVCD;
                    break;
                case 31:
                    // SWF
                    ffmpegOutput.OutputMuxer = OutputMuxer.SWF;
                    break;
                case 32:
                    // TrueHD
                    ffmpegOutput.OutputMuxer = OutputMuxer.TrueHD;
                    break;
                case 33:
                    // VC1
                    ffmpegOutput.OutputMuxer = OutputMuxer.VC1;
                    break;
                case 34:
                    // VCD
                    ffmpegOutput.OutputMuxer = OutputMuxer.VCD;
                    break;
                case 35:
                    // WAV
                    ffmpegOutput.OutputMuxer = OutputMuxer.WAV;
                    break;
                case 36:
                    // WebM
                    ffmpegOutput.OutputMuxer = OutputMuxer.WebM;
                    break;
                case 37:
                    // WTV
                    ffmpegOutput.OutputMuxer = OutputMuxer.WTV;
                    break;
                case 38:
                    // WV (WavPack)
                    ffmpegOutput.OutputMuxer = OutputMuxer.WV;
                    break;
            }

            var videoEncoderSettings = new BasicVideoSettings();
            VideoEncoder videoEncoder;
            switch (cbVideoCodec.SelectedIndex)
            {
                case 0:
                    // Auto
                    videoEncoder = VideoEncoder.Auto;
                    break;
                case 1:
                    // DV
                    videoEncoder = VideoEncoder.DVVideo;
                    break;
                case 2:
                    // FLV1
                    videoEncoder = VideoEncoder.FLV1;
                    break;
                case 3:
                    // GIF
                    videoEncoder = VideoEncoder.GIF;
                    break;
                case 4:
                    // H263
                    videoEncoder = VideoEncoder.H263;
                    break;
                case 5:
                    // H264
                    videoEncoder = VideoEncoder.H264;
                    videoEncoderSettings = new H264MFSettings();
                    break;
                case 6:
                    // H264 QSV
                    videoEncoder = VideoEncoder.H264_QSV;
                    break;
                case 7:
                    // H264 NVENC
                    videoEncoder = VideoEncoder.H264_NVENC;
                    videoEncoderSettings = new H264NVENCSettings();
                    break;
                case 8:
                    // HEVC
                    videoEncoder = VideoEncoder.HEVC;
                    videoEncoderSettings = new HEVCMFSettings();
                    break;
                case 9:
                    // HEVC QSV
                    videoEncoder = VideoEncoder.HEVC_QSV;
                    break;
                case 10:
                    // HEVC NVENC
                    videoEncoder = VideoEncoder.HEVC_NVENC;
                    videoEncoderSettings = new HEVCNVENCSettings();
                    break;
                case 11:
                    // HuffYUV
                    videoEncoder = VideoEncoder.HuffYUV;
                    break;
                case 12:
                    // JPEG 2000
                    videoEncoder = VideoEncoder.JPEG2000;
                    break;
                case 13:
                    // JPEG-LS
                    videoEncoder = VideoEncoder.JPEGLS;
                    break;
                case 14:
                    // LJPEG
                    videoEncoder = VideoEncoder.LJPEG;
                    break;
                case 15:
                    // MJPEG
                    videoEncoder = VideoEncoder.MJPEG;
                    break;
                case 16:
                    // MPEG-1
                    videoEncoder = VideoEncoder.MPEG1Video;
                    break;
                case 17:
                    // MPEG-2
                    videoEncoder = VideoEncoder.MPEG2Video;
                    videoEncoderSettings = new MPEG2Settings();
                    break;
                case 18:
                    // MPEG-4
                    videoEncoder = VideoEncoder.MPEG4;
                    break;
                case 19:
                    // PNG
                    videoEncoder = VideoEncoder.PNG;
                    break;
                case 20:
                    // Theora
                    videoEncoder = VideoEncoder.Theora;
                    break;
                case 21:
                    // VP8
                    videoEncoder = VideoEncoder.VP8;
                    break;
                case 22:
                    // VP9
                    videoEncoder = VideoEncoder.VP9;
                    break;
                default:
                    videoEncoder = VideoEncoder.H264;
                    break;
            }

            ffmpegOutput.Video = videoEncoderSettings;
            ffmpegOutput.Video.Encoder = videoEncoder;

            switch (cbAspectRatio.SelectedIndex)
            {
                case 0:
                    ffmpegOutput.Video.AspectRatioW = 0;
                    ffmpegOutput.Video.AspectRatioH = 1;
                    break;
                case 1:
                    ffmpegOutput.Video.AspectRatioW = 1;
                    ffmpegOutput.Video.AspectRatioH = 1;
                    break;
                case 2:
                    ffmpegOutput.Video.AspectRatioW = 4;
                    ffmpegOutput.Video.AspectRatioH = 3;
                    break;
                case 3:
                    ffmpegOutput.Video.AspectRatioW = 16;
                    ffmpegOutput.Video.AspectRatioH = 9;
                    break;
            }

            if (cbVideoResolutionOriginal.Checked)
            {
                ffmpegOutput.Video.Width = 0;
                ffmpegOutput.Video.Height = 0;
            }
            else
            {
                ffmpegOutput.Video.Width = Convert.ToInt32(edVideoWidth.Text);
                ffmpegOutput.Video.Height = Convert.ToInt32(edVideoHeight.Text);
            }

            if (rbVideoModeCBR.Checked)
            {
                ffmpegOutput.Video.BasicMode = VideoMode.CBR;
            }
            else if (rbVideoModeQuality.Checked)
            {
                ffmpegOutput.Video.BasicMode = VideoMode.Quality;
            }
            else if (rbVideoModeABR.Checked)
            {
                ffmpegOutput.Video.BasicMode = VideoMode.ABR;
            }

            ffmpegOutput.Video.Bitrate = Convert.ToInt32(edVideoTargetBitrate.Text) * 1000;
            ffmpegOutput.Video.MaxBitrate = Convert.ToInt32(edVideoBitrateMax.Text) * 1000;
            ffmpegOutput.Video.MinBitrate = Convert.ToInt32(edVideoBitrateMin.Text) * 1000;
            ffmpegOutput.Video.Interlace = cbVideoInterlace.Checked;
            ffmpegOutput.Video.Letterbox = cbVideoResolutionLetterbox.Checked;
            ffmpegOutput.Video.Quality = tbVideoQuality.Value;
            ffmpegOutput.Video.TVSystem = (TVSystem)cbVideoConstraint.SelectedIndex;
            ffmpegOutput.VideoBufferSize = Convert.ToInt32(edVBVBufferSize.Text);

            if (ffmpegOutput.Video.GetType() == typeof(H264MFSettings)
                || ffmpegOutput.Video.GetType() == typeof(HEVCMFSettings))
            {
                var mf = (CommonMFSettings)ffmpegOutput.Video;

                mf.ForceHWEncoding = cbForceHWEncoding.Checked;
                mf.RateControl = (H264MFRateControl)cbH264Mode.SelectedIndex;
                switch (cbH264Usage.SelectedIndex)
                {
                    case 0:
                        mf.Scenario = H264MFScenario.Default;
                        break;
                    case 1:
                        mf.Scenario = H264MFScenario.DisplayRemoting;
                        break;
                    case 2:
                        mf.Scenario = H264MFScenario.VideoConference;
                        break;
                    case 3:
                        mf.Scenario = H264MFScenario.Archive;
                        break;
                    case 4:
                        mf.Scenario = H264MFScenario.LiveStreaming;
                        break;
                    case 5:
                        mf.Scenario = H264MFScenario.CameraRecord;
                        break;
                    case 6:
                        mf.Scenario = H264MFScenario.DisplayRemotingWithFeatureMap;
                        break;
                }

                if (videoEncoderSettings.GetType() == typeof(MPEG2Settings))
                {
                    (videoEncoderSettings as MPEG2Settings).GOPSize = Convert.ToInt32(edVideoGOPSize.Text);
                    (videoEncoderSettings as MPEG2Settings).BFrames = Convert.ToInt32(edVideoBFramesCount.Text);
                }
                
                //ffmpegOutput.Video_X264_Quantizer = tbFFEXEH264Quantizer.Value;
                //ffmpegOutput.Video_H264_Mode = (VFFFMPEGEXEH264Mode)cbFFEXEH264Mode.SelectedIndex;
                //ffmpegOutput.Video_H264_Preset = (X264Preset)cbFFEXEH264Usage.SelectedIndex;
                //ffmpegOutput.Video_H264_Profile = (H264Profile)cbFFEXEH264Profile.SelectedIndex;
                //ffmpegOutput.Video_H264_QuickTime_Compatibility = cbFFEXEH264QuickTimeCompatibility.Checked;
                //ffmpegOutput.Video_H264_ZeroTolerance = cbFFEXEH264ZeroTolerance.Checked;
                //ffmpegOutput.Video_X264_WebFastStart = cbFFEXEH264WebFastStart.Checked;

                //switch (cbFFEXEH264Level.SelectedIndex)
                //{
                //    case 0:
                //        ffmpegOutput.Video_H264_Level = H264Level.None;
                //        break;
                //    case 1:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level1;
                //        break;
                //    case 2:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level11;
                //        break;
                //    case 3:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level12;
                //        break;
                //    case 4:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level13;
                //        break;
                //    case 5:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level2;
                //        break;
                //    case 6:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level21;
                //        break;
                //    case 7:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level22;
                //        break;
                //    case 8:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level3;
                //        break;
                //    case 9:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level31;
                //        break;
                //    case 10:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level32;
                //        break;
                //    case 11:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level4;
                //        break;
                //    case 12:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level41;
                //        break;
                //    case 13:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level42;
                //        break;
                //    case 14:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level5;
                //        break;
                //    case 15:
                //        ffmpegOutput.Video_H264_Level = H264Level.Level51;
                //        break;
                //}
            }

            switch (cbAudioCodec.SelectedIndex)
            {
                case 0:
                    // Auto
                    ffmpegOutput.Audio.Encoder = AudioEncoder.Auto;
                    break;
                case 1:
                    // AAC
                    ffmpegOutput.Audio.Encoder = AudioEncoder.AAC;
                    break;
                case 2:
                    // AC3
                    ffmpegOutput.Audio.Encoder = AudioEncoder.AC3;
                    break;
                case 3:
                    // G722
                    ffmpegOutput.Audio.Encoder = AudioEncoder.ADPCM_G722;
                    break;
                case 4:
                    // G726
                    ffmpegOutput.Audio.Encoder = AudioEncoder.ADPCM_G726;
                    break;
                case 5:
                    // ADPCM
                    ffmpegOutput.Audio.Encoder = AudioEncoder.ADPCM_MS;
                    break;
                case 6:
                    // ALAC
                    ffmpegOutput.Audio.Encoder = AudioEncoder.ALAC;
                    break;
                case 7:
                    // AMR-NB
                    ffmpegOutput.Audio.Encoder = AudioEncoder.AMR_NB;
                    break;
                case 8:
                    // AMR-WB
                    ffmpegOutput.Audio.Encoder = AudioEncoder.AMR_WB;
                    break;
                case 9:
                    // E-AC3
                    ffmpegOutput.Audio.Encoder = AudioEncoder.EAC3;
                    break;
                case 10:
                    // FLAC
                    ffmpegOutput.Audio.Encoder = AudioEncoder.FLAC;
                    break;
                case 11:
                    // G723
                    ffmpegOutput.Audio.Encoder = AudioEncoder.G723_1;
                    break;
                case 12:
                    // MP2
                    ffmpegOutput.Audio.Encoder = AudioEncoder.MP2;
                    break;
                case 13:
                    // MP3
                    ffmpegOutput.Audio.Encoder = AudioEncoder.MP3;
                    break;
                case 14:
                    // OPUS
                    ffmpegOutput.Audio.Encoder = AudioEncoder.OPUS;
                    break;
                case 15:
                    // PCM ALAW
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_ALAW;
                    break;
                case 16:
                    // PCM F32BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_F32BE;
                    break;
                case 17:
                    // PCM F32LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_F32LE;
                    break;
                case 18:
                    // PCM F64BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_F64BE;
                    break;
                case 19:
                    // PCM F64LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_F64LE;
                    break;
                case 20:
                    // PCM MULAW
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_MULAW;
                    break;
                case 21:
                    // PCM S16BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S16BE;
                    break;
                case 22:
                    // PCM S16BE Planar
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S16BE_Planar;
                    break;
                case 23:
                    // PCM S16LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S16LE;
                    break;
                case 24:
                    // PCM S16LE Planar
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S16LE_Planar;
                    break;
                case 25:
                    // PCM S24BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S24BE;
                    break;
                case 26:
                    // PCM S24LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S24LE;
                    break;
                case 27:
                    // PCM S24LE Planar
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S24LE_Planar;
                    break;
                case 28:
                    // PCM S32BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S32BE;
                    break;
                case 29:
                    // PCM S32LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S32LE;
                    break;
                case 30:
                    // PCM S32LE Planar
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S32LE_Planar;
                    break;
                case 31:
                    // PCM S8
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S8;
                    break;
                case 32:
                    // PCM S8 Planar
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_S8_Planar;
                    break;
                case 33:
                    // PCM U16BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U16BE;
                    break;
                case 34:
                    // PCM U16LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U16LE;
                    break;
                case 35:
                    // PCM U24BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U24BE;
                    break;
                case 36:
                    // PCM U24LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U24LE;
                    break;
                case 37:
                    // PCM U32BE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U32BE;
                    break;
                case 38:
                    // PCM U32LE
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U32LE;
                    break;
                case 39:
                    // PCM U8
                    ffmpegOutput.Audio.Encoder = AudioEncoder.PCM_U8;
                    break;
                case 40:
                    // Speex
                    ffmpegOutput.Audio.Encoder = AudioEncoder.Speex;
                    break;
                case 41:
                    // Vorbis
                    ffmpegOutput.Audio.Encoder = AudioEncoder.Vorbis;
                    break;
                case 42:
                    // WavPack
                    ffmpegOutput.Audio.Encoder = AudioEncoder.WavPack;
                    break;
            }

            if (cbAudioChannels.SelectedIndex == 0)
            {
                ffmpegOutput.Audio.Channels = 0;
            }
            else
            {
                ffmpegOutput.Audio.Channels = Convert.ToInt32(cbAudioChannels.Text);
            }

            if (cbAudioSampleRate.SelectedIndex == 0)
            {
                ffmpegOutput.Audio.SampleRate = 0;
            }
            else
            {
                ffmpegOutput.Audio.SampleRate = Convert.ToInt32(cbAudioSampleRate.Text);
            }

            if (cbAudioBitrate.SelectedIndex == 0)
            {
                ffmpegOutput.Audio.Bitrate = 0;
            }
            else
            {
                ffmpegOutput.Audio.Bitrate = Convert.ToInt32(cbAudioBitrate.Text) * 1000;
            }

            ffmpegOutput.Audio.Quality = tbAudioQuality.Value;

            if (rbAudioModeCBR.Checked)
            {
                ffmpegOutput.Audio.Mode = AudioMode.CBR;
            }
            else if (rbAudioModeQuality.Checked)
            {
                ffmpegOutput.Audio.Mode = AudioMode.Quality;
            }
            else if (rbAudioModeABR.Checked)
            {
                ffmpegOutput.Audio.Mode = AudioMode.ABR;
            }
            else if (rbAudioModeLossless.Checked)
            {
                ffmpegOutput.Audio.Mode = AudioMode.Lossless;
            }
        }

        private void FFEXEDisableVideoMode()
        {
            rbVideoModeABR.Enabled = false;
            rbVideoModeABR.Checked = false;
            rbVideoModeCBR.Enabled = false;
            rbVideoModeCBR.Checked = false;
            rbVideoModeQuality.Enabled = false;
            rbVideoModeQuality.Checked = false;

            tbVideoQuality.Enabled = false;
            edVideoTargetBitrate.Enabled = false;
            edVideoBitrateMax.Enabled = false;
            edVideoBitrateMin.Enabled = false;
        }

        private void FFEXEEnableVideoCBR()
        {
            rbVideoModeCBR.Enabled = true;
            rbVideoModeCBR.Checked = true;

            edVideoTargetBitrate.Enabled = true;
        }

        private void FFEXEEnableVideoABR()
        {
            rbVideoModeABR.Enabled = true;
            rbVideoModeABR.Checked = true;

            edVideoTargetBitrate.Enabled = true;
            edVideoBitrateMax.Enabled = true;
            edVideoBitrateMin.Enabled = true;
        }

        private void FFEXEEnableVideoQuality()
        {
            rbVideoModeQuality.Enabled = true;
            rbVideoModeQuality.Checked = true;

            tbVideoQuality.Enabled = true;
        }

        private void cbFFEXEProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbProfile.SelectedIndex)
            {
                // MPEG-1
                case 0:
                    cbOutputFormat.SelectedIndex = 23;

                    cbVideoCodec.SelectedIndex = 14;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MPEG-1 VCD
                case 1:
                    cbOutputFormat.SelectedIndex = 34;

                    cbVideoCodec.SelectedIndex = 14;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2
                case 2:
                    cbOutputFormat.SelectedIndex = 23;

                    cbVideoCodec.SelectedIndex = 15;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MPEG-2 SVCD
                case 3:
                    cbOutputFormat.SelectedIndex = 30;

                    cbVideoCodec.SelectedIndex = 15;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2 DVD
                case 4:
                    cbOutputFormat.SelectedIndex = 7;

                    cbVideoCodec.SelectedIndex = 15;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MPEG-2 TS
                case 5:
                    cbOutputFormat.SelectedIndex = 24;

                    cbVideoCodec.SelectedIndex = 15;
                    cbAudioCodec.SelectedIndex = 12;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // Flash Video (FLV)
                case 6:
                    cbOutputFormat.SelectedIndex = 11;

                    cbVideoCodec.SelectedIndex = 5;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 H264 / AAC
                case 7:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 5;
                    cbAudioCodec.SelectedIndex = 1;
                    
                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    break;

                // MP4 H264 / AAC QSV
                case 8:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 6;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 H264 / AAC NVENC
                case 9:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 7;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 HEVC / AAC
                case 10:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 7;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 HEVC / AAC QSV
                case 11:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 8;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP4 HEVC / AAC NVENC
                case 12:
                    cbOutputFormat.SelectedIndex = 22;

                    cbVideoCodec.SelectedIndex = 10;
                    cbAudioCodec.SelectedIndex = 1;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // WebM
                case 13:
                    cbOutputFormat.SelectedIndex = 36;

                    cbVideoCodec.SelectedIndex = 19;
                    cbAudioCodec.SelectedIndex = 41;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // AVI
                case 14:
                    cbOutputFormat.SelectedIndex = 4;

                    cbVideoCodec.SelectedIndex = 16;
                    cbAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // OGG Vorbis
                case 15:
                    cbOutputFormat.SelectedIndex = 26;

                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 41;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // Opus
                case 16:
                    cbOutputFormat.SelectedIndex = 27;

                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 14;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // Speex
                case 17:
                    cbOutputFormat.SelectedIndex = 26;

                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 40;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // FLAC
                case 18:
                    cbOutputFormat.SelectedIndex = 10;

                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 10;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // MP3
                case 19:
                    cbOutputFormat.SelectedIndex = 21;

                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;

                // DV
                case 20:
                    cbOutputFormat.SelectedIndex = 4;

                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 23;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);

                    cbAudioChannels.SelectedIndex = 1;
                    cbAudioSampleRate.SelectedIndex = 1;
                    break;

                // Custom
                case 21:
                    cbOutputFormat.SelectedIndex = 4;

                    cbVideoCodec.SelectedIndex = 16;
                    cbAudioCodec.SelectedIndex = 13;

                    cbFFEXEVideoCodec_SelectedIndexChanged(null, null);
                    cbFFEXEAudioCodec_SelectedIndexChanged(null, null);
                    break;
            }
        }

        private void FFEXEDisableAudioMode()
        {
            rbAudioModeABR.Enabled = false;
            rbAudioModeABR.Checked = false;
            rbAudioModeCBR.Enabled = false;
            rbAudioModeCBR.Checked = false;
            rbAudioModeQuality.Enabled = false;
            rbAudioModeQuality.Checked = false;
            rbAudioModeLossless.Enabled = false;
            rbAudioModeLossless.Checked = false;

            tbAudioQuality.Enabled = false;
            cbAudioBitrate.Enabled = false;
        }

        private void FFEXEEnableAudioCBR()
        {
            rbAudioModeCBR.Enabled = true;
            rbAudioModeCBR.Checked = true;

            cbAudioBitrate.Enabled = true;
        }

        // ReSharper disable once UnusedMember.Local
        private void FFEXEEnableAudioABR()
        {
            rbAudioModeABR.Enabled = true;
            rbAudioModeABR.Checked = true;

            // edFFEXEAudioTargetBitrate.Enabled = true;
            // edFFEXEAudioBitrateMax.Enabled = true;
            // edFFEXEAudioBitrateMin.Enabled = true;
        }

        private void FFEXEEnableAudioQuality()
        {
            rbAudioModeQuality.Enabled = true;
            rbAudioModeQuality.Checked = true;

            tbAudioQuality.Enabled = true;
        }

        private void FFEXEEnableAudioLossless()
        {
            rbAudioModeLossless.Enabled = true;
            rbAudioModeLossless.Checked = true;

            // tbFFEXEAudioQuality.Enabled = true;
        }

        private void cbFFEXEAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFEXEDisableAudioMode();
            lbFFEXEAudioNotes.Text = "Notes: None.";

            switch (cbAudioCodec.SelectedIndex)
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

                        tbAudioQuality.Minimum = 0;
                        tbAudioQuality.Maximum = 12;
                        tbAudioQuality.Value = 5;
                        lbFFEXEAudioQuality.Text = tbAudioQuality.Value.ToString();
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

                        tbAudioQuality.Minimum = 0;
                        tbAudioQuality.Maximum = 9;
                        tbAudioQuality.Value = 0;
                        lbFFEXEAudioQuality.Text = tbAudioQuality.Value.ToString();
                    }

                    break;

                // MP3
                case 13:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbAudioQuality.Minimum = 0;
                        tbAudioQuality.Maximum = 9;
                        tbAudioQuality.Value = 4;
                        lbFFEXEAudioQuality.Text = tbAudioQuality.Value.ToString();
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

                        tbAudioQuality.Minimum = 0;
                        tbAudioQuality.Maximum = 10;
                        tbAudioQuality.Value = 5;
                        tbFFEXEAudioQuality_Scroll(null, null);
                    }

                    break;

                // Vorbis
                case 41:
                    {
                        FFEXEEnableAudioQuality();
                        FFEXEEnableAudioCBR();

                        tbAudioQuality.Minimum = -1;
                        tbAudioQuality.Maximum = 10;
                        tbAudioQuality.Value = 5;
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
            lbFFEXEAudioQuality.Text = tbAudioQuality.Value.ToString();
        }

        private void cbFFEXEVideoCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            edVBVBufferSize.Text = "0";
            edVideoGOPSize.Text = "0";
            edVideoBFramesCount.Text = "0";
            tbVideoQuality.Minimum = 1;
            tbVideoQuality.Maximum = 31;

            lbFFEXEVideoNotes.Text = "Notes: None.";

            FFEXEDisableVideoMode();

            switch (cbVideoCodec.SelectedIndex)
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
                        cbVideoConstraint.SelectedIndex = 1;
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
                        cbH264Mode.SelectedIndex = 0;
                        cbH264Level.SelectedIndex = 0;
                        cbH264Usage.SelectedIndex = 0;
                        cbH264Profile.SelectedIndex = 0;
                        cbH264QuickTimeCompatibility.Checked = true;
                        cbH264ZeroTolerance.Checked = false;
                        cbH264WebFastStart.Checked = false;

                        edVideoTargetBitrate.Enabled = true;
                        tbVideoQuality.Enabled = true;
                    }

                    break;

                // H264 QSV
                case 6:
                    {
                        cbH264Mode.SelectedIndex = 0;
                        cbH264Level.SelectedIndex = 0;
                        cbH264Usage.SelectedIndex = 0;
                        cbH264Profile.SelectedIndex = 0;
                        cbH264QuickTimeCompatibility.Checked = true;
                        cbH264ZeroTolerance.Checked = false;
                        cbH264WebFastStart.Checked = false;
                    }

                    break;

                // HEVC
                case 7:
                    {
                        cbH264Mode.SelectedIndex = 0;
                        cbH264Level.SelectedIndex = 0;
                        cbH264Usage.SelectedIndex = 0;
                        cbH264Profile.SelectedIndex = 0;
                        cbH264QuickTimeCompatibility.Checked = true;
                        cbH264ZeroTolerance.Checked = false;
                        cbH264WebFastStart.Checked = false;

                        edVideoTargetBitrate.Enabled = true;
                        tbVideoQuality.Enabled = true;
                    }

                    break;

                // HEVC QSV
                case 8:
                    {
                        cbH264Mode.SelectedIndex = 0;
                        cbH264Level.SelectedIndex = 0;
                        cbH264Usage.SelectedIndex = 0;
                        cbH264Profile.SelectedIndex = 0;
                        cbH264QuickTimeCompatibility.Checked = true;
                        cbH264ZeroTolerance.Checked = false;
                        cbH264WebFastStart.Checked = false;
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

                        tbVideoQuality.Value = 4;
                        tbFFEXEVideoQuality_Scroll(null, null);
                    }

                    break;

                // MPEG-1
                case 14:
                    {
                        FFEXEEnableVideoCBR();

                        edVideoBitrateMin.Text = "1000";
                        edVideoBitrateMax.Text = "2000";
                        edVideoTargetBitrate.Text = "1800";
                    }

                    break;

                // MPEG-2
                case 15:
                    {
                        FFEXEEnableVideoCBR();

                        edVideoBitrateMin.Text = "2000";
                        edVideoBitrateMax.Text = "5000";
                        edVideoTargetBitrate.Text = "4000";

                        edVideoGOPSize.Text = "45";
                        edVideoBFramesCount.Text = "2";
                    }

                    break;

                // MPEG-4
                case 16:
                    {
                        FFEXEEnableVideoCBR();

                        edVideoBitrateMin.Text = "2000";
                        edVideoBitrateMax.Text = "5000";
                        edVideoTargetBitrate.Text = "4000";
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

                        tbVideoQuality.Minimum = 0;
                        tbVideoQuality.Maximum = 10;
                        tbVideoQuality.Value = 7;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edVideoTargetBitrate.Text = "2000";
                    }

                    break;

                // VP8
                case 19:
                    {
                        FFEXEEnableVideoQuality();
                        FFEXEEnableVideoCBR();

                        tbVideoQuality.Minimum = 4;
                        tbVideoQuality.Maximum = 63;
                        tbVideoQuality.Value = 10;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edVideoTargetBitrate.Text = "2000";
                    }

                    break;

                // VP9   
                case 20:
                    {
                        FFEXEEnableVideoQuality();
                        FFEXEEnableVideoCBR();

                        tbVideoQuality.Minimum = 4;
                        tbVideoQuality.Maximum = 63;
                        tbVideoQuality.Value = 10;
                        tbFFEXEVideoQuality_Scroll(null, null);

                        edVideoTargetBitrate.Text = "2000";
                    }

                    break;
            }
        }

        private void tbFFEXEVideoQuality_Scroll(object sender, EventArgs e)
        {
            lbFFEXEVideoQuality.Text = tbVideoQuality.Value.ToString();
        }

        private void cbFFEXEH264Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FFEXEDisableVideoMode();

            switch (cbH264Mode.SelectedIndex)
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
