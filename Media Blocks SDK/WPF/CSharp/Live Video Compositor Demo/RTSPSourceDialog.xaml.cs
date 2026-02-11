using System.Windows;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for RTSPSourceDialog.xaml
    /// </summary>
    public partial class RTSPSourceDialog : Window
    {
        public string URL { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        public bool AudioEnabled { get; private set; }

        public RTSPSourceDialog()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edURL.Text))
            {
                MessageBox.Show(this, "Please enter an RTSP URL.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            URL = edURL.Text.Trim();
            Login = edLogin.Text;
            Password = edPassword.Password;
            AudioEnabled = cbAudioEnabled.IsChecked == true;
            DialogResult = true;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
