using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Core;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI.WPF;

namespace Multiple_Encoders
{
    /// <summary>
    /// Interaction logic for the Multiple Encoders WPF demo's MainWindow.
    /// Demonstrates how to run multiple independent capture/encode pipelines simultaneously.
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Dictionary<string, IVideoEncoder> _encoders = new Dictionary<string, IVideoEncoder>();

        private EncodeEngine[] _encodeEngines = new EncodeEngine[4];

        public MainWindow()
        {
            InitializeComponent();
        }

        private static string[] GetVideoEncoders()
        {
            _encoders.Clear();

            var encoders = new List<string>();
            encoders.Add("OpenH264");
            _encoders.Add("OpenH264", new OpenH264EncoderSettings());

            if (NVENCH264EncoderSettings.IsAvailable())
            {
                encoders.Add("NVIDIA H.264");
                _encoders.Add("NVIDIA H.264", new NVENCH264EncoderSettings(VideoQuality.High));
            }

            if (NVENCHEVCEncoderSettings.IsAvailable())
            {
                encoders.Add("NVIDIA H.265");
                _encoders.Add("NVIDIA H.265", new NVENCHEVCEncoderSettings(VideoQuality.High));
            }

            if (QSVH264EncoderSettings.IsAvailable())
            {
                encoders.Add("Intel Quick Sync H.264");
                _encoders.Add("Intel Quick Sync H.264", new QSVH264EncoderSettings(VideoQuality.High));
            }

            if (QSVHEVCEncoderSettings.IsAvailable())
            {
                encoders.Add("Intel Quick Sync H.265");
                _encoders.Add("Intel Quick Sync H.265", new QSVHEVCEncoderSettings(VideoQuality.High));
            }

            if (AMFH264EncoderSettings.IsAvailable())
            {
                encoders.Add("AMD H.264");
                _encoders.Add("AMD H.264", new AMFH264EncoderSettings(VideoQuality.High));
            }

            if (AMFHEVCEncoderSettings.IsAvailable())
            {
                encoders.Add("AMD H.265");
                _encoders.Add("AMD H.265", new AMFHEVCEncoderSettings(VideoQuality.High));
            }

            return encoders.ToArray();
        }

        /// <summary>
        /// Asynchronously retrieves the display names of all available video capture devices.
        /// </summary>
        /// <returns>An array of video source display names.</returns>
        private async Task<string[]> GetVideoSourcesAsync()
        {
            var sources = new List<string>();

            var sourcesX = await DeviceEnumerator.Shared.VideoSourcesAsync();
            foreach (var source in sourcesX)
            {
                sources.Add(source.DisplayName);
            }

            return sources.ToArray();
        }

