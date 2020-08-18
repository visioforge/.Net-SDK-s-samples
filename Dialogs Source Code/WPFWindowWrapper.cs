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
        /// Creates new WPFWindowWrapper.
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

    /// <summary>
    /// Helper to show WinForms dialog in WPF app.
    /// </summary>
    public static class WPFWindowWrapperHelper
    {
        /// <summary>
        /// Show dialog.
        /// </summary>
        /// <param name="form">
        /// WinForms form.
        /// </param>
        /// <param name="parent">
        /// WPF window.
        /// </param>
        /// <returns>
        /// Dialog result.
        /// </returns>
        public static DialogResult ShowDialog(this Form form, System.Windows.Window parent)
        {
            return form.ShowDialog(new WPFWindowWrapper(parent));
        }
    }
}
