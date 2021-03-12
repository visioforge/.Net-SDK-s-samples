// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AVISettingsDialog.cs" company="VisioForge">
//   VisioForge (c) 2006 - 2021
// </copyright>
// <summary>
//   Defines the AVISettingsDialog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;

    using VisioForge.Controls.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;

    /// <summary>
    /// AVI settings dialog.
    /// </summary>
    public partial class AVISettingsDialog : Form
    {
        private readonly string[] _videoCodecs;

        private readonly string[] _audioCodecs;

        public AVISettingsDialog(string[] videoCodecs, string[] audioCodecs)
        {
            InitializeComponent();

            _videoCodecs = videoCodecs;
            _audioCodecs = audioCodecs;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbBPS.SelectedIndex = 1;
            cbChannels.SelectedIndex = 1;
            cbSampleRate.SelectedIndex = 0;

            foreach (string codec in _videoCodecs)
            {
                cbVideoCodecs.Items.Add(codec);
            }

            if (cbVideoCodecs.Items.Count > 0)
            {
                cbVideoCodecs.SelectedIndex = 0;
                cbVideoCodecs_SelectedIndexChanged(null, null);
            }

            foreach (string codec in _audioCodecs)
            {
                cbAudioCodecs.Items.Add(codec);
            }

            if (cbAudioCodecs.Items.Count > 0)
            {
                cbAudioCodecs.SelectedIndex = 0;
                cbAudioCodecs_SelectedIndexChanged(null, null);
            }

            if (cbVideoCodecs.Items.IndexOf("MJPEG Compressor") != -1)
            {
                cbVideoCodecs.SelectedIndex = cbVideoCodecs.Items.IndexOf("MJPEG Compressor");
            }

            if (cbAudioCodecs.Items.IndexOf("PCM") != -1)
            {
                cbAudioCodecs.SelectedIndex = cbAudioCodecs.Items.IndexOf("PCM");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAudioSettings_Click(object sender, EventArgs e)
        {
            string name = cbAudioCodecs.Text;

            if (VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.Default))
            {
                VideoCaptureCore.Audio_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
            }
            else if (VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
            {
                VideoCaptureCore.Audio_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
            }
        }

        public void LoadSettings(VFAVIOutput aviOutput)
        {
            cbAudioCodecs.Text = aviOutput.ACM.Name;
            cbChannels.Text = aviOutput.ACM.Channels.ToString();
            cbBPS.Text = aviOutput.ACM.BPS.ToString();
            cbSampleRate.Text = aviOutput.ACM.SampleRate.ToString();
            cbVideoCodecs.Text = aviOutput.Video_Codec;
            cbUncVideo.Checked = !aviOutput.Video_UseCompression;
            cbDecodeToRGB.Checked = !aviOutput.Video_UseCompression_DecodeUncompressedToRGB;
            cbUncAudio.Checked = !aviOutput.ACM.UseCompression;

            cbUseMP3InAVI.Checked = aviOutput.Audio_UseMP3Encoder;
        }

        public void SaveSettings(ref VFAVIOutput aviOutput)
        {
            aviOutput.ACM.Name = cbAudioCodecs.Text;
            aviOutput.ACM.Channels = Convert.ToInt32(cbChannels.Text);
            aviOutput.ACM.BPS = Convert.ToInt32(cbBPS.Text);
            aviOutput.ACM.SampleRate = Convert.ToInt32(cbSampleRate.Text);
            aviOutput.Video_Codec = cbVideoCodecs.Text;
            aviOutput.Video_UseCompression = !cbUncVideo.Checked;
            aviOutput.Video_UseCompression_DecodeUncompressedToRGB = cbDecodeToRGB.Checked;
            aviOutput.ACM.UseCompression = !cbUncAudio.Checked;

            if (cbUseMP3InAVI.Checked)
            {
                aviOutput.Audio_UseMP3Encoder = true;
            }
        }

        public void LoadSettings(VFMKVv1Output mkvOutput)
        {
            cbAudioCodecs.Text = mkvOutput.ACM.Name;
            cbChannels.Text = mkvOutput.ACM.Channels.ToString();
            cbBPS.Text = mkvOutput.ACM.BPS.ToString();
            cbSampleRate.Text = mkvOutput.ACM.SampleRate.ToString();
            cbVideoCodecs.Text = mkvOutput.Video_Codec;
            cbUncVideo.Checked = !mkvOutput.Video_UseCompression;
            cbDecodeToRGB.Checked = mkvOutput.Video_UseCompression_DecodeUncompressedToRGB;
            cbUncAudio.Checked = !mkvOutput.ACM.UseCompression;

            cbUseMP3InAVI.Checked = mkvOutput.Audio_UseMP3Encoder;
        }

        public void SaveSettings(ref VFMKVv1Output mkvOutput)
        {
            mkvOutput.ACM.Name = cbAudioCodecs.Text;
            mkvOutput.ACM.Channels = Convert.ToInt32(cbChannels.Text);
            mkvOutput.ACM.BPS = Convert.ToInt32(cbBPS.Text);
            mkvOutput.ACM.SampleRate = Convert.ToInt32(cbSampleRate.Text);
            mkvOutput.Video_Codec = cbVideoCodecs.Text;
            mkvOutput.Video_UseCompression = !cbUncVideo.Checked;
            mkvOutput.Video_UseCompression_DecodeUncompressedToRGB = cbDecodeToRGB.Checked;
            mkvOutput.ACM.UseCompression = !cbUncAudio.Checked;

            if (cbUseMP3InAVI.Checked)
            {
                mkvOutput.Audio_UseMP3Encoder = true;
            }
        }

        private void btVideoSettings_Click(object sender, EventArgs e)
        {
            string name = cbVideoCodecs.Text;

            if (VideoCaptureCore.Video_Codec_Has_Dialog(name, VFPropertyPage.Default))
            {
                VideoCaptureCore.Video_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
            }
            else
            {
                if (VideoCaptureCore.Video_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
                {
                    VideoCaptureCore.Video_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
                }
            }
        }

        /// <summary>
        /// Audio codec combobox.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbAudioCodecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbAudioCodecs.Text;
            btAudioSettings.Enabled = VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.Default) ||
                                      VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
        }

        /// <summary>
        /// Video codec combobox event.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void cbVideoCodecs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbVideoCodecs.Text;
            btVideoSettings.Enabled = VideoCaptureCore.Video_Codec_Has_Dialog(name, VFPropertyPage.Default) ||
                                      VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
        }

        private void cbUncVideo_CheckedChanged(object sender, EventArgs e)
        {
            cbVideoCodecs.Enabled = !cbUncVideo.Checked;
            btVideoSettings.Enabled = !cbUncVideo.Checked;
            cbDecodeToRGB.Enabled = cbUncVideo.Checked;

            if (cbVideoCodecs.Enabled)
            {
                cbVideoCodecs_SelectedIndexChanged(null, null);
            }
            else
            {
                btVideoSettings.Enabled = false;
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
