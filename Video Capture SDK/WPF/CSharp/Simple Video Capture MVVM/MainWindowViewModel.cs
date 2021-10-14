using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using VisioForge.Controls.UI;
using VisioForge.Tools;
using VisioForge.Types;
using VisioForge.Types.VideoEffects;

namespace Simple_Video_Capture
{
    public class MainWindowViewModel
        : BindableBase
    {
        public MainWindowViewModel(IVideoCaptureAccessor videoCaptureAccessor)
        {
            this.videoCaptureAccessor = videoCaptureAccessor;
            this.videoCaptureAccessor.OnError += VideoCaptureAccessorOnError;

            Title = "Simple Video Capture Demo - Video Capture SDK .Net" +
                " (SDK v" + videoCaptureAccessor.SDK_Version + ")";

            SelectedVideoInputDevice = VideoInputDevices.FirstOrDefault();
            SelectedAudioInputDevice = AudioInputDevices.FirstOrDefault();
            SelectedAudioOutputDevice =
                AudioOutputDevices.FirstOrDefault(_ => _.Contains("Default DirectSound Device")) ??
                AudioOutputDevices.FirstOrDefault();

            RecordAudio = true;

            MinVolumeValue = 20;
            MaxVolumeValue = 100;
            CurrentVolumeValue = 80;

            MinBalanceValue = -100;
            MaxBalanceValue = 100;
            CurrentBalanceValue = 0;

            ConfigureAudioInputDeviceCommand = new DelegateCommand(ConfigureAudioInputDevice);
            ConfigureVideoInputDeviceCommand = new DelegateCommand(ConfigureVideoInputDevice);

            OutputFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
            SelectedOutputFormat =
                OutputFormats.FirstOrDefault(_ => _.Description == "MP4") ??
                OutputFormats.FirstOrDefault();
            BrowseForOutputFileCommand = new DelegateCommand(BrowseForOutputFile);
            ConfigureOutputFormatCommand = new DelegateCommand(ConfigureOutputFormat);

            MinLightnessValue = 0;
            MaxLightnessValue = 255;
            CurrentLightnessValue = 0;

            MinSaturationValue = 0;
            MaxSaturationValue = 255;
            CurrentSaturationValue = 255;

            MinContrastValue = 0;
            MaxContrastValue = 255;
            CurrentContrastValue = 0;

            MinDarknessValue = 0;
            MaxDarknessValue = 255;
            CurrentContrastValue = 0;

            AddImageLogoCommand = new DelegateCommand(AddImageLogo);
            AddTextLogoCommand = new DelegateCommand(AddTextLogo);
            EditLogoCommand = new DelegateCommand(EditLogo, CanEditLogo);
            RemoveLogoCommand = new DelegateCommand(RemoveLogo, CanRemoveLogo);

            PreviewMode = true;
            RecordingTimeText = "Recording time: 00:00:00";
            StartCommand = new DelegateCommand(Start);
            StopCommand = new DelegateCommand(Stop);
            PauseCommand = new DelegateCommand(Pause);
            ResumeCommand = new DelegateCommand(Resume);
            SaveSnapshotCommand = new DelegateCommand(SaveSnapshot);
            ViewVideoTutorialsCommand = new DelegateCommand(ViewVideoTutorials);

            tmRecording.Interval = TimeSpan.FromSeconds(1);
            tmRecording.Tick += (senderx, args) => { UpdateRecordingTime(); };
        }

        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

        #region Devices Tab

        public List<VideoCaptureDeviceInfo> VideoInputDevices => videoCaptureAccessor.Video_CaptureDevicesInfo;

        public VideoCaptureDeviceInfo SelectedVideoInputDevice
        {
            get => this.selectedVideoInputDevice;
            set
            {
                if (SetProperty(ref this.selectedVideoInputDevice, value))
                {
                    this.videoCaptureAccessor.Video_CaptureDevice = SelectedVideoInputDevice.Name;
                    SelectedVideoFormat = SelectedVideoInputDevice?.VideoFormats.FirstOrDefault();
                    UseAudioInputFromVideoSource = false;
                }
            }
        }

        public VideoCaptureDeviceFormat SelectedVideoFormat
        {
            get => this.selectedVideoFormat;
            set
            {
                if (SetProperty(ref this.selectedVideoFormat, value))
                {
                    SelectedFrameRate = SelectedVideoFormat?.FrameRates.FirstOrDefault();
                }
            }
        }

        public double? SelectedFrameRate
        {
            get => this.selectedFrameRate;
            set => SetProperty(ref this.selectedFrameRate, value);
        }

        public List<AudioCaptureDeviceInfo> AudioInputDevices => videoCaptureAccessor.Audio_CaptureDevicesInfo;

        public AudioCaptureDeviceInfo SelectedAudioInputDevice
        {
            get => this.selectedAudioInputDevice;
            set
            {
                if (SetProperty(ref this.selectedAudioInputDevice, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice = SelectedAudioInputDevice.Name;

                    SelectedAudioInputFormat =
                        SelectedAudioInputDevice.Formats.FirstOrDefault(_ => _ == "PCM, 44100 Hz, 16 Bits, 2 Channels") ??
                        SelectedAudioInputDevice.Formats.FirstOrDefault();

                    SelectedAudioInputLine = SelectedAudioInputDevice.Lines.FirstOrDefault();

                    RaisePropertyChanged(nameof(CanConfigureAudioInputDevice));
                }
            }
        }

        public string SelectedAudioInputFormat
        {
            get => this.selectedAudioInputFormat;
            set
            {
                if (SetProperty(ref this.selectedAudioInputFormat, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice_Format = this.selectedAudioInputFormat;
                }
            }
        }

        public string SelectedAudioInputLine
        {
            get => this.selectedAudioInputLine;
            set
            {
                if (SetProperty(ref this.selectedAudioInputLine, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice_Line = this.selectedAudioInputLine;
                }
            }
        }

        public List<string> AudioOutputDevices => this.videoCaptureAccessor.Audio_OutputDevices;

        public string SelectedAudioOutputDevice
        {
            get => this.selectedAudioOutputDevice;
            set => SetProperty(ref this.selectedAudioOutputDevice, value);
        }

        public bool UseAudioInputFromVideoSource
        {
            get => this.useAudioInputFromVideoSource;
            set
            {
                if (SetProperty(ref this.useAudioInputFromVideoSource, value))
                {
                    this.videoCaptureAccessor.Video_CaptureDevice_IsAudioSource = this.useAudioInputFromVideoSource;
                    RaisePropertyChanged(nameof(CanConfigureAudioInputDevice));
                }
            }
        }

        public bool CanConfigureAudioInputDevice
        {
            get => !UseAudioInputFromVideoSource && SelectedAudioInputDevice?.DialogDefault == true;
        }

        public bool UseBestVideoInputFormat
        {
            get => this.useBestVideoInputFormat;
            set => SetProperty(ref this.useBestVideoInputFormat, value);
        }

        public bool UseBestAudioInputFormat
        {
            get => this.useBestAudioInputFormat;
            set => SetProperty(ref this.useBestAudioInputFormat, value);
        }

        public bool RecordAudio
        {
            get => this.recordAudio;
            set => SetProperty(ref this.recordAudio, value);
        }

        public double MinVolumeValue
        {
            get => this.minVolumeValue;
            set => SetProperty(ref this.minVolumeValue, value);
        }

        public double MaxVolumeValue
        {
            get => this.maxVolumeValue;
            set => SetProperty(ref this.maxVolumeValue, value);
        }

        public double CurrentVolumeValue
        {
            get => this.curVolumeValue;
            set
            {
                if (SetProperty(ref this.curVolumeValue, value))
                {
                    this.videoCaptureAccessor.Audio_OutputDevice_Volume_Set((int)CurrentVolumeValue);
                }
            }
        }

        public double MinBalanceValue
        {
            get => this.minBalanceValue;
            set => SetProperty(ref this.minBalanceValue, value);
        }

        public double MaxBalanceValue
        {
            get => this.maxBalanceValue;
            set => SetProperty(ref this.maxBalanceValue, value);
        }

        public double CurrentBalanceValue
        {
            get => this.curBalanceValue;
            set
            {
                if (SetProperty(ref this.curBalanceValue, value))
                {
                    this.videoCaptureAccessor.Audio_OutputDevice_Balance_Set((int)CurrentBalanceValue);
                }
            }
        }

        public DelegateCommand ConfigureVideoInputDeviceCommand { get; }

        public DelegateCommand ConfigureAudioInputDeviceCommand { get; }

        #endregion

        #region Output tab

        public DelegateCommand BrowseForOutputFileCommand { get; }
        
        public DelegateCommand ConfigureOutputFormatCommand { get; }

        public List<OutputFormatInfo> OutputFormats => this.videoCaptureAccessor.OutputFormats;

        public OutputFormatInfo SelectedOutputFormat
        {
            get => this.selectedOutputFormat;
            set
            {
                if (SetProperty(ref this.selectedOutputFormat, value))
                {
                    OutputFileName = FilenameHelper.ChangeFileExt(OutputFileName, SelectedOutputFormat.Extension);
                }
            }
        }

        public string OutputFileName
        {
            get => this.outputFileName;
            set => SetProperty(ref this.outputFileName, value);
        }

        #endregion

        #region Video Effects Tab

        public ObservableCollection<IVFVideoEffect> Logos { get; } = new ObservableCollection<IVFVideoEffect>();

        public IVFVideoEffect SelectedLogo
        {
            get => this.selectedLogo;
            set
            {
                if (SetProperty(ref this.selectedLogo, value))
                {
                    EditLogoCommand.RaiseCanExecuteChanged();
                    RemoveLogoCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool MergeImageLogos
        {
            get => this.mergeImageLogos;
            set => SetProperty(ref this.mergeImageLogos, value);
        }

        public bool MergeTextLogos
        {
            get => this.mergeTextLogos;
            set => SetProperty(ref this.mergeTextLogos, value);
        }

        public bool GrayscaleEffectEnabled
        {
            get => this.grayscaleEffectEnabled;
            set
            {
                if (SetProperty(ref this.grayscaleEffectEnabled, value))
                {
                    SetGrayscaleEffectEnabledState();
                }
            }
        }

        public bool InvertEffectEnabled
        {
            get => this.invertEffectEnabled;
            set
            {
                if (SetProperty(ref this.invertEffectEnabled, value))
                {
                    SetInvertEffectEnabledState();
                }
            }
        }

        public bool FlipXEffectEnabled
        {
            get => this.flipXEffectEnabled;
            set
            {
                if (SetProperty(ref this.flipXEffectEnabled, value))
                {
                    SetFlipXEffectEnabledState();
                }
            }
        }

        public bool FlipYEffectEnabled
        {
            get => this.flipYEffectEnabled;
            set
            {
                if (SetProperty(ref this.flipYEffectEnabled, value))
                {
                    SetFlipYEffectEnabledState();
                }
            }
        }

        public double MinLightnessValue
        {
            get => this.minLightnessValue;
            set => SetProperty(ref this.minLightnessValue, value);
        }

        public double MaxLightnessValue
        {
            get => this.maxLightnessValue;
            set => SetProperty(ref this.maxLightnessValue, value);
        }

        public double CurrentLightnessValue
        {
            get => this.curLightnessValue;
            set
            {
                if (SetProperty(ref this.curLightnessValue, value))
                {
                    SetLightnessEffectValue();
                }
            }
        }

        public double MinDarknessValue
        {
            get => this.minDarknessValue;
            set => SetProperty(ref this.minDarknessValue, value);
        }

        public double MaxDarknessValue
        {
            get => this.maxDarknessValue;
            set => SetProperty(ref this.maxDarknessValue, value);
        }

        public double CurrentDarknessValue
        {
            get => this.curDarknessValue;
            set
            {
                if (SetProperty(ref this.curDarknessValue, value))
                {
                    SetDarknessEffectValue();
                }
            }
        }

        public double MinContrastValue
        {
            get => this.minContrastValue;
            set => SetProperty(ref this.minContrastValue, value);
        }

        public double MaxContrastValue
        {
            get => this.maxContrastValue;
            set => SetProperty(ref this.maxContrastValue, value);
        }

        public double CurrentContrastValue
        {
            get => this.curContrastValue;
            set
            {
                if (SetProperty(ref this.curContrastValue, value))
                {
                    SetContrastEffectValue();
                }
            }
        }

        public double MinSaturationValue
        {
            get => this.minSaturationValue;
            set => SetProperty(ref this.minSaturationValue, value);
        }

        public double MaxSaturationValue
        {
            get => this.maxSaturationValue;
            set => SetProperty(ref this.maxSaturationValue, value);
        }

        public double CurrentSaturationValue
        {
            get => this.curSaturationValue;
            set
            {
                if (SetProperty(ref this.curSaturationValue, value))
                {
                    SetSaturationEffectValue();
                }
            }
        }

        public DelegateCommand AddImageLogoCommand { get; }
        public DelegateCommand AddTextLogoCommand { get; }
        public DelegateCommand EditLogoCommand { get; }
        public DelegateCommand RemoveLogoCommand { get; }

        #endregion

        #region Log Tab

        public bool DebugMode
        {
            get => this.debugMode;
            set => SetProperty(ref this.debugMode, value);
        }

        public string Log
        {
            get => this.log;
            set => SetProperty(ref this.log, value);
        }

        #endregion

        #region Common

        public bool PreviewMode
        {
            get => this.previewMode;
            set => SetProperty(ref this.previewMode, value);
        }

        public string RecordingTimeText
        {
            get => this.recordingTimeText;
            set => SetProperty(ref this.recordingTimeText, value);
        }

        public int SelectedContentIndex
        {
            get => this.selectedContentIndex;
            set => SetProperty(ref this.selectedContentIndex, value);
        }

        public DelegateCommand StartCommand { get; }
        public DelegateCommand StopCommand { get; }
        public DelegateCommand PauseCommand { get; }
        public DelegateCommand ResumeCommand { get; }
        public DelegateCommand SaveSnapshotCommand { get; }
        public DelegateCommand ViewVideoTutorialsCommand { get; }

        #endregion

        #region Implementation

        private void ConfigureAudioInputDevice()
        {
            this.videoCaptureAccessor.Audio_CaptureDevice_SettingsDialog_Show(SelectedAudioInputDevice.Name);
        }

        private void ConfigureVideoInputDevice()
        {
            this.videoCaptureAccessor.Video_CaptureDevice_SettingsDialog_Show(SelectedVideoInputDevice.Name);
        }

        private void BrowseForOutputFile()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".jpg; *.bmp; *.gif;",
                Filter = "Images|*.jpg; *.bmp; *.gif;"
            };

            if (dlg.ShowDialog() == true)
            {
                OutputFileName = dlg.FileName;
            }
        }

        private void ConfigureOutputFormat()
        {
            this.videoCaptureAccessor.DisplayConfigureDialog(SelectedOutputFormat.Tag);
        }

        private void ViewVideoTutorials()
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void VideoCaptureAccessorOnError(object sender, string message)
        {
            Log += (message + Environment.NewLine);
        }

        private void AddImageLogo()
        {
            var logoEffect = this.videoCaptureAccessor.AddImageLogoEffect();
            if (logoEffect != null)
            {
                Logos.Add(logoEffect);
            }
        }

        private void AddTextLogo()
        {
            var logoEffect = this.videoCaptureAccessor.AddTextLogoEffect();
            if (logoEffect != null)
            {
                Logos.Add(logoEffect);
            }
        }

        private bool CanEditLogo()
        {
            return SelectedLogo != null;
        }

        private void EditLogo()
        {
            this.videoCaptureAccessor.EditEffect(SelectedLogo);
        }

        private bool CanRemoveLogo()
        {
            return SelectedLogo != null;
        }

        private void RemoveLogo()
        {
            this.videoCaptureAccessor.RemoveEffect(SelectedLogo);
            Logos.Remove(SelectedLogo);
        }

        private async void Start()
        {
            Log = string.Empty;

            if (CurrentLightnessValue > 0)
            {
                SetLightnessEffectValue();
            }

            if (CurrentSaturationValue < 255)
            {
                SetSaturationEffectValue();
            }

            if (CurrentContrastValue > 0)
            {
                SetContrastEffectValue();
            }

            if (CurrentDarknessValue > 0)
            {
                SetDarknessEffectValue();
            }

            if (GrayscaleEffectEnabled)
            {
                SetGrayscaleEffectEnabledState();
            }

            if (InvertEffectEnabled)
            {
                SetInvertEffectEnabledState();
            }

            if (FlipXEffectEnabled)
            {
                SetFlipXEffectEnabledState();
            }

            if (FlipYEffectEnabled)
            {
                SetFlipYEffectEnabledState();
            }

            VideoCaptureStartParams startParams = new VideoCaptureStartParams
            {
                DebugMode = this.DebugMode,
                DebugDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge"),
                RecordAudio = this.RecordAudio,
                VideoCaptureDevice = SelectedVideoInputDevice.Name,
                VideoCaptureDeviceIsAudioSource = UseAudioInputFromVideoSource,
                VideoCaptureFormat = SelectedVideoFormat.Name,
                VideoCaptureFormatUseBest = UseBestVideoInputFormat,
                AudioCaptureDevice = SelectedAudioInputDevice.Name,
                AudioCaptureDeviceFormat = SelectedAudioInputFormat,
                AudioCaptureDeviceFormatUseBest = UseBestAudioInputFormat,
                AudioOutputDevice = SelectedAudioOutputDevice,
                VideoFrameRate = SelectedFrameRate.GetValueOrDefault(0),
                Preview = this.PreviewMode,
                OutputFileName = this.OutputFileName,
                OutputFormat = SelectedOutputFormat.Tag,
                MergeImageLogos = this.MergeImageLogos,
                MergeTextLogos = this.MergeTextLogos,
            };

            Logos.Clear();

            await this.videoCaptureAccessor.StartAsync(startParams);

            tmRecording.Start();
            SelectedContentIndex = 3;
        }

        private async void Stop()
        {
            tmRecording.Stop();
            await this.videoCaptureAccessor.StopAsync();
        }

        private async void Pause()
        {
            await this.videoCaptureAccessor.PauseAsync();
        }

        private async void Resume()
        {
            await this.videoCaptureAccessor.ResumeAsync();
        }

        private async void SaveSnapshot()
        {
            var screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "image.jpg",
                Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
            };

            if (screenshotSaveDialog.ShowDialog() == true)
            {
                await  this.videoCaptureAccessor.SaveScreenshotAsync(screenshotSaveDialog.FileName);
            }
        }

        private void SetGrayscaleEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("Grayscale", GrayscaleEffectEnabled);
        }

        private void SetInvertEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("Invert", InvertEffectEnabled);
        }

        private void SetFlipXEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("FlipDown", FlipXEffectEnabled);
        }

        private void SetFlipYEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("FlipRight", FlipYEffectEnabled);
        }

