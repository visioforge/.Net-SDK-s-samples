// <copyright file="GIFSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    /// <summary>
    /// GIF settings dialog.
    /// </summary>
    public partial class GIFSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GIFSettingsDialog"/> class.
        /// </summary>
        public GIFSettingsDialog()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="gifOutput">
        /// Output.
        /// </param>
        public void LoadSettings(VFAnimatedGIFOutput gifOutput)
        {
            edGIFFrameRate.Text = gifOutput.FrameRate.ToString("F2");
            edGIFWidth.Text = gifOutput.ForcedVideoWidth.ToString();
            edGIFHeight.Text = gifOutput.ForcedVideoHeight.ToString();
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="gifOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref VFAnimatedGIFOutput gifOutput)
        {
            gifOutput.FrameRate = Convert.ToDouble(edGIFFrameRate.Text);
            gifOutput.ForcedVideoWidth = Convert.ToInt32(edGIFWidth.Text);
            gifOutput.ForcedVideoHeight = Convert.ToInt32(edGIFHeight.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }
}
