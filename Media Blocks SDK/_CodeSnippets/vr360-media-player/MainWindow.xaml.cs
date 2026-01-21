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
using VisioForge.Core.Types.X.VideoEffects;
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

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt pause click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
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
            
            // Clean up processor
            _processor?.Dispose();
            _processor = null;
            
            imgPauseView.Source = null;
            imgPauseView.Visibility = Visibility.Collapsed;
            VideoView1.Visibility = Visibility.Visible;
            btPause.Content = "Pause";
        }

        /// <summary>
        /// Handles the bt open file click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt 360 left click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt 360 right click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt 360 up click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt 360 down click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt zoom in click event.
        /// </summary>
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

        /// <summary>
        /// Handles the bt zoom out click event.
        /// </summary>
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

        /// <summary>
        /// Handles the timer tick event.
        /// </summary>
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

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
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

        /// <summary>
        /// Video view 1 mouse down.
        /// </summary>
        private void VideoView1_MouseDown(object sender, MouseButtonEventArgs e)
        {           
            if (e.LeftButton == MouseButtonState.Pressed && _processor != null)
            {
                _lastMousePosition = e.GetPosition(pnVideoView);
                _isMouseDragging = true;
                VideoView1.CaptureMouse();
            }
        }

        /// <summary>
        /// Video view 1 mouse move.
        /// </summary>
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

        /// <summary>
        /// Video view 1 mouse up.
        /// </summary>
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

        /// <summary>
        /// Video view 1 mouse leave.
        /// </summary>
        private void VideoView1_MouseLeave(object sender, MouseEventArgs e)
        {
            // Release capture if mouse leaves the control while dragging
            if (_isMouseDragging && VideoView1.IsMouseCaptured)
            {
                _isMouseDragging = false;
                VideoView1.ReleaseMouseCapture();
            }
        }

        /// <summary>
        /// On closing.
        /// </summary>
        protected override async void OnClosing(System.ComponentModel.CancelEventArgs e)
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
            
            // Clean up processor
            _processor?.Dispose();
            _processor = null;
            
            imgPauseView.Source = null;

            base.OnClosing(e);
        }

        /// <summary>
        /// Update paused frame.
        /// </summary>
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
                    // Dispose previous bitmap to prevent memory leak
                    var previousBitmap = imgPauseView.Source as WriteableBitmap;
                    
                    var writeableBitmap = VideoFrameToWriteableBitmap(_pausedFrame);
                    if (writeableBitmap != null)
                    {
                        imgPauseView.Source = writeableBitmap;
                        imgPauseView.Visibility = Visibility.Visible;
                        VideoView1.Visibility = Visibility.Collapsed;
                    }
                    
                    // Force garbage collection of previous bitmap
                    previousBitmap = null;
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

        /// <summary>
        /// Video frame to writeable bitmap.
        /// </summary>
        private WriteableBitmap VideoFrameToWriteableBitmap(VideoFrameX frame)
        {
            if (frame == null || frame.Width <= 0 || frame.Height <= 0 || frame.Data == IntPtr.Zero)
                return null;

            try
            {
                // Create WriteableBitmap
                var writeableBitmap = new WriteableBitmap(frame.Width, frame.Height, 96, 96, PixelFormats.Bgr24, null);
                
                // Calculate stride
                int stride = (frame.Width * writeableBitmap.Format.BitsPerPixel + 7) / 8;
                
                // Lock the bitmap for direct pixel access
                writeableBitmap.Lock();
                
                try
                {
                    unsafe
                    {
                        byte* src = (byte*)frame.Data.ToPointer();
                        byte* dst = (byte*)writeableBitmap.BackBuffer.ToPointer();
                        int pixelCount = frame.Width * frame.Height;
                        
                        // Convert RGB to BGR directly in the bitmap buffer
                        for (int i = 0; i < pixelCount; i++)
                        {
                            int srcIndex = i * 3;
                            int dstIndex = i * 3;
                            
                            dst[dstIndex] = src[srcIndex + 2];     // B
                            dst[dstIndex + 1] = src[srcIndex + 1]; // G
                            dst[dstIndex + 2] = src[srcIndex];     // R
                        }
                    }
                    
                    writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, frame.Width, frame.Height));
                }
                finally
                {
                    writeableBitmap.Unlock();
                }

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
 