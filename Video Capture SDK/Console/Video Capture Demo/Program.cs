// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="VisioForge">
//   Video Capture Console Demo.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Video_Capture_Demo
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    using VisioForge.Core.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.Events;
    using VisioForge.Types.Output;
    using VisioForge.Types.VideoCapture;

    class Program
    {
        static void Main(string[] args)
        {
            var videoCapture = new VideoCaptureCore();
            videoCapture.OnError += VideoCapture_OnError;

            videoCapture.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            // get video capture devices
            var videoCaptureDevices = videoCapture.Video_CaptureDevices();

            Console.WriteLine(@"Video capture devices: ");
            for (int i = 0; i < videoCaptureDevices.Count; i++)
            {
                Console.WriteLine(i + @": " + videoCaptureDevices[i].Name);
            }

            Console.Write(@"Select video capture device index: ");
            int videoCaptureDeviceIndex = Convert.ToInt32(Console.ReadLine());

            // video formats
            VideoCaptureDeviceFormat videoFormat = new VideoCaptureDeviceFormat(string.Empty);
            if (videoCaptureDevices[videoCaptureDeviceIndex].VideoFormats.Count > 0)
            {
                Console.WriteLine(@"Video capture device formats: ");
                for (int i = 0; i < videoCaptureDevices[videoCaptureDeviceIndex].VideoFormats.Count; i++)
                {
                    Console.WriteLine(i + @": " + videoCaptureDevices[videoCaptureDeviceIndex].VideoFormats[i]);
                }

                Console.Write(@"Select video format index: ");
                int videoFormatIndex = Convert.ToInt32(Console.ReadLine());
                videoFormat = videoCaptureDevices[videoCaptureDeviceIndex].VideoFormats[videoFormatIndex];
            }

            // video frame rates
            double videoFrameRate = 0;
            if (videoFormat.FrameRates.Count > 0)
            {
                Console.WriteLine(@"Video capture device frame rates: ");
                for (int i = 0; i < videoFormat.FrameRates.Count; i++)
                {
                    Console.WriteLine(i + @": " + videoFormat.FrameRates[i]);
                }

                Console.Write(@"Select video frame rate index: ");
                int videoFrameRateIndex = Convert.ToInt32(Console.ReadLine());
                videoFrameRate = videoFormat.FrameRates[videoFrameRateIndex];
            }

            // get audio capture devices
            var audioCaptureDevices = videoCapture.Audio_CaptureDevices();

            Console.WriteLine(@"Audio capture devices: ");
            Console.WriteLine(@"0: Use video capture device if possible.");
            for (int i = 0; i < audioCaptureDevices.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + @": " + audioCaptureDevices[i].Name);
            }

            Console.Write(@"Select audio capture device index: ");
            int audioCaptureDeviceIndex = Convert.ToInt32(Console.ReadLine());

            // audio formats
            string audioFormat = string.Empty;

            if (audioCaptureDeviceIndex == 0)
            {
                if (videoCaptureDevices[videoCaptureDeviceIndex].AudioFormats.Count > 0)
                {
                    Console.WriteLine(@"Audio capture device formats: ");
                    for (int i = 0; i < videoCaptureDevices[videoCaptureDeviceIndex].AudioFormats.Count; i++)
                    {
                        Console.WriteLine(i + @": " + videoCaptureDevices[videoCaptureDeviceIndex].AudioFormats[i]);
                    }

                    Console.Write(@"Select audio format index: ");
                    int audioFormatIndex = Convert.ToInt32(Console.ReadLine());
                    audioFormat = videoCaptureDevices[videoCaptureDeviceIndex].AudioFormats[audioFormatIndex];
                }
            }
            else
            {
                if (audioCaptureDevices[audioCaptureDeviceIndex - 1].Formats.Count > 0)
                {
                    Console.WriteLine(@"Audio capture device formats: ");
                    for (int i = 0; i < audioCaptureDevices[audioCaptureDeviceIndex - 1].Formats.Count; i++)
                    {
                        Console.WriteLine(i + @": " + audioCaptureDevices[audioCaptureDeviceIndex - 1].Formats[i]);
                    }

                    Console.Write(@"Select audio format index: ");
                    int audioFormatIndex = Convert.ToInt32(Console.ReadLine());
                    audioFormat = audioCaptureDevices[audioCaptureDeviceIndex - 1].Formats[audioFormatIndex];
                }
            }

            // mode
            Console.Write(@"Select mode. 0 - Capture to AVI, 1 - Capture to MP4: ");
            int mode = Convert.ToInt32(Console.ReadLine());

            // set properties
            videoCapture.Video_CaptureDevice = new VideoCaptureSource(videoCaptureDevices[videoCaptureDeviceIndex].Name);

            if (string.IsNullOrEmpty(videoFormat.Name))
            {
                videoCapture.Video_CaptureDevice.Format_UseBest = true;
            }
            else
            {
                videoCapture.Video_CaptureDevice.Format_UseBest = false;
                videoCapture.Video_CaptureDevice.Format = videoFormat.Name;
            }

            videoCapture.Video_CaptureDevice.FrameRate = Convert.ToDouble(videoFrameRate, CultureInfo.InvariantCulture);

            if (audioCaptureDeviceIndex == 0)
            {
                videoCapture.Video_CaptureDevice.IsAudioSource = true;
            }
            else
            {
                videoCapture.Video_CaptureDevice.IsAudioSource = false;
                videoCapture.Audio_CaptureDevice = new AudioCaptureSource(audioCaptureDevices[audioCaptureDeviceIndex - 1].Name);
                videoCapture.Audio_CaptureDevice.Format_UseBest = false;
                videoCapture.Audio_CaptureDevice.Format = audioFormat;
            }



            switch (mode)
            {
                case 0:
                    {
                        string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.avi");
                        videoCapture.Output_Filename = outputFile;
                        Console.WriteLine(@"Output file: " + outputFile);

                        videoCapture.Output_Format = new AVIOutput();
                    }

                    break;
                case 1:
                    {
                        string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
                        videoCapture.Output_Filename = outputFile;
                        Console.WriteLine(@"Output file: " + outputFile);

                        videoCapture.Output_Format = new MP4HWOutput();
                    }

                    break;
                default:
                    Console.WriteLine(@"Wrong mode. Press ESC to exit.");
                    Console.ReadKey();
                    return;
            }

            videoCapture.Mode = VideoCaptureMode.VideoCapture;
            videoCapture.Start();

            Console.WriteLine(@"Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(100);
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            videoCapture.Stop();

            videoCapture.Dispose();
        }

        private static void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            if (e.Message.Contains("FULL SDK"))
            {
                return;
            }

            Console.WriteLine(@"Error: " + e.Message);
        }
    }
}
