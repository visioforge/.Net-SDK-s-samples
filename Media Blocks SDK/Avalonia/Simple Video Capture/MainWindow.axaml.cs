using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI;
using VisioForge.Core.UI.Avalonia;
using VisioForge.Core.VideoCaptureX;

namespace SimpleVideoCaptureAMB
{
    /// <summary>
    /// Interaction logic for MainWindow.axaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        /// <summary>
        /// The initialized flag.
        /// </summary>
        private bool _initialized;

        /// <summary>
        /// The recording timer.
        /// </summary>
        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The video source.
        /// </summary>
        private SystemVideoSourceBlock _videoSource;

        /// <summary>
        /// The audio source.
        /// </summary>
        private MediaBlock _audioSource;

        /// <summary>
        /// The MP4 output.
        /// </summary>
        private MP4OutputBlock _mp4Output;

        /// <summary>
        /// The video tee.
        /// </summary>
        private TeeBlock _videoTee;

        /// <summary>
        /// The audio tee.
        /// </summary>
        private TeeBlock _audioTee;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        #region Controls

        public ObservableCollection<string> VideoInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFormats { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFrameRates { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputFormats { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputLines { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioOutputDevices { get; set; } = new ObservableCollection<string>();

        #endregion

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;

            InitControls();

            Activated += MainWindow_Activated;

            DataContext = this;
        }

        /// <summary>
        /// Device enumerator on video source added.
        /// </summary>
        private async void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            try
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    VideoInputDevices.Add(e.DisplayName);

                    if (cbVideoInputDevice.Items.Count == 1)
                    {
                        cbVideoInputDevice.SelectedIndex = 0;
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Initialize component.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handles the main window activated event.
        /// </summary>
        private async void MainWindow_Activated(object sender, EventArgs e)
        {
            try
            {
                if (_initialized)
                {
                    return;
                }

                _initialized = true;

    #if __MACOS__
            AVFoundation.AVCaptureDevice.RequestAccessForMediaType(AVFoundation.AVAuthorizationMediaType.Video, (bool granted) => {
                Debug.WriteLine($"Camera access: {granted}");
                // Handle the response here. 'granted' is true if permission is given.
            });
    #endif

                Closing += Window_Closing;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();

                // audio inputs
                var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
                foreach (var device in audioInputs)
                {
                    AudioInputDevices.Add(device.DisplayName);
                }

                if (AudioInputDevices.Count > 0)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                    cbAudioInputDevice_SelectionChanged(null, null);
                }

                // audio outputs
                var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
                foreach (var audioOutputDevice in audioOutputs)
                {
                    AudioOutputDevices.Add(audioOutputDevice.DisplayName);
                }

                if (AudioOutputDevices.Count > 0)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }

                Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

                tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTimeAsync(); };

                edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Init controls.
        /// </summary>
        private void InitControls()
        {
            VideoView1 = this.FindControl<VideoView>("VideoView1");

            cbVideoInputDevice = this.FindControl<ComboBox>("cbVideoInputDevice");
            cbVideoInputDevice.SelectionChanged += cbVideoInputDevice_SelectionChanged;
            cbVideoInputDevice.ItemsSource = VideoInputDevices;

            cbVideoInputFormat = this.FindControl<ComboBox>("cbVideoInputFormat");
            cbVideoInputFormat.SelectionChanged += cbVideoInputFormat_SelectionChanged;
            cbVideoInputFormat.ItemsSource = VideoInputFormats;

            cbVideoInputFrameRate = this.FindControl<ComboBox>("cbVideoInputFrameRate");
            cbVideoInputFrameRate.ItemsSource = VideoInputFrameRates;

            cbAudioInputDevice = this.FindControl<ComboBox>("cbAudioInputDevice");
            cbAudioInputDevice.SelectionChanged += cbAudioInputDevice_SelectionChanged;
            cbAudioInputDevice.ItemsSource = AudioInputDevices;

            cbAudioInputFormat = this.FindControl<ComboBox>("cbAudioInputFormat");
            cbAudioInputFormat.ItemsSource = AudioInputFormats;

            cbAudioOutputDevice = this.FindControl<ComboBox>("cbAudioOutputDevice");
            cbAudioOutputDevice.ItemsSource = AudioOutputDevices;

            cbRecordAudio = this.FindControl<CheckBox>("cbRecordAudio");

            tbAudioVolume = this.FindControl<Slider>("tbAudioVolume");
            tbAudioVolume.PropertyChanged += tbAudioVolume_PropertyChanged;

            edOutput = this.FindControl<TextBox>("edOutput");

            btSelectOutput = this.FindControl<Button>("btSelectOutput");
            btSelectOutput.Click += btSelectOutput_Click;

            lbViewVideoTutorials = this.FindControl<Label>("lbViewVideoTutorials");
            lbViewVideoTutorials.PointerPressed += LbViewVideoTutorials_PointerPressed;

            cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");

            rbPreview = this.FindControl<RadioButton>("rbPreview");
            rbCapture = this.FindControl<RadioButton>("rbCapture");

            lbTimestamp = this.FindControl<TextBlock>("lbTimestamp");

            btStart = this.FindControl<Button>("btStart");
            btStart.Click += btStart_Click;

            btStop = this.FindControl<Button>("btStop");
            btStop.Click += btStop_Click;

            btResume = this.FindControl<Button>("btResume");
            btResume.Click += btResume_Click;

            btPause = this.FindControl<Button>("btPause");
            btPause.Click += btPause_Click;

            cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");

            tcMain = this.FindControl<TabControl>("tcMain");

            edLog = this.FindControl<TextBox>("edLog");
        }

        /// <summary>
        /// Lb view video tutorials pointer pressed.
        /// </summary>
        private void LbViewVideoTutorials_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {

        }

        /// <summary>
        /// Save video file dialog async.
        /// </summary>
        private async Task<string> SaveVideoFileDialogAsync()
        {
            var sfd = new SaveFileDialog();
            sfd.InitialFileName = "video.mp4";
            sfd.DefaultExtension = ".mp4";

            var exts = new string[] { "mp4", "avi", "wmv", "wma", "mp3", "ogg" };
            foreach (var extension in exts)
            {
                var filter = new FileDialogFilter();
                filter.Name = extension.ToUpperInvariant();
                filter.Extensions.Add(extension);
                sfd.Filters.Add(filter);
            }

            return await sfd.ShowAsync(this);
        }

        /// <summary>
        /// Handles the bt select output click event.
        /// </summary>
        private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = await SaveVideoFileDialogAsync();
                if (!string.IsNullOrEmpty(filename))
                {
                    edOutput.Text = filename;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string txt)
        {
            Dispatcher.UIThread.InvokeAsync(() => { edLog.Text += txt + Environment.NewLine; });
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Tb audio volume property changed.
        /// </summary>
        private void tbAudioVolume_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (_audioRenderer != null && e.Property.ToString() == "Value")
            {
                _audioRenderer.Volume = tbAudioVolume.Value / 100;
            }
        }

        /// <summary>
        /// Cb video input device selection changed.
        /// </summary>
        private async void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    VideoInputFormats.Clear();

                    var deviceItem =
                           (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                    if (deviceItem == null)
                    {
                        return;
                    }

                    foreach (var format in deviceItem.VideoFormats)
                    {
                        VideoInputFormats.Add(format.Name);
                    }

                    if (VideoInputFormats.Count > 0)
                    {
                        cbVideoInputFormat.SelectedIndex = 0;
                        cbVideoInputFormat_SelectionChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb audio input device selection changed.
        /// </summary>
        private async void cbAudioInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
                {
                    AudioInputFormats.Clear();

                    var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                    if (deviceItem == null)
                    {
                        return;
                    }

                    foreach (var format in deviceItem.Formats)
                    {
                        AudioInputFormats.Add(format.Name);
                    }

                    if (AudioInputFormats.Count > 0)
                    {
                        cbAudioInputFormat.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                edLog.Text = string.Empty;

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += VideoCapture1_OnError;
                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
                _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                bool audioStream = cbRecordAudio.IsChecked == true;
                bool capture = rbCapture.IsChecked == true;

                // video source
                VideoCaptureDeviceSourceSettings videoSourceSettings = null;

                var deviceName = cbVideoInputDevice.SelectedItem.ToString();
                var format = cbVideoInputFormat.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            videoSourceSettings = new VideoCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                            if (cbVideoInputFrameRate.SelectedIndex != -1)
                            {
                                videoSourceSettings.Format.FrameRate =
                                    new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.SelectedItem.ToString()));
                            }
                        }
                    }
                }

                _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

                // audio source
                if (audioStream)
                {
                    IAudioCaptureDeviceSourceSettings audioSourceSettings = null;

                    deviceName = cbAudioInputDevice.SelectedItem.ToString();
                    format = cbAudioInputFormat.SelectedItem.ToString();
                    if (!string.IsNullOrEmpty(deviceName))
                    {
                        var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                        if (device != null)
                        {
                            var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                            if (formatItem != null)
                            {
                                audioSourceSettings = device.CreateSourceSettings(formatItem.ToFormat());
                            }
                        }
                    }

                    _audioSource = new SystemAudioSourceBlock(audioSourceSettings);

                    var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.SelectedItem.ToString()).First();
                    _audioRenderer = new AudioRendererBlock(audioOutputDevice);
                }

                // connect blocks
                if (capture)
                {
                    _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);
                    _pipeline.Connect(_videoSource, _videoTee);

                    _mp4Output = new MP4OutputBlock(edOutput.Text);
                    _pipeline.Connect(_videoTee, _mp4Output);
                    _pipeline.Connect(_videoTee, _videoRenderer);

                    if (audioStream)
                    {
                        _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                        _pipeline.Connect(_audioSource, _audioTee);

                        _pipeline.Connect(_audioTee, _mp4Output);
                        _pipeline.Connect(_audioTee, _audioRenderer);
                    }
                }
                else
                {
                    _pipeline.Connect(_videoSource, _videoRenderer);

                    if (audioStream)
                    {
                        _pipeline.Connect(_audioSource, _audioRenderer);
                    }
                }

