// <copyright file="WebMSettingsDialog.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using VisioForge.Types;
using VisioForge.Types.Output;

namespace VisioForge.Controls.UI.Dialogs.Shared.OutputFormats
{
    /// <summary>
    /// WebM settings dialog.
    /// </summary>
    public partial class WebMSettingsDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebMSettingsDialog"/> class.
        /// </summary>
        public WebMSettingsDialog()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            cbWebMVideoEndUsageMode.SelectedIndex = 0;
            edWebMVideoThreadCount.Text = Environment.ProcessorCount.ToString(CultureInfo.InvariantCulture);
            cbWebMVideoEncoder.SelectedIndex = 0;
            cbWebMVideoKeyframeMode.SelectedIndex = 0;
            cbWebMVideoQualityMode.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads settings.
        /// </summary>
        /// <param name="webmOutput">
        /// Output.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void LoadSettings(WebMOutput webmOutput)
        {
            tbWebMAudioQuality.Value = webmOutput.Audio_Quality;

            edWebMVideoBitrate.Text = webmOutput.Video_Bitrate.ToString();
            edWebMVideoARNRMaxFrames.Text = webmOutput.Video_ARNR_MaxFrames.ToString();
            edWebMVideoARNRStrenght.Text = webmOutput.Video_ARNR_Strength.ToString();
            edWebMVideoARNRType.Text = webmOutput.Video_ARNR_Type.ToString();
            edWebMVideoCPUUsed.Text = webmOutput.Video_CPUUsed.ToString();
            edWebMVideoDecimate.Text = webmOutput.Video_Decimate.ToString();
            edWebMVideoDecoderBufferSize.Text = webmOutput.Video_Decoder_Buffer_Size.ToString();
            edWebMVideoDecoderInitialBuffer.Text = webmOutput.Video_Decoder_Buffer_InitialSize.ToString();
            edWebMVideoDecoderOptimalBuffer.Text = webmOutput.Video_Decoder_Buffer_OptimalSize.ToString();
            edWebMVideoFixedKeyframeInterval.Text = webmOutput.Video_FixedKeyframeInterval.ToString();
            edWebMVideoKeyframeMaxInterval.Text = webmOutput.Video_Keyframe_MaxInterval.ToString();
            edWebMVideoKeyframeMinInterval.Text = webmOutput.Video_Keyframe_MinInterval.ToString();
            edWebMVideoLagInFrames.Text = webmOutput.Video_LagInFrames.ToString();
            edWebMVideoMaxQuantizer.Text = webmOutput.Video_MaxQuantizer.ToString();
            edWebMVideoMinQuantizer.Text = webmOutput.Video_MinQuantizer.ToString();
            edWebMVideoOvershootPct.Text = webmOutput.Video_OvershootPct.ToString();
            edWebMVideoSpatialDownThreshold.Text = webmOutput.Video_SpatialResampling_DownThreshold.ToString();
            edWebMVideoSpatialUpThreshold.Text = webmOutput.Video_SpatialResampling_UpThreshold.ToString();
            edWebMVideoStaticThreshold.Text = webmOutput.Video_StaticThreshold.ToString();
            edWebMVideoThreadCount.Text = webmOutput.Video_ThreadCount.ToString();
            edWebMVideoTokenPartition.Text = webmOutput.Video_TokenPartition.ToString();
            edWebMVideoUndershootPct.Text = webmOutput.Video_UndershootPct.ToString();
            cbWebMVideoAutoAltRef.Checked = webmOutput.Video_AutoAltRef;
            cbWebMVideoErrorResilent.Checked = webmOutput.Video_ErrorResilient;
            cbWebMVideoSpatialResamplingAllowed.Checked = webmOutput.Video_SpatialResampling_Allowed;
            cbWebMVideoEncoder.SelectedIndex = (int)webmOutput.Video_Encoder;

            switch (webmOutput.Video_EndUsage)
            {
                case VP8EndUsageMode.CBR:
                    cbWebMVideoEndUsageMode.SelectedIndex = 1;
                    break;
                case VP8EndUsageMode.Default:
                    cbWebMVideoEndUsageMode.SelectedIndex = 0;
                    break;
                case VP8EndUsageMode.VBR:
                    cbWebMVideoEndUsageMode.SelectedIndex = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (webmOutput.Video_Mode)
            {
                case VP8QualityMode.BestQualityBetaDoNotUse:
                    cbWebMVideoQualityMode.SelectedIndex = 2;
                    break;
                case VP8QualityMode.GoodQuality:
                    cbWebMVideoQualityMode.SelectedIndex = 1;
                    break;
                case VP8QualityMode.Realtime:
                    cbWebMVideoQualityMode.SelectedIndex = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            switch (webmOutput.Video_Keyframe_Mode)
            {
                case VP8KeyframeMode.Auto:
                    cbWebMVideoKeyframeMode.SelectedIndex = 0;
                    break;
                case VP8KeyframeMode.Default:
                    cbWebMVideoKeyframeMode.SelectedIndex = 1;
                    break;
                case VP8KeyframeMode.Disabled:
                    cbWebMVideoKeyframeMode.SelectedIndex = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Saves settings.
        /// </summary>
        /// <param name="webmOutput">
        /// Output.
        /// </param>
        public void SaveSettings(ref WebMOutput webmOutput)
        {
            webmOutput.Audio_Quality = tbWebMAudioQuality.Value;

            webmOutput.Video_Bitrate = Convert.ToInt32(edWebMVideoBitrate.Text);
            webmOutput.Video_ARNR_MaxFrames = Convert.ToInt32(edWebMVideoARNRMaxFrames.Text);
            webmOutput.Video_ARNR_Strength = Convert.ToInt32(edWebMVideoARNRStrenght.Text);
            webmOutput.Video_ARNR_Type = Convert.ToInt32(edWebMVideoARNRType.Text);
            webmOutput.Video_CPUUsed = Convert.ToInt32(edWebMVideoCPUUsed.Text);
            webmOutput.Video_Decimate = Convert.ToInt32(edWebMVideoDecimate.Text);
            webmOutput.Video_Decoder_Buffer_Size = Convert.ToInt32(edWebMVideoDecoderBufferSize.Text);
            webmOutput.Video_Decoder_Buffer_InitialSize = Convert.ToInt32(edWebMVideoDecoderInitialBuffer.Text);
            webmOutput.Video_Decoder_Buffer_OptimalSize = Convert.ToInt32(edWebMVideoDecoderOptimalBuffer.Text);
            webmOutput.Video_FixedKeyframeInterval = Convert.ToInt32(edWebMVideoFixedKeyframeInterval.Text);
            webmOutput.Video_Keyframe_MaxInterval = Convert.ToInt32(edWebMVideoKeyframeMaxInterval.Text);
            webmOutput.Video_Keyframe_MinInterval = Convert.ToInt32(edWebMVideoKeyframeMinInterval.Text);
            webmOutput.Video_LagInFrames = Convert.ToInt32(edWebMVideoLagInFrames.Text);
            webmOutput.Video_MaxQuantizer = Convert.ToInt32(edWebMVideoMaxQuantizer.Text);
            webmOutput.Video_MinQuantizer = Convert.ToInt32(edWebMVideoMinQuantizer.Text);
            webmOutput.Video_OvershootPct = Convert.ToInt32(edWebMVideoOvershootPct.Text);
            webmOutput.Video_SpatialResampling_DownThreshold = Convert.ToInt32(edWebMVideoSpatialDownThreshold.Text);
            webmOutput.Video_SpatialResampling_UpThreshold = Convert.ToInt32(edWebMVideoSpatialUpThreshold.Text);
            webmOutput.Video_StaticThreshold = Convert.ToInt32(edWebMVideoStaticThreshold.Text);
            webmOutput.Video_ThreadCount = Convert.ToInt32(edWebMVideoThreadCount.Text);
            webmOutput.Video_TokenPartition = Convert.ToInt32(edWebMVideoTokenPartition.Text);
            webmOutput.Video_UndershootPct = Convert.ToInt32(edWebMVideoUndershootPct.Text);
            webmOutput.Video_AutoAltRef = cbWebMVideoAutoAltRef.Checked;
            webmOutput.Video_ErrorResilient = cbWebMVideoErrorResilent.Checked;
            webmOutput.Video_SpatialResampling_Allowed = cbWebMVideoSpatialResamplingAllowed.Checked;
            webmOutput.Video_Encoder = (WebMVideoEncoder)cbWebMVideoEncoder.SelectedIndex;

            switch (cbWebMVideoEndUsageMode.SelectedIndex)
            {
                case 0:
                    webmOutput.Video_EndUsage = VP8EndUsageMode.Default;
                    break;
                case 1:
                    webmOutput.Video_EndUsage = VP8EndUsageMode.CBR;
                    break;
                case 2:
                    webmOutput.Video_EndUsage = VP8EndUsageMode.VBR;
                    break;
            }

            switch (cbWebMVideoQualityMode.SelectedIndex)
            {
                case 0:
                    webmOutput.Video_Mode = VP8QualityMode.Realtime;
                    break;
                case 1:
                    webmOutput.Video_Mode = VP8QualityMode.GoodQuality;
                    break;
                case 2:
                    webmOutput.Video_Mode = VP8QualityMode.BestQualityBetaDoNotUse;
                    break;
            }

            switch (cbWebMVideoKeyframeMode.SelectedIndex)
            {
                case 0:
                    webmOutput.Video_Keyframe_Mode = VP8KeyframeMode.Auto;
                    break;
                case 1:
                    webmOutput.Video_Keyframe_Mode = VP8KeyframeMode.Default;
                    break;
                case 2:
                    webmOutput.Video_Keyframe_Mode = VP8KeyframeMode.Disabled;
                    break;
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
