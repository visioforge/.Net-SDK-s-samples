using System;
using System.Windows;
using VisioForge.Core.Types.X.VideoEffects;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for WebView2OverlayOptionsWindow.xaml
    /// </summary>
    public partial class WebView2OverlayOptionsWindow : Window
    {
        public string Url { get; private set; }

        public string JavaScript { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int VideoWidth { get; private set; }

        public int VideoHeight { get; private set; }

        public double OpacityLevel { get; private set; }

        public OverlayManagerImageStretchMode StretchMode { get; private set; }

        public bool EnableShadow { get; private set; }

        public WebView2OverlayOptionsWindow()
        {
            InitializeComponent();

            slOpacity.ValueChanged += (s, e) =>
            {
                lbOpacityValue.Content = slOpacity.Value.ToString("F1");
            };
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate URL
            string url = tbUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a URL.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
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

            Url = url;
            JavaScript = string.IsNullOrWhiteSpace(tbJavaScript.Text) ? null : tbJavaScript.Text;
            X = x;
            Y = y;
            VideoWidth = width;
            VideoHeight = height;
            OpacityLevel = slOpacity.Value;
            EnableShadow = cbEnableShadow.IsChecked == true;

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
