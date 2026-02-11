using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using VisioForge.Core;

namespace Video_Preview_Blazor_Hybrid;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddSingleton<VideoPlayerService>();
        Resources.Add("services", serviceCollection.BuildServiceProvider());

        VisioForgeX.InitSDK();
    }

        /// <summary>
        /// Window unloaded.
        /// </summary>
    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        VisioForgeX.DestroySDK();
    }
}