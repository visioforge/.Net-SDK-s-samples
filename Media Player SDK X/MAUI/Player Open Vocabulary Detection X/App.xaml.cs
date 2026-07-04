namespace Player_Open_Vocabulary_Detection_X
{
    /// <summary>
    /// The app class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        /// <inheritdoc />
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "Media Player SDK .Net — Open Vocabulary Detection";
            return window;
        }
    }
}