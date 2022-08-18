// <copyright file="SpeexSettingsDialog.cs" company="VisioForge">
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
    /// Speex settings dialog.
    /// </summary>
    public partial class SpeexSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeexSettingsDialog"/> class.
        /// </summary>
        public SpeexSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbSpeexBitrateControl.SelectedIndex = 2;
            cbSpeexMode.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves setings.
        /// </summary>
        /// <param name="speexOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref SpeexOutput speexOutput)
        {
            speexOutput.BitRate = tbSpeexBitrate.Value;
            speexOutput.BitrateControl = (SpeexBitrateControl)cbSpeexBitrateControl.SelectedIndex;
            speexOutput.Mode = (SpeexEncodeMode)cbSpeexMode.SelectedIndex;
            speexOutput.MaxBitRate = tbSpeexMaxBitrate.Value;
            speexOutput.Complexity = tbSpeexComplexity.Value;
            speexOutput.Quality = tbSpeexQuality.Value;
            speexOutput.UseAGC = cbSpeexAGC.Checked;
            speexOutput.UseDTX = cbSpeexDTX.Checked;
            speexOutput.UseDenoise = cbSpeexDenoise.Checked;
            speexOutput.UseVAD = cbSpeexVAD.Checked;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="speexOutput">
        /// Output.
        /// </param>
        public void LoadSettings(SpeexOutput speexOutput)
        {
            tbSpeexBitrate.Value = speexOutput.BitRate;
            cbSpeexBitrateControl.SelectedIndex = (int)speexOutput.BitrateControl;
            cbSpeexMode.SelectedIndex = (int)speexOutput.Mode;
            tbSpeexMaxBitrate.Value = speexOutput.MaxBitRate;
            tbSpeexComplexity.Value = speexOutput.Complexity;
            tbSpeexQuality.Value = speexOutput.Quality;
            cbSpeexAGC.Checked = speexOutput.UseAGC;
            cbSpeexDTX.Checked = speexOutput.UseDTX;
            cbSpeexDenoise.Checked = speexOutput.UseDenoise;
            cbSpeexVAD.Checked = speexOutput.UseVAD;
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
