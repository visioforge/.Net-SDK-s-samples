using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.UI;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    public class MainWindowViewModel
        : BindableBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="videoCaptureAccessor">The video capture accessor.</param>
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

            OutputFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
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

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

        #region Devices Tab

        /// <summary>
        /// Gets the video input devices.
        /// </summary>
        public ObservableCollection<VideoCaptureDeviceInfo> VideoInputDevices => videoCaptureAccessor.Video_CaptureDevices;

        /// <summary>
        /// Gets or sets the selected video input device.
        /// </summary>
        public VideoCaptureDeviceInfo SelectedVideoInputDevice
        {
            get => this.selectedVideoInputDevice;
            set
            {
                if (SetProperty(ref this.selectedVideoInputDevice, value))
                {
                    if (SelectedVideoInputDevice != null)
                    {
                        this.videoCaptureAccessor.Video_CaptureDevice = new VideoCaptureSource(SelectedVideoInputDevice.Name);
                        SelectedVideoFormat = SelectedVideoInputDevice.VideoFormats.FirstOrDefault();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected video format.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the selected frame rate.
        /// </summary>
        public VideoFrameRate? SelectedFrameRate
        {
            get => this.selectedFrameRate;
            set => SetProperty(ref this.selectedFrameRate, value);
        }

        /// <summary>
        /// Gets the audio input devices.
        /// </summary>
        public ObservableCollection<AudioCaptureDeviceInfo> AudioInputDevices => videoCaptureAccessor.Audio_CaptureDevices;

        /// <summary>
        /// Gets or sets the selected audio input device.
        /// </summary>
        public AudioCaptureDeviceInfo SelectedAudioInputDevice
        {
            get => this.selectedAudioInputDevice;
            set
            {
                if (SetProperty(ref this.selectedAudioInputDevice, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice = new AudioCaptureSource(SelectedAudioInputDevice.Name);

                    SelectedAudioInputFormat =
                        SelectedAudioInputDevice.Formats.Find(_ => _ == "PCM, 44100 Hz, 16 Bits, 2 Channels") ??
                        SelectedAudioInputDevice.Formats.FirstOrDefault();

                    SelectedAudioInputLine = SelectedAudioInputDevice.Lines.FirstOrDefault();

                    RaisePropertyChanged(nameof(CanConfigureAudioInputDevice));
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected audio input format.
        /// </summary>
        public string SelectedAudioInputFormat
        {
            get => this.selectedAudioInputFormat;
            set
            {
                if (SetProperty(ref this.selectedAudioInputFormat, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice.Format = this.selectedAudioInputFormat;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected audio input line.
        /// </summary>
        public string SelectedAudioInputLine
        {
            get => this.selectedAudioInputLine;
            set
            {
                if (SetProperty(ref this.selectedAudioInputLine, value))
                {
                    this.videoCaptureAccessor.Audio_CaptureDevice.Line = this.selectedAudioInputLine;
                }
            }
        }

        /// <summary>
        /// Gets the audio output devices.
        /// </summary>
        public ObservableCollection<string> AudioOutputDevices => this.videoCaptureAccessor.Audio_OutputDevices;

        /// <summary>
        /// Gets or sets the selected audio output device.
        /// </summary>
        public string SelectedAudioOutputDevice
        {
            get => this.selectedAudioOutputDevice;
            set => SetProperty(ref this.selectedAudioOutputDevice, value);
        }

        /// <summary>
        /// Gets a value indicating whether the audio input device can be configured.
        /// </summary>
        public bool CanConfigureAudioInputDevice
        {
            get => SelectedAudioInputDevice?.DialogDefault == true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the best video input format.
        /// </summary>
        public bool UseBestVideoInputFormat
        {
            get => this.useBestVideoInputFormat;
            set => SetProperty(ref this.useBestVideoInputFormat, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the best audio input format.
        /// </summary>
        public bool UseBestAudioInputFormat
        {
            get => this.useBestAudioInputFormat;
            set => SetProperty(ref this.useBestAudioInputFormat, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to record audio.
        /// </summary>
        public bool RecordAudio
        {
            get => this.recordAudio;
            set => SetProperty(ref this.recordAudio, value);
        }

        /// <summary>
        /// Gets or sets the minimum volume value.
        /// </summary>
        public double MinVolumeValue
        {
            get => this.minVolumeValue;
            set => SetProperty(ref this.minVolumeValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum volume value.
        /// </summary>
        public double MaxVolumeValue
        {
            get => this.maxVolumeValue;
            set => SetProperty(ref this.maxVolumeValue, value);
        }

        /// <summary>
        /// Gets or sets the current volume value.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum balance value.
        /// </summary>
        public double MinBalanceValue
        {
            get => this.minBalanceValue;
            set => SetProperty(ref this.minBalanceValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum balance value.
        /// </summary>
        public double MaxBalanceValue
        {
            get => this.maxBalanceValue;
            set => SetProperty(ref this.maxBalanceValue, value);
        }

        /// <summary>
        /// Gets or sets the current balance value.
        /// </summary>
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

        /// <summary>
        /// Gets the command to configure the video input device.
        /// </summary>
        public DelegateCommand ConfigureVideoInputDeviceCommand { get; }

        /// <summary>
        /// Gets the command to configure the audio input device.
        /// </summary>
        public DelegateCommand ConfigureAudioInputDeviceCommand { get; }

        #endregion

        #region Output tab

        /// <summary>
        /// Gets the command to browse for the output file.
        /// </summary>
        public DelegateCommand BrowseForOutputFileCommand { get; }

        /// <summary>
        /// Gets the command to configure the output format.
        /// </summary>
        public DelegateCommand ConfigureOutputFormatCommand { get; }

        /// <summary>
        /// Gets the output formats.
        /// </summary>
        public ObservableCollection<OutputFormatInfo> OutputFormats => this.videoCaptureAccessor.OutputFormats;

        /// <summary>
        /// Gets or sets the selected output format.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the output file name.
        /// </summary>
        public string OutputFileName
        {
            get => this.outputFileName;
            set => SetProperty(ref this.outputFileName, value);
        }

        #endregion

        #region Video Effects Tab

        /// <summary>
        /// Gets the logos.
        /// </summary>
        public ObservableCollection<IVideoEffect> Logos { get; } = new ObservableCollection<IVideoEffect>();

        /// <summary>
        /// Gets or sets the selected logo.
        /// </summary>
        public IVideoEffect SelectedLogo
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

        /// <summary>
        /// Gets or sets a value indicating whether to merge image logos.
        /// </summary>
        public bool MergeImageLogos
        {
            get => this.mergeImageLogos;
            set => SetProperty(ref this.mergeImageLogos, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether to merge text logos.
        /// </summary>
        public bool MergeTextLogos
        {
            get => this.mergeTextLogos;
            set => SetProperty(ref this.mergeTextLogos, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the grayscale effect is enabled.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the invert effect is enabled.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the flip X effect is enabled.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a value indicating whether the flip Y effect is enabled.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum lightness value.
        /// </summary>
        public double MinLightnessValue
        {
            get => this.minLightnessValue;
            set => SetProperty(ref this.minLightnessValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum lightness value.
        /// </summary>
        public double MaxLightnessValue
        {
            get => this.maxLightnessValue;
            set => SetProperty(ref this.maxLightnessValue, value);
        }

        /// <summary>
        /// Gets or sets the current lightness value.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum darkness value.
        /// </summary>
        public double MinDarknessValue
        {
            get => this.minDarknessValue;
            set => SetProperty(ref this.minDarknessValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum darkness value.
        /// </summary>
        public double MaxDarknessValue
        {
            get => this.maxDarknessValue;
            set => SetProperty(ref this.maxDarknessValue, value);
        }

        /// <summary>
        /// Gets or sets the current darkness value.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum contrast value.
        /// </summary>
        public double MinContrastValue
        {
            get => this.minContrastValue;
            set => SetProperty(ref this.minContrastValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum contrast value.
        /// </summary>
        public double MaxContrastValue
        {
            get => this.maxContrastValue;
            set => SetProperty(ref this.maxContrastValue, value);
        }

        /// <summary>
        /// Gets or sets the current contrast value.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum saturation value.
        /// </summary>
        public double MinSaturationValue
        {
            get => this.minSaturationValue;
            set => SetProperty(ref this.minSaturationValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum saturation value.
        /// </summary>
        public double MaxSaturationValue
        {
            get => this.maxSaturationValue;
            set => SetProperty(ref this.maxSaturationValue, value);
        }

        /// <summary>
        /// Gets or sets the current saturation value.
        /// </summary>
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

        /// <summary>
        /// Gets the command to add an image logo.
        /// </summary>
        public DelegateCommand AddImageLogoCommand { get; }
        /// <summary>
        /// Gets the command to add a text logo.
        /// </summary>
        public DelegateCommand AddTextLogoCommand { get; }
        /// <summary>
        /// Gets the command to edit the logo.
        /// </summary>
        public DelegateCommand EditLogoCommand { get; }
        /// <summary>
        /// Gets the command to remove the logo.
        /// </summary>
        public DelegateCommand RemoveLogoCommand { get; }

        #endregion

        #region Log Tab

        /// <summary>
        /// Gets or sets a value indicating whether debug mode is enabled.
        /// </summary>
        public bool DebugMode
        {
            get => this.debugMode;
            set => SetProperty(ref this.debugMode, value);
        }

        /// <summary>
        /// Gets or sets the log.
        /// </summary>
        public string Log
        {
            get => this.log;
            set => SetProperty(ref this.log, value);
        }

        #endregion

        #region Common

        /// <summary>
        /// Gets or sets a value indicating whether preview mode is enabled.
        /// </summary>
        public bool PreviewMode
        {
            get => this.previewMode;
            set => SetProperty(ref this.previewMode, value);
        }

        /// <summary>
        /// Gets or sets the recording time text.
        /// </summary>
        public string RecordingTimeText
        {
            get => this.recordingTimeText;
            set => SetProperty(ref this.recordingTimeText, value);
        }

        /// <summary>
        /// Gets or sets the selected content index.
        /// </summary>
        public int SelectedContentIndex
        {
            get => this.selectedContentIndex;
            set => SetProperty(ref this.selectedContentIndex, value);
        }

        /// <summary>
        /// Gets the start command.
        /// </summary>
        public DelegateCommand StartCommand { get; }
        /// <summary>
        /// Gets the stop command.
        /// </summary>
        public DelegateCommand StopCommand { get; }
        /// <summary>
        /// Gets the pause command.
        /// </summary>
        public DelegateCommand PauseCommand { get; }
        /// <summary>
        /// Gets the resume command.
        /// </summary>
        public DelegateCommand ResumeCommand { get; }
        /// <summary>
        /// Gets the save snapshot command.
        /// </summary>
        public DelegateCommand SaveSnapshotCommand { get; }
        /// <summary>
        /// Gets the view video tutorials command.
        /// </summary>
        public DelegateCommand ViewVideoTutorialsCommand { get; }

        #endregion

        #region Implementation

        /// <summary>
        /// Configure audio input device.
        /// </summary>
        private void ConfigureAudioInputDevice()
        {
            this.videoCaptureAccessor.Audio_CaptureDevice_SettingsDialog_Show(SelectedAudioInputDevice.Name);
        }

        /// <summary>
        /// Configure video input device.
        /// </summary>
        private void ConfigureVideoInputDevice()
        {
            this.videoCaptureAccessor.Video_CaptureDevice_SettingsDialog_Show(SelectedVideoInputDevice.Name);
        }

        /// <summary>
        /// Browse for output file.
        /// </summary>
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

        /// <summary>
        /// Configure output format.
        /// </summary>
        private void ConfigureOutputFormat()
        {
            this.videoCaptureAccessor.DisplayConfigureDialog(SelectedOutputFormat.Tag);
        }

        /// <summary>
        /// View video tutorials.
        /// </summary>
        private void ViewVideoTutorials()
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Video capture accessor on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="message">The message.</param>
        private void VideoCaptureAccessorOnError(object sender, string message)
        {
            Log += (message + Environment.NewLine);
        }

        /// <summary>
        /// Add image logo.
        /// </summary>
        private void AddImageLogo()
        {
            var logoEffect = this.videoCaptureAccessor.AddImageLogoEffect();
            if (logoEffect != null)
            {
                Logos.Add(logoEffect);
            }
        }

        /// <summary>
        /// Add text logo.
        /// </summary>
        private void AddTextLogo()
        {
            var logoEffect = this.videoCaptureAccessor.AddTextLogoEffect();
            if (logoEffect != null)
            {
                Logos.Add(logoEffect);
            }
        }

        /// <summary>
        /// Can edit logo.
        /// </summary>
        private bool CanEditLogo() //-V3013
        {
            return SelectedLogo != null;
        }

        /// <summary>
        /// Edit logo.
        /// </summary>
        private void EditLogo()
        {
            this.videoCaptureAccessor.EditEffect(SelectedLogo);
        }

        /// <summary>
        /// Can remove logo.
        /// </summary>
        private bool CanRemoveLogo()
        {
            return SelectedLogo != null;
        }

        /// <summary>
        /// Remove logo.
        /// </summary>
        private void RemoveLogo()
        {
            this.videoCaptureAccessor.RemoveEffect(SelectedLogo);
            Logos.Remove(SelectedLogo);
        }

        /// <summary>
        /// Start.
        /// </summary>
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

            var videoSource = new VideoCaptureSource(SelectedVideoInputDevice.Name);
            videoSource.Format = SelectedVideoFormat.Name;
            videoSource.Format_UseBest = UseBestVideoInputFormat;
            videoSource.FrameRate = SelectedFrameRate.GetValueOrDefault(VideoFrameRate.FPS_25);

            var audioSource = new AudioCaptureSource(SelectedAudioInputDevice.Name);
            audioSource.Format = SelectedAudioInputFormat;
            audioSource.Format_UseBest = UseBestAudioInputFormat;

            VideoCaptureStartParams startParams = new VideoCaptureStartParams
            {
                DebugMode = this.DebugMode,
                DebugDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge"),
                RecordAudio = this.RecordAudio,
                VideoCaptureDevice = videoSource,
                AudioCaptureDevice = audioSource,
                AudioOutputDevice = SelectedAudioOutputDevice,
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

        /// <summary>
        /// Stop.
        /// </summary>
        private async void Stop()
        {
            tmRecording.Stop();
            await this.videoCaptureAccessor.StopAsync();
        }

        /// <summary>
        /// Pause.
        /// </summary>
        private async void Pause()
        {
            await this.videoCaptureAccessor.PauseAsync();
        }

        /// <summary>
        /// Resume.
        /// </summary>
        private async void Resume()
        {
            await this.videoCaptureAccessor.ResumeAsync();
        }

        /// <summary>
        /// Save snapshot.
        /// </summary>
        private async void SaveSnapshot()
        {
            var screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
            {
                FileName = "image.jpg",
                Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            };

            if (screenshotSaveDialog.ShowDialog() == true)
            {
                await videoCaptureAccessor.SaveScreenshotAsync(screenshotSaveDialog.FileName);
            }
        }

        /// <summary>
        /// Set grayscale effect enabled state.
        /// </summary>
        private void SetGrayscaleEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("Grayscale", GrayscaleEffectEnabled);
        }

        /// <summary>
        /// Set invert effect enabled state.
        /// </summary>
        private void SetInvertEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("Invert", InvertEffectEnabled);
        }

        /// <summary>
        /// Set flip x effect enabled state.
        /// </summary>
        private void SetFlipXEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("FlipDown", FlipXEffectEnabled);
        }

        /// <summary>
        /// Set flip y effect enabled state.
        /// </summary>
        private void SetFlipYEffectEnabledState()
        {
            this.videoCaptureAccessor.SetEffectEnabledState("FlipRight", FlipYEffectEnabled);
        }

        /// <summary>
        /// Set lightness effect value.
        /// </summary>
        private void SetLightnessEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Lightness", (int)CurrentLightnessValue);
        }

        /// <summary>
        /// Set darkness effect value.
        /// </summary>
        private void SetDarknessEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Darkness", (int)CurrentDarknessValue);
        }

        /// <summary>
        /// Set contrast effect value.
        /// </summary>
        private void SetContrastEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Contrast", (int)CurrentContrastValue);
        }

        /// <summary>
        /// Set saturation effect value.
        /// </summary>
        private void SetSaturationEffectValue()
        {
            this.videoCaptureAccessor.SetEffectValue("Saturation", (int)CurrentSaturationValue);
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
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

        /// <summary>
        /// The video capture accessor.
        /// </summary>
        private readonly IVideoCaptureAccessor videoCaptureAccessor;

        /// <summary>
        /// The recording timer.
        /// </summary>
        private readonly DispatcherTimer tmRecording = new DispatcherTimer();

        /// <summary>
        /// The title.
        /// </summary>
        private string title;

        /// <summary>
        /// The selected video input device.
        /// </summary>
        private VideoCaptureDeviceInfo selectedVideoInputDevice;

        /// <summary>
        /// The selected video format.
        /// </summary>
        private VideoCaptureDeviceFormat selectedVideoFormat;

        /// <summary>
        /// The selected frame rate.
        /// </summary>
        private VideoFrameRate? selectedFrameRate;

        /// <summary>
        /// The selected audio input device.
        /// </summary>
        private AudioCaptureDeviceInfo selectedAudioInputDevice;

        /// <summary>
        /// The selected audio input format.
        /// </summary>
        private string selectedAudioInputFormat;

        /// <summary>
        /// The selected audio input line.
        /// </summary>
        private string selectedAudioInputLine;

        /// <summary>
        /// The selected audio output device.
        /// </summary>
        private string selectedAudioOutputDevice;

        /// <summary>
        /// The use best video input format value.
        /// </summary>
        private bool useBestVideoInputFormat;

        /// <summary>
        /// The use best audio input format value.
        /// </summary>
        private bool useBestAudioInputFormat;

        /// <summary>
        /// The record audio value.
        /// </summary>
        private bool recordAudio;

        /// <summary>
        /// The minimum volume value.
        /// </summary>
        private double minVolumeValue;

        /// <summary>
        /// The maximum volume value.
        /// </summary>
        private double maxVolumeValue;

        /// <summary>
        /// The current volume value.
        /// </summary>
        private double curVolumeValue;

        /// <summary>
        /// The minimum balance value.
        /// </summary>
        private double minBalanceValue;

        /// <summary>
        /// The maximum balance value.
        /// </summary>
        private double maxBalanceValue;

        /// <summary>
        /// The current balance value.
        /// </summary>
        private double curBalanceValue;

        /// <summary>
        /// The selected output format.
        /// </summary>
        private OutputFormatInfo selectedOutputFormat;

        /// <summary>
        /// The output file name.
        /// </summary>
        private string outputFileName;

        /// <summary>
        /// The selected logo.
        /// </summary>
        private IVideoEffect selectedLogo;

        /// <summary>
        /// The merge image logos value.
        /// </summary>
        private bool mergeImageLogos;

        /// <summary>
        /// The merge text logos value.
        /// </summary>
        private bool mergeTextLogos;

        /// <summary>
        /// The grayscale effect enabled value.
        /// </summary>
        private bool grayscaleEffectEnabled;

        /// <summary>
        /// The invert effect enabled value.
        /// </summary>
        private bool invertEffectEnabled;

        /// <summary>
        /// The flip X effect enabled value.
        /// </summary>
        private bool flipXEffectEnabled;

        /// <summary>
        /// The flip Y effect enabled value.
        /// </summary>
        private bool flipYEffectEnabled;

        /// <summary>
        /// The minimum lightness value.
        /// </summary>
        private double minLightnessValue;

        /// <summary>
        /// The maximum lightness value.
        /// </summary>
        private double maxLightnessValue;

        /// <summary>
        /// The current lightness value.
        /// </summary>
        private double curLightnessValue;

        /// <summary>
        /// The minimum darkness value.
        /// </summary>
        private double minDarknessValue;

        /// <summary>
        /// The maximum darkness value.
        /// </summary>
        private double maxDarknessValue;

        /// <summary>
        /// The current darkness value.
        /// </summary>
        private double curDarknessValue;

        /// <summary>
        /// The minimum saturation value.
        /// </summary>
        private double minSaturationValue;

        /// <summary>
        /// The maximum saturation value.
        /// </summary>
        private double maxSaturationValue;

        /// <summary>
        /// The current saturation value.
        /// </summary>
        private double curSaturationValue;

        /// <summary>
        /// The minimum contrast value.
        /// </summary>
        private double minContrastValue;

        /// <summary>
        /// The maximum contrast value.
        /// </summary>
        private double maxContrastValue;

        /// <summary>
        /// The current contrast value.
        /// </summary>
        private double curContrastValue;

        /// <summary>
        /// The debug mode value.
        /// </summary>
        private bool debugMode;

        /// <summary>
        /// The log.
        /// </summary>
        private string log;

        /// <summary>
        /// The preview mode value.
        /// </summary>
        private bool previewMode;

        /// <summary>
        /// The recording time text.
        /// </summary>
        private string recordingTimeText;

        /// <summary>
        /// The selected content index.
        /// </summary>
        private int selectedContentIndex;
    }
}
