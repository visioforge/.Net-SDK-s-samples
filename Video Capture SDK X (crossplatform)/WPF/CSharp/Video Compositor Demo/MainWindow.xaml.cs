using System;
using System.Linq;
using System.Windows;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.X.Sources;
using Microsoft.Win32;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types;
using Rect = VisioForge.Core.Types.Rect;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.WPF.Dialogs.Sources;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using System.Threading.Tasks;

namespace Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DeviceEnumerator _deviceEnumerator;

        private VideoCaptureCoreX _videoCapture;

        private VideoMixerSourceSettings _videoMixerSourceSettings = new VideoMixerSourceSettings();

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;

            _deviceEnumerator = new DeviceEnumerator();
        }
        private void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void CreateEngine()
        {
            _videoCapture = new VideoCaptureCoreX(VideoView1);
            _videoCapture.OnError += VideoCapture_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_videoCapture != null)
            {
                _videoCapture.OnError -= VideoCapture_OnError;

                await _videoCapture.DisposeAsync();
                _videoCapture = null;
            }
        }

        private async void btAddCamera_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new VideoCaptureSourceDialog(_deviceEnumerator);
            if (dlg.ShowDialog() == true)
            {
                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await _deviceEnumerator.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            settings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            settings.Format.FrameRate = dlg.FrameRate;
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure video capture device.");
                    return;
                }

                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                _videoMixerSourceSettings.Add(settings, rect);
                
                cbSources.Items.Add($"Camera [{dlg.Device}]");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btAddScreen_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;
                
                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                _videoMixerSourceSettings.Add(settings, rect);
                
                cbSources.Items.Add($"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}");
                cbSources.SelectedIndex = cbSources.Items.Count - 1;
            }
        }

        private void btRemove_Click(object sender, RoutedEventArgs e)
        {
            if (cbSources.SelectedIndex != -1)
            {
                _videoMixerSourceSettings.RemoveAt(cbSources.SelectedIndex);
                cbSources.Items.RemoveAt(cbSources.SelectedIndex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }
       
        private void UpdateRecordingTime()
        {
            var ts = _videoCapture.Duration();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            CreateEngine();

            _videoMixerSourceSettings.Width = Convert.ToInt32(edWidth.Text);
            _videoMixerSourceSettings.Height = Convert.ToInt32(edHeight.Text);
            _videoMixerSourceSettings.FrameRate = new VideoFrameRate(Convert.ToInt32(edFrameRate.Text), 1);

            _videoCapture.Video_Source = _videoMixerSourceSettings;
            _videoCapture.Outputs_Clear();

            if (rbOutputFile.IsChecked == true)
            {
                _videoCapture.Outputs_Add(new MP4Output(edOutputFilename.Text) 
                { 
                    Video = new OpenH264EncoderSettings()
                });
            }
            else if (rbOutputYouTube.IsChecked == true)
            {
                // fake audio source 
                var fakeAudioSource = new VirtualAudioSourceSettings();
                _videoCapture.Audio_Source = fakeAudioSource;

                // create and connect YouTube output
                var youTubeOutput = new YouTubeOutput(edOutputYouTubeKey.Text)
                {
                    Video = new OpenH264EncoderSettings(), 
                    Audio = new MFAACEncoderSettings() 
                };
                _videoCapture.Outputs_Add(youTubeOutput);
            }
            else if (rbOutputFacebook.IsChecked == true)
            {
                // fake audio source 
                var fakeAudioSource = new VirtualAudioSourceSettings();
                _videoCapture.Audio_Source = fakeAudioSource;

                // create and connect Facebook Live output
                var facebookOutput = new FacebookLiveOutput(edOutputFacebookKey.Text)
                {
                    Video = new OpenH264EncoderSettings(),
                    Audio = new MFAACEncoderSettings()
                };
                _videoCapture.Outputs_Add(facebookOutput);
            }

            await _videoCapture.StartAsync();

            _videoCapture.Debug_SavePipeline("vcpipeline");
            
            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _videoCapture?.StopAsync();

            await DestroyEngineAsync();
        }

        private void btUpdateRect_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1)
            {
                var mixer = _videoCapture.GetSourceMixerControl();
                if (mixer != null)
                {
                    var stream = mixer.Input_Get(index);
                    if (stream != null)
                    {
                        stream.Rectangle = new Rect(
                            Convert.ToInt32(edRectLeft.Text),
                            Convert.ToInt32(edRectTop.Text),
                            Convert.ToInt32(edRectRight.Text),
                            Convert.ToInt32(edRectBottom.Text));
                        mixer.Input_Update(index, stream);
                    }
                }
            }
        }

        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == true)
            {
                edOutputFilename.Text = dlg.FileName;
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tmRecording.Stop();

            await DestroyEngineAsync();

            _deviceEnumerator?.Dispose();
        }

        private void btTransparency_Click(object sender, RoutedEventArgs e)
        {
            int index = cbSources.SelectedIndex;
            if (index != -1)
            {
                var mixer = _videoCapture.GetSourceMixerControl();
                if (mixer != null)
                {
                    var stream = mixer.Input_Get(index);
                    if (stream != null)
                    {
                        stream.Alpha = slTransparency.Value / 100.0;
                        mixer.Input_Update(index, stream);
                    }
                }
            }
        }
    }
}
