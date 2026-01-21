using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using VisioForge.Core.MediaPlayer;
using VisioForge.Core.Types;
using VisioForge.Core.Types.MediaPlayer;

namespace madVR_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The open file dialog.
        /// </summary>
        private readonly Microsoft.Win32.OpenFileDialog openFileDialog1 = new Microsoft.Win32.OpenFileDialog();

        /// <summary>
        /// The timer.
        /// </summary>
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        /// <summary>
        /// The media player instance.
        /// </summary>
        private MediaPlayerCore MediaPlayer1;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the timer 1 tick event.
        /// </summary>
        private void timer1_Tick()
        {
            _timer.Tag = 1;
            tbTimeline.Maximum = (int)(MediaPlayer1.Duration_Time()).TotalSeconds;

            int value = (int)(MediaPlayer1.Position_Get_Time()).TotalSeconds;
            if ((value > 0) && (value < tbTimeline.Maximum))
            {
                tbTimeline.Value = value;
            }

            lbTimestamp.Text = MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Value) + "/" + MediaPlayer1.Helpful_SecondsToTimeFormatted((int)tbTimeline.Maximum);

            _timer.Tag = 0;
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            MediaPlayer1 = new MediaPlayerCore(VideoView1 as IVideoView);
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (MediaPlayer1 != null)
            {
                MediaPlayer1.Dispose();
                MediaPlayer1 = null;
            }
        }

        /// <summary>
        /// Handles the bt select file click event.
        /// </summary>
        private void btSelectFile_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == true)
            {
                edFilename.Text = openFileDialog1.FileName;
            }
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();

            MediaPlayer1.Stop();

            tbTimeline.Value = 0;
        }

        /// <summary>
        /// Handles the bt play click event.
        /// </summary>
        private void btPlay_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer1.Source_Mode = MediaPlayerSourceMode.LAV;

            MediaPlayer1.Playlist_Clear();
            MediaPlayer1.Playlist_Add(edFilename.Text);

            MediaPlayer1.Audio_PlayAudio = true;
            MediaPlayer1.Info_UseLibMediaInfo = true;
            MediaPlayer1.Audio_OutputDevice = "Default DirectSound Device";

            MediaPlayer1.Video_Renderer.VideoRenderer = VideoRendererMode.MadVR;

            MediaPlayer1.Play();

            _timer.Start();
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick +=
                delegate (object s, EventArgs a)
                {
                    timer1_Tick();
                };

            CreateEngine();

            Title += $" (SDK v{MediaPlayer1.SDK_Version()})";
            MediaPlayer1.Debug_Dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge");
        }

        /// <summary>
        /// Tb timeline value changed.
        /// </summary>
        private void tbTimeline_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Convert.ToInt32(_timer.Tag) == 0)
            {
                MediaPlayer1.Position_Set_Time(TimeSpan.FromSeconds(tbTimeline.Value));
            }
        }
    }
}
