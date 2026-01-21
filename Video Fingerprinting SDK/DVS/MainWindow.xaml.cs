namespace DVS
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Forms;

    using VisioForge.Core.VideoFingerPrinting;

    using VisioForge_MMT;

    using HorizontalAlignment = System.Windows.HorizontalAlignment;
    using MessageBox = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            // StyleManager.ApplicationTheme = new Windows8Theme();
            InitializeComponent();
        }

        /// <summary>
        /// Handles the bt add folder click event.
        /// </summary>
        private void btAddFolder_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog
            {
                SelectedPath = Settings.LastPath
            };

            DialogResult result = dlg.ShowDialog(this.GetIWin32Window());

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                lbSourceFolders.Items.Add(dlg.SelectedPath);
                Settings.LastPath = dlg.SelectedPath;
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
            btSearch.IsEnabled = false;
            edErrors.Text = string.Empty;

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

            lbStatus.Text = "Step 2: Getting fingerprints for video files";

            int progress = 0;
            foreach (string filename in filenames)
            {
                pbProgress.Value = progress;

                VFPFingerPrint fp = null;
                string error = null;

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

                if (error != null)
                {
                    edErrors.Text += error + Environment.NewLine;
                }

                progress += 100 / filenames.Count;
            }

            pbProgress.Value = 100;

            List<SearchResult> results = new List<SearchResult>();

            results.Clear();
            lbResults.Items.Clear();
            lbStatus.Text = "Step 3: Analyzing data";
            progress = 0;
            int foundCount = 0;

            List<string> clonesToIgnore = new List<string>();
            foreach (var first in fingerPrints)
            {
                pbProgress.Value = progress;

                if (first == null)
                {
                    continue;
                }

                if (clonesToIgnore.Contains(first.OriginalFilename))
                {
                    continue;
                }

                foreach (var second in fingerPrints)
                {
                    if (second == null)
                    {
                        continue;
                    }

                    if (first.OriginalFilename == second.OriginalFilename)
                    {
                        continue;
                    }

                    int diff = VFPAnalyzer.Compare(first, second, TimeSpan.FromSeconds(slMaxShift.Value));

                    if (diff < slSensitivity.Value * 10)
                    {
                        foundCount++;

                        clonesToIgnore.Add(second.OriginalFilename);

                        var result = new SearchResult()
                        {
                            GroupFile = first.OriginalFilename
                        };
                        result.Clones.Add(second.OriginalFilename);

                        results.Add(result);
                    }
                }

                progress += 100 / fingerPrints.Count;
            }

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

            btSearch.IsEnabled = true;
        }

        /// <summary>
        /// Handles the bt delete click event.
        /// </summary>
        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            bool removed = false;

            List<ResultItem> toRemove = new List<ResultItem>();

            foreach (ResultItem item in lbResults.Items)
            {
                if (item.Checked.IsChecked == true)
                {
                    removed = true;

                    File.Delete(item.Text.Text);

                    toRemove.Add(item);
                }
            }

            foreach (var item in toRemove)
            {
                lbResults.Items.Remove(item);
            }

            if (removed)
            {
                MessageBox.Show("File(s) has been removed!");
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
            string filename = Settings.SettingsFolder + "settings.xml";

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
            string filename = Settings.SettingsFolder + "settings.xml";

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
