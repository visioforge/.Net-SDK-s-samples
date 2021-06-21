using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Controls.UI.Dialogs;
using VisioForge.Controls.UI.Dialogs.OutputFormats;
using VisioForge.Controls.UI.Dialogs.VideoEffects;
using VisioForge.Controls.UI.WPF;
using VisioForge.Types;
using VisioForge.Types.OutputFormat;
using VisioForge.Types.VideoEffects;

namespace Simple_Video_Capture
{
    public class WpfVideoCaptureAccessor
        : IVideoCaptureAccessor
    {
        public WpfVideoCaptureAccessor()
        {
            this.videoCapture = new VideoCapture();
            this.videoCapture.OnError += (_s, _e) => this.OnError?.Invoke(this, _e.Message);
            this.videoCapture.OnLicenseRequired += (_s, _e) => this.OnError?.Invoke(this, "(NOT ERROR) " + _e.Message);

            this.outputFormats = new List<OutputFormatInfo>
            {
                new OutputFormatInfo(OutputFormatInfoTag.AVI, "AVI", ".avi"),
                new OutputFormatInfo(OutputFormatInfoTag.WMV, "WMV (Windows Media Video)", ".wmv"),
                new OutputFormatInfo(OutputFormatInfoTag.MP4, "MP4", ".mp4"),
                new OutputFormatInfo(OutputFormatInfoTag.MP4_v11, "MP4 (v11 engine, CPU/GPU)", ".mp4"),
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

        public object UIElement => this.videoCapture;

        public Version SDK_Version => this.videoCapture.SDK_Version;

        public string SDK_State => this.videoCapture.SDK_State;

        public List<VideoCaptureDeviceInfo> Video_CaptureDevicesInfo => this.videoCapture.Video_CaptureDevicesInfo;

        public List<AudioCaptureDeviceInfo> Audio_CaptureDevicesInfo => this.videoCapture.Audio_CaptureDevicesInfo;

        public List<string> Audio_OutputDevices => this.videoCapture.Audio_OutputDevices;

        public List<OutputFormatInfo> OutputFormats => new List<OutputFormatInfo>(this.outputFormats);

        public string Audio_CaptureDevice_Format
        {
            get => this.videoCapture.Audio_CaptureDevice_Format;
            set => this.videoCapture.Audio_CaptureDevice_Format = value;
        }

        public string Audio_CaptureDevice_Line
        {
            get => this.videoCapture.Audio_CaptureDevice_Line;
            set => this.videoCapture.Audio_CaptureDevice_Line = value;
        }

        public bool Video_CaptureDevice_IsAudioSource
        {
            get => this.videoCapture.Video_CaptureDevice_IsAudioSource;
            set => this.videoCapture.Video_CaptureDevice_IsAudioSource = value;
        }

        public string Video_CaptureDevice
        {
            get => this.videoCapture.Video_CaptureDevice;
            set => this.videoCapture.Video_CaptureDevice = value;
        }

        public string Audio_CaptureDevice
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
                case OutputFormatInfoTag.MP4_v11:
                    {
                        if (mp4v11SettingsDialog == null)
                        {
                            mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
                        }

                        mp4v11SettingsDialog.ShowDialog(ownerWindow);

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
                            mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
                        }

                        mpegTSSettingsDialog.ShowDialog(ownerWindow);

                        break;
                    }
                case OutputFormatInfoTag.MOV:
                    {
                        if (movSettingsDialog == null)
                        {
                            movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
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

        public IVFVideoEffect AddImageLogoEffect()
        {
            using (var dlg = new ImageLogoSettingsDialog())
            {
                var name = dlg.GenerateNewEffectName(this.videoCapture);
                var effect = new VFVideoEffectImageLogo(true, name);

                this.videoCapture.Video_Effects_Add(effect);

                dlg.Fill(effect);
                dlg.ShowDialog(TryGetOwnerWindow());
                return effect;
            }

        }
        public IVFVideoEffect AddTextLogoEffect()
        {
            using (var dlg = new TextLogoSettingsDialog())
            {

                var name = dlg.GenerateNewEffectName(this.videoCapture);
                var effect = new VFVideoEffectTextLogo(true, name);

                this.videoCapture.Video_Effects_Add(effect);
                dlg.Fill(effect);
                dlg.ShowDialog(TryGetOwnerWindow());
                return effect;
            }
        }

        public void EditEffect(IVFVideoEffect effect)
        {
            if (effect.GetEffectType() == VFVideoEffectType.TextLogo)
            {
                using (var dlg = new TextLogoSettingsDialog())
                {
                    dlg.Attach(effect);
                    dlg.ShowDialog(TryGetOwnerWindow());
                }
            }
            else if (effect.GetEffectType() == VFVideoEffectType.ImageLogo)
            {
                using (var dlg = new ImageLogoSettingsDialog())
                {
                    dlg.Attach(effect);
                    dlg.ShowDialog(TryGetOwnerWindow());
                }
            }
        }

        public void RemoveEffect(IVFVideoEffect effect)
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
                        this.videoCapture.Video_Effects_Add(new VFVideoEffectGrayscale(state));
                        break;

                    case "Invert":
                        this.videoCapture.Video_Effects_Add(new VFVideoEffectInvert(state));
                        break;

                    case "FlipDown":
                        this.videoCapture.Video_Effects_Add(new VFVideoEffectFlipHorizontal(state));
                        break;

                    case "FlipRight":
                        this.videoCapture.Video_Effects_Add(new VFVideoEffectFlipVertical(state));
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
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVFVideoEffectContrast;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VFVideoEffectContrast(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Darkness":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVFVideoEffectDarkness;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VFVideoEffectDarkness(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Lightness":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVFVideoEffectLightness;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VFVideoEffectLightness(true, value));
                        }
                        else
                        {
                            effect.Value = value;
                        }
                    }
                    break;

                case "Saturation":
                    {
                        var effect = this.videoCapture.Video_Effects_Get(name) as IVFVideoEffectSaturation;
                        if (effect == null)
                        {
                            this.videoCapture.Video_Effects_Add(new VFVideoEffectSaturation(value));
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

            videoCapture.Video_Renderer.Video_Renderer = VFVideoRendererWPF.WPF;

            videoCapture.Video_CaptureDevice = startParams.VideoCaptureDevice;
            videoCapture.Video_CaptureDevice_IsAudioSource = startParams.VideoCaptureDeviceIsAudioSource;
            videoCapture.Video_CaptureFormat = startParams.VideoCaptureFormat;
            videoCapture.Video_CaptureFormat_UseBest = startParams.VideoCaptureFormatUseBest;
            videoCapture.Audio_CaptureDevice = startParams.AudioCaptureDevice;
            videoCapture.Audio_CaptureDevice_Format = startParams.AudioCaptureDeviceFormat;
            videoCapture.Audio_CaptureDevice_Format_UseBest = startParams.AudioCaptureDeviceFormatUseBest;
            videoCapture.Audio_OutputDevice = startParams.AudioOutputDevice;

            if (startParams.VideoFrameRate > 0)
            {
                videoCapture.Video_FrameRate = startParams.VideoFrameRate;
            }

            if (startParams.Preview == true)
            {
                videoCapture.Mode = VFVideoCaptureMode.VideoPreview;
            }
            else
            {
                videoCapture.Mode = VFVideoCaptureMode.VideoCapture;
                videoCapture.Output_Filename = startParams.OutputFileName;

                switch (startParams.OutputFormat)
                {
                    case OutputFormatInfoTag.AVI:
                        {
                            var aviOutput = new VFAVIOutput();
                            SetAVIOutput(ref aviOutput);
                            videoCapture.Output_Format = aviOutput;
                            break;
                        }

                    case OutputFormatInfoTag.WMV:
                        {
                            var wmvOutput = new VFWMVOutput();
                            SetWMVOutput(ref wmvOutput);
                            videoCapture.Output_Format = wmvOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MP4:
                        {
                            var mp4Output = new VFMP4Output();
                            SetMP4Output(ref mp4Output);
                            videoCapture.Output_Format = mp4Output;
                            break;
                        }

                    case OutputFormatInfoTag.MP4_v11:
                        {
                            var mp4Output = new VFMP4v11Output();
                            SetMP4v11Output(ref mp4Output);
                            videoCapture.Output_Format = mp4Output;
                            break;
                        }

                    case OutputFormatInfoTag.AGIF:
                        {
                            var gifOutput = new VFAnimatedGIFOutput();
                            SetGIFOutput(ref gifOutput);
                            videoCapture.Output_Format = gifOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MPEGTS:
                        {
                            var tsOutput = new VFMPEGTSOutput();
                            SetMPEGTSOutput(ref tsOutput);
                            videoCapture.Output_Format = tsOutput;
                            break;
                        }

                    case OutputFormatInfoTag.MOV:
                        {
                            var movOutput = new VFMOVOutput();
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
                    task = videoCapture.Frame_SaveAsync(fileName, VFImageFormat.BMP, 0);
                    break;
                case ".jpg":
                    task = videoCapture.Frame_SaveAsync(fileName, VFImageFormat.JPEG, 85);
                    break;
                case ".gif":
                    task = videoCapture.Frame_SaveAsync(fileName, VFImageFormat.GIF, 0);
                    break;
                case ".png":
                    task = videoCapture.Frame_SaveAsync(fileName, VFImageFormat.PNG, 0);
                    break;
                case ".tiff":
                    task = videoCapture.Frame_SaveAsync(fileName, VFImageFormat.TIFF, 0);
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

        private void SetAVIOutput(ref VFAVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(videoCapture.Video_Codecs.ToArray(), videoCapture.Audio_Codecs.ToArray());
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                aviOutput.MP3 = new VFMP3Output();
            }
        }

        private void SetWMVOutput(ref VFWMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(videoCapture);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        private void SetMP4Output(ref VFMP4Output mp4Output)
        {
            if (mp4SettingsDialog == null)
            {
                mp4SettingsDialog = new MP4SettingsDialog();
            }

            mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetMP4v11Output(ref VFMP4v11Output mp4Output)
        {
            if (mp4v11SettingsDialog == null)
            {
                mp4v11SettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MP4v11);
            }

            mp4v11SettingsDialog.SaveSettings(ref mp4Output);
        }

        private void SetGIFOutput(ref VFAnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        private void SetMPEGTSOutput(ref VFMPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        private void SetMOVOutput(ref VFMOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new MFSettingsDialog(MFSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        #endregion

        private readonly VideoCapture videoCapture;
        private readonly List<OutputFormatInfo> outputFormats;

        private WeakReference<System.Windows.Window> ownerWindowWeak;

        private MFSettingsDialog mp4v11SettingsDialog;
        private MFSettingsDialog mpegTSSettingsDialog;
        private MFSettingsDialog movSettingsDialog;
        private MP4SettingsDialog mp4SettingsDialog;
        private AVISettingsDialog aviSettingsDialog;
        private WMVSettingsDialog wmvSettingsDialog;
        private GIFSettingsDialog gifSettingsDialog;
    }
}
