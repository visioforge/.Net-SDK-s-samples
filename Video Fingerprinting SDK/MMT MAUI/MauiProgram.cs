using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;
using VisioForge.Core.UI.MAUI;
using MMT_MAUI.Services;

namespace MMT_MAUI;

public static class MauiProgram
{
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

		// Register platform-specific services
#if WINDOWS
		builder.Services.AddSingleton<IFolderPicker, Platforms.Windows.FolderPickerImplementation>();
		builder.Services.AddSingleton<IFileSaver, Platforms.Windows.FileSaverImplementation>();
#elif MACCATALYST
		builder.Services.AddSingleton<IFolderPicker, Platforms.MacCatalyst.FolderPickerImplementation>();
		builder.Services.AddSingleton<IFileSaver, Platforms.MacCatalyst.FileSaverImplementation>();
#elif ANDROID
		// Android implementations would go here when needed
		// builder.Services.AddSingleton<IFolderPicker, Platforms.Android.FolderPickerImplementation>();
		// builder.Services.AddSingleton<IFileSaver, Platforms.Android.FileSaverImplementation>();
#elif IOS
		// iOS implementations would go here when needed
		// builder.Services.AddSingleton<IFolderPicker, Platforms.iOS.FolderPickerImplementation>();
		// builder.Services.AddSingleton<IFileSaver, Platforms.iOS.FileSaverImplementation>();
#endif

		return builder.Build();
	}
}
