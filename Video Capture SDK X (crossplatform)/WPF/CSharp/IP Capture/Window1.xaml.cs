// ReSharper disable InconsistentNaming

// ReSharper disable StyleCop.SA1600
// ReSharper disable StyleCop.SA1601

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
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.Types.X.Output;
    using VisioForge.Core.Types.X.Sources;
    using VisioForge.Core.Types.X.VideoEffects;
    using VisioForge.Core.UI;
    using VisioForge.Core.UI.WPF.Dialogs.OutputFormats;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.VideoCaptureX;
    using Application = System.Windows.Forms.Application;

    public partial class Window1 : IDisposable
    {
        private DeviceEnumerator _deviceEnumerator;

        private UniversalOutputDialog mpegTSSettingsDialog;

        private UniversalOutputDialog movSettingsDialog;

        private UniversalOutputDialog mp4SettingsDialog;

        private UniversalOutputDialog aviSettingsDialog;

        private UniversalOutputDialog webMSettingsDialog;

        private readonly SaveFileDialog screenshotSaveDialog = new SaveFileDialog
        {
            FileName = "image.jpg",
            Filter = "JPEG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|TIFF|*.tiff",
            InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge")
        };

        private Timer tmRecording = new Timer(1000);

        private readonly SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        private ONVIFControl onvifControl;

        private ONVIFPTZRanges onvifPtzRanges;

        private float onvifPtzX;

        private float onvifPtzY;

        private float onvifPtzZoom;

        private VideoCaptureCoreX VideoCapture1;

        private bool disposedValue;

        public Window1()
        {
            InitializeComponent();

            Application.EnableVisualStyles();

            _deviceEnumerator = new DeviceEnumerator();
        }

        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);

            VideoCapture1.OnError += VideoCapture1_OnError;
            //VideoCapture1.OnNetworkSourceDisconnect += VideoCapture1_OnNetworkSourceDisconnect;
        }

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

        private async void Form1_Load(object sender, RoutedEventArgs e)
        {
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
            foreach (var audioOutputDevice in (await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)))
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

            edOutput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }

        private async void btSaveScreenshot_Click(object sender, RoutedEventArgs e)
        {
            if (screenshotSaveDialog.ShowDialog() == true)
            {
                var filename = screenshotSaveDialog.FileName;
                var ext = Path.GetExtension(filename).ToLowerInvariant();
                switch (ext)
                {
                    case ".bmp":
                        await VideoCapture1.Snapshot_SaveAsync(filename, ImageFormat.Bmp);
                        break;
                    case ".jpg":
                        await VideoCapture1.Snapshot_SaveAsync(filename, ImageFormat.Jpeg, 85);
                        break;
                    case ".gif":
                        await VideoCapture1.Snapshot_SaveAsync(filename, ImageFormat.Gif);
                        break;
                    case ".png":
                        await VideoCapture1.Snapshot_SaveAsync(filename, ImageFormat.Png);
                        break;
                    case ".tiff":
                        await VideoCapture1.Snapshot_SaveAsync(filename, ImageFormat.Tiff);
                        break;
                }
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == true)
            {
                edOutput.Text = saveFileDialog1.FileName;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl != null)
            {
                onvifControl.Disconnect();
                onvifControl.Dispose();
                onvifControl = null;

                btONVIFConnect.Content = "Connect";
            }

            mmLog.Clear();

            var audioEnabled = cbIPAudioCapture.IsChecked == true; 
            VideoCapture1.Debug_Mode = cbDebugMode.IsChecked == true;
            VideoCapture1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            VideoCapture1.Audio_Record = audioEnabled;
            VideoCapture1.Audio_Play = audioEnabled;
            VideoCapture1.Audio_OutputDevice = (await _deviceEnumerator.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).First(device => device.DisplayName == cbAudioOutputDevice.Text);

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
                        var rtsp = new RTSPSourceSettings(new Uri(cbIPURL.Text), cbIPAudioCapture.IsChecked == true);
                        rtsp.Login = edIPLogin.Text;
                        rtsp.Password = edIPPassword.Text;

                        VideoCapture1.Video_Source = rtsp;
                    }

                    break;
                case 2:
                    {
                        // NDI URL
                        var ndiSettings = new NDISourceSettings();
                        ndiSettings.URL = cbIPURL.Text;
                        VideoCapture1.Video_Source = ndiSettings;
                    }

                    break;
                case 3:
                    {
                        // NDI Name
                        var ndiSettings = new NDISourceSettings();
                        ndiSettings.SourceName = cbIPURL.Text;
                        VideoCapture1.Video_Source = ndiSettings;
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

            await VideoCapture1.StartAsync();

            //if (rbCapture.IsChecked == true)
            //{
            //    await VideoCapture1.StartCaptureAsync(0, edOutput.Text);
            //}

            tcMain.SelectedIndex = 3;
            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            if (rbCapture.IsChecked == true)
            {
                await VideoCapture1.StopCaptureAsync(0);
            }

            await VideoCapture1.StopAsync();
        }

        private void llVideoTutorials_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.VideoTutorials);
            Process.Start(startInfo);
        }

        private void Log(string txt)
        {
            Dispatcher.Invoke(() => { mmLog.Text = mmLog.Text + txt + Environment.NewLine; });
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private async void btONVIFConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btONVIFConnect.Content.ToString() == "Connect")
            {
                try
                {
                    btONVIFConnect.IsEnabled = false;
                    btONVIFConnect.Content = "Connecting";

                    if (onvifControl != null)
                    {
                        onvifControl.Disconnect();
                        onvifControl.Dispose();
                        onvifControl = null;
                    }

                    if (string.IsNullOrEmpty(edONVIFLogin.Text) || string.IsNullOrEmpty(edONVIFPassword.Text))
                    {
                        MessageBox.Show(this, "Please specify IP camera user name and password.");
                        return;
                    }

                    onvifControl = new ONVIFControl();
                    var result = await onvifControl.ConnectAsync(edONVIFURL.Text, edONVIFLogin.Text, edONVIFPassword.Text);
                    if (!result)
                    {
                        onvifControl = null;
                        MessageBox.Show(this, "Unable to connect to ONVIF camera.");
                        return;
                    }

                    var deviceInfo = await onvifControl.GetDeviceInformationAsync();
                    if (deviceInfo != null)
                    {
                        lbONVIFCameraInfo.Content = $"Model {deviceInfo.Model}, Firmware {deviceInfo.Firmware}";
                    }

                    cbONVIFProfile.Items.Clear();
                    var profiles = await onvifControl.GetProfilesAsync();
                    foreach (var profile in profiles)
                    {
                        cbONVIFProfile.Items.Add($"{profile.Name}");
                    }

                    if (cbONVIFProfile.Items.Count > 0)
                    {
                        cbONVIFProfile.SelectedIndex = 0;
                    }

                    edONVIFLiveVideoURL.Text = cbIPURL.Text = await onvifControl.GetVideoURLAsync();

                    edIPLogin.Text = edONVIFLogin.Text;
                    edIPPassword.Text = edONVIFPassword.Text;

                    onvifPtzRanges = await onvifControl.PTZ_GetRangesAsync();
                    await onvifControl.PTZ_SetAbsoluteAsync(0, 0, 0);

                    onvifPtzX = 0;
                    onvifPtzY = 0;
                    onvifPtzZoom = 0;

                    btONVIFConnect.Content = "Disconnect";
                }
                finally
                {
                    btONVIFConnect.IsEnabled = true;
                    btONVIFConnect.Content = "Connect";
                }
            }
            else
            {
                btONVIFConnect.Content = "Connect";

                if (onvifControl != null)
                {
                    onvifControl.Disconnect();
                    onvifControl.Dispose();
                    onvifControl = null;
                }
            }
        }

        private void btONVIFRight_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX - step;

            if (onvifPtzX < onvifPtzRanges.MinX)
            {
                onvifPtzX = onvifPtzRanges.MinX;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFPTZSetDefault_Click(object sender, RoutedEventArgs e)
        {
            onvifControl?.PTZ_SetAbsolute(0, 0, 0);
        }

        private void btONVIFLeft_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxX - onvifPtzRanges.MinX) / 30;
            onvifPtzX = onvifPtzX + step;

            if (onvifPtzX > onvifPtzRanges.MaxX)
            {
                onvifPtzX = onvifPtzRanges.MaxX;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFUp_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY - step;

            if (onvifPtzY < onvifPtzRanges.MinY)
            {
                onvifPtzY = onvifPtzRanges.MinY;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFDown_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxY - onvifPtzRanges.MinY) / 30;
            onvifPtzY = onvifPtzY + step;

            if (onvifPtzY > onvifPtzRanges.MaxY)
            {
                onvifPtzY = onvifPtzRanges.MaxY;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom + step;

            if (onvifPtzZoom > onvifPtzRanges.MaxZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MaxZoom;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
        }

        private void btONVIFZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (onvifControl == null || onvifPtzRanges == null)
            {
                return;
            }

            float step = (onvifPtzRanges.MaxZoom - onvifPtzRanges.MinZoom) / 100;
            onvifPtzZoom = onvifPtzZoom - step;

            if (onvifPtzZoom < onvifPtzRanges.MinZoom)
            {
                onvifPtzZoom = onvifPtzRanges.MinZoom;
            }

            onvifControl.PTZ_SetAbsolute(onvifPtzX, onvifPtzY, onvifPtzZoom);
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

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.ResumeAsync();
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.PauseAsync();
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

        private async Task UpdateRecordingTime()
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

        private void lbNDIVendor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var startInfo = new ProcessStartInfo("explorer.exe", HelpLinks.NDIVendor);
            Process.Start(startInfo);
        }

        private async void btListNDISources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await _deviceEnumerator.NDISourcesAsync();
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri.URL);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private async void btListONVIFSources_Click(object sender, RoutedEventArgs e)
        {
            cbIPURL.Items.Clear();

            var lst = await _deviceEnumerator.ONVIF_ListSourcesAsync(null, null);
            foreach (var uri in lst)
            {
                cbIPURL.Items.Add(uri);
            }

            if (cbIPURL.Items.Count > 0)
            {
                cbIPURL.SelectedIndex = 0;
            }
        }

        private void VideoCapture1_OnNetworkSourceDisconnect(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(
                               async () =>
                                   {
                                       await VideoCapture1.StopAsync();

                                       MessageBox.Show(this, "Network source stopped or disconnected!");
                                   }));
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyEngineAsync();

            _deviceEnumerator.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (onvifControl != null)
                    {
                        onvifControl.Dispose();
                        onvifControl = null;
                    }

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