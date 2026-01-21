using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.X.Decklink;
using VisioForge.Core.Types.X.VideoEffects;
using VisioForge.Core.Types.X.Output;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for DecklinkOverlayOptionsWindow.xaml
    /// </summary>
    public partial class DecklinkOverlayOptionsWindow : Window
    {
        private DecklinkVideoSourceInfo[] _devices;
        private AudioOutputDeviceInfo[] _audioDevices;

        public DecklinkVideoSourceInfo SelectedDevice { get; private set; }
        public DecklinkMode SelectedMode { get; private set; }
        public DecklinkConnection SelectedConnection { get; private set; }
        public bool AutoDeinterlace { get; private set; }
        public uint BufferSize { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int VideoWidth { get; private set; }
        public int VideoHeight { get; private set; }
        public double OpacityLevel { get; private set; }
        public OverlayManagerImageStretchMode StretchMode { get; private set; }
        public bool EnableShadow { get; private set; }
        public bool EnableAudio { get; private set; }
        public int SelectedAudioDeviceIndex { get; private set; } = 0;

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

        /// <summary>
        /// Decklink overlay options window loaded.
        /// </summary>
        private async void DecklinkOverlayOptionsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Load Decklink devices
            await LoadDevicesAsync();
            
            // Load audio devices
            await LoadAudioDevicesAsync();
        }

        /// <summary>
        /// Load devices async.
        /// </summary>
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

        /// <summary>
        /// Load audio devices async.
        /// </summary>
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

        /// <summary>
        /// Cb enable audio changed.
        /// </summary>
        private void cbEnableAudio_Changed(object sender, RoutedEventArgs e)
        {
            if (cbAudioDevice == null)
                return;

            cbAudioDevice.IsEnabled = cbEnableAudio.IsChecked == true;
        }

        /// <summary>
        /// Handles the bt click event.
        /// </summary>
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
            OpacityLevel = slOpacity.Value;
            EnableShadow = cbEnableShadow.IsChecked == true;
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
