using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_MultiViewSync_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RTSPPlayEngine[] _engines = new RTSPPlayEngine[3];

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            await DestroyAllAsync();

            var settings1 = await RTSPSourceSettings.CreateAsync(new Uri(edURL1.Text), edUserName1.Text, edPassword1.Text, false);
            _engines[0] = new RTSPPlayEngine(settings1, videoView1);

            var settings2 = await RTSPSourceSettings.CreateAsync(new Uri(edURL2.Text), edUserName2.Text, edPassword2.Text, false);
            _engines[1] = new RTSPPlayEngine(settings2, videoView2);

            var settings3 = await RTSPSourceSettings.CreateAsync(new Uri(edURL3.Text), edUserName3.Text, edPassword3.Text, false);
            _engines[2] = new RTSPPlayEngine(settings3, videoView3);

            await _engines[0].PreloadAsync();
            await _engines[1].PreloadAsync();
            await _engines[2].PreloadAsync();

            while (!(_engines[0].IsPaused() && _engines[1].IsPaused() && _engines[2].IsPaused()))
            {
                Thread.Sleep(50);
            }

            await _engines[0].ResumeAsync().ConfigureAwait(false);
            await _engines[1].ResumeAsync().ConfigureAwait(false);
            await _engines[2].ResumeAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Destroy all async.
        /// </summary>
        private async Task DestroyAllAsync()
        {
            if (_engines[0] != null)
            {
               await _engines[0].DisposeAsync();
               _engines[0] = null;
            }

            if (_engines[1] != null)
            {
                await _engines[1].DisposeAsync();
               _engines[1] = null;
            }

            if (_engines[2] != null)
            {
                await _engines[2].DisposeAsync();
                _engines[2] = null;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            _engines[0].StopAsync();
            _engines[1].StopAsync();
            _engines[2].StopAsync();
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await DestroyAllAsync();

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");
        }
    }
}