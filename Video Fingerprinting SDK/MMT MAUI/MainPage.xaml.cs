using System.Collections.ObjectModel;
using System.Diagnostics;
using VisioForge.Core.Types;
using VisioForge.Core.VideoFingerPrinting;
using VisioForge.Core.UI.MAUI;
using Rect = VisioForge.Core.Types.Rect;
using MMT_MAUI.Services;
using MMT_MAUI.Controls;
using VisioForge.Core;

namespace MMT_MAUI;

public partial class MainPage : ContentPage
{
    private readonly List<Rect> _ignoredAreas = new List<Rect>();
    private VFPFingerPrintDB _db;
    private readonly ObservableCollection<ResultsViewModel> results = new ObservableCollection<ResultsViewModel>();
    private readonly ObservableCollection<string> broadcastFolders = new ObservableCollection<string>();
    private readonly ObservableCollection<string> adFolders = new ObservableCollection<string>();
    private readonly ObservableCollection<string> ignoredAreasList = new ObservableCollection<string>();
    private readonly ObservableCollection<string> dbItems = new ObservableCollection<string>();
    private readonly IFolderPicker _folderPicker;
    private readonly IFileSaver _fileSaver;

    public ObservableCollection<ResultsViewModel> Results { get { return this.results; } }

    public MainPage()
    {
        InitializeComponent();
        
        BindingContext = this;        

        lvResults.ItemsSource = results;

        Unloaded += MainPage_Unloaded;

        // Get the services from dependency injection
        _folderPicker = Application.Current.Handler.MauiContext.Services.GetService<IFolderPicker>();
        _fileSaver = Application.Current.Handler.MauiContext.Services.GetService<IFileSaver>();
        
        // Initialize tabs
        InitializeTabs();
        
        LoadDB();
    }

    private void InitializeTabs()
    {
        // Broadcast tab
        var broadcastContent = new Border
        {
            Stroke = Color.FromArgb("#E0E0E0"),
            StrokeThickness = 1,
            Padding = 10,
            Content = new VerticalStackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Fill,
                Children =
                {
                    new ScrollView
                    {
                        HeightRequest = 390,
                        BackgroundColor = Colors.LightGray,
                        VerticalOptions = LayoutOptions.Fill,
                        Content = lbBroadcastFolders
                    },
                    new HorizontalStackLayout
                    {
                        Spacing = 5,
                        Children = { btAddBroadcastFile, btAddBroadcastFolder, btClearBroadcast }
                    }
                }
            }
        };
        tabView.AddTab("Broadcast", broadcastContent);

        // Ad samples tab
        var adSamplesContent = new Border
        {
            Stroke = Color.FromArgb("#E0E0E0"),
            StrokeThickness = 1,
            Padding = 10,
            Content = new VerticalStackLayout
            {
                Spacing = 10,
                Children =
                {
                    new ScrollView
                    {
                        HeightRequest = 390,
                        BackgroundColor = Colors.LightGray,
                        VerticalOptions = LayoutOptions.Fill,
                        Content = lbAdFolders
                    },
                    new HorizontalStackLayout
                    {
                        Spacing = 5,
                        Children = { btAddAdFile, btAddAdFolder, btClearAds }
                    }
                }
            }
        };
        tabView.AddTab("Ad samples", adSamplesContent);

