using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace MJPEG_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private HTTPSourceBlock _source;

        private JPEGDecoderBlock _jpegDecoder;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
        }

        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                _pipeline.OnError -= Pipeline_OnError;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            //_pipeline.Debug_Mode = cbDebugMode.IsChecked == true;
            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var settings = new HTTPSourceSettings(new Uri(edURL.Text))
            {
                UserID = edUserName.Text,
                UserPassword = edPassword.Text
            };

            _source = new HTTPSourceBlock(settings);
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            _jpegDecoder = new JPEGDecoderBlock();

            _pipeline.Connect(_source.Output, _jpegDecoder.Input);
            _pipeline.Connect(_jpegDecoder.Output, _videoRenderer.Input);

            await _pipeline.StartAsync();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await DestroyEngineAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
