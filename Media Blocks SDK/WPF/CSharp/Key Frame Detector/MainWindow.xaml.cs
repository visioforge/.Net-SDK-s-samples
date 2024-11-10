using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaInfoReaderX;
using System.Diagnostics;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using System;

namespace key_frame_detector_mb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await VisioForgeX.InitSDKAsync();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            _timer = new System.Timers.Timer(250);
            _timer.Elapsed += async (s, ev) =>
            {
                if (_pipeline != null)
                {
                    var pos = await _pipeline.Position_GetAsync();
                    var dur = await _pipeline.DurationAsync();

                    var progress = (int)(100 * pos.Ticks / dur.Ticks);

                    await Dispatcher.InvokeAsync(() =>
                    {
                        pbProgress.Value = progress;
                    });
                }
            };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            btStart.IsEnabled = true;
            btStop.IsEnabled = false;

            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();
            await _pipeline.DisposeAsync();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            var sourceFile = edSourceFile.Text;
            string jsonFile = sourceFile + ".json";

            // create pipeline
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnStop += async (senderx, ex) =>
            {
                _timer.Stop();

                Debug.WriteLine("Pipeline stopped.");

                await _pipeline.DisposeAsync();
                _pipeline = null;

                await Dispatcher.InvokeAsync(() =>
                {
                    btStart.IsEnabled = true;
                    btStop.IsEnabled = false;
                    pbProgress.Value = 0;

                    MessageBox.Show(this, $"Timestamps saved to {jsonFile}.");
                });
            };

            // add file source
            var fileSource = new BasicFileSourceBlock(sourceFile);

            // read video info
            var infoReader = new MediaInfoReaderX();
            await infoReader.OpenAsync(sourceFile);

            // add demux
            var demux = new UniversalDemuxBlock(infoReader.Info, renderVideo: true, renderAudio: false);

            var videoNullRenderer = new NullRendererBlock(MediaBlockPadMediaType.Video);
            videoNullRenderer.IsSync = false;

            // add key frame detector and finish pipeline with null renderer
            var keyFrameDetector = new KeyFrameDetectorBlock();
            keyFrameDetector.JSONFilename = jsonFile;
            keyFrameDetector.OnKeyFrameDetected += (senderx, ex) =>
            {
                Debug.WriteLine($"Key frame detected at {e}");
            };

            // link blocks
            _pipeline.Connect(fileSource.Output, demux.Input);
            _pipeline.Connect(demux.GetVideoOutput(), keyFrameDetector.Input);
            _pipeline.Connect(keyFrameDetector.Output, videoNullRenderer.Input);

            // run pipeline
            await _pipeline.StartAsync();

            btStart.IsEnabled = false;
            btStop.IsEnabled = true;

            _timer.Start();
        }
    
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            // select file
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mp4";

            var result = dlg.ShowDialog();
            if (result == true) {
                edSourceFile.Text = dlg.FileName;
            }
        }
    }
}