// ReSharper disable InconsistentNaming
// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601
// ReSharper disable RedundantNameQualifier

namespace Screen_Capture_X
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms;
    using System.Windows.Input;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.MediaBlocks.Sources;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoCapture;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WinForms.Dialogs;
    using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
    using VisioForge.Core.VideoCaptureX;

    public partial class Window1 : IDisposable
    {
        private UniversalOutputDialog mpegTSSettingsDialog;

        private UniversalOutputDialog movSettingsDialog;

        private UniversalOutputDialog mp4SettingsDialog;

        private UniversalOutputDialog aviSettingsDialog;

        private UniversalOutputDialog webMSettingsDialog;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCoreX VideoCapture1;

        private WindowCaptureForm windowCaptureForm;

        private bool disposedValue;

        public Window1()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();

            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInputDevice.Items.Add(e.DisplayName);

                if (cbAudioInputDevice.Items.Count == 1)
                {
                    cbAudioInputDevice.SelectedIndex = 0;
                }
            });
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                await VideoCapture1.DisposeAsync();
                VideoCapture1 = null;
            }
        }

        private static bool SaveFileDialog(string defaultExt, string filter, out string filename)
        {
            filename = string.Empty;

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = defaultExt,
                Filter = filter
            };

            if (dlg.ShowDialog() == true)
            {
                filename = dlg.FileName;
                return true;
            }

            return false;
        }

        private void btScreenCaptureUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1.Video_Source is IScreenCaptureSourceSettings screen)
            {
                screen.UpdateLiveSettings(
                                       Convert.ToInt32(edScreenLeft.Text),
                                       Convert.ToInt32(edScreenTop.Text),
                                       cbScreenCapture_GrabMouseCursor.IsChecked == true);
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            if (SaveFileDialog("*.mp4; *.webm; *.ts; *.avi; *.mov", "Video files|*.mp4; *.webm; *.ts; *.avi; *.mov", out filename))
            {
                edOutput.Text = filename;
            }
        }

        private IScreenCaptureSourceSettings CreateWindowCaptureSource()
        {
            // create Direct3D11 source
            var source = new ScreenCaptureD3D11SourceSettings();
            source.API = D3D11ScreenCaptureAPI.WGC;

            // set frame rate
            source.FrameRate = new VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text));

            // get handle of the window
            source.WindowHandle = windowCaptureForm.CapturedWindowHandle;

            return source;
        }

        private IScreenCaptureSourceSettings CreateScreenCaptureSource()
        {
            var screenID = Convert.ToInt32(cbScreenCaptureDisplayIndex.Text);

            var source = new ScreenCaptureDX9SourceSettings();

            source.FrameRate = new VideoFrameRate(Convert.ToDouble(edScreenFrameRate.Text));

            if (rbScreenFullScreen.IsChecked == true)
            {
                for (int i = 0; i < System.Windows.Forms.Screen.AllScreens.Length; i++)
                {
                    if (i == screenID)
                    {
                        source.Rectangle = new VisioForge.Core.Types.Rect(System.Windows.Forms.Screen.AllScreens[i].Bounds);
                    }
                }
            }
            else
            {
                source.Rectangle = new VisioForge.Core.Types.Rect(
                    Convert.ToInt32(edScreenLeft.Text),
                    Convert.ToInt32(edScreenTop.Text),
                    Convert.ToInt32(edScreenRight.Text),
                    Convert.ToInt32(edScreenBottom.Text));
            }

            source.CaptureCursor = cbScreenCapture_GrabMouseCursor.IsChecked == true;
            source.Monitor = screenID;

            return source;
        }

        private void btOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        MP4Output mp4;
                        if (mp4SettingsDialog == null)
                        {
                            mp4 = new MP4Output(edOutput.Text);
                        }
                        else
                        {
                            mp4 = (MP4Output)mp4SettingsDialog.GetOutput();
                        }

                        mp4SettingsDialog = new UniversalOutputDialog(mp4);
                        mp4SettingsDialog.ShowDialog();

                        break;
                    }
                case 1:
                    {
                        AVIOutput avi;
                        if (aviSettingsDialog == null)
                        {
                            avi = new AVIOutput(edOutput.Text);
                        }
                        else
                        {
                            avi = (AVIOutput)aviSettingsDialog.GetOutput();
                        }

                        aviSettingsDialog = new UniversalOutputDialog(avi);
                        aviSettingsDialog.ShowDialog();

                        break;
                    }
                case 2:
                    {
                        WebMOutput webm;
                        if (webMSettingsDialog == null)
                        {
                            webm = new WebMOutput(edOutput.Text);
                        }
                        else
                        {
                            webm = (WebMOutput)webMSettingsDialog.GetOutput();
                        }

                        webMSettingsDialog = new UniversalOutputDialog(webm);
                        webMSettingsDialog.ShowDialog();

                        break;
                    }
                case 3:
                    {
                        MPEGTSOutput ts;
                        if (mpegTSSettingsDialog == null)
                        {
                            ts = new MPEGTSOutput(edOutput.Text);
                        }
                        else
                        {
                            ts = (MPEGTSOutput)mpegTSSettingsDialog.GetOutput();
                        }

                        mpegTSSettingsDialog = new UniversalOutputDialog(ts);
                        mpegTSSettingsDialog.ShowDialog();

                        break;
                    }
                case 4:
                    {
                        MOVOutput mov;
                        if (movSettingsDialog == null)
                        {
                            mov = new MOVOutput(edOutput.Text);
                        }
                        else
                        {
                            mov = (MOVOutput)movSettingsDialog.GetOutput();
                        }

                        movSettingsDialog = new UniversalOutputDialog(mov);
                        movSettingsDialog.ShowDialog();

                        break;
                    }
            }
        }

        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null)
            {
                return;
            }

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
                    }
            }
        }

        private async void btStartCapture(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StartCaptureAsync(0, edOutput.Text);
        }

        private async void btStopCapture(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopCaptureAsync(0);
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_Play = false;
            if (cbRecordAudio.IsChecked == true)
            {
                VideoCapture1.Audio_Record = true;
            }
            else
            {
                VideoCapture1.Audio_Record = false;
            }

            // video source
            if (rbWindow.IsChecked == true)
            {
                VideoCapture1.Video_Source = CreateWindowCaptureSource();
            }
            else
            {
                // screen source
                VideoCapture1.Video_Source = CreateScreenCaptureSource();
            }

            if (rbCapture.IsChecked == true)
            {
                // audio source
                if (VideoCapture1.Audio_Record)
                {
                    IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;
                    if (rbSystemAudio.IsChecked == true)
                    {
                        var deviceName = cbAudioInputDevice.Text;
                        var format = cbAudioInputFormat.Text;
                        if (!string.IsNullOrEmpty(deviceName))
                        {
                            var sources = await DeviceEnumerator.Shared.AudioSourcesAsync();
                            var device = sources.FirstOrDefault(x => x.DisplayName == deviceName);
                            if (device != null)
                            {
                                var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                                if (formatItem != null)
                                {
                                    audioSourceSettings = device.CreateSourceSettingsVC(formatItem.ToFormat());
                                }
                            }
                        }
                    }
                    else
                    {
                        var deviceItem = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.WASAPI2)).FirstOrDefault(device => device.Name == cbAudioLoopbackDevice.Text);
                        if (deviceItem == null)
                        {
                            return;
                        }

                        audioSourceSettings = new LoopbackAudioCaptureDeviceSourceSettings(deviceItem);
                    }

                    VideoCapture1.Audio_Source = audioSourceSettings;
                }

                // outputs
                VideoCapture1.Outputs_Clear();

                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            if (mp4SettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MP4Output(edOutput.Text), false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mp4SettingsDialog.GetOutputVC(), false);
                            }

                            break;
                        }
                    case 1:
                        {
                            if (aviSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new AVIOutput(edOutput.Text), false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(aviSettingsDialog.GetOutputVC(), false);
                            }

                            break;
                        }
                    case 2:
                        {
                            if (webMSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new WebMOutput(edOutput.Text), false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(webMSettingsDialog.GetOutputVC(), false);
                            }

                            break;
                        }
                    case 3:
                        {
                            if (mpegTSSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MPEGTSOutput(edOutput.Text), false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mpegTSSettingsDialog.GetOutputVC(), false);
                            }


                            break;
                        }
                    case 4:
                        {
                            if (movSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MOVOutput(edOutput.Text), false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(movSettingsDialog.GetOutputVC(), false);
                            }

                            break;
                        }
                }
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 2;
            tmRecording.Start();

            //VideoCapture1.Debug_SavePipeline("videocapturex");
        }

        private void UpdateRecordingTime()
        {
            var ts = VideoCapture1.Duration();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
           {
               lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
           }));
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            // audio input
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();

            // monitors
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                cbScreenCaptureDisplayIndex.Items.Add(i.ToString());
            }

            // enumerate audio sinks
            var audioSinks = await DeviceEnumerator.Shared.AudioOutputsAsync();
            foreach (var sink in audioSinks)
            {
                if (sink.API == AudioOutputDeviceAPI.WASAPI2)
                {
                    cbAudioLoopbackDevice.Items.Add(sink.Name);

                    if (cbAudioLoopbackDevice.Items.Count == 1)
                    {
                        cbAudioLoopbackDevice.SelectedIndex = 0;
                    }
                }
            }

            cbScreenCaptureDisplayIndex.SelectedIndex = 0;

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }


        private async void cbAudioInputDevice_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAudioInputDevice.SelectedIndex != -1 && e != null && e.AddedItems.Count > 0)
            {
                cbAudioInputFormat.Items.Clear();

                var deviceItem = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(device => device.DisplayName == e.AddedItems[0].ToString());
                if (deviceItem == null)
                {
                    return;
                }

                var defaultValue = "S16LE 44100 Hz 2 ch.";
                var defaultValueExists = false;
                foreach (var format in deviceItem.Formats)
                {
                    cbAudioInputFormat.Items.Add(format.Name);

                    if (defaultValue == format.Name)
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
            }
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void lbViewVideoTutorials_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void btSelectWindow_Click(object sender, RoutedEventArgs e)
        {
            if (windowCaptureForm == null)
            {
                windowCaptureForm = new WindowCaptureForm();
                windowCaptureForm.OnCaptureHotkey += WindowCaptureForm_OnCaptureHotkey;
            }

            windowCaptureForm.StartCapture();
        }

        private void WindowCaptureForm_OnCaptureHotkey(object sender, WindowCaptureEventArgs e)
        {
            windowCaptureForm.StopCapture();
            windowCaptureForm.Hide();

            rbWindow.Content = "Window: " + e.Caption;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    tmRecording?.Dispose();
                    tmRecording = null;
                }

                disposedValue = true;
            }
        }

        ~Window1()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

// ReSharper restore InconsistentNaming