using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using SkiaSharp;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using Rect = VisioForge.Core.Types.Rect;

namespace Transparent_Video_Mixer_Demo
{
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;

        private VirtualVideoSourceBlock _bgSource;
        private UniversalSourceBlock _fileSource1;
        private UniversalSourceBlock _fileSource2;

        private VideoMixerBlock _videoMixer;
        private VideoRendererBlock _videoRenderer;

        private SKColor _bgColor = new SKColor(100, 149, 237); // CornflowerBlue

        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Title += " [FIRST TIME LOAD, BUILDING THE REGISTRY...]";
                IsEnabled = false;

                await VisioForgeX.InitSDKAsync();

                IsEnabled = true;
                Title = Title.Replace(" [FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
                Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

                _timer = new System.Timers.Timer(500);
                _timer.Elapsed += Timer_Elapsed;

                LogMessage("Application ready. Select two video files with alpha transparency (WebM/MOV) and click Play.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(edFile1.Text) || string.IsNullOrWhiteSpace(edFile2.Text))
                {
                    MessageBox.Show(this, "Please select both video files.", "Missing Input",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                await DestroyPipelineAsync();

                LogMessage("Building pipeline...");

                _pipeline = new MediaBlocksPipeline();
                _pipeline.OnError += Pipeline_OnError;
                _pipeline.OnStop += Pipeline_OnStop;

                int width = Convert.ToInt32(edWidth.Text);
                int height = Convert.ToInt32(edHeight.Text);
                var frameRate = new VideoFrameRate(Convert.ToInt32(edFrameRate.Text));
                var fullRect = new Rect(0, 0, width, height);

                // Background: solid color virtual source
                var bgSettings = new VirtualVideoSourceSettings(width, height, frameRate)
                {
                    Pattern = VirtualVideoSourcePattern.SolidColor,
                    ForegroundColor = _bgColor
                };
                _bgSource = new VirtualVideoSourceBlock(bgSettings);

                // File source 1
                var settings1 = await UniversalSourceSettings.CreateAsync(
                    edFile1.Text, renderVideo: true, renderAudio: false);
                _fileSource1 = new UniversalSourceBlock(settings1);

                // File source 2
                var settings2 = await UniversalSourceSettings.CreateAsync(
                    edFile2.Text, renderVideo: true, renderAudio: false);
                _fileSource2 = new UniversalSourceBlock(settings2);

                // Mixer with 3 streams
                var mixerSettings = new VideoMixerSettings(width, height, frameRate);
                mixerSettings.Background = VideoMixerBackground.Transparent;

                // Stream 0: background (z-order 0)
                var bgStream = new VideoMixerStream(fullRect, 0, 1.0);
                mixerSettings.AddStream(bgStream);

                // Stream 1: video file 1 (z-order 1)
                mixerSettings.AddStream(new VideoMixerStream(fullRect, 1, 1.0));

                // Stream 2: video file 2 (z-order 2)
                mixerSettings.AddStream(new VideoMixerStream(fullRect, 2, 1.0));

                _videoMixer = new VideoMixerBlock(mixerSettings);

                // Renderer
                _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

                // Connect pipeline
                _pipeline.Connect(_bgSource.Output, _videoMixer.Inputs[0]);
                _pipeline.Connect(_fileSource1.VideoOutput, _videoMixer.Inputs[1]);
                _pipeline.Connect(_fileSource2.VideoOutput, _videoMixer.Inputs[2]);
                _pipeline.Connect(_videoMixer.Output, _videoRenderer.Input);

                // Start
                await _pipeline.StartAsync();
                _timer.Start();

                LogMessage("Pipeline started.");
            }
            catch (Exception ex)
            {
                LogMessage($"Error: {ex.Message}");
                Debug.WriteLine(ex);
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            await DestroyPipelineAsync();
            lbTimestamp.Content = "00:00:00";
            LogMessage("Pipeline stopped.");
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.PauseAsync();
                    LogMessage("Paused.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void btResume_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_pipeline != null)
                {
                    await _pipeline.ResumeAsync();
                    LogMessage("Resumed.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void btPickBgColor_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.ColorDialog
            {
                Color = System.Drawing.Color.FromArgb(_bgColor.Red, _bgColor.Green, _bgColor.Blue)
            };

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var c = dlg.Color;
                _bgColor = new SKColor(c.R, c.G, c.B);

                rectBgColor.Fill = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromRgb(c.R, c.G, c.B));
                lbBgColor.Content = $"#{c.R:X2}{c.G:X2}{c.B:X2}";

                LogMessage($"Background color set to #{c.R:X2}{c.G:X2}{c.B:X2} (applied on next Play).");
            }
        }

        private void btSelectFile1_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Transparent Video (*.webm;*.mov)|*.webm;*.mov|All files (*.*)|*.*",
                Title = "Select Video File 1 (with alpha)"
            };

            if (dlg.ShowDialog() == true)
            {
                edFile1.Text = dlg.FileName;
            }
        }

        private void btSelectFile2_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "Transparent Video (*.webm;*.mov)|*.webm;*.mov|All files (*.*)|*.*",
                Title = "Select Video File 2 (with alpha)"
            };

            if (dlg.ShowDialog() == true)
            {
                edFile2.Text = dlg.FileName;
            }
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                LogMessage($"ERROR: {e.Message}");
            });
        }

        private void Pipeline_OnStop(object sender, StopEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                _timer?.Stop();
                lbTimestamp.Content = "00:00:00";
            });
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (_pipeline == null)
                    return;

                var position = _pipeline.Position_Get();

                Dispatcher.BeginInvoke(() =>
                {
                    lbTimestamp.Content = position.ToString(@"hh\:mm\:ss");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async Task DestroyPipelineAsync()
        {
            try
            {
                _timer?.Stop();

                if (_pipeline != null)
                {
                    _pipeline.OnError -= Pipeline_OnError;
                    _pipeline.OnStop -= Pipeline_OnStop;
                    await _pipeline.StopAsync();
                    await _pipeline.DisposeAsync();
                    _pipeline = null;
                }

                _bgSource = null;
                _fileSource1 = null;
                _fileSource2 = null;
                _videoMixer = null;
                _videoRenderer = null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                await DestroyPipelineAsync();
                _timer?.Dispose();
                VisioForgeX.DestroySDK();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void LogMessage(string message)
        {
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => LogMessage(message));
                return;
            }

            if (mmLog.Text.Length > 50000)
            {
                var lines = mmLog.Text.Split('\n');
                mmLog.Text = string.Join("\n", lines.Skip(lines.Length / 2));
            }

            mmLog.Text += $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";
            mmLog.ScrollToEnd();
        }
    }
}
