using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.Core;

namespace EncoderConcurrencyTest
{
    /// <summary>
    /// Pick a webcam, a format and a frame rate. Used by the main window when the user
    /// switches the source mode to "Webcam" — the resulting <see cref="WebcamSelection"/>
    /// is then reused for every "Add pipeline" / "Fill to limit" call until the user
    /// reconfigures.
    /// </summary>
    public partial class WebcamConfigDialog : Window
    {
        public WebcamSelection Result { get; private set; }

        private readonly WebcamSelection _initial;

        public WebcamConfigDialog(WebcamSelection initial)
        {
            InitializeComponent();
            _initial = initial;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                IsEnabled = false;
                await PopulateDevicesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to enumerate video sources: " + ex.Message);
                DialogResult = false;
                Close();
                return;
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private async Task PopulateDevicesAsync()
        {
            var devices = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .Select(d => d.DisplayName)
                .ToArray();

            cbDevice.ItemsSource = devices;
            if (devices.Length == 0)
            {
                btOk.IsEnabled = false;
                return;
            }

            var initialDevice = _initial?.DeviceName;
            var preselect = !string.IsNullOrEmpty(initialDevice) && devices.Contains(initialDevice)
                ? initialDevice
                : devices[0];
            cbDevice.SelectedItem = preselect;
        }

        private async void CbDevice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFormat.ItemsSource = null;
            cbFrameRate.ItemsSource = null;

            var deviceName = cbDevice.SelectedItem as string;
            if (string.IsNullOrEmpty(deviceName)) return;

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null) return;

            var formats = device.VideoFormats.Select(f => f.Name).ToArray();
            cbFormat.ItemsSource = formats;
            if (formats.Length == 0) return;

            var preferred = _initial?.DeviceName == deviceName ? _initial?.FormatName : null;
            cbFormat.SelectedItem = !string.IsNullOrEmpty(preferred) && formats.Contains(preferred)
                ? preferred
                : formats[0];
        }

        private async void CbFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbFrameRate.ItemsSource = null;

            var deviceName = cbDevice.SelectedItem as string;
            var formatName = cbFormat.SelectedItem as string;
            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(formatName)) return;

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null) return;

            var format = device.VideoFormats.FirstOrDefault(f => f.Name == formatName);
            if (format == null) return;

            var rates = format.GetFrameRateRangeAsStringList().ToArray();
            cbFrameRate.ItemsSource = rates;
            if (rates.Length == 0) return;

            var preferred = _initial?.DeviceName == deviceName && _initial?.FormatName == formatName
                ? _initial?.FrameRateText
                : null;
            cbFrameRate.SelectedItem = !string.IsNullOrEmpty(preferred) && rates.Contains(preferred)
                ? preferred
                : rates[0];
        }

        private async void BtOk_Click(object sender, RoutedEventArgs e)
        {
            var deviceName = cbDevice.SelectedItem as string;
            var formatName = cbFormat.SelectedItem as string;
            var rateText = cbFrameRate.SelectedItem as string;

            if (string.IsNullOrEmpty(deviceName) || string.IsNullOrEmpty(formatName))
            {
                MessageBox.Show("Pick a camera and a format first.");
                return;
            }

            var device = (await DeviceEnumerator.Shared.VideoSourcesAsync())
                .FirstOrDefault(d => d.DisplayName == deviceName);
            if (device == null)
            {
                MessageBox.Show("Selected device disappeared — re-enumerate.");
                return;
            }

            var formatItem = device.VideoFormats.FirstOrDefault(f => f.Name == formatName);
            if (formatItem == null)
            {
                MessageBox.Show("Selected format is no longer available.");
                return;
            }

            double rate = 30;
            if (!string.IsNullOrEmpty(rateText))
            {
                double.TryParse(rateText, System.Globalization.NumberStyles.Float,
                    System.Globalization.CultureInfo.InvariantCulture, out rate);
            }
            if (rate <= 0)
            {
                rate = formatItem.FrameRateList.Count > 0 ? formatItem.FrameRateList[0].Value : 30;
            }

            Result = new WebcamSelection
            {
                DeviceName = deviceName,
                FormatName = formatName,
                FrameRateText = rateText,
                Width = formatItem.Width,
                Height = formatItem.Height,
                FrameRate = rate,
            };

            DialogResult = true;
            Close();
        }
    }

    /// <summary>
    /// Result of <see cref="WebcamConfigDialog"/>. Plain data, kept by the main window
    /// for as long as Source mode is "Webcam".
    /// </summary>
    public class WebcamSelection
    {
        public string DeviceName { get; set; }
        public string FormatName { get; set; }
        public string FrameRateText { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double FrameRate { get; set; }

        public string Summary => $"{DeviceName}  {Width}x{Height}@{FrameRate:0.##}";
    }
}
