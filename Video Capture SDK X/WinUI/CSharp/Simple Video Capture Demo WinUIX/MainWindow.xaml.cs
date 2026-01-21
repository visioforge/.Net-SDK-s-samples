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
/// Interaction logic for the WinUI Simple Video Capture demo's MainWindow.
/// Demonstrates the core capabilities of the Video Capture SDK in a WinUI 3 Desktop application,
/// including device enumeration, recording, and camera controls.
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

    /// <summary>
    /// Handles the ValueChanged event of the audio volume slider.
    /// Adjusts the output volume of the video capture engine.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RangeBaseValueChangedEventArgs"/> instance containing the event data.</param>
    private void tbAudioVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (VideoCapture1 != null)
        {
            VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0;
        }
    }

    /// <summary>
    /// Handles the Click event of the Select Output button.
    /// Opens a file save dialog to let the user choose where to save the recording.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
    {
        string filename = await SaveFileDialog();
        if (!string.IsNullOrEmpty(filename))
        {
            edOutput.Text = filename;
        }
    }

    /// <summary>
    /// Handles the Click event of the Stop button.
    /// Stops the video capture and the recording timer.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        tmRecording.Stop();

        await VideoCapture1.StopAsync();
    }

    /// <summary>
    /// Handles the Click event of the Resume button.
    /// Resumes the video capture if it was paused.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.ResumeAsync();
    }

    /// <summary>
    /// Handles the Click event of the Pause button.
    /// Pauses the video capture.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.PauseAsync();
    }

    /// <summary>
    /// Initializes the video capture engine and subscribes to error events.
    /// </summary>
    private void CreateEngine()
    {
        VideoCapture1 = new VideoCaptureCoreX(_videoView);

        VideoCapture1.OnError += VideoCapture1_OnError;
    }

    /// <summary>
    /// Diposes of the video capture engine and destroys the SDK instance.
    /// </summary>
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

    /// <summary>
    /// Opens a file save picker dialog to allow the user to select a destination for the recording.
    /// </summary>
    /// <returns>The full path of the selected file, or an empty string if cancelled.</returns>
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

    /// <summary>
    /// Appends a message to the on-screen log via the dispatcher.
    /// </summary>
    /// <param name="txt">The message text to log.</param>
    private void Log(string txt)
    {
        DispatcherQueue.TryEnqueue(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
    }

    /// <summary>
    /// Handles the OnError event of the video capture engine.
    /// Logs any errors that occur during operation.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
    private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
    {
        Log(e.Message);
    }

    /// <summary>
    /// Handles the SelectionChanged event of the video input device combo box.
    /// Updates the available video formats based on the selected device.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the SelectionChanged event of the audio input device combo box.
    /// Updates the available audio formats based on the selected device.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Click event of the Start button.
    /// Configures the video capture engine with selected video/audio sources and settings, then starts the capture.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the SelectionChanged event of the video input format combo box.
    /// Updates available frame rates for the selected video format.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Updates the recording duration display on the UI thread.
    /// </summary>
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

    /// <summary>
    /// Disposes of managed resources and cleans up the video capture engine.
    /// </summary>
    /// <param name="disposing">True if called from <see cref="Dispose()"/>; false if called from finalizer.</param>
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

    /// <summary>
    /// Releases all resources used by the <see cref="MainWindow"/>.
    /// </summary>
    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Sets the application window icon.
    /// </summary>
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

    /// <summary>
    /// Handles the Activated event of the Window.
    /// Performs one-time initialization, such as initializing the SDK, creating the engine, setting the icon, and enumerating devices.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">The <see cref="WindowActivatedEventArgs"/> instance containing the event data.</param>
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

    /// <summary>
    /// Handles the Closed event of the Window.
    /// Ensures that the engine is destroyed and resources are cleaned up.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="args">The <see cref="WindowEventArgs"/> instance containing the event data.</param>
    private void Window_Closed(object sender, WindowEventArgs args)
    {
        DestroyEngine();
    }
}
