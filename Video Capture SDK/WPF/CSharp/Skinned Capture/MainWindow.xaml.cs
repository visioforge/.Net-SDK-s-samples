using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.UI.Skins;
using VisioForge.Core.VideoCapture;

namespace Skinned_Capture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public MainWindow()
        {
            var skinFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Skins", "Default.vfskin");
            SkinManager.LoadFromFile(skinFile);

            //var skinPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Skins", "Default");
            //SkinManager.LoadFromFolder(skinPath);

            InitializeComponent();

            StateChanged += MainWindowStateChangeRaised;
        }

        /// <summary>
        /// The video capture.
        /// </summary>
        private VideoCaptureCore VideoCapture1;

        /// <summary>
        /// The camera index.
        /// </summary>
        private int _cameraIndex;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        #region Title bar

        // Can execute
        /// <summary>
        /// Command binding can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        /// <summary>
        /// Command binding executed minimize.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        /// <summary>
        /// Command binding executed maximize.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        /// <summary>
        /// Command binding executed restore.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        /// <summary>
        /// Command binding executed close.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        /// <summary>
        /// Handles the main window state change raised event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainWindowBorder.BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainWindowBorder.BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }

        #endregion

        /// <summary>
        /// Window loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();
            CaptionBlock.Text += $" (SDK v{VideoCapture1.SDK_Version()})";

            VideoCapture1.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            VideoCapture1 = new VideoCaptureCore(VideoView1 as IVideoView);
            VideoCapture1.OnError += VideoCapture1_OnError;
            VideoCapture1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;
            VideoCapture1.Audio_PlayAudio = true;
            VideoCapture1.Video_Effects_Enabled = true;

            VideoView1.MouseDown += VideoCapture1_MouseDown;

            captureControls.Capture = VideoCapture1;
            captureControls.OnAction += Controls_OnAction;
        }

        /// <summary>
        /// Controls on action.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SkinActionEventArgs"/> instance containing the event data.</param>
        private async void Controls_OnAction(object sender, SkinActionEventArgs e)
        {
            if (e.Type == SkinElementType.FullScreen)
            {
                await ToggleFullScreen();
            }
            else if (e.Type == SkinElementType.CameraSwitch)
            {
                await CameraSwitch();
            }
        }

        /// <summary>
        /// Camera switch.
        /// </summary>
        private async Task CameraSwitch()
        {
            await VideoCapture1.StopAsync();

            if (_cameraIndex >= VideoCapture1.Video_CaptureDevices().Count - 1)
            {
                _cameraIndex = 0;
            }

            //var device = VideoCapture1.Video_CaptureDevices()[_cameraIndex];
            //device.DevicePath
            //var videoSource = new VideoCaptureSource(.Name);


            //VideoCapture1.Video_CaptureDevice = videoSource;


            _cameraIndex++;

            await VideoCapture1.StartAsync();
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (VideoCapture1 != null)
            {
                VideoCapture1.OnError -= VideoCapture1_OnError;
                VideoView1.MouseDown -= VideoCapture1_MouseDown;

                VideoCapture1.Dispose();
                VideoCapture1 = null;
            }
        }

        /// <summary>
        /// Video capture 1 on error.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ErrorsEventArgs"/> instance containing the event data.</param>
        private void VideoCapture1_OnError(object sender, ErrorsEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Window size changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SizeChangedEventArgs"/> instance containing the event data.</param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //VideoView1.Height = e.NewSize.Height - playerControls.ActualHeight - 45;
        }

        #region Full screen

        /// <summary>
        /// The full screen mode value.
        /// </summary>
        private bool fullScreen;

        /// <summary>
        /// The window left value.
        /// </summary>
        private double windowLeft;

        /// <summary>
        /// The window top value.
        /// </summary>
        private double windowTop;

        /// <summary>
        /// The window width value.
        /// </summary>
        private double windowWidth;

        /// <summary>
        /// The window height value.
        /// </summary>
        private double windowHeight;

        /// <summary>
        /// The control margin value.
        /// </summary>
        private Thickness controlMargin;

        /// <summary>
        /// The control width value.
        /// </summary>
        private double controlWidth;

        /// <summary>
        /// The control height value.
        /// </summary>
        private double controlHeight;

        /// <summary>
        /// Toggle full screen.
        /// </summary>
        private async Task ToggleFullScreen()
        {
            if (!fullScreen)
            {
                // going fullscreen
                fullScreen = true;

                // saving coordinates
                windowLeft = Left;
                windowTop = Top;
                windowWidth = Width;
                windowHeight = Height;

                controlMargin = VideoView1.Margin;
                controlWidth = VideoView1.Width;
                controlHeight = VideoView1.Height;

                // resizing window
                ResizeMode = ResizeMode.NoResize;
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                //Topmost = true;

                Left = 0;
                Top = 0;
                Width = SystemParameters.PrimaryScreenWidth;
                Height = SystemParameters.PrimaryScreenHeight;
                Margin = new Thickness(0);

                // resizing control
                VideoView1.Margin = new Thickness(0, 0, 0, 0);
                VideoView1.Width = SystemParameters.PrimaryScreenWidth;
                VideoView1.Height = SystemParameters.PrimaryScreenHeight;

                captureControls.Visibility = Visibility.Hidden;
                pnCaption.Height = 0;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoView1.Margin = controlMargin;
                VideoView1.Width = controlWidth;
                VideoView1.Height = controlHeight;

                VideoView1.Width = controlWidth;
                VideoView1.Height = controlHeight;

                // restoring window
                Left = windowLeft;
                Top = windowTop;
                Width = windowWidth;
                Height = windowHeight;

                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                //Topmost = false;
                ResizeMode = ResizeMode.CanResize;

                captureControls.Visibility = Visibility.Visible;
                pnCaption.Height = 30;

                await VideoCapture1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Video capture 1 mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private async void VideoCapture1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                await ToggleFullScreen();
            }
        }

        #endregion

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                DestroyEngine();

                VideoCapture1?.Dispose();
                VideoCapture1 = null;

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MainWindow()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
