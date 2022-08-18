// <copyright file="MP3SettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;

namespace VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
{
    /// <summary>
    /// MP3 settings dialog.
    /// </summary>
    public partial class MP3SettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MP3SettingsDialog"/> class.
        /// </summary>
        public MP3SettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbLameCBRBitrate.SelectedIndex = 8;
            cbLameVBRMin.SelectedIndex = 8;
            cbLameVBRMax.SelectedIndex = 10;
            cbLameSampleRate.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="mp3Output">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(MP3Output mp3Output)
        {
            // main
            cbLameCBRBitrate.Text = mp3Output.CBR_Bitrate.ToString();
            cbLameVBRMin.Text = mp3Output.VBR_MinBitrate.ToString();
            cbLameVBRMax.Text = mp3Output.VBR_MaxBitrate.ToString();
            cbLameSampleRate.Text = mp3Output.SampleRate.ToString();
            tbLameVBRQuality.Value = mp3Output.VBR_Quality;
            tbLameEncodingQuality.Value = mp3Output.EncodingQuality;

            switch (mp3Output.ChannelsMode)
            {
                case MP3ChannelsMode.StandardStereo:
                    rbLameStandardStereo.Checked = true;
                    break;
                case MP3ChannelsMode.JointStereo:
                    rbLameJointStereo.Checked = true;
                    break;
                case MP3ChannelsMode.DualStereo:
                    rbLameDualChannels.Checked = true;
                    break;
                case MP3ChannelsMode.Mono:
                    rbLameMono.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            rbLameVBR.Checked = mp3Output.VBR_Mode;

            // other
            cbLameCopyright.Checked = mp3Output.Copyright;
            cbLameOriginal.Checked = mp3Output.Original;
            cbLameCRCProtected.Checked = mp3Output.CRCProtected;
            cbLameForceMono.Checked = mp3Output.ForceMono;
            cbLameStrictlyEnforceVBRMinBitrate.Checked = mp3Output.StrictlyEnforceVBRMinBitrate;
            cbLameVoiceEncodingMode.Checked = mp3Output.VoiceEncodingMode;
            cbLameKeepAllFrequences.Checked = mp3Output.KeepAllFrequencies;
            cbLameStrictISOCompilance.Checked = mp3Output.StrictISOCompliance;
            cbLameDisableShortBlocks.Checked = mp3Output.DisableShortBlocks;
            cbLameEnableXingVBRTag.Checked = mp3Output.EnableXingVBRTag;
            cbLameModeFixed.Checked = mp3Output.ModeFixed;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="mp3Output">
        /// Output.
        /// </param>
        public void SaveSettings(ref MP3Output mp3Output)
        {
            // main
            mp3Output.CBR_Bitrate = Convert.ToInt32(cbLameCBRBitrate.Text);
            mp3Output.VBR_MinBitrate = Convert.ToInt32(cbLameVBRMin.Text);
            mp3Output.VBR_MaxBitrate = Convert.ToInt32(cbLameVBRMax.Text);
            mp3Output.SampleRate = Convert.ToInt32(cbLameSampleRate.Text);
            mp3Output.VBR_Quality = tbLameVBRQuality.Value;
            mp3Output.EncodingQuality = tbLameEncodingQuality.Value;

            if (rbLameStandardStereo.Checked)
            {
                mp3Output.ChannelsMode = MP3ChannelsMode.StandardStereo;
            }
            else if (rbLameJointStereo.Checked)
            {
                mp3Output.ChannelsMode = MP3ChannelsMode.JointStereo;
            }
            else if (rbLameDualChannels.Checked)
            {
                mp3Output.ChannelsMode = MP3ChannelsMode.DualStereo;
            }
            else
            {
                mp3Output.ChannelsMode = MP3ChannelsMode.Mono;
            }

            mp3Output.VBR_Mode = rbLameVBR.Checked;

            // other
            mp3Output.Copyright = cbLameCopyright.Checked;
            mp3Output.Original = cbLameOriginal.Checked;
            mp3Output.CRCProtected = cbLameCRCProtected.Checked;
            mp3Output.ForceMono = cbLameForceMono.Checked;
            mp3Output.StrictlyEnforceVBRMinBitrate = cbLameStrictlyEnforceVBRMinBitrate.Checked;
            mp3Output.VoiceEncodingMode = cbLameVoiceEncodingMode.Checked;
            mp3Output.KeepAllFrequencies = cbLameKeepAllFrequences.Checked;
            mp3Output.StrictISOCompliance = cbLameStrictISOCompilance.Checked;
            mp3Output.DisableShortBlocks = cbLameDisableShortBlocks.Checked;
            mp3Output.EnableXingVBRTag = cbLameEnableXingVBRTag.Checked;
            mp3Output.ModeFixed = cbLameModeFixed.Checked;
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
