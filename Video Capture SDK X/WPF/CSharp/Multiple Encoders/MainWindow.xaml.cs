using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoCapture;
using VisioForge.Core.Types.X.VideoEncoders;
using VisioForge.Core.UI;
using VisioForge.Core.UI.WPF;
using VisioForge.Core.VideoCaptureX;

namespace Multiple_Encoders
{
    /// <summary>
    /// Multiple Encoders WPF demo — runs four independent VideoCaptureCoreX pipelines in parallel,
    /// each with its own device, format, encoder and output file. Demonstrates that several hardware /
    /// software encoders can run side by side from a single application.
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int PipelineCount = 4;

        private readonly VideoCaptureCoreX[] _cores = new VideoCaptureCoreX[PipelineCount];

        private VideoView[] _videoViews;
        private ComboBox[] _cbVideoDevice;
        private ComboBox[] _cbVideoFormat;
        private ComboBox[] _cbVideoFrameRate;
        private ComboBox[] _cbAudioDevice;
        private ComboBox[] _cbAudioFormat;
        private ComboBox[] _cbVideoEncoder;
        private CheckBox[] _cbRecordAudio;
        private TextBlock[] _lbStatus;

        private static readonly Dictionary<string, Func<IVideoEncoder>> _encoderFactories =
            new Dictionary<string, Func<IVideoEncoder>>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuildSlotArrays()
        {
            _videoViews = new[] { videoView1, videoView2, videoView3, videoView4 };
            _cbVideoDevice = new[] { cbVideoDevice1, cbVideoDevice2, cbVideoDevice3, cbVideoDevice4 };
            _cbVideoFormat = new[] { cbVideoFormat1, cbVideoFormat2, cbVideoFormat3, cbVideoFormat4 };
            _cbVideoFrameRate = new[] { cbVideoFrameRate1, cbVideoFrameRate2, cbVideoFrameRate3, cbVideoFrameRate4 };
            _cbAudioDevice = new[] { cbAudioDevice1, cbAudioDevice2, cbAudioDevice3, cbAudioDevice4 };
            _cbAudioFormat = new[] { cbAudioFormat1, cbAudioFormat2, cbAudioFormat3, cbAudioFormat4 };
            _cbVideoEncoder = new[] { cbVideoEncoder1, cbVideoEncoder2, cbVideoEncoder3, cbVideoEncoder4 };
            _cbRecordAudio = new[] { cbRecordAudio1, cbRecordAudio2, cbRecordAudio3, cbRecordAudio4 };
            _lbStatus = new[] { lbStatus1, lbStatus2, lbStatus3, lbStatus4 };
        }

        private static int SlotFromTag(object tag) => Convert.ToInt32(tag);

        private static string[] BuildEncoderList()
        {
            _encoderFactories.Clear();

            var names = new List<string>();

            void Add(string name, Func<IVideoEncoder> factory)
            {
                names.Add(name);
                _encoderFactories[name] = factory;
            }

            Add("OpenH264", () => new OpenH264EncoderSettings());
            Add("NVIDIA H.264", () => new NVENCH264EncoderSettings(VideoQuality.High));
            Add("NVIDIA H.265", () => new NVENCHEVCEncoderSettings(VideoQuality.High));
            Add("Intel Quick Sync H.264", () => new QSVH264EncoderSettings(VideoQuality.High));
            Add("Intel Quick Sync H.265", () => new QSVHEVCEncoderSettings(VideoQuality.High));
            Add("AMD H.264", () => new AMFH264EncoderSettings(VideoQuality.High));
            Add("AMD H.265", () => new AMFHEVCEncoderSettings(VideoQuality.High));
            Add("Media Foundation H.264", () => new MFH264EncoderSettings());
            Add("Media Foundation H.265", () => new MFHEVCEncoderSettings());
            Add("D3D12 H.264", () => new D3D12H264EncoderSettings());
            Add("D3D12 H.265", () => new D3D12HEVCEncoderSettings());

            return names.ToArray();
        }

        private void CreateCore(int index)
        {
            var core = new VideoCaptureCoreX(_videoViews[index] as IVideoView);
            core.OnError += (s, e) => Log($"[Pipeline {index + 1}] {e.Message}");
            _cores[index] = core;
        }

        private async Task DestroyCoreAsync(int index)
        {
            if (_cores[index] == null)
            {
                return;
            }

            try
            {
                await _cores[index].StopAsync();
            }
            catch (Exception ex)
            {
                Log($"[Pipeline {index + 1}] Stop error: {ex.Message}");
            }

            try
            {
                await _cores[index].DisposeAsync();
            }
            catch (Exception ex)
            {
                Log($"[Pipeline {index + 1}] Dispose error: {ex.Message}");
            }

            _cores[index] = null;
        }

