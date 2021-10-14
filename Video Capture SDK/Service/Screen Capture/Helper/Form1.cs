using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace ScreenCaptureServiceHelper
{
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security.Permissions;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;
    using VisioForge.Types.OutputFormat;
    using VisioForge.Types.Sources;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inits video capture.
        /// </summary>
        protected void CaptureStart()
        {
            // System.Diagnostics.Debugger.Launch();

            // configure cam1
            VideoCapture1.Mode = VFVideoCaptureMode.ScreenCapture;

            VideoCapture1.Screen_Capture_Source = new ScreenCaptureSourceSettings();
            VideoCapture1.Screen_Capture_Source.FullScreen = true;
            VideoCapture1.Screen_Capture_Source.FrameRate = 5;

            VideoCapture1.Output_Filename = "d:\\screen.wmv";

            AddLog("Output file: " + VideoCapture1.Output_Filename);

            var wmvOutput = new VFWMVOutput();
            wmvOutput.Mode = VFWMVMode.InternalProfile;
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
            catch
            {
            }
        }

        private IntPtr HWND_BROADCAST = (IntPtr)0xffff;

        private uint VF_SCS_EXIT_COMMAND;

        private void Form1_Load(object sender, EventArgs e)
        {
            VF_SCS_EXIT_COMMAND = RegisterWindowMessage("VF_SCS_EXIT_COMMAND");

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 0 && args[0] == "-q")
            {
                //System.Diagnostics.Debugger.Launch();
                
                IntPtr result = SendMessage(HWND_BROADCAST, VF_SCS_EXIT_COMMAND, (IntPtr)0, (IntPtr)0);
            }
            else
            {
                //Bitmap bmp = VideoCapture.CaptureScreenToImage();
                //bmp.Save("d:\\mywindow.jpg");

                CaptureStart();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint RegisterWindowMessage(string lpString);

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
