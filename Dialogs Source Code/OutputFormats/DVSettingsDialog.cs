// <copyright file="DVSettingsDialog.cs" company="VisioForge">
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
    /// DV settings dialog.
    /// </summary>
    public partial class DVSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DVSettingsDialog"/> class.
        /// </summary>
        public DVSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbDVChannels.SelectedIndex = 1;
            cbDVSampleRate.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="dvOutput">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(DVOutput dvOutput)
        {
            cbDVChannels.Text = dvOutput.Audio_Channels.ToString();
            cbDVSampleRate.Text = dvOutput.Audio_SampleRate.ToString();

            switch (dvOutput.Video_Format)
            {
                case DVVideoFormat.PAL:
                    rbDVPAL.Checked = true;
                    break;
                case DVVideoFormat.NTSC:
                    rbDVPAL.Checked = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            rbDVType2.Checked = dvOutput.Type2;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="dvOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref DVOutput dvOutput)
        {
            dvOutput.Audio_Channels = Convert.ToInt32(cbDVChannels.Text);
            dvOutput.Audio_SampleRate = Convert.ToInt32(cbDVSampleRate.Text);

            if (rbDVPAL.Checked)
            {
                dvOutput.Video_Format = DVVideoFormat.PAL;
            }
            else
            {
                dvOutput.Video_Format = DVVideoFormat.NTSC;
            }

            dvOutput.Type2 = rbDVType2.Checked;
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
