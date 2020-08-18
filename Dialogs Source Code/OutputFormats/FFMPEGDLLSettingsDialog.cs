using System;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class FFMPEGDLLSettingsDialog : Form
    {
        public FFMPEGDLLSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbFFAspectRatio.SelectedIndex = 0;
            cbFFAudioBitrate.SelectedIndex = 8;
            cbFFAudioChannels.SelectedIndex = 0;
            cbFFAudioSampleRate.SelectedIndex = 1;
            cbFFConstaint.SelectedIndex = 0;
            cbFFOutputFormat.SelectedIndex = 0;
        }

        public void LoadSettings(VFFFMPEGDLLOutput ffmpegDLLOutput)
        {
            switch (ffmpegDLLOutput.OutputFormat)
            {
                case VFFFMPEGDLLOutputFormat.FLV:
                    cbFFOutputFormat.SelectedIndex = 6;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG1:
                    cbFFOutputFormat.SelectedIndex = 0;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG1VCD:
                    cbFFOutputFormat.SelectedIndex = 1;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG2:
                    cbFFOutputFormat.SelectedIndex = 2;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG2TS:
                    cbFFOutputFormat.SelectedIndex = 5;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG2SVCD:
                    cbFFOutputFormat.SelectedIndex = 3;
                    break;
                case VFFFMPEGDLLOutputFormat.MPEG2DVD:
                    cbFFOutputFormat.SelectedIndex = 4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (ffmpegDLLOutput.Video_AspectRatio_W == 0 && ffmpegDLLOutput.Video_AspectRatio_H == 1)
            {
                cbFFAspectRatio.SelectedIndex = 0;
            }
            else if (ffmpegDLLOutput.Video_AspectRatio_W == 1 && ffmpegDLLOutput.Video_AspectRatio_H == 1)
            {
                cbFFAspectRatio.SelectedIndex = 1;
            }
            else if(ffmpegDLLOutput.Video_AspectRatio_W == 4 && ffmpegDLLOutput.Video_AspectRatio_H == 3)
            {
                cbFFAspectRatio.SelectedIndex = 2;
            }
            else
            {
                cbFFAspectRatio.SelectedIndex = 3;
            }

            switch (ffmpegDLLOutput.Video_TVSystem)
            {
                case VFFFMPEGDLLTVSystem.None:
                    cbFFConstaint.SelectedIndex = 0;
                    break;
                case VFFFMPEGDLLTVSystem.PAL:
                    cbFFConstaint.SelectedIndex = 1;
                    break;
                case VFFFMPEGDLLTVSystem.NTSC:
                    cbFFConstaint.SelectedIndex = 2;
                    break;
                case VFFFMPEGDLLTVSystem.Film:
                    cbFFConstaint.SelectedIndex = 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            edFFVideoWidth.Text = ffmpegDLLOutput.Video_Width.ToString();
            edFFVideoHeight.Text = ffmpegDLLOutput.Video_Height.ToString();
            edFFTargetBitrate.Text = ((int)(ffmpegDLLOutput.Video_Bitrate / 1000.0)).ToString();
            edFFVideoBitrateMax.Text = ((int)(ffmpegDLLOutput.Video_MaxBitrate / 1000.0)).ToString();
            edFFVideoBitrateMin.Text = ((int)(ffmpegDLLOutput.Video_MinBitrate / 1000.0)).ToString();
            edFFVBVBufferSize.Text = ffmpegDLLOutput.Video_BufferSize.ToString();
            cbFFAudioChannels.Text = ffmpegDLLOutput.Audio_Channels.ToString();
            cbFFAudioSampleRate.Text = ffmpegDLLOutput.Audio_SampleRate.ToString();
            cbFFAudioBitrate.Text = ((int)(ffmpegDLLOutput.Audio_Bitrate / 1000.0)).ToString();
            cbFFVideoInterlace.Checked = ffmpegDLLOutput.Video_Interlace;
        }

        public void SaveSettings(ref VFFFMPEGDLLOutput ffmpegDLLOutput)
        {
            switch (cbFFOutputFormat.SelectedIndex)
            {
                case 0:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG1;
                    break;
                case 1:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG1VCD;
                    break;
                case 2:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG2;
                    break;
                case 3:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG2SVCD;
                    break;
                case 4:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG2DVD;
                    break;
                case 5:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.MPEG2TS;
                    break;
                case 6:
                    ffmpegDLLOutput.OutputFormat = VFFFMPEGDLLOutputFormat.FLV;
                    break;
            }

            switch (cbFFAspectRatio.SelectedIndex)
            {
                case 0:
                    ffmpegDLLOutput.Video_AspectRatio_W = 0;
                    ffmpegDLLOutput.Video_AspectRatio_H = 1;
                    break;
                case 1:
                    ffmpegDLLOutput.Video_AspectRatio_W = 1;
                    ffmpegDLLOutput.Video_AspectRatio_H = 1;
                    break;
                case 2:
                    ffmpegDLLOutput.Video_AspectRatio_W = 4;
                    ffmpegDLLOutput.Video_AspectRatio_H = 3;
                    break;
                case 3:
                    ffmpegDLLOutput.Video_AspectRatio_W = 16;
                    ffmpegDLLOutput.Video_AspectRatio_H = 9;
                    break;
            }

            switch (cbFFConstaint.SelectedIndex)
            {
                case 0:
                    ffmpegDLLOutput.Video_TVSystem = VFFFMPEGDLLTVSystem.None;
                    break;
                case 1:
                    ffmpegDLLOutput.Video_TVSystem = VFFFMPEGDLLTVSystem.PAL;
                    break;
                case 2:
                    ffmpegDLLOutput.Video_TVSystem = VFFFMPEGDLLTVSystem.NTSC;
                    break;
                case 3:
                    ffmpegDLLOutput.Video_TVSystem = VFFFMPEGDLLTVSystem.Film;
                    break;
            }

            ffmpegDLLOutput.Video_Width = Convert.ToInt32(edFFVideoWidth.Text);
            ffmpegDLLOutput.Video_Height = Convert.ToInt32(edFFVideoHeight.Text);
            ffmpegDLLOutput.Video_Bitrate = Convert.ToInt32(edFFTargetBitrate.Text) * 1000;
            ffmpegDLLOutput.Video_MaxBitrate = Convert.ToInt32(edFFVideoBitrateMax.Text) * 1000;
            ffmpegDLLOutput.Video_MinBitrate = Convert.ToInt32(edFFVideoBitrateMin.Text) * 1000;
            ffmpegDLLOutput.Video_BufferSize = Convert.ToInt32(edFFVBVBufferSize.Text);
            ffmpegDLLOutput.Audio_Channels = Convert.ToInt32(cbFFAudioChannels.Text);
            ffmpegDLLOutput.Audio_SampleRate = Convert.ToInt32(cbFFAudioSampleRate.Text);
            ffmpegDLLOutput.Audio_Bitrate = Convert.ToInt32(cbFFAudioBitrate.Text) * 1000;
            ffmpegDLLOutput.Video_Interlace = cbFFVideoInterlace.Checked;
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
