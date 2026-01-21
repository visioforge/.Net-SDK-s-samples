




namespace IP_Capture
{
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using VisioForge.Core;
    using VisioForge.Core.Helpers;
    using VisioForge.Core.MediaBlocks;
    using VisioForge.Core.ONVIFX;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.X.AudioRenderers;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.VideoCaptureX;
    using Application = System.Windows.Forms.Application;

    /// <summary>
    /// Interaction logic for the IP Capture WPF demo's Window1.
    /// Demonstrates capturing from various IP sources (RTSP, MJPEG, NDI, SRT, ONVIF) using the X-engine.
    /// </summary>
    public partial class Window1 : IDisposable
    {
        private UniversalOutputDialog mpegTSSettingsDialog;

        private UniversalOutputDialog movSettingsDialog;

        private UniversalOutputDialog mp4SettingsDialog;

        private UniversalOutputDialog aviSettingsDialog;

        private UniversalOutputDialog webMSettingsDialog;

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        };

        private Timer tmRecording = new Timer(1000);

        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        private ONVIFClientX onvifDevice;

        private VideoCaptureCoreX VideoCapture1;

        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();
        }

        /// <summary>
        /// Creates the video capture engine and subscribes to essential events.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            //VideoCapture1.OnNetworkSourceDisconnect += VideoCapture1_OnNetworkSourceDisconnect;
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
                //VideoCapture1.OnNetworkSourceDisconnect -= VideoCapture1_OnNetworkSourceDisconnect;

                await VideoCapture1.DisposeAsync();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Handles the Load event of the Window control.
        /// Initializes the SDK, sets up the engine, and populates audio output devices.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            tmRecording.Elapsed += async (senderx, args) =>
            {
                await UpdateRecordingTime();
            };

            cbOutputFormat.SelectedIndex = 0;
            cbIPCameraType.SelectedIndex = 1;

            // audio output
            string defaultAudioRenderer = string.Empty;
            foreach (var audioOutputDevice in (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)))
            {
                cbAudioOutputDevice.Items.Add(audioOutputDevice.DisplayName);

                if (audioOutputDevice.DisplayName.Contains("Default"))
                {
                    defaultAudioRenderer = audioOutputDevice.DisplayName;
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
                    cbAudioOutputDevice.Text = defaultAudioRenderer;                                              
                }
            }

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "output.mp4");
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
        /// Handles the Click event of the btSelectOutput control.
        /// Opens a file dialog to select the output video file path.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures the engine for the selected IP camera type and starts capture or preview.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice != null)
            {
                onvifDevice.Dispose();
                onvifDevice = null;

                btONVIFConnect.Content = "Connect";
            }

            mmLog.Clear();

            var audioEnabled = cbIPAudioCapture.IsChecked == true; 
            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_Record = audioEnabled;
            VideoCapture1.Audio_Play = audioEnabled;

            var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).First(device => device.DisplayName == cbAudioOutputDevice.Text);
            VideoCapture1.Audio_OutputDevice = new AudioRendererSettings(audioOutputDevice); 

            var login = edIPLogin.Text;
            var password = edIPPassword.Text;

            switch (cbIPCameraType.SelectedIndex)
            {
                case 0:
                    {
                        // Auto
                        bool audio = cbIPAudioCapture.IsChecked == true;
                        var uri = new Uri(cbIPURL.Text);
                        if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
                        {
                            uri = new UriBuilder(uri) { UserName = login, Password = password }.Uri;
                        }

                        var uni = await UniversalSourceSettings.CreateAsync(uri, renderAudio: audio);

                        VideoCapture1.Video_Source = uni;
                    }

                    break;
                case 1:
                    {
                        // RTSP
                        var rtsp = await RTSPSourceSettings.CreateAsync(new Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text, cbIPAudioCapture.IsChecked == true);
                        
                        // Enable low latency mode if checkbox is checked
                        if (cbLowLatencyMode.IsChecked == true)
                        {
                            rtsp.LowLatencyMode = true;
                        }
                        
                        VideoCapture1.Video_Source = rtsp;
                    }

                    break;
                case 2:
                    {
                        // HTTP MJPEG
                        var mjpeg = await HTTPMJPEGSourceSettings.CreateAsync(new Uri(cbIPURL.Text), edIPLogin.Text, edIPPassword.Text);
                        VideoCapture1.Video_Source = mjpeg;
                    }

                    break;
                case 3:
                    {
                        // NDI URL
                        var ndiSettings = await NDISourceSettings.CreateAsync(VideoCapture1.GetContext(), null, cbIPURL.Text);
                        VideoCapture1.Video_Source = ndiSettings;
                    }

                    break;
                case 4:
                    {
                        // NDI Name
                        var ndiSettings = await NDISourceSettings.CreateAsync(VideoCapture1.GetContext(), cbIPURL.Text, null);
                        VideoCapture1.Video_Source = ndiSettings;
                    }

                    break;
                case 5:
                    {
                        // SRT
                        var srt = await SRTSourceSettings.CreateAsync(cbIPURL.Text);
                        VideoCapture1.Video_Source = srt;
                    }

                    break;
            }

            //if (cbIPDisconnect.IsChecked == true)
            //{
            //    VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.FromSeconds(10);
            //}
            //else
            //{
            //    VideoCapture1.IP_Camera_Source.DisconnectEventInterval = TimeSpan.Zero;
            //}

            VideoCapture1.Outputs_Clear();
            
            if (rbCapture.IsChecked == true)
            {
                switch (cbOutputFormat.SelectedIndex)
                {
                    case 0:
                        {
                            if (mp4SettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MP4Output(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mp4SettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 1:
                        {
                            if (aviSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new AVIOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(aviSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 2:
                        {
                            if (webMSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new WebMOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(webMSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                    case 3:
                        {
                            if (mpegTSSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MPEGTSOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(mpegTSSettingsDialog.GetOutputVC(), true);
                            }


                            break;
                        }
                    case 4:
                        {
                            if (movSettingsDialog == null)
                            {
                                VideoCapture1.Outputs_Add(new MOVOutput(edOutput.Text), true);
                            }
                            else
                            {
                                VideoCapture1.Outputs_Add(movSettingsDialog.GetOutputVC(), true);
                            }

                            break;
                        }
                }
            }

            VideoView1.StatusOverlay = new TextStatusOverlay();

            VideoCapture1.Snapshot_Grabber_Enabled = true;

            await VideoCapture1.StartAsync();

            //if (rbCapture.IsChecked == true)
            //{
            //    await VideoCapture1.StartCaptureAsync(0, edOutput.Text);
            //}

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the video capture engine and resets the recording timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            if (rbCapture.IsChecked == true)
            {
                await VideoCapture1.StopCaptureAsync(0);
            }

            await VideoCapture1.StopAsync();
        }

        /// <summary>
        /// Handles the MouseDown event of the llVideoTutorials label.
        /// Opens the video tutorials link in the default browser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
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
        /// Handles the Click event of the btONVIFConnect control.
        /// Connects to or disconnects from the specified ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                try
                {
                    btONVIFConnect.IsEnabled = false;
                    btONVIFConnect.Content = "Connecting";

                    if (onvifDevice != null)
                    {
                        onvifDevice.Dispose();
                        onvifDevice = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifDevice = new ONVIFClientX();
                    var result = await onvifDevice.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifDevice = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    var deviceInfo = onvifDevice.DeviceInformation;
                    if (deviceInfo != null)
                    {
                        lbONVIFCameraInfo.Content = $"{deviceInfo.Manufacturer} {deviceInfo.Model}, s/n {deviceInfo.SerialNumber}";
                    }
                    else
                    {
                        lbONVIFCameraInfo.Content = "Device information not available";
                    }
                    
                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifDevice.GetProfilesAsync();
                    foreach (var profile in profiles)
                    {
                        cbONVIFProfile.Items.Add($"{profile.Name}");
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;
                    }

                    if (profiles.Length > 0)
                    {
                        var streamUri = await onvifDevice.GetStreamUriAsync(profiles[0]);
                        if (streamUri != null)
                        {
                            edONVIFLiveVideoURL.Text = cbIPURL.Text = streamUri.Uri;
                        }
                    }

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    btONVIFConnect.Content = "Disconnect";
                }
                catch
                {                   
                    btONVIFConnect.Content = "Connect";
                }

                btONVIFConnect.IsEnabled = true;
            }
            else
            {
                btONVIFConnect.Content = "Connect";

                if (onvifDevice != null)
                {
                    onvifDevice.Dispose();
                    onvifDevice = null;
                }
            }
        }

        /// <summary>
        /// Get current profile token async.
        /// </summary>
        private async Task<string> GetCurrentProfileTokenAsync()
        {
            if (onvifDevice == null || cbONVIFProfile.SelectedIndex < 0)
            {
                return null;
            }

            var profiles = await onvifDevice.GetProfilesAsync();
            if (profiles != null && cbONVIFProfile.SelectedIndex < profiles.Length)
            {
                return profiles[cbONVIFProfile.SelectedIndex].token;
            }

            return null;
        }

        /// <summary>
        /// Handles the Click event of the btONVIFRight control.
        /// Initiates a continuous move to the right on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFRight_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, new VisioForge.Core.ONVIFX.PTZ.Vector2D { x = 0.5f, y = 0 }, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFPTZSetDefault control.
        /// Navigates the ONVIF device PTZ to its default position.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            try
            {
                var profileToken = await GetCurrentProfileTokenAsync();
                if (!string.IsNullOrEmpty(profileToken))
                {
                    // Try to go to the first preset, which is often the home position
                    var presets = await onvifDevice.GetPresetsAsync(profileToken);
                    if (presets != null && presets.Length > 0)
                    {
                        await onvifDevice.GoToPresetAsync(profileToken, presets[0].token, 1.0f, 1.0f, 1.0f);
                    }
                }
            }
            catch
            {
                // Handle exception if needed
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFLeft control.
        /// Initiates a continuous move to the left on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFLeft_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, new VisioForge.Core.ONVIFX.PTZ.Vector2D { x = -0.5f, y = 0 }, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFUp control.
        /// Initiates a continuous move upward on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFUp_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, new VisioForge.Core.ONVIFX.PTZ.Vector2D { x = 0, y = 0.5f }, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFDown control.
        /// Initiates a continuous move downward on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFDown_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, new VisioForge.Core.ONVIFX.PTZ.Vector2D { x = 0, y = -0.5f }, null);
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFZoomIn control.
        /// Initiates a continuous zoom in on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, null, new VisioForge.Core.ONVIFX.PTZ.Vector1D { x = 0.5f });
            }
        }

        /// <summary>
        /// Handles the Click event of the btONVIFZoomOut control.
        /// Initiates a continuous zoom out on the ONVIF device.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (onvifDevice == null)
            {
                return;
            }

            var profileToken = await GetCurrentProfileTokenAsync();
            if (!string.IsNullOrEmpty(profileToken))
            {
                await onvifDevice.ContinuousMoveAsync(profileToken, null, new VisioForge.Core.ONVIFX.PTZ.Vector1D { x = -0.5f });
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

        /// <summary>
        /// Asynchronously updates the recording duration displayed in the UI.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdateRecordingTime()
        {
            var ts = await VideoCapture1.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            await Dispatcher.InvokeAsync((Action)(() =>
            {
                lbTimestamp.Text = "Duration: " + ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the MouseDown event of the lbNDIVendor label.
        /// Opens the NDI vendor link in the default browser.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handles the Click event of the btListNDISources control.
        /// Populates the URL combo box with available NDI sources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await DeviceEnumerator.Shared.NDISourcesAsync();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri.Name);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the Click event of the btListONVIFSources control.
        /// Populates the URL combo box with available ONVIF sources discovered on the network.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await DeviceEnumerator.Shared.ONVIF_ListSourcesAsync(null, null);
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Handles the OnNetworkSourceDisconnect event of the VideoCapture1 control.
        /// Stops the engine and alerts the user when a network disconnect occurs.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(
                               async () =>
                                   {
                                       await VideoCapture1.StopAsync();

                                       MessageBox.Show(this, "Network source stopped or disconnected!");
                                   }));
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
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (onvifDevice != null)
                    {
                        onvifDevice.Dispose();
                        onvifDevice = null;
                    }

                    tmRecording?.Dispose();
                    tmRecording = null;
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="Window1"/> class.
        /// </summary>
        ~Window1()
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
    }
}

