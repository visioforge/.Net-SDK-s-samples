using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Controls.VideoEdit;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;

namespace VisioForge.Controls.UI.Dialogs.OutputFormats
{
    public partial class WMVSettingsDialog : Form
    {
        private readonly VideoCaptureCore _coreVideoCapture;

        private readonly VideoEditCore _coreVideoEdit;

        public bool WMA;

        public WMVSettingsDialog(VideoCaptureCore core)
        {
            InitializeComponent();

            _coreVideoCapture = core;

            LoadDefaults();
        }

        public WMVSettingsDialog(VideoEditCore core)
        {
            InitializeComponent();

            _coreVideoEdit = core;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbWMVVideoMode.SelectedIndex = 0;
            cbWMVAudioMode.SelectedIndex = 0;

            if (cbWMVVideoCodec.Items.Count > 0)
            {
                cbWMVVideoCodec.SelectedIndex = 0;
            }

            if (cbWMVAudioCodec.Items.Count > 0)
            {
                cbWMVAudioCodec.SelectedIndex = 0;
            }

            cbWMVAudioCodec_SelectedIndexChanged(null, null);

            if (cbWMVAudioFormat.Items.Count > 0)
            {
                cbWMVAudioFormat.SelectedIndex = 0;
            }

            if (_coreVideoCapture != null)
            {
                foreach (string profile in _coreVideoCapture.WMV_Internal_Profiles())
                {
                    cbWMVInternalProfile9.Items.Add(profile);
                }
            }
            else
            {
                foreach (string profile in _coreVideoEdit.WMV_Internal_Profiles())
                {
                    cbWMVInternalProfile9.Items.Add(profile);
                }
            }

            if (cbWMVInternalProfile9.Items.Count > 7)
            {
                cbWMVInternalProfile9.SelectedIndex = 7;
            }

            List<string> names;
            if (_coreVideoCapture != null)
            {
                _coreVideoCapture.WMV_V8_Profiles(out names, out _);
            }
            else
            {
                _coreVideoEdit.WMV_V8_Profiles(out names, out _);
            }

            foreach (string name in names)
            {
                cbWMVInternalProfile8.Items.Add(name);
            }

            if (cbWMVInternalProfile8.Items.Count > 0)
            {
                cbWMVInternalProfile8.SelectedIndex = 0;
            }

            cbWMVTVFormat.SelectedIndex = 0;
        }

        private void cbWMVAudioCodec_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = VFWMVStreamMode.CBR;
            switch (cbWMVAudioMode.SelectedIndex)
            {
                case 0:
                    {
                        mode = VFWMVStreamMode.CBR;
                        break;
                    }

                case 1:
                    {
                        mode = VFWMVStreamMode.VBRBitrate;
                        break;
                    }

                case 2:
                    {
                        mode = VFWMVStreamMode.VBRPeakBitrate;
                        break;
                    }

                case 3:
                    {
                        mode = VFWMVStreamMode.VBRQuality;
                        break;
                    }
            }

            cbWMVAudioFormat.Items.Clear();
            if (cbWMVAudioCodec.SelectedIndex != -1)
            {
                if (_coreVideoCapture != null)
                {
                    foreach (string format in _coreVideoCapture.WMV_CustomProfile_AudioFormats(cbWMVAudioCodec.Text, mode))
                    {
                        cbWMVAudioFormat.Items.Add(format);
                    }
                }
                else
                {
                    foreach (string format in _coreVideoEdit.WMV_CustomProfile_AudioFormats(cbWMVAudioCodec.Text, mode))
                    {
                        cbWMVAudioFormat.Items.Add(format);
                    }
                }
            }

            if (cbWMVAudioFormat.Items.Count > 0)
            {
                cbWMVAudioFormat.SelectedIndex = 0;
            }
        }

