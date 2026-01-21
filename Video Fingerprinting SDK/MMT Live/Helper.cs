using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisioForge_MMT_Live
{
    public static class Helper
    {
        /// <summary>
        /// Gets the IWin32Window from a WPF visual.
        /// </summary>
        /// <param name="visual">The WPF visual.</param>
        /// <returns>The IWin32Window.</returns>
        public static System.Windows.Forms.IWin32Window GetIWin32Window(this System.Windows.Media.Visual visual)
        {
            var source = System.Windows.PresentationSource.FromVisual(visual) as System.Windows.Interop.HwndSource;
            System.Windows.Forms.IWin32Window win = new OldWindow(source.Handle);
            return win;
        }

        /// <summary>
        /// Represents an old window for IWin32Window implementation.
        /// </summary>
        private class OldWindow : System.Windows.Forms.IWin32Window
        {
            /// <summary>
            /// The handle.
            /// </summary>
            private readonly System.IntPtr _handle;

            /// <summary>
            /// Initializes a new instance of the <see cref="OldWindow"/> class.
            /// </summary>
            /// <param name="handle">The window handle.</param>
            public OldWindow(System.IntPtr handle)
            {
                _handle = handle;
            }

            #region IWin32Window Members

            /// <summary>
            /// Gets the handle.
            /// </summary>
            System.IntPtr System.Windows.Forms.IWin32Window.Handle
            {
                get { return _handle; }
            }

            #endregion
        }
    }
}
