namespace Capture_Open_Vocabulary_Detection_X
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
            window.Title = "Video Capture SDK .Net — Open Vocabulary Detection";
            return window;
        }
    }
}