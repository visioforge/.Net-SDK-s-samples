using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.Special;
using System.ComponentModel;
using VisioForge.Core.MediaBlocks.Sinks;
using System.IO;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using System.Net.Http;
using VisioForge.Core.MediaBlocks.VideoDecoders;
using VisioForge.Core.Types.Events;
using System.Drawing;
using System.Threading;
using System;

namespace video_from_images
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private PushSourceBlock _source;

        private JPEGDecoderBlock _jpegDecoder;

        private string _outputFile;

        private string[] _files;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await VisioForgeX.InitSDKAsync();

            edSourceFolder.Text = "c:\\Samples\\pics\\src\\";
        }

        private bool LoadImages(out int width, out int height)
        {
            // get images
            _files = System.IO.Directory.GetFiles(edSourceFolder.Text);

            // read first image to get resolution
            var firstImage = new Bitmap(_files[0]);

            width = firstImage.Width;
            height = firstImage.Height;

            firstImage.Dispose();

            // check resolution
            foreach (var file in _files)
            {
                var image = new Bitmap(file);
                if (image.Width != width || image.Height != height)
                {
                    MessageBox.Show("All images must have the same resolution.");
                    image.Dispose();
                    return false;
                }

                image.Dispose();
            }

            return true;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            // Create VideoCaptureCoreX object
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnStop += _pipeline_OnStop;

            // Create video renderer
            var videoRenderer = new VideoRendererBlock(_pipeline, videoView1) { IsSync = false };

            // Load images
            if (!LoadImages(out int width, out int height))
                { 
                return; 
            }

            // Create source
            var jpegSource = new PushJPEGSourceSettings(1280, 720, VideoFrameRate.FPS_25);
            _source = new PushSourceBlock(jpegSource);

            // JPEG decoder
            _jpegDecoder = new JPEGDecoderBlock();

            // Video tee
            var tee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            // Connect blocks
            _pipeline.Connect(_source, _jpegDecoder);
            _pipeline.Connect(_jpegDecoder, tee);
            _pipeline.Connect(tee, videoRenderer);

            // MP4 output
            _outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "jpegs.mp4");
            var mp4Output = new MP4OutputBlock(new MP4SinkSettings(_outputFile), h264settings: new OpenH264EncoderSettings(), aacSettings: null);
            _pipeline.Connect(tee.Outputs[1], mp4Output.CreateNewInput(MediaBlockPadMediaType.Video));

            // Start
            await _pipeline.StartAsync(onlyPreload: true);

            // Push data loop
            var _pushThread = new Thread(async () =>
            {
                // Load images
                foreach (var file in _files)
                {
                    var data = System.IO.File.ReadAllBytes(file);
                    for (int i = 0; i < VideoFrameRate.FPS_25.Num; i++)
                    {
                        _source.PushData(data, data.Length);
                    }
                }

                _source.SendEOS();
            });

            _pushThread.Start();

            // Start playback
            await _pipeline.ResumeAsync();
        }

        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            _pipeline.OnStop -= _pipeline_OnStop;

            Dispatcher.Invoke(() =>
            {
                _pipeline?.Dispose();
                _pipeline = null;

                MessageBox.Show("Done. Video saved to " + _outputFile);
            });
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            await _pipeline.DisposeAsync();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private void btSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                edSourceFolder.Text = dlg.SelectedPath;
            }
        }
    }
}