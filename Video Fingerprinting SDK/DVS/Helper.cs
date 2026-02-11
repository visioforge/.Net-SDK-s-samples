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

    public static class Helper
    {
        /// <summary>
        /// Get image for file.
        /// </summary>
        public static BitmapSource GetImageForFile(string filename)
        {
            var bitmap = MediaInfoReaderX.GetFileSnapshotBitmap(filename, TimeSpan.FromMilliseconds(3000));
            if (bitmap == null)
            {
                return CreateBitmapSource(Colors.Black);
            }

            return BitmapConv(bitmap);
        }

        /// <summary>
        /// Deletes the object.
        /// </summary>
        /// <param name="objectPtr">The object pointer.</param>
        /// <returns>True if successful.</returns>
        [Localizable(false), DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject([In] IntPtr objectPtr);

        /// <summary>
        /// Converts WinForms Bitmap to WPF BitmapSource.
        /// </summary>
        /// <param name="bitmap">
        /// Source bitmap. Will be disposed after conversion.
        /// </param>
        /// <returns>
        /// Returns WPF BitmapSource.
        /// </returns>
        private static BitmapSource BitmapConv(System.Drawing.Bitmap bitmap)
        {
            try
            {
                IntPtr bitmapHandle = bitmap.GetHbitmap();
                try
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                        bitmapHandle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    return bitmapSource;
                }
                finally
                {
                    DeleteObject(bitmapHandle);
                }
            }
            finally
            {
                // Dispose the source bitmap to prevent GDI resource leak
                bitmap.Dispose();
            }
        }

        /// <summary>
        /// Create bitmap source.
        /// </summary>
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
