using System;
using System.Diagnostics;
using System.IO;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;

namespace SRT_Source_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        private AudioRendererBlock _audioRenderer;
        
        private SRTSourceBlock _source;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.Application.EnableVisualStyles();

            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private void CreateEngine()
        {
            _pipeline = new MediaBlocksPipeline(true);
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

        private void UpdateRecordingTime()
        {            
            //var ts = _pipeline.Duration();

            //if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            //{
            //    return;
            //}

            //Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    lbTimestamp.Text = "Recording time: " + ts.ToString(@"hh\:mm\:ss");
            //}));
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            _pipeline.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            var settings = await SRTSourceSettings.CreateAsync(edURL.Text);
            _source = new SRTSourceBlock(settings);

            bool hasVideo = true;
            bool hasAudio = true;

            if (settings.GetInfo()?.VideoStreams.Count == 0)
            {
                hasVideo = false;
            }

            if (settings.GetInfo()?.AudioStreams.Count == 0)
            {
                hasAudio = false;
            }

            if (hasVideo)
            {
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                _pipeline.Connect(_source.VideoOutput, _videoRenderer.Input);
            }

            if (hasAudio)
            {
                _audioRenderer = new AudioRendererBlock();
                _pipeline.Connect(_source.AudioOutput, _audioRenderer.Input);
            }

            await _pipeline.StartAsync();

            tmRecording.Start();
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();            

            await DestroyEngineAsync();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }
    }
}
