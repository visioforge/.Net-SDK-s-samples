// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service1.cs" company="VisioForge">
//   VisioForge video capture service sample.
// </copyright>
// <summary>
//   Service class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IPCaptureService
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.ServiceProcess;
    using VisioForge.Core.VideoCapture;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;


    /// <summary>
    /// Service class.
    /// </summary>
    public partial class Service1 : ServiceBase
    {
        /// <summary>
        /// Video capture instance.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service1"/> class.
        /// </summary>
        public Service1()
        {
            InitializeComponent();

            VideoCapture1 = new VideoCaptureCore();
        }

        /// <summary>
        /// Inits video capture.
        /// </summary>
        protected void CaptureStart()
        {
            // Uncomment to start debugger
            // System.Diagnostics.Debugger.Launch();            

            // configure cam
            VideoCapture1.Mode = VideoCaptureMode.IPCapture;

            VideoCapture1.Audio_RecordAudio = false;
            VideoCapture1.Audio_PlayAudio = false;

            VideoCapture1.IP_Camera_Source = new IPCameraSourceSettings();
            VideoCapture1.IP_Camera_Source.AudioCapture = false;
            VideoCapture1.IP_Camera_Source.Type = IPSourceEngine.Auto_LAV;
            VideoCapture1.IP_Camera_Source.URL = new Uri("http://212.162.177.75/mjpg/video.mjpg");

            VideoCapture1.Output_Filename = @"c:\vf\service_output.mp4";

            var mp4Output = new MP4Output();
            mp4Output.MP4Mode = MP4Mode.CPU_QSV;
            VideoCapture1.Output_Format = mp4Output;

            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.None;

            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnError += VideoCapture1_OnError;

            VideoCapture1.Start();
        }

        /// <summary>
        /// OnStart service event.
        /// </summary>
        /// <param name="args">
        /// Service args.
        /// </param>
        /// <summary>
        /// On start.
        /// </summary>
        protected override void OnStart(string[] args)
        {
            AddLog("start - 1");

            CaptureStart();

            AddLog("start - 2");
        }

        /// <summary>
        /// Error events processing. All error going to Windows Events. You can write it to logs if you are prefer this way.
        /// </summary>
        /// <param name="sender">
        /// Sender.
        /// </param>
        /// <param name="e">
        /// Event args.
        /// </param>
        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        protected void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            this.AddLog("cam1: " + e.Message);
        }

        /// <summary>
        /// Stop capture for all cams.
        /// </summary>
        public void CaptureStop()
        {
            AddLog("stop - 1");

            VideoCapture1.Stop();

            AddLog("stop - 2");
        }

        /// <summary>
        /// Servie OnStop event.
        /// </summary>
        protected override void OnStop()
        {
            CaptureStop();
        }

        /// <summary>
        /// Adds text to Windows Events.
        /// </summary>
        /// <param name="log">
        /// Event text.
        /// </param>
        /// <summary>
        /// Add log.
        /// </summary>
        public void AddLog(string log)
        {
            try
            {
                if (!EventLog.SourceExists("VisioForgeIPCaptureService"))
                {
                    EventLog.CreateEventSource("VisioForgeIPCaptureService", "VisioForgeIPCaptureService");
                }

                eventLog1.Source = "VisioForgeIPCaptureService";
                eventLog1.WriteEntry(log);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
