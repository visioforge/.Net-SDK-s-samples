using Microsoft.Extensions.Logging;
using MMT_MAUI.Services;

namespace MMT_MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register platform-specific services
#if WINDOWS
            builder.Services.AddSingleton<IFileSaver, Platforms.Windows.FileSaverImplementation>();
#elif MACCATALYST
            builder.Services.AddSingleton<IFileSaver, Platforms.MacCatalyst.FileSaverImplementation>();
#endif

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
