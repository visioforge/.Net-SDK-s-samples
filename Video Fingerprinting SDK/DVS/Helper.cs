namespace DVS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using VisioForge.Core.MediaInfoReaderX;
    using VisioForge.Core.VideoFingerPrinting;

    public static class Helper
    {
        public static System.Windows.Forms.IWin32Window GetIWin32Window(this System.Windows.Media.Visual visual)
        {
            var source = System.Windows.PresentationSource.FromVisual(visual) as System.Windows.Interop.HwndSource;
            System.Windows.Forms.IWin32Window win = new OldWindow(source.Handle);
            return win;
        }

        private class OldWindow : System.Windows.Forms.IWin32Window
        {
            private readonly System.IntPtr _handle;
            public OldWindow(System.IntPtr handle)
            {
                this._handle = handle;
            }

            #region IWin32Window Members
            System.IntPtr System.Windows.Forms.IWin32Window.Handle
            {
                get { return this._handle; }
            }
            #endregion
        }

        public static BitmapSource GetImageForFile(string filename)
        {
            var bitmap = MediaInfoReaderX.GetFileSnapshotBitmap(filename, TimeSpan.FromMilliseconds(3000));
            if (bitmap == null)
            {
                return CreateBitmapSource(Colors.Black);
            }

            return BitmapConv(bitmap);
        }

        [Localizable(false), DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject([In] IntPtr objectPtr);

        /// <summary>
        /// Converts WinForms Bitmap to WPF BitmapSource.
        /// </summary>
        /// <param name="bitmap">
        /// Source bitmap.
        /// </param>
        /// <returns>
        /// Returns WPF BitmapSource.
        /// </returns>
        private static BitmapSource BitmapConv(System.Drawing.Bitmap bitmap)
        {
            IntPtr bitmapHandle = bitmap.GetHbitmap();
            BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmapHandle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(bitmapHandle);
            return bitmapSource;
        }

        private static BitmapSource CreateBitmapSource(System.Windows.Media.Color color)
        {
            int width = 80;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];

            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>();
            colors.Add(color);
            BitmapPalette myPalette = new BitmapPalette(colors);

            BitmapSource image = BitmapSource.Create(
                width,
                height,
                96,
                96,
                PixelFormats.Indexed1,
                myPalette,
                pixels,
                stride);

            return image;
        }
    }
}
