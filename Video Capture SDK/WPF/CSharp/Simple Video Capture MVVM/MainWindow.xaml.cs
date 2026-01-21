using Prism.Navigation.Regions;
using System.Windows;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="videoCaptureAccessor">The video capture accessor.</param>
        public MainWindow(IRegionManager regionManager, IVideoCaptureAccessor videoCaptureAccessor)
        {
            InitializeComponent();
            

            this.regionManager = regionManager;
            this.videoCaptureAccessor = videoCaptureAccessor;
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.regionManager.AddToRegion("VideoCaptureRegion", this.videoCaptureAccessor.UIElement);
            this.videoCaptureAccessor.SetOwnerWindow(this);
        }

        /// <summary>
        /// The region manager.
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The video capture accessor.
        /// </summary>
        private readonly IVideoCaptureAccessor videoCaptureAccessor;
    }
}
