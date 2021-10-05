// <copyright file="MP4SettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    /// <summary>
    /// MP4 settings dialog.
    /// </summary>
    public partial class MP4SettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MP4SettingsDialog"/> class.
        /// </summary>
        public MP4SettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadDefaults()
        {
            cbH264Profile.SelectedIndex = 1;
            cbH264Level.SelectedIndex = 14;
            cbH264RateControl.SelectedIndex = 1;
            cbH264MBEncoding.SelectedIndex = 0;

            cbH264PictureType.SelectedIndex = 0;
            cbH264TargetUsage.SelectedIndex = 3;

            cbNVENCProfile.SelectedIndex = 2;
            cbNVENCLevel.SelectedIndex = 0;
            cbNVENCRateControl.SelectedIndex = 1;

            cbMP4Mode.SelectedIndex = 0;

            cbAACOutput.SelectedIndex = 0;
            cbAACVersion.SelectedIndex = 0;
            cbAACObjectType.SelectedIndex = 1;
            cbAACBitrate.SelectedIndex = 16;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SaveSettings(ref VFMP4Output mp4Output)
        {
            int tmp;

            switch (cbMP4Mode.SelectedIndex)
            {
                case 0:
                    // v10(CPU or Intel QuickSync GPU)
                    mp4Output.MP4Mode = VFMP4Mode.CPU_QSV;
                    break;
                case 1:
                    // v10 nVidia NVENC
                    mp4Output.MP4Mode = VFMP4Mode.NVENC;
                    break;
            }

            if (mp4Output.MP4Mode == VFMP4Mode.CPU_QSV)
            {
                // Legacy / Modern settings

                // Video H264 settings
                switch (cbH264Profile.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video.Profile = VFH264Profile.ProfileAuto;
                        break;
                    case 1:
                        mp4Output.Video.Profile = VFH264Profile.ProfileBaseline;
                        break;
                    case 2:
                        mp4Output.Video.Profile = VFH264Profile.ProfileMain;
                        break;
                    case 3:
                        mp4Output.Video.Profile = VFH264Profile.ProfileHigh;
                        break;
                    case 4:
                        mp4Output.Video.Profile = VFH264Profile.ProfileHigh10;
                        break;
                    case 5:
                        mp4Output.Video.Profile = VFH264Profile.ProfileHigh422;
                        break;
                }

                switch (cbH264Level.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video.Level = VFH264Level.LevelAuto;
                        break;
                    case 1:
                        mp4Output.Video.Level = VFH264Level.Level1;
                        break;
                    case 2:
                        mp4Output.Video.Level = VFH264Level.Level11;
                        break;
                    case 3:
                        mp4Output.Video.Level = VFH264Level.Level12;
                        break;
                    case 4:
                        mp4Output.Video.Level = VFH264Level.Level13;
                        break;
                    case 5:
                        mp4Output.Video.Level = VFH264Level.Level2;
                        break;
                    case 6:
                        mp4Output.Video.Level = VFH264Level.Level21;
                        break;
                    case 7:
                        mp4Output.Video.Level = VFH264Level.Level22;
                        break;
                    case 8:
                        mp4Output.Video.Level = VFH264Level.Level3;
                        break;
                    case 9:
                        mp4Output.Video.Level = VFH264Level.Level31;
                        break;
                    case 10:
                        mp4Output.Video.Level = VFH264Level.Level32;
                        break;
                    case 11:
                        mp4Output.Video.Level = VFH264Level.Level4;
                        break;
                    case 12:
                        mp4Output.Video.Level = VFH264Level.Level41;
                        break;
                    case 13:
                        mp4Output.Video.Level = VFH264Level.Level42;
                        break;
                    case 14:
                        mp4Output.Video.Level = VFH264Level.Level5;
                        break;
                    case 15:
                        mp4Output.Video.Level = VFH264Level.Level51;
                        break;
                }

                switch (cbH264TargetUsage.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video.TargetUsage = VFH264TargetUsage.Auto;
                        break;
                    case 1:
                        mp4Output.Video.TargetUsage = VFH264TargetUsage.BestQuality;
                        break;
                    case 2:
                        mp4Output.Video.TargetUsage = VFH264TargetUsage.Balanced;
                        break;
                    case 3:
                        mp4Output.Video.TargetUsage = VFH264TargetUsage.BestSpeed;
                        break;
                }

                switch (cbH264PictureType.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video.PictureType = VFH264PictureType.Auto;
                        break;
                    case 1:
                        mp4Output.Video.PictureType = VFH264PictureType.Frame;
                        break;
                    case 2:
                        mp4Output.Video.PictureType = VFH264PictureType.TFF;
                        break;
                    case 3:
                        mp4Output.Video.PictureType = VFH264PictureType.BFF;
                        break;
                }

                mp4Output.Video.RateControl = (VFH264RateControl)cbH264RateControl.SelectedIndex;
                mp4Output.Video.MBEncoding = (VFH264MBEncoding)cbH264MBEncoding.SelectedIndex;
                mp4Output.Video.GOP = cbH264GOP.Checked;
                mp4Output.Video.BitrateAuto = cbH264AutoBitrate.Checked;

                int.TryParse(edH264IDR.Text, out tmp);
                mp4Output.Video.IDR_Period = tmp;

                int.TryParse(edH264P.Text, out tmp);
                mp4Output.Video.P_Period = tmp;

                int.TryParse(edH264Bitrate.Text, out tmp);
                mp4Output.Video.Bitrate = tmp;
            }
            else if (mp4Output.MP4Mode == VFMP4Mode.NVENC)
            {
                // NVENC settings
                switch (cbNVENCProfile.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.Auto;
                        break;
                    case 1:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_Baseline;
                        break;
                    case 2:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_Main;
                        break;
                    case 3:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_High;
                        break;
                    case 4:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_High444;
                        break;
                    case 5:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_ProgressiveHigh;
                        break;
                    case 6:
                        mp4Output.Video_NVENC.Profile = VFNVENCVideoEncoderProfile.H264_ConstrainedHigh;
                        break;
                }

                switch (cbNVENCLevel.SelectedIndex)
                {
                    case 0:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.Auto;
                        break;
                    case 1:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_1;
                        break;
                    case 2:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_11;
                        break;
                    case 3:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_12;
                        break;
                    case 4:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_13;
                        break;
                    case 5:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_2;
                        break;
                    case 6:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_21;
                        break;
                    case 7:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_22;
                        break;
                    case 8:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_3;
                        break;
                    case 9:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_31;
                        break;
                    case 10:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_32;
                        break;
                    case 11:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_4;
                        break;
                    case 12:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_41;
                        break;
                    case 13:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_42;
                        break;
                    case 14:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_5;
                        break;
                    case 15:
                        mp4Output.Video_NVENC.Level = VFNVENCEncoderLevel.H264_51;
                        break;
                }

                mp4Output.Video_NVENC.Bitrate = Convert.ToInt32(edNVENCBitrate.Text);
                mp4Output.Video_NVENC.QP = Convert.ToInt32(edNVENCQP.Text);
                mp4Output.Video_NVENC.RateControl = (VFNVENCRateControlMode)cbNVENCRateControl.SelectedIndex;
                mp4Output.Video_NVENC.GOP = Convert.ToInt32(edNVENCGOP.Text);
                mp4Output.Video_NVENC.BFrames = Convert.ToInt32(edNVENCBFrames.Text);
            }

            // Audio AAC settings
            int.TryParse(cbAACBitrate.Text, out tmp);
            mp4Output.Audio_AAC.Bitrate = tmp;
            mp4Output.Audio_AAC.Version = (VFAACVersion)cbAACVersion.SelectedIndex;
            mp4Output.Audio_AAC.Output = (VFAACOutput)cbAACOutput.SelectedIndex;
            mp4Output.Audio_AAC.Object = (VFAACObject)(cbAACObjectType.SelectedIndex + 1);

            mp4Output.UseSpecialSyncMode = cbMP4UseSpecialSyncMode.Checked;

            if (cbMP4CustomAVSettings.Checked)
            {
                mp4Output.MP4V10Flags = 0;
                if (cbMP4TimeAdjust.Checked)
                {
                    mp4Output.MP4V10Flags |= MP4V10Flags.TimeAdjust;
                }

                if (cbMP4TimeOverride.Checked)
                {
                    mp4Output.MP4V10Flags |= MP4V10Flags.TimeOverride;
                }
            }

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
                mp4Output.Encryption_Key = ConvertHexStringToByteArray(edEncryptionKeyHEX.Text);
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

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(VFMP4Output mp4Output)
        {
            switch (mp4Output.MP4Mode)
            {
                case VFMP4Mode.CPU_QSV:
                    cbMP4Mode.SelectedIndex = 0;
                    break;
                case VFMP4Mode.NVENC:
                    cbMP4Mode.SelectedIndex = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (mp4Output.MP4Mode == VFMP4Mode.CPU_QSV)
            {
                // Legacy / Modern settings
                // Video H264 settings
                switch (mp4Output.Video.Profile)
                {
                    case VFH264Profile.ProfileAuto:
                        cbH264Profile.SelectedIndex = 0;
                        break;
                    case VFH264Profile.ProfileBaseline:
                        cbH264Profile.SelectedIndex = 1;
                        break;
                    case VFH264Profile.ProfileMain:
                        cbH264Profile.SelectedIndex = 2;
                        break;
                    case VFH264Profile.ProfileHigh:
                        cbH264Profile.SelectedIndex = 3;
                        break;
                    case VFH264Profile.ProfileHigh10:
                        cbH264Profile.SelectedIndex = 4;
                        break;
                    case VFH264Profile.ProfileHigh422:
                        cbH264Profile.SelectedIndex = 5;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (mp4Output.Video.Level)
                {
                    case VFH264Level.LevelAuto:
                        cbH264Level.SelectedIndex = 0;
                        break;
                    case VFH264Level.Level1:
                        cbH264Level.SelectedIndex = 1;
                        break;
                    case VFH264Level.Level11:
                        cbH264Level.SelectedIndex = 2;
                        break;
                    case VFH264Level.Level12:
                        cbH264Level.SelectedIndex = 3;
                        break;
                    case VFH264Level.Level13:
                        cbH264Level.SelectedIndex = 4;
                        break;
                    case VFH264Level.Level2:
                        cbH264Level.SelectedIndex = 5;
                        break;
                    case VFH264Level.Level21:
                        cbH264Level.SelectedIndex = 6;
                        break;
                    case VFH264Level.Level22:
                        cbH264Level.SelectedIndex = 7;
                        break;
                    case VFH264Level.Level3:
                        cbH264Level.SelectedIndex = 8;
                        break;
                    case VFH264Level.Level31:
                        cbH264Level.SelectedIndex = 9;
                        break;
                    case VFH264Level.Level32:
                        cbH264Level.SelectedIndex = 10;
                        break;
                    case VFH264Level.Level4:
                        cbH264Level.SelectedIndex = 11;
                        break;
                    case VFH264Level.Level41:
                        cbH264Level.SelectedIndex = 12;
                        break;
                    case VFH264Level.Level42:
                        cbH264Level.SelectedIndex = 13;
                        break;
                    case VFH264Level.Level5:
                        cbH264Level.SelectedIndex = 14;
                        break;
                    case VFH264Level.Level51:
                        cbH264Level.SelectedIndex = 15;
                        break;
                    case VFH264Level.Level51_NVENC:
                        cbH264Level.SelectedIndex = 15;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (mp4Output.Video.TargetUsage)
                {
                    case VFH264TargetUsage.Auto:
                        cbH264TargetUsage.SelectedIndex = 0;
                        break;
                    case VFH264TargetUsage.BestQuality:
                        cbH264TargetUsage.SelectedIndex = 1;
                        break;
                    case VFH264TargetUsage.Balanced:
                        cbH264TargetUsage.SelectedIndex = 2;
                        break;
                    case VFH264TargetUsage.BestSpeed:
                        cbH264TargetUsage.SelectedIndex = 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (mp4Output.Video.PictureType)
                {
                    case VFH264PictureType.Auto:
                        cbH264PictureType.SelectedIndex = 0;
                        break;
                    case VFH264PictureType.Frame:
                        cbH264PictureType.SelectedIndex = 1;
                        break;
                    case VFH264PictureType.TFF:
                        cbH264PictureType.SelectedIndex = 2;
                        break;
                    case VFH264PictureType.BFF:
                        cbH264PictureType.SelectedIndex = 3;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                cbH264RateControl.SelectedIndex = (int)mp4Output.Video.RateControl;
                cbH264MBEncoding.SelectedIndex = (int)mp4Output.Video.MBEncoding;
                cbH264GOP.Checked = mp4Output.Video.GOP;
                cbH264AutoBitrate.Checked = mp4Output.Video.BitrateAuto;
                edH264IDR.Text = mp4Output.Video.IDR_Period.ToString();
                edH264P.Text = mp4Output.Video.P_Period.ToString();
                edH264Bitrate.Text = mp4Output.Video.Bitrate.ToString();
            }
            else if (mp4Output.MP4Mode == VFMP4Mode.NVENC)
            {
                // NVENC settings
                switch (mp4Output.Video_NVENC.Profile)
                {
                    case VFNVENCVideoEncoderProfile.Auto:
                        cbNVENCProfile.SelectedIndex = 0;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_Baseline:
                        cbNVENCProfile.SelectedIndex = 1;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_Main:
                        cbNVENCProfile.SelectedIndex = 2;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_High:
                        cbNVENCProfile.SelectedIndex = 3;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_High444:
                        cbNVENCProfile.SelectedIndex = 4;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_ProgressiveHigh:
                        cbNVENCProfile.SelectedIndex = 5;
                        break;
                    case VFNVENCVideoEncoderProfile.H264_ConstrainedHigh:
                        cbNVENCProfile.SelectedIndex = 6;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                switch (mp4Output.Video_NVENC.Level)
                {
                    case VFNVENCEncoderLevel.Auto:
                        cbNVENCLevel.SelectedIndex = 0;
                        break;
                    case VFNVENCEncoderLevel.H264_1:
                        cbNVENCLevel.SelectedIndex = 1;
                        break;
                    case VFNVENCEncoderLevel.H264_11:
                        cbNVENCLevel.SelectedIndex = 2;
                        break;
                    case VFNVENCEncoderLevel.H264_12:
                        cbNVENCLevel.SelectedIndex = 3;
                        break;
                    case VFNVENCEncoderLevel.H264_13:
                        cbNVENCLevel.SelectedIndex = 4;
                        break;
                    case VFNVENCEncoderLevel.H264_2:
                        cbNVENCLevel.SelectedIndex = 5;
                        break;
                    case VFNVENCEncoderLevel.H264_21:
                        cbNVENCLevel.SelectedIndex = 6;
                        break;
                    case VFNVENCEncoderLevel.H264_22:
                        cbNVENCLevel.SelectedIndex = 7;
                        break;
                    case VFNVENCEncoderLevel.H264_3:
                        cbNVENCLevel.SelectedIndex = 8;
                        break;
                    case VFNVENCEncoderLevel.H264_31:
                        cbNVENCLevel.SelectedIndex = 9;
                        break;
                    case VFNVENCEncoderLevel.H264_32:
                        cbNVENCLevel.SelectedIndex = 10;
                        break;
                    case VFNVENCEncoderLevel.H264_4:
                        cbNVENCLevel.SelectedIndex = 11;
                        break;
                    case VFNVENCEncoderLevel.H264_41:
                        cbNVENCLevel.SelectedIndex = 12;
                        break;
                    case VFNVENCEncoderLevel.H264_42:
                        cbNVENCLevel.SelectedIndex = 13;
                        break;
                    case VFNVENCEncoderLevel.H264_5:
                        cbNVENCLevel.SelectedIndex = 14;
                        break;
                    case VFNVENCEncoderLevel.H264_51:
                        cbNVENCLevel.SelectedIndex = 15;
                        break;
                    case VFNVENCEncoderLevel.H264_52:
                        cbNVENCLevel.SelectedIndex = 16;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                edNVENCBitrate.Text = mp4Output.Video_NVENC.Bitrate.ToString();
                edNVENCQP.Text = mp4Output.Video_NVENC.QP.ToString();
                cbNVENCRateControl.SelectedIndex = (int)mp4Output.Video_NVENC.RateControl;
                edNVENCGOP.Text = mp4Output.Video_NVENC.GOP.ToString();
                edNVENCBFrames.Text = mp4Output.Video_NVENC.BFrames.ToString();
            }

            // Audio AAC settings
            cbAACBitrate.Text = mp4Output.Audio_AAC.Bitrate.ToString();
            cbAACVersion.SelectedIndex = (int)mp4Output.Audio_AAC.Version;
            cbAACOutput.SelectedIndex = (int)mp4Output.Audio_AAC.Output;
            cbAACObjectType.SelectedIndex = (int)mp4Output.Audio_AAC.Object - 1;
            cbMP4UseSpecialSyncMode.Checked = mp4Output.UseSpecialSyncMode;

            if ((mp4Output.MP4V10Flags & MP4V10Flags.TimeAdjust) != 0)
            {
                cbMP4TimeAdjust.Checked = true;
            }
            else
            {
                cbMP4TimeAdjust.Checked = false;
            }

            if ((mp4Output.MP4V10Flags & MP4V10Flags.TimeOverride) != 0)
            {
                cbMP4TimeOverride.Checked = true;
            }
            else
            {
                cbMP4TimeOverride.Checked = false;
            }

            switch (mp4Output.Encryption_KeyType)
            {
                case VFEncryptionKeyType.String:
                    rbEncryptionKeyString.Checked = true;
                    edEncryptionKeyString.Text = mp4Output.Encryption_Key.ToString();
                    break;
                case VFEncryptionKeyType.File:
                    rbEncryptionKeyFile.Checked = true;
                    edEncryptionKeyString.Text = mp4Output.Encryption_Key.ToString();
                    break;
                case VFEncryptionKeyType.Binary:
                    rbEncryptionKeyFile.Checked = true;
                    edEncryptionKeyHEX.Text = ConvertByteArrayToHexString((byte[])mp4Output.Encryption_Key);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (mp4Output.Encryption_Mode)
            {
                case VFEncryptionMode.V8_AES128:
                    rbEncryptionModeAES128.Checked = true;
                    break;
                case VFEncryptionMode.V9_AES256:
                    rbEncryptionModeAES128.Checked = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Converts HEX string to byte array.
        /// </summary>
        /// <param name="hexString">
        /// HEX string.
        /// </param>
        /// <returns>
        /// Byte array.
        /// </returns>
        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] hexAsBytes = new byte[hexString.Length / 2];
            for (int index = 0; index < hexAsBytes.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                hexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return hexAsBytes;
        }

        /// <summary>
        /// Converts byte array to hex string.
        /// </summary>
        /// <param name="ba">
        /// Byte array.
        /// </param>
        /// <returns>
        /// Returns <see cref="string"/>.
        /// </returns>
        public static string ConvertByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", @"http://support.visioforge.com/934037-MP4-H264--AAC-output-for-2K--4K-resolution-memory-problem");
            Process.Start(startInfo);
        }

        private void tpNVEnc_Enter(object sender, EventArgs e)
        {
            if (lbNVENCStatus.Tag.ToString() == "0")
            {
                lbNVENCStatus.Tag = 1;

                bool res = VideoCaptureCore.Filter_Supported_NVENC(out var errorCode);

                if (res)
                {
                    lbNVENCStatus.Text = "Available";
                    lbNVENCStatus.ForeColor = Color.Green;
                }
                else
                {
                    lbNVENCStatus.Text = $"Not available or error (code: {errorCode})";
                    lbNVENCStatus.ForeColor = Color.Red;
                }
            }
        }

        private void MP4v10SettingsDialog_Load(object sender, EventArgs e)
        {
        }

        private void btEncryptionOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edEncryptionKeyFile.Text = openFileDialog1.FileName;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }
}
