using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.UI.Avalonia;
using VisioForge.Core.VideoCaptureX;

namespace SimpleVideoCaptureA
{
    /// <summary>
    /// Interaction logic for the Avalonia Simple Video Capture demo's MainWindow.
    /// Demonstrates basic video capture capabilities using the X-engine in an Avalonia application.
    /// </summary>

    public partial class MainWindow : Window, IDisposable
    {
        private bool _initialized;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCoreX VideoCapture1;

        private bool disposedValue;

        #region Controls

        public ObservableCollection<string> Logs { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFormats { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> VideoInputFrameRates { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputDevices { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> AudioInputFormats { get; set; } = new ObservableCollection<string>();

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

            InitControls();

            Activated += MainWindow_Activated;

            DataContext = this;
        }

        /// <summary>
        /// Handles the event when a new audio sink (output device) is added by the device enumerator.
        /// Updates the AudioOutputDevices collection on the UI thread.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioOutputDeviceInfo"/> instance containing the new device information.</param>
        private async void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            await Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                AudioOutputDevices.Add(e.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
            }));
        }

        /// <summary>
        /// Handles the event when a new audio source (input device) is added by the device enumerator.
        /// Updates the AudioInputDevices collection on the UI thread.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioCaptureDeviceInfo"/> instance containing the new device information.</param>
        private async void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                AudioInputDevices.Add(e.DisplayName);

                if (cbAudioInputDevice.Items.Count == 1)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                }
            });
        }

        /// <summary>
        /// Handles the event when a new video source is added by the device enumerator.
        /// Updates the VideoInputDevices collection on the UI thread.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoCaptureDeviceInfo"/> instance containing the new device information.</param>
        private async void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
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

        /// <summary>
        /// Initializes the Avalonia component loader.
        /// </summary>
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        /// <summary>
        /// Handles the Activated event of the MainWindow.
        /// Performs one-time initialization, such as checking permissions (on macOS) and populating device lists.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MainWindow_Activated(object sender, EventArgs e)
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

        //var status = AVFoundation.AVCaptureDevice.GetAuthorizationStatus(AVFoundation.AVAuthorizationMediaType.Video);

        //switch (status)
        //{
        //    case AVFoundation.AVAuthorizationStatus.NotDetermined:
        //        {
        //            var accessTask = await AVFoundation.AVCaptureDevice.RequestAccessForMediaTypeAsync(AVFoundation.AVAuthorizationMediaType.Video);
        //            //return accessTask;
        //        }

        //        break;

        //    case AVFoundation.AVAuthorizationStatus.Restricted:
        //        //_context?.Error(TAG, "AskCameraPermissions",
        //        //    "Camera access restricted by user or system settings.");
        //       // return false;
        //    case AVFoundation.AVAuthorizationStatus.Denied:
        //       // _context?.Error(TAG, "AskCameraPermissions", "Camera access denied.");
        //      //  return false;
        //    case AVFoundation.AVAuthorizationStatus.Authorized:
        //      //  return true;
        //    default:
        //        throw new ArgumentOutOfRangeException();
        //}
