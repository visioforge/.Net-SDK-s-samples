// <copyright file="FLACSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Core.Types.Output;

namespace VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
{
    /// <summary>
    /// FLAC settings dialog.
    /// </summary>
    public partial class FLACSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FLACSettingsDialog"/> class.
        /// </summary>
        public FLACSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbFLACBlockSize.SelectedIndex = 4;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="flacOutput">
        /// Output.
        /// </param>
        public void LoadSettings(FLACOutput flacOutput)
        {
            tbFLACLevel.Value = flacOutput.Level;
            cbFLACBlockSize.Text = flacOutput.BlockSize.ToString();
            cbFLACAdaptiveMidSideCoding.Checked = flacOutput.AdaptiveMidSideCoding;
            cbFLACExhaustiveModelSearch.Checked = flacOutput.ExhaustiveModelSearch;
            tbFLACLPCOrder.Value = flacOutput.LPCOrder;
            cbFLACMidSideCoding.Checked = flacOutput.MidSideCoding;
            edFLACRiceMin.Text = flacOutput.RiceMin.ToString();
            edFLACRiceMax.Text = flacOutput.RiceMax.ToString();
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="flacOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref FLACOutput flacOutput)
        {
            flacOutput.Level = tbFLACLevel.Value;
            flacOutput.BlockSize = Convert.ToInt32(cbFLACBlockSize.Text);
            flacOutput.AdaptiveMidSideCoding = cbFLACAdaptiveMidSideCoding.Checked;
            flacOutput.ExhaustiveModelSearch = cbFLACExhaustiveModelSearch.Checked;
            flacOutput.LPCOrder = tbFLACLPCOrder.Value;
            flacOutput.MidSideCoding = cbFLACMidSideCoding.Checked;
            flacOutput.RiceMin = Convert.ToInt32(edFLACRiceMin.Text);
            flacOutput.RiceMax = Convert.ToInt32(edFLACRiceMax.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "https://github.com/visioforge/.Net-SDK-s-samples/tree/master/Dialogs%20Source%20Code/OutputFormats";
            var startInfo = new ProcessStartInfo("explorer.exe", url);
            Process.Start(startInfo);
        }
    }
}
