namespace PIP_Two_Webcams
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.UI;
    using VisioForge.Core.VideoCapture;

    public partial class MainWindow : IDisposable
    {
        private VideoCaptureCore VideoCapture1;

        private bool disposedValue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task CreateEngineAsync()
        {
            VideoCapture1 = await VideoCaptureCore.CreateAsync(VideoView1 as IVideoView);
            VideoCapture1.OnError += VideoCapture1_OnError;
        }

        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await CreateEngineAsync();

            Title += $" (SDK v{VideoCapture1.SDK_Version()})";

            foreach (var device in VideoCapture1.Video_CaptureDevices())
            {
                cbMainDevice.Items.Add(device.Name);
                cbPIPDevice.Items.Add(device.Name);
            }

            if (cbMainDevice.Items.Count > 0)
            {
                cbMainDevice.SelectedIndex = 0;
            }

            if (cbPIPDevice.Items.Count > 1)
            {
                cbPIPDevice.SelectedIndex = 1;
            }
            else if (cbPIPDevice.Items.Count > 0)
            {
                cbPIPDevice.SelectedIndex = 0;
            }
        }

        private void cbMainDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            cbMainFormat.Items.Clear();

            var deviceItem = VideoCapture1.Video_CaptureDevices()
                .FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                cbMainFormat.Items.Add(format);
            }

            if (cbMainFormat.Items.Count > 0)
            {
                cbMainFormat.SelectedIndex = 0;
            }
        }

        private void cbPIPDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            cbPIPFormat.Items.Clear();

            var deviceItem = VideoCapture1.Video_CaptureDevices()
                .FirstOrDefault(device => device.Name == e.AddedItems[0].ToString());
            if (deviceItem == null)
            {
                return;
            }

            foreach (var format in deviceItem.VideoFormats)
            {
                cbPIPFormat.Items.Add(format);
            }

            if (cbPIPFormat.Items.Count > 0)
            {
                cbPIPFormat.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            if (string.IsNullOrEmpty(cbMainDevice.Text) || string.IsNullOrEmpty(cbPIPDevice.Text))
            {
                mmLog.Text = "Please select both main and PIP cameras.";
                return;
            }

            // Main camera
            VideoCapture1.Video_CaptureDevice = new VideoCaptureSource(cbMainDevice.Text);
            if (!string.IsNullOrEmpty(cbMainFormat.Text))
            {
                VideoCapture1.Video_CaptureDevice.Format = cbMainFormat.Text;
            }

            VideoCapture1.Video_CaptureDevice.Format_UseBest = true;

            // PIP mode
            VideoCapture1.PIP_Mode = PIPMode.Custom;
            VideoCapture1.PIP_ResizeQuality = PIPResizeQuality.RQ_LINEAR;

            // Add PIP camera
            int.TryParse(edPIPLeft.Text, out int pipLeft);
            int.TryParse(edPIPTop.Text, out int pipTop);
            int.TryParse(edPIPWidth.Text, out int pipWidth);
            int.TryParse(edPIPHeight.Text, out int pipHeight);

            if (pipWidth <= 0)
            {
                pipWidth = 320;
            }

            if (pipHeight <= 0)
            {
                pipHeight = 240;
            }

            VideoCapture1.PIP_Sources_Add_VideoCaptureDevice(
                cbPIPDevice.Text,
                cbPIPFormat.Text,
                true,
                new VideoFrameRate(30),
                null,
                pipLeft, pipTop, pipWidth, pipHeight);

            // Preview mode
            VideoCapture1.Mode = VideoCaptureMode.VideoPreview;
            VideoCapture1.Audio_PlayAudio = false;
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;

            await VideoCapture1.StartAsync();

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await VideoCapture1.StopAsync();

            VideoCapture1.PIP_Sources_Clear();

            btStart.IsEnabled = true;
            btStop.IsEnabled = false;
        }

        private async void btUpdatePIP_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(edPIPLeft.Text, out int pipLeft);
            int.TryParse(edPIPTop.Text, out int pipTop);
            int.TryParse(edPIPWidth.Text, out int pipWidth);
            int.TryParse(edPIPHeight.Text, out int pipHeight);

            // PIP index is 1-based
            await VideoCapture1.PIP_Sources_SetSourcePositionAsync(
                1,
                new Rectangle(pipLeft, pipTop, pipWidth, pipHeight));
        }

        private async void slTransparency_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (tbTransparencyValue != null)
            {
                int value = (int)e.NewValue;
                tbTransparencyValue.Text = value.ToString();

                if (VideoCapture1 != null && btStop.IsEnabled)
                {
                    // PIP index is 1-based
                    await VideoCapture1.PIP_Sources_SetSourceSettingsAsync(
                        1, value, false, false);
                }
            }
        }

        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                mmLog.Text += e.Message + Environment.NewLine;
            }));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DestroyEngine();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    VideoCapture1?.Dispose();
                    VideoCapture1 = null;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
