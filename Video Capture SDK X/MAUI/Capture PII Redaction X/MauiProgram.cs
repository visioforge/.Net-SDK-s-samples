using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using VisioForge.Core.UI.MAUI;

namespace Capture_PII_Redaction_X
{
    public static class MauiProgram
    {
        /// <summary>
        /// Create maui app.
        /// </summary>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureMauiHandlers(handlers => handlers.AddVisioForgeHandlers())
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if WINDOWS
            // WinUI ToggleSwitch reserves a wide On/Off content column (MinWidth ~154),
            // which pushes each paired label far to the right. Collapse it so the
            // switch and its label sit next to each other, as on mobile.
            Microsoft.Maui.Handlers.SwitchHandler.Mapper.AppendToMapping("CompactSwitch", (handler, view) =>
            {
                handler.PlatformView.MinWidth = 0;
                handler.PlatformView.OnContent = null;
                handler.PlatformView.OffContent = null;
            });
#endif

            return builder.Build();
        }
    }
}