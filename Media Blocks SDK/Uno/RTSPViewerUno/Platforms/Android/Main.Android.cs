using System;
using Android.App;
using Android.Runtime;
using Uno.UI.Hosting;

namespace RTSPViewerUno.Droid;

[global::Android.App.ApplicationAttribute(
    Label = "@string/ApplicationName",
    LargeHeap = true,
    HardwareAccelerated = true,
    Theme = "@style/AppTheme"
)]
public class Application : Uno.UI.Runtime.Android.NativeApplication
{
    static Application()
    {
        App.InitializeLogging();
    }
    
    public Application(IntPtr javaReference, JniHandleOwnership transfer)
        : base(javaReference, transfer)
    {
    }

    protected override UnoPlatformHost CreateHost() =>
        UnoPlatformHostBuilder.Create()
            .App(() => new App())
            .UseAndroid()
            .Build();
}
