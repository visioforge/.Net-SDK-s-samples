using System.Collections.ObjectModel;
using System.Diagnostics;
using VisioForge.Core.Types;
using VisioForge.Core.VideoFingerPrinting;
using VisioForge.Core.UI.MAUI;
using Rect = VisioForge.Core.Types.Rect;
using MMT_MAUI.Services;
using VisioForge.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MMT_MAUI;

public partial class MainPage : ContentPage
{
    /// <summary>
    /// The ignored areas.
    /// </summary>
    private readonly List<Rect> _ignoredAreas = new List<Rect>();

    /// <summary>
    /// The database.
    /// </summary>
    private VFPFingerPrintDB? _db;

    /// <summary>
    /// The results.
    /// </summary>
    private readonly ObservableCollection<ResultsViewModel> results = new ObservableCollection<ResultsViewModel>();

    /// <summary>
    /// The broadcast folders.
    /// </summary>
    private readonly ObservableCollection<string> broadcastFolders = new ObservableCollection<string>();

    /// <summary>
    /// The ad folders.
    /// </summary>
    private readonly ObservableCollection<string> adFolders = new ObservableCollection<string>();

    /// <summary>
    /// The ignored areas list.
    /// </summary>
    private readonly ObservableCollection<string> ignoredAreasList = new ObservableCollection<string>();

    /// <summary>
    /// The database items.
    /// </summary>
    private readonly ObservableCollection<string> dbItems = new ObservableCollection<string>();

    /// <summary>
    /// The file saver.
    /// </summary>
    private readonly IFileSaver? _fileSaver;

    /// <summary>
    /// Gets the results.
    /// </summary>
    public ObservableCollection<ResultsViewModel> Results { get { return this.results; } }

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
        InitializeComponent();
        
        BindingContext = this;        

        lvResults.ItemsSource = results;

        Unloaded += MainPage_Unloaded;

        // Get the services from dependency injection
#if WINDOWS || MACCATALYST
        try
        {
            _fileSaver = Microsoft.Maui.Controls.Application.Current?.Handler?.MauiContext?.Services?.GetService<IFileSaver>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to get IFileSaver service: {ex.Message}");
        }
#endif
        
        LoadDB();
    }


        /// <summary>
        /// Main page unloaded.
        /// </summary>
    private void MainPage_Unloaded(object? sender, EventArgs e)
    {
        // Destroy SDK
        VisioForgeX.DestroySDK();
    }

        /// <summary>
        /// Handles the bt add broadcast file click event.
        /// </summary>
    private async void btAddBroadcastFile_Click(object? sender, EventArgs e)
    {
        try
        {
#if MACCATALYST
            // Mac Catalyst specific implementation
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.MacCatalyst, new[] { "public.movie", "public.video", "public.mpeg-4", "public.avi", "public.mpeg" } }
                });
            
            var options = new PickOptions
            {
                PickerTitle = "Select broadcast video file",
                FileTypes = customFileType
            };
            
            // Ensure we're on the main thread
            FileResult file = null;
            if (MainThread.IsMainThread)
            {
                file = await FilePicker.Default.PickAsync(options);
            }
            else
            {
                file = await MainThread.InvokeOnMainThreadAsync(async () => 
                    await FilePicker.Default.PickAsync(options));
            }
            
            if (file != null)
            {
                // Add to UI for feedback
                broadcastFolders.Add(file.FullPath);
                var label = new Label 
                { 
                    Text = file.FullPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbBroadcastFolders.Children.Add(label);
                
                Settings.LastPath = Path.GetDirectoryName(file.FullPath);
            }
#else
            // Use single file picker on all platforms
            var options = new PickOptions
            {
                PickerTitle = "Select video file",
                FileTypes = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".mp4", ".mov", ".avi", ".mkv", ".m4v", ".wmv", ".flv", ".webm", ".mpg", ".mpeg" } },
                        { DevicePlatform.Android, new[] { "video/*" } },
                        { DevicePlatform.iOS, new[] { "public.movie", "public.video" } }
                    })
            };

            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                broadcastFolders.Add(result.FullPath);
                
                // Add label directly to the UI
                var label = new Label 
                { 
                    Text = result.FullPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbBroadcastFolders.Children.Add(label);
                
                Settings.LastPath = Path.GetDirectoryName(result.FullPath) ?? "";
            }
