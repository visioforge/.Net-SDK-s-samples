using System;
using System.Linq;
using System.Windows;

using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types;
using VisioForge.Core.UI.WPF.Dialogs.Sources;

using Rect = VisioForge.Core.Types.Rect;

using VisioForge.Core.LiveVideoCompositorV2;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.VideoEncoders;
using System.IO;
using System.Windows.Controls;
using System.Threading.Tasks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core;
using Microsoft.Win32;
using VisioForge.Core.MediaBlocks.Decklink;
using VisioForge.Core.UI.WPF.Dialogs.Decklink;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X;
using VisioForge.Core.Helpers;
using VisioForge.Core.GStreamer;

namespace Live_Video_Compositor_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiveVideoCompositor _compositor;

        private LVCVideoViewOutput _videoRendererOutput;

        private LVCAudioOutput _audioRendererOutput;

        private int _videoWidth;

        private int _videoHeight;

        private VideoFrameRate _videoFrameRate;

        private LVCMixerType _mixerType;

        private System.Timers.Timer tmRecording = new System.Timers.Timer(1000);

        public MainWindow()
        {
            InitializeComponent();            
        }
                
        /// <summary>
        /// Compositor on error.
        /// </summary>
        private void Compositor_OnError(object sender, ErrorsEventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        /// <summary>
        /// Create engine.
        /// </summary>
        private void CreateEngine()
        {
            var settings =
                new LiveVideoCompositorSettings(_videoWidth, _videoHeight, _videoFrameRate);
            settings.MixerType = _mixerType;
            settings.AudioEnabled = true;

            _compositor = new LiveVideoCompositor(settings);
            _compositor.OnError += Compositor_OnError;
        }

        /// <summary>
        /// Destroy engine.
        /// </summary>
        private void DestroyEngine()
        {
            if (_compositor != null)
            {
                _compositor.OnError -= Compositor_OnError;

                _compositor.Dispose();
                _compositor = null;
            }
        }

        /// <summary>
        /// Add camera source async.
        /// </summary>
        private async Task AddCameraSourceAsync()
        {
            var dlg = new VideoCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                VideoCaptureDeviceSourceSettings settings = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.VideoSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            settings = new VideoCaptureDeviceSourceSettings(device)
                            {
                                Format = formatItem.ToFormat()
                            };

                            settings.Format.FrameRate = dlg.FrameRate;
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure video capture device.");
                    return;
                }

                var name = $"Camera [{dlg.Device}]";
                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var videoInfo = new VideoFrameInfoX(settings.Format.Width, settings.Format.Height, settings.Format.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new SystemVideoSourceBlock(settings), videoInfo, rect, true);
                src.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        /// <summary>
        /// Add file source async.
        /// </summary>
        private async Task AddFileSourceAsync()
        {
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == true)
            {
                var filename = dlg.FileName;
                var name = $"File [{filename}]";
                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var settings = await UniversalSourceSettings.CreateAsync(filename);
                var src = new LVCVideoAudioInput(name, _compositor, new UniversalSourceBlock(settings), settings.GetInfo().GetVideoInfo(), settings.GetInfo().GetAudioInfo(), rect, autostart: true, live: false);
                src.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        /// <summary>
        /// Add screen source async.
        /// </summary>
        private async Task AddScreenSourceAsync()
        {
            var dlg = new ScreenSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                var settings = new ScreenCaptureDX9SourceSettings();
                settings.CaptureCursor = dlg.GrabMouseCursor;
                settings.Monitor = dlg.DisplayIndex;
                settings.FrameRate = dlg.FrameRate;
                settings.Rectangle = dlg.Rectangle;

                var rect = new Rect(Convert.ToInt32(edRectLeft.Text), Convert.ToInt32(edRectTop.Text), Convert.ToInt32(edRectRight.Text), Convert.ToInt32(edRectBottom.Text));
                var name = $"Screen [{dlg.DisplayIndex}] {dlg.Rectangle.Width}x{dlg.Rectangle.Height}";
                var info = new VideoFrameInfoX(dlg.Rectangle.Width, dlg.Rectangle.Height, dlg.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new ScreenSourceBlock(settings), info, rect, true);
                src.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                { 
                    src.Dispose(); 
                }
            }
        }

        /// <summary>
        /// Window loaded.
        /// </summary>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var resDialog = new ResolutionDialog();
            resDialog.Owner = this;
            resDialog.ShowDialog();

            _videoWidth = resDialog.GetWidth();
            _videoHeight = resDialog.GetHeight();
            _videoFrameRate = resDialog.GetFrameRate();
            _mixerType = resDialog.GetMixerType();

            lbResolution.Content = $"Video: {_videoWidth}x{_videoHeight}@{_videoFrameRate}fps";

            // We have to initialize the engine on start
            Title += "[FIRST TIME LOAD, BUILDING THE REGISTRY...]";
            this.IsEnabled = false;
            await VisioForgeX.InitSDKAsync();
            this.IsEnabled = true;
            Title = Title.Replace("[FIRST TIME LOAD, BUILDING THE REGISTRY...]", "");

            CreateEngine();

            Title += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            tmRecording.Elapsed += (senderx, args) => { UpdateRecordingTime(); };

            DeviceEnumerator.Shared.OnAudioSinkAdded += Shared_OnAudioSinkAdded;
            await DeviceEnumerator.Shared.StartAudioSinkMonitorAsync();

            VideoView1.SetNativeRendering(true);
        }

        /// <summary>
        /// Shared on audio sink added.
        /// </summary>
        private void Shared_OnAudioSinkAdded(object sender, AudioOutputDeviceInfo e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                if (e.API == AudioOutputDeviceAPI.DirectSound)
                {
                    cbAudioRenderer.Items.Add(e.Name);
                }

                cbAudioRenderer.SelectedIndex = 0;
            }));
        }

        /// <summary>
        /// Update recording time.
        /// </summary>
        private async void UpdateRecordingTime()
        {
            var ts = await _compositor.DurationAsync();

            if (Math.Abs(ts.TotalMilliseconds) < 0.01)
            {
                return;
            }

            Dispatcher.BeginInvoke((Action)(() =>
            {
                lbTimestamp.Content = ts.ToString(@"hh\:mm\:ss");
            }));
        }

        /// <summary>
        /// Handles the bt start click event.
        /// </summary>
        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            _compositor.Settings.VideoView = VideoView1;
            _compositor.Settings.AudioOutput = new AudioRendererBlock(
                (await DeviceEnumerator.Shared.AudioOutputsAsync(AudioOutputDeviceAPI.DirectSound)).First(x => x.Name == cbAudioRenderer.Text));


            await _compositor.StartAsync();

            tmRecording.Start();
        }

        /// <summary>
        /// Handles the bt stop click event.
        /// </summary>
        private async void btStop_Click(object sender, RoutedEventArgs e)
        {
            tmRecording.Stop();

            await _compositor.StopAsync();
            
            DestroyEngine();
            CreateEngine();

            lbOutputs.Items.Clear();
            lbSources.Items.Clear();
        }

        /// <summary>
        /// Handles the bt update source click event.
        /// </summary>
        private void btUpdateSource_Click(object sender, RoutedEventArgs e)
        {
            int index = lbSources.SelectedIndex;
            if (index != -1)
            {
                var rect = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                var zOrder = Convert.ToUInt32(edZOrder.Text);

                var input = _compositor.Input_Get(index);
                if (input == null)
                {
                    return;
                }

                // Update rectangles
                if (input is LVCVideoAudioInput vai)
                {
                    vai.Rectangle = rect;
                }
                else if (input is LVCVideoInput vi)
                {
                    vi.Rectangle = rect;
                }

                // Update live stream if available
                var stream = _compositor.Input_VideoStream_Get(input);
                if (stream != null)
                {
                    // we have playback started and can change the rect
                    stream.Rectangle = rect;
                    stream.ZOrder = zOrder;
                    _compositor.Input_VideoStream_Update(stream);
                }
            }
        }

        /// <summary>
        /// Add mp 4 output async.
        /// </summary>
        private async Task AddMP4OutputAsync()
        {
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp4";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp4Output = new MP4OutputBlock(new MP4SinkSettings(outputFile), new OpenH264EncoderSettings(), new MFAACEncoderSettings());

            var output = new LVCVideoAudioOutput(outputFile, _compositor, mp4Output, autostart: true);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add decklink video output async.
        /// </summary>
        private async Task AddDecklinkVideoOutputAsync()
        {
            // Decklink video output
            var dlg = new DecklinkVideoOutputDialog();
            if (dlg.ShowDialog() == true)
            {
                var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

               DecklinkVideoAudioSinkBlock _decklinkOutputBlock;

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                var name = $"Decklink Out V{dlg.VideoDevice}:A{dlg.AudioDevice}";

                _decklinkOutputBlock = new DecklinkVideoAudioSinkBlock(videoSettings, audioSettings);

                var decklinkOutput = new LVCVideoAudioOutput(name, _compositor, _decklinkOutputBlock, autostart: true);


                if (await _compositor.Output_AddAsync(decklinkOutput))
                {
                    lbOutputs.Items.Add(name);
                    lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
                }
                else
                {
                    decklinkOutput.Dispose();
                }
            }
        }

        /// <summary>
        /// Add web m output async.
        /// </summary>
        private async Task AddWebMOutputAsync()
        {
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.webm";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var webmOutput = new WebMOutputBlock(new WebMSinkSettings(outputFile), new VP8EncoderSettings(), new VorbisEncoderSettings());
            var output = new LVCVideoAudioOutput(outputFile, _compositor, webmOutput, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add mp 3 output async.
        /// </summary>
        private async Task AddMP3OutputAsync()
        {
            var now = System.DateTime.Now;
            var name = $"output_{now.Year}_{now.Month}_{now.Day}_{now.Hour}_{now.Minute}_{now.Second}.mp3";
            var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), name);
            var mp3Output = new MP3OutputBlock(outputFile, new MP3EncoderSettings());
            var output = new LVCAudioOutput(outputFile, _compositor, mp3Output, false);

            if (await _compositor.Output_AddAsync(output))
            {
                lbOutputs.Items.Add(outputFile);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
            else
            {
                output.Dispose();
            }
        }

        /// <summary>
        /// Add audio source async.
        /// </summary>
        private async Task AddAudioSourceAsync()
        {
            var dlg = new AudioCaptureSourceDialog();
            if (dlg.ShowDialog() == true)
            {
                IAudioCaptureDeviceSourceSettings settings = null;
                AudioCaptureDeviceFormat deviceFormat = null;

                var deviceName = dlg.Device;
                var format = dlg.Format;
                if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
                {
                    var device = (await DeviceEnumerator.Shared.AudioSourcesAsync()).FirstOrDefault(x => x.DisplayName == deviceName);
                    if (device != null)
                    {
                        var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                        if (formatItem != null)
                        {
                            deviceFormat = formatItem.ToFormat();
                            settings = device.CreateSourceSettings(deviceFormat);
                        }
                    }
                }

                if (settings == null)
                {
                    MessageBox.Show(this, "Unable to configure audio capture device.");
                    return;
                }

                var name = $"Audio source [{dlg.Device}]";
                var info = new AudioInfoX(deviceFormat.Format, deviceFormat.SampleRate, deviceFormat.Channels);
                var src = new LVCAudioInput(name, _compositor, new SystemAudioSourceBlock(settings), info, true);
                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        /// <summary>
        /// Add audio virtual async.
        /// </summary>
        private async Task AddAudioVirtualAsync()
        {
            var name = "Audio source [Virtual]";
            var settings = new VirtualAudioSourceSettings();
            var info = new AudioInfoX(settings.Format, settings.SampleRate, settings.Channels);
            var src = new LVCAudioInput(name, _compositor, new VirtualAudioSourceBlock(settings), info, true);            
            if (await _compositor.Input_AddAsync(src))
            {
                lbSources.Items.Add(name);
                lbSources.SelectedIndex = lbSources.Items.Count - 1;
            }
            else
            {
                src.Dispose();
            }
        }

        /// <summary>
        /// Add video virtual async.
        /// </summary>
        private async Task AddVideoVirtualAsync()
        {
            var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

            var name = $"Video source [Virtual] {_compositor.Input_Count()}";
            var settings = new VirtualVideoSourceSettings();
            var info = new VideoFrameInfoX(settings.Width, settings.Height, settings.FrameRate);
            var src = new LVCVideoInput(name, _compositor, new VirtualVideoSourceBlock(settings), info, rect, true);   
            src.ZOrder = (uint)_compositor.Input_Count();

            if (await _compositor.Input_AddAsync(src))
            {
                lbSources.Items.Add(name);
                lbSources.SelectedIndex = lbSources.Items.Count - 1;
            }
            else
            {
                src.Dispose();
            }
        }

        /// <summary>
        /// Add video static image async.
        /// </summary>
        private async Task AddVideoStaticImageAsync()
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (dlg.ShowDialog(this) == true)
            {
                var rect = new Rect(
                  Convert.ToInt32(edRectLeft.Text),
                  Convert.ToInt32(edRectTop.Text),
                  Convert.ToInt32(edRectRight.Text),
                  Convert.ToInt32(edRectBottom.Text));

                var name = $"Video source [Static image] {_compositor.Input_Count()}";
                var settings = new ImageVideoSourceSettings(dlg.FileName);
                var info = new VideoFrameInfoX(settings.Width, settings.Height, settings.FrameRate);
                var src = new LVCVideoInput(name, _compositor, new ImageVideoSourceBlock(settings), info, rect, true);
                src.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(src))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    src.Dispose();
                }
            }
        }

        /// <summary>
        /// Add decklink video source async.
        /// </summary>
        private async Task AddDecklinkVideoSourceAsync()
        {
            // Decklink video source
            var dlg = new DecklinkVideoSourceDialog();
            if (dlg.ShowDialog() == true)
            {               
                var rect = new Rect(
                   Convert.ToInt32(edRectLeft.Text),
                   Convert.ToInt32(edRectTop.Text),
                   Convert.ToInt32(edRectRight.Text),
                   Convert.ToInt32(edRectBottom.Text));

                var videoSettings = await dlg.GetVideoDeviceSettingsAsync();
                videoSettings.DisableVideoConversion = true;

                var audioSettings = await dlg.GetAudioDeviceSettingsAsync();
                audioSettings.DisableAudioConversion = true;

                var name = $"Decklink source [{videoSettings.DeviceNumber}]";

                var sourceBlock = new DecklinkVideoAudioSourceBlock(videoSettings, audioSettings);

                DecklinkHelper.GetVideoInfoFromMode(videoSettings.Mode, out int width, out int height, out VideoFrameRate frameRate);
                var videoInfo = new VideoFrameInfoX(width, height, frameRate);
                var audioInfo = new AudioInfoX(DecklinkHelper.ToFormat(audioSettings.Format), audioSettings.SampleRate, (int)audioSettings.Channels);
                var videoSrc = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, true);
                videoSrc.ZOrder = (uint)_compositor.Input_Count();

                if (await _compositor.Input_AddAsync(videoSrc))
                {
                    lbSources.Items.Add(name);
                    lbSources.SelectedIndex = lbSources.Items.Count - 1;
                }
                else
                {
                    videoSrc.Dispose();
                }
            }
        }

        /// <summary>
        /// Add ndi source async.
        /// </summary>
        private async Task AddNDISourceAsync()
        {
            var dlg = new NDISourceDialog();
            dlg.Owner = this;
            if (dlg.ShowDialog() == true && dlg.SelectedSource != null)
            {
                var rect = new Rect(
                    Convert.ToInt32(edRectLeft.Text),
                    Convert.ToInt32(edRectTop.Text),
                    Convert.ToInt32(edRectRight.Text),
                    Convert.ToInt32(edRectBottom.Text));

                // Show progress while retrieving NDI source info
                this.IsEnabled = false;
                var originalTitle = this.Title;
                this.Title = $"{originalTitle} - Connecting to NDI source...";

                try
                {
                    // Create a temporary context for NDI source info retrieval
                    var context = new ContextX();
                    var ndiSettings = await NDISourceSettings.CreateAsync(context, dlg.SelectedSource);
                    
                    if (ndiSettings == null || !ndiSettings.IsValid())
                    {
                        MessageBox.Show(this, "Selected NDI source is not valid or not available. Please ensure the NDI source is active and streaming.", "NDI Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                var name = $"NDI [{dlg.SelectedSource.Name}]";
                var sourceBlock = new NDISourceBlock(ndiSettings);
                
                var info = ndiSettings.GetInfo();
                if (info != null && info.VideoStreams.Count > 0)
                {
                    var videoInfo = info.GetVideoInfo();
                    AudioInfoX audioInfo = null;
                    
                    if (info.AudioStreams.Count > 0)
                    {
                        audioInfo = info.GetAudioInfo();
                    }

                    if (audioInfo != null)
                    {
                        var src = new LVCVideoAudioInput(name, _compositor, sourceBlock, videoInfo, audioInfo, rect, autostart: true, live: true);
                        src.ZOrder = (uint)_compositor.Input_Count();
                        
                        if (await _compositor.Input_AddAsync(src))
                        {
                            lbSources.Items.Add(name);
                            lbSources.SelectedIndex = lbSources.Items.Count - 1;
                        }
                        else
                        {
                            src.Dispose();
                        }
                    }
                    else
                    {
                        var src = new LVCVideoInput(name, _compositor, sourceBlock, videoInfo, rect, autostart: true);
                        src.ZOrder = (uint)_compositor.Input_Count();
                        
                        if (await _compositor.Input_AddAsync(src))
                        {
                            lbSources.Items.Add(name);
                            lbSources.SelectedIndex = lbSources.Items.Count - 1;
                        }
                        else
                        {
                            src.Dispose();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(this, "NDI source does not contain video streams.", "NDI Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"Error connecting to NDI source: {ex.Message}", "NDI Source Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    this.IsEnabled = true;
                    this.Title = originalTitle;
                }
            }
        }

        /// <summary>
        /// Handles the bt add source click event.
        /// </summary>
        private void btAddSource_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new ContextMenu();

            var miScreen = new MenuItem() { Header = "Screen source" };
            miScreen.Click += async (senderm, args) =>
            {
                await AddScreenSourceAsync();
            };

            var miCamera = new MenuItem() { Header = "Camera source" };
            miCamera.Click += async (senderm, args) =>
            {
                await AddCameraSourceAsync();
            };

            var miFile = new MenuItem() { Header = "File source" };
            miFile.Click += async (senderm, args) =>
            {
                await AddFileSourceAsync();
            };

            var miAudioSource = new MenuItem() { Header = "Audio source" };
            miAudioSource.Click += async (senderm, args) =>
            {
                await AddAudioSourceAsync();
            };

            var miAudioVirtual = new MenuItem() { Header = "Virtual audio" };
            miAudioVirtual.Click += async (senderm, args) =>
            {
                await AddAudioVirtualAsync();
            };

            var miVideoVirtual = new MenuItem() { Header = "Virtual video" };
            miVideoVirtual.Click += async (senderm, args) =>
            {
                await AddVideoVirtualAsync();
            };

            var miStaticImage = new MenuItem() { Header = "Static image" };
            miStaticImage.Click += async (senderm, args) =>
            {
                await AddVideoStaticImageAsync();
            };

            var miDecklinkSource = new MenuItem() { Header = "Decklink source" };
            miDecklinkSource.Click += async (senderm, args) =>
            {
                await AddDecklinkVideoSourceAsync();
            };

            var miNDISource = new MenuItem() { Header = "NDI source" };
            miNDISource.Click += async (senderm, args) =>
            {
                await AddNDISourceAsync();
            };

            ctx.Items.Add(miScreen);
            ctx.Items.Add(miCamera);
            ctx.Items.Add(miFile);
            ctx.Items.Add(miVideoVirtual);
            ctx.Items.Add(miStaticImage);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miAudioSource);
            ctx.Items.Add(miAudioVirtual);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklinkSource);
            ctx.Items.Add(miNDISource);
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        /// <summary>
        /// Handles the bt remove source click event.
        /// </summary>
        private async void btRemoveSource_Click(object sender, RoutedEventArgs e)
        {
            if (lbSources.SelectedIndex != -1)
            {
                var index = lbSources.SelectedIndex;
                var input = _compositor.Input_Get(index);
                if (input != null)
                {
                    await _compositor.Input_RemoveAsync(input.ID);
                }
                lbSources.Items.RemoveAt(index);
            }
        }

        /// <summary>
        /// Update source selection async.
        /// </summary>
        private async Task UpdateSourceSelectionAsync()
        {
            if (lbSources.SelectedIndex != -1)
            {
                var inputSource = _compositor.Input_Get(lbSources.SelectedIndex);
                var input = _compositor.Input_VideoStream_Get(inputSource);

                bool isVideo = inputSource is LVCVideoAudioInput || inputSource is LVCVideoInput;
                edRectLeft.IsEnabled = edRectTop.IsEnabled = edRectRight.IsEnabled = edRectBottom.IsEnabled = isVideo;

                if (input != null)
                {
                    edRectLeft.Text = input.Rectangle.Left.ToString();
                    edRectTop.Text = input.Rectangle.Top.ToString();
                    edRectRight.Text = input.Rectangle.Right.ToString();
                    edRectBottom.Text = input.Rectangle.Bottom.ToString();
                    edZOrder.Text = input.ZOrder.ToString();
                }

                _timelineSeeking = false;

                if (inputSource != null && inputSource.IsSeekable)
                {
                    var duration = await inputSource.Pipeline.DurationAsync();
                    var position = await inputSource.Pipeline.Position_GetAsync();
                    tbSeeking.IsEnabled = true;
                    tbSeeking.Maximum = duration.TotalSeconds;
                    tbSeeking.Value = position.TotalSeconds;
                }
                else
                {
                    tbSeeking.IsEnabled = false;
                    tbSeeking.Value = 0;
                }

                _timelineSeeking = true;
            }
        }

        /// <summary>
        /// Lb sources selection changed.
        /// </summary>
        private async void lbSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await UpdateSourceSelectionAsync();
        }

        /// <summary>
        /// Lb sources preview mouse left button down.
        /// </summary>
        private async void lbSources_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            await UpdateSourceSelectionAsync();
        }

        /// <summary>
        /// Handles the bt add output click event.
        /// </summary>
        private void btAddOutput_Click(object sender, RoutedEventArgs e)
        {
            var ctx = new ContextMenu();

            var miMP4 = new MenuItem() { Header = "MP4 file" };
            miMP4.Click += async (senderm, args) =>
            {
                await AddMP4OutputAsync();
            };

            var miWebM = new MenuItem() { Header = "WebM file" };
            miWebM.Click += async (senderm, args) =>
            {
                await AddWebMOutputAsync();
            };

            var miMP3 = new MenuItem() { Header = "MP3 file" };
            miMP3.Click += async (senderm, args) =>
            {
                await AddMP3OutputAsync();
            };

            var miDecklink = new MenuItem() { Header = "Decklink device" };
            miDecklink.Click += async (senderm, args) =>
            {
                await AddDecklinkVideoOutputAsync();
            };

            ctx.Items.Add(miMP4);
            ctx.Items.Add(miWebM);
            ctx.Items.Add(miMP3);
            ctx.Items.Add(new Separator());
            ctx.Items.Add(miDecklink);
            ctx.PlacementTarget = sender as Button;
            ctx.IsOpen = true;
        }

        /// <summary>
        /// Handles the bt remove output click event.
        /// </summary>
        private async void btRemoveOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                var index = lbOutputs.SelectedIndex;
                var output = _compositor.Output_Get(index);
                if (output != null)
                {
                    await _compositor.Output_RemoveAsync(output.ID);
                }
                lbOutputs.Items.RemoveAt(index);
                lbOutputs.SelectedIndex = lbOutputs.Items.Count - 1;
            }
        }

        /// <summary>
        /// Window closing.
        /// </summary>
        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_compositor != null)
            {
                await _compositor.DisposeAsync();
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Handles the bt start output click event.
        /// </summary>
        private async void btStartOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                var output = _compositor.Output_Get(lbOutputs.SelectedIndex);
                await output.StartAsync();
            }
        }

        /// <summary>
        /// Handles the bt stop output click event.
        /// </summary>
        private async void btStopOutput_Click(object sender, RoutedEventArgs e)
        {
            if (lbOutputs.SelectedIndex != -1)
            {
                var output = _compositor.Output_Get(lbOutputs.SelectedIndex);
                await output.StopAsync();
            }
        }

        private bool _timelineSeeking = true;

        /// <summary>
        /// Tb seeking value changed.
        /// </summary>
        private async void tbSeeking_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!_timelineSeeking)
            {
                return;
            }

            int index = lbSources.SelectedIndex;
            if (index != -1)
            {
                var fileInput = _compositor.Input_VideoAudio_Get(index);
                if (fileInput == null)
                {
                    return;
                }

                await fileInput?.Pipeline?.Position_SetAsync(TimeSpan.FromSeconds(e.NewValue));
            }
        }
    }
}
