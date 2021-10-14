// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service1.cs" company="VisioForge">
//   VisioForge video capture service sample.
// </copyright>
// <summary>
//   Service class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ScreenCaptureService
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.ServiceProcess;

    using CSCreateProcessAsUserFromService;

    using VisioForge.Controls.UI.WinForms;
    using VisioForge.Types;

    /// <summary>
    /// Service class.
    /// </summary>
    public partial class Service1 : ServiceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Service1"/> class.
        /// </summary>
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();

            // As creating a child process might be a time consuming operation,
            // its better to do that in a separate thread than blocking the main thread.
            System.Threading.Thread ProcessCreationThread = new System.Threading.Thread(MyThreadFuncStart);
            ProcessCreationThread.Start();
        }

        protected override void OnStop()
        {
            //System.Diagnostics.Debugger.Launch();

            System.Threading.Thread ProcessCreationThread = new System.Threading.Thread(MyThreadFuncStop);
            ProcessCreationThread.Start();
        }

        // This thread function would launch a child process 
        // in the interactive session of the logged-on user.
        public static void MyThreadFuncStart()
        {
           // System.Diagnostics.Debugger.Launch();

            CreateProcessAsUserWrapper.LaunchChildProcess(AppDomain.CurrentDomain.BaseDirectory + "ScreenCaptureServiceHelper.exe", string.Empty); //"C:\\Windows\\notepad.exe");
        }

        // This thread function would launch a child process 
        // in the interactive session of the logged-on user.
        public static void MyThreadFuncStop()
        {
            // System.Diagnostics.Debugger.Launch();

            CreateProcessAsUserWrapper.LaunchChildProcess(AppDomain.CurrentDomain.BaseDirectory + "ScreenCaptureServiceHelper.exe", "-q"); //"C:\\Windows\\notepad.exe");
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
    }
}
