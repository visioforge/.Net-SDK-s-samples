using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.UI.Skins;

namespace Skinned_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// The disposed value.
        /// </summary>
        private bool disposedValue;

        #region Title bar

        // Can execute
        /// <summary>
        /// Command binding can execute.
        /// </summary>
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        /// <summary>
        /// Command binding executed minimize.
        /// </summary>
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        /// <summary>
        /// Command binding executed maximize.
        /// </summary>
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        /// <summary>
        /// Command binding executed restore.
        /// </summary>
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        /// <summary>
        /// Command binding executed close.
        /// </summary>
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        /// <summary>
        /// Handles the main window state change raised event.
        /// </summary>
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
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            var skinFile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Skins", "Default.vfskin");
            SkinManager.LoadFromFile(skinFile);

            //var skinPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Skins", "Default");
            //SkinManager.LoadFromFolder(skinPath);

            InitializeComponent();

            StateChanged += MainWindowStateChangeRaised;

            playlist.SkinName = "Default";
            playerControls.SkinName = "Default";
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateEngine();

            CaptionBlock.Text += $" (SDK v{MediaPlayer1.SDK_Version()})";

            MediaPlayer1.Debug_Dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");

            playerControls.ConnectPlaylist(playlist);

            playlist.AttachPlayer(MediaPlayer1);
            playlist.AttachPlayerControls(playerControls);
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
            MediaPlayer1.OnError += MediaPlayer1_OnError;
            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.WPF_WinUI_Callback;
            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Video_Effects_Enabled = true;

            VideoView1.MouseDown += MediaPlayer1_MouseDown;

            playerControls.Player = MediaPlayer1;
            playerControls.OnAction += PlayerControls_OnAction;
        }

        /// <summary>
        /// Player controls on action.
        /// </summary>
        private async void PlayerControls_OnAction(object sender, SkinActionEventArgs e)
        {
            if (e.Type == SkinElementType.FullScreen)
            {
                await ToggleFullScreenAsync();
            }
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.OnError -= MediaPlayer1_OnError;
                VideoView1.MouseDown -= MediaPlayer1_MouseDown;

                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        /// <summary>
        /// Media player 1 on error.
        /// </summary>
        private void MediaPlayer1_OnError(object sender, ErrorsEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
        }

        /// <summary>
        /// Window size changed.
        /// </summary>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //VideoView1.Height = e.NewSize.Height - playerControls.ActualHeight - 45;
        }

        #region Full screen

        /// <summary>
        /// The full screen flag.
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
        /// The control margin.
        /// </summary>
        private Thickness controlMargin;

        /// <summary>
        /// The control width.
        /// </summary>
        private double controlWidth;

        /// <summary>
        /// The control height.
        /// </summary>
        private double controlHeight;

        /// <summary>
        /// Toggle full screen async.
        /// </summary>
        private async Task ToggleFullScreenAsync()
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

                playerControls.Visibility = Visibility.Hidden;
                pnCaption.Height = 0;

                await MediaPlayer1.Video_Renderer_UpdateAsync();
            }
            else
            {
                // going normal screen
                fullScreen = false;

                // restoring control
                VideoView1.Margin = controlMargin;
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

                playerControls.Visibility = Visibility.Visible;
                pnCaption.Height = 30;

                await MediaPlayer1.Video_Renderer_UpdateAsync();
            }
        }

        /// <summary>
        /// Media player 1 mouse down.
        /// </summary>
        private async void MediaPlayer1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fullScreen)
            {
                await ToggleFullScreenAsync();
            }
        }

        #endregion

        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                DestroyEngine();

                MediaPlayer1?.Dispose();
                MediaPlayer1 = null;

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