        // Settings tab
        var settingsContent = new Border
        {
            BackgroundColor = Colors.LightGray,
            Stroke = Color.FromArgb("#E0E0E0"),
            StrokeThickness = 1,
            Padding = 10,
            Content = new VerticalStackLayout
            {
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Difference level", TextColor = Colors.Black },
                    new HorizontalStackLayout
                    {
                        Spacing = 10,
                        Children = { slDifference, lbDifference }
                    },
                    new HorizontalStackLayout
                    {
                        Spacing = 5,
                        Children = 
                        { 
                            cbDebug, 
                            new Label { Text = "Save logs to Documents\\VisioForge\\MMT folder", VerticalOptions = LayoutOptions.Center, TextColor = Colors.Black }
                        }
                    }
                }
            }
        };
        tabView.AddTab("Settings", settingsContent);

        // Ignored areas tab
        var ignoredAreasGrid = new Grid
        {
            RowDefinitions = 
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { Height = GridLength.Auto }
            },
            ColumnDefinitions = 
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = 100 },
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = 100 }
            }
        };
        
        ignoredAreasGrid.Add(new Label { Text = "Left", VerticalOptions = LayoutOptions.Center, TextColor = Colors.Black }, 0, 0);
        ignoredAreasGrid.Add(edIgnoredAreaLeft, 1, 0);
        ignoredAreasGrid.Add(new Label { Text = "Right", VerticalOptions = LayoutOptions.Center, TextColor = Colors.Black }, 2, 0);
        ignoredAreasGrid.Add(edIgnoredAreaRight, 3, 0);
        ignoredAreasGrid.Add(new Label { Text = "Top", VerticalOptions = LayoutOptions.Center, TextColor = Colors.Black }, 0, 1);
        ignoredAreasGrid.Add(edIgnoredAreaTop, 1, 1);
        ignoredAreasGrid.Add(new Label { Text = "Bottom", VerticalOptions = LayoutOptions.Center, TextColor = Colors.Black }, 2, 1);
        ignoredAreasGrid.Add(edIgnoredAreaBottom, 3, 1);

        var ignoredAreasContent = new Border
        {
            BackgroundColor = Colors.LightGray,
            Stroke = Color.FromArgb("#E0E0E0"),
            StrokeThickness = 1,
            Padding = 10,
            Content = new VerticalStackLayout
            {
                Spacing = 10,
                Children =
                {
                    new Label { Text = "Ignored areas (you should add areas before adding ad samples).", TextColor = Colors.Black },
                    new Label { Text = "Regenerate fingerprint files if ignored areas changed.", TextColor = Colors.Black },
                    ignoredAreasGrid,
                    btIgnoredAreaAdd,
                    new ScrollView
                    {
                        HeightRequest = 100,
                        VerticalOptions = LayoutOptions.Fill,
                        BackgroundColor = Colors.White,
                        Content = lbIgnoredAreas
                    },
                    new HorizontalStackLayout
                    {
                        Spacing = 5,
                        Children = { btIgnoredAreasRemoveItem, btIgnoredAreasRemoveAll }
                    }
                }
            }
        };
        tabView.AddTab("Ignored areas", ignoredAreasContent);

        // DB tab
        var dbContent = new Border
        {
            BackgroundColor = Colors.LightGray,
            Stroke = Color.FromArgb("#E0E0E0"),
            StrokeThickness = 1,
            Padding = 10,
            Content = new VerticalStackLayout
            {
                Spacing = 10,
                Children =
                {
                    lbDBLocation,
                    new ScrollView
                    {
                        HeightRequest = 200,
                        VerticalOptions = LayoutOptions.Fill,
                        BackgroundColor = Colors.White,
                        Content = lbDB
                    },
                    btDBClear
                }
            }
        };
        tabView.AddTab("DB", dbContent);
    }

    private void MainPage_Unloaded(object? sender, EventArgs e)
    {
        // Destroy SDK
        VisioForgeX.DestroySDK();
    }

    private async void btAddBroadcastFolder_Click(object sender, EventArgs e)
    {
        if (_folderPicker == null)
        {
            // Fallback to file picker if folder picker is not available
            await DisplayAlert("Select Folder", "Please select any file in the folder you want to add. The folder will be added.", "OK");
            
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                var folderPath = Path.GetDirectoryName(result.FullPath);
                if (!string.IsNullOrEmpty(folderPath))
                {
                    broadcastFolders.Add(folderPath);
                    Settings.LastPath = folderPath;
                    
                    // Add label directly to the UI
                    var label = new Label 
                    { 
                        Text = folderPath,
                        TextColor = Colors.Black,
                        Padding = new Thickness(5),
                        GestureRecognizers = { new TapGestureRecognizer() }
                    };
                    lbBroadcastFolders.Children.Add(label);
                }
            }
        }
        else
        {
            // Use the proper folder picker
            var folderPath = await _folderPicker.PickFolderAsync("Select Broadcast Folder", Settings.LastPath);
            if (!string.IsNullOrEmpty(folderPath))
            {
                broadcastFolders.Add(folderPath);
                Settings.LastPath = folderPath;
                
                // Add label directly to the UI
                var label = new Label 
                { 
                    Text = folderPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbBroadcastFolders.Children.Add(label);
            }
        }
    }

    private async void btAddBroadcastFile_Click(object sender, EventArgs e)
    {
        try
        {
#if MACCATALYST
            // Workaround for Mac Catalyst file picker hanging issue
            // Use single file picker
            var options = new PickOptions
            {
                PickerTitle = "Select video file",
                FileTypes = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.macOS, new[] { "mp4", "mov", "avi", "mkv", "m4v", "wmv", "flv", "webm", "mpg", "mpeg" } },
                        { DevicePlatform.MacCatalyst, new[] { "public.movie", "public.video", "public.mpeg-4" } }
                    })
            };
            
            // Use MainThread.InvokeOnMainThreadAsync to ensure proper thread handling
            var file = await MainThread.InvokeOnMainThreadAsync(async () => 
                await FilePicker.Default.PickAsync(options));
            
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
                
                Settings.LastPath = Path.GetDirectoryName(result.FullPath);
            }
