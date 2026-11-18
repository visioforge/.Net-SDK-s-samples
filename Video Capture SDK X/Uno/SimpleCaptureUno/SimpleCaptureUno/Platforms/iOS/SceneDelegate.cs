using Foundation;
using Uno.UI.Runtime.AppleUIKit;

namespace SimpleCaptureUno.iOS;

// iOS 27 SDK apps must adopt the UIScene lifecycle; Uno's scene delegate hosts the app window.
[Register("SceneDelegate")]
public class SceneDelegate : UnoUISceneDelegate
{
}
