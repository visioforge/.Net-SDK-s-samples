using System.Windows;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for StreamingKeyDialog.xaml
    /// </summary>
    public partial class StreamingKeyDialog : Window
    {
        public string Key { get; private set; }

        public StreamingKeyDialog(string title)
        {
            InitializeComponent();
            Title = title;
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edKey.Text))
            {
                MessageBox.Show(this, "Please enter a streaming key.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Key = edKey.Text.Trim();
            DialogResult = true;
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