#endif
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to select files: {ex.Message}", "OK");
        }
    }

    private async void btAddAdFolder_Click(object sender, EventArgs e)
    {
        if (_folderPicker == null)
        {
            // Fallback to file picker if folder picker is not available
            await DisplayAlert("Select Folder", "Please select any file in the folder you want to add. The folder will be added.", "OK");
            
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                var folderPath = Path.GetDirectoryName(result.FullPath);
                if (!string.IsNullOrEmpty(folderPath))
                {
                    adFolders.Add(folderPath);
                    Settings.LastPath = folderPath;
                    
                    // Add label directly to the UI
                    var label = new Label 
                    { 
                        Text = folderPath,
                        TextColor = Colors.Black,
                        Padding = new Thickness(5),
                        GestureRecognizers = { new TapGestureRecognizer() }
                    };
                    lbAdFolders.Children.Add(label);
                }
            }
        }
        else
        {
            // Use the proper folder picker
            var folderPath = await _folderPicker.PickFolderAsync("Select Ad Folder", Settings.LastPath);
            if (!string.IsNullOrEmpty(folderPath))
            {
                adFolders.Add(folderPath);
                Settings.LastPath = folderPath;
                
                // Add label directly to the UI
                var label = new Label 
                { 
                    Text = folderPath,
                    TextColor = Colors.Black,
                    Padding = new Thickness(5),
                    GestureRecognizers = { new TapGestureRecognizer() }
                };
                lbAdFolders.Children.Add(label);
            }
        }
    }

    private async void btAddAdFile_Click(object sender, EventArgs e)
    {
        try
        {
#if MACCATALYST
            // Workaround for Mac Catalyst file picker hanging issue
            // Use single file picker
            var options = new PickOptions
            {
                PickerTitle = "Select ad video file",
                FileTypes = new FilePickerFileType(
                    new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.macOS, new[] { "mp4", "mov", "avi", "mkv", "m4v", "wmv", "flv", "webm", "mpg", "mpeg" } },
                        { DevicePlatform.MacCatalyst, new[] { "public.movie", "public.video", "public.mpeg-4" } }
                    })
            };
            
            // Use MainThread.InvokeOnMainThreadAsync to ensure proper thread handling
            var file = await MainThread.InvokeOnMainThreadAsync(async () => 
                await FilePicker.Default.PickAsync(options));
            
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
                
                Settings.LastPath = Path.GetDirectoryName(result.FullPath);
            }