#endif

            Closing += Window_Closing;

            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTimeAsync(); };

            // video inputs
            var videoInputs = await DeviceEnumerator.Shared.VideoSourcesAsync();
            foreach (var device in videoInputs)
            {
                VideoInputDevices.Add(device.DisplayName);
            }

            if (VideoInputDevices.Count > 0)
            {
                cbVideoInputDevice.SelectedIndex = 0;
                //cbVideoInputDevice_SelectionChanged(null, null);
            }

            // audio inputs
            var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
            foreach (var device in audioInputs)
            {
                AudioInputDevices.Add(device.DisplayName);
            }

            if (AudioInputDevices.Count > 0)
            {
                cbAudioInputDevice.SelectedIndex = 0;
                //cbAudioInputDevice_SelectionChanged(null, null);
            }

            // audio outputs
            var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var device in audioOutputs)
            {
                AudioOutputDevices.Add(device.DisplayName);
            }

            if (AudioOutputDevices.Count > 0)
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        }

        /// <summary>
        /// Initializes UI controls by finding them in the visual tree and attaching event handlers.
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

            mmLog = this.FindControl<ListBox>("mmLog");
            mmLog.ItemsSource = Logs;

        }

        /// <summary>
        /// Handles the PointerPressed event for the Video Tutorials label.
        /// Opens the video tutorials URL in the default browser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Avalonia.Input.PointerPressedEventArgs"/> instance containing the event data.</param>
        private void LbViewVideoTutorials_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Creates a new instance of the video capture engine and configures event handlers.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Disposes of the video capture engine and releases resources.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Opens a save file dialog for selecting a video output file.
        /// </summary>
        /// <returns>The confirmed filename, or null if cancelled.</returns>
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
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a dialog to select the output video file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            string filename = await SaveVideoFileDialogAsync();
            if (!string.IsNullOrEmpty(filename))
            {
                edOutput.Text = filename;
            }
        }

        /// <summary>
        /// Adds a message to the logs collection.
        /// </summary>
        /// <param name="txt">The message to log.</param>
        private void Log(string txt)
        {
            Logs.Add(txt);
        }

        /// <summary>
        /// Handles the OnError event of the video capture engine.
        /// Logs the error message.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the PropertyChanged event of the tbAudioVolume control.
        /// Updates the audio output volume when the slider value changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AvaloniaPropertyChangedEventArgs"/> instance containing the event data.</param>
        private void tbAudioVolume_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property.ToString() == "Value")
            {
                VideoCapture1.Audio_OutputDevice_Volume = ((int)tbAudioVolume.Value);
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbVideoInputDevice control.
        /// Populates available video formats for the selected video device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbAudioInputDevice control.
        /// Populates available audio formats for the selected audio device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbAudioInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine with selected video/audio sources and settings, then starts the capture.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            Logs.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            if (cbRecordAudio.IsChecked == true)
            {
                VideoCapture1.Audio_Record = true;
                VideoCapture1.Audio_Play = true;
            }
            else
            {
                VideoCapture1.Audio_Record = false;
                VideoCapture1.Audio_Play = false;
            }

            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.SelectedItem.ToString()).First();
            VideoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

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
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        if (cbVideoInputFrameRate.SelectedIndex != -1)
                        {
                            videoSourceSettings.Format.FrameRate =
                                new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.SelectedItem.ToString()));
                        }
                    }
                }
            }

            VideoCapture1.Video_Source = videoSourceSettings;

            // audio source
            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

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
                        audioSourceSettings = device.CreateSourceSettingsVC(formatItem.ToFormat());
                    }
                }
            }

            VideoCapture1.Audio_Source = audioSourceSettings;

            VideoCapture1.Snapshot_Grabber_Enabled = true;

            if (rbPreview.IsChecked == false)
            {
                // add MP4 output with default parameters
                var mp4output = new MP4Output(edOutput.Text);
                VideoCapture1.Outputs_Add(mp4output, autostart: true);
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btResume control.
        /// Resumes the video capture if it was paused.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the Click event of the btPause control.
        /// Pauses the video capture.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops video capture and resets the recording timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbVideoInputFormat control.
        /// Populates available frame rates based on the selected video format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        /// <summary>
        /// Handles the Click event of the btSaveSnapshot control.
        /// Captures a snapshot of the current video frame and saves it to a file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSaveSnapshot_Click(object sender, RoutedEventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialFileName = "image.jpg";
            sfd.DefaultExtension = ".jpg";
            sfd.Directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "VisioForge");

            var exts = new string[] { "jpg", "bmp", "png", "gif" };
            foreach (var extension in exts)
            {
                var filter = new FileDialogFilter();
                filter.Name = extension.ToUpperInvariant();
                filter.Extensions.Add(extension);
                sfd.Filters.Add(filter);
            }

            var filename = await sfd.ShowAsync(this);

            if (!string.IsNullOrEmpty(filename))
            {
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Bmp);
                        break;
                    case ".jpg":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Jpeg);
                        break;
                    case ".gif":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Gif);
                        break;
                    case ".png":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Png);
                        break;
                }
            }
        }

        /// <summary>
        /// Asynchronously updates the recording timestamp displayed on the UI.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdateRecordingTimeAsync()
        {
            var ts = await VideoCapture1.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            await Dispatcher.UIThread.InvokeAsync((Action)(() =>
            {
                lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the Closing event of the window.
        /// Ensures resources are cleaned up and the SDK is destroyed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Disposes of the managed resources used by the window.
        /// </summary>
        /// <param name="disposing">True if called from the <see cref="Dispose()"/> method; false if called from the finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    tmRecording?.Dispose();
                    tmRecording = null;

                    VideoCapture1?.Dispose();
                    VideoCapture1 = null;

                    VideoView1?.Dispose();
                    VideoView1 = null;
                }

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Window1()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Disposes of the resources utilized by the current instance.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}