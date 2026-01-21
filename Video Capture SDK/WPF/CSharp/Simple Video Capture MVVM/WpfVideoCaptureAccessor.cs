using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.UI.WinForms.Dialogs.OutputFormats;
using VisioForge.Core.UI.WinForms.Dialogs.VideoEffects;
using VisioForge.Core.UI.WPF;
using VisioForge.Core.VideoCapture;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Implementation of IVideoCaptureAccessor for WPF.
    /// </summary>
    public class WpfVideoCaptureAccessor : IVideoCaptureAccessor, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WpfVideoCaptureAccessor"/> class.
        /// </summary>
        public WpfVideoCaptureAccessor()
        {
            videoView = new VideoView();
            this.videoCapture = new VideoCaptureCore(videoView);

            this.videoCapture.OnError += (_s, _e) => this.OnError?.Invoke(this, _e.Message);

            this.outputFormats = new ObservableCollection<OutputFormatInfo>
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

        /// <summary>
        /// Occurs when an error happens.
        /// </summary>
        public event EventHandler<string> OnError;

        /// <summary>
        /// Sets the owner window.
        /// </summary>
        /// <param name="window">The owner window.</param>
        public void SetOwnerWindow(System.Windows.Window window)
        {
            if (window != null)
            {
                this.ownerWindowWeak = new WeakReference<System.Windows.Window>(window);
            }
        }

        /// <summary>
        /// Gets the UI element.
        /// </summary>
        public object UIElement => this.videoView;

        /// <summary>
        /// Gets the SDK version.
        /// </summary>
        public Version SDK_Version => this.videoCapture.SDK_Version();

        /// <summary>
        /// Gets the available video capture devices.
        /// </summary>
        public ObservableCollection<VideoCaptureDeviceInfo> Video_CaptureDevices => this.videoCapture.Video_CaptureDevices();

        /// <summary>
        /// Gets the available audio capture devices.
        /// </summary>
        public ObservableCollection<AudioCaptureDeviceInfo> Audio_CaptureDevices => this.videoCapture.Audio_CaptureDevices();

        /// <summary>
        /// Gets the available audio output devices.
        /// </summary>
        public ObservableCollection<string> Audio_OutputDevices => this.videoCapture.Audio_OutputDevices();

        /// <summary>
        /// Gets the available output formats.
        /// </summary>
        public ObservableCollection<OutputFormatInfo> OutputFormats => new ObservableCollection<OutputFormatInfo>(this.outputFormats);

        /// <summary>
        /// Gets or sets the video capture device.
        /// </summary>
        public VideoCaptureSource Video_CaptureDevice
        {
            get => this.videoCapture.Video_CaptureDevice;
            set => this.videoCapture.Video_CaptureDevice = value;
        }

        /// <summary>
        /// Gets or sets the audio capture device.
        /// </summary>
        public AudioCaptureSource Audio_CaptureDevice
        {
            get => this.videoCapture.Audio_CaptureDevice;
            set => this.videoCapture.Audio_CaptureDevice = value;
        }

        /// <summary>
        /// Sets the volume of the audio output device.
        /// </summary>
        /// <param name="volume">The volume level.</param>
        public void Audio_OutputDevice_Volume_Set(int volume) => this.videoCapture.Audio_OutputDevice_Volume_Set(volume);

        /// <summary>
        /// Sets the balance of the audio output device.
        /// </summary>
        /// <param name="balance">The balance level.</param>
        public void Audio_OutputDevice_Balance_Set(int balance) => this.videoCapture.Audio_OutputDevice_Balance_Set(balance);

        /// <summary>
        /// Displays the configuration dialog for the specified output format.
        /// </summary>
        /// <param name="outputFormatInfoTag">The output format tag.</param>
        public void DisplayConfigureDialog(OutputFormatInfoTag outputFormatInfoTag)
        {
            System.Windows.Window ownerWindow = TryGetOwnerWindow();

            switch (outputFormatInfoTag)
            {
                case OutputFormatInfoTag.AVI:
                    {
                        if (aviSettingsDialog == null)
                        {
                            aviSettingsDialog = new AVISettingsDialog(videoCapture);
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

        /// <summary>
        /// Shows the settings dialog for the specified audio capture device.
        /// </summary>
        /// <param name="deviceName">The name of the device.</param>
        public void Audio_CaptureDevice_SettingsDialog_Show(string deviceName)
        {
            this.videoCapture.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, deviceName);
        }

        /// <summary>
        /// Shows the settings dialog for the specified video capture device.
        /// </summary>
        /// <param name="deviceName">The name of the device.</param>
        public void Video_CaptureDevice_SettingsDialog_Show(string deviceName)
        {
            this.videoCapture.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, deviceName);
        }

        /// <summary>
        /// Adds an image logo effect.
        /// </summary>
        /// <returns>The added video effect.</returns>
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
        /// <summary>
        /// Adds a text logo effect.
        /// </summary>
        /// <returns>The added video effect.</returns>
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

        /// <summary>
        /// Edits the specified video effect.
        /// </summary>
        /// <param name="effect">The video effect to edit.</param>
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

        /// <summary>
        /// Removes the specified video effect.
        /// </summary>
        /// <param name="effect">The video effect to remove.</param>
        public void RemoveEffect(IVideoEffect effect)
        {
            this.videoCapture.Video_Effects_Remove(effect.Name);
        }

        /// <summary>
        /// Sets the enabled state of a video effect.
        /// </summary>
        /// <param name="name">The name of the effect.</param>
        /// <param name="state">The enabled state.</param>
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

        /// <summary>
        /// Sets the value of a video effect.
        /// </summary>
        /// <param name="name">The name of the effect.</param>
        /// <param name="value">The value to set.</param>
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

        /// <summary>
        /// Starts the video capture asynchronously.
        /// </summary>
        /// <param name="startParams">The start parameters.</param>
        /// <returns>The task.</returns>
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

            videoCapture.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;

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

        /// <summary>
        /// Pauses the video capture asynchronously.
        /// </summary>
        /// <returns>The task.</returns>
        public Task<bool> PauseAsync()
        {
            return this.videoCapture.PauseAsync();
        }

        /// <summary>
        /// Resumes the video capture asynchronously.
        /// </summary>
        /// <returns>The task.</returns>
        public Task<bool> ResumeAsync()
        {
            return this.videoCapture.ResumeAsync();
        }

        /// <summary>
        /// Stops the video capture asynchronously.
        /// </summary>
        /// <returns>The task.</returns>
        public Task StopAsync()
        {
            return this.videoCapture.StopAsync();
        }

        /// <summary>
        /// Gets the duration of the current video capture.
        /// </summary>
        /// <returns>The duration time.</returns>
        public TimeSpan Duration_Time() => this.videoCapture.Duration_Time();

        /// <summary>
        /// Saves a screenshot asynchronously.
        /// </summary>
        /// <param name="fileName">The file name.</param>
        /// <returns>The task.</returns>
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

        /// <summary>
        /// Set avi output.
        /// </summary>
        /// <param name="aviOutput">The avi output.</param>
        private void SetAVIOutput(ref AVIOutput aviOutput)
        {
            if (aviSettingsDialog == null)
            {
                aviSettingsDialog = new AVISettingsDialog(videoCapture);
            }

            aviSettingsDialog.SaveSettings(ref aviOutput);

            if (aviOutput.Audio_UseMP3Encoder)
            {
                aviOutput.MP3 = new MP3Output();
            }
        }

        /// <summary>
        /// Set wmv output.
        /// </summary>
        /// <param name="wmvOutput">The wmv output.</param>
        private void SetWMVOutput(ref WMVOutput wmvOutput)
        {
            if (wmvSettingsDialog == null)
            {
                wmvSettingsDialog = new WMVSettingsDialog(videoCapture);
            }

            wmvSettingsDialog.WMA = false;
            wmvSettingsDialog.SaveSettings(ref wmvOutput);
        }

        /// <summary>
        /// Set mp 4 output.
        /// </summary>
        /// <param name="mp4Output">The mp4 output.</param>
        private void SetMP4Output(ref MP4Output mp4Output)
        {
            if (mp4SettingsDialog == null)
            {
                mp4SettingsDialog = new MP4SettingsDialog();
            }

            mp4SettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set mp 4 hw output.
        /// </summary>
        /// <param name="mp4Output">The mp4 output.</param>
        private void SetMP4HWOutput(ref MP4HWOutput mp4Output)
        {
            if (mp4HWSettingsDialog == null)
            {
                mp4HWSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MP4);
            }

            mp4HWSettingsDialog.SaveSettings(ref mp4Output);
        }

        /// <summary>
        /// Set gif output.
        /// </summary>
        /// <param name="gifOutput">The gif output.</param>
        private void SetGIFOutput(ref AnimatedGIFOutput gifOutput)
        {
            if (gifSettingsDialog == null)
            {
                gifSettingsDialog = new GIFSettingsDialog();
            }

            gifSettingsDialog.SaveSettings(ref gifOutput);
        }

        /// <summary>
        /// Set mpegts output.
        /// </summary>
        /// <param name="mpegTSOutput">The mpeg ts output.</param>
        private void SetMPEGTSOutput(ref MPEGTSOutput mpegTSOutput)
        {
            if (mpegTSSettingsDialog == null)
            {
                mpegTSSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MPEGTS);
            }

            mpegTSSettingsDialog.SaveSettings(ref mpegTSOutput);
        }

        /// <summary>
        /// Set mov output.
        /// </summary>
        /// <param name="mkvOutput">The mkv output.</param>
        private void SetMOVOutput(ref MOVOutput mkvOutput)
        {
            if (movSettingsDialog == null)
            {
                movSettingsDialog = new HWEncodersOutputSettingsDialog(HWSettingsDialogMode.MOV);
            }

            movSettingsDialog.SaveSettings(ref mkvOutput);
        }

        #endregion

        /// <summary>
        /// The video capture.
        /// </summary>
        private VideoCaptureCore videoCapture;

        /// <summary>
        /// The video view.
        /// </summary>
        private VideoView videoView;

        /// <summary>
        /// The output formats.
        /// </summary>
        private readonly ObservableCollection<OutputFormatInfo> outputFormats;

        /// <summary>
        /// The owner window weak reference.
        /// </summary>
        private WeakReference<System.Windows.Window> ownerWindowWeak;

        /// <summary>
        /// The MP4 hardware encoder output settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mp4HWSettingsDialog;

        /// <summary>
        /// The MPEG-TS output settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog mpegTSSettingsDialog;

        /// <summary>
        /// The MOV output settings dialog.
        /// </summary>
        private HWEncodersOutputSettingsDialog movSettingsDialog;

        /// <summary>
        /// The MP4 output settings dialog.
        /// </summary>
        private MP4SettingsDialog mp4SettingsDialog;

        /// <summary>
        /// The AVI output settings dialog.
        /// </summary>
        private AVISettingsDialog aviSettingsDialog;

        /// <summary>
        /// The WMV output settings dialog.
        /// </summary>
        private WMVSettingsDialog wmvSettingsDialog;

        /// <summary>
        /// The GIF output settings dialog.
        /// </summary>
        private GIFSettingsDialog gifSettingsDialog;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                videoCapture.Dispose();
                videoCapture = null;

                videoView.Dispose();
                videoView = null;

                aviSettingsDialog.Dispose();
                aviSettingsDialog = null;

                mp4HWSettingsDialog.Dispose();
                mp4HWSettingsDialog = null;

                mp4SettingsDialog.Dispose();
                mp4SettingsDialog = null;

                movSettingsDialog.Dispose();
                movSettingsDialog = null;

                mpegTSSettingsDialog.Dispose();
                mpegTSSettingsDialog = null;

                gifSettingsDialog.Dispose();
                gifSettingsDialog = null;

                wmvSettingsDialog.Dispose();
                wmvSettingsDialog = null;





                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="WpfVideoCaptureAccessor"/> class.
        /// </summary>
        ~WpfVideoCaptureAccessor()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
