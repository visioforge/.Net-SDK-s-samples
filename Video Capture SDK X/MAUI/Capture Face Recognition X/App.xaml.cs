namespace Capture_Face_Recognition_X
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        /// <inheritdoc />
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "Video Capture SDK .Net — Face Recognition";
            return window;
        }
    }
}