        private void SetLightnessEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Lightness", (int)CurrentLightnessValue);
        }

        private void SetDarknessEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Darkness", (int)CurrentDarknessValue);
        }

        private void SetContrastEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Contrast", (int)CurrentContrastValue);
        }

        private void SetSaturationEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Saturation", (int)CurrentSaturationValue);
        }

        private void UpdateRecordingTime()
        {
            var ts = this.videoCaptureAccessor.Duration_Time();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            RecordingTimeText = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
        }

        #endregion

        private readonly IVideoCaptureAccessor videoCaptureAccessor;
        private readonly DispatcherTimer tmRecording = new DispatcherTimer();

        private string title;
        private VideoCaptureDeviceInfo selectedVideoInputDevice;
        private VideoCaptureDeviceFormat selectedVideoFormat;
        private double? selectedFrameRate;
        private AudioCaptureDeviceInfo selectedAudioInputDevice;
        private string selectedAudioInputFormat;
        private string selectedAudioInputLine;
        private string selectedAudioOutputDevice;
        private bool useAudioInputFromVideoSource;
        private bool useBestVideoInputFormat;
        private bool useBestAudioInputFormat;
        private bool recordAudio;
        private double minVolumeValue;
        private double maxVolumeValue;
        private double curVolumeValue;
        private double minBalanceValue;
        private double maxBalanceValue;
        private double curBalanceValue;

        private OutputFormatInfo selectedOutputFormat;
        private string outputFileName;

        private IVFVideoEffect selectedLogo;
        private bool mergeImageLogos;
        private bool mergeTextLogos;
        private bool grayscaleEffectEnabled;
        private bool invertEffectEnabled;
        private bool flipXEffectEnabled;
        private bool flipYEffectEnabled;
        private double minLightnessValue;
        private double maxLightnessValue;
        private double curLightnessValue;
        private double minDarknessValue;
        private double maxDarknessValue;
        private double curDarknessValue;
        private double minSaturationValue;
        private double maxSaturationValue;
        private double curSaturationValue;
        private double minContrastValue;
        private double maxContrastValue;
        private double curContrastValue;

        private bool debugMode;
        private string log;

        private bool previewMode;
        private string recordingTimeText;
        private int selectedContentIndex;
    }
}
