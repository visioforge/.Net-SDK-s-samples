using Avalonia;
using Avalonia.iOS;
using Avalonia.ReactiveUI;
using Foundation;

namespace VideoMixerMVVM.iOS
{
    [Register("AppDelegate")]
#pragma warning disable CA1711
    public partial class AppDelegate : AvaloniaAppDelegate<App>
#pragma warning restore CA1711
    {
        protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
        {
            return base.CustomizeAppBuilder(builder)
                .WithInterFont()
                .UseReactiveUI();
        }
    }
}
