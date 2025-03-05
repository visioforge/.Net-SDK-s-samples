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
/// Interaction logic for MainWindow.xaml
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

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
       
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        VisioForgeX.DestroySDK();
    }
}