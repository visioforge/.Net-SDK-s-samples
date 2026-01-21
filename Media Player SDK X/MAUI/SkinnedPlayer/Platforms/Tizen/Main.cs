using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace SkinnedPlayer_MAUI;

class Program : MauiApplication
{
        /// <summary>
        /// Create maui app.
        /// </summary>
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        /// <summary>
        /// Main.
        /// </summary>
	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}

