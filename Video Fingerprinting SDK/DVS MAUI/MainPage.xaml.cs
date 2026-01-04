namespace DVS_MAUI
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using VisioForge.Core.VideoFingerPrinting;
    using DVS_MAUI.Services;
    using VisioForge.Core;

    public partial class MainPage : ContentPage
    {
        private IFolderPicker _folderPicker;
        private ObservableCollection<string> _sourceFolders = new ObservableCollection<string>();
        private ObservableCollection<ResultItemViewModel> _results = new ObservableCollection<ResultItemViewModel>();

        public MainPage()
        {
            InitializeComponent();

            Unloaded += (s, e) => 
            {
                VisioForgeX.DestroySDK();
            };

            lbSourceFolders.ItemsSource = _sourceFolders;
            lbResults.ItemsSource = _results;
            
            // Set default values for Pickers
            cbIndexingTime.SelectedIndex = 1;  // Default to "5 seconds"
            cbSkipFirst.SelectedIndex = 0;     // Default to "0 seconds"
            
            LoadSettings();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            // Get the folder picker service when the page appears (after Handler is set)
            if (_folderPicker == null && Application.Current?.Handler?.MauiContext?.Services != null)
            {
                _folderPicker = Application.Current.Handler.MauiContext.Services.GetService<IFolderPicker>();
            }
        }

        private async void btAddFolder_Click(object? sender, EventArgs e)
        {
            try
            {
                string result = null;
                
                // Use platform-specific folder picker if available
                if (_folderPicker != null)
                {
                    result = await _folderPicker.PickFolderAsync(
                        "Select Folder", 
                        Settings.LastPath);
                }
                else
                {
                    // Fallback to text input if folder picker is not available
                    result = await DisplayPromptAsync(
                        "Add Folder", 
                        "Enter the full path to the folder:",
                        initialValue: Settings.LastPath ?? string.Empty);
                }
                
                if (!string.IsNullOrWhiteSpace(result))
                {
                    if (Directory.Exists(result))
                    {
                        _sourceFolders.Add(result);
                        Settings.LastPath = result;
                    }
                    else
                    {
                        await DisplayAlertAsync("Error", "The specified folder does not exist.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding folder: {ex.Message}");
                await DisplayAlertAsync("Error", $"Failed to add folder: {ex.Message}", "OK");
            }
        }

        private void btRemoveFolder_Click(object? sender, EventArgs e)
        {
            if (lbSourceFolders.SelectedItem is string selectedFolder)
            {
                _sourceFolders.Remove(selectedFolder);
            }
        }

        private async void btSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                btSearch.IsEnabled = false;
                edErrors.Text = string.Empty;
                _results.Clear();

                // Settings
                int indexingTime = cbIndexingTime.SelectedIndex switch
                {
                    0 => 3,
                    1 => 5,
                    2 => 10,
                    3 => 30,
                    _ => 5
                };

                var extensions = new List<string>();
                if (cbFormatAVI.IsChecked) extensions.Add("avi");
                if (cbFormatFLV.IsChecked) extensions.Add("flv");
                if (cbFormatMKV.IsChecked) extensions.Add("mkv");
                if (cbFormatMOV.IsChecked) extensions.Add("mov");
                if (cbFormatMP4.IsChecked) extensions.Add("mp4");
                if (cbFormatMPG.IsChecked) extensions.Add("mpg");
                if (cbFormatTS.IsChecked) extensions.Add("ts");
                if (cbFormatWMV.IsChecked) extensions.Add("wmv");

                if (extensions.Count == 0)
                {
                    await DisplayAlertAsync("Warning", "Please select at least one format to analyze.", "OK");
                    return;
                }

                lbStatus.Text = "Step 1: Searching video files";

                var filenames = new List<string>();
                foreach (string folder in _sourceFolders)
                {
                    filenames.AddRange(FileScanner.SearchVideoInFolder(folder, extensions));
                }

                if (filenames.Count == 0)
                {
                    await DisplayAlertAsync("Information", "No video files found in the specified folders.", "OK");
                    return;
                }

                lbStatus.Text = "Step 2: Getting fingerprints for video files";

                var fingerPrints = new List<VFPFingerPrint>();
                int progress = 0;

                foreach (string filename in filenames)
                {
                    await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = progress / 100.0);

                    VFPFingerPrint? fp = null;
                    try
                    {
#if MACCATALYST
                        // Restore security-scoped access for the file's directory on macOS
                        var folderPath = Path.GetDirectoryName(filename);
                        if (!string.IsNullOrEmpty(folderPath))
                        {
                            Platforms.MacCatalyst.FolderPickerImplementation.RestoreSecurityScopedAccess(folderPath);
                        }
#endif
                        
                        var source = new VFPFingerprintSource(filename)
                        {
                            StopTime = TimeSpan.FromSeconds(indexingTime)
                        };

                        fp = await VFPAnalyzer.GetComparingFingerprintForVideoFileAsync(source, ErrorCallback);
                    }
                    catch (Exception ex)
                    {
                        await MainThread.InvokeOnMainThreadAsync(() => 
                            edErrors.Text += $"{filename}: {ex.Message}{Environment.NewLine}");
                    }

                    if (fp != null)
                    {
                        fingerPrints.Add(fp);
                    }

                    progress += 100 / filenames.Count;
                }

                await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = 1.0);

                lbStatus.Text = "Step 3: Analyzing data";
                progress = 0;
                int foundCount = 0;

                var results = new List<SearchResult>();
                var clonesToIgnore = new HashSet<string>();

                foreach (var first in fingerPrints)
                {
                    await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = progress / 100.0);

                    if (first == null || clonesToIgnore.Contains(first.OriginalFilename))
                        continue;

                    foreach (var second in fingerPrints)
                    {
                        if (second == null || first.OriginalFilename == second.OriginalFilename)
                            continue;

                        int diff = VFPAnalyzer.Compare(first, second, TimeSpan.FromSeconds(slMaxShift.Value));

                        if (diff < slSensitivity.Value * 10)
                        {
                            foundCount++;
                            clonesToIgnore.Add(second.OriginalFilename);

                            var existingResult = results.FirstOrDefault(r => r.GroupFile == first.OriginalFilename);
                            if (existingResult != null)
                            {
                                existingResult.Clones.Add(second.OriginalFilename);
                            }
                            else
                            {
                                var result = new SearchResult
                                {
                                    GroupFile = first.OriginalFilename
                                };
                                result.Clones.Add(second.OriginalFilename);
                                results.Add(result);
                            }
                        }
                    }

                    progress += 100 / fingerPrints.Count;
                }

                await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = 0);

                // Display results
                foreach (var result in results)
                {
                    var groupItem = new ResultItemViewModel
                    {
                        FilePath = result.GroupFile,
                        IsChecked = false,
                        IsGroupHeader = true
                    };
                    _results.Add(groupItem);

                    foreach (var clone in result.Clones)
                    {
                        var cloneItem = new ResultItemViewModel
                        {
                            FilePath = clone,
                            IsChecked = true,
                            IsGroupHeader = false
                        };
                        _results.Add(cloneItem);
                    }
                }

                lbStatus.Text = $"Step 4: Done. {foundCount} copies found.";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Search error: {ex.Message}");
                await DisplayAlertAsync("Error", $"Search failed: {ex.Message}", "OK");
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    edErrors.Text += $"Search error: {ex.Message}{Environment.NewLine}";
                    lbStatus.Text = "Search failed.";
                });
            }
            finally
            {
                btSearch.IsEnabled = true;
            }
        }


        private async void btDelete_Click(object? sender, EventArgs e)
        {
            var itemsToDelete = _results.Where(r => r.IsChecked && !r.IsGroupHeader).ToList();
            
            if (itemsToDelete.Count == 0)
            {
                await DisplayAlertAsync("Information", "No files selected for deletion.", "OK");
                return;
            }

            bool confirm = await DisplayAlertAsync("Confirm", 
                $"Are you sure you want to delete {itemsToDelete.Count} file(s)?", 
                "Yes", "No");
            
            if (!confirm)
                return;

            int deletedCount = 0;
            foreach (var item in itemsToDelete)
            {
                try
                {
                    if (File.Exists(item.FilePath))
                    {
#if MACCATALYST
                        // Restore security-scoped access for the file's directory on macOS
                        var folderPath = Path.GetDirectoryName(item.FilePath);
                        if (!string.IsNullOrEmpty(folderPath))
                        {
                            Platforms.MacCatalyst.FolderPickerImplementation.RestoreSecurityScopedAccess(folderPath);
                        }
#endif
                        
                        File.Delete(item.FilePath);
                        _results.Remove(item);
                        deletedCount++;
                    }
                }
                catch (Exception ex)
                {
                    edErrors.Text += $"Failed to delete {item.FilePath}: {ex.Message}{Environment.NewLine}";
                }
            }

            if (deletedCount > 0)
            {
                await DisplayAlertAsync("Success", $"{deletedCount} file(s) have been deleted.", "OK");
            }
        }

        private void slSensitivity_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (lbSensitivity != null)
            {
                lbSensitivity.Text = ((int)slSensitivity.Value).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void slMaxShift_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            if (lbMaxShift != null)
            {
                lbMaxShift.Text = ((int)slMaxShift.Value).ToString(CultureInfo.InvariantCulture);
            }
        }

        private void SaveSettings()
        {
            try
            {
                string filename = Path.Combine(Settings.SettingsFolder, "settings.json");
                
                if (!Directory.Exists(Settings.SettingsFolder))
                {
                    Directory.CreateDirectory(Settings.SettingsFolder);
                }

                Settings.Save(typeof(Settings), filename);
            }
            catch (Exception ex)
            {
                // Log error but don't crash
                System.Diagnostics.Debug.WriteLine($"Failed to save settings: {ex.Message}");
            }
        }

        private void LoadSettings()
        {
            try
            {
                string filename = Path.Combine(Settings.SettingsFolder, "settings.json");
                
                if (File.Exists(filename))
                {
                    Settings.Load(typeof(Settings), filename);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't crash
                System.Diagnostics.Debug.WriteLine($"Failed to load settings: {ex.Message}");
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SaveSettings();
        }

        private void ErrorCallback(string error)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                edErrors.Text += error + Environment.NewLine;
            });
        }
    }

    public class ResultItemViewModel
    {
        public string FilePath { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
        public bool IsGroupHeader { get; set; }
    }
}
