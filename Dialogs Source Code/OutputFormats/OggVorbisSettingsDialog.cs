// <copyright file="OggVorbisSettingsDialog.cs" company="VisioForge">
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
    /// Ogg Vorbis settings dialog.
    /// </summary>
    public partial class OggVorbisSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OggVorbisSettingsDialog"/> class.
        /// </summary>
        public OggVorbisSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbOGGAverage.SelectedIndex = 6;
            cbOGGMaximum.SelectedIndex = 8;
            cbOGGMinimum.SelectedIndex = 5;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="oggVorbisOutput">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(OGGVorbisOutput oggVorbisOutput)
        {
            edOGGQuality.Text = oggVorbisOutput.Quality.ToString();
            cbOGGMinimum.Text = oggVorbisOutput.MinBitRate.ToString();
            cbOGGMaximum.Text = oggVorbisOutput.MaxBitRate.ToString();
            cbOGGAverage.Text = oggVorbisOutput.AvgBitRate.ToString();

            switch (oggVorbisOutput.Mode)
            {
                case VorbisMode.Quality:
                    rbOGGQuality.Checked = true;
                    break;
                case VorbisMode.Bitrate:
                    rbOGGBitrate.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="oggVorbisOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref OGGVorbisOutput oggVorbisOutput)
        {
            oggVorbisOutput.Quality = Convert.ToInt32(edOGGQuality.Text);
            oggVorbisOutput.MinBitRate = Convert.ToInt32(cbOGGMinimum.Text);
            oggVorbisOutput.MaxBitRate = Convert.ToInt32(cbOGGMaximum.Text);
            oggVorbisOutput.AvgBitRate = Convert.ToInt32(cbOGGAverage.Text);

            if (rbOGGQuality.Checked)
            {
                oggVorbisOutput.Mode = VorbisMode.Quality;
            }
            else
            {
                oggVorbisOutput.Mode = VorbisMode.Bitrate;
            }
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
