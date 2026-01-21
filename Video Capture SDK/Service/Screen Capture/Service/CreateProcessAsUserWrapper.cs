/************************************* Module Header ***********************************\
* Module Name:  CreateProcessAsUserWrapper.cs
* Project:      CSCreateProcessAsUserFromService
* Copyright (c) Microsoft Corporation.
* 
* The sample demonstrates how to create/launch a process interactively in the session of 
* the logged-on user from a service application written in C#.Net.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace CSCreateProcessAsUserFromService
{
    /// <summary>
    /// Wrapper class for CreateProcessAsUser.
    /// </summary>
    class CreateProcessAsUserWrapper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        /// <summary>
        /// Launch child process.
        /// </summary>
        /// <param name="ChildProcName">Child process name.</param>
        /// <param name="args">Arguments.</param>
        public static void LaunchChildProcess(string ChildProcName, string args)
        {
            IntPtr ppSessionInfo = IntPtr.Zero;
            UInt32 SessionCount = 0;

            if (WTSEnumerateSessions(
                (IntPtr)WTS_CURRENT_SERVER_HANDLE,  // Current RD Session Host Server handle would be zero.
                0,                                  // This reserved parameter must be zero.
                1,                                  // The version of the enumeration request must be 1.
                ref ppSessionInfo,                  // This would point to an array of session info.
                ref SessionCount                    // This would indicate the length of the above array.
                ))
            {
                for (int nCount = 0; nCount < SessionCount; nCount++)
                {
                    // Extract each session info and check if it is the 
                    // "Active Session" of the current logged-on user.
                    WTS_SESSION_INFO tSessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure(
                        new IntPtr(ppSessionInfo.ToInt64() + nCount * Marshal.SizeOf(typeof(WTS_SESSION_INFO))),
                        typeof(WTS_SESSION_INFO)
                        );

                    if (WTS_CONNECTSTATE_CLASS.WTSActive == tSessionInfo.State)
                    {
                        if (WTSQueryUserToken(tSessionInfo.SessionID, out IntPtr hToken))
                        {
                            const int STARTF_USESHOWWINDOW = 0x00000001;
                            const short SW_HIDE = 0;

                            // Launch the child process interactively 
                            // with the token of the logged-on user.
                            PROCESS_INFORMATION tProcessInfo;
                            STARTUPINFO tStartUpInfo = new STARTUPINFO();
                            tStartUpInfo.cb = Marshal.SizeOf(typeof(STARTUPINFO));
                            tStartUpInfo.wShowWindow = SW_HIDE;
                            tStartUpInfo.dwFlags = STARTF_USESHOWWINDOW;

                            bool ChildProcStarted = CreateProcessAsUser(
                                hToken,             // Token of the logged-on user.
                                ChildProcName,      // Name of the process to be started.
                                args,               // Any command line arguments to be passed.
                                IntPtr.Zero,        // Default Process' attributes.
                                IntPtr.Zero,        // Default Thread's attributes.
                                false,              // Does NOT inherit parent's handles.
                                0,                  // No any specific creation flag.
                                null,               // Default environment path.
                                null,               // Default current directory.
                                ref tStartUpInfo,   // Process Startup Info. 
                                out tProcessInfo    // Process information to be returned.
                                );

                            if (ChildProcStarted)
                            {
                                // The child process creation is successful!

                                // If the child process is created, it can be controlled via the out 
                                // param "tProcessInfo". For now, as we don't want to do any thing 
                                // with the child process, closing the child process' handles 
                                // to prevent the handle leak.
                                CloseHandle(tProcessInfo.hThread);
                                CloseHandle(tProcessInfo.hProcess);
                            }
                            else
                            {
                                // CreateProcessAsUser failed!
                            }

                            // Whether child process was created or not, close the token handle 
                            // and break the loop as processing for current active user has been done.
                            CloseHandle(hToken);
                            break;
                        }
                        else
                        {
                            // WTSQueryUserToken failed!
                        }
                    }
                    else
                    {
                        // This Session is not active!
                    }
                }

                // Free the memory allocated for the session info array.
                WTSFreeMemory(ppSessionInfo);
            }
            else
            {
                // WTSEnumerateSessions failed!
            }
        }


        #region P/Invoke WTS APIs
        /// <summary>
        /// Struct, Enum and P/Invoke Declarations of WTS APIs.
        /// </summary>
        /// 

        /// <summary>
        /// Current server handle.
        /// </summary>
        private const int WTS_CURRENT_SERVER_HANDLE = 0;
        /// <summary>
        /// WTS connect state class.
        /// </summary>
        private enum WTS_CONNECTSTATE_CLASS
        {
            /// <summary>
            /// Active.
            /// </summary>
            WTSActive,
            /// <summary>
            /// Connected.
            /// </summary>
            WTSConnected,
            /// <summary>
            /// Connect query.
            /// </summary>
            WTSConnectQuery,
            /// <summary>
            /// Shadow.
            /// </summary>
            WTSShadow,
            /// <summary>
            /// Disconnected.
            /// </summary>
            WTSDisconnected,
            /// <summary>
            /// Idle.
            /// </summary>
            WTSIdle,
            /// <summary>
            /// Listen.
            /// </summary>
            WTSListen,
            /// <summary>
            /// Reset.
            /// </summary>
            WTSReset,
            /// <summary>
            /// Down.
            /// </summary>
            WTSDown,
            /// <summary>
            /// Init.
            /// </summary>
            WTSInit
        }

        /// <summary>
        /// WTS session info.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct WTS_SESSION_INFO
        {
            /// <summary>
            /// Session ID.
            /// </summary>
            public UInt32 SessionID;

            /// <summary>
            /// Window station name.
            /// </summary>
            public string pWinStationName;

            /// <summary>
            /// State.
            /// </summary>
            public WTS_CONNECTSTATE_CLASS State;
        }

        /// <summary>
        /// Enumerate sessions.
        /// </summary>
        /// <param name="hServer">Server.</param>
        /// <param name="Reserved">Reserved.</param>
        /// <param name="Version">Version.</param>
        /// <param name="ppSessionInfo">Session info.</param>
        /// <param name="pSessionInfoCount">Session info count.</param>
        /// <returns>True if successful.</returns>
        [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            [MarshalAs(UnmanagedType.U4)] UInt32 Reserved,
            [MarshalAs(UnmanagedType.U4)] UInt32 Version,
            ref IntPtr ppSessionInfo,
            [MarshalAs(UnmanagedType.U4)] ref UInt32 pSessionInfoCount
            );

        /// <summary>
        /// Free memory.
        /// </summary>
        /// <param name="pMemory">Pointer to memory.</param>
        [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern void WTSFreeMemory(IntPtr pMemory);

        /// <summary>
        /// Query user token.
        /// </summary>
        /// <param name="sessionId">Session ID.</param>
        /// <param name="Token">Token.</param>
        /// <returns>True if successful.</returns>
        [DllImport("WTSAPI32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool WTSQueryUserToken(UInt32 sessionId, out IntPtr Token);
        #endregion


        #region P/Invoke CreateProcessAsUser
        /// <summary>
        /// Struct, Enum and P/Invoke Declarations for CreateProcessAsUser.
        /// </summary>
        /// 

        /// <summary>
        /// Startup info.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct STARTUPINFO
        {
            /// <summary>
            /// CB.
            /// </summary>
            public Int32 cb;
            /// <summary>
            /// Reserved.
            /// </summary>
            public string lpReserved;
            /// <summary>
            /// Desktop.
            /// </summary>
            public string lpDesktop;
            /// <summary>
            /// Title.
            /// </summary>
            public string lpTitle;
            /// <summary>
            /// X.
            /// </summary>
            public Int32 dwX;
            /// <summary>
            /// Y.
            /// </summary>
            public Int32 dwY;
            /// <summary>
            /// X Size.
            /// </summary>
            public Int32 dwXSize;
            /// <summary>
            /// Y Size.
            /// </summary>
            public Int32 dwYSize;
            /// <summary>
            /// X Count Chars.
            /// </summary>
            public Int32 dwXCountChars;
            /// <summary>
            /// Y Count Chars.
            /// </summary>
            public Int32 dwYCountChars;
            /// <summary>
            /// Fill Attribute.
            /// </summary>
            public Int32 dwFillAttribute;
            /// <summary>
            /// Flags.
            /// </summary>
            public Int32 dwFlags;
            /// <summary>
            /// Show Window.
            /// </summary>
            public Int16 wShowWindow;
            /// <summary>
            /// Reserved 2.
            /// </summary>
            public Int16 cbReserved2;
            /// <summary>
            /// Reserved 2.
            /// </summary>
            public IntPtr lpReserved2;
            /// <summary>
            /// Std Input.
            /// </summary>
            public IntPtr hStdInput;
            /// <summary>
            /// Std Output.
            /// </summary>
            public IntPtr hStdOutput;
            /// <summary>
            /// Std Error.
            /// </summary>
            public IntPtr hStdError;
        }

        /// <summary>
        /// Process information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct PROCESS_INFORMATION
        {
            /// <summary>
            /// Process handle.
            /// </summary>
            public IntPtr hProcess;
            /// <summary>
            /// Thread handle.
            /// </summary>
            public IntPtr hThread;
            /// <summary>
            /// Process ID.
            /// </summary>
            public int dwProcessId;
            /// <summary>
            /// Thread ID.
            /// </summary>
            public int dwThreadId;
        }

        /// <summary>
        /// Create process as user.
        /// </summary>
        /// <param name="hToken">Token.</param>
        /// <param name="lpApplicationName">Application name.</param>
        /// <param name="lpCommandLine">Command line.</param>
        /// <param name="lpProcessAttributes">Process attributes.</param>
        /// <param name="lpThreadAttributes">Thread attributes.</param>
        /// <param name="bInheritHandles">Inherit handles.</param>
        /// <param name="dwCreationFlags">Creation flags.</param>
        /// <param name="lpEnvironment">Environment.</param>
        /// <param name="lpCurrentDirectory">Current directory.</param>
        /// <param name="lpStartupInfo">Startup info.</param>
        /// <param name="lpProcessInformation">Process information.</param>
        /// <returns>True if successful.</returns>
        [DllImport("ADVAPI32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool CreateProcessAsUser(
            IntPtr hToken,
            string lpApplicationName,
            string lpCommandLine,
            IntPtr lpProcessAttributes,
            IntPtr lpThreadAttributes,
            bool bInheritHandles,
            uint dwCreationFlags,
            string lpEnvironment,
            string lpCurrentDirectory,
            ref STARTUPINFO lpStartupInfo,
            out PROCESS_INFORMATION lpProcessInformation
            );

        /// <summary>
        /// Close handle.
        /// </summary>
        /// <param name="hHandle">Handle.</param>
        /// <returns>True if successful.</returns>
        [DllImport("KERNEL32.DLL", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern bool CloseHandle(IntPtr hHandle);
        #endregion
    }
}