        private void cbWMVAudioMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = VFWMVStreamMode.CBR;
            switch (cbWMVAudioMode.SelectedIndex)
            {
                case 0:
                    {
                        mode = VFWMVStreamMode.CBR;
                        break;
                    }

                case 1:
                    {
                        mode = VFWMVStreamMode.VBRBitrate;
                        break;
                    }

                case 2:
                    {
                        mode = VFWMVStreamMode.VBRPeakBitrate;
                        break;
                    }

                case 3:
                    {
                        mode = VFWMVStreamMode.VBRQuality;
                        break;
                    }
            }

            cbWMVAudioCodec.Items.Clear();
            if (_coreVideoCapture != null)
            {
                foreach (string codec in _coreVideoCapture.WMV_CustomProfile_AudioCodecs(mode))
                {
                    cbWMVAudioCodec.Items.Add(codec);
                }
            }
            else
            {
                foreach (string codec in _coreVideoEdit.WMV_CustomProfile_AudioCodecs(mode))
                {
                    cbWMVAudioCodec.Items.Add(codec);
                }
            }

            if (cbWMVAudioCodec.Items.Count > 0)
            {
                cbWMVAudioCodec.SelectedIndex = 0;
            }
        }

        private void cbWMVVideoMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var mode = VFWMVStreamMode.CBR;
            switch (cbWMVVideoMode.SelectedIndex)
            {
                case 0:
                    {
                        mode = VFWMVStreamMode.CBR;
                        edWMVVideoBitrate.Enabled = true;
                        edWMVVideoPeakBitrate.Enabled = false;
                        edWMVVideoQuality.Enabled = false;
                        break;
                    }

                case 1:
                    {
                        mode = VFWMVStreamMode.VBRBitrate;
                        edWMVVideoBitrate.Enabled = true;
                        edWMVVideoPeakBitrate.Enabled = false;
                        edWMVVideoQuality.Enabled = false;
                        break;
                    }

                case 2:
                    {
                        mode = VFWMVStreamMode.VBRPeakBitrate;
                        edWMVVideoBitrate.Enabled = true;
                        edWMVVideoPeakBitrate.Enabled = true;
                        edWMVVideoQuality.Enabled = false;
                        break;
                    }

                case 3:
                    {
                        mode = VFWMVStreamMode.VBRQuality;
                        edWMVVideoBitrate.Enabled = false;
                        edWMVVideoPeakBitrate.Enabled = false;
                        edWMVVideoQuality.Enabled = true;
                        break;
                    }
            }

            cbWMVVideoCodec.Items.Clear();
            if (_coreVideoCapture != null)
            {
                foreach (string codec in _coreVideoCapture.WMV_CustomProfile_VideoCodecs(mode))
                {
                    cbWMVVideoCodec.Items.Add(codec);
                }
            }
            else
            {
                foreach (string codec in _coreVideoEdit.WMV_CustomProfile_VideoCodecs(mode))
                {
                    cbWMVVideoCodec.Items.Add(codec);
                }
            }

            if (cbWMVVideoCodec.Items.Count > 0)
            {
                cbWMVVideoCodec.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Selects WM profile.
        /// </summary>
        /// <param name="sender">
        /// Sender object.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        private void btSelectWM_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                edWMVProfile.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Fills WMA settings.
        /// </summary>
        /// <param name="wmaOutput">
        /// WMA settings.
        /// </param>
        public void SaveSettings(ref VFWMAOutput wmaOutput)
        {
            //if (WMA && !_loaded)
            //{
            //    cbWMVInternalProfile9.Text = "Windows Media Audio 9 High (192K)";
            //}

            if (rbWMVInternal9.Checked)
            {
                wmaOutput.Mode = VFWMVMode.InternalProfile;

                if (cbWMVInternalProfile9.SelectedIndex != -1)
                {
                    wmaOutput.Internal_Profile_Name = cbWMVInternalProfile9.Text;
                }
            }
            else if (rbWMVInternal8.Checked)
            {
                wmaOutput.Mode = VFWMVMode.V8SystemProfile;

                if (cbWMVInternalProfile8.SelectedIndex != -1)
                {
                    wmaOutput.V8ProfileName = cbWMVInternalProfile8.Text;
                }
            }
            else if (rbWMVExternal.Checked)
            {
                wmaOutput.Mode = VFWMVMode.ExternalProfile;
                wmaOutput.External_Profile_FileName = edWMVProfile.Text;
            }
            else
            {
                wmaOutput.Mode = VFWMVMode.CustomSettings;

                wmaOutput.Custom_Audio_Codec = cbWMVAudioCodec.Text;
                wmaOutput.Custom_Audio_Format = cbWMVAudioFormat.Text;
                wmaOutput.Custom_Audio_PeakBitrate = Convert.ToInt32(edWMVAudioPeakBitrate.Text);

                string s = cbWMVAudioMode.Text;
                if (s == "CBR")
                {
                    wmaOutput.Custom_Audio_Mode = VFWMVStreamMode.CBR;
                }
                else if (s == "VBR")
                {
                    wmaOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRBitrate;
                }
                else if (s == "VBR (Peak)")
                {
                    wmaOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRPeakBitrate;
                }
                else
                {
                    wmaOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRQuality;
                }

                wmaOutput.Custom_Audio_StreamPresent = cbWMVAudioEnabled.Checked;

                wmaOutput.Custom_Profile_Name = "My_Profile_1";
            }
        }

        /// <summary>
        /// Loads WMA settings.
        /// </summary>
        /// <param name="wmaOutput">
        /// WMA settings.
        /// </param>
        public void LoadSettings(VFWMAOutput wmaOutput)
        {
            //if (WMA && !_loaded)
            //{
            //    cbWMVInternalProfile9.Text = "Windows Media Audio 9 High (192K)";
            //}

            switch (wmaOutput.Mode)
            {
                case VFWMVMode.ExternalProfile:
                    rbWMVExternal.Checked = true;
                    edWMVProfile.Text = wmaOutput.External_Profile_FileName;
                    break;
                case VFWMVMode.InternalProfile:
                    rbWMVInternal9.Checked = true;
                    if (!string.IsNullOrEmpty(wmaOutput.Internal_Profile_Name))
                    {
                        cbWMVInternalProfile9.Text = wmaOutput.Internal_Profile_Name;
                    }

                    break;
                case VFWMVMode.CustomSettings:
                    {
                        rbWMVCustom.Checked = true;

                        cbWMVAudioCodec.Text = wmaOutput.Custom_Audio_Codec;
                        cbWMVAudioFormat.Text = wmaOutput.Custom_Audio_Format;
                        edWMVAudioPeakBitrate.Text = wmaOutput.Custom_Audio_PeakBitrate.ToString();

                        switch (wmaOutput.Custom_Audio_Mode)
                        {
                            case VFWMVStreamMode.CBR:
                                cbWMVAudioMode.Text = "CBR";
                                break;
                            case VFWMVStreamMode.VBRQuality:
                                cbWMVAudioMode.Text = "Quality";
                                break;
                            case VFWMVStreamMode.VBRBitrate:
                                cbWMVAudioMode.Text = "VBR";
                                break;
                            case VFWMVStreamMode.VBRPeakBitrate:
                                cbWMVAudioMode.Text = "VBR (Peak)";
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        cbWMVAudioEnabled.Checked = wmaOutput.Custom_Audio_StreamPresent;
                    }
                    break;
                case VFWMVMode.V8SystemProfile:

                    rbWMVInternal8.Checked = true;

                    if (!string.IsNullOrEmpty(wmaOutput.V8ProfileName))
                    {
                        cbWMVInternalProfile8.Text = wmaOutput.V8ProfileName;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Fills WMV settings.
        /// </summary>
        /// <param name="wmvOutput">
        /// WMV settings.
        /// </param>
        public void SaveSettings(ref VFWMVOutput wmvOutput)
        {
            if (rbWMVInternal9.Checked)
            {
                wmvOutput.Mode = VFWMVMode.InternalProfile;

                if (cbWMVInternalProfile9.SelectedIndex != -1)
                {
                    wmvOutput.Internal_Profile_Name = cbWMVInternalProfile9.Text;
                }
            }
            else if (rbWMVInternal8.Checked)
            {
                wmvOutput.Mode = VFWMVMode.V8SystemProfile;

                if (cbWMVInternalProfile8.SelectedIndex != -1)
                {
                    wmvOutput.V8ProfileName = cbWMVInternalProfile8.Text;
                }
            }
            else if (rbWMVExternal.Checked)
            {
                wmvOutput.Mode = VFWMVMode.ExternalProfile;
                wmvOutput.External_Profile_FileName = edWMVProfile.Text;
            }
            else
            {
                wmvOutput.Mode = VFWMVMode.CustomSettings;

                wmvOutput.Custom_Audio_Codec = cbWMVAudioCodec.Text;
                wmvOutput.Custom_Audio_Format = cbWMVAudioFormat.Text;
                wmvOutput.Custom_Audio_PeakBitrate = Convert.ToInt32(edWMVAudioPeakBitrate.Text);

                string s = cbWMVAudioMode.Text;
                if (s == "CBR")
                {
                    wmvOutput.Custom_Audio_Mode = VFWMVStreamMode.CBR;
                }
                else if (s == "VBR")
                {
                    wmvOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRBitrate;
                }
                else if (s == "VBR (Peak)")
                {
                    wmvOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRPeakBitrate;
                }
                else
                {
                    wmvOutput.Custom_Audio_Mode = VFWMVStreamMode.VBRQuality;
                }

                wmvOutput.Custom_Audio_StreamPresent = cbWMVAudioEnabled.Checked;

                wmvOutput.Custom_Video_Codec = cbWMVVideoCodec.Text;
                wmvOutput.Custom_Video_Width = Convert.ToInt32(edWMVWidth.Text);
                wmvOutput.Custom_Video_Height = Convert.ToInt32(edWMVHeight.Text);
                wmvOutput.Custom_Video_SizeSameAsInput = cbWMVSizeSameAsInput.Checked;
                wmvOutput.Custom_Video_FrameRate = Convert.ToDouble(edWMVFrameRate.Text);
                wmvOutput.Custom_Video_KeyFrameInterval = Convert.ToByte(edWMVKeyFrameInterval.Text);
                wmvOutput.Custom_Video_Bitrate = Convert.ToInt32(edWMVVideoBitrate.Text);
                wmvOutput.Custom_Video_Quality = Convert.ToByte(edWMVVideoQuality.Text);

                s = cbWMVVideoMode.Text;
                if (s == "CBR")
                {
                    wmvOutput.Custom_Video_Mode = VFWMVStreamMode.CBR;
                }
                else if (s == "VBR")
                {
                    wmvOutput.Custom_Video_Mode = VFWMVStreamMode.VBRBitrate;
                }
                else if (s == "VBR (Peak)")
                {
                    wmvOutput.Custom_Video_Mode = VFWMVStreamMode.VBRPeakBitrate;
                }
                else
                {
                    wmvOutput.Custom_Video_Mode = VFWMVStreamMode.VBRQuality;
                }

                if (cbWMVTVFormat.Text == "PAL")
                {
                    wmvOutput.Custom_Video_TVSystem = VFWMVTVSystem.PAL;
                }
                else if (cbWMVTVFormat.Text == "NTSC")
                {
                    wmvOutput.Custom_Video_TVSystem = VFWMVTVSystem.NTSC;
                }
                else
                {
                    wmvOutput.Custom_Video_TVSystem = VFWMVTVSystem.Other;
                }

                wmvOutput.Custom_Video_StreamPresent = cbWMVVideoEnabled.Checked;

                wmvOutput.Custom_Profile_Name = "My_Profile_1";
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
