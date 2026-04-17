using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace MediaBlocks_Virtual_Camera_Demo_WPF
{
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private SystemVideoSourceBlock _videoSource;

        private SystemAudioSourceBlock _audioSource;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private TeeBlock _videoTee;

        private TeeBlock _audioTee;

        private VirtualCameraSinkBlock _virtualCameraSink;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeviceEnumerator_OnVideoSourceAdded(object sender, VideoCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbVideoInput.Items.Add(e.DisplayName);

                if (cbVideoInput.Items.Count == 1)
                {
                    cbVideoInput.SelectedIndex = 0;
                }
            });
        }

        private void DeviceEnumerator_OnAudioSourceAdded(object sender, AudioCaptureDeviceInfo e)
        {
            Dispatcher.Invoke(() =>
            {
                cbAudioInput.Items.Add(e.DisplayName);
            });
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.Text += e.Message + Environment.NewLine;
            });
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [LOADING SDK...]";
                IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                IsEnabled = true;
                Title = Title.Replace(" [LOADING SDK...]", "");

                DeviceEnumerator.Shared.OnVideoSourceAdded += DeviceEnumerator_OnVideoSourceAdded;
                DeviceEnumerator.Shared.OnAudioSourceAdded += DeviceEnumerator_OnAudioSourceAdded;

                cbAudioInput.Items.Add("None");
                cbAudioInput.SelectedIndex = 0;

                await DeviceEnumerator.Shared.StartVideoSourceMonitorAsync();
                await DeviceEnumerator.Shared.StartAudioSourceMonitorAsync();

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                UpdateRegistrationStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}");
            }
        }

        private void UpdateRegistrationStatus()
        {
            bool registered = VirtualCameraSinkBlock.IsCOMRegistered();

            if (registered)
            {
                statusIndicator.Fill = new SolidColorBrush(Colors.Green);
                lbRegistrationStatus.Text = "Virtual Camera filters registered";
            }
            else
            {
                statusIndicator.Fill = new SolidColorBrush(Colors.Red);
                lbRegistrationStatus.Text = "Virtual Camera filters NOT registered";
            }
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            bool result = VirtualCameraSinkBlock.COMRegisterAsAdmin();

            if (result)
            {
                mmLog.Text += "Virtual Camera filters registered successfully." + Environment.NewLine;
            }
            else
            {
                mmLog.Text += "Failed to register Virtual Camera filters. Make sure .ax files are present." + Environment.NewLine;
            }

            UpdateRegistrationStatus();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Text = "";

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a video input device.");
                return;
            }

            if (!int.TryParse(edWidth.Text, out int width) || !int.TryParse(edHeight.Text, out int height) || !double.TryParse(edFrameRate.Text, out double frameRate))
            {
                MessageBox.Show("Invalid resolution or frame rate values.");
                return;
            }

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;

            // Video source
            var deviceName = cbVideoInput.SelectedItem.ToString();
            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
            if (device == null)
            {
                MessageBox.Show("Video device not found.");
                return;
            }

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(device);
            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // Video tee (preview + virtual camera)
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // Video renderer (preview)
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            // Virtual camera sink settings
            var vcSettings = new VirtualCameraSinkSettings
            {
                Width = width,
                Height = height,
                FrameRate = frameRate,
            };

            // Virtual camera sink block
            _virtualCameraSink = new VirtualCameraSinkBlock(vcSettings);

            // Connect video path
            _pipeline.Connect(_videoSource.Output, _videoTee.Input);
            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipeline.Connect(_videoTee.Outputs[1], _virtualCameraSink.CreateNewInput(MediaBlockPadMediaType.Video));

            // Audio source (if selected)
            bool audioEnabled = cbAudioInput.SelectedIndex > 0 && cbAudioInput.SelectedItem.ToString() != "None";

            if (audioEnabled)
            {
                var audioDeviceName = cbAudioInput.SelectedItem.ToString();
                var audioDevice = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == audioDeviceName);
                if (audioDevice == null)
                {
                    MessageBox.Show("Audio device not found.");
                    return;
                }

                var audioSourceSettings = new AudioCaptureDeviceSourceSettings(audioDevice);
                _audioSource = new SystemAudioSourceBlock(audioSourceSettings);
                _audioTee = new TeeBlock(2, MediaBlockPadMediaType.Audio);
                _audioRenderer = new AudioRendererBlock();

                _pipeline.Connect(_audioSource.Output, _audioTee.Input);
                _pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                _pipeline.Connect(_audioTee.Outputs[1], _virtualCameraSink.CreateNewInput(MediaBlockPadMediaType.Audio));
            }

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            try
            {
                await _pipeline.StartAsync();
                mmLog.Text += "Pipeline started. Virtual camera is now active." + Environment.NewLine;
            }
            catch (Exception ex)
            {
                mmLog.Text += $"Error starting pipeline: {ex.Message}" + Environment.NewLine;
                btStart.IsEnabled = true;
                btStop.IsEnabled = false;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _videoSource = null;
            _audioSource = null;
            _videoRenderer = null;
            _audioRenderer = null;
            _videoTee = null;
            _audioTee = null;
            _virtualCameraSink = null;

            mmLog.Text += "Pipeline stopped." + Environment.NewLine;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DeviceEnumerator.Shared.OnVideoSourceAdded -= DeviceEnumerator_OnVideoSourceAdded;
            DeviceEnumerator.Shared.OnAudioSourceAdded -= DeviceEnumerator_OnAudioSourceAdded;

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }
    }
}
