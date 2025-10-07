// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types;
using Windows.Storage.Pickers;
using Windows.ApplicationModel;
using Microsoft.UI.Windowing;
using VisioForge.Core.UI.WinUI;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.AudioRenderers;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Simple_Video_Capture;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

    private VideoCaptureCoreX VideoCapture1;

    private VisioForge.Core.UI.WinUI.VideoView _videoView;

    private bool disposedValue;

    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void tbAudioVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (VideoCapture1 != null)
        {
            VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0;
        }
    }

    private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
    {
        string filename = await SaveFileDialog();
        if (!string.IsNullOrEmpty(filename))
        {
            edOutput.Text = filename;
        }
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        tmRecording.Stop();

        await VideoCapture1.StopAsync();
    }

    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.ResumeAsync();
    }

    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.PauseAsync();
    }

    private void CreateEngine()
    {
        VideoCapture1 = new VideoCaptureCoreX(_videoView);

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

        VisioForgeX.DestroySDK();
    }

    private async Task<string> SaveFileDialog()
    {
        var picker = new FileSavePicker
        {
            SuggestedStartLocation = PickerLocationId.VideosLibrary,
            SuggestedFileName = "output",
            DefaultFileExtension = ".mp4"
        };
        picker.FileTypeChoices.Add("Video", new List<string> { $".mp4" });

        var m_hwnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
        WinRT.Interop.InitializeWithWindow.Initialize(picker, m_hwnd);

        var file = await picker.PickSaveFileAsync();
        if (file != null)
        {
            return file.Path;
        }

        return string.Empty;
    }

    private void Log(string txt)
    {
        DispatcherQueue.TryEnqueue(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
    }

    private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
    {
        Log(e.Message);
    }

    private async void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
        {
            cbVideoInputFormat.Items.Clear();

            var deviceItem =
                   (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format.Name);
            }

            if (cbVideoInputFormat.Items.Count > 0)
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
            cbAudioInputFormat.Items.Clear();

            var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.Formats)
            {
                cbAudioInputFormat.Items.Add(format.Name);
            }

            if (cbAudioInputFormat.Items.Count > 0)
            {
                cbAudioInputFormat.SelectedIndex = 0;
            }
        }
    }

    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        mmLog.Text = string.Empty;

        VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

        // audio output
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

        if (rbCapture.IsChecked == true)
        {
            // add MP4 output with default parameters
            var mp4output = new MP4Output(edOutput.Text);
            VideoCapture1.Outputs_Add(mp4output, autostart: true);
        }

        await VideoCapture1.StartAsync();

        tcMain.SelectedIndex = 2;
        tmRecording.Start();
    }

    private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
        {
            return;
        }

        if (cbVideoInputDevice.SelectedIndex != -1)
        {
            cbVideoInputFrameRate.Items.Clear();

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
                    cbVideoInputFrameRate.Items.Add(item);
                }

                if (cbVideoInputFrameRate.Items.Count > 0)
                {
                    cbVideoInputFrameRate.SelectedIndex = 0;
                }
            }
        }
    }

    private void UpdateRecordingTime()
    {
        var ts = VideoCapture1.Duration();

        if (Math.Abs(ts.TotalMilliseconds) < 0.01)
        {
            return;
        }

        DispatcherQueue.TryEnqueue(() =>
        {
            lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
        });
    }

    private void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                tmRecording?.Dispose();
                tmRecording = null;

                VideoCapture1?.Dispose();
                VideoCapture1 = null;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
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

    private void SetIcon()
    {
        try
        {
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            var appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.SetIcon(Path.Combine(Package.Current.InstalledLocation.Path, "Assets", "visioforge_main_icon.ico"));
        }
        catch (Exception ex)
        {
            // Ignore icon setting errors - not critical for functionality
            System.Diagnostics.Debug.WriteLine($"Failed to set window icon: {ex.Message}");
        }
    }

    private bool _isInitiated = false;

    private async void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        if (_isInitiated)
        {
            return;
        }

        _isInitiated = true;

        await VisioForgeX.InitSDKAsync();

        _videoView = new VideoView(canvasControl);

        CreateEngine();

        Title = $"Video Capture SDK .Net - Simple Video Capture Demo X for WinUI 3 Desktop (SDK v{VideoCaptureCoreX.SDK_Version})";

        SetIcon();

        tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

        // video inputs
        var videoInputs = await DeviceEnumerator.Shared.VideoSourcesAsync();
        foreach (var device in videoInputs)
        {
            cbVideoInputDevice.Items.Add(device.DisplayName);
        }

        if (cbVideoInputDevice.Items.Count > 0)
        {
            cbVideoInputDevice.SelectedIndex = 0;
        }

        // audio inputs
        var audioInputs = await DeviceEnumerator.Shared.AudioSourcesAsync();
        foreach (var device in audioInputs)
        {
            cbAudioInputDevice.Items.Add(device.DisplayName);
        }

        if (cbAudioInputDevice.Items.Count > 0)
        {
            cbAudioInputDevice.SelectedIndex = 0;
        }

        // audio outputs
        var audioOutputs = await DeviceEnumerator.Shared.AudioOutputsAsync();
        foreach (var device in audioOutputs)
        {
            cbAudioOutputDevice.Items.Add(device.DisplayName);
        }

        if (cbAudioOutputDevice.Items.Count > 0)
        {
            cbAudioOutputDevice.SelectedIndex = 0;
        }

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
    }

    private void Window_Closed(object sender, WindowEventArgs args)
    {
        DestroyEngine();
    }
}
