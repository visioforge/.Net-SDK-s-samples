using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

using VisioForge.Core;
using VisioForge.Core.Types.X.AudioRenderers;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.VideoProcessing;
using VisioForge.Core.Types.X._Windows.VideoEffects;
using VisioForge.Core.Types.X;
using System.Diagnostics;

namespace vr360_media_player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaBlocksPipeline _pipeline;
        private VR360ProcessorBlock _processor;
        private DispatcherTimer _timer;
        private Point _lastMousePosition;
        private bool _isMouseDragging;
        private VideoFrameX _pausedFrame;
        private volatile bool _pauseDrawing = false;

        public MainWindow()
        {
            InitializeComponent();
            
            // Initialize timer
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            _timer.Tick += Timer_Tick;
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(edFilename.Text))
            {
                MessageBox.Show("Please select a file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Create MediaBlocks pipeline
                _pipeline = new MediaBlocksPipeline();

                // Add file source
                var fileSourceSettings = await UniversalSourceSettings.CreateAsync(edFilename.Text);
                var info = fileSourceSettings.GetInfo();
                var videoStreamAvailable = info.VideoStreams.Count > 0;
                var audioStreamAvailable = info.AudioStreams.Count > 0;

                var fileSource = new UniversalSourceBlock(fileSourceSettings);

                // Add video renderer
                if (videoStreamAvailable)
                {
                    _processor = new VR360ProcessorBlock(new D3D11VR360RendererSettings());

                    var videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
                    VideoView1.SetNativeRendering(false);

                    _pipeline.Connect(fileSource.VideoOutput, _processor.Input);
                    _pipeline.Connect(_processor.Output, videoRenderer.Input);
                }

                // Add audio output
                if (audioStreamAvailable)
                {
                    var audioOutputDevice = (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound))[0];
                    var audioOutput = new AudioRendererBlock(new AudioRendererSettings(audioOutputDevice));
                    _pipeline.Connect(fileSource, audioOutput);
                }

                // Start playback
                await _pipeline.StartAsync();

                _timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting playback: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void btPause_Click(object sender, RoutedEventArgs e)
        {
            if (_pipeline == null) return;

            if (btPause.Content.ToString() == "Resume")
            {
                btPause.Content = "Pause";
                await _pipeline.ResumeAsync();

                _pausedFrame?.Free();
                _pausedFrame = null;
                
                imgPauseView.Visibility = Visibility.Collapsed;
                VideoView1.Visibility = Visibility.Visible;
            }
            else
            {
                btPause.Content = "Resume";
                await _pipeline.PauseAsync();

                // Set frame to imgPauseView
                UpdatePausedFrame();
            }
        }

        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync(force: true);
                await _pipeline.DisposeAsync();
                _pipeline = null;
            }

            _pausedFrame?.Free();
            _pausedFrame = null;
            imgPauseView.Visibility = Visibility.Collapsed;
            VideoView1.Visibility = Visibility.Visible;
            btPause.Content = "Pause";
        }

        private void btOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv;*.wmv;*.flv|All Files|*.*",
                Title = "Select Video File"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                edFilename.Text = openFileDialog.FileName;
            }
        }

        private void bt360Left_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.Yaw -= 5.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void bt360Right_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.Yaw += 5.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void bt360Up_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.Pitch -= 2.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void bt360Down_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.Pitch += 2.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void btZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.FOV -= 5.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void btZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (_processor != null)
            {
                _processor.Settings.FOV += 5.0f;
                _processor.Update();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            if (_pipeline == null) return;

            try
            {
                var duration = await _pipeline.DurationAsync();
                var position = await _pipeline.Position_GetAsync();

                tbTimeline.Maximum = duration.TotalSeconds;

                if (position.TotalSeconds > 0 && position.TotalSeconds < tbTimeline.Maximum)
                {
                    // Temporarily remove event handler to avoid recursion
                    tbTimeline.ValueChanged -= tbTimeline_ValueChanged;
                    tbTimeline.Value = position.TotalSeconds;
                    tbTimeline.ValueChanged += tbTimeline_ValueChanged;
                }

                lbTime.Content = $"{position:hh\\:mm\\:ss}/{duration:hh\\:mm\\:ss}";
            }
            catch (Exception ex)
            {
                // Handle any timing-related exceptions silently
                System.Diagnostics.Debug.WriteLine($"Timer error: {ex.Message}");
            }
        }

        private async void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_pipeline != null && !_timer.IsEnabled)
            {
                try
                {
                    await _pipeline.Position_SetAsync(TimeSpan.FromSeconds(tbTimeline.Value));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Seek error: {ex.Message}");
                }
            }
        }

        private void VideoView1_MouseDown(object sender, MouseButtonEventArgs e)
        {           
            if (e.LeftButton == MouseButtonState.Pressed && _processor != null)
            {
                _lastMousePosition = e.GetPosition(pnVideoView);
                _isMouseDragging = true;
                VideoView1.CaptureMouse();
            }
        }

        private void VideoView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_processor == null || !_isMouseDragging) return;

            var currentPosition = e.GetPosition(pnVideoView);
            var deltaX = currentPosition.X - _lastMousePosition.X;
            var deltaY = currentPosition.Y - _lastMousePosition.Y;

            _processor.Settings.Yaw += (float)(deltaX * 0.5);
            _processor.Settings.Pitch += (float)(deltaY * 0.5);

            _lastMousePosition = currentPosition;
            _processor.Update();

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }
        }

        private void VideoView1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released && _isMouseDragging)
            {
                _isMouseDragging = false;
                if (VideoView1.IsMouseCaptured)
                {
                    VideoView1.ReleaseMouseCapture();
                }
            }
        }

        private void VideoView1_MouseLeave(object sender, MouseEventArgs e)
        {
            // Release capture if mouse leaves the control while dragging
            if (_isMouseDragging && VideoView1.IsMouseCaptured)
            {
                _isMouseDragging = false;
                VideoView1.ReleaseMouseCapture();
            }
        }

        protected override async void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _timer.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync(force: true);
                await _pipeline.DisposeAsync();
            }

            if (_pipeline.State == VisioForge.Core.Types.PlaybackState.Pause)
            {
                UpdatePausedFrame();
            }

            base.OnClosing(e);
        }

        private void UpdatePausedFrame()
        {
            if (_pauseDrawing)
            {
                return; // Avoid re-entrancy
            }

            _pauseDrawing = true;

            try
            {
                if (_pipeline?.State == VisioForge.Core.Types.PlaybackState.Pause)
                {
                    _pausedFrame?.Free();
                    _pausedFrame = _processor?.GetPausedFrame();
                }

                if (_pausedFrame != null)
                {
                    var writeableBitmap = VideoFrameToWriteableBitmap(_pausedFrame);
                    if (writeableBitmap != null)
                    {
                        imgPauseView.Source = writeableBitmap;
                        imgPauseView.Visibility = Visibility.Visible;
                        VideoView1.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    imgPauseView.Source = null;
                    imgPauseView.Visibility = Visibility.Collapsed;
                    VideoView1.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdatePausedFrame error: {ex.Message}");
            }
            finally
            {
                _pauseDrawing = false;
            }
        }

        private WriteableBitmap VideoFrameToWriteableBitmap(VideoFrameX frame)
        {
            if (frame == null || frame.Width <= 0 || frame.Height <= 0 || frame.Data == IntPtr.Zero)
                return null;

            try
            {
                // Create WriteableBitmap
                var writeableBitmap = new WriteableBitmap(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr24, null);
                
                // Get frame data as byte array
                var frameData = frame.ToArray();
                
                // Convert RGB to BGR if needed (VideoFrameX is typically RGB, WriteableBitmap expects BGR)
                var bgrData = new byte[frameData.Length];
                for (int i = 0; i < frameData.Length; i += 3)
                {
                    if (i + 2 < frameData.Length)
                    {
                        bgrData[i] = frameData[i + 2];     // B
                        bgrData[i + 1] = frameData[i + 1]; // G
                        bgrData[i + 2] = frameData[i];     // R
                    }
                }

                // Calculate stride
                int stride = (frame.Width * writeableBitmap.Format.BitsPerPixel + 7) / 8;
                
                // Write pixels to WriteableBitmap
                writeableBitmap.WritePixels(
                    new Int32Rect(0, 0, frame.Width, frame.Height),
                    bgrData,
                    stride,
                    0);

                return writeableBitmap;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"VideoFrameToWriteableBitmap error: {ex.Message}");
                return null;
            }
        }
    }
} 
 