        private void Log(string text)
        {
            Dispatcher.Invoke(() =>
            {
                mmLog.AppendText(text + Environment.NewLine);
                mmLog.ScrollToEnd();
            });
        }

        private void SetStatus(int index, string text, System.Windows.Media.Brush brush)
        {
            _lbStatus[index].Text = text;
            _lbStatus[index].Foreground = brush;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BuildSlotArrays();

            edOutputFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            IsEnabled = true;
            Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
            Title += $" (SDK v{VideoCaptureCoreX.SDK_Version})";

            // Eagerly create one VideoCaptureCoreX per slot, bound to its VideoView.
            // Step 2(c) experiment: only slot 0 is constructed; slots 1..3 stay null
            // so we can rule out cross-instance interference from the other 3 cores
            // running their preview pipelines on the same process.
            CreateCore(0);
            // CreateCore(1);
            // CreateCore(2);
            // CreateCore(3);

            var encoders = BuildEncoderList();
            var videoSources = (await DeviceEnumerator.Shared.VideoSourcesAsync()).Select(d => d.DisplayName).ToArray();
            var audioSources = (await DeviceEnumerator.Shared.AudioSourcesAsync()).Select(d => d.DisplayName).ToArray();

            for (int i = 0; i < PipelineCount; i++)
            {
                _cbVideoEncoder[i].ItemsSource = encoders;
                if (encoders.Length > 0)
                {
                    _cbVideoEncoder[i].SelectedIndex = 0;
                }

                _cbVideoDevice[i].ItemsSource = videoSources;
                if (videoSources.Length > 0)
                {
                    _cbVideoDevice[i].SelectedIndex = 0;
                }

                _cbAudioDevice[i].ItemsSource = audioSources;
                if (audioSources.Length > 0)
                {
                    _cbAudioDevice[i].SelectedIndex = 0;
                }
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for (int i = 0; i < PipelineCount; i++)
            {
                await DestroyCoreAsync(i);
            }

            VisioForgeX.DestroySDK();
        }

        private async void cbVideoDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cbVideoFormat == null || sender is not ComboBox combo || e.AddedItems.Count == 0)
            {
                return;
            }

