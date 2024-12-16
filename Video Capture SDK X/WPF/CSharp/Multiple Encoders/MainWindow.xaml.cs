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
    /// Interaction logic for MainWindow.xaml
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // destroy SDK
            VisioForgeX.DestroySDK();
        }

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

        private async Task StopCaptureAsync(int index)
        {
            if (_encodeEngines[index] != null)
            {
                await _encodeEngines[index].StopAsync();
                _encodeEngines[index] = null;
            }
        }

        private async void btStart1_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(0, videoView1, cbVideoSource1.Text, cbAudioSource1.Text, cbVideoEncoder1.Text);
        }

        private async void btStop1_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(0);
        }

        private async void btStart2_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(1, videoView2, cbVideoSource2.Text, cbAudioSource2.Text, cbVideoEncoder2.Text);
        }

        private async void btStop2_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(1);
        }

        private async void btStart3_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(2, videoView3, cbVideoSource3.Text, cbAudioSource3.Text, cbVideoEncoder3.Text);
        }

        private async void btStop3_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(2);
        }

        private async void btStart4_Click(object sender, RoutedEventArgs e)
        {
            await StartCaptureAsync(3, videoView4, cbVideoSource4.Text, cbAudioSource4.Text, cbVideoEncoder4.Text);
        }

        private async void btStop4_Click(object sender, RoutedEventArgs e)
        {
            await StopCaptureAsync(3);
        }
    }
}