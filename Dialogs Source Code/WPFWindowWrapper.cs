// <copyright file="WPFWindowWrapper.cs" company="VisioForge">
// Copyright (c) VisioForge. All rights reserved.
// </copyright>

using System;
using System.Windows.Forms;

namespace VisioForge.Controls.UI.Dialogs
{
    /// <summary>
    /// Handle wrapper to show WinForms dialog in WPF app.
    /// </summary>
    public class WPFWindowWrapper : IWin32Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WPFWindowWrapper"/> class.
        /// </summary>
        /// <param name="wpfWindow">
        /// WPF window.
        /// </param>
        public WPFWindowWrapper(System.Windows.Window wpfWindow)
        {
            Handle = new System.Windows.Interop.WindowInteropHelper(wpfWindow).Handle;
        }

        /// <summary>
        /// Gets handle.
        /// </summary>
        public IntPtr Handle { get; private set; }
    }
}