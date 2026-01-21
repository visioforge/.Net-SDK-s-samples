using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core;
using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using System.Diagnostics;
using System.Windows.Input;
using VisioForge.Core.Helpers;
using System.IO;
using VisioForge.Core.UI;
using System.Windows.Controls;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.AudioRenderers;

namespace Decklink_Demo_X
{
    /// <summary>
    /// Interaction logic for the Decklink Demo X WPF demo's MainWindow.
    /// Demonstrates how to discover and capture from Blackmagic Decklink devices using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private UniversalOutputDialog mp4SettingsDialog;
                
        private UniversalOutputDialog webMSettingsDialog;

        private readonly Microsoft.Win32.SaveFileDialog screenshotSaveDialog = new Microsoft.Win32.SaveFileDialog()
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
        };

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        private VideoCaptureCoreX VideoCapture1;

        private bool disposedValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of the video capture engine and configures error event handling.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        /// <summary>
        /// Asynchronously disposes of the video capture engine and cleans up events.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DestroyEngineAsync()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;

                await VideoCapture1.DisposeAsync();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Displays a save file dialog and returns the selected filename.
        /// </summary>
        /// <param name="defaultExt">The default extension.</param>
        /// <param name="filter">The file filter string.</param>
        /// <param name="filename">The output filename.</param>
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
        /// Handles the Loaded event of the window.
        /// Initializes the SDK and populates the UI with Decklink devices, modes, and audio outputs.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            cbOutputFormat.SelectedIndex = 0;

            var videoCaptureDevices = await DeviceEnumerator.Shared.DecklinkVideoSourcesAsync();
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = await DeviceEnumerator.Shared.DecklinkAudioSourcesAsync();
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var audioOutputDevices = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).ToArray();
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item);
                }

                cbAudioOutput.SelectedIndex = 0;
            }

            var decklinkModes = Enum.GetValues(typeof(DecklinkMode));
            foreach (var item in decklinkModes)
            {
                cbVideoMode.Items.Add(item.ToString());
            }

            cbVideoMode.SelectedIndex = 0;

            edOutput.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
        }

        /// <summary>
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a save file dialog to specify the recording output path.
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
        /// Logs a message to the UI log window.
        /// </summary>
        /// <param name="txt">The message to log.</param>
        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        /// <summary>
        /// Handles the OnError event of the VideoCapture1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the error information.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbVolume control.
        /// Updates the output audio volume.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (VideoCapture1 == null)
            {
                return;
            }

            VideoCapture1.Audio_OutputDevice_Volume = tbVolume.Value / 100.0f;
        }

        /// <summary>
        /// Handles the MouseLeftButtonDown event of the lbViewVideoTutorials control.
        /// Opens the video tutorials URL in the default browser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void lbViewVideoTutorials_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine for Decklink capture with selected video/audio settings and starts the stream.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First();
            VideoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice);

            VideoCapture1.Audio_Record = true;
            VideoCapture1.Audio_Play = true;

            // video source
            DecklinkVideoSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var mode = cbVideoMode.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(mode))
            {
                var device = (await DeviceEnumerator.Shared.DecklinkVideoSourcesAsync()).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    videoSourceSettings = new DecklinkVideoSourceSettings(device)
                    {
                        Mode = (DecklinkMode)Enum.Parse(typeof(DecklinkMode), mode, true)
                    };
                }
            }

            VideoCapture1.Video_Source = videoSourceSettings;

            // audio source
            DecklinkAudioSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await DeviceEnumerator.Shared.DecklinkAudioSourcesAsync()).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    audioSourceSettings = new DecklinkAudioSourceSettings(device);
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
                }
            }

            await VideoCapture1.StartAsync();

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the engine.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the Click event of the btOutputConfigure control.
        /// Displays the output format configuration dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".mp4");
                        break;
                    }
                case 1:
                    {
                        edOutput.Text = FilenameHelper.ChangeFileExt(edOutput.Text, ".webm");
                        break;
                    }
            }
        }

        /// <summary>
        /// Asynchronously updates the recording duration displayed in the UI.
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
        /// Handles the Closing event of the window.
        /// Ensures the engine is stopped and SDK resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the Click event of the btStartCapture button.
        /// Starts recording using the secondary capture output.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStartCapture(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StartCaptureAsync(0, edOutput.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStopCapture button.
        /// Stops the secondary capture output.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStopCapture(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopCaptureAsync(0);
        }
                
        #region Dispose

        /// <summary>
        /// Disposes of the managed and unmanaged resources used by the window.
        /// </summary>
        /// <param name="disposing">True if called from the <see cref="Dispose()"/> method; false if called from the finalizer.</param>
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
