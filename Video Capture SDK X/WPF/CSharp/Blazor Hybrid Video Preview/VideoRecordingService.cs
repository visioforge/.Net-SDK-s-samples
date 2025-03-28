using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using VisioForge.Core.VideoCaptureX;
using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using System.Diagnostics;
using System.Net.NetworkInformation;
using SkiaSharp;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;
using VisioForge.Core.Types.X.Output;

namespace Video_Preview_Blazor_Hybrid
{
    public class VideoRecordingService : IDisposable
    {
        private VideoCaptureCoreX _videoCapture;

        private bool _isRecording;
        private bool _isCameraRunning;
        private string _currentVideoPath;
        private CancellationTokenSource _cts;

        public event Action<byte[]> FrameCaptured;
        public event Action<string> RecordingCompleted;

        public VideoRecordingService()
        {
            _cts = new CancellationTokenSource();
        }

        public bool InitializeCamera(int deviceIndex = 0)
        {
            try
            {
                _videoCapture = new VideoCaptureCoreX();

                var videoSources = DeviceEnumerator.Shared.VideoSources().Where(x => x.API == VideoCaptureDeviceAPI.KS).ToArray();
                if (videoSources.Length == 0)
                    return false;

                var videoSource = new VideoCaptureDeviceSourceSettings(videoSources[0]);
                videoSource.Format = videoSources[0].GetHDOrAnyVideoFormatAndFrameRate(out var frameRate).ToFormat();
                videoSource.Format.FrameRate = frameRate;

                _videoCapture.Video_Source = videoSource;

                _isCameraRunning = true;

                //_videoCapture.OnVideoFrameBuffer += (sender, e) =>
                //{
                //    if (e.Frame == null)
                //        return;

                //    if (_isCameraRunning && !_cts.Token.IsCancellationRequested)
                //    {
                //        // Create JPEG from RGBA frame using SkiaSharp
                //        var bytes = ConvertRgbaToJpeg(e.Frame.Data, e.Frame.Width, e.Frame.Height, e.Frame.Stride);

                //        // Notify UI
                //        FrameCaptured?.Invoke(bytes);
                //    }
                //};

                _videoCapture.Outputs_Add(new MP4Output("tempfile.mp4"), autostart: false);

                var jpegOutput = new JPEGCallbackOutput();
                jpegOutput.OnJPEGFrame += (sender, frame) =>
                {
                    if (frame == null)
                        return;

                    if (_isCameraRunning && !_cts.Token.IsCancellationRequested)
                    {
                        // Notify UI
                        FrameCaptured?.Invoke(frame);
                    }
                };

                _videoCapture.Outputs_Add(jpegOutput, autostart: true);

                _videoCapture.Start();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize camera: {ex.Message}");
                return false;
            }
        }

        public string StartRecording(string fileName = null)
        {
            if (!_isCameraRunning || _isRecording)
                return null;

            try
            {
                // Create a directory for videos if it doesn't exist
                var videosFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Videos");
                Directory.CreateDirectory(videosFolder);

                // Generate file name if not provided
                if (string.IsNullOrEmpty(fileName))
                    fileName = $"Recording_{DateTime.Now:yyyyMMdd_HHmmss}.mp4";

                _currentVideoPath = Path.Combine(videosFolder, fileName);

                _videoCapture.StartCapture(0, _currentVideoPath);

                _isRecording = true;
                return _currentVideoPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start recording: {ex.Message}");
                return null;
            }
        }

        public string StopRecording()
        {
            if (!_isRecording)
                return null;

            _isRecording = false;

            _videoCapture.StopCapture(0);

            var videoPath = _currentVideoPath;
            RecordingCompleted?.Invoke(videoPath);

            return videoPath;
        }

        public void StopCamera()
        {
            _isCameraRunning = false;
            _cts.Cancel();

            if (_isRecording)
                StopRecording();

            _videoCapture?.Stop();
            _videoCapture?.Dispose();
            _videoCapture = null;
        }

        public void Dispose()
        {
            StopCamera();
            _cts.Dispose();
        }
    }
}