#endif
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to select files: {ex.Message}", "OK");
        }
    }

    private void btClearAds_Click(object sender, EventArgs e)
    {
        adFolders.Clear();
        lbAdFolders.Children.Clear();
    }

    private void btClearBroadcast_Click(object sender, EventArgs e)
    {
        broadcastFolders.Clear();
        lbBroadcastFolders.Children.Clear();
    }

    private async void errorDelegate(string error)
    {
        await DisplayAlert("Error", error, "OK");
    }

    private async void btStart_Click(object sender, EventArgs e)
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
            pbProgress.Progress = progress / 100.0;

            var source = new VFPFingerprintSource(filename);
            foreach (var area in _ignoredAreas)
            {
                source.IgnoredAreas.Add(area);
            }

            VFPFingerPrint fp = _db.GetFingerprint(source);

            if (fp == null)
            {
                fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);

                if (fp == null)
                {
                    await DisplayAlert("Error", "Unable to get fingerprint for the video file: " + filename, "OK");
                }
                else
                {
                    _db.Items.Add(fp);
                    AddDBItem(fp);
                }
            }

            adVFPList.Add(fp);

            progress += 100 / adList.Count;
        }

        pbProgress.Progress = 1.0;

        lbStatus.Text = "Step 3: Getting fingerprints for broadcast files";
        progress = 0;
        foreach (string filename in broadcastList)
        {
            pbProgress.Progress = progress / 100.0;

            var source = new VFPFingerprintSource(filename);
            foreach (var area in _ignoredAreas)
            {
                source.IgnoredAreas.Add(area);
            }

            VFPFingerPrint fp = _db.GetFingerprint(source);
            if (fp == null)
            {
                fp = await VFPAnalyzer.GetSearchFingerprintForVideoFileAsync(source, errorDelegate);
                if (fp == null)
                {
                    await DisplayAlert("Error", "Unable to get fingerprint for the video file: " + filename, "OK");
                    return;
                }
                else
                {
                    _db.Items.Add(fp);
                    AddDBItem(fp);
                }
            }

            broadcastVFPList.Add(fp);

            progress += 100 / broadcastList.Count;
        }

        pbProgress.Progress = 1.0;

        lbStatus.Text = "Step 4: Analyzing data";
        progress = 0;
        int foundCount = 0;
        foreach (var broadcast in broadcastVFPList)
        {
            pbProgress.Progress = progress / 100.0;

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

        pbProgress.Progress = 0;

        lbStatus.Text = "Step 5: Done. " + foundCount + " ads found.";

        btStart.IsEnabled = true;
    }

    private async void btPlay_Click(object sender, EventArgs e)
    {
        if (lvResults.SelectedItem == null)
        {
            return;
        }

        // VideoView playback requires MediaBlocks pipeline setup
        // For simplicity, just show the file path for now
        var selected = (ResultsViewModel)lvResults.SelectedItem;
        await DisplayAlert("Play Video", $"Selected file: {selected.DumpFile}", "OK");
        
        // TODO: Implement MediaBlocks pipeline for video playback
        // Requires: UniversalSourceBlock, VideoRendererBlock, AudioRendererBlock
    }

    private async void btSaveResults_Click(object sender, EventArgs e)
    {
        try
        {
            if (results.Count == 0)
            {
                await DisplayAlert("Info", "No results to save", "OK");
                return;
            }

            string filename = null;

            // Try to use the native file saver first
            if (_fileSaver != null)
            {
                var fileTypes = new Dictionary<string, List<string>>
                {
                    { "CSV Files", new List<string> { ".csv" } },
                    { "XML Files", new List<string> { ".xml" } }
                };

                filename = await _fileSaver.SaveFileAsync("results", fileTypes);
            }
            else
            {
                // Fallback to file picker if native saver is not available
                var options = new PickOptions
                {
                    PickerTitle = "Save results file"
                };

                var fileTypes = new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".csv", ".xml" } },
                    { DevicePlatform.macOS, new[] { "csv", "xml" } }
                };

                options.FileTypes = new FilePickerFileType(fileTypes);

                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    filename = result.FullPath;
                }
            }

            if (!string.IsNullOrEmpty(filename))
            {
                // Ensure the file has an extension
                if (!Path.HasExtension(filename))
                {
                    filename += ".csv";
                }

                if (Path.GetExtension(filename.ToLowerInvariant()) == ".xml")
                {
                    await DisplayAlert("Info", "XML export not implemented in MAUI version", "OK");
                }
                else
                {
                    // Save as CSV
                    results.ToList().SerializeToCsv(filename, ',');
                    await DisplayAlert("Success", $"Results saved to {filename}", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void slDifference_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (lbDifference != null)
        {
            lbDifference.Text = ((int)e.NewValue).ToString();
        }
    }

    private void btIgnoredAreaAdd_Click(object sender, EventArgs e)
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

    private void btIgnoredAreasRemoveItem_Click(object sender, EventArgs e)
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

    private void btIgnoredAreasRemoveAll_Click(object sender, EventArgs e)
    {
        ignoredAreasList.Clear();
        _ignoredAreas.Clear();
        lbIgnoredAreas.Children.Clear();
    }

    private void btDBClear_Click(object sender, EventArgs e)
    {
        _db.Items.Clear();
        dbItems.Clear();
        lbDB.Children.Clear();
    }

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

    private void SaveDB()
    {
        var dbFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mmt.db");
        _db.Save(dbFile);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        SaveDB();
    }
}