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
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.UI.Avalonia;
using VisioForge.Core.VideoCaptureX;

namespace SimpleVideoCaptureA;

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

    public ObservableCollection<string> AudioInputLines { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> AudioOutputDevices { get; set; } = new ObservableCollection<string>();

    public ObservableCollection<string> Logos { get; set; } = new ObservableCollection<string>();

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
        DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
        DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

        InitControls();

        Activated += MainWindow_Activated;

        DataContext = this;
    }

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

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

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

        await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
        await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
        //await _deviceEnumerator.StartAudioSinkMonitorAsync();

        var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();

        CreateEngine();

        Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

        tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTimeAsync(); };

        //foreach (var device in VideoCapture1.Video_CaptureDevices())
        //{
        //    VideoInputDevices.Add(device.Name);
        //}

        //if (VideoInputDevices.Count > 0)
        //{
        //    cbVideoInputDevice.SelectedIndex = 0;
        //}

        //cbVideoInputDevice_SelectionChanged(null, null);

        //foreach (var device in VideoCapture1.Audio_CaptureDevices())
        //{
        //    AudioInputDevices.Add(device.Name);
        //}

        //if (AudioInputDevices.Count > 0)
        //{
        //    cbAudioInputDevice.SelectedIndex = 0;
        //    cbAudioInputDevice_SelectionChanged(null, null);
        //}

        //AudioInputLines.Clear();

        //if (!string.IsNullOrEmpty(cbAudioInputDevice.SelectedItem.ToString()))
        //{
        //    var deviceItem =
        //        VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == cbAudioInputDevice.SelectedItem.ToString());
        //    if (deviceItem != null)
        //    {
        //        foreach (var line in deviceItem.Lines)
        //        {
        //            AudioInputLines.Add(line);
        //        }

        //        if (AudioInputLines.Count > 0)
        //        {
        //            cbAudioInputLine.SelectedIndex = 0;
        //        }
        //    }
        //}

        //string defaultAudioRenderer = string.Empty;
        //foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices())
        //{
        //    AudioOutputDevices.Add(audioOutputDevice);

        //    if (audioOutputDevice.Contains("Default DirectSound Device"))
        //    {
        //        defaultAudioRenderer = audioOutputDevice;
        //    }
        //}

        //if (AudioOutputDevices.Count > 0)
        //{
        //    if (string.IsNullOrEmpty(defaultAudioRenderer))
        //    {
        //        cbAudioOutputDevice.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        cbAudioOutputDevice.SelectedItem = defaultAudioRenderer;
        //    }
        //}

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
    }

    private void InitControls()
    {
        VideoView1 = this.FindControl<VideoView>("VideoView1");

        cbVideoInputDevice = this.FindControl<ComboBox>("cbVideoInputDevice");
        cbVideoInputDevice.SelectionChanged += cbVideoInputDevice_SelectionChanged;

        btVideoCaptureDeviceSettings = this.FindControl<Button>("btVideoCaptureDeviceSettings");
        btVideoCaptureDeviceSettings.Click += btVideoCaptureDeviceSettings_Click;

        cbVideoInputFormat = this.FindControl<ComboBox>("cbVideoInputFormat");
        cbVideoInputFormat.SelectionChanged += cbVideoInputFormat_SelectionChanged;

        cbVideoInputFrameRate = this.FindControl<ComboBox>("cbVideoInputFrameRate");

        cbAudioInputDevice = this.FindControl<ComboBox>("cbAudioInputDevice");
        cbAudioInputDevice.SelectionChanged += cbAudioInputDevice_SelectionChanged;

        btAudioInputDeviceSettings = this.FindControl<Button>("btAudioInputDeviceSettings");
        btAudioInputDeviceSettings.Click += btAudioInputDeviceSettings_Click;

        cbAudioInputFormat = this.FindControl<ComboBox>("cbAudioInputFormat");

        cbAudioOutputDevice = this.FindControl<ComboBox>("cbAudioOutputDevice");

        cbRecordAudio = this.FindControl<CheckBox>("cbRecordAudio");

        tbAudioVolume = this.FindControl<Slider>("tbAudioVolume");
        tbAudioVolume.PropertyChanged += tbAudioVolume_PropertyChanged;

        edOutput = this.FindControl<TextBox>("edOutput");

        btSelectOutput = this.FindControl<Button>("btSelectOutput");
        btSelectOutput.Click += btSelectOutput_Click;

        lbViewVideoTutorials = this.FindControl<Label>("lbViewVideoTutorials");
        lbViewVideoTutorials.PointerPressed += LbViewVideoTutorials_PointerPressed;

        tbLightness = this.FindControl<Slider>("tbLightness");
        tbLightness.PropertyChanged += tbLightness_PropertyChanged;

        tbSaturation = this.FindControl<Slider>("tbSaturation");
        tbSaturation.PropertyChanged += tbSaturation_PropertyChanged;

        tbContrast = this.FindControl<Slider>("tbContrast");
        tbContrast.PropertyChanged += tbContrast_PropertyChanged;

        tbDarkness = this.FindControl<Slider>("tbDarkness");
        tbDarkness.PropertyChanged += tbDarkness_PropertyChanged;

        cbGreyscale = this.FindControl<CheckBox>("cbGreyscale");
        cbGreyscale.Checked += cbGreyscale_CheckedChanged;
        cbGreyscale.Unchecked += cbGreyscale_CheckedChanged;

        cbInvert = this.FindControl<CheckBox>("cbInvert");
        cbInvert.Checked += cbInvert_CheckedChanged;
        cbInvert.Unchecked += cbInvert_CheckedChanged;

        cbFlipX = this.FindControl<CheckBox>("cbFlipX");
        cbFlipX.Checked += cbFlipX_Checked;
        cbFlipX.Unchecked += cbFlipX_Checked;

        cbFlipY = this.FindControl<CheckBox>("cbFlipY");
        cbFlipY.Checked += cbFlipY_Checked;
        cbFlipY.Unchecked += cbFlipY_Checked;

        cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");

        rbPreview = this.FindControl<RadioButton>("rbPreview");

        lbTimestamp = this.FindControl<TextBlock>("lbTimestamp");

        btSaveSnapshot = this.FindControl<Button>("btSaveSnapshot");
        btSaveSnapshot.Click += btSaveSnapshot_Click;

        btStart = this.FindControl<Button>("btStart");
        btStart.Click += btStart_Click;

        btStop = this.FindControl<Button>("btStop");
        btStop.Click += btStop_Click;

        btResume = this.FindControl<Button>("btResume");
        btResume.Click += btResume_Click;

        btPause = this.FindControl<Button>("btPause");
        btPause.Click += btPause_Click;

        btSaveSnapshot = this.FindControl<Button>("btSaveSnapshot");

        cbDebugMode = this.FindControl<CheckBox>("cbDebugMode");

        tcMain = this.FindControl<TabControl>("tcMain");
    }

    private void LbViewVideoTutorials_PointerPressed(object sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
        Process.Start(startInfo);
    }

    private void CreateEngine()
    {
        VideoCapture1 = new VideoCaptureCoreX(VideoView1);

        VideoCapture1.OnError += VideoCapture1_OnError;
    }

    private void DestroyEngine()
    {
        if (VideoCapture1 != null)
        {
            VideoCapture1.OnError -= VideoCapture1_OnError;

            VideoCapture1.Dispose();
            VideoCapture1 = null;
        }
    }

    private async Task<string> SaveVideoFileDialogAsync()
    {
        SaveFileDialog sfd = new SaveFileDialog();
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

    private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
    {
        //VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.SelectedItem.ToString());
    }

    private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
    {
        string filename = await SaveVideoFileDialogAsync();
        if (!string.IsNullOrEmpty(filename))
        {
            edOutput.Text = filename;
        }
    }

    private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
    {
       // VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.SelectedItem.ToString());
    }

    private void Log(string txt)
    {
        Logs.Add(txt);
    }

    private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
    {
        Log(e.Message);
    }

    private void tbAudioVolume_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.ToString() == "Value")
        {
            VideoCapture1.Audio_OutputDevice_Volume = ((int)tbAudioVolume.Value);
        }
    }

    private void tbAudioBalance_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        //if (e.Property.ToString() == "Value")
        //{
        //    VideoCapture1.Audio_Output((int)tbAudioBalance.Value);
        //}
    }

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

        VideoCapture1.Audio_OutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.SelectedItem.ToString()).First();

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


        //if (rbPreview.IsChecked == true)
        //{
        //    VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
        //}
        //else
        //{
        //    VideoCapture1.Mode = VideoCaptureMode.VideoCapture;
        //    var mp4Output = new MP4Output();
        //    VideoCapture1.Output_Format = mp4Output;
        //    VideoCapture1.Output_Filename = edOutput.Text;
        //}

        VideoCapture1.Video_Effects_Clear();
        Logos.Clear();
        ConfigureVideoEffects();

        await VideoCapture1.StartAsync();

        tcMain.SelectedIndex = 3;
        tmRecording.Start();
    }

    private void ConfigureVideoEffects()
    {
        if (tbLightness.Value > 0)
        {
            UpdateLightness();
        }

        if (tbSaturation.Value < 255)
        {
            UpdateSaturation();
        }

        if (tbContrast.Value > 0)
        {
            UpdateContrast();
        }

        if (tbDarkness.Value > 0)
        {
            UpdateDarkness();
        }

        if (cbGreyscale.IsChecked == true)
        {
            cbGreyscale_CheckedChanged(null, null);
        }

        if (cbInvert.IsChecked == true)
        {
            cbInvert_CheckedChanged(null, null);
        }

        if (cbFlipX.IsChecked == true)
        {
            cbFlipX_Checked(null, null);
        }

        if (cbFlipY.IsChecked == true)
        {
            cbFlipY_Checked(null, null);
        }
    }

    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.ResumeAsync();
    }

    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.PauseAsync();
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        tmRecording.Stop();

        await VideoCapture1.StopAsync();
    }

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

    private async void btSaveSnapshot_Click(object sender, RoutedEventArgs e)
    {
        var sfd = new SaveFileDialog();
        sfd.InitialFileName = "image.jpg";
        sfd.DefaultExtension = ".jpg";
        sfd.Directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

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
                    await VideoCapture1.Video_Renderer_Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Bmp);
                    break;
                case ".jpg":
                    await VideoCapture1.Video_Renderer_Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Jpeg);
                    break;
                case ".gif":
                    await VideoCapture1.Video_Renderer_Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Gif);
                    break;
                case ".png":
                    await VideoCapture1.Video_Renderer_Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Png);
                    break;
            }
        }
    }

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

    private void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
    {
        //IVideoEffectGrayscale grayscale;
        //var effect = VideoCapture1.Video_Effects_Get("Grayscale");
        //if (effect == null)
        //{
        //    grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
        //    VideoCapture1.Video_Effects_Add(grayscale);
        //}
        //else
        //{
        //    grayscale = effect as IVideoEffectGrayscale;
        //    if (grayscale != null)
        //    {
        //        grayscale.Enabled = cbGreyscale.IsChecked == true;
        //    }
        //}
    }

    private void UpdateContrast()
    {
        //IVideoEffectContrast contrast;
        //var effect = VideoCapture1.Video_Effects_Get("Contrast");
        //if (effect == null)
        //{
        //    contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
        //    VideoCapture1.Video_Effects_Add(contrast);
        //}
        //else
        //{
        //    contrast = effect as IVideoEffectContrast;
        //    if (contrast != null)
        //    {
        //        contrast.Value = (int)tbContrast.Value;
        //    }
        //}
    }

    private void tbContrast_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.ToString() == "Value")
        {
            UpdateContrast();
        }
    }

    private void UpdateDarkness()
    {
        //IVideoEffectDarkness darkness;
        //var effect = VideoCapture1.Video_Effects_Get("Darkness");
        //if (effect == null)
        //{
        //    darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
        //    VideoCapture1.Video_Effects_Add(darkness);
        //}
        //else
        //{
        //    darkness = effect as IVideoEffectDarkness;
        //    if (darkness != null)
        //    {
        //        darkness.Value = (int)tbDarkness.Value;
        //    }
        //}
    }

    private void tbDarkness_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.ToString() == "Value")
        {
            UpdateDarkness();
        }
    }

    private void UpdateLightness()
    {
        //IVideoEffectLightness lightness;
        //var effect = VideoCapture1.Video_Effects_Get("Lightness");
        //if (effect == null)
        //{
        //    lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
        //    VideoCapture1.Video_Effects_Add(lightness);
        //}
        //else
        //{
        //    lightness = effect as IVideoEffectLightness;
        //    if (lightness != null)
        //    {
        //        lightness.Value = (int)tbLightness.Value;
        //    }
        //}
    }

    private void tbLightness_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.ToString() == "Value")
        {
            UpdateLightness();
        }
    }

    private void UpdateSaturation()
    {
        //if (VideoCapture1 != null)
        //{
        //    IVideoEffectSaturation saturation;
        //    var effect = VideoCapture1.Video_Effects_Get("Saturation");
        //    if (effect == null)
        //    {
        //        saturation = new VideoEffectSaturation((int)tbSaturation.Value);
        //        VideoCapture1.Video_Effects_Add(saturation);
        //    }
        //    else
        //    {
        //        saturation = effect as IVideoEffectSaturation;
        //        if (saturation != null)
        //        {
        //            saturation.Value = (int)tbSaturation.Value;
        //        }
        //    }
        //}
    }

    private void tbSaturation_PropertyChanged(object sender, AvaloniaPropertyChangedEventArgs e)
    {
        if (e.Property.ToString() == "Value")
        {
            UpdateSaturation();
        }
    }

    private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
    {
        //IVideoEffectInvert invert;
        //var effect = VideoCapture1.Video_Effects_Get("Invert");
        //if (effect == null)
        //{
        //    invert = new VideoEffectInvert(cbInvert.IsChecked == true);
        //    VideoCapture1.Video_Effects_Add(invert);
        //}
        //else
        //{
        //    invert = effect as IVideoEffectInvert;
        //    if (invert != null)
        //    {
        //        invert.Enabled = cbInvert.IsChecked == true;
        //    }
        //}
    }

    private void cbFlipX_Checked(object sender, RoutedEventArgs e)
    {
        //IVideoEffectFlipDown flip;
        //var effect = VideoCapture1.Video_Effects_Get("FlipDown");
        //if (effect == null)
        //{
        //    flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
        //    VideoCapture1.Video_Effects_Add(flip);
        //}
        //else
        //{
        //    flip = effect as IVideoEffectFlipDown;
        //    if (flip != null)
        //    {
        //        flip.Enabled = cbFlipX.IsChecked == true;
        //    }
        //}
    }

    private void cbFlipY_Checked(object sender, RoutedEventArgs e)
    {
        //IVideoEffectFlipRight flip;
        //var effect = VideoCapture1.Video_Effects_Get("FlipRight");
        //if (effect == null)
        //{
        //    flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
        //    VideoCapture1.Video_Effects_Add(flip);
        //}
        //else
        //{
        //    flip = effect as IVideoEffectFlipRight;
        //    if (flip != null)
        //    {
        //        flip.Enabled = cbFlipY.IsChecked == true;
        //    }
        //}
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        DestroyEngine();

        VisioForgeX.DestroySDK();
    }

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

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
