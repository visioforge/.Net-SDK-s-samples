using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;
// ReSharper disable InconsistentNaming

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class HWEncodersOutputSettingsDialog : Form
    {
        private HWEncodersAvailableInfo _filtersAvailableInfo;

        private readonly HWSettingsDialogMode _mode;

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
                    cbMP4Mode.SelectedIndex = 5;
                    break;
                case VFMFVideoEncoder.AMD_H265:
                    cbMP4Mode.SelectedIndex = 7;
                    break;
                case VFMFVideoEncoder.MS_H265:
                    cbMP4Mode.SelectedIndex = 4;
                    break;
                case VFMFVideoEncoder.QSV_H265:
                    cbMP4Mode.SelectedIndex = 6;
                    break;
                case VFMFVideoEncoder.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Video H264 settings
            switch (video.Profile)
            {
                case VFMFH264Profile.Simple:
                    cbProfile.SelectedIndex = 0;
                    break;
                case VFMFH264Profile.Main:
                    cbProfile.SelectedIndex = 1;
                    break;
                case VFMFH264Profile.High:
                    cbProfile.SelectedIndex = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (video.Level)
            {
                case VFMFH264Level.Level1:
                    cbLevel.SelectedIndex = 0;
                    break;
                case VFMFH264Level.Level1b:
                    cbLevel.SelectedIndex = 1;
                    break;
                case VFMFH264Level.Level12:
                    cbLevel.SelectedIndex = 2;
                    break;
                case VFMFH264Level.Level13:
                    cbLevel.SelectedIndex = 3;
                    break;
                case VFMFH264Level.Level2:
                    cbLevel.SelectedIndex = 4;
                    break;
                case VFMFH264Level.Level21:
                    cbLevel.SelectedIndex = 5;
                    break;
                case VFMFH264Level.Level22:
                    cbLevel.SelectedIndex = 6;
                    break;
                case VFMFH264Level.Level3:
                    cbLevel.SelectedIndex = 7;
                    break;
                case VFMFH264Level.Level31:
                    cbLevel.SelectedIndex = 8;
                    break;
                case VFMFH264Level.Level32:
                    cbLevel.SelectedIndex = 9;
                    break;
                case VFMFH264Level.Level4:
                    cbLevel.SelectedIndex = 10;
                    break;
                case VFMFH264Level.Level41:
                    cbLevel.SelectedIndex = 11;
                    break;
                case VFMFH264Level.Level42:
                    cbLevel.SelectedIndex = 12;
                    break;
                case VFMFH264Level.Level5:
                    cbLevel.SelectedIndex = 13;
                    break;
                case VFMFH264Level.Level51:
                    cbLevel.SelectedIndex = 14;
                    break;
                case VFMFH264Level.Level52:
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

        private void SaveVideo(ref VFMFVideoEncoderSettings video)
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
                    video.Codec = VFMFVideoEncoder.MS_H264;
                    break;
                case 1:
                    //  nVidia NVENC H264
                    video.Codec = VFMFVideoEncoder.NVENC_H264;
                    break;
                case 2:
                    //  Intel QuickSync H264
                    video.Codec = VFMFVideoEncoder.QSV_H264;
                    break;
                case 3:
                    //  AMD Radeon H264
                    video.Codec = VFMFVideoEncoder.AMD_H264;
                    break;
                case 4:
                    //  MS H265
                    video.Codec = VFMFVideoEncoder.MS_H265;
                    break;
                case 5:
                    //  NVENC H265
                    video.Codec = VFMFVideoEncoder.NVENC_H265;
                    break;
                case 6:
                    //  QSV H265
                    video.Codec = VFMFVideoEncoder.QSV_H265;
                    break;
                case 7:
                    //  AMD Radeon H265
                    video.Codec = VFMFVideoEncoder.AMD_H265;
                    break;
            }

            // Video H264 settings
            switch (cbProfile.SelectedIndex)
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

            switch (cbLevel.SelectedIndex)
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

            video.RateControl = (VFMFCommonRateControlMode)cbVideoRateControl.SelectedIndex;

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

        public void LoadSettings(VFMP4HWOutput mp4Output)
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

        public void SaveSettings(ref VFMP4HWOutput mp4Output)
        {
            SaveVideo(ref mp4Output.Video);
            SaveAudio(ref mp4Output.Audio);

            if (_mode == HWSettingsDialogMode.MP4)
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

        private void mp4HWSettingsDialog_Load(object sender, EventArgs e)
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
    /// HW settings dialog mode.
    /// </summary>
    public enum HWSettingsDialogMode
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default,

        /// <summary>
        /// MP4.
        /// </summary>
        MP4,

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