#endif
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Failed to select files: {ex.Message}", "OK");
        }
    }

        /// <summary>
        /// Handles the bt add ad file click event.
        /// </summary>
    private async void btAddAdFile_Click(object? sender, EventArgs e)
    {
        try
        {
#if MACCATALYST
            // Mac Catalyst specific implementation
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.MacCatalyst, new[] { "public.movie", "public.video", "public.mpeg-4", "public.avi", "public.mpeg" } }
                });
            
            var options = new PickOptions
            {
                PickerTitle = "Select ad video file",
                FileTypes = customFileType
            };
            
            // Ensure we're on the main thread
            FileResult file = null;
            if (MainThread.IsMainThread)
            {
                file = await FilePicker.Default.PickAsync(options);
            }
            else
            {
                file = await MainThread.InvokeOnMainThreadAsync(async () => 
                    await FilePicker.Default.PickAsync(options));
            }
            
            if (file != null)
            {
                // Add to UI for feedback
                adFolders.Add(file.FullPath);
                var label = new Label 
                { 
                    Text = file.FullPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbAdFolders.Children.Add(label);
                
                Settings.LastPath = Path.GetDirectoryName(file.FullPath);
            }
#else
            // Use single file picker on all platforms
            var options = new PickOptions
            {
                PickerTitle = "Select ad video file",
                FileTypes = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.WinUI, new[] { ".mp4", ".mov", ".avi", ".mkv", ".m4v", ".wmv", ".flv", ".webm", ".mpg", ".mpeg" } },
                        { DevicePlatform.Android, new[] { "video/*" } },
                        { DevicePlatform.iOS, new[] { "public.movie", "public.video" } }
                    })
            };

            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                adFolders.Add(result.FullPath);
                
                // Add label directly to the UI
                var label = new Label 
                { 
                    Text = result.FullPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbAdFolders.Children.Add(label);
                
                Settings.LastPath = Path.GetDirectoryName(result.FullPath) ?? "";
            }
