using System;
using System.Windows;
using System.IO;
using System.ComponentModel;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.MediaBlocks.Parsers;

namespace replace_audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private BasicFileSourceBlock _videoSourceFile;

        private ParseBinBlock _videoSource;

        private BasicFileSourceBlock _audioSourceFile;

        private MediaBlock _audioSource;

        private MP4SinkBlock _mp4Sink;

        private string _outputFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }
            
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(edSourceVideoFile.Text))
            {
                MessageBox.Show("Please select video file.");
                return;
            }

            if (cbRemoveAudio.IsChecked == false && !File.Exists(edSourceAudioFile.Text))
            {
                MessageBox.Show("Please select audio file.");
                return;
            }

            // Create VideoCaptureCoreX object
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnStop += _pipeline_OnStop;

            // Create video source
            _videoSourceFile = new BasicFileSourceBlock(edSourceVideoFile.Text);
            _videoSource = new ParseBinBlock();

            // MP4 output
            _outputFile = Path.Combine(Path.GetDirectoryName(edSourceVideoFile.Text), "new_output.mp4");
            _mp4Sink = new MP4SinkBlock(_outputFile);

            // Create audio source
            if (cbRemoveAudio.IsChecked == false)
            {
                _audioSourceFile = new BasicFileSourceBlock(edSourceAudioFile.Text);

                bool mp3 = edSourceAudioFile.Text.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase);
                if (mp3)
                {
                    _audioSource = new MPEGAudioParseBlock();
                }
                else
                {
                    _audioSource = new ParseBinBlock();
                }
            }
         
            // Connect everything
            _pipeline.Connect(_videoSourceFile.Output, _videoSource.Input);
                        
            var videoInputPad = _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video);

            // Catch EOS for video stream, to prevent creation of files with long audio and short video. File duration = video duration.
            videoInputPad.OnEOS += async (sender, args) => { 
                _pipeline.SendEOS();
            };

            _pipeline.Connect(_videoSource.GetOutputPadByType(MediaBlockPadMediaType.Video), videoInputPad);

            if (cbRemoveAudio.IsChecked == false)
            {
                _pipeline.Connect(_audioSourceFile.Output, _audioSource.Input);
                _pipeline.Connect(_audioSource.GetOutputPadByType(MediaBlockPadMediaType.Audio), _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
            }

            // Start
            await _pipeline.StartAsync();
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

        private void btSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "MP4 files|*.mp4";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                edSourceVideoFile.Text = dlg.FileName;
            }
        }

        private void btSelectAudio_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "MP3 files|*.mp3|AAC files|*.m4a";
            var result = dlg.ShowDialog();
            if (result == true)
            {
                edSourceAudioFile.Text = dlg.FileName;
            }
        }
    }
}