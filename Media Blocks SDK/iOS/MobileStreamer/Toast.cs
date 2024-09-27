namespace MobileStreamer;

using System;
using UIKit;
using CoreGraphics;

public class Toast
{
    public static void Show(string message, UIViewController controller, double seconds = 2.0)
    {
        var toastLabel = new UILabel(new CGRect(10, controller.View.Frame.Size.Height - 100, controller.View.Frame.Size.Width - 20, 35))
        {
            BackgroundColor = UIColor.Black.ColorWithAlpha(0.6f),
            TextColor = UIColor.White,
            TextAlignment = UITextAlignment.Center,
            Text = message,
            Alpha = 0.0f,
            ClipsToBounds = true,
            Layer = { CornerRadius = 10 }
        };

        controller.View.AddSubview(toastLabel);

        UIView.Animate(0.5, 0, UIViewAnimationOptions.CurveEaseIn, () =>
        {
            toastLabel.Alpha = 1.0f;
        }, () =>
        {
            UIView.Animate(seconds, 0, UIViewAnimationOptions.CurveEaseOut, () =>
            {
                toastLabel.Alpha = 0.0f;
            }, () =>
            {
                toastLabel.RemoveFromSuperview();
            });
        });
    }
}
