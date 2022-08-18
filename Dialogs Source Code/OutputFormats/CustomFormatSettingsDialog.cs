// <copyright file="CustomFormatSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Core.Helpers;
using VisioForge.Core.VideoCapture;
using VisioForge.Core.VideoEdit;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;

namespace VisioForge.Core.UI.WinForms.Dialogs.OutputFormats
{
    /// <summary>
    /// Custom format settings dialog.
    /// </summary>
    public partial class CustomFormatSettingsDialog : Form
    {
        private readonly string[] _videoCodecs;

        private readonly string[] _audioCodecs;

        private readonly string[] _dsFilters;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormatSettingsDialog"/> class.
        /// </summary>
        /// <param name="videoCodecs">
        /// Video codecs.
        /// </param>
        /// <param name="audioCodecs">
        /// Audio codecs.
        /// </param>
        /// <param name="dsFilters">
        /// Filters.
        /// </param>
        public CustomFormatSettingsDialog(string[] videoCodecs, string[] audioCodecs, string[] dsFilters)
        {
            InitializeComponent();

            _videoCodecs = videoCodecs;
            _audioCodecs = audioCodecs;
            _dsFilters = dsFilters;

            LoadDefaults();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormatSettingsDialog"/> class.
        /// </summary>
        /// <param name="core">The core.</param>
        public CustomFormatSettingsDialog(VideoCaptureCore core)
        {
            InitializeComponent();

            _videoCodecs = core.Video_Codecs().ToArray();
            _audioCodecs = core.Audio_Codecs().ToArray();
            _dsFilters = core.DirectShow_Filters().ToArray();

            LoadDefaults();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormatSettingsDialog"/> class.
        /// </summary>
        /// <param name="core">The core.</param>
        public CustomFormatSettingsDialog(VideoEditCore core)
        {
            InitializeComponent();

            _videoCodecs = core.Video_Codecs().ToArray();
            _audioCodecs = core.Audio_Codecs().ToArray();
            _dsFilters = core.DirectShow_Filters().ToArray();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            foreach (string codec in _audioCodecs)
            {
                cbCustomAudioCodecs.Items.Add(codec);
            }

            if (cbCustomAudioCodecs.Items.Count > 0)
            {
                cbCustomAudioCodecs.SelectedIndex = 0;
                cbCustomAudioCodecs_SelectedIndexChanged(null, null);
            }

            foreach (string directShowFilter in _dsFilters)
            {
                cbCustomDSFilterA.Items.Add(directShowFilter);
                cbCustomDSFilterV.Items.Add(directShowFilter);
                cbCustomMuxer.Items.Add(directShowFilter);
                cbCustomFilewriter.Items.Add(directShowFilter);
            }

            if (cbCustomDSFilterA.Items.Count > 0)
            {
                cbCustomDSFilterA.SelectedIndex = 0;
                cbCustomDSFilterA_SelectedIndexChanged(null, null);
                cbCustomDSFilterV.SelectedIndex = 0;
                cbCustomDSFilterV_SelectedIndexChanged(null, null);
                cbCustomMuxer.SelectedIndex = 0;
                cbCustomMuxer_SelectedIndexChanged(null, null);
                cbCustomFilewriter.SelectedIndex = 0;
                cbCustomFilewriter_SelectedIndexChanged(null, null);
            }

            foreach (string codec in _videoCodecs)
            {
                cbCustomVideoCodecs.Items.Add(codec);
            }

            if (cbCustomVideoCodecs.Items.Count > 0)
            {
                cbCustomVideoCodecs.SelectedIndex = 0;
                cbCustomVideoCodecs_SelectedIndexChanged(null, null);
            }
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        public void LoadSettings(DirectCaptureMP4Output directCaptureOutput)
        {
            // Custom audio codec can be used if device to not have audio pin with compressed stream
            if (directCaptureOutput.Audio_Codec_UseFiltersCategory)
            {
                rbCustomUseAudioCodecsCat.Checked = false;
                cbCustomAudioCodecs.Text = directCaptureOutput.Audio_Codec;
            }
            else
            {
                rbCustomUseAudioCodecsCat.Checked = true;
                cbCustomDSFilterA.Text = directCaptureOutput.Audio_Codec;
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref DirectCaptureMP4Output directCaptureOutput)
        {
            // Custom audio codec can be used if device to not have audio pin with compressed stream
            if (rbCustomUseAudioCodecsCat.Checked)
            {
                directCaptureOutput.Audio_Codec = cbCustomAudioCodecs.Text;
                directCaptureOutput.Audio_Codec_UseFiltersCategory = false;
            }
            else
            {
                directCaptureOutput.Audio_Codec = cbCustomDSFilterA.Text;
                directCaptureOutput.Audio_Codec_UseFiltersCategory = true;
            }
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        public void LoadSettings(DirectCaptureCustomOutput directCaptureOutput)
        {
            if (directCaptureOutput.Video_Codec_UseFiltersCategory)
            {
                rbCustomUseVideoCodecsCat.Checked = false;
                cbCustomVideoCodecs.Text = directCaptureOutput.Video_Codec;
            }
            else
            {
                rbCustomUseVideoCodecsCat.Checked = true;
                cbCustomDSFilterV.Text = directCaptureOutput.Video_Codec;
            }

            if (directCaptureOutput.Audio_Codec_UseFiltersCategory)
            {
                rbCustomUseAudioCodecsCat.Checked = false;
                cbCustomAudioCodecs.Text = directCaptureOutput.Audio_Codec;
            }
            else
            {
                rbCustomUseAudioCodecsCat.Checked = true;
                cbCustomDSFilterA.Text = directCaptureOutput.Audio_Codec;
            }

            cbCustomMuxer.Text = directCaptureOutput.MuxFilter_Name;
            cbCustomMuxFilterIsEncoder.Checked = directCaptureOutput.MuxFilter_IsEncoder;
            cbUseSpecialFilewriter.Checked = directCaptureOutput.SpecialFileWriter_Needed;
            cbCustomFilewriter.Text = directCaptureOutput.SpecialFileWriter_FilterName;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref DirectCaptureCustomOutput directCaptureOutput)
        {
            if (rbCustomUseVideoCodecsCat.Checked)
            {
                directCaptureOutput.Video_Codec = cbCustomVideoCodecs.Text;
                directCaptureOutput.Video_Codec_UseFiltersCategory = false;
            }
            else
            {
                directCaptureOutput.Video_Codec = cbCustomDSFilterV.Text;
                directCaptureOutput.Video_Codec_UseFiltersCategory = true;
            }

            if (rbCustomUseAudioCodecsCat.Checked)
            {
                directCaptureOutput.Audio_Codec = cbCustomAudioCodecs.Text;
                directCaptureOutput.Audio_Codec_UseFiltersCategory = false;
            }
            else
            {
                directCaptureOutput.Audio_Codec = cbCustomDSFilterA.Text;
                directCaptureOutput.Audio_Codec_UseFiltersCategory = true;
            }

            directCaptureOutput.MuxFilter_Name = cbCustomMuxer.Text;
            directCaptureOutput.MuxFilter_IsEncoder = cbCustomMuxFilterIsEncoder.Checked;
            directCaptureOutput.SpecialFileWriter_Needed = cbUseSpecialFilewriter.Checked;
            directCaptureOutput.SpecialFileWriter_FilterName = cbCustomFilewriter.Text;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="customOutput">
        /// Output.
        /// </param>
        public void LoadSettings(CustomOutput customOutput)
        {
            if (customOutput.Video_Codec_UseFiltersCategory)
            {
                rbCustomUseVideoCodecsCat.Checked = false;
                cbCustomVideoCodecs.Text = customOutput.Video_Codec;
            }
            else
            {
                rbCustomUseVideoCodecsCat.Checked = true;
                cbCustomDSFilterV.Text = customOutput.Video_Codec;
            }

            if (customOutput.Audio_Codec_UseFiltersCategory)
            {
                rbCustomUseAudioCodecsCat.Checked = false;
                cbCustomAudioCodecs.Text = customOutput.Audio_Codec;
            }
            else
            {
                rbCustomUseAudioCodecsCat.Checked = true;
                cbCustomDSFilterA.Text = customOutput.Audio_Codec;
            }

            cbCustomMuxer.Text = customOutput.MuxFilter_Name;
            cbCustomMuxFilterIsEncoder.Checked = customOutput.MuxFilter_IsEncoder;
            cbUseSpecialFilewriter.Checked = customOutput.SpecialFileWriter_Needed;
            cbCustomFilewriter.Text = customOutput.SpecialFileWriter_FilterName;
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="customOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref CustomOutput customOutput)
        {
            if (rbCustomUseVideoCodecsCat.Checked)
            {
                customOutput.Video_Codec = cbCustomVideoCodecs.Text;
                customOutput.Video_Codec_UseFiltersCategory = false;
            }
            else
            {
                customOutput.Video_Codec = cbCustomDSFilterV.Text;
                customOutput.Video_Codec_UseFiltersCategory = true;
            }

            if (rbCustomUseAudioCodecsCat.Checked)
            {
                customOutput.Audio_Codec = cbCustomAudioCodecs.Text;
                customOutput.Audio_Codec_UseFiltersCategory = false;
            }
            else
            {
                customOutput.Audio_Codec = cbCustomDSFilterA.Text;
                customOutput.Audio_Codec_UseFiltersCategory = true;
            }

            customOutput.MuxFilter_Name = cbCustomMuxer.Text;
            customOutput.MuxFilter_IsEncoder = cbCustomMuxFilterIsEncoder.Checked;
            customOutput.SpecialFileWriter_Needed = cbUseSpecialFilewriter.Checked;
            customOutput.SpecialFileWriter_FilterName = cbCustomFilewriter.Text;
        }

        private void cbCustomVideoCodecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomVideoCodecs.Text;
            btCustomVideoCodecSettings.Enabled = FilterDialogHelper.Video_Codec_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.Video_Codec_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void cbCustomAudioCodecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomAudioCodecs.Text;
            btCustomAudioCodecSettings.Enabled = FilterDialogHelper.Audio_Codec_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.Audio_Codec_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void cbCustomDSFilterV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomDSFilterV.Text;
            btCustomDSFiltersVSettings.Enabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void cbCustomDSFilterA_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomDSFilterA.Text;
            btCustomDSFiltersASettings.Enabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void cbCustomMuxer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomMuxer.Text;
            btCustomMuxerSettings.Enabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void cbCustomFilewriter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbCustomFilewriter.Text;
            btCustomFilewriterSettings.Enabled = FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default) ||
                FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig);
        }

        private void btCustomAudioCodecSettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomAudioCodecs.Text;

            if (FilterDialogHelper.Audio_Codec_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.Audio_Codec_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.Audio_Codec_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.Audio_Codec_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void btCustomDSFiltersASettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomDSFilterA.Text;

            if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void btCustomDSFiltersVSettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomDSFilterV.Text;

            if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void btCustomFilewriterSettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomFilewriter.Text;

            if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void btCustomMuxerSettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomMuxer.Text;

            if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.DirectShow_Filter_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.DirectShow_Filter_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void btCustomVideoCodecSettings_Click(object sender, EventArgs e)
        {
            string name = cbCustomVideoCodecs.Text;

            if (FilterDialogHelper.Video_Codec_HasDialog(name, PropertyPageType.Default))
            {
                FilterDialogHelper.Video_Codec_ShowDialog(IntPtr.Zero, name, PropertyPageType.Default);
            }
            else if (FilterDialogHelper.Video_Codec_HasDialog(name, PropertyPageType.CompressorConfig))
            {
                FilterDialogHelper.Video_Codec_ShowDialog(IntPtr.Zero, name, PropertyPageType.CompressorConfig);
            }
        }

        private void cbUseSpecialFilewriter_CheckedChanged(object sender, EventArgs e)
        {
            cbCustomFilewriter.Enabled = cbUseSpecialFilewriter.Checked;
            btCustomFilewriterSettings.Enabled = cbUseSpecialFilewriter.Checked;
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
