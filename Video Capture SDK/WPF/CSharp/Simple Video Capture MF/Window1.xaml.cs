using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.Output;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.UI;
using VisioForge.Core.VideoCapture;

namespace Simple_Video_Capture_MF
{
    public partial class Window1 : Window
    {
        private VideoCaptureCore _capture;

        private Task<bool> _start;

        private Task _stopTask;

        private bool _running;

        private bool _stop;

        private bool _closing;

        private bool _closeNow;

        public Window1()
        {
            InitializeComponent();
            edOutput.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyVideos),
                "VisioForge",
                "capture-mf.mp4");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _capture = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);
            _capture.OnError += Capture_OnError;
            Title += " (SDK v" + _capture.SDK_Version() + ")";

            if (!VideoCaptureSource.IsMediaFoundationCaptureAvailable())
            {
                Log("Media Foundation camera capture is not available on this Windows version.");
                btStart.IsEnabled = false;
                return;
            }

            foreach (MediaFoundationCaptureDevice camera in _capture.Video_MediaFoundationCaptureDevices())
            {
                cbCamera.Items.Add(camera);
            }

            if (cbCamera.Items.Count == 0)
            {
                Log("No Media Foundation camera could be opened.");
                btStart.IsEnabled = false;
                return;
            }

            cbCamera.SelectedIndex = 0;
        }

        private void cbCamera_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFormat.Items.Clear();
            cbFrameRate.Items.Clear();

            var camera = cbCamera.SelectedItem as MediaFoundationCaptureDevice;
            if (camera == null)
            {
                return;
            }

            foreach (MediaFoundationCaptureFormat format in camera.Formats)
            {
                cbFormat.Items.Add(format);
            }

            int selected = BestFormatIndex(camera);
            if (selected >= 0)
            {
                cbFormat.SelectedIndex = selected;
            }
        }

        private void cbFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFrameRate.Items.Clear();

            var format = cbFormat.SelectedItem as MediaFoundationCaptureFormat;
            if (format == null)
            {
                return;
            }

            // The capture source accepts at most 100 fps. A faster listed rate stays in the list.
            int selected = 0;
            for (int i = 0; i < format.FrameRates.Count; i++)
            {
                cbFrameRate.Items.Add(format.FrameRates[i]);
                double candidate = format.FrameRates[i].Value;
                double current = format.FrameRates[selected].Value;
                if (candidate <= 100 ? current > 100 || candidate > current : current > 100 && candidate > current)
                {
                    selected = i;
                }
            }

            if (cbFrameRate.Items.Count > 0)
            {
                cbFrameRate.SelectedIndex = selected;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            var camera = cbCamera.SelectedItem as MediaFoundationCaptureDevice;
            var format = cbFormat.SelectedItem as MediaFoundationCaptureFormat;
            if (_capture == null || camera == null || format == null)
            {
                return;
            }

            _stop = false;
            _stopTask = null;
            btStart.IsEnabled = false;
            mmLog.Clear();

            var source = new VideoCaptureSource(camera);
            source.Format = format.Name;
            source.Format_UseBest = false;
            if (cbFrameRate.SelectedItem is VideoFrameRate rate && !rate.IsEmpty)
            {
                source.FrameRate = rate;
            }

            _capture.Video_CaptureDevice = source;
            _capture.Audio_PlayAudio = false;
            _capture.Audio_RecordAudio = false;
            _capture.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;

            if (rbCapture.IsChecked == true)
            {
                string folder = Path.GetDirectoryName(edOutput.Text);
                if (!string.IsNullOrEmpty(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                _capture.Mode = VideoCaptureMode.VideoCapture;
                _capture.Output_Filename = edOutput.Text;
                _capture.Output_Format = new MP4Output();
            }
            else
            {
                _capture.Mode = VideoCaptureMode.VideoPreview;
            }

            _start = _capture.StartAsync();
            bool started = await _start;
            _start = null;
            // Stop was clicked while the camera was opening. That handler owns the teardown.
            if (_stop)
            {
                return;
            }

            if (_closing)
            {
                _running = started;
                return;
            }

            _running = started;
            if (!_running)
            {
                btStart.IsEnabled = true;
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_capture == null || _stop || (_start == null && !_running))
            {
                return;
            }

            _stop = true;
            btStop.IsEnabled = false;
            _stopTask = StopOpenedCaptureAsync();
            await _stopTask;
            _running = false;
            if (_closing)
            {
                return;
            }

            btStop.IsEnabled = true;
            btStart.IsEnabled = true;
        }

        private async Task StopOpenedCaptureAsync()
        {
            Task<bool> start = _start;
            if ((start == null || await start) && _capture != null)
            {
                await _capture.StopAsync();
            }
        }

        private void btSelectOutput_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "MP4|*.mp4",
                FileName = Path.GetFileName(edOutput.Text),
                InitialDirectory = Path.GetDirectoryName(edOutput.Text)
            };

            if (dialog.ShowDialog() == true)
            {
                edOutput.Text = dialog.FileName;
            }
        }

        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            if (_closeNow)
            {
                return;
            }

            e.Cancel = true;
            if (_closing)
            {
                return;
            }

            _closing = true;
            btStart.IsEnabled = false;
            btStop.IsEnabled = false;

            // Close() throws while this Closing call is still on the stack.
            await System.Windows.Threading.Dispatcher.Yield();
            Hide();

            try
            {
                if (_capture != null)
                {
                    _capture.OnError -= Capture_OnError;
                    try
                    {
                        Task<bool> start = _start;
                        bool started = start != null && await start;

                        // Stop clicked during open is already tearing the graph down.
                        Task stop = _stopTask;
                        if (stop != null)
                        {
                            await stop;
                        }
                        else if (started || _running)
                        {
                            await _capture.StopAsync();
                            _running = false;
                        }
                    }
                    finally
                    {
                        if (_capture != null)
                        {
                            _capture.Dispose();
                            _capture = null;
                        }
                    }
                }
            }
            finally
            {
                _closeNow = true;
                Close();
            }
        }

        private void Capture_OnError(object sender, ErrorsEventArgs e)
        {
            Log(e.Message);
        }

        private void Log(string text)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                mmLog.AppendText(text + Environment.NewLine);
                mmLog.ScrollToEnd();
            }));
        }

        private static int BestFormatIndex(MediaFoundationCaptureDevice camera)
        {
            int within = -1;
            long withinPixels = -1;
            int largest = -1;
            long largestPixels = -1;
            for (int i = 0; i < camera.Formats.Count; i++)
            {
                MediaFoundationCaptureFormat format = camera.Formats[i];
                long pixels = (long)format.Width * format.Height;
                if (largest < 0 || pixels > largestPixels)
                {
                    largest = i;
                    largestPixels = pixels;
                }

                if (format.Width <= 1920 && format.Height <= 1080 && pixels > withinPixels)
                {
                    within = i;
                    withinPixels = pixels;
                }
            }

            return within >= 0 ? within : largest;
        }
    }
}
