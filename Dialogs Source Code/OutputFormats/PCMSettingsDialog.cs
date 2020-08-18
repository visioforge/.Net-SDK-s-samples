using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class PCMSettingsDialog : Form
    {
        private readonly string[] _audioCodecs;

        public PCMSettingsDialog(string[] audioCodecs)
        {
            InitializeComponent();

            _audioCodecs = audioCodecs;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbBPS2.SelectedIndex = 0;
            cbChannels2.SelectedIndex = 0;
            cbSampleRate2.SelectedIndex = 0;

            foreach (string codec in _audioCodecs)
            {
                cbAudioCodecs2.Items.Add(codec);
            }

            if (cbAudioCodecs2.Items.Count > 0)
            {
                cbAudioCodecs2.SelectedIndex = 0;
                cbAudioCodecs2_SelectedIndexChanged(null, null);
            }

            cbAudioCodecs2.Text = @"PCM";
        }

        public void LoadSettings(VFACMOutput acmOutput)
        {
            cbChannels2.Text = acmOutput.Channels.ToString();
            cbBPS2.Text = acmOutput.BPS.ToString();
            cbSampleRate2.Text = acmOutput.SampleRate.ToString();

            acmOutput.Name = cbAudioCodecs2.Text;
        }

        public void SaveSettings(ref VFACMOutput acmOutput)
        {
            acmOutput.Channels = Convert.ToInt32(cbChannels2.Text);
            acmOutput.BPS = Convert.ToInt32(cbBPS2.Text);
            acmOutput.SampleRate = Convert.ToInt32(cbSampleRate2.Text);

            acmOutput.Name = cbAudioCodecs2.Text;
        }

        private void cbAudioCodecs2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbAudioCodecs2.Text;
            btAudioSettings2.Enabled = VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.Default) ||
                                       VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig);
        }

        private void btAudioSettings2_Click(object sender, EventArgs e)
        {
            string name = cbAudioCodecs2.Text;

            if (VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.Default))
            {
                VideoCaptureCore.Audio_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.Default);
            }
            else if (VideoCaptureCore.Audio_Codec_Has_Dialog(name, VFPropertyPage.VFWCompConfig))
            {
                VideoCaptureCore.Audio_Codec_Show_Dialog(IntPtr.Zero, name, VFPropertyPage.VFWCompConfig);
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
