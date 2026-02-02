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
using VisioForge.Core.VideoEditX;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.VideoEncoders;

namespace replace_audio
{
    /// <summary>
    /// Interaction logic for the replace-audio snippet MainWindow.
    /// Demonstrates how to replace or remove audio tracks from a video file using the X-engine.
    /// </summary>
    public partial class MainWindow : Window
    {
        private VideoEditCoreX _core;

        private string _outputFile;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// Initializes the SDK engine on startup.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }
            
        /// <summary>
        /// Handles the Click event of the btStart control.
        /// Configures and starts the process of replacing or removing audio from the video source.
        /// </summary>
        private void btStart_Click(object sender, RoutedEventArgs e)
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

            // Create VideoEditCoreX object
            _core = new VideoEditCoreX();
            _core.OnStop += _pipeline_OnStop;

            // Create video source
            _core.Input_AddVideoFile(edSourceVideoFile.Text);

            //_core.Input_AddAudioFile(edSourceAudioFile.Text);

            // MP4 output
            _outputFile = Path.Combine(Path.GetDirectoryName(edSourceVideoFile.Text), "new_output.mp4");
            _core.Output_Format = new MP4Output(_outputFile, new NVENCH264EncoderSettings());
           
            //// Create audio source
            //if (cbRemoveAudio.IsChecked == false)
            //{
            //    _audioSourceFile = new BasicFileSourceBlock(edSourceAudioFile.Text);

            //    bool mp3 = edSourceAudioFile.Text.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase);
            //    if (mp3)
            //    {
            //        _audioSource = new MPEGAudioParseBlock();
            //    }
            //    else
            //    {
            //        _audioSource = new ParseBinBlock();
            //    }
            //}
         
            //// Connect everything
            //_pipeline.Connect(_videoSourceFile.Output, _videoSource.Input);
                        
            //var videoInputPad = _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video);

            //// Catch EOS for video stream, to prevent creation of files with long audio and short video. File duration = video duration.
            //videoInputPad.OnEOS += async (senderX, argsX) => { 
            //    _pipeline.SendEOS();
            //};

            //_pipeline.Connect(_videoSource.GetOutputPadByType(MediaBlockPadMediaType.Video), videoInputPad);

            //if (cbRemoveAudio.IsChecked == false)
            //{
            //    _pipeline.Connect(_audioSourceFile.Output, _audioSource.Input);
            //    _pipeline.Connect(_audioSource.GetOutputPadByType(MediaBlockPadMediaType.Audio), _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Audio));
            //}

            // Start
            _core.Start();
        }

        /// <summary>
        /// Event handler for the engine's OnStop event.
        /// Cleans up resources and notifies the user of completion.
        /// </summary>
        private void _pipeline_OnStop(object sender, StopEventArgs e)
        {
            _core.OnStop -= _pipeline_OnStop;

            Dispatcher.Invoke(() =>
            {
                _core?.Dispose();
                _core = null;

                MessageBox.Show("Done. Video saved to " + _outputFile);
            });
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// Stops the current operation and disposes of the engine.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        { 
            if (_core == null)
            {
                return;
            }
                    
            _core.Stop();

            _core.Dispose();
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// Ensures the SDK resources are released upon closing.
        /// </summary>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt select video click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt select audio click event.
        /// </summary>
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