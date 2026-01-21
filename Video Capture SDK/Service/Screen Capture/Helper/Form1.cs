using System;
using System.Windows.Forms;

namespace ScreenCaptureServiceHelper
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;
    using VisioForge.Core.Types;
    using VisioForge.Core.Types.Events;
    using VisioForge.Core.Types.Output;
    using VisioForge.Core.Types.VideoCapture;
    using VisioForge.Core.VideoCapture;

    /// <summary>
    /// Screen capture service helper main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// RegisterWindowMessage.
        /// </summary>
        /// <param name="lpString">
        /// String.
        /// </param>
        /// <returns>uint.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint RegisterWindowMessage(string lpString);

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="hWnd">The HWND.</param>
        /// <param name="Msg">The MSG.</param>
        /// <param name="wParam">The w parameter.</param>
        /// <param name="lParam">The l parameter.</param>
        /// <returns>IntPtr.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Video capture instance.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            VideoCapture1 = new VideoCaptureCore();
        }

        /// <summary>
        /// Inits video capture.
        /// </summary>
        protected void CaptureStart()
        {
            // System.Diagnostics.Debugger.Launch();

            // configure cam1
            VideoCapture1.Mode = VideoCaptureMode.ScreenCapture;

            VideoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings();
            VideoCapture1.Screen_Capture_Source.FullScreen = true;
            VideoCapture1.Screen_Capture_Source.FrameRate = new VideoFrameRate(5);

            VideoCapture1.Output_Filename = "d:\\screen.wmv";

            AddLog("Output file: " + VideoCapture1.Output_Filename);

            var wmvOutput = new WMVOutput();
            wmvOutput.Mode = WMVMode.InternalProfile;
            wmvOutput.Internal_Profile_Name = VideoCapture1.WMV_Internal_Profiles()[5];
            VideoCapture1.Output_Format = wmvOutput;

            VideoCapture1.OnError -= VideoCapture1_OnError;
            VideoCapture1.OnError += VideoCapture1_OnError;

            VideoCapture1.Start();
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
            this.AddLog("helper: " + e.Message);
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
                if (!EventLog.SourceExists("VisioForgeScreenCaptureService"))
                {
                    EventLog.CreateEventSource("VisioForgeScreenCaptureService", "VisioForgeScreenCaptureService");
                }

                eventLog1.Source = "VisioForgeScreenCaptureService";
                eventLog1.WriteEntry(log);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// HWND broadcast.
        /// </summary>
        private IntPtr HWND_BROADCAST = (IntPtr)0xffff;

        /// <summary>
        /// Exit command message ID.
        /// </summary>
        private uint VF_SCS_EXIT_COMMAND;

        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <summary>
        /// Handles the form 1 load event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            VF_SCS_EXIT_COMMAND = RegisterWindowMessage("VF_SCS_EXIT_COMMAND");

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 0 && args[0] == "-q")
            {
                //System.Diagnostics.Debugger.Launch();

                SendMessage(HWND_BROADCAST, VF_SCS_EXIT_COMMAND, (IntPtr)0, (IntPtr)0);
            }
            else
            {
                //Bitmap bmp = VideoCapture.CaptureScreenToImage();
                //bmp.Save("d:\\mywindow.jpg");

                CaptureStart();
            }
        }

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows Message to process.</param>
        [EnvironmentPermission(SecurityAction.LinkDemand, Unrestricted = true)]

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == VF_SCS_EXIT_COMMAND)
            {
                CaptureStop();
                Close();
            }

            base.WndProc(ref m);
        }
    }
}
