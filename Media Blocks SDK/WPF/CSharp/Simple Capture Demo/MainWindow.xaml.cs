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
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.GST.VideoCapture;

namespace MediaBlocks_Simple_Video_Capture_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        public MainWindow()
        {
            InitializeComponent();

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var videoCaptureDevices = SystemVideoSourceBlock.GetDevices(_pipeline);
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show("Select video input device");
                return;
            }

            var videoSourceSettings = new VideoCaptureDeviceSourceSettings(cbVideoInput.Text);
            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            var videoRendererBlock = new VideoRendererBlock(videoView, true);
            _pipeline.Connect(_videoSource.Output, videoRendererBlock.Input);

            await _pipeline.StartAsync();
        }
    }
}
