﻿// <copyright file="HWEncodersOutputSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Core.VideoCapture;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.DirectShow;

namespace VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
{
    /// <summary>
    /// HW encoders output settings dialog.
    /// </summary>
    public partial class HWEncodersOutputSettingsDialog : Form
    {
        private HWEncodersAvailableInfo _filtersAvailableInfo;

        private readonly HWSettingsDialogMode _mode;

        /// <summary>
        /// Initializes a new instance of the <see cref="HWEncodersOutputSettingsDialog"/> class.
        /// </summary>
        /// <param name="mode">
        /// Mode.
        /// </param>
        public HWEncodersOutputSettingsDialog(HWSettingsDialogMode mode)
        {
            InitializeComponent();

            _mode = mode;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbProfile.SelectedIndex = 1;
            cbLevel.SelectedIndex = 12;
            cbVideoRateControl.SelectedIndex = 3;

            _filtersAvailableInfo = VideoCaptureCore.HWEncodersAvailable();
            if (_filtersAvailableInfo.NVENC_H264)
            {
                edHWAvailableEncoders.Text += "NVENC_H264  ";
            }

            if (_filtersAvailableInfo.NVENC_H265)
            {
                edHWAvailableEncoders.Text += "NVENC_H265  ";
            }

            if (_filtersAvailableInfo.AMD_H264)
            {
                edHWAvailableEncoders.Text += "AMD_H264  ";
            }

            if (_filtersAvailableInfo.AMD_H265)
            {
                edHWAvailableEncoders.Text += "AMD_H265  ";
            }

            if (_filtersAvailableInfo.QSV_H264)
            {
                edHWAvailableEncoders.Text += "INTEL_QSV_H264  ";
            }

            if (_filtersAvailableInfo.QSV_H265)
            {
                edHWAvailableEncoders.Text += "INTEL_QSV_H265  ";
            }

            if (_filtersAvailableInfo.MS_H264)
            {
                edHWAvailableEncoders.Text += "MS_H264  ";
            }

            if (_filtersAvailableInfo.MS_H265)
            {
                edHWAvailableEncoders.Text += "MS_H265  ";
            }

            cbMP4Mode.SelectedIndex = 0;

            cbAACOutput.SelectedIndex = 0;
            cbAACVersion.SelectedIndex = 0;
            cbAACObjectType.SelectedIndex = 1;
            cbAACBitrate.SelectedIndex = 16;

            switch (_mode)
            {
                case HWSettingsDialogMode.Default:
                case HWSettingsDialogMode.MP4:
                    {
                        Text = "MP4 settings";

                        lbCustomMuxer.Visible = true;
                        cbCustomMuxer.Visible = true;

                        cbCustomMuxer.Items.AddRange(new object[] { "Default", "FFMPEG-based" });
                        cbCustomMuxer.SelectedIndex = 0;

                        break;
                    }

                case HWSettingsDialogMode.MKV:
                    Text = "MKV settings";
                    break;
                case HWSettingsDialogMode.MPEGTS:
                    Text = "MPEG-TS settings";
                    break;
                case HWSettingsDialogMode.MOV:
                    Text = "MOV settings";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LoadAudio(M4AOutput audio)
        {
            cbAACBitrate.Text = audio.Bitrate.ToString();

            cbAACVersion.SelectedIndex = (int)audio.Version;
            cbAACOutput.SelectedIndex = (int)audio.Output;
            cbAACObjectType.SelectedIndex = (int)audio.Object - 1;
        }

        private M4AOutput SaveAudio(M4AOutput audio)
        {
            int.TryParse(cbAACBitrate.Text, out var tmp);
            audio.Bitrate = tmp;

            audio.Version = (AACVersion)cbAACVersion.SelectedIndex;
            audio.Output = (AACOutput)cbAACOutput.SelectedIndex;
            audio.Object = (AACObject)(cbAACObjectType.SelectedIndex + 1);

            return audio;
        }

        private void LoadVideo(MFVideoEncoderSettings video)
        {
            // 0 - Microsoft(H264 / AAC)
            // 1 - Nvidia NVENC(H264/ AAC)
            // 2 - Intel QuickSync(H264/ AAC)
            // 3 - AMD Radeon(H264/ AAC)
            // 4 - Microsoft(H265 / AAC)
            // 5 - Nvidia NVENC(H265/ AAC)
            // 6 - Intel QuickSync(H265/ AAC)
            // 7 - AMD Radeon(H265/ AAC)

            // Main settings
            switch (video.Codec)
            {
                case MFVideoEncoder.MS_H264:
                    cbMP4Mode.SelectedIndex = 0;
                    break;
                case MFVideoEncoder.QSV_H264:
                    cbMP4Mode.SelectedIndex = 2;
                    break;
                case MFVideoEncoder.NVENC_H264:
                    cbMP4Mode.SelectedIndex = 1;
                    break;
                case MFVideoEncoder.AMD_H264:
                    cbMP4Mode.SelectedIndex = 3;
                    break;
                case MFVideoEncoder.NVENC_H265:
                    cbMP4Mode.SelectedIndex = 5;
                    break;
                case MFVideoEncoder.AMD_H265:
                    cbMP4Mode.SelectedIndex = 7;
                    break;
                case MFVideoEncoder.MS_H265:
                    cbMP4Mode.SelectedIndex = 4;
                    break;
                case MFVideoEncoder.QSV_H265:
                    cbMP4Mode.SelectedIndex = 6;
                    break;
                case MFVideoEncoder.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Video H264 settings
            switch (video.Profile)
            {
                case MFH264Profile.Simple:
                    cbProfile.SelectedIndex = 0;
                    break;
                case MFH264Profile.Main:
                    cbProfile.SelectedIndex = 1;
                    break;
                case MFH264Profile.High:
                    cbProfile.SelectedIndex = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (video.Level)
            {
                case MFH264Level.Level1:
                    cbLevel.SelectedIndex = 0;
                    break;
                case MFH264Level.Level1b:
                    cbLevel.SelectedIndex = 1;
                    break;
                case MFH264Level.Level12:
                    cbLevel.SelectedIndex = 2;
                    break;
                case MFH264Level.Level13:
                    cbLevel.SelectedIndex = 3;
                    break;
                case MFH264Level.Level2:
                    cbLevel.SelectedIndex = 4;
                    break;
                case MFH264Level.Level21:
                    cbLevel.SelectedIndex = 5;
                    break;
                case MFH264Level.Level22:
                    cbLevel.SelectedIndex = 6;
                    break;
                case MFH264Level.Level3:
                    cbLevel.SelectedIndex = 7;
                    break;
                case MFH264Level.Level31:
                    cbLevel.SelectedIndex = 8;
                    break;
                case MFH264Level.Level32:
                    cbLevel.SelectedIndex = 9;
                    break;
                case MFH264Level.Level4:
                    cbLevel.SelectedIndex = 10;
                    break;
                case MFH264Level.Level41:
                    cbLevel.SelectedIndex = 11;
                    break;
                case MFH264Level.Level42:
                    cbLevel.SelectedIndex = 12;
                    break;
                case MFH264Level.Level5:
                    cbLevel.SelectedIndex = 13;
                    break;
                case MFH264Level.Level51:
                    cbLevel.SelectedIndex = 14;
                    break;
                case MFH264Level.Level52:
                    cbLevel.SelectedIndex = 15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cbVideoRateControl.SelectedIndex = (int)video.RateControl;
            cbVideoCABAC.Checked = video.CABAC;
            cbVideoLowLatency.Checked = video.LowLatencyMode;
            edVideoBFramesCount.Text = video.DefaultBPictureCount.ToString();
            edVideoKeyFrameSpacing.Text = video.MaxKeyFrameSpacing.ToString();
            edVideoBitrate.Text = video.AvgBitrate.ToString();
            edVideoMaxBitrate.Text = video.MaxBitrate.ToString();
            edVideoQuality.Text = video.Quality.ToString();
        }

        private MFVideoEncoderSettings SaveVideo(MFVideoEncoderSettings video)
        {
            // Main settings
            // 0 - Microsoft(H264 / AAC)
            // 1 - Nvidia NVENC(H264/ AAC)
            // 2 - Intel QuickSync(H264/ AAC)
            // 3 - AMD Radeon(H264/ AAC)
            // 4 - Microsoft(H265 / AAC)
            // 5 - Nvidia NVENC(H265/ AAC)
            // 6 - Intel QuickSync(H265/ AAC)
            // 7 - AMD Radeon(H265/ AAC)

            switch (cbMP4Mode.SelectedIndex)
            {
                case 0:
                    //  MS H264
                    video.Codec = MFVideoEncoder.MS_H264;
                    break;
                case 1:
                    //  nVidia NVENC H264
                    video.Codec = MFVideoEncoder.NVENC_H264;
                    break;
                case 2:
                    //  Intel QuickSync H264
                    video.Codec = MFVideoEncoder.QSV_H264;
                    break;
                case 3:
                    //  AMD Radeon H264
                    video.Codec = MFVideoEncoder.AMD_H264;
                    break;
                case 4:
                    //  MS H265
                    video.Codec = MFVideoEncoder.MS_H265;
                    break;
                case 5:
                    //  NVENC H265
                    video.Codec = MFVideoEncoder.NVENC_H265;
                    break;
                case 6:
                    //  QSV H265
                    video.Codec = MFVideoEncoder.QSV_H265;
                    break;
                case 7:
                    //  AMD Radeon H265
                    video.Codec = MFVideoEncoder.AMD_H265;
                    break;
            }

            // Video H264 settings
            switch (cbProfile.SelectedIndex)
            {
                case 0:
                    video.Profile = MFH264Profile.Base;
                    break;
                case 1:
                    video.Profile = MFH264Profile.Main;
                    break;
                case 2:
                    video.Profile = MFH264Profile.High;
                    break;
            }

            switch (cbLevel.SelectedIndex)
            {
                case 0:
                    video.Level = MFH264Level.Level1;
                    break;
                case 1:
                    video.Level = MFH264Level.Level11;
                    break;
                case 2:
                    video.Level = MFH264Level.Level12;
                    break;
                case 3:
                    video.Level = MFH264Level.Level13;
                    break;
                case 4:
                    video.Level = MFH264Level.Level2;
                    break;
                case 5:
                    video.Level = MFH264Level.Level21;
                    break;
                case 6:
                    video.Level = MFH264Level.Level22;
                    break;
                case 7:
                    video.Level = MFH264Level.Level3;
                    break;
                case 8:
                    video.Level = MFH264Level.Level31;
                    break;
                case 9:
                    video.Level = MFH264Level.Level32;
                    break;
                case 10:
                    video.Level = MFH264Level.Level4;
                    break;
                case 11:
                    video.Level = MFH264Level.Level41;
                    break;
                case 12:
                    video.Level = MFH264Level.Level42;
                    break;
                case 13:
                    video.Level = MFH264Level.Level5;
                    break;
                case 14:
                    video.Level = MFH264Level.Level51;
                    break;
                case 15:
                    video.Level = MFH264Level.Level52;
                    break;
            }

            video.RateControl = (MFCommonRateControlMode)cbVideoRateControl.SelectedIndex;

            video.CABAC = cbVideoCABAC.Checked;
            video.LowLatencyMode = cbVideoLowLatency.Checked;

            int.TryParse(edVideoBFramesCount.Text, out var tmp);
            video.DefaultBPictureCount = tmp;

            int.TryParse(edVideoKeyFrameSpacing.Text, out tmp);
            video.MaxKeyFrameSpacing = tmp;

            int.TryParse(edVideoBitrate.Text, out tmp);
            video.AvgBitrate = tmp;

            int.TryParse(edVideoMaxBitrate.Text, out tmp);
            video.MaxBitrate = tmp;

            int.TryParse(edVideoQuality.Text, out tmp);
            video.Quality = tmp;

            return video;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mpegTSOutput">
        /// Output.
        /// </param>
        public void LoadSettings(MPEGTSOutput mpegTSOutput)
        {
            LoadVideo(mpegTSOutput.Video);
            LoadAudio(mpegTSOutput.Audio);
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mpegTSOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref MPEGTSOutput mpegTSOutput)
        {
            mpegTSOutput.Video = SaveVideo(mpegTSOutput.Video);
            mpegTSOutput.Audio = SaveAudio(mpegTSOutput.Audio);
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void LoadSettings(MP4HWOutput mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);

            if (_mode == HWSettingsDialogMode.MP4)
            {
                if (mp4Output.UseFFMPEGMuxer)
                {
                    cbCustomMuxer.SelectedIndex = 1;
                }
                else
                {
                    cbCustomMuxer.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SaveSettings(ref MP4HWOutput mp4Output)
        {
            mp4Output.Video = SaveVideo(mp4Output.Video);
            mp4Output.Audio = SaveAudio(mp4Output.Audio);

            if (_mode == HWSettingsDialogMode.MP4)
            {
                mp4Output.UseFFMPEGMuxer = cbCustomMuxer.SelectedIndex == 1;
            }
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void LoadSettings(MKVv2Output mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SaveSettings(ref MKVv2Output mp4Output)
        {
            mp4Output.Video = SaveVideo(mp4Output.Video);
            mp4Output.Audio = SaveAudio(mp4Output.Audio);
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void LoadSettings(MOVOutput mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SaveSettings(ref MOVOutput mp4Output)
        {
            mp4Output.Video = SaveVideo(mp4Output.Video);
            mp4Output.Audio = SaveAudio(mp4Output.Audio);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", @"http://support.visioforge.com/934037-MP4-H264--AAC-output-for-2K--4K-resolution-memory-problem");
            Process.Start(startInfo);
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
