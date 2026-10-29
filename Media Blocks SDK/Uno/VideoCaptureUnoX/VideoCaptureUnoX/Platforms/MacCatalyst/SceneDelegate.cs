using Foundation;
using Uno.UI.Xaml;
using UIKit;

namespace VideoCaptureUnoX.MacCatalyst;

// iOS 27 SDK apps must adopt the UIScene lifecycle. Uno 6 creates its window at launch, so hand that window to the scene.
[Register("SceneDelegate")]
public class SceneDelegate : UIWindowSceneDelegate
{
    public override UIWindow? Window { get; set; }

    public override void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
    {
        if (scene is UIWindowScene windowScene && App.MainWindow is { } window && WindowHelper.GetNativeWindow(window) is UIWindow nativeWindow)
        {
            Window = nativeWindow;
            nativeWindow.WindowScene = windowScene;
            nativeWindow.MakeKeyAndVisible();
        }
    }
}
