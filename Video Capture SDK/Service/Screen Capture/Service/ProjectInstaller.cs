using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

using System.ServiceProcess;
namespace SimpleService
{
    using Microsoft.Win32;

    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectInstaller"/> class.
        /// </summary>
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Service installer 1 committed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Event args.</param>
        private void serviceInstaller1_Committed(object sender, InstallEventArgs e)
        {
            // System.Diagnostics.Debugger.Launch();

            RegistryKey ServiceKeys = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                string.Format(@"System\CurrentControlSet\Services\{0}", serviceInstaller1.ServiceName),
                true);

            try
            {
                var ServiceType = (ServiceType)(int)(ServiceKeys.GetValue("type"));

                //Service must be of type Own Process or Share Process
                if (((ServiceType & ServiceType.Win32OwnProcess) != ServiceType.Win32OwnProcess)
                     && ((ServiceType & ServiceType.Win32ShareProcess) != ServiceType.Win32ShareProcess))
                {
                    throw new Exception("ServiceType must be either Own Process or Shared   Process to enable interact with desktop");
                }

                var AccountType = ServiceKeys.GetValue("ObjectName");

                // Account Type must be Local System
                if (!string.Equals(AccountType, "LocalSystem"))
                    throw new Exception("Service account must be local system to enable interact with desktop");

                // ORing the InteractiveProcess with the existing service type
                System.ServiceProcess.ServiceType newType = ServiceType | ServiceType.InteractiveProcess;
                ServiceKeys.SetValue("type", (int)newType);
            }
            finally
            {
                ServiceKeys.Close();
            }
        }
    }
}
