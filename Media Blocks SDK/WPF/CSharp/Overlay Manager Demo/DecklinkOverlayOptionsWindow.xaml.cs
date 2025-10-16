using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.VideoEffects;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for DecklinkOverlayOptionsWindow.xaml
    /// </summary>
    public partial class DecklinkOverlayOptionsWindow : Window
    {
        private DecklinkVideoSourceInfo[] _devices;

        public DecklinkVideoSourceInfo SelectedDevice { get; private set; }
        public DecklinkMode SelectedMode { get; private set; }
        public DecklinkConnection SelectedConnection { get; private set; }
        public bool AutoDeinterlace { get; private set; }
        public uint BufferSize { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int VideoWidth { get; private set; }
        public int VideoHeight { get; private set; }
        public double Opacity { get; private set; }
        public OverlayManagerImageStretchMode StretchMode { get; private set; }
        public bool EnableShadow { get; private set; }

        public DecklinkOverlayOptionsWindow()
        {
            InitializeComponent();
            
            // Set up opacity slider
            slOpacity.ValueChanged += (s, e) =>
            {
                lbOpacityValue.Content = slOpacity.Value.ToString("F1");
            };

            Loaded += DecklinkOverlayOptionsWindow_Loaded;
        }

        private async void DecklinkOverlayOptionsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load Decklink devices
            await LoadDevicesAsync();
        }

        private async Task LoadDevicesAsync()
        {
            try
            {
                cbDevice.Items.Clear();
                cbDevice.Items.Add("Loading devices...");
                cbDevice.SelectedIndex = 0;
                cbDevice.IsEnabled = false;

                _devices = await DecklinkVideoSourceBlock.GetDevicesAsync();

                cbDevice.Items.Clear();

                if (_devices == null || _devices.Length == 0)
                {
                    cbDevice.Items.Add("No devices found");
                    cbDevice.SelectedIndex = 0;
                    MessageBox.Show("No Decklink devices found. Please ensure your Decklink hardware is connected and drivers are installed.",
                        "No Devices", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (var device in _devices)
                {
                    var item = new ComboBoxItem
                    {
                        Content = $"{device.ModelName} (Device {device.DeviceNumber})",
                        Tag = device
                    };
                    cbDevice.Items.Add(item);
                }

                cbDevice.SelectedIndex = 0;
                cbDevice.IsEnabled = true;
            }
            catch (Exception ex)
            {
                cbDevice.Items.Clear();
                cbDevice.Items.Add("Error loading devices");
                cbDevice.SelectedIndex = 0;
                MessageBox.Show($"Error loading Decklink devices: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate device selection
            if (cbDevice.SelectedItem is ComboBoxItem deviceItem && deviceItem.Tag is DecklinkVideoSourceInfo device)
            {
                SelectedDevice = device;
            }
            else
            {
                MessageBox.Show("Please select a valid Decklink device.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get mode
            if (cbMode.SelectedItem is ComboBoxItem modeItem && Enum.TryParse<DecklinkMode>(modeItem.Tag.ToString(), out var mode))
            {
                SelectedMode = mode;
            }
            else
            {
                MessageBox.Show("Please select a valid video mode.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get connection
            if (cbConnection.SelectedItem is ComboBoxItem connectionItem && Enum.TryParse<DecklinkConnection>(connectionItem.Tag.ToString(), out var connection))
            {
                SelectedConnection = connection;
            }
            else
            {
                MessageBox.Show("Please select a valid connection type.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get buffer size
            if (!uint.TryParse(tbBufferSize.Text, out uint bufferSize) || bufferSize < 1 || bufferSize > 100)
            {
                MessageBox.Show("Please enter a valid buffer size (1-100 frames).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            BufferSize = bufferSize;

            // Validate position
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

            // Validate size
            if (!int.TryParse(tbWidth.Text, out int width) || width <= 0)
            {
                MessageBox.Show("Please enter a valid width (> 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(tbHeight.Text, out int height) || height <= 0)
            {
                MessageBox.Show("Please enter a valid height (> 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Set properties
            X = x;
            Y = y;
            VideoWidth = width;
            VideoHeight = height;
            AutoDeinterlace = cbAutoDeinterlace.IsChecked == true;
            Opacity = slOpacity.Value;
            EnableShadow = cbEnableShadow.IsChecked == true;

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
