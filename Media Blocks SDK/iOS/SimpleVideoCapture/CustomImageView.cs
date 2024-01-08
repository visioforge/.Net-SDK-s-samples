using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleVideoCapture
{
    using CoreGraphics;
    using UIKit;
    using Foundation;

    public class CustomImageView : UIView
    {
        private readonly object _lock = new object();

        private CGImage cgImage;

        public CustomImageView(CGImage image, CGRect frame) : base(frame)
        {
            cgImage = image;
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            CGContext context = UIGraphics.GetCurrentContext();

            // Draw the image
            lock (_lock)
            {
                if (cgImage != null)
                {
                    context.DrawImage(rect, cgImage);
                }
            }
        }

        public void Update(CGImage image)
        {
            lock (_lock)
            {
                cgImage?.Dispose();
                cgImage = null;

                cgImage = image;

                SetNeedsDisplay();
            }
        }

        public static CGImage CreateCGImageFromByteArray(byte[] imageData, int width, int height)
        {
            // Define color space (RGB)
            CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();

            // Create a CGContext
            using var context = new CGBitmapContext(imageData, width, height, 8, 4 * width, colorSpace, CGImageAlphaInfo.PremultipliedLast);

            // Create CGImage from context
            CGImage cgImage = context.ToImage();
            return cgImage;
        }
    }

}
