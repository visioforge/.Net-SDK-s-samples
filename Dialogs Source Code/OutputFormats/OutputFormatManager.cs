// <copyright file="OutputFormatManager.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Windows;
using System.Windows.Forms;
using VisioForge.Controls.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.Output;
using VisioForge.Types.VideoCapture;
using MessageBox = System.Windows.Forms.MessageBox;

// ReSharper disable InconsistentNaming

namespace VisioForge.Controls.UI.Dialogs.Shared.OutputFormats
{
    /// <summary>
    /// Output format manager.
    /// </summary>
    public class OutputFormatManager : IDisposable
    {
        private HWEncodersOutputSettingsDialog mfSettingsDialog;

        private MP4SettingsDialog mp4SettingsDialog;

        private AVISettingsDialog aviSettingsDialog;

        private AVISettingsDialog mkvSettingsDialog;

        private WMVSettingsDialog wmvSettingsDialog;

        private WMVSettingsDialog wmaSettingsDialog;

        private DVSettingsDialog dvSettingsDialog;

        private PCMSettingsDialog pcmSettingsDialog;

        private MP3SettingsDialog mp3SettingsDialog;

        private WebMSettingsDialog webmSettingsDialog;

        private FFMPEGSettingsDialog ffmpegSettingsDialog;

        private FFMPEGEXESettingsDialog ffmpegEXESettingsDialog;

        private FLACSettingsDialog flacSettingsDialog;

        private CustomFormatSettingsDialog customFormatSettingsDialog;

        private OggVorbisSettingsDialog oggVorbisSettingsDialog;

        private SpeexSettingsDialog speexSettingsDialog;

        private M4ASettingsDialog m4aSettingsDialog;

        private GIFSettingsDialog gifSettingsDialog;

        /// <summary>
        /// Shows dialog.
        /// </summary>
        /// <param name="format">
        /// Format.
        /// </param>
        /// <param name="parent">
        /// Parent.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void ShowDialog(VideoCaptureOutputFormat format, Window parent, VideoCaptureCore core)
        {
            ShowDialog(format, new WPFWindowWrapper(parent), core);
        }

