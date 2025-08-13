using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for NDISourceDialog.xaml
    /// </summary>
    public partial class NDISourceDialog : Window
    {
        private NDISourceInfo[] _ndiSources;

        public NDISourceInfo SelectedSource { get; private set; }

        public NDISourceDialog()
        {
            InitializeComponent();
        }

        protected override async void OnSourceInitialized(System.EventArgs e)
        {
            base.OnSourceInitialized(e);
            await RefreshNDISourcesAsync();
        }

        private async Task RefreshNDISourcesAsync()
        {
            lbNDISources.Items.Clear();
            _ndiSources = await DeviceEnumerator.Shared.NDISourcesAsync();

            if (_ndiSources != null && _ndiSources.Length > 0)
            {
                foreach (var source in _ndiSources)
                {
                    lbNDISources.Items.Add(source);
                }

                lbNDISources.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "No NDI sources found on the network.", "NDI Sources", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private async void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            await RefreshNDISourcesAsync();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            if (lbNDISources.SelectedItem != null)
            {
                SelectedSource = lbNDISources.SelectedItem as NDISourceInfo;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show(this, "Please select an NDI source.", "Selection Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}