#endif
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Failed to select files: {ex.Message}", "OK");
        }
    }

        /// <summary>
        /// Handles the bt clear ads click event.
        /// </summary>
    private void btClearAds_Click(object? sender, EventArgs e)
    {
        adFolders.Clear();
        lbAdFolders.Children.Clear();
    }

        /// <summary>
        /// Handles the bt clear broadcast click event.
        /// </summary>
    private void btClearBroadcast_Click(object? sender, EventArgs e)
    {
        broadcastFolders.Clear();
        lbBroadcastFolders.Children.Clear();
    }

        /// <summary>
        /// Error delegate.
        /// </summary>
    private async void errorDelegate(string error)
    {
        await DisplayAlertAsync("Error", error, "OK");
    }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
    private async void btStart_Click(object? sender, EventArgs e)
    {
        try
        {
            if (cbDebug.IsChecked == true)
            {
                VFPAnalyzer.DebugDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "MMT");
            }

            btStart.IsEnabled = false;

            results.Clear();

            lbStatus.Text = "Step 1: Searching video files";

            List<string> adList = new List<string>();
            List<string> broadcastList = new List<string>();

            List<VFPFingerPrint> adVFPList = new List<VFPFingerPrint>();
            List<VFPFingerPrint> broadcastVFPList = new List<VFPFingerPrint>();

            foreach (string item in adFolders)
            {
                if (Directory.Exists(item))
                {
                    adList.AddRange(FileScanner.SearchVideoFiles(item));
                }
                else if (File.Exists(item))
                {
                    adList.Add(item);
                }
            }

            foreach (string item in broadcastFolders)
            {
                if (Directory.Exists(item))
                {
                    broadcastList.AddRange(FileScanner.SearchVideoFiles(item));
                }
                else if (File.Exists(item))
                {
                    broadcastList.Add(item);
                }
            }

            lbStatus.Text = "Step 2: Getting fingerprints for ads files";

            int progress = 0;
            foreach (string filename in adList)
            {
                await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = progress / 100.0);

                var source = new VFPFingerprintSource(filename);
                foreach (var area in _ignoredAreas)
                {
                    source.IgnoredAreas.Add(area);
                }

                VFPFingerPrint? fp = _db?.GetFingerprint(source);

                if (fp == null)
                {
                    fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);

                    if (fp == null)
                    {
                        await DisplayAlertAsync("Error", "Unable to get fingerprint for the video file: " + filename, "OK");
                    }
                    else
                    {
                        if (_db != null)
                        {
                            _db.Items.Add(fp);
                            AddDBItem(fp);
                        }
                    }
                }

                if (fp != null)
                {
                    adVFPList.Add(fp);
                }

                progress += 100 / adList.Count;
            }

            await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = 1.0);

            lbStatus.Text = "Step 3: Getting fingerprints for broadcast files";
            progress = 0;
            foreach (string filename in broadcastList)
            {
                await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = progress / 100.0);

                var source = new VFPFingerprintSource(filename);
                foreach (var area in _ignoredAreas)
                {
                    source.IgnoredAreas.Add(area);
                }

                VFPFingerPrint? fp = _db?.GetFingerprint(source);
                if (fp == null)
                {
                    fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);
                    if (fp == null)
                    {
                        await DisplayAlertAsync("Error", "Unable to get fingerprint for the video file: " + filename, "OK");
                        return;
                    }
                    else
                    {
                        if (_db != null)
                        {
                            _db.Items.Add(fp);
                            AddDBItem(fp);
                        }
                    }
                }

                broadcastVFPList.Add(fp);

                progress += 100 / broadcastList.Count;
            }

            await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = 1.0);

            lbStatus.Text = "Step 4: Analyzing data";
            progress = 0;
            int foundCount = 0;
            foreach (var broadcast in broadcastVFPList)
            {
                await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = progress / 100.0);

                foreach (var ad in adVFPList)
                {
                    var positions = await VFPAnalyzer.SearchAsync(ad, broadcast, ad.Duration, (int)slDifference.Value, true);

                    if (positions.Count > 0)
                    {
                        foreach (var pos in positions)
                        {
                            foundCount++;
                            int minutes = (int)(pos.TotalSeconds / 60);
                            int seconds = (int)(pos.TotalSeconds % 60);

                            results.Add(
                                new ResultsViewModel()
                                {
                                    Sample = ad.OriginalFilename,
                                    DumpFile = broadcast.OriginalFilename,
                                    Position = $"{minutes}:{seconds}"
                                });
                        }
                    }
                }

                progress += 100 / broadcastList.Count;
            }

            await MainThread.InvokeOnMainThreadAsync(() => pbProgress.Progress = 0);

            lbStatus.Text = "Step 5: Done. " + foundCount + " ads found.";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error in analysis: {ex.Message}");
            await DisplayAlertAsync("Error", $"Analysis failed: {ex.Message}", "OK");
            lbStatus.Text = "Error occurred during analysis.";
        }
        finally
        {
            btStart.IsEnabled = true;
        }
    }

        /// <summary>
        /// Handles the bt play click event.
        /// </summary>
    private async void btPlay_Click(object? sender, EventArgs e)
    {
        if (lvResults.SelectedItem == null)
        {
            return;
        }

        // VideoView playback requires MediaBlocks pipeline setup
        // For simplicity, just show the file path for now
        var selected = (ResultsViewModel)lvResults.SelectedItem;
        await DisplayAlertAsync("Play Video", $"Selected file: {selected.DumpFile}", "OK");
        
        // TODO: Implement MediaBlocks pipeline for video playback
        // Requires: UniversalSourceBlock, VideoRendererBlock, AudioRendererBlock
    }

        /// <summary>
        /// Handles the bt save results click event.
        /// </summary>
    private async void btSaveResults_Click(object? sender, EventArgs e)
    {
        try
        {
            if (results.Count == 0)
            {
                await DisplayAlertAsync("Info", "No results to save", "OK");
                return;
            }

#if MACCATALYST
            // For Mac Catalyst, we need to handle file saving differently due to sandboxing
            try
            {
                // First prepare the data in memory
                var saveOptions = await DisplayActionSheetAsync("Save as", "Cancel", null, "CSV", "XML");
                if (saveOptions == "Cancel" || string.IsNullOrEmpty(saveOptions))
                    return;

                string tempFileName;
                string tempPath;
                
                if (saveOptions == "XML")
                {
                    tempFileName = "results.xml";
                    tempPath = Path.Combine(Path.GetTempPath(), tempFileName);
                    SaveResultsAsXml(tempPath);
                }
                else
                {
                    tempFileName = "results.csv";
                    tempPath = Path.Combine(Path.GetTempPath(), tempFileName);
                    results.ToList().SerializeToCsv(tempPath, ',');
                }

                // Now use the share/save functionality
                await Share.Default.RequestAsync(new ShareFileRequest
                {
                    Title = "Save Results",
                    File = new ShareFile(tempPath)
                });

                // Clean up temp file after a delay
                await Task.Delay(2000);
                if (File.Exists(tempPath))
                {
                    try 
                    { 
                        File.Delete(tempPath); 
                    } 
                    catch (Exception ex) 
                    { 
                        System.Diagnostics.Debug.WriteLine($"Failed to delete temp file: {ex.Message}");
                    }
                }
                
                await DisplayAlertAsync("Success", "Results exported successfully", "OK");
            }
            catch (Exception macEx)
            {
                await DisplayAlertAsync("Error", $"Failed to save results: {macEx.Message}", "OK");
            }
#else
            string? filename = null;

            // Use the native file saver service for Windows
            if (_fileSaver != null)
            {
                var fileTypes = new Dictionary<string, List<string>>
                {
                    { "CSV Files", new List<string> { ".csv" } },
                    { "XML Files", new List<string> { ".xml" } }
                };

                filename = await _fileSaver.SaveFileAsync("results", fileTypes);
            }

            if (!string.IsNullOrEmpty(filename))
            {
                // Ensure the file has an extension
                if (!Path.HasExtension(filename))
                {
                    filename += ".csv";
                }

                string extension = Path.GetExtension(filename).ToLowerInvariant();
                
                if (extension == ".xml")
                {
                    // Save as XML
                    SaveResultsAsXml(filename);
                    await DisplayAlertAsync("Success", $"Results saved to {Path.GetFileName(filename)}", "OK");
                }
                else
                {
                    // Save as CSV (default)
                    results.ToList().SerializeToCsv(filename, ',');
                    await DisplayAlertAsync("Success", $"Results saved to {Path.GetFileName(filename)}", "OK");
                }
            }
#endif
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"Failed to save results: {ex.Message}", "OK");
        }
    }

        /// <summary>
        /// Save results as xml.
        /// </summary>
    private void SaveResultsAsXml(string filename)
    {
        using (var writer = new System.Xml.XmlTextWriter(filename, System.Text.Encoding.UTF8))
        {
            writer.Formatting = System.Xml.Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Results");
            
            foreach (var result in results)
            {
                writer.WriteStartElement("Result");
                writer.WriteElementString("Sample", result.Sample ?? string.Empty);
                writer.WriteElementString("Position", result.Position ?? string.Empty);
                writer.WriteElementString("DumpFile", result.DumpFile ?? string.Empty);
                writer.WriteEndElement();
            }
            
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
    }

        /// <summary>
        /// Sl difference value changed.
        /// </summary>
    private void slDifference_ValueChanged(object? sender, ValueChangedEventArgs e)
    {
        if (lbDifference != null)
        {
            lbDifference.Text = ((int)e.NewValue).ToString();
        }
    }

        /// <summary>
        /// Handles the bt ignored area add click event.
        /// </summary>
    private void btIgnoredAreaAdd_Click(object? sender, EventArgs e)
    {
        var rect = new Rect()
        {
            Left = Convert.ToInt32(edIgnoredAreaLeft.Text),
            Top = Convert.ToInt32(edIgnoredAreaTop.Text),
            Right = Convert.ToInt32(edIgnoredAreaRight.Text),
            Bottom = Convert.ToInt32(edIgnoredAreaBottom.Text)
        };

        _ignoredAreas.Add(rect);
        var areaText = $"Left: {rect.Left}, Top: {rect.Top}, Right: {rect.Right}, Bottom: {rect.Bottom}";
        ignoredAreasList.Add(areaText);
        
        // Add label directly to the UI
        var label = new Label 
        { 
            Text = areaText,
            TextColor = Colors.Black,
            Padding = new Thickness(5),
            GestureRecognizers = { new TapGestureRecognizer() }
        };
        lbIgnoredAreas.Children.Add(label);
    }

        /// <summary>
        /// Handles the bt ignored areas remove item click event.
        /// </summary>
    private void btIgnoredAreasRemoveItem_Click(object? sender, EventArgs e)
    {
        // Since we don't have selection anymore, remove the last item
        if (ignoredAreasList.Count > 0)
        {
            ignoredAreasList.RemoveAt(ignoredAreasList.Count - 1);
            _ignoredAreas.RemoveAt(_ignoredAreas.Count - 1);
            if (lbIgnoredAreas.Children.Count > 0)
            {
                lbIgnoredAreas.Children.RemoveAt(lbIgnoredAreas.Children.Count - 1);
            }
        }
    }

        /// <summary>
        /// Handles the bt ignored areas remove all click event.
        /// </summary>
    private void btIgnoredAreasRemoveAll_Click(object? sender, EventArgs e)
    {
        ignoredAreasList.Clear();
        _ignoredAreas.Clear();
        lbIgnoredAreas.Children.Clear();
    }

        /// <summary>
        /// Handles the bt db clear click event.
        /// </summary>
    private void btDBClear_Click(object? sender, EventArgs e)
    {
        if (_db != null)
        {
            _db.Items.Clear();
        }
        dbItems.Clear();
        lbDB.Children.Clear();
    }

        /// <summary>
        /// Add db item.
        /// </summary>
    private void AddDBItem(VFPFingerPrint fp)
    {
        var txt = $"{fp.OriginalFilename} [{fp.Width}x{fp.Height}, {fp.OriginalDuration.ToString("g")}]";
        if (fp.IgnoredAreas.Count > 0)
        {
            txt += "(with ignored areas)";
        }

        dbItems.Add(txt);
        
        // Add label directly to the UI
        var label = new Label 
        { 
            Text = txt,
            TextColor = Colors.Black,
            Padding = new Thickness(5),
            GestureRecognizers = { new TapGestureRecognizer() }
        };
        lbDB.Children.Add(label);
    }

        /// <summary>
        /// Load db.
        /// </summary>
    private void LoadDB()
    {
        var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
        lbDBLocation.Text = $"DB file: {dbFile}";
        
        if (File.Exists(dbFile))
        {
            _db = VFPFingerPrintDB.Load(dbFile);
        }
        else
        {
            _db = new VFPFingerPrintDB();
        }

        foreach (var item in _db.Items)
        {
            AddDBItem(item);
        }
    }

        /// <summary>
        /// Save db.
        /// </summary>
    private void SaveDB()
    {
        if (_db != null)
        {
            var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
            _db.Save(dbFile);
        }
    }

        /// <summary>
        /// On disappearing.
        /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SaveDB();
    }
}
