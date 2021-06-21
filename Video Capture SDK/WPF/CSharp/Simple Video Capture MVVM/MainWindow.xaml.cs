using Prism.Regions;
using System.Windows;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(IRegionManager regionManager, IVideoCaptureAccessor videoCaptureAccessor)
        {
            InitializeComponent();
            System.Windows.Forms.Application.EnableVisualStyles();

            this.regionManager = regionManager;
            this.videoCaptureAccessor = videoCaptureAccessor;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.regionManager.AddToRegion("VideoCaptureRegion", this.videoCaptureAccessor.UIElement);
            this.videoCaptureAccessor.SetOwnerWindow(this);
        }

        private readonly IRegionManager regionManager;
        private readonly IVideoCaptureAccessor videoCaptureAccessor;
    }
}
