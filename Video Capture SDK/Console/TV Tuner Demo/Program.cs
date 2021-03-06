﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="VisioForge">
//   Video Capture TV Tuner Demo.
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TV_Tuner_Demo
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using VisioForge.Controls.VideoCapture;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;

    class Program
    {
        static void Main(string[] args)
        {
            var videoCapture = new VideoCaptureCore();
            videoCapture.OnTVTunerTuneChannels += videoCapture_OnTVTunerTuneChannels;
            videoCapture.OnError += VideoCapture_OnError;
            videoCapture.OnVideoFrameBuffer += VideoCapture_OnVideoFrameBuffer;

            videoCapture.Video_Renderer.VideoRendererInternal = VFVideoRendererInternal.None;

            // get video capture devices
            var videoCaptureDevices = videoCapture.Video_CaptureDevices();

            Console.WriteLine(@"Video capture devices: ");
            for (int i = 0; i < videoCaptureDevices.Count; i++)
            {
                Console.WriteLine(i + @": " + videoCaptureDevices[i].Name);
            }

            Console.Write(@"Select video capture device index: ");
            int videoCaptureDeviceIndex = Convert.ToInt32(Console.ReadLine());

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

            // get tv tuner info
            videoCapture.TVTuner_Read();

            var tuners = new List<string>();
            var tunerFormats = new List<string>();
            var tunerCountries = new List<string>();

            foreach (string tunerDevice in videoCapture.TVTuner_Devices())
            {
                tuners.Add(tunerDevice);
            }

            foreach (string tunerTVFormat in videoCapture.TVTuner_TVFormats())
            {
                tunerFormats.Add(tunerTVFormat);
            }

            foreach (string tunerCountry in videoCapture.TVTuner_Countries())
            {
                tunerCountries.Add(tunerCountry);
            }

            Console.WriteLine(@"TV tuners: ");
            for (int i = 0; i < tuners.Count; i++)
            {
                Console.WriteLine(i + @": " + tuners[i]);
            }

            Console.Write(@"Select TV tuner index: ");
            int tunerIndex = Convert.ToInt32(Console.ReadLine());

            Console.Write(@"Select country (empty to use default): ");
            string country = Console.ReadLine();

            // mode
            Console.Write(@"Select mode. 0 - Enumerate channels, 1 - Capture to AVI, 2 - Capture to MP4: ");
            int mode = Convert.ToInt32(Console.ReadLine());

            switch (mode)
            {
                case 0:
                    {
                        videoCapture.Mode = VFVideoCaptureMode.VideoPreview;
                    }
                    break;
                case 1:
                    {
                        videoCapture.Mode = VFVideoCaptureMode.VideoCapture;

                        string outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                            + "\\VisioForge\\" + "output.avi";
                        videoCapture.Output_Filename = outputFile;
                        Console.WriteLine(@"Output file: " + outputFile);

                        videoCapture.Output_Format = new VFAVIOutput();
                    }

                    break;
                case 2:
                    {
                        videoCapture.Mode = VFVideoCaptureMode.VideoCapture;

                        string outputFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                                            + "\\VisioForge\\" + "output.mp4";
                        videoCapture.Output_Filename = outputFile;
                        Console.WriteLine(@"Output file: " + outputFile);

                        videoCapture.Output_Format = new VFMP4v11Output();
                    }

                    break;
                default:
                    Console.WriteLine(@"Wrong mode. Press ESC to exit.");
                    Console.ReadKey();
                    return;
            }

            // set properties
            videoCapture.Video_CaptureDevice = videoCaptureDevices[videoCaptureDeviceIndex].Name;
            videoCapture.Video_CaptureDevice_Format_UseBest = true;
            videoCapture.Video_CaptureDevice_FrameRate = 0; // auto

            if (audioCaptureDeviceIndex == 0)
            {
                videoCapture.Video_CaptureDevice_IsAudioSource = true;
            }
            else
            {
                videoCapture.Video_CaptureDevice_IsAudioSource = false;
                videoCapture.Audio_CaptureDevice = audioCaptureDevices[audioCaptureDeviceIndex - 1].Name;
            }
            
            videoCapture.Audio_CaptureDevice_Format_UseBest = true;

            videoCapture.TVTuner_Country = country;
            videoCapture.TVTuner_Name = tuners[tunerIndex];
            videoCapture.TVTuner_Mode = VFTVTunerMode.FMRadio;

            // videoCapture.TVTuner_Apply();

            videoCapture.TVTuner_Read();

            const int KHz = 1000;
            const int MHz = 1000000;

            videoCapture.TVTuner_Read();

            videoCapture.TVTuner_FM_Tuning_StartFrequency = 100 * MHz;
            videoCapture.TVTuner_FM_Tuning_StopFrequency = 110 * MHz;
            videoCapture.TVTuner_FM_Tuning_Step = 100 * KHz;

            videoCapture.Start();

            if (mode == 0)
            {
                videoCapture.TVTuner_TuneChannels_Start();
            }

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
        }

        private static void VideoCapture_OnVideoFrameBuffer(object sender, VideoFrameBufferEventArgs e)
        {
            
        }

        private static void VideoCapture_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine(@"Error: " + e.Message);
        }

        private static void videoCapture_OnTVTunerTuneChannels(object sender, TVTunerTuneChannelsEventArgs e)
        {
            if (e.SignalPresent)
            {
                Console.WriteLine(e.Channel.ToString());
            }

            if (e.Channel == -1)
            {
                Console.WriteLine("AutoTune complete");
            }
        }
    }
} 
    

