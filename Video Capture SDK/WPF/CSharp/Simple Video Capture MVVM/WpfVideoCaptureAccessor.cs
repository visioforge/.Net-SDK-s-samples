using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core.UI.WinForms.Dialogs;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
using VisioForge.Core.UI.WPF;
using VisioForge.Core.VideoCapture;
using VisioForge.Types;
using VisioForge.Types.Output;
using VisioForge.Types.VideoCapture;
using VisioForge.Types.VideoEffects;

namespace Simple_Video_Capture
{
    public class WpfVideoCaptureAccessor : IVideoCaptureAccessor
    {
        public WpfVideoCaptureAccessor()
        {
            videoView = new VideoView();
            this.videoCapture = new VideoCaptureCore(videoView);
            
            this.videoCapture.OnError += (_s, _e) => this.OnError?.Invoke(this, _e.Message);

            this.outputFormats = new List<OutputFormatInfo>
            {
                new OutputFormatInfo(OutputFormatInfoTag.AVI, "AVI", ".avi"),
                new OutputFormatInfo(OutputFormatInfoTag.WMV, "WMV (Windows Media Video)", ".wmv"),
                new OutputFormatInfo(OutputFormatInfoTag.MP4, "MP4 (CPU)", ".mp4"),
                new OutputFormatInfo(OutputFormatInfoTag.MP4_HW, "MP4 (GPU: Intel, Nvidia, AMD/ATI)", ".mp4"),
                new OutputFormatInfo(OutputFormatInfoTag.AGIF, "Animated GIF", ".gif"),
                new OutputFormatInfo(OutputFormatInfoTag.MPEGTS, "MPEG-TS", ".ts"),
                new OutputFormatInfo(OutputFormatInfoTag.MOV, "MOV", ".mov"),
            };
        }

        public event EventHandler<string> OnError;

        public void SetOwnerWindow(System.Windows.Window window)
        {
            if (window != null)
            {
                this.ownerWindowWeak = new WeakReference<System.Windows.Window>(window);
            }
        }

        public object UIElement => this.videoView;

        public Version SDK_Version => this.videoCapture.SDK_Version;

        public List<VideoCaptureDeviceInfo> Video_CaptureDevices => this.videoCapture.Video_CaptureDevices;

        public List<AudioCaptureDeviceInfo> Audio_CaptureDevices => this.videoCapture.Audio_CaptureDevices;

        public List<string> Audio_OutputDevices => this.videoCapture.Audio_OutputDevices;

        public List<OutputFormatInfo> OutputFormats => new List<OutputFormatInfo>(this.outputFormats);

        public VideoCaptureSource Video_CaptureDevice
        {
            get => this.videoCapture.Video_CaptureDevice;
            set => this.videoCapture.Video_CaptureDevice = value;
        }

        public AudioCaptureSource Audio_CaptureDevice
        {
            get => this.videoCapture.Audio_CaptureDevice;
            set => this.videoCapture.Audio_CaptureDevice = value;
        }

        public void Audio_OutputDevice_Volume_Set(int volume) => this.videoCapture.Audio_OutputDevice_Volume_Set(volume);

        public void Audio_OutputDevice_Balance_Set(int balance) => this.videoCapture.Audio_OutputDevice_Balance_Set(balance);