            int slot = SlotFromTag(combo.Tag);
            var deviceName = e.AddedItems[0]?.ToString();
            if (string.IsNullOrEmpty(deviceName))
            {
                return;
            }

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null)
            {
                return;
            }

            _cbVideoFormat[slot].Items.Clear();
            foreach (var format in device.VideoFormats)
            {
                _cbVideoFormat[slot].Items.Add(format.Name);
            }

            if (_cbVideoFormat[slot].Items.Count > 0)
            {
                _cbVideoFormat[slot].SelectedIndex = 0;
            }
        }

        private async void cbVideoFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cbVideoFrameRate == null || sender is not ComboBox combo)
            {
                return;
            }

            int slot = SlotFromTag(combo.Tag);
            _cbVideoFrameRate[slot].Items.Clear();

            var deviceName = _cbVideoDevice[slot].SelectedItem?.ToString();
            var formatName = combo.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(formatName))
            {
                return;
            }

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null)
            {
                return;
            }

            var videoFormat = device.VideoFormats.FirstOrDefault(f => f.Name == formatName);
            if (videoFormat == null)
            {
                return;
            }

            foreach (var rate in videoFormat.GetFrameRateRangeAsStringList())
            {
                _cbVideoFrameRate[slot].Items.Add(rate);
            }

            if (_cbVideoFrameRate[slot].Items.Count > 0)
            {
                _cbVideoFrameRate[slot].SelectedIndex = 0;
            }
        }

        private async void cbAudioDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_cbAudioFormat == null || sender is not ComboBox combo || e.AddedItems.Count == 0)
            {
                return;
            }

            int slot = SlotFromTag(combo.Tag);
            var deviceName = e.AddedItems[0]?.ToString();
            if (string.IsNullOrEmpty(deviceName))
            {
                return;
            }

            var device = (await DeviceEnumerator.Shared.AudioSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null)
            {
                return;
            }

            _cbAudioFormat[slot].Items.Clear();
            const string defaultValue = "S16LE 44100 Hz 2 ch.";
            bool defaultExists = false;
            foreach (var format in device.Formats)
            {
                _cbAudioFormat[slot].Items.Add(format.Name);
                if (format.Name == defaultValue)
                {
                    defaultExists = true;
                }
            }

            if (_cbAudioFormat[slot].Items.Count > 0)
            {
                _cbAudioFormat[slot].SelectedIndex = 0;
                if (defaultExists)
                {
                    _cbAudioFormat[slot].Text = defaultValue;
                }
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn)
            {
                return;
            }

            int slot = SlotFromTag(btn.Tag);
            try
            {
                await StartPipelineAsync(slot);
                SetStatus(slot, "Recording", System.Windows.Media.Brushes.Green);
            }
            catch (Exception ex)
            {
                Log($"[Pipeline {slot + 1}] Start failed: {ex.Message}");
                SetStatus(slot, "Error", System.Windows.Media.Brushes.Red);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button btn)
            {
                return;
            }

            int slot = SlotFromTag(btn.Tag);
            await StopPipelineAsync(slot);
            SetStatus(slot, "Idle", System.Windows.Media.Brushes.Gray);
        }

        private async void btStartAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < PipelineCount; i++)
            {
                try
                {
                    await StartPipelineAsync(i);
                    SetStatus(i, "Recording", System.Windows.Media.Brushes.Green);
                }
                catch (Exception ex)
                {
                    Log($"[Pipeline {i + 1}] Start failed: {ex.Message}");
                    SetStatus(i, "Error", System.Windows.Media.Brushes.Red);
                }
            }
        }

        private async void btStopAll_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < PipelineCount; i++)
            {
                await StopPipelineAsync(i);
                SetStatus(i, "Idle", System.Windows.Media.Brushes.Gray);
            }
        }

        private async Task StartPipelineAsync(int slot)
        {
            // Recreate the core if it was disposed (e.g. after a previous StopAsync) or never created.
            if (_cores[slot] == null)
            {
                CreateCore(slot);
            }

            var core = _cores[slot];

            var videoDeviceName = _cbVideoDevice[slot].Text;
            var videoFormatName = _cbVideoFormat[slot].Text;
            var frameRateText = _cbVideoFrameRate[slot].Text;
            var audioDeviceName = _cbAudioDevice[slot].Text;
            var audioFormatName = _cbAudioFormat[slot].Text;
            var encoderName = _cbVideoEncoder[slot].Text;

            // Video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;
            if (!string.IsNullOrEmpty(videoDeviceName))
            {
                var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                    .FirstOrDefault(d => d.DisplayName == videoDeviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(f => f.Name == videoFormatName);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        if (!string.IsNullOrEmpty(frameRateText))
                        {
                            videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(frameRateText));
                        }
                    }
                }
            }

            core.Video_Source = videoSourceSettings;

            // Audio source
            bool recordAudio = _cbRecordAudio[slot].IsChecked == true;
            core.Audio_Record = recordAudio;
            core.Audio_Play = false;

            IVideoCaptureBaseAudioSourceSettings audioSourceSettings = null;
            if (recordAudio && !string.IsNullOrEmpty(audioDeviceName))
            {
                var device = (await DeviceEnumerator.Shared.AudioSourcesAsync())
                    .FirstOrDefault(d => d.DisplayName == audioDeviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(f => f.Name == audioFormatName);
                    audioSourceSettings = formatItem != null
                        ? device.CreateSourceSettingsVC(formatItem.ToFormat())
                        : device.CreateSourceSettingsVC();
                }
            }

            core.Audio_Source = audioSourceSettings;

            // Encoder + output
            if (!_encoderFactories.TryGetValue(encoderName, out var encoderFactory))
            {
                throw new InvalidOperationException($"Unknown encoder: {encoderName}");
            }

            var filename = Path.Combine(edOutputFolder.Text, $"output_{slot + 1}.mp4");
            var mp4Output = recordAudio
                ? new MP4Output(filename, new NVENCH264EncoderSettings(), new AVENCAACEncoderSettings())
                : new MP4Output(filename, new NVENCH264EncoderSettings());

            core.Outputs_Clear();
            core.Outputs_Add(mp4Output, autostart: true);

            await core.StartAsync();
        }

        private async Task StopPipelineAsync(int slot)
        {
            var core = _cores[slot];
            if (core == null)
            {
                return;
            }

            try
            {
                await core.StopAsync();
            }
            catch (Exception ex)
            {
                Log($"[Pipeline {slot + 1}] Stop error: {ex.Message}");
            }
        }

        private void btSelectOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFolderDialog
            {
                InitialDirectory = Directory.Exists(edOutputFolder.Text)
                    ? edOutputFolder.Text
                    : Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            };

            if (dlg.ShowDialog() == true)
            {
                edOutputFolder.Text = dlg.FolderName;
            }
        }
    }
}
