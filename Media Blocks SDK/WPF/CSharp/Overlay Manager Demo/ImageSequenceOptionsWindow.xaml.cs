using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using VisioForge.Core.Types.X.VideoEffects;

namespace Overlay_Manager_Demo
{
    /// <summary>
    /// Interaction logic for ImageSequenceOptionsWindow.xaml
    /// </summary>
    public partial class ImageSequenceOptionsWindow : Window
    {
        public List<ImageSequenceItem> Items { get; private set; } = new List<ImageSequenceItem>();

        public int X { get; private set; }

        public int Y { get; private set; }

        public int SequenceWidth { get; private set; }

        public int SequenceHeight { get; private set; }

        public bool Loop { get; private set; }

        public double OpacityLevel { get; private set; }

        // Internal list to track filenames and durations for the ListBox display
        private readonly List<(string Filename, double Duration)> _entries = new List<(string, double)>();

        public ImageSequenceOptionsWindow()
        {
            InitializeComponent();

            slOpacity.ValueChanged += (s, e) =>
            {
                lbOpacityValue.Content = slOpacity.Value.ToString("F1");
            };
        }

        private void btAddImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Multiselect = true,
                Title = "Select Images for Sequence"
            };

            if (dlg.ShowDialog() == true)
            {
                if (!double.TryParse(tbDuration.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double duration) || duration <= 0)
                {
                    duration = 2.0;
                }

                foreach (var filename in dlg.FileNames)
                {
                    _entries.Add((filename, duration));
                    lbImages.Items.Add($"{Path.GetFileName(filename)} ({duration:F1}s)");
                }
            }
        }

        private void btRemoveImage_Click(object sender, RoutedEventArgs e)
        {
            if (lbImages.SelectedIndex >= 0)
            {
                int idx = lbImages.SelectedIndex;
                _entries.RemoveAt(idx);
                lbImages.Items.RemoveAt(idx);
            }
        }

        private void btUpdateDuration_Click(object sender, RoutedEventArgs e)
        {
            if (lbImages.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an image to update.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!double.TryParse(tbDuration.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out double duration) || duration <= 0)
            {
                MessageBox.Show("Please enter a valid duration (> 0).", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int idx = lbImages.SelectedIndex;
            var entry = _entries[idx];
            _entries[idx] = (entry.Filename, duration);
            lbImages.Items[idx] = $"{Path.GetFileName(entry.Filename)} ({duration:F1}s)";
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            if (_entries.Count == 0)
            {
                MessageBox.Show("Please add at least one image.", "No Images", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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

            // Build items list
            Items = new List<ImageSequenceItem>();
            foreach (var entry in _entries)
            {
                Items.Add(new ImageSequenceItem(entry.Filename, TimeSpan.FromSeconds(entry.Duration)));
            }

            X = x;
            Y = y;
            SequenceWidth = width;
            SequenceHeight = height;
            Loop = cbLoop.IsChecked == true;
            OpacityLevel = slOpacity.Value;

            DialogResult = true;
            Close();
        }
    }
}
