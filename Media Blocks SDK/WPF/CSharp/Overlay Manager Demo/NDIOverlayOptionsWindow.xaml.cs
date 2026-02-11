using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEffects;
using System.Diagnostics;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for NDIOverlayOptionsWindow.xaml
    /// </summary>
    public partial class NDIOverlayOptionsWindow : Window
    {
        private NDISourceInfo[] _ndiSources;

        public NDISourceInfo SelectedSource { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int VideoWidth { get; private set; }
        public int VideoHeight { get; private set; }
        public double OpacityLevel { get; private set; }
        public OverlayManagerImageStretchMode StretchMode { get; private set; }
        public bool EnableShadow { get; private set; }

        public NDIOverlayOptionsWindow()
        {
            InitializeComponent();
            
            // Set up opacity slider
            slOpacity.ValueChanged += (s, e) =>
            {
                lbOpacityValue.Content = slOpacity.Value.ToString("F1");
            };

            Loaded += NDIOverlayOptionsWindow_Loaded;
        }

        /// <summary>
        /// Ndi overlay options window loaded.
        /// </summary>
        private async void NDIOverlayOptionsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load NDI sources
                await LoadNDISourcesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Load ndi sources async.
        /// </summary>
        private async Task LoadNDISourcesAsync()
        {
            try
            {
                cbNDISource.Items.Clear();
                cbNDISource.Items.Add("Discovering NDI sources...");
                cbNDISource.SelectedIndex = 0;
                cbNDISource.IsEnabled = false;
                btRefresh.IsEnabled = false;

                _ndiSources = await DeviceEnumerator.Shared.NDISourcesAsync();

                cbNDISource.Items.Clear();

                if (_ndiSources == null || _ndiSources.Length == 0)
                {
                    cbNDISource.Items.Add("No NDI sources found");
                    cbNDISource.SelectedIndex = 0;
                    MessageBox.Show("No NDI sources found on the network. Please ensure NDI sources are broadcasting and the GStreamer NDI plugin is installed.",
                        "No Sources", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    foreach (var source in _ndiSources)
                    {
                        var item = new ComboBoxItem
                        {
                            Content = source.Name,
                            Tag = source
                        };
                        cbNDISource.Items.Add(item);
                    }

                    cbNDISource.SelectedIndex = 0;
                }

                cbNDISource.IsEnabled = true;
                btRefresh.IsEnabled = true;
            }
            catch (Exception ex)
            {
                cbNDISource.Items.Clear();
                cbNDISource.Items.Add("Error loading sources");
                cbNDISource.SelectedIndex = 0;
                MessageBox.Show($"Error loading NDI sources: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
                cbNDISource.IsEnabled = true;
                btRefresh.IsEnabled = true;
            }
        }

        /// <summary>
        /// Handles the bt refresh click event.
        /// </summary>
        private async void btRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadNDISourcesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        /// <summary>
        /// Handles the bt click event.
        /// </summary>
        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate NDI source selection
            if (cbNDISource.SelectedItem is ComboBoxItem sourceItem && sourceItem.Tag is NDISourceInfo source)
            {
                SelectedSource = source;
            }
            else
            {
                MessageBox.Show("Please select a valid NDI source.", "Invalid Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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
            OpacityLevel = slOpacity.Value;
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
                    StretchMode = OverlayManagerImageStretchMode.Letterbox;
                    break;
            }

            DialogResult = true;
            Close();
        }
    }
}