        public void DisplayConfigureDialog(OutputFormatInfoTag outputFormatInfoTag)
        {
            System.Windows.Window ownerWindow = TryGetOwnerWindow();

            switch (outputFormatInfoTag)
            {
                case OutputFormatInfoTag.AVI:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(videoCapture.Video_Codecs.ToArray(), videoCapture.Audio_Codecs.ToArray());
                        }

                        aviSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.WMV:
                    {
                        if (wmvSettingsDialog == null)
                        {
                            wmvSettingsDialog = new WMVSettingsDialog(this.videoCapture);
                        }

                        wmvSettingsDialog.WMA = false;
                        wmvSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.MP4:
                    {
                        if (this.mp4SettingsDialog == null)
                        {
                            this.mp4SettingsDialog = new MP4SettingsDialog();
                        }

                        this.mp4SettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.MP4_HW:
                    {
                        if (mp4HWSettingsDialog == null)
                        {
                            mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
                        }

                        mp4HWSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.AGIF:
                    {
                        if (gifSettingsDialog == null)
                        {
                            gifSettingsDialog = new GIFSettingsDialog();
                        }

                        gifSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.MPEGTS:
                    {
                        if (mpegTSSettingsDialog == null)
                        {
                            mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.MOV:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
                        }

                        movSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
            }
        }

        public void Audio_CaptureDevice_SettingsDialog_Show(string deviceName)
        {
            this.videoCapture.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, deviceName);
        }

        public void Video_CaptureDevice_SettingsDialog_Show(string deviceName)
        {
            this.videoCapture.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, deviceName);
        }

        public IVideoEffect AddImageLogoEffect()
        {
            using (var dlg = new ImageLogoSettingsDialog())
            {
                var name = dlg.GenerateNewEffectName(this.videoCapture);
                var effect = new VideoEffectImageLogo(true, name);

                this.videoCapture.Video_Effects_Add(effect);

                dlg.Fill(effect);
                dlg.ShowDialog(TryGetOwnerWindow());
                return effect;
            }

        }
        public IVideoEffect AddTextLogoEffect()
        {
            using (var dlg = new TextLogoSettingsDialog())
            {

                var name = dlg.GenerateNewEffectName(this.videoCapture);
                var effect = new VideoEffectTextLogo(true, name);

                this.videoCapture.Video_Effects_Add(effect);
                dlg.Fill(effect);
                dlg.ShowDialog(TryGetOwnerWindow());
                return effect;
            }
        }

        public void EditEffect(IVideoEffect effect)
        {
            if (effect.GetEffectType() == VideoEffectType.TextLogo)
            {
                using (var dlg = new TextLogoSettingsDialog())
                {
                    dlg.Attach(effect);
                    dlg.ShowDialog(TryGetOwnerWindow());
                }
            }
            else if (effect.GetEffectType() == VideoEffectType.ImageLogo)
            {
                using (var dlg = new ImageLogoSettingsDialog())
                {
                    dlg.Attach(effect);
                    dlg.ShowDialog(TryGetOwnerWindow());
                }
            }
        }

        public void RemoveEffect(IVideoEffect effect)
        {
            this.videoCapture.Video_Effects_Remove(effect.Name);
        }

        public void SetEffectEnabledState(string name, bool state)
        {
            var effect = this.videoCapture.Video_Effects_Get(name);
            if (effect != null)
            {
                effect.Enabled = state;
            }
            else
            {
                switch (name)
                {
                    case "Grayscale":
                        this.videoCapture.Video_Effects_Add(new VideoEffectGrayscale(state));
                        break;

                    case "Invert":
                        this.videoCapture.Video_Effects_Add(new VideoEffectInvert(state));
                        break;

                    case "FlipDown":
                        this.videoCapture.Video_Effects_Add(new VideoEffectFlipHorizontal(state));
                        break;

                    case "FlipRight":
                        this.videoCapture.Video_Effects_Add(new VideoEffectFlipVertical(state));
                        break;

                    default:
                        throw new ArgumentException($"Invalid effect name: {name}");
                }
            }
        }

        public void SetEffectValue(string name, int value)
        {
            switch (name)
            {
                case "Contrast":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVideoEffectContrast;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VideoEffectContrast(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Darkness":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVideoEffectDarkness;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VideoEffectDarkness(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Lightness":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVideoEffectLightness;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VideoEffectLightness(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Saturation":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVideoEffectSaturation;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VideoEffectSaturation(value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                default:
                    throw new ArgumentException($"Invalid effect name: {name}");
            }
        }

        public Task StartAsync(VideoCaptureStartParams startParams)
        {
            videoCapture.Video_Sample_Grabber_Enabled = true;
            videoCapture.Debug_Mode = startParams.DebugMode;
            videoCapture.Debug_Dir = startParams.DebugDirectory;

            videoCapture.Audio_OutputDevice = "Default DirectSound Device";

            if (startParams.RecordAudio)
            {
                videoCapture.Audio_RecordAudio = true;
                videoCapture.Audio_PlayAudio = true;
            }
            else
            {
                videoCapture.Audio_RecordAudio = false;
                videoCapture.Audio_PlayAudio = false;
            }

            videoCapture.Video_Renderer.VideoRenderer = VideoRendererMode.WPF;

            videoCapture.Video_CaptureDevice = startParams.VideoCaptureDevice;
            videoCapture.Audio_CaptureDevice = startParams.AudioCaptureDevice;
           
            videoCapture.Audio_OutputDevice = startParams.AudioOutputDevice;

            if (startParams.Preview)
            {
                videoCapture.Mode = VideoCaptureMode.VideoPreview;
            }
            else
            {
                videoCapture.Mode = VideoCaptureMode.VideoCapture;
                videoCapture.Output_Filename = startParams.OutputFileName;

                switch (startParams.OutputFormat)
                {
                    case OutputFormatInfoTag.AVI:
                        {
                            var aviOutput = new AVIOutput();
                            SetAVIOutput(ref aviOutput);
                            videoCapture.Output_Format = aviOutput;
                            break;
                        }

                    case OutputFormatInfoTag.WMV:
                        {
                            var wmvOutput = new WMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            videoCapture.Output_Format = wmvOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MP4:
                        {
                            var mp4Output = new MP4Output();
                            SetMP4Output(ref mp4Output);
                            videoCapture.Output_Format = mp4Output;
                            break;
                        }

                    case OutputFormatInfoTag.MP4_HW:
                        {
                            var mp4Output = new MP4HWOutput();
                            SetMP4HWOutput(ref mp4Output);
                            videoCapture.Output_Format = mp4Output;
                            break;
                        }

                    case OutputFormatInfoTag.AGIF:
                        {
                            var gifOutput = new AnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);
                            videoCapture.Output_Format = gifOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MPEGTS:
                        {
                            var tsOutput = new MPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            videoCapture.Output_Format = tsOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MOV:
                        {
                            var movOutput = new MOVOutput();
                            SetMOVOutput(ref movOutput);
                            videoCapture.Output_Format = movOutput;
                            break;
                        }
                }
            }

            videoCapture.Video_Effects_Enabled = true;
            videoCapture.Video_Effects_MergeImageLogos = startParams.MergeImageLogos;
            videoCapture.Video_Effects_MergeTextLogos = startParams.MergeTextLogos;
            videoCapture.Video_Effects_Clear();

            return this.videoCapture.StartAsync();
        }

        public Task<bool> PauseAsync()
        {
            return this.videoCapture.PauseAsync();
        }

        public Task<bool> ResumeAsync()
        {
            return this.videoCapture.ResumeAsync();
        }

        public Task StopAsync()
        {
            return this.videoCapture.StopAsync();
        }

        public TimeSpan Duration_Time() => this.videoCapture.Duration_Time();

        public Task<bool> SaveScreenshotAsync(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            Task<bool> task = null;

            switch (ext)
            {
                case ".bmp":
                    task = videoCapture.Frame_SaveAsync(fileName, ImageFormat.Bmp, 0);
                    break;
                case ".jpg":
                    task = videoCapture.Frame_SaveAsync(fileName, ImageFormat.Jpeg, 85);
                    break;
                case ".gif":
                    task = videoCapture.Frame_SaveAsync(fileName, ImageFormat.Gif, 0);
                    break;
                case ".png":
                    task = videoCapture.Frame_SaveAsync(fileName, ImageFormat.Png, 0);
                    break;
                case ".tiff":
                    task = videoCapture.Frame_SaveAsync(fileName, ImageFormat.Tiff, 0);
                    break;
            }

            return task ?? Task.FromResult(false);
        }

        #region private methods

        private System.Windows.Window TryGetOwnerWindow()
        {
            if (ownerWindowWeak != null)
            {
                if (ownerWindowWeak.TryGetTarget(out System.Windows.Window ownerWindow))
                {
                    return ownerWindow;
                }
            }

            return null;
        }

        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(videoCapture.Video_Codecs.ToArray(), videoCapture.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                aviOutput.MP3 = new MP3Output();
            }
        }

        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(videoCapture);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (mp4SettingsDialog == null)
            {
                mp4SettingsDialog = new MP4SettingsDialog();
            }

            mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetMPEGTSOutput(ref MPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref MOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        #endregion

        private readonly VideoCaptureCore videoCapture;

        private readonly VideoView videoView;

        private readonly List<OutputFormatInfo> outputFormats;

        private WeakReference<System.Windows.Window> ownerWindowWeak;

        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;
        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;
        private HWEncodersOutputSettingsDialog movSettingsDialog;
        private MP4SettingsDialog mp4SettingsDialog;
        private AVISettingsDialog aviSettingsDialog;
        private WMVSettingsDialog wmvSettingsDialog;
        private GIFSettingsDialog gifSettingsDialog;
    }
}
