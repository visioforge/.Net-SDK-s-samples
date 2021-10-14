// <copyright file="FFMPEGSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    /// <summary>
    /// FFMPEG settings dialog.
    /// </summary>
    public partial class FFMPEGSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FFMPEGSettingsDialog"/> class.
        /// </summary>
        public FFMPEGSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbAspectRatio.SelectedIndex = 0;
            cbAudioBitrate.SelectedIndex = 8;
            cbAudioChannels.SelectedIndex = 0;
            cbAudioSampleRate.SelectedIndex = 1;
            cbConstaint.SelectedIndex = 0;
            cbOutputFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(VFFFMPEGOutput ffmpegOutput)
        {
            cbOutputFormat.SelectedIndex = (int)ffmpegOutput.OutputFormat;
            cbVideoCodec.SelectedIndex = (int)ffmpegOutput.Video_Codec;
            cbAudioCodec.SelectedIndex = (int)ffmpegOutput.Audio_Codec;
            
            if (ffmpegOutput.Video_AspectRatio_W == 0 && ffmpegOutput.Video_AspectRatio_H == 1)
            {
                cbAspectRatio.SelectedIndex = 0;
            }
            else if (ffmpegOutput.Video_AspectRatio_W == 1 && ffmpegOutput.Video_AspectRatio_H == 1)
            {
                cbAspectRatio.SelectedIndex = 1;
            }
            else if (ffmpegOutput.Video_AspectRatio_W == 4 && ffmpegOutput.Video_AspectRatio_H == 3)
            {
                cbAspectRatio.SelectedIndex = 2;
            }
            else
            {
                cbAspectRatio.SelectedIndex = 3;
            }

            switch (ffmpegOutput.Video_TVSystem)
            {
                case FFMPEGTVSystem.None:
                    cbConstaint.SelectedIndex = 0;
                    break;
                case FFMPEGTVSystem.PAL:
                    cbConstaint.SelectedIndex = 1;
                    break;
                case FFMPEGTVSystem.NTSC:
                    cbConstaint.SelectedIndex = 2;
                    break;
                case FFMPEGTVSystem.Film:
                    cbConstaint.SelectedIndex = 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            edVideoWidth.Text = ffmpegOutput.Video_Width.ToString();
            edVideoHeight.Text = ffmpegOutput.Video_Height.ToString();
            edTargetBitrate.Text = ((int)(ffmpegOutput.Video_Bitrate / 1000.0)).ToString();
            edVideoBitrateMax.Text = ((int)(ffmpegOutput.Video_MaxBitrate / 1000.0)).ToString();
            edVideoBitrateMin.Text = ((int)(ffmpegOutput.Video_MinBitrate / 1000.0)).ToString();
            edVBVBufferSize.Text = ffmpegOutput.Video_BufferSize.ToString();
            cbAudioChannels.Text = ffmpegOutput.Audio_Channels.ToString();
            cbAudioSampleRate.Text = ffmpegOutput.Audio_SampleRate.ToString();
            cbAudioBitrate.Text = ((int)(ffmpegOutput.Audio_Bitrate / 1000.0)).ToString();
            cbVideoInterlace.Checked = ffmpegOutput.Video_Interlace;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref VFFFMPEGOutput ffmpegOutput)
        {
            ffmpegOutput.OutputFormat = (FFMPEGOutputFormat)cbOutputFormat.SelectedIndex;
            ffmpegOutput.Video_Codec = (FFMPEGVideoCodec)cbVideoCodec.SelectedIndex;
            ffmpegOutput.Audio_Codec = (FFMPEGAudioCodec)cbAudioCodec.SelectedIndex;

            switch (cbAspectRatio.SelectedIndex)
            {
                case 0:
                    ffmpegOutput.Video_AspectRatio_W = 0;
                    ffmpegOutput.Video_AspectRatio_H = 1;
                    break;
                case 1:
                    ffmpegOutput.Video_AspectRatio_W = 1;
                    ffmpegOutput.Video_AspectRatio_H = 1;
                    break;
                case 2:
                    ffmpegOutput.Video_AspectRatio_W = 4;
                    ffmpegOutput.Video_AspectRatio_H = 3;
                    break;
                case 3:
                    ffmpegOutput.Video_AspectRatio_W = 16;
                    ffmpegOutput.Video_AspectRatio_H = 9;
                    break;
            }

            switch (cbConstaint.SelectedIndex)
            {
                case 0:
                    ffmpegOutput.Video_TVSystem = FFMPEGTVSystem.None;
                    break;
                case 1:
                    ffmpegOutput.Video_TVSystem = FFMPEGTVSystem.PAL;
                    break;
                case 2:
                    ffmpegOutput.Video_TVSystem = FFMPEGTVSystem.NTSC;
                    break;
                case 3:
                    ffmpegOutput.Video_TVSystem = FFMPEGTVSystem.Film;
                    break;
            }

            ffmpegOutput.Video_Width = Convert.ToInt32(edVideoWidth.Text);
            ffmpegOutput.Video_Height = Convert.ToInt32(edVideoHeight.Text);
            ffmpegOutput.Video_Bitrate = Convert.ToInt32(edTargetBitrate.Text) * 1000;
            ffmpegOutput.Video_MaxBitrate = Convert.ToInt32(edVideoBitrateMax.Text) * 1000;
            ffmpegOutput.Video_MinBitrate = Convert.ToInt32(edVideoBitrateMin.Text) * 1000;
            ffmpegOutput.Video_BufferSize = Convert.ToInt32(edVBVBufferSize.Text);
            ffmpegOutput.Audio_Channels = Convert.ToInt32(cbAudioChannels.Text);
            ffmpegOutput.Audio_SampleRate = Convert.ToInt32(cbAudioSampleRate.Text);
            ffmpegOutput.Audio_Bitrate = Convert.ToInt32(cbAudioBitrate.Text) * 1000;
            ffmpegOutput.Video_Interlace = cbVideoInterlace.Checked;
            ffmpegOutput.Video_Profile = (FFMPEGVideoProfile)cbVideoProfile.SelectedIndex;
            ffmpegOutput.Video_Level = (FFMPEGVideoLevel)cbVideoLevel.SelectedIndex;
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

        private void FFMPEGSettingsDialog_Load(object sender, EventArgs e)
        {
            cbVideoLevel.Items.AddRange(Enum.GetNames(typeof(FFMPEGVideoLevel)));
            cbVideoLevel.SelectedIndex = 0;
            cbVideoProfile.Items.AddRange(Enum.GetNames(typeof(FFMPEGVideoProfile)));
            cbVideoProfile.SelectedIndex = 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1871:Two branches in a conditional structure should not have exactly the same implementation", Justification = "<Pending>")]
        private void cbOutputFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                // Auto
                case 0:
                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 0;
                    break;

                // MP4
                case 1:
                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 3;
                    break;

                // MKV
                case 2:
                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 3;
                    break;

                // FLV
                case 3:
                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 3;
                    break;

                // OGG
                case 4:
                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 5;
                    break;

                // MPEG-TS
                case 5:
                    cbVideoCodec.SelectedIndex = 11;
                    cbAudioCodec.SelectedIndex = 1;
                    break;

                // VOB
                case 6:
                    cbVideoCodec.SelectedIndex = 11;
                    cbAudioCodec.SelectedIndex = 1;
                    break;

                // AVI
                case 7:
                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 2;
                    break;

                // WEBM
                case 8:
                    cbVideoCodec.SelectedIndex = 12;
                    cbAudioCodec.SelectedIndex = 5;
                    break;

                // M4A
                case 9:
                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 3;
                    break;

                // GIF
                case 10:
                    cbVideoCodec.SelectedIndex = 0;
                    cbAudioCodec.SelectedIndex = 0;
                    break;

                // MOV
                case 11:
                    cbVideoCodec.SelectedIndex = 1;
                    cbAudioCodec.SelectedIndex = 3;
                    break;
            }
        }
    }
}
