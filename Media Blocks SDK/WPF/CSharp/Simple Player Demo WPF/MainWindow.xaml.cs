using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using System.Diagnostics;


namespace MediaBlocks_Simple_Player_Demo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The update timer.
        /// </summary>
        private System.Timers.Timer _timer;

        /// <summary>
        /// Indicates whether the timer is currently processing an update.
        /// </summary>
        private volatile bool _timerFlag;

        /// <summary>
        /// The pipeline.
        /// </summary>
        private MediaBlocksPipeline _pipeline;

        /// <summary>
        /// The video renderer.
        /// </summary>
        private VideoRendererBlock _videoRenderer;

        /// <summary>
        /// The audio renderer.
        /// </summary>
        private AudioRendererBlock _audioRenderer;

        /// <summary>
        /// The file source.
        /// </summary>
        private UniversalSourceBlockV2 _fileSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // We have to initialize the engine on start
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                this.IsEnabled = false;
                await VisioForgeX.InitSDKAsync();
                this.IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += _timer_Elapsed;

                var audioOutputDevices = (await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound)).ToArray();
                cbAudioOutput.Items.Clear();
                if (audioOutputDevices.Length > 0)
                {
                    foreach (var item in audioOutputDevices)
                    {
                        cbAudioOutput.Items.Add(item.DisplayName);
                    }

                    cbAudioOutput.SelectedIndex = 0;
                }

                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the OnError event of the Pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                edLog.Text = edLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Handles the OnStop event of the Pipeline.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="StopEventArgs"/> instance containing the event data.</param>
        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                _timer.Stop();
                tbTimeline.Value = 0;
            }));
        }

        /// <summary>
        /// Asynchronously creates the media engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task CreateEngineAsync()
        {
            _pipeline = new MediaBlocksPipeline();
            _pipeline.OnError += Pipeline_OnError;
            _pipeline.OnStop += Pipeline_OnStop;
            _pipeline.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            _fileSource = new UniversalSourceBlockV2(await UniversalSourceSettingsV2.CreateAsync(new Uri(edFilename.Text)));

            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

            //VideoView1.SetNativeRendering(true);            

            _pipeline.Connect(_fileSource.VideoOutput, _videoRenderer.Input);

            _audioRenderer = new AudioRendererBlock((await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).Where(device => device.DisplayName == cbAudioOutput.Text).First());
            _pipeline.Connect(_fileSource.AudioOutput, _audioRenderer.Input);
        }

        /// <summary>
        /// Handles the Elapsed event of the timer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timerFlag = true;

                var position = await _pipeline.Position_GetAsync();
                var duration = await _pipeline.DurationAsync();

                Dispatcher.Invoke((Action)(() =>
                {
                    tbTimeline.Maximum = (int)duration.TotalSeconds;

                    lbTime.Text = position.ToString("hh\\:mm\\:ss") + " | " + duration.ToString("hh\\:mm\\:ss");

                    if (tbTimeline.Maximum >= position.TotalSeconds)
                    {
                        tbTimeline.Value = (int)position.TotalSeconds;
                    }
                }));

                _timerFlag = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Asynchronously stops the media engine.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task StopEngineAsync()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                await _pipeline.StopAsync(true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Destroys the media engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;
                _pipeline.OnStop -= Pipeline_OnStop;
                _pipeline.Stop(true);
                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        /// <summary>
        /// Handles the Click event of the btSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbTimeline control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                if (!_timerFlag && _pipeline != null)
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                edLog.Clear();

                await CreateEngineAsync();

                _pipeline.Debug_Mode = cbDebugMode.IsChecked == true;

                await _pipeline.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btStop control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _timer.Stop();

                if (_pipeline != null)
                {
                    await StopEngineAsync();
                }

                tbTimeline.Value = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btPause control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _pipeline.PauseAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of the btResume control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _pipeline.ResumeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the tbVolume control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Double}"/> instance containing the event data.</param>
        private void tbVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_audioRenderer != null)
            {
                _audioRenderer.Volume = tbVolume.Value / 100.0;
            }
        }

        /// <summary>
        /// Handles the Closing event of the Window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                DestroyEngine();
            }

            VisioForgeX.DestroySDK();
        }
    }
}
