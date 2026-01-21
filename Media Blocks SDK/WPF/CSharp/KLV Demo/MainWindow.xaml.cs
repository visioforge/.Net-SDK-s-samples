using Microsoft.Win32;
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
using VisioForge.Core;
using VisioForge.Core.Experimental;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Metadata;
using VisioForge.Core.Metadata.KLV;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Metadata;
using VisioForge.Core.Types.X.Sinks;

namespace KLV_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private BasicFileSourceBlock _fileSource;

        private MPEGTSDemuxBlock _demux;

        // private MPEGTSSinkBlock _sink;

        private KLVFileSinkBlock _klvSink; 

        public MainWindow()
        {
            InitializeComponent();

            // We have to initialize the engine on start
            VisioForgeX.InitSDK();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Pipeline on error.
        /// </summary>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                //edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Pipeline on stop.
        /// </summary>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                MessageBox.Show(this, "Complete");                
            }));

            _pipeline.Close();
        }

        /// <summary>
        /// Create extract engine.
        /// </summary>
        private void CreateExtractEngine()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new BasicFileSourceBlock(edSrcTSFile.Text);
            _demux = new MPEGTSDemuxBlock(false, renderMetadata: true);
            _klvSink = new KLVFileSinkBlock(edOutputKLVFile.Text);

            _pipeline.Connect(_fileSource.Output, _demux.Input);
            _pipeline.Connect(_demux.MetadataOutput, _klvSink.Input);
        }

        //private void CreateRemuxEngine()
        //{
        //    _pipeline = new MediaBlocksPipeline(false);
        //    _pipeline.OnError += Pipeline_OnError;
        //    _pipeline.OnStop += Pipeline_OnStop;
        //    _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

        //    _fileSource = new BasicFileSourceBlock(edSrcTSFile2.Text);
        //    _demux = new MPEGTSDemuxBlock(renderVideo: true);

        //    var tsSettings = new MPEGTSSinkSettings(edOutputTSFile.Text);
        //    tsSettings.Metadata = new KLVMetadata(edSrcKLVFile.Text);
        //    _sink = new MPEGTSSinkBlock(tsSettings);

        //    _pipeline.Connect(_fileSource.Output, _demux.Input);
        //    _pipeline.Connect(_demux.VideoOutput, _sink.CreateNewInput(MediaBlockPadMediaType.Video));
        //}

        /// <summary>
        /// Destroy engine async.
        /// </summary>
        private async Task DestroyEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the bt open ts file click event.
        /// </summary>
        private void btOpenTSFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                edSrcTSFile.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt save klv file click event.
        /// </summary>
        private void btSaveKLVFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                edOutputKLVFile.Text = saveFileDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt start extract click event.
        /// </summary>
        private async void btStartExtract_Click(object sender, RoutedEventArgs e)
        {
            await DestroyEngineAsync();
            CreateExtractEngine();

            await _pipeline.StartAsync();
        }

        /// <summary>
        /// Handles the bt stop extract click event.
        /// </summary>
        private async void btStopExtract_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            await _pipeline.StopAsync();

            await DestroyEngineAsync();
        }

        //private async void btStartRemux_Click(object sender, RoutedEventArgs e)
        //{
        //    DestroyEngine();
        //    CreateRemuxEngine();

        //    await _pipeline.StartAsync();
        //}

        //private async void btStopRemux_Click(object sender, RoutedEventArgs e)
        //{
        //    if (_pipeline == null)
        //    {
        //        return;
        //    }

        //    await _pipeline.StopAsync();

        //    DestroyEngine();
        //}

        //private void btOpenTSFile2_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        edSrcTSFile2.Text = openFileDialog.FileName;
        //    }
        //}

        //private void btOpenSrcKLVFile_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        edSrcKLVFile.Text = openFileDialog.FileName;
        //    }
        //}

        //private void btSaveTSFile_Click(object sender, RoutedEventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    if (saveFileDialog.ShowDialog() == true)
        //    {
        //        edOutputTSFile.Text = saveFileDialog.FileName;
        //    }
        //}

        /// <summary>
        /// Handles the bt open viewer src klv file click event.
        /// </summary>
        private void btOpenViewerSrcKLVFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                edViewerKLVFile.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Handles the bt viewer parse click event.
        /// </summary>
        private void btViewerParse_Click(object sender, RoutedEventArgs e)
        {
            edViewerData.Text = string.Empty;

            var klv = new KLVParser(edViewerKLVFile.Text);

            int k = 0;
            foreach (var item in klv.Elements)
            {
                edViewerData.Text += item.ToString() + Environment.NewLine;
                k++;

                if (k > 100)
                {
                    break;
                }
            }
        }
    }
}
