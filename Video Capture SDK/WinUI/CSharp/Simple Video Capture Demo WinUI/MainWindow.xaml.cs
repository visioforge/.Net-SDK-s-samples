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
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using VisioForge.Core.Helpers;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.Types;
using VisioForge.Core.VideoCapture;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.ApplicationModel;
using Microsoft.UI.Windowing;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Simple_Video_Capture;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    private Color _videoViewBackgroud;

    private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

    private VideoCaptureCore VideoCapture1;

    private bool disposedValue;

    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void btVideoCaptureDeviceSettings_Click(object sender, RoutedEventArgs e)
    {
        VideoCapture1.Video_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbVideoInputDevice.SelectedValue.ToString());
    }

    private void tbAudioVolume_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        VideoCapture1?.Audio_OutputDevice_Volume_Set((int)tbAudioVolume.Value);
    }

    private void tbAudioBalance_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        VideoCapture1.Audio_OutputDevice_Balance_Set((int)tbAudioBalance.Value);
    }

    private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        switch (cbOutputFormat.SelectedIndex)
        {
            case 0:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                    break;
                }
            case 1:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".wmv");
                    break;
                }
            case 2:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4"); //-V3139
                    break;
                }
            case 3:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                    break;
                }
            case 4:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".gif");
                    break;
                }
            case 5:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                    break;
                }
            case 6:
                {
                    edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                    break;
                }
        }
    }

    private async void btSelectOutput_Click(object sender, RoutedEventArgs e)
    {
        string filename = await SaveFileDialog(this, "*");
        if (!string.IsNullOrEmpty(filename))
        {
            edOutput.Text = filename;
        }
    }

    private void tbLightness_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        IVideoEffectLightness lightness;
        var effect = VideoCapture1.Video_Effects_Get("Lightness");
        if (effect == null)
        {
            lightness = new VideoEffectLightness(true, (int)tbLightness.Value);
            VideoCapture1.Video_Effects_Add(lightness);
        }
        else
        {
            lightness = effect as IVideoEffectLightness;
            if (lightness != null)
            {
                lightness.Value = (int)tbLightness.Value;
            }
        }
    }

    private void tbSaturation_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        if (VideoCapture1 != null)
        {
            IVideoEffectSaturation saturation;
            var effect = VideoCapture1.Video_Effects_Get("Saturation");
            if (effect == null)
            {
                saturation = new VideoEffectSaturation((int)tbSaturation.Value);
                VideoCapture1.Video_Effects_Add(saturation);
            }
            else
            {
                saturation = effect as IVideoEffectSaturation;
                if (saturation != null)
                {
                    saturation.Value = (int)tbSaturation.Value;
                }
            }
        }
    }

    private void tbContrast_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        IVideoEffectContrast contrast;
        var effect = VideoCapture1.Video_Effects_Get("Contrast");
        if (effect == null)
        {
            contrast = new VideoEffectContrast(true, (int)tbContrast.Value);
            VideoCapture1.Video_Effects_Add(contrast);
        }
        else
        {
            contrast = effect as IVideoEffectContrast;
            if (contrast != null)
            {
                contrast.Value = (int)tbContrast.Value;
            }
        }
    }

    private void tbDarkness_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        IVideoEffectDarkness darkness;
        var effect = VideoCapture1.Video_Effects_Get("Darkness");
        if (effect == null)
        {
            darkness = new VideoEffectDarkness(true, (int)tbDarkness.Value);
            VideoCapture1.Video_Effects_Add(darkness);
        }
        else
        {
            darkness = effect as IVideoEffectDarkness;
            if (darkness != null)
            {
                darkness.Value = (int)tbDarkness.Value;
            }
        }
    }

    private void cbGreyscale_Click(object sender, RoutedEventArgs e)
    {
        IVideoEffectGrayscale grayscale;
        var effect = VideoCapture1.Video_Effects_Get("Grayscale");
        if (effect == null)
        {
            grayscale = new VideoEffectGrayscale(cbGreyscale.IsChecked == true);
            VideoCapture1.Video_Effects_Add(grayscale);
        }
        else
        {
            grayscale = effect as IVideoEffectGrayscale;
            if (grayscale != null)
            {
                grayscale.Enabled = cbGreyscale.IsChecked == true;
            }
        }
    }

    private async void btStop_Click(object sender, RoutedEventArgs e)
    {
        tmRecording.Stop();

        await VideoCapture1.StopAsync();

        VideoView1.Background = new SolidColorBrush(_videoViewBackgroud);
    }

    private async void btResume_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.ResumeAsync();
    }

    private async void btPause_Click(object sender, RoutedEventArgs e)
    {
        await VideoCapture1.PauseAsync();
    }

    private void cbInvert_Click(object sender, RoutedEventArgs e)
    {
        IVideoEffectInvert invert;
        var effect = VideoCapture1.Video_Effects_Get("Invert");
        if (effect == null)
        {
            invert = new VideoEffectInvert(cbInvert.IsChecked == true);
            VideoCapture1.Video_Effects_Add(invert);
        }
        else
        {
            invert = effect as IVideoEffectInvert;
            if (invert != null)
            {
                invert.Enabled = cbInvert.IsChecked == true;
            }
        }
    }

    private void CreateEngine()
    {
        VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);

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

    private static async Task<string> SaveFileDialog(Window window, string defaultExt)
    {
        FileSavePicker save = new FileSavePicker();
        save.SuggestedStartLocation = PickerLocationId.VideosLibrary;
        // save.FileTypeChoices = defaultExt;

        var m_hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        WinRT.Interop.InitializeWithWindow.Initialize(save, m_hwnd);

        var file = await save.PickSaveFileAsync();
        if (file != null)
        {
            return file.Path;
        }

        return null;
    }

    private void btAudioInputDeviceSettings_Click(object sender, RoutedEventArgs e)
    {
        VideoCapture1.Audio_CaptureDevice_SettingsDialog_Show(IntPtr.Zero, cbAudioInputDevice.SelectedValue.ToString());
    }

    private void Log(string txt)
    {
        DispatcherQueue.TryEnqueue(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
    }

    private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
    {
        Log(e.Message);
    }

    private void cbVideoInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbVideoInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
        {
            cbVideoInputFormat.Items.Clear();

            var deviceItem =
                VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                cbVideoInputFormat.Items.Add(format);
            }

            if (cbVideoInputFormat.Items.Count > 0)
            {
                cbVideoInputFormat.SelectedIndex = 0;
                cbVideoInputFormat_SelectionChanged(null, null);
            }

            btVideoCaptureDeviceSettings.IsEnabled = deviceItem.DialogDefault;
        }
    }

    private void cbAudioInputDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
        {
            cbAudioInputFormat.Items.Clear();

            var deviceItem = VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            var defaultValue = "PCM, 44100 Hz, 16 Bits, 2 Channels";
            var defaultValueExists = false;
            foreach (string format in deviceItem.Formats)
            {
                cbAudioInputFormat.Items.Add(format);

                if (defaultValue == format)
                {
                    defaultValueExists = true;
                }
            }

            if (cbAudioInputFormat.Items.Count > 0)
            {
                cbAudioInputFormat.SelectedIndex = 0;

                if (defaultValueExists)
                {
                    cbAudioInputFormat.Text = defaultValue;
                }
            }

            cbAudioInputLine.Items.Clear();

            foreach (var line in deviceItem.Lines)
            {
                cbAudioInputLine.Items.Add(line);
            }

            if (cbAudioInputLine.Items.Count > 0)
            {
                cbAudioInputLine.SelectedIndex = 0;
            }

            btAudioInputDeviceSettings.IsEnabled = deviceItem.DialogDefault;
        }
    }

    private async void btStart_Click(object sender, RoutedEventArgs e)
    {
        VideoView1.Background = new SolidColorBrush(new Color { A = 0, R = 0, G = 0, B = 0 });

        mmLog.Text = string.Empty;

        VideoCapture1.Video_Sample_Grabber_Enabled = true;

        VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
        VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

        VideoCapture1.Audio_OutputDevice = "Default DirectSound Device";

        if (cbRecordAudio.IsChecked == true)
        {
            VideoCapture1.Audio_RecordAudio = true;
            VideoCapture1.Audio_PlayAudio = true;
        }
        else
        {
            VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Audio_PlayAudio = false;
        }

        VideoCapture1.Audio_OutputDevice = cbAudioOutputDevice.SelectedValue.ToString();

        // apply capture params
        VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbVideoInputDevice.SelectedValue.ToString());
        VideoCapture1.Video_CaptureDevice.Format = cbVideoInputFormat.SelectedValue.ToString();

        VideoCapture1.Audio_CaptureDevice = new AudioCaptureSource(cbAudioInputDevice.SelectedValue.ToString());
        VideoCapture1.Audio_CaptureDevice.Format = cbAudioInputFormat.SelectedValue.ToString();

        if (cbVideoInputFrameRate.SelectedIndex != -1)
        {
            VideoCapture1.Video_CaptureDevice.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.SelectedValue.ToString()));
        }

        if (rbPreview.IsChecked == true)
        {
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
        }
        else
        {
            VideoCapture1.Mode = VideoCaptureMode.VideoCapture;

            VideoCapture1.Output_Filename = edOutput.Text;

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        var aviOutput = new AVIOutput();
                        VideoCapture1.Output_Format = aviOutput;

                        break;
                    }
                case 1:
                    {
                        var wmvOutput = new WMVOutput();
                        VideoCapture1.Output_Format = wmvOutput;

                        break;
                    }
                case 2:
                    {
                        var mp4Output = new MP4Output();
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 3:
                    {
                        var mp4Output = new MP4HWOutput();
                        VideoCapture1.Output_Format = mp4Output;

                        break;
                    }
                case 4:
                    {
                        var gifOutput = new AnimatedGIFOutput();
                        VideoCapture1.Output_Format = gifOutput;

                        break;
                    }
                case 5:
                    {
                        var tsOutput = new MPEGTSOutput();
                        VideoCapture1.Output_Format = tsOutput;

                        break;
                    }
                case 6:
                    {
                        var movOutput = new MOVOutput();
                        VideoCapture1.Output_Format = movOutput;

                        break;
                    }
            }
        }

        VideoCapture1.Video_Effects_Enabled = true;
        VideoCapture1.Video_Effects_Clear();
        ConfigureVideoEffects();

        await VideoCapture1.StartAsync();

        tcMain.SelectedIndex = 3;
        tmRecording.Start();
    }

    private void ConfigureVideoEffects()
    {
        if (tbLightness.Value > 0)
        {
            tbLightness_ValueChanged(null, null);
        }

        if (tbSaturation.Value < 255)
        {
            tbSaturation_ValueChanged(null, null);
        }

        if (tbContrast.Value > 0)
        {
            tbContrast_ValueChanged(null, null);
        }

        if (tbDarkness.Value > 0)
        {
            tbDarkness_ValueChanged(null, null);
        }

        if (cbGreyscale.IsChecked == true)
        {
            cbGreyscale_Click(null, null);
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

    private void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
        {
            return;
        }

        if (cbVideoInputDevice.SelectedIndex != -1)
        {
            var deviceItem = VideoCapture1.Video_CaptureDevices().FirstOrDefault(device => device.Name == cbVideoInputDevice.SelectedValue.ToString());
            if (deviceItem == null)
            {
                return;
            }

            var videoFormat = deviceItem.VideoFormats.FirstOrDefault(format => format.Name == cbVideoInputFormat.SelectedValue.ToString());
            if (videoFormat == null)
            {
                return;
            }

            cbVideoInputFrameRate.Items.Clear();
            foreach (var frameRate in videoFormat.FrameRates)
            {
                cbVideoInputFrameRate.Items.Add(frameRate.ToString(CultureInfo.CurrentCulture));
            }

            if (cbVideoInputFrameRate.Items.Count > 0)
            {
                cbVideoInputFrameRate.SelectedIndex = 0;
            }
        }
    }

    private void UpdateRecordingTime()
    {
        var ts = VideoCapture1.Duration_Time();

        if (Math.Abs(ts.TotalMilliseconds) < 0.01)
        {
            return;
        }

        DispatcherQueue.TryEnqueue(() =>
        {
            lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
        });
    }

    private void cbInvert_CheckedChanged(object sender, RoutedEventArgs e)
    {

    }

    private void cbFlipX_Checked(object sender, RoutedEventArgs e)
    {
        IVideoEffectFlipDown flip;
        var effect = VideoCapture1.Video_Effects_Get("FlipDown");
        if (effect == null)
        {
            flip = new VideoEffectFlipHorizontal(cbFlipX.IsChecked == true);
            VideoCapture1.Video_Effects_Add(flip);
        }
        else
        {
            flip = effect as IVideoEffectFlipDown;
            if (flip != null)
            {
                flip.Enabled = cbFlipX.IsChecked == true;
            }
        }
    }

    private void cbFlipY_Checked(object sender, RoutedEventArgs e)
    {
        IVideoEffectFlipRight flip;
        var effect = VideoCapture1.Video_Effects_Get("FlipRight");
        if (effect == null)
        {
            flip = new VideoEffectFlipVertical(cbFlipY.IsChecked == true);
            VideoCapture1.Video_Effects_Add(flip);
        }
        else
        {
            flip = effect as IVideoEffectFlipRight;
            if (flip != null)
            {
                flip.Enabled = cbFlipY.IsChecked == true;
            }
        }
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        DestroyEngine();
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

    private void cbTextLogo_Click(object sender, RoutedEventArgs e)
    {
        IVideoEffectTextLogo textLogo;
        var effect = VideoCapture1.Video_Effects_Get("TextLogo");
        if (effect == null)
        {
            textLogo = new VideoEffectTextLogo(cbTextLogo.IsChecked == true) { Text = "Hello world!" };
            VideoCapture1.Video_Effects_Add(textLogo);
        }
        else
        {
            textLogo = effect as IVideoEffectTextLogo;
            if (textLogo != null)
            {
                textLogo.Enabled = cbTextLogo.IsChecked == true;
            }
        }
    }

    private void cbImageLogo_Click(object sender, RoutedEventArgs e)
    {
        IVideoEffectImageLogo textLogo;
        var effect = VideoCapture1.Video_Effects_Get("ImageLogo");
        if (effect == null)
        {
            var imagePath = Path.Combine(Package.Current.InstalledLocation.Path, "Assets", "LogoOverlay.png");
            textLogo = new VideoEffectImageLogo(cbImageLogo.IsChecked == true) { Filename = imagePath };
            VideoCapture1.Video_Effects_Add(textLogo);
        }
        else
        {
            textLogo = effect as IVideoEffectImageLogo;
            if (textLogo != null)
            {
                textLogo.Enabled = cbImageLogo.IsChecked == true;
            }
        }
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
        catch
        {
        }
    }

    private void Window_Activated(object sender, WindowActivatedEventArgs args)
    {
        if (VideoCapture1 != null)
        {
            return;
        }

        CreateEngine();

        Title = $"Video Capture SDK .Net - Simple Video Capture Demo for WinUI 3 Desktop (SDK v{VideoCapture1.SDK_Version()})";

        _videoViewBackgroud = ((SolidColorBrush)VideoView1.Background).Color;

        SetIcon();

        tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

        cbOutputFormat.SelectedIndex = 2;

        foreach (var device in VideoCapture1.Video_CaptureDevices())
        {
            cbVideoInputDevice.Items.Add(device.Name);
        }

        if (cbVideoInputDevice.Items.Count > 0)
        {
            cbVideoInputDevice.SelectedIndex = 0;
        }

        cbVideoInputDevice_SelectionChanged(null, null);

        foreach (var device in VideoCapture1.Audio_CaptureDevices())
        {
            cbAudioInputDevice.Items.Add(device.Name);
        }

        if (cbAudioInputDevice.Items.Count > 0)
        {
            cbAudioInputDevice.SelectedIndex = 0;
            cbAudioInputDevice_SelectionChanged(null, null);
        }

        cbAudioInputLine.Items.Clear();

        if (!string.IsNullOrEmpty(cbAudioInputDevice.SelectedValue.ToString()))
        {
            var deviceItem =
                VideoCapture1.Audio_CaptureDevices().FirstOrDefault(device => device.Name == cbAudioInputDevice.SelectedValue.ToString());
            if (deviceItem != null)
            {
                foreach (var line in deviceItem.Lines)
                {
                    cbAudioInputLine.Items.Add(line);
                }

                if (cbAudioInputLine.Items.Count > 0)
                {
                    cbAudioInputLine.SelectedIndex = 0;
                }
            }
        }

        string defaultAudioRenderer = string.Empty;
        foreach (string audioOutputDevice in VideoCapture1.Audio_OutputDevices())
        {
            cbAudioOutputDevice.Items.Add(audioOutputDevice);

            if (audioOutputDevice.Contains("Default DirectSound Device"))
            {
                defaultAudioRenderer = audioOutputDevice;
            }
        }

        if (cbAudioOutputDevice.Items.Count > 0)
        {
            if (string.IsNullOrEmpty(defaultAudioRenderer))
            {
                cbAudioOutputDevice.SelectedIndex = 0;
            }
            else
            {
                cbAudioOutputDevice.SelectedValue = defaultAudioRenderer;
            }
        }

        edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
    }
}
