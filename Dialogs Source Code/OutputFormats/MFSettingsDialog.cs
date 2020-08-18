using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;
// ReSharper disable InconsistentNaming

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class MFSettingsDialog : Form
    {
        private FiltersAvailableInfo _filtersAvailableInfo;

        private readonly MFSettingsDialogMode _mode;

        public MFSettingsDialog(MFSettingsDialogMode mode)
        {
            InitializeComponent();

            _mode = mode;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbMFProfile.SelectedIndex = 1;
            cbMFLevel.SelectedIndex = 12;
            cbMFRateControl.SelectedIndex = 3;

            _filtersAvailableInfo = VideoCaptureCore.MP4_v11_GetFiltersAvailable();
            if (_filtersAvailableInfo.V11_NVENC_H264)
            {
                lbMFHWAvailableEncoders.Text += "NVENC ";
            }

            if (_filtersAvailableInfo.V11_AMD_H264)
            {
                lbMFHWAvailableEncoders.Text += "AMD ";
            }

            if (_filtersAvailableInfo.V11_QSV_H264)
            {
                lbMFHWAvailableEncoders.Text += "INTEL QSV";
            }

            cbMP4Mode.SelectedIndex = 0;

            cbAACOutput.SelectedIndex = 0;
            cbAACVersion.SelectedIndex = 0;
            cbAACObjectType.SelectedIndex = 1;
            cbAACBitrate.SelectedIndex = 16;

            switch (_mode)
            {
                case MFSettingsDialogMode.Default:
                case MFSettingsDialogMode.MP4v11:
                    {
                        Text = "MP4 v11 settings";

                        lbCustomMuxer.Visible = true;
                        cbCustomMuxer.Visible = true;

                        cbCustomMuxer.Items.AddRange(new object[] { "Default", "FFMPEG-based" });
                        cbCustomMuxer.SelectedIndex = 0;

                        break;
                    }
                case MFSettingsDialogMode.MKV:
                    Text = "MKV settings";
                    break;
                case MFSettingsDialogMode.MPEGTS:
                    Text = "MPEG-TS settings";
                    break;
                case MFSettingsDialogMode.MOV:
                    Text = "MOV settings";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LoadAudio(VFM4AOutput audio)
        {
            cbAACBitrate.Text = audio.Bitrate.ToString();

            cbAACVersion.SelectedIndex = (int)audio.Version;
            cbAACOutput.SelectedIndex = (int)audio.Output;
            cbAACObjectType.SelectedIndex = (int)audio.Object - 1;
        }

        private void SaveAudio(ref VFM4AOutput audio)
        {
            int.TryParse(cbAACBitrate.Text, out var tmp);
            audio.Bitrate = tmp;

            audio.Version = (VFAACVersion)cbAACVersion.SelectedIndex;
            audio.Output = (VFAACOutput)cbAACOutput.SelectedIndex;
            audio.Object = (VFAACObject)(cbAACObjectType.SelectedIndex + 1);
        }

        private void LoadVideo(VFMFVideoEncoderSettings video)
        {
            // Main settings
            switch (video.Codec)
            {
                case VFMFVideoEncoder.MS_H264:
                    cbMP4Mode.SelectedIndex = 0;
                    break;
                case VFMFVideoEncoder.QSV_H264:
                    cbMP4Mode.SelectedIndex = 2;
                    break;
                case VFMFVideoEncoder.NVENC_H264:
                    cbMP4Mode.SelectedIndex = 1;
                    break;
                case VFMFVideoEncoder.AMD_H264:
                    cbMP4Mode.SelectedIndex = 3;
                    break;
                case VFMFVideoEncoder.NVENC_H265:
                    cbMP4Mode.SelectedIndex = 4;
                    break;
                case VFMFVideoEncoder.AMD_H265:
                    cbMP4Mode.SelectedIndex = 5;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Video H264 settings
            switch (video.Profile)
            {
                case VFMFH264Profile.Simple:
                    cbMFProfile.SelectedIndex = 0;
                    break;
                case VFMFH264Profile.Main:
                    cbMFProfile.SelectedIndex = 1;
                    break;
                case VFMFH264Profile.High:
                    cbMFProfile.SelectedIndex = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (video.Level)
            {
                case VFMFH264Level.Level1:
                    cbMFLevel.SelectedIndex = 0;
                    break;
                case VFMFH264Level.Level1b:
                    cbMFLevel.SelectedIndex = 1;
                    break;
                case VFMFH264Level.Level12:
                    cbMFLevel.SelectedIndex = 2;
                    break;
                case VFMFH264Level.Level13:
                    cbMFLevel.SelectedIndex = 3;
                    break;
                case VFMFH264Level.Level2:
                    cbMFLevel.SelectedIndex = 4;
                    break;
                case VFMFH264Level.Level21:
                    cbMFLevel.SelectedIndex = 5;
                    break;
                case VFMFH264Level.Level22:
                    cbMFLevel.SelectedIndex = 6;
                    break;
                case VFMFH264Level.Level3:
                    cbMFLevel.SelectedIndex = 7;
                    break;
                case VFMFH264Level.Level31:
                    cbMFLevel.SelectedIndex = 8;
                    break;
                case VFMFH264Level.Level32:
                    cbMFLevel.SelectedIndex = 9;
                    break;
                case VFMFH264Level.Level4:
                    cbMFLevel.SelectedIndex = 10;
                    break;
                case VFMFH264Level.Level41:
                    cbMFLevel.SelectedIndex = 11;
                    break;
                case VFMFH264Level.Level42:
                    cbMFLevel.SelectedIndex = 12;
                    break;
                case VFMFH264Level.Level5:
                    cbMFLevel.SelectedIndex = 13;
                    break;
                case VFMFH264Level.Level51:
                    cbMFLevel.SelectedIndex = 14;
                    break;
                case VFMFH264Level.Level52:
                    cbMFLevel.SelectedIndex = 15;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cbMFRateControl.SelectedIndex = (int)video.RateControl;
            cbMFCABAC.Checked = video.CABAC;
            cbMFLowLatency.Checked = video.LowLatencyMode;
            edMFBFramesCount.Text = video.DefaultBPictureCount.ToString();
            edMFKeyFrameSpacing.Text = video.MaxKeyFrameSpacing.ToString();
            edMFBitrate.Text = video.AvgBitrate.ToString();
            edMFMaxBitrate.Text = video.MaxBitrate.ToString();
            edMFQuality.Text = video.Quality.ToString();
        }

        private void SaveVideo(ref VFMFVideoEncoderSettings video)
        {
            // Main settings
            switch (cbMP4Mode.SelectedIndex)
            {
                case 0:
                    //  v11 (CPU) H264
                    video.Codec = VFMFVideoEncoder.MS_H264;
                    break;
                case 1:
                    //  v11 nVidia NVENC H264
                    video.Codec = VFMFVideoEncoder.NVENC_H264;
                    break;
                case 2:
                    //  v11 Intel QuickSync H264
                    video.Codec = VFMFVideoEncoder.QSV_H264;
                    break;
                case 3:
                    //  v11 AMD Radeon H264
                    video.Codec = VFMFVideoEncoder.AMD_H264;
                    break;
                case 4:
                    //  v11 nVidia NVENC H265
                    video.Codec = VFMFVideoEncoder.NVENC_H265;
                    break;
                case 5:
                    //  v11 AMD Radeon H265
                    video.Codec = VFMFVideoEncoder.AMD_H265;
                    break;
            }

            // Video H264 settings
            switch (cbMFProfile.SelectedIndex)
            {
                case 0:
                    video.Profile = VFMFH264Profile.Base;
                    break;
                case 1:
                    video.Profile = VFMFH264Profile.Main;
                    break;
                case 2:
                    video.Profile = VFMFH264Profile.High;
                    break;
            }

            switch (cbMFLevel.SelectedIndex)
            {
                case 0:
                    video.Level = VFMFH264Level.Level1;
                    break;
                case 1:
                    video.Level = VFMFH264Level.Level11;
                    break;
                case 2:
                    video.Level = VFMFH264Level.Level12;
                    break;
                case 3:
                    video.Level = VFMFH264Level.Level13;
                    break;
                case 4:
                    video.Level = VFMFH264Level.Level2;
                    break;
                case 5:
                    video.Level = VFMFH264Level.Level21;
                    break;
                case 6:
                    video.Level = VFMFH264Level.Level22;
                    break;
                case 7:
                    video.Level = VFMFH264Level.Level3;
                    break;
                case 8:
                    video.Level = VFMFH264Level.Level31;
                    break;
                case 9:
                    video.Level = VFMFH264Level.Level32;
                    break;
                case 10:
                    video.Level = VFMFH264Level.Level4;
                    break;
                case 11:
                    video.Level = VFMFH264Level.Level41;
                    break;
                case 12:
                    video.Level = VFMFH264Level.Level42;
                    break;
                case 13:
                    video.Level = VFMFH264Level.Level5;
                    break;
                case 14:
                    video.Level = VFMFH264Level.Level51;
                    break;
                case 15:
                    video.Level = VFMFH264Level.Level52;
                    break;
            }

            video.RateControl = (VFMFCommonRateControlMode)cbMFRateControl.SelectedIndex;

            video.CABAC = cbMFCABAC.Checked;
            video.LowLatencyMode = cbMFLowLatency.Checked;

            int.TryParse(edMFBFramesCount.Text, out var tmp);
            video.DefaultBPictureCount = tmp;

            int.TryParse(edMFKeyFrameSpacing.Text, out tmp);
            video.MaxKeyFrameSpacing = tmp;

            int.TryParse(edMFBitrate.Text, out tmp);
            video.AvgBitrate = tmp;

            int.TryParse(edMFMaxBitrate.Text, out tmp);
            video.MaxBitrate = tmp;

            int.TryParse(edMFQuality.Text, out tmp);
            video.Quality = tmp;
        }

        public void LoadSettings(VFMPEGTSOutput mpegTSOutput)
        {
            LoadVideo(mpegTSOutput.Video);
            LoadAudio(mpegTSOutput.Audio);
        }

        public void SaveSettings(ref VFMPEGTSOutput mpegTSOutput)
        {
            SaveVideo(ref mpegTSOutput.Video);
            SaveAudio(ref mpegTSOutput.Audio);
        }

        public void LoadSettings(VFMP4v11Output mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);

            if (_mode == MFSettingsDialogMode.MP4v11)
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

        public void SaveSettings(ref VFMP4v11Output mp4Output)
        {
            SaveVideo(ref mp4Output.Video);
            SaveAudio(ref mp4Output.Audio);

            if (_mode == MFSettingsDialogMode.MP4v11)
            {
                mp4Output.UseFFMPEGMuxer = cbCustomMuxer.SelectedIndex == 1;
            }
        }


        public void LoadSettings(VFMKVv2Output mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);
        }

        public void SaveSettings(ref VFMKVv2Output mp4Output)
        {
            SaveVideo(ref mp4Output.Video);
            SaveAudio(ref mp4Output.Audio);
        }

        public void LoadSettings(VFMOVOutput mp4Output)
        {
            LoadVideo(mp4Output.Video);
            LoadAudio(mp4Output.Audio);
        }

        public void SaveSettings(ref VFMOVOutput mp4Output)
        {
            SaveVideo(ref mp4Output.Video);
            SaveAudio(ref mp4Output.Audio);
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

        private void MP4v11SettingsDialog_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }

    /// <summary>
    /// MF settings dialog mode.
    /// </summary>
    public enum MFSettingsDialogMode
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default,

        /// <summary>
        /// MP4 v11.
        /// </summary>
        MP4v11,

        /// <summary>
        /// MKV.
        /// </summary>
        MKV,

        /// <summary>
        /// MPEG-TS.
        /// </summary>
        MPEGTS,

        /// <summary>
        /// Apple MOV.
        /// </summary>
        MOV
    }
}
