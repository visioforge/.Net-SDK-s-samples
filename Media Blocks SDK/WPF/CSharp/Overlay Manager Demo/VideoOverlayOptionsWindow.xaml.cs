using System.Windows;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.MediaBlocks.AudioRendering;
using System.Threading.Tasks;
using System.Linq;
using VisioForge.Core.Types.X.Output;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for VideoOverlayOptionsWindow.xaml
    /// </summary>
    public partial class VideoOverlayOptionsWindow : Window
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int VideoWidth { get; private set; }
        public int VideoHeight { get; private set; }
        public bool Loop { get; private set; }
        public double OpacityLevel { get; private set; }
        public OverlayManagerImageStretchMode StretchMode { get; private set; }
        public bool EnableShadow { get; private set; }
        public bool UseExternalVideoView { get; private set; }
        public bool EnableAudio { get; private set; }
        public int SelectedAudioDeviceIndex { get; private set; } = 0;

        private AudioOutputDeviceInfo[] _audioDevices;

        public VideoOverlayOptionsWindow()
        {
            InitializeComponent();
            
            // Set up opacity slider
            slOpacity.ValueChanged += (s, e) =>
            {
                lbOpacityValue.Content = slOpacity.Value.ToString("F1");
            };

            Loaded += VideoOverlayOptionsWindow_Loaded;
        }

        private async void VideoOverlayOptionsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadAudioDevicesAsync();
        }

        private async Task LoadAudioDevicesAsync()
        {
            try
            {
                _audioDevices = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
                
                cbAudioDevice.Items.Clear();
                if (_audioDevices != null && _audioDevices.Length > 0)
                {
                    foreach (var device in _audioDevices)
                    {
                        cbAudioDevice.Items.Add(device.Name);
                    }
                    cbAudioDevice.SelectedIndex = 0;
                }
                else
                {
                    cbAudioDevice.Items.Add("No audio devices found");
                    cbAudioDevice.SelectedIndex = 0;
                    cbAudioDevice.IsEnabled = false;
                    cbEnableAudio.IsChecked = false;
                    cbEnableAudio.IsEnabled = false;
                }
            }
            catch
            {
                cbAudioDevice.Items.Add("Error loading audio devices");
                cbAudioDevice.SelectedIndex = 0;
                cbAudioDevice.IsEnabled = false;
                cbEnableAudio.IsChecked = false;
                cbEnableAudio.IsEnabled = false;
            }
        }

        private void cbEnableAudio_Changed(object sender, RoutedEventArgs e)
        {
            if (cbAudioDevice == null)
                return;

            cbAudioDevice.IsEnabled = cbEnableAudio.IsChecked == true;
        }

        private void cbOriginalSize_Checked(object sender, RoutedEventArgs e)
        {
            tbWidth.IsEnabled = false;
            tbHeight.IsEnabled = false;
            tbWidth.Text = "0";
            tbHeight.Text = "0";
        }

        private void cbOriginalSize_Unchecked(object sender, RoutedEventArgs e)
        {
            tbWidth.IsEnabled = true;
            tbHeight.IsEnabled = true;
            tbWidth.Text = "320";
            tbHeight.Text = "240";
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (!int.TryParse(tbX.Text, out int x) || x < 0)
            {
                MessageBox.Show("Please enter a valid X position (>= 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(tbY.Text, out int y) || y < 0)
            {
                MessageBox.Show("Please enter a valid Y position (>= 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(tbWidth.Text, out int width) || width < 0)
            {
                MessageBox.Show("Please enter a valid width (>= 0, or 0 for original).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(tbHeight.Text, out int height) || height < 0)
            {
                MessageBox.Show("Please enter a valid height (>= 0, or 0 for original).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Set properties
            X = x;
            Y = y;
            VideoWidth = width;
            VideoHeight = height;
            Loop = cbLoop.IsChecked == true;
            OpacityLevel = slOpacity.Value;
            EnableShadow = cbEnableShadow.IsChecked == true;
            UseExternalVideoView = cbUseExternalVideoView.IsChecked == true;
            EnableAudio = cbEnableAudio.IsChecked == true;
            SelectedAudioDeviceIndex = cbAudioDevice.SelectedIndex;

            // Get stretch mode
            switch (cbStretchMode.SelectedIndex)
            {
                case 0:
                    StretchMode = OverlayManagerImageStretchMode.None;
                    break;
                case 1:
                    StretchMode = OverlayManagerImageStretchMode.Stretch;
                    break;
                case 2:
                    StretchMode = OverlayManagerImageStretchMode.Letterbox;
                    break;
                case 3:
                    StretchMode = OverlayManagerImageStretchMode.CropToFill;
                    break;
                default:
                    StretchMode = OverlayManagerImageStretchMode.None;
                    break;
            }

            DialogResult = true;
            Close();
        }
    }
}