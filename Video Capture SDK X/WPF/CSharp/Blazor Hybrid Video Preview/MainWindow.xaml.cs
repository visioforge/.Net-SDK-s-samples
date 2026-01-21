using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using VisioForge.Core;

namespace Video_Preview_Blazor_Hybrid;

/// <summary>
/// Interaction logic for the Blazor Hybrid Video Preview WPF demo's MainWindow.
/// Initializes the internal service collection and the Video Capture SDK X.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddSingleton<VideoRecordingService>();
        Resources.Add("services", serviceCollection.BuildServiceProvider());

        VisioForgeX.InitSDK();
    }

    /// <summary>
    /// Handles the Loaded event of the window.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       
    }

    /// <summary>
    /// Handles the Unloaded event of the window.
    /// Ensures that the Video Capture SDK is properly destroyed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        VisioForgeX.DestroySDK();
    }
}