        /// <summary>
        /// Shows dialog.
        /// </summary>
        /// <param name="format">
        /// Format.
        /// </param>
        /// <param name="parent">
        /// Parent.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S1871:Two branches in a conditional structure should not have exactly the same implementation", Justification = "<Pending>")]
        public void ShowDialog(VideoCaptureOutputFormat format, IWin32Window parent, VideoCaptureCore core)
        {
            switch (format)
            {
                case VideoCaptureOutputFormat.AVI:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(
                                core.Video_Codecs.ToArray(),
                                core.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.WMV:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(core);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.DV:
                    {
                        if (dvSettingsDialog == null)
                        {
                            dvSettingsDialog = new DVSettingsDialog();
                        }

                        dvSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MKVv1:
                    {
                        if (mkvSettingsDialog == null)
                        {
                            mkvSettingsDialog = new AVISettingsDialog(
                                core.Video_Codecs.ToArray(), 
                                core.Audio_Codecs.ToArray());
                        }

                        mkvSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.PCM_ACM:
                    {
                        if (pcmSettingsDialog == null)
                        {
                            pcmSettingsDialog = new PCMSettingsDialog(core.Audio_Codecs.ToArray());
                        }

                        pcmSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.WMA:
                    {
                        if (wmaSettingsDialog == null)
                        {
                            wmaSettingsDialog = new WMVSettingsDialog(core);
                        }

                        wmaSettingsDialog.WMA = true;
                        wmaSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MP3:
                    {
                        if (mp3SettingsDialog == null)
                        {
                            mp3SettingsDialog = new MP3SettingsDialog();
                        }

                        mp3SettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.Custom:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(
                                core.Video_Codecs.ToArray(), 
                                core.Audio_Codecs.ToArray(), 
                                core.DirectShow_Filters.ToArray());
                        }

                        customFormatSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureDV:
                case VideoCaptureOutputFormat.DirectCaptureMPEG:
                case VideoCaptureOutputFormat.DirectCaptureAVI:
                case VideoCaptureOutputFormat.DirectCaptureMKV:
                    {
                        MessageBox.Show("No settings available for selected output format.");

                        break;
                    }

                case VideoCaptureOutputFormat.FFMPEG:
                    {
                        if (ffmpegSettingsDialog == null)
                        {
                            ffmpegSettingsDialog = new FFMPEGSettingsDialog();
                        }

                        ffmpegSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.WebM:
                    {
                        if (webmSettingsDialog == null)
                        {
                            webmSettingsDialog = new WebMSettingsDialog();
                        }

                        webmSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureMP4_GDCL:
                case VideoCaptureOutputFormat.DirectCaptureMP4_Monogram:
                    {
                        MessageBox.Show("No settings available for selected output format.");

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureCustom:
                    {
                        if (customFormatSettingsDialog == null)
                        {
                            customFormatSettingsDialog = new CustomFormatSettingsDialog(
                                core.Video_Codecs.ToArray(),
                                core.Audio_Codecs.ToArray(),
                                core.DirectShow_Filters.ToArray());
                        }

                        customFormatSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MP4:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MP4_HW:
                    {
                        if (mfSettingsDialog == null)
                        {
                            mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mfSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MPEGTS:
                    {
                        if (mfSettingsDialog == null)
                        {
                            mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
                        }

                        mfSettingsDialog.ShowDialog(parent);

                        break;
                    }
                    
                case VideoCaptureOutputFormat.MKVv2:
                    {
                        if (mfSettingsDialog == null)
                        {
                            mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MKV);
                        }

                        mfSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.MOV:
                    {
                        if (mfSettingsDialog == null)
                        {
                            mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
                        }

                        mfSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.Encrypted:
                    {
                        if (mp4SettingsDialog == null)
                        {
                            mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        mp4SettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.FLAC:
                    {
                        if (flacSettingsDialog == null)
                        {
                            flacSettingsDialog = new FLACSettingsDialog();
                        }

                        flacSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.OggVorbis:
                    {
                        if (oggVorbisSettingsDialog == null)
                        {
                            oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
                        }

                        oggVorbisSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.Speex:
                    {
                        if (speexSettingsDialog == null)
                        {
                            speexSettingsDialog = new SpeexSettingsDialog();
                        }

                        speexSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.FFMPEG_EXE:
                    {
                        if (ffmpegEXESettingsDialog == null)
                        {
                            ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
                        }

                        ffmpegEXESettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.M4A:
                    {
                        if (m4aSettingsDialog == null)
                        {
                            m4aSettingsDialog = new M4ASettingsDialog();
                        }

                        m4aSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.AnimatedGIF:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(parent);

                        break;
                    }

                case VideoCaptureOutputFormat.VLC_EXE:
                    {
                        MessageBox.Show("No settings available for selected output format.");

                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        /// <summary>
        /// Sets MP3 output.
        /// </summary>
        /// <param name="mp3Output">
        /// Output.
        /// </param>
        public void SetMP3Output(ref MP3Output mp3Output)
        {
            if (mp3SettingsDialog == null)
            {
                mp3SettingsDialog = new MP3SettingsDialog();
            }

            mp3SettingsDialog.SaveSettings(ref mp3Output);
        }

        /// <summary>
        /// Sets MP4 output.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SetMP4Output(ref MP4Output mp4Output)
        {
            if (this.mp4SettingsDialog == null)
            {
                this.mp4SettingsDialog = new MP4SettingsDialog();
            }

            this.mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Sets FFMPEG.exe output.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// Output.
        /// </param>
        public void SetFFMPEGEXEOutput(ref FFMPEGEXEOutput ffmpegOutput)
        {
            if (ffmpegEXESettingsDialog == null)
            {
                ffmpegEXESettingsDialog = new FFMPEGEXESettingsDialog();
            }

            ffmpegEXESettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Sets WMV output.
        /// </summary>
        /// <param name="wmvOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetWMVOutput(ref WMVOutput wmvOutput, VideoCaptureCore core)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(core);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Sets WMA output.
        /// </summary>
        /// <param name="wmaOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetWMAOutput(ref WMAOutput wmaOutput, VideoCaptureCore core)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(core);
            }

            wmvSettingsDialog.WMA = true;
            wmvSettingsDialog.SaveSettings(ref wmaOutput);
        }

        /// <summary>
        /// Sets ACM output.
        /// </summary>
        /// <param name="acmOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetACMOutput(ref ACMOutput acmOutput, VideoCaptureCore core)
        {
            if (pcmSettingsDialog == null)
            {
                pcmSettingsDialog = new PCMSettingsDialog(core.Audio_Codecs.ToArray());
            }

            pcmSettingsDialog.SaveSettings(ref acmOutput);
        }

        /// <summary>
        /// Set WebM output.
        /// </summary>
        /// <param name="webmOutput">
        /// Output.
        /// </param>
        public void SetWebMOutput(ref WebMOutput webmOutput)
        {
            if (webmSettingsDialog == null)
            {
                webmSettingsDialog = new WebMSettingsDialog();
            }

            webmSettingsDialog.SaveSettings(ref webmOutput);
        }

        /// <summary>
        /// Sets FFMPEG output.
        /// </summary>
        /// <param name="ffmpegOutput">
        /// Output.
        /// </param>
        public void SetFFMPEGOutput(ref FFMPEGOutput ffmpegOutput)
        {
            if (ffmpegSettingsDialog == null)
            {
                ffmpegSettingsDialog = new FFMPEGSettingsDialog();
            }

            ffmpegSettingsDialog.SaveSettings(ref ffmpegOutput);
        }

        /// <summary>
        /// Sets FLAC output.
        /// </summary>
        /// <param name="flacOutput">
        /// Output.
        /// </param>
        public void SetFLACOutput(ref FLACOutput flacOutput)
        {
            if (flacSettingsDialog == null)
            {
                flacSettingsDialog = new FLACSettingsDialog();
            }

            flacSettingsDialog.SaveSettings(ref flacOutput);
        }

        /// <summary>
        /// Sets MP4 HW output.
        /// </summary>
        /// <param name="mp4Output">
        /// Output.
        /// </param>
        public void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mfSettingsDialog == null)
            {
                mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mfSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Sets MOV output.
        /// </summary>
        /// <param name="movOutput">
        /// Output.
        /// </param>
        public void SetMOVOutput(ref MOVOutput movOutput)
        {
            if (mfSettingsDialog == null)
            {
                mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            mfSettingsDialog.SaveSettings(ref movOutput);
        }

        /// <summary>
        /// Sets MPEG-TS output.
        /// </summary>
        /// <param name="tsOutput">
        /// Output.
        /// </param>
        public void SetMPEGTSOutput(ref MPEGTSOutput tsOutput)
        {
            if (mfSettingsDialog == null)
            {
                mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mfSettingsDialog.SaveSettings(ref tsOutput);
        }

        /// <summary>
        /// Sets MKV v2 output.
        /// </summary>
        /// <param name="mkvOutput">
        /// Output.
        /// </param>
        public void SetMKVv2Output(ref MKVv2Output mkvOutput)
        {
            if (mfSettingsDialog == null)
            {
                mfSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MKV);
            }

            mfSettingsDialog.SaveSettings(ref mkvOutput);
        }

        /// <summary>
        /// Sets Speex output.
        /// </summary>
        /// <param name="speexOutput">
        /// Output.
        /// </param>
        public void SetSpeexOutput(ref SpeexOutput speexOutput)
        {
            if (speexSettingsDialog == null)
            {
                speexSettingsDialog = new SpeexSettingsDialog();
            }

            speexSettingsDialog.SaveSettings(ref speexOutput);
        }

        /// <summary>
        /// Sets M4A output.
        /// </summary>
        /// <param name="m4aOutput">
        /// Output.
        /// </param>
        public void SetM4AOutput(ref M4AOutput m4aOutput)
        {
            if (m4aSettingsDialog == null)
            {
                m4aSettingsDialog = new M4ASettingsDialog();
            }

            m4aSettingsDialog.SaveSettings(ref m4aOutput);
        }

        /// <summary>
        /// Sets GIF output.
        /// </summary>
        /// <param name="gifOutput">
        /// Output.
        /// </param>
        public void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Sets DirectCapture custom output.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetDirectCaptureCustomOutput(ref DirectCaptureCustomOutput directCaptureOutput, VideoCaptureCore core)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(
                    core.Video_Codecs.ToArray(),
                    core.Audio_Codecs.ToArray(), 
                    core.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        /// <summary>
        /// Sets DirectCapture custom output.
        /// </summary>
        /// <param name="directCaptureOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetDirectCaptureCustomOutput(ref DirectCaptureMP4Output directCaptureOutput, VideoCaptureCore core)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(
                    core.Video_Codecs.ToArray(),
                    core.Audio_Codecs.ToArray(), 
                    core.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref directCaptureOutput);
        }

        /// <summary>
        /// Sets custom output.
        /// </summary>
        /// <param name="customOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetCustomOutput(ref CustomOutput customOutput, VideoCaptureCore core)
        {
            if (customFormatSettingsDialog == null)
            {
                customFormatSettingsDialog = new CustomFormatSettingsDialog(
                    core.Video_Codecs.ToArray(), 
                    core.Audio_Codecs.ToArray(),
                    core.DirectShow_Filters.ToArray());
            }

            customFormatSettingsDialog.SaveSettings(ref customOutput);
        }

        /// <summary>
        /// Sets DV output.
        /// </summary>
        /// <param name="dvOutput">
        /// Output.
        /// </param>
        public void SetDVOutput(ref DVOutput dvOutput)
        {
            if (dvSettingsDialog == null)
            {
                dvSettingsDialog = new DVSettingsDialog();
            }

            dvSettingsDialog.SaveSettings(ref dvOutput);
        }

        /// <summary>
        /// Sets AVI output.
        /// </summary>
        /// <param name="aviOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetAVIOutput(ref AVIOutput aviOutput, VideoCaptureCore core)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    core.Video_Codecs.ToArray(),
                    core.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                aviOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Sets MKV output.
        /// </summary>
        /// <param name="mkvOutput">
        /// Output.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        public void SetMKVOutput(ref MKVv1Output mkvOutput, VideoCaptureCore core)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(
                    core.Video_Codecs.ToArray(),
                    core.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref mkvOutput);

            if (mkvOutput.Audio_UseMP3Encoder)
            {
                var mp3Output = new MP3Output();
                SetMP3Output(ref mp3Output);
                mkvOutput.MP3 = mp3Output;
            }
        }

        /// <summary>
        /// Sets OGG output.
        /// </summary>
        /// <param name="oggVorbisOutput">
        /// Output.
        /// </param>
        public void SetOGGOutput(ref OGGVorbisOutput oggVorbisOutput)
        {
            if (oggVorbisSettingsDialog == null)
            {
                oggVorbisSettingsDialog = new OggVorbisSettingsDialog();
            }

            oggVorbisSettingsDialog.SaveSettings(ref oggVorbisOutput);
        }

        /// <summary>
        /// Fill settings.
        /// </summary>
        /// <param name="format">
        /// Format.
        /// </param>
        /// <param name="core">
        /// Core.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// ArgumentOutOfRangeException.
        /// </exception>
        public void FillSettings(VideoCaptureOutputFormat format, VideoCaptureCore core)
        {
            switch (format)
            {
                case VideoCaptureOutputFormat.AVI:
                    {
                        var aviOutput = new AVIOutput();
                        SetAVIOutput(ref aviOutput, core);
                        core.Output_Format = aviOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.WMV:
                    {
                        var wmvOutput = new WMVOutput();
                        SetWMVOutput(ref wmvOutput, core);
                        core.Output_Format = wmvOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.DV:
                    {
                        var dvOutput = new DVOutput();
                        SetDVOutput(ref dvOutput);
                        core.Output_Format = dvOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.MKVv1:
                    {
                        var mkvOutput = new MKVv1Output();
                        SetMKVOutput(ref mkvOutput, core);
                        core.Output_Format = mkvOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.PCM_ACM:
                    {
                        var acmOutput = new ACMOutput();
                        SetACMOutput(ref acmOutput, core);
                        core.Output_Format = acmOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.WMA:
                    {
                        var wmaOutput = new WMAOutput();
                        SetWMAOutput(ref wmaOutput, core);
                        core.Output_Format = wmaOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.MP3:
                    {
                        var mp3Output = new MP3Output();
                        SetMP3Output(ref mp3Output);
                        core.Output_Format = mp3Output;

                        break;
                    }

                case VideoCaptureOutputFormat.Custom:
                    {
                        var customOutput = new CustomOutput();
                        SetCustomOutput(ref customOutput, core);
                        core.Output_Format = customOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureDV:
                    {
                        core.Output_Format = new DirectCaptureDVOutput();
                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureMPEG:
                    {
                        core.Output_Format = new DirectCaptureMPEGOutput();
                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureAVI:
                    {
                        core.Output_Format = new DirectCaptureAVIOutput();
                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureMKV:
                    {
                        core.Output_Format = new DirectCaptureMKVOutput();
                        break;
                    }

                case VideoCaptureOutputFormat.FFMPEG:
                    {
                        var ffmpegOutput = new FFMPEGOutput();
                        SetFFMPEGOutput(ref ffmpegOutput);
                        core.Output_Format = ffmpegOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.WebM:
                    {
                        var webmOutput = new WebMOutput();
                        SetWebMOutput(ref webmOutput);
                        core.Output_Format = webmOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureMP4_GDCL:
                    {
                        var directCaptureOutputGDCL = new DirectCaptureMP4Output();
                        SetDirectCaptureCustomOutput(ref directCaptureOutputGDCL, core);
                        directCaptureOutputGDCL.Muxer = DirectCaptureMP4Muxer.GDCL;
                        core.Output_Format = directCaptureOutputGDCL;

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureMP4_Monogram:
                    {
                        var directCaptureOutputMG = new DirectCaptureMP4Output();
                        SetDirectCaptureCustomOutput(ref directCaptureOutputMG, core);
                        directCaptureOutputMG.Muxer = DirectCaptureMP4Muxer.Monogram;
                        core.Output_Format = directCaptureOutputMG;

                        break;
                    }

                case VideoCaptureOutputFormat.DirectCaptureCustom:
                    {
                        var directCaptureOutput = new DirectCaptureCustomOutput();
                        SetDirectCaptureCustomOutput(ref directCaptureOutput, core);
                        core.Output_Format = directCaptureOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.MP4:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        var mp4Output = new MP4Output();
                        SetMP4Output(ref mp4Output);
                        core.Output_Format = mp4Output;
                                              
                        break;
                    }

                case VideoCaptureOutputFormat.MP4_HW:
                    {
                        var mp4Output = new MP4HWOutput();
                        SetMP4HWOutput(ref mp4Output);
                        core.Output_Format = mp4Output;

                        break;
                    }

                case VideoCaptureOutputFormat.MPEGTS:
                    {
                        var tsOutput = new MPEGTSOutput();
                        SetMPEGTSOutput(ref tsOutput);
                        core.Output_Format = tsOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.MKVv2:
                    {
                        var mkvOutput = new MKVv2Output();
                        SetMKVv2Output(ref mkvOutput);
                        core.Output_Format = mkvOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.MOV:
                    {
                        var movOutput = new MOVOutput();
                        SetMOVOutput(ref movOutput);
                        core.Output_Format = movOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.Encrypted:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        var mp4Output = new MP4Output();
                        SetMP4Output(ref mp4Output);
                        mp4Output.Encryption = true;
                        core.Output_Format = mp4Output;

                        break;
                    }

                case VideoCaptureOutputFormat.FLAC:
                    {
                        var flacOutput = new FLACOutput();
                        SetFLACOutput(ref flacOutput);
                        core.Output_Format = flacOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.OggVorbis:
                    {
                        var oggVorbisOutput = new OGGVorbisOutput();
                        SetOGGOutput(ref oggVorbisOutput);
                        core.Output_Format = oggVorbisOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.Speex:
                    {
                        var speexOutput = new SpeexOutput();
                        SetSpeexOutput(ref speexOutput);
                        core.Output_Format = speexOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.FFMPEG_EXE:
                    {
                        var ffmpegOutput = new FFMPEGEXEOutput();
                        SetFFMPEGEXEOutput(ref ffmpegOutput);
                        core.Output_Format = ffmpegOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.M4A:
                    {
                        var m4aOutput = new M4AOutput();
                        SetM4AOutput(ref m4aOutput);
                        core.Output_Format = m4aOutput;

                        break;
                    }

                case VideoCaptureOutputFormat.AnimatedGIF:
                    {
                        var gifOutput = new AnimatedGIFOutput();
                        SetGIFOutput(ref gifOutput);
                        core.Output_Format = gifOutput;
                        break;
                    }

                case VideoCaptureOutputFormat.VLC_EXE:
                    {
                        var vlcOutput = new VLCEXEOutput();
                        core.Output_Format = vlcOutput;
                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
#pragma warning disable S1186 // Methods should not be empty
        private void ReleaseUnmanagedResources()
#pragma warning restore S1186 // Methods should not be empty
        {
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing">
        /// Is disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();

            if (disposing)
            {
                if (mfSettingsDialog != null)
                {
                    mfSettingsDialog.Dispose();
                    mfSettingsDialog = null;
                }

                if (ffmpegSettingsDialog != null)
                {
                    ffmpegSettingsDialog.Dispose();
                    ffmpegSettingsDialog = null;
                }

                if (webmSettingsDialog != null)
                {
                    webmSettingsDialog.Dispose();
                    webmSettingsDialog = null;
                }

                if (pcmSettingsDialog != null)
                {
                    pcmSettingsDialog.Dispose();
                    pcmSettingsDialog = null;
                }

                if (mp3SettingsDialog != null)
                {
                    mp3SettingsDialog.Dispose();
                    mp3SettingsDialog = null;
                }

                if (dvSettingsDialog != null)
                {
                    dvSettingsDialog.Dispose();
                    dvSettingsDialog = null;
                }

                if (wmaSettingsDialog != null)
                {
                    wmaSettingsDialog.Dispose();
                    wmaSettingsDialog = null;
                }

                if (wmvSettingsDialog != null)
                {
                    wmvSettingsDialog.Dispose();
                    wmvSettingsDialog = null;
                }

                if (mkvSettingsDialog != null)
                {
                    mkvSettingsDialog.Dispose();
                    mkvSettingsDialog = null;
                }

                if (aviSettingsDialog != null)
                {
                    aviSettingsDialog.Dispose();
                    aviSettingsDialog = null;
                }

                if (this.mp4SettingsDialog != null)
                {
                    this.mp4SettingsDialog.Dispose();
                    this.mp4SettingsDialog = null;
                }
                
                if (gifSettingsDialog != null)
                {
                    gifSettingsDialog.Dispose();
                    gifSettingsDialog = null;
                }

                if (m4aSettingsDialog != null)
                {
                    m4aSettingsDialog.Dispose();
                    m4aSettingsDialog = null;
                }

                if (speexSettingsDialog != null)
                {
                    speexSettingsDialog.Dispose();
                    speexSettingsDialog = null;
                }

                if (oggVorbisSettingsDialog != null)
                {
                    oggVorbisSettingsDialog.Dispose();
                    oggVorbisSettingsDialog = null;
                }

                if (customFormatSettingsDialog != null)
                {
                    customFormatSettingsDialog.Dispose();
                    customFormatSettingsDialog = null;
                }

                if (flacSettingsDialog != null)
                {
                    flacSettingsDialog.Dispose();
                    flacSettingsDialog = null;
                }

                if (ffmpegEXESettingsDialog != null)
                {
                    ffmpegEXESettingsDialog.Dispose();
                    ffmpegEXESettingsDialog = null;
                }
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="OutputFormatManager"/> class.
        /// </summary>
        ~OutputFormatManager()
        {
            Dispose(false);
        }
    }
}
