using System.Windows;
using SkiaSharp;
using VisioForge.Core.Types.X.VideoEffects;
using FontStyle = VisioForge.Core.Types.X.VideoEffects.FontStyle;
using FontWeight = VisioForge.Core.Types.X.VideoEffects.FontWeight;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for ScrollingTextOptionsWindow.xaml
    /// </summary>
    public partial class ScrollingTextOptionsWindow : Window
    {
        public string ScrollText { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int AreaWidth { get; private set; }
        public int AreaHeight { get; private set; }
        public ScrollDirection Direction { get; private set; }
        public int Speed { get; private set; }
        public bool Loop { get; private set; }
        public int FontSize { get; private set; }
        public FontStyle FontStyle { get; private set; }
        public FontWeight FontWeight { get; private set; }
        public bool Underline { get; private set; }
        public SKColor TextColor { get; private set; }
        public bool TransparentBackground { get; private set; }
        public SKColor BackgroundColor { get; private set; }
        public bool EnableShadow { get; private set; }

        public ScrollingTextOptionsWindow()
        {
            InitializeComponent();
            
            // Set up speed slider
            slSpeed.ValueChanged += (s, e) =>
            {
                lbSpeedValue.Content = ((int)slSpeed.Value).ToString();
            };
        }

        private void cbTransparentBackground_Changed(object sender, RoutedEventArgs e)
        {
            if (cbBackgroundColor == null)
                return;

            cbBackgroundColor.IsEnabled = cbTransparentBackground.IsChecked != true;
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            // Validate text
            if (string.IsNullOrWhiteSpace(tbText.Text))
            {
                MessageBox.Show("Please enter text content.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
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
            if (!int.TryParse(tbWidth.Text, out int width) || width < 0)
            {
                MessageBox.Show("Please enter a valid width (>= 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(tbHeight.Text, out int height) || height < 0)
            {
                MessageBox.Show("Please enter a valid height (>= 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Validate font size
            if (!int.TryParse(tbFontSize.Text, out int fontSize) || fontSize < 1 || fontSize > 200)
            {
                MessageBox.Show("Please enter a valid font size (1-200).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Set properties
            ScrollText = tbText.Text;
            X = x;
            Y = y;
            AreaWidth = width;
            AreaHeight = height;
            Speed = (int)slSpeed.Value;
            Loop = cbLoop.IsChecked == true;
            FontSize = fontSize;
            Underline = cbUnderline.IsChecked == true;
            TransparentBackground = cbTransparentBackground.IsChecked == true;
            EnableShadow = cbEnableShadow.IsChecked == true;

            // Get font style
            switch (cbFontStyle.SelectedIndex)
            {
                case 0:
                    FontStyle = FontStyle.Normal;
                    break;
                case 1:
                    FontStyle = FontStyle.Italic;
                    break;
                case 2:
                    FontStyle = FontStyle.Oblique;
                    break;
                default:
                    FontStyle = FontStyle.Normal;
                    break;
            }

            // Get font weight
            switch (cbFontWeight.SelectedIndex)
            {
                case 0:
                    FontWeight = FontWeight.Normal;
                    break;
                case 1:
                    FontWeight = FontWeight.Bold;
                    break;
                case 2:
                    FontWeight = FontWeight.Light;
                    break;
                case 3:
                    FontWeight = FontWeight.SemiBold;
                    break;
                default:
                    FontWeight = FontWeight.Normal;
                    break;
            }

            // Get direction
            switch (cbDirection.SelectedIndex)
            {
                case 0:
                    Direction = ScrollDirection.RightToLeft;
                    break;
                case 1:
                    Direction = ScrollDirection.LeftToRight;
                    break;
                case 2:
                    Direction = ScrollDirection.BottomToTop;
                    break;
                case 3:
                    Direction = ScrollDirection.TopToBottom;
                    break;
                default:
                    Direction = ScrollDirection.RightToLeft;
                    break;
            }

            // Get text color
            switch (cbTextColor.SelectedIndex)
            {
                case 0:
                    TextColor = SKColors.White;
                    break;
                case 1:
                    TextColor = SKColors.Yellow;
                    break;
                case 2:
                    TextColor = SKColors.Red;
                    break;
                case 3:
                    TextColor = SKColors.Green;
                    break;
                case 4:
                    TextColor = SKColors.Blue;
                    break;
                case 5:
                    TextColor = SKColors.Cyan;
                    break;
                case 6:
                    TextColor = SKColors.Orange;
                    break;
                default:
                    TextColor = SKColors.White;
                    break;
            }

            // Get background color
            switch (cbBackgroundColor.SelectedIndex)
            {
                case 0:
                    BackgroundColor = SKColors.Black;
                    break;
                case 1:
                    BackgroundColor = SKColors.DarkBlue;
                    break;
                case 2:
                    BackgroundColor = SKColors.DarkRed;
                    break;
                case 3:
                    BackgroundColor = SKColors.DarkGray;
                    break;
                default:
                    BackgroundColor = SKColors.Black;
                    break;
            }

            DialogResult = true;
            Close();
        }
    }
}
