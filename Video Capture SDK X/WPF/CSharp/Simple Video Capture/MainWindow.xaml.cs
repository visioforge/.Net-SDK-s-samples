using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using VisioForge.Core;
using VisioForge.Core.Helpers;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.VideoEffects;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI;
using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
using VisioForge.Core.VideoCaptureX;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Interaction logic for the Simple Video Capture WPF demo's MainWindow.
    /// Provides a comprehensive interface for video/audio capture, preview, and effect management.
    /// </summary>
    public partial class MainWindow : IDisposable
    {
        private UniversalOutputDialog mpegTSSettingsDialog;

        private UniversalOutputDialog movSettingsDialog;

        private UniversalOutputDialog mp4SettingsDialog;

        private UniversalOutputDialog aviSettingsDialog;

        private UniversalOutputDialog webMSettingsDialog;

        private readonly Microsoft.Win32.SaveFileDialog screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        };

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCoreX VideoCapture1;

        private bool disposedValue;

        public MainWindow()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Handles the OnAudioSinkAdded event of the DeviceEnumerator.
        /// Adds newly discovered audio output devices to the UI selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioOutputDeviceInfo"/> instance containing device information.</param>
        private void DeviceEnumerator_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioOutputDevice.Items.Add(e.DisplayName);

                if (cbAudioOutputDevice.Items.Count == 1)
                {
                    cbAudioOutputDevice.SelectedIndex = 0;
                }
            });
        }

        /// <summary>
        /// Handles the OnAudioSourceAdded event of the DeviceEnumerator.
        /// Adds newly discovered audio input devices to the UI selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="AudioCaptureDeviceInfo"/> instance containing device information.</param>
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

        /// <summary>
        /// Handles the OnVideoSourceAdded event of the DeviceEnumerator.
        /// Adds newly discovered video input devices to the UI selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VideoCaptureDeviceInfo"/> instance containing device information.</param>
        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInputDevice.Items.Add(e.DisplayName);

                if (cbVideoInputDevice.Items.Count == 1)
                {
                    cbVideoInputDevice.SelectedIndex = 0;
                }
            });
        }

        /// <summary>
        /// Creates the video capture engine and subscribes to essential events.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.OnAudioVUMeter += VideoCapture1_OnAudioVUMeter;
        }

        /// <summary>
        /// Handles the OnAudioVUMeter event of the VideoCapture1 control.
        /// Updates the UI VU meter with current amplitude levels.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="VisioForge.Core.Types.X.VUMeterXEventArgs"/> instance containing VU meter data.</param>
        private void VideoCapture1_OnAudioVUMeter(object sender, VisioForge.Core.Types.X.VUMeterXEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                vumeter.Amplitude = (float)e.MeterData.Peak[0];
                vumeter.Update();
                //Debug.WriteLine($"VU: {e.MeterData.Peak[0]}");
            });
        }

        /// <summary>
        /// Disposes of the video capture engine and unsubscribes from events.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.OnAudioVUMeter -= VideoCapture1_OnAudioVUMeter;

                await VideoCapture1.DisposeAsync();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Displays a save file dialog and returns the selected filename.
        /// </summary>
        /// <param name="defaultExt">The default extension.</param>
        /// <param name="filter">The file filter.</param>
        /// <param name="filename">The selected filename.</param>
        /// <returns>True if a file was selected; otherwise, false.</returns>
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

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// Initializes the SDK, starts device monitoring, and sets up the engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");

            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;
            DeviceEnumerator.Shared.OnAudioSinkAdded += DeviceEnumerator_OnAudioSinkAdded;

            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a dialog to select the output file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            if (SaveFileDialog("*.mp4; *.webm; *.ts; *.avi; *.mov", "Video files|*.mp4; *.webm; *.ts; *.avi; *.mov", out filename))
            {
                edOutput.Text = filename;
            }
        }

        /// <summary>
        /// Log.
        /// </summary>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Handles the OnError event of the VideoCapture1 control.
        /// Logs error messages to the UI.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Tb audio volume value changed.
        /// </summary>
        private void tbAudioVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            VideoCapture1.Audio_OutputDevice_Volume = tbAudioVolume.Value / 100.0f;
        }

        /// <summary>
        /// Lb view video tutorials mouse left button down.
        /// </summary>
        private void lbViewVideoTutorials_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the cbVideoInputDevice control.
        /// Populates the video input formats for the selected device.
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
        /// Handles the SelectionChanged event of the cbAudioInputDevice control.
        /// Populates the audio input formats for the selected device.
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
        
        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine and starts the video capture or preview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync()).Where(device => device.DisplayName == cbAudioOutputDevice.Text).First();
            VideoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

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

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInputDevice.Text;
            var format = cbVideoInputFormat.Text;
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

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoInputFrameRate.Text));
                    }
                }
            }

            VideoCapture1.Video_Source = videoSourceSettings;

            // audio source
            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInputDevice.Text;
            format = cbAudioInputFormat.Text;
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

            if (rbPreview.IsChecked == true)
            {
            }
            else
            {
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
                            if (mp4SettingsDialog == null)
                            {
                                var mp4 = new MP4Output(edOutput.Text);
                                mp4.Sink = new MP4SplitSinkSettings(edOutput.Text) { SplitDuration = TimeSpan.FromSeconds(10)};
                                VideoCapture1.Outputs_Add(mp4, false);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mp4SettingsDialog.GetOutputVC(), false);
                            }

                            break;
                        }
                    case 2:
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
                    case 3:
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
                    case 4:
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
                    case 5:
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

            await ConfigureVideoEffectsAsync();

            // VU meter
            if (cbVUMeter.IsChecked == true)
            {
                VideoCapture1.Audio_VU_Meter_Enabled = true;
                vumeter.Start();
            }
            else
            {
                VideoCapture1.Audio_VU_Meter_Enabled = false;
            }

            VideoCapture1.Snapshot_Grabber_Enabled = true;

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();

            //VideoCapture1.Debug_SavePipeline("videocapturex");
        }

        /// <summary>
        /// Asynchronously configures video effects based on current UI settings.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task ConfigureVideoEffectsAsync()
        {
            VideoCapture1.Video_Effects_Clear();

            if (cbVideoBalance.IsChecked == true)
            {
                var balance = new VideoBalanceVideoEffect();
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(balance);

                tbBrightness_Scroll(null, null);
                tbSaturation_Scroll(null, null);
                tbContrast_Scroll(null, null);
                tbHue_Scroll(null, null);
            }
                            
            if (cbGreyscale.IsChecked == true)
            {
                cbGreyscale_CheckedChanged(null, null);
            }

            if (cbSepia.IsChecked == true)
            {
                cbSepia_CheckedChanged(null, null);
            }

            if (cbFlipX.IsChecked == true)
            {
                cbFlipX_Checked(null, null);
            }

            if (cbFlipY.IsChecked == true)
            {
                cbFlipY_Checked(null, null);
            }

            if (cbTextLogo.IsChecked == true)
            {
                cbTextLogo_Click(null, null);
            }

            if (cbImageLogo.IsChecked == true)
            {
                cbImageLogo_Click(null, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btResume control.
        /// Resumes the video capture engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        /// <summary>
        /// Handles the Click event of the btPause control.
        /// Pauses the video capture engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video capture engine and resets recording time.
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
        /// Populates the available frame rates for the selected video input format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private async void cbVideoInputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbVideoInputFrameRate.Items.Clear();

            if (string.IsNullOrEmpty(cbVideoInputFormat.SelectedValue?.ToString()) || string.IsNullOrEmpty(cbVideoInputDevice.SelectedValue.ToString()))
            {
                return;
            }

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

        /// <summary>
        /// Handles the Click event of the btSaveScreenshot control.
        /// Captures a snapshot of the current video frame and saves it to a file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog() == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Bmp);
                        break;
                    case ".jpg":
                        await VideoCapture1.Snapshot_SaveAsync(filename, SkiaSharp.SKEncodedImageFormat.Jpeg, 85);
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
        /// Handles the Click event of the btOutputConfigure control.
        /// Opens a configuration dialog for the selected output format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btOutputConfigure_Click(object sender, RoutedEventArgs e)
        {
            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                case 1:
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
                case 2:
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
                case 3:
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
                case 4:
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
                case 5:
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

        /// <summary>
        /// Handles the SelectionChanged event of the cbOutputFormat control.
        /// Updates the output file extension based on the selected format.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cbOutputFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (edOutput == null)
            {
                return;
            }

            switch (cbOutputFormat.SelectedIndex)
            {
                case 0:
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 2:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".avi");
                        break;
                    }
                case 3:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm"); 
                        break;
                    }
                case 4:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".ts");
                        break;
                    }
                case 5:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mov");
                        break;
                    }
            }
        }

        /// <summary>
        /// Periodically updates the recording time displayed in the UI.
        /// </summary>
        private async void UpdateRecordingTime()
        {
            var ts = await VideoCapture1.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.Invoke((Action)(() =>
            {
                lbTimestamp.Text = "Duration: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the Checked and Unchecked events of the cbGreyscale control.
        /// Adds or removes the grayscale video effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbGreyscale_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (cbGreyscale.IsChecked == true)
            {
                var grayscale = new GrayscaleVideoEffect();
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(grayscale);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(GrayscaleVideoEffect.DefaultName);
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbContrast control.
        /// Updates the contrast value of the video balance effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbContrast_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            var balanceEffect = (VideoBalanceVideoEffect)VideoCapture1.Video_Effects_Get(VideoBalanceVideoEffect.DefaultName);
            if (balanceEffect != null)
            {
                balanceEffect.Contrast = tbContrast.Value / 100.0;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbHue control.
        /// Updates the hue value of the video balance effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbHue_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            var balanceEffect = (VideoBalanceVideoEffect)VideoCapture1.Video_Effects_Get(VideoBalanceVideoEffect.DefaultName);
            if (balanceEffect != null)
            {
                balanceEffect.Hue = tbHue.Value / 100.0;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbBrightness control.
        /// Updates the brightness value of the video balance effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbBrightness_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            var balanceEffect = (VideoBalanceVideoEffect)VideoCapture1.Video_Effects_Get(VideoBalanceVideoEffect.DefaultName);
            if (balanceEffect != null)
            {
                balanceEffect.Brightness = tbBrightness.Value / 100.0;
            }            
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbSaturation control.
        /// Updates the saturation value of the video balance effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbSaturation_Scroll(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            var balanceEffect = (VideoBalanceVideoEffect)VideoCapture1.Video_Effects_Get(VideoBalanceVideoEffect.DefaultName);
            if (balanceEffect != null)
            {
                balanceEffect.Saturation = tbSaturation.Value / 100.0;
            }
        }

        /// <summary>
        /// Handles the Checked and Unchecked events of the cbSepia control.
        /// Adds or removes the sepia color effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbSepia_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (cbSepia.IsChecked == true)
            {
                var effect = new ColorEffectsVideoEffect(ColorEffectsPreset.Sepia);
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(effect);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(ColorEffectsVideoEffect.DefaultName);
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        private async void cbFlipX_Checked(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (cbFlipX.IsChecked == true)
            {
                var flip = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodHorizontal, "flipx");
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(flip);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove("flipx");
            }
        }

        /// <summary>
        /// Cb flip checked.
        /// </summary>
        private async void cbFlipY_Checked(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (cbFlipY.IsChecked == true)
            {
                var flip = new FlipRotateVideoEffect(VideoFlipRotateMethod.MethodVertical, "flipy");
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(flip);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove("flipy");
            }
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// Stops the engine and releases SDK resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Bt start capture.
        /// </summary>
        private async void btStartCapture(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (VideoCapture1.Outputs_Count() == 0)
            {
                MessageBox.Show("Please add output first.");
                return;
            }

            var output = VideoCapture1.Outputs_Get(0);

            // check if it is split MP4 sink to create segmented file
            if (output is MP4Output mp4 && mp4.Sink is MP4SplitSinkSettings)
            {
                var filename = Path.Combine(Path.GetDirectoryName(edOutput.Text), Path.GetFileNameWithoutExtension(edOutput.Text) + "_%02d.mp4");
                await VideoCapture1.StartCaptureAsync(0, filename);
            }
            else
            {
                await VideoCapture1.StartCaptureAsync(0, edOutput.Text);
            }
            
        }

        /// <summary>
        /// Bt stop capture.
        /// </summary>
        private async void btStopCapture(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopCaptureAsync(0);
        }

        /// <summary>
        /// Handles the cb text logo click event.
        /// </summary>
        private async void cbTextLogo_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (cbTextLogo.IsChecked == true)
            {
                var effect = new TextOverlayVideoEffect();
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(effect);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(TextOverlayVideoEffect.DefaultName);
            }
        }

        /// <summary>
        /// Handles the Checked and Unchecked events of the cbImageLogo control.
        /// Adds or removes the image logo video effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbImageLogo_Click(object sender, RoutedEventArgs e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            if (cbImageLogo.IsChecked == true)
            {
                var effect = new ImageOverlayVideoEffect("logo.png");
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(effect);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(ImageOverlayVideoEffect.DefaultName);
            }
        }

        /// <summary>
        /// Handles the Click event of the cbVideoBalance control.
        /// Adds or removes the video balance effect and updates its settings.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbVideoBalance_Click(object sender, RoutedEventArgs e)
        {
            if (cbVideoBalance.IsChecked == true)
            {
                var effect = new VideoBalanceVideoEffect();
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(effect);

                tbBrightness_Scroll(null, null);
                tbSaturation_Scroll(null, null);
                tbContrast_Scroll(null, null);
                tbHue_Scroll(null, null);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(VideoBalanceVideoEffect.DefaultName);
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectLUT control.
        /// Opens a file dialog to select a Look-Up Table (LUT) file.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectLUT_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
            };

            if (dlg.ShowDialog() == true)
            {
                edLUTPath.Text = dlg.FileName;
            }
        }
        
        /// <summary>
        /// Handles the Checked and Unchecked events of the cbLUT control.
        /// Adds or removes the LUT video effect.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void cbLUT_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (cbLUT.IsChecked == true)
            {
                var effect = new LUTVideoEffect(edLUTPath.Text);
                await VideoCapture1.Video_Effects_AddOrUpdateAsync(effect);
            }
            else
            {
                VideoCapture1.Video_Effects_Remove(LUTVideoEffect.DefaultName);
            }
        }

        #region Dispose

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
                    tmRecording?.Dispose();
                    tmRecording = null;
                }

                disposedValue = true;
            }
        }

        ~MainWindow()
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

        #endregion

    }
}