        /// <summary>
        /// Asynchronously retrieves the display names of all available audio capture devices.
        /// </summary>
        /// <returns>An array of audio source display names.</returns>
        private async Task<string[]> GetAudioSourcesAsync()
        {
            var sources = new List<string>();

            var sourcesX = await DeviceEnumerator.Shared.AudioSourcesAsync();
            foreach (var source in sourcesX)
            {
                sources.Add(source.DisplayName);
            }

            return sources.ToArray();
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// Initializes the SDK, populates device and encoder lists, and sets default values.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // init SDK
            await VisioForgeX.InitSDKAsync();

            // fill encoders
            var videoEncoders = GetVideoEncoders();

            cbVideoEncoder1.ItemsSource = videoEncoders;
            cbVideoEncoder1.SelectedIndex = 0;

            cbVideoEncoder2.ItemsSource = videoEncoders;
            cbVideoEncoder2.SelectedIndex = 0;

            cbVideoEncoder3.ItemsSource = videoEncoders;
            cbVideoEncoder3.SelectedIndex = 0;

            cbVideoEncoder4.ItemsSource = videoEncoders;
            cbVideoEncoder4.SelectedIndex = 0;

            // fill video sources
            var videoSources = await GetVideoSourcesAsync();

            cbVideoSource1.ItemsSource = videoSources;
            cbVideoSource1.SelectedIndex = 0;

            cbVideoSource2.ItemsSource = videoSources;
            cbVideoSource2.SelectedIndex = 0;

            cbVideoSource3.ItemsSource = videoSources;
            cbVideoSource3.SelectedIndex = 0;

            cbVideoSource4.ItemsSource = videoSources;
            cbVideoSource4.SelectedIndex = 0;

            // fill audio sources
            var audioSources = await GetAudioSourcesAsync();

            cbAudioSource1.ItemsSource = audioSources;
            cbAudioSource1.SelectedIndex = 0;

            cbAudioSource2.ItemsSource = audioSources;
            cbAudioSource2.SelectedIndex = 0;

            cbAudioSource3.ItemsSource = audioSources;
            cbAudioSource3.SelectedIndex = 0;

            cbAudioSource4.ItemsSource = audioSources;
            cbAudioSource4.SelectedIndex = 0;

            // other settings
            edOutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// Destroys the SDK resources.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // destroy SDK
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Asynchronously starts a capture pipeline for a specific engine instance.
        /// </summary>
        /// <param name="index">The index of the engine instance (0-3).</param>
        /// <param name="videoView">The video view to render the stream on.</param>
        /// <param name="videoCaptureSource">The display name of the selected video source.</param>
        /// <param name="audioCaptureSource">The display name of the selected audio source.</param>
        /// <param name="videoEncoder">The name of the selected video encoder.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StartCaptureAsync(int index, VideoView videoView, string videoCaptureSource, string audioCaptureSource, string videoEncoder)
        {
            if (_encodeEngines[index] != null)
            {
                await _encodeEngines[index].StopAsync();
            }

            _encodeEngines[index] = new EncodeEngine(videoView);
            var videoSource = (await DeviceEnumerator.Shared.VideoSourcesAsync()).First(x => x.DisplayName == videoCaptureSource);
            var audioSource = (await DeviceEnumerator.Shared.AudioSourcesAsync()).First(x => x.DisplayName == audioCaptureSource);
            await _encodeEngines[index].StartAsync(
                videoSource,
                audioSource,
                _encoders[videoEncoder],
                System.IO.Path.Combine(edOutputFolder.Text, $"output {index}.mp4"));
        }

        /// <summary>
        /// Asynchronously stops the capture pipeline for a specific engine instance.
        /// </summary>
        /// <param name="index">The index of the engine instance to stop.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task StopCaptureAsync(int index)
        {
            if (_encodeEngines[index] != null)
            {
                await _encodeEngines[index].StopAsync();
                _encodeEngines[index] = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart1 control.
        /// Starts capture for the first engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart1_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(0, videoView1, cbVideoSource1.Text, cbAudioSource1.Text, cbVideoEncoder1.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStop1 control.
        /// Stops capture for the first engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(0);
        }

        /// <summary>
        /// Handles the Click event of the btStart2 control.
        /// Starts capture for the second engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(1, videoView2, cbVideoSource2.Text, cbAudioSource2.Text, cbVideoEncoder2.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStop2 control.
        /// Stops capture for the second engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(1);
        }

        /// <summary>
        /// Handles the Click event of the btStart3 control.
        /// Starts capture for the third engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart3_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(2, videoView3, cbVideoSource3.Text, cbAudioSource3.Text, cbVideoEncoder3.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStop3 control.
        /// Stops capture for the third engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop3_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(2);
        }

        /// <summary>
        /// Handles the Click event of the btStart4 control.
        /// Starts capture for the fourth engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart4_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(3, videoView4, cbVideoSource4.Text, cbAudioSource4.Text, cbVideoEncoder4.Text);
        }

        /// <summary>
        /// Handles the Click event of the btStop4 control.
        /// Stops capture for the fourth engine instance.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop4_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(3);
        }
    }
}