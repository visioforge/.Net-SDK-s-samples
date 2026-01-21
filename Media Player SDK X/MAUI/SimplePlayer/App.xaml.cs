namespace Simple_Player_MAUI
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
    }
}