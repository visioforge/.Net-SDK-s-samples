namespace DVS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using Microsoft.Win32;

    using VisioForge.Core.VideoFingerPrinting;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Cancellation token source for the search operation.
        /// </summary>
        private CancellationTokenSource _searchCts;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt add folder click event.
        /// </summary>
        private void btAddFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFolderDialog
            {
                InitialDirectory = Settings.LastPath
            };

            bool? result = dlg.ShowDialog(this);

            if (result == true)
            {
                lbSourceFolders.Items.Add(dlg.FolderName);
                Settings.LastPath = dlg.FolderName;
            }
        }

        /// <summary>
        /// Handles the bt remove folder click event.
        /// </summary>
        private void btRemoveFolder_Click(object sender, RoutedEventArgs e)
        {
            if (lbSourceFolders.SelectedIndex != -1)
            {
                lbSourceFolders.Items.RemoveAt(lbSourceFolders.SelectedIndex);
            }
        }

        /// <summary>
        /// Handles the bt search click event.
        /// </summary>
        private async void btSearch_Click(object sender, RoutedEventArgs e)
        {
            // Handle cancel request
            if (_searchCts != null)
            {
                _searchCts.Cancel();
                return;
            }

            _searchCts = new CancellationTokenSource();
            var cancellationToken = _searchCts.Token;

            btSearch.Content = "Cancel";
            edErrors.Text = string.Empty;

            try
            {
                // Settings
                int indexingTime = 5;
                switch (cbIndexingTime.SelectedIndex)
                {
                    case 0:
                        indexingTime = 3;
                        break;
                    case 1:
                        indexingTime = 5;
                        break;
                    case 2:
                        indexingTime = 10;
                        break;
                    case 3:
                        indexingTime = 30;
                        break;
                }

                List<string> extensions = new List<string>();
                if (cbFormatAVI.IsChecked == true)
                {
                    extensions.Add("avi");
                }

                if (cbFormatFLV.IsChecked == true)
                {
                    extensions.Add("flv");
                }

                if (cbFormatMKV.IsChecked == true)
                {
                    extensions.Add("mkv");
                }

                if (cbFormatMOV.IsChecked == true)
                {
                    extensions.Add("mov");
                }

                if (cbFormatMP4.IsChecked == true)
                {
                    extensions.Add("mp4");
                }

                if (cbFormatMPG.IsChecked == true)
                {
                    extensions.Add("mpg");
                }

                if (cbFormatTS.IsChecked == true)
                {
                    extensions.Add("ts");
                }

                if (cbFormatWMV.IsChecked == true)
                {
                    extensions.Add("wmv");
                }

                lbStatus.Text = "Step 1: Searching video files";

                List<string> filenames = new List<string>();

                List<VFPFingerPrint> fingerPrints = new List<VFPFingerPrint>();

                foreach (string item in lbSourceFolders.Items)
                {
                    filenames.AddRange(FileScanner.SearchVideoInFolder(item, extensions));
                }

                cancellationToken.ThrowIfCancellationRequested();

                lbStatus.Text = "Step 2: Getting fingerprints for video files";

                int progress = 0;
                foreach (string filename in filenames)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    pbProgress.Value = progress;

                    VFPFingerPrint fp = null;

                    try
                    {
                        var source = new VFPFingerprintSource(filename)
                        {
                            StopTime = TimeSpan.FromSeconds(indexingTime)
                        };

                        fp = await VFPAnalyzer.GetComparingFingerprintForVideoFileAsync(source, ErrorCallback);
                    }
                    catch (Exception ex)
                    {
                        edErrors.Text += ex.Message + Environment.NewLine;
                    }

                    if (fp != null)
                    {
                        fingerPrints.Add(fp);
                    }

                    progress += filenames.Count > 0 ? 100 / filenames.Count : 0;
                }

                pbProgress.Value = 100;

                lbResults.Items.Clear();
                lbStatus.Text = "Step 3: Analyzing data";

                // Capture UI values for background processing
                double maxShiftValue = slMaxShift.Value;
                double sensitivityValue = slSensitivity.Value;

                // Run the O(n^2) comparison on a background thread to keep UI responsive
                var (results, foundCount) = await Task.Run(() =>
                {
                    var searchResults = new List<SearchResult>();
                    int matchCount = 0;
                    int bgProgress = 0;

                    var clonesToIgnore = new HashSet<string>();
                    foreach (var first in fingerPrints)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        if (first == null || clonesToIgnore.Contains(first.OriginalFilename))
                        {
                            continue;
                        }

                        foreach (var second in fingerPrints)
                        {
                            if (second == null || first.OriginalFilename == second.OriginalFilename)
                            {
                                continue;
                            }

                            int diff = VFPAnalyzer.Compare(first, second, TimeSpan.FromSeconds(maxShiftValue));

                            if (diff < sensitivityValue * 10)
                            {
                                matchCount++;

                                clonesToIgnore.Add(second.OriginalFilename);

                                var result = new SearchResult()
                                {
                                    GroupFile = first.OriginalFilename
                                };
                                result.Clones.Add(second.OriginalFilename);

                                searchResults.Add(result);
                            }
                        }

                        bgProgress += fingerPrints.Count > 0 ? 100 / fingerPrints.Count : 0;

                        // Update progress on UI thread
                        Dispatcher.Invoke(() => pbProgress.Value = bgProgress);
                    }

                    return (searchResults, matchCount);
                }, cancellationToken);

                pbProgress.Value = 0;

                foreach (var result in results)
                {
                    ResultItem item = new ResultItem
                    {
                        Text = { Text = result.GroupFile },
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Screenshot = { Source = Helper.GetImageForFile(result.GroupFile) }
                    };

                    lbResults.Items.Add(item);

                    foreach (var clone in result.Clones)
                    {
                        ResultItem item2 = new ResultItem
                        {
                            Text = { Text = clone },
                            Checked = { IsChecked = true },
                            HorizontalAlignment = HorizontalAlignment.Stretch,
                            Screenshot = { Source = Helper.GetImageForFile(clone) }
                        };

                        lbResults.Items.Add(item2);
                    }
                }

                lbStatus.Text = "Step 4: Done. " + foundCount + " copies found.";
            }
            catch (OperationCanceledException)
            {
                lbStatus.Text = "Search cancelled.";
                pbProgress.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during search: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                edErrors.Text += ex.Message + Environment.NewLine;
            }
            finally
            {
                _searchCts?.Dispose();
                _searchCts = null;
                btSearch.Content = "Search";
            }
        }

        /// <summary>
        /// Handles the bt delete click event.
        /// </summary>
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            List<ResultItem> toRemove = new List<ResultItem>();

            foreach (ResultItem item in lbResults.Items)
            {
                if (item.Checked.IsChecked == true)
                {
                    toRemove.Add(item);
                }
            }

            if (toRemove.Count == 0)
            {
                return;
            }

            // Show confirmation dialog before deleting files
            var confirmResult = MessageBox.Show(
                $"Are you sure you want to permanently delete {toRemove.Count} file(s)?\n\nThis action cannot be undone.",
                "Confirm Deletion",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (confirmResult != MessageBoxResult.Yes)
            {
                return;
            }

            int deletedCount = 0;
            List<string> failedFiles = new List<string>();

            foreach (var item in toRemove)
            {
                try
                {
                    File.Delete(item.Text.Text);
                    lbResults.Items.Remove(item);
                    deletedCount++;
                }
                catch (Exception ex)
                {
                    failedFiles.Add($"{item.Text.Text}: {ex.Message}");
                }
            }

            if (failedFiles.Count > 0)
            {
                MessageBox.Show(
                    $"Successfully deleted {deletedCount} file(s).\n\nFailed to delete {failedFiles.Count} file(s):\n{string.Join("\n", failedFiles)}",
                    "Deletion Results",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
            else if (deletedCount > 0)
            {
                MessageBox.Show(
                    $"Successfully deleted {deletedCount} file(s).",
                    "Deletion Complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Sl sensitivity value changed.
        /// </summary>
        private void slSensitivity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbSensitivity != null)
            {
                lbSensitivity.Text = ((int)slSensitivity.Value).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Sl max shift value changed.
        /// </summary>
        private void slMaxShift_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbMaxShift != null)
            {
                lbMaxShift.Text = ((int)slMaxShift.Value).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Save settings.
        /// </summary>
        private void SaveSettings()
        {
            string filename = Path.Combine(Settings.SettingsFolder, "settings.xml");

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            if (!Directory.Exists(Settings.SettingsFolder))
            {
                Directory.CreateDirectory(Settings.SettingsFolder);
            }

            Settings.Save(typeof(Settings), filename);
        }

        /// <summary>
        /// Load settings.
        /// </summary>
        private void LoadSettings()
        {
            string filename = Path.Combine(Settings.SettingsFolder, "settings.xml");

            if (File.Exists(filename))
            {
                Settings.Load(typeof(Settings), filename);
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadSettings();
        }

        /// <summary>
        /// Window unloaded.
        /// </summary>
        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Error callback.
        /// </summary>
        private void ErrorCallback(string error)
        {
            Dispatcher.Invoke(() =>
            {
                edErrors.Text += error + Environment.NewLine;
            });
        }
    }
}