                await _pipeline.StartAsync();

                tcMain.SelectedIndex = 3;
                tmRecording.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt resume click event.
        /// </summary>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.ResumeAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.PauseAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tmRecording.Stop();

                if (_pipeline != null)
                {
                    await _pipeline.StopAsync();

                    _pipeline.OnError -= VideoCapture1_OnError;

                    _pipeline.Dispose();
                    _pipeline = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cb video input format selection changed.
        /// </summary>
        private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedItem.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedItem.ToString()))
                {
                    return;
                }

                if (cbVideoInputDevice.SelectedIndex != -1)
                {
                    VideoInputFrameRates.Clear();

                    if (cbVideoInputDevice.SelectedIndex != -1)
                    {
                        var deviceItem = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(device => device.DisplayName == cbVideoInputDevice.SelectedValue.ToString());
                        if (deviceItem == null)
                        {
                            return;
                        }

                        var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
                        if (videoFormat == null)
                        {
                            return;
                        }

                        // build int range from tuple (min, max)
                        var frameRateList = videoFormat.GetFrameRateRangeAsStringList();
                        foreach (var item in frameRateList)
                        {
                            VideoInputFrameRates.Add(item);
                        }

                        if (VideoInputFrameRates.Count > 0)
                        {
                            cbVideoInputFrameRate.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Update recording time async.
        /// </summary>
        private async Task UpdateRecordingTimeAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            var pos = await _pipeline.Position_GetAsync();

            if (Math.Abs(pos.TotalMilliseconds) < 0.01)
            {
                return;
            }

            await Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + pos.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= VideoCapture1_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    tmRecording?.Dispose();
                    tmRecording = null;

                    if (_pipeline != null)
                    {
                        _pipeline.OnError -= VideoCapture1_OnError;

                        _pipeline.Dispose();
                        _pipeline = null;
                    }

                    VideoView1?.Dispose();
                    VideoView1 = null;
                }

                disposedValue = true;
            }
        }



        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
