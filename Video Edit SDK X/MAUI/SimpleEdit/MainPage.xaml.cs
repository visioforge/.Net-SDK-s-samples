using System;
using System.Collections.Generic;
using System.IO;

using VisioForge.Core;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.VideoEditX;

namespace Simple_Edit_MAUI
{
    /// <summary>
    /// Joins the clips picked from the device gallery into a single MP4 using the X-engine
    /// video editor. The same VideoEditCoreX code runs on Android, iOS, MacCatalyst and Windows.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        private VideoEditCoreX _core;

        private readonly List<string> _clips = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;
            Unloaded += MainPage_Unloaded;

            // The engine only exists once MainPage_Loaded has awaited InitSDKAsync, which on a
            // cold start spends hundreds of milliseconds building the GStreamer registry. Keep
            // the controls dead until then so a tap in that window cannot reach a null _core.
            pnMain.IsEnabled = false;
        }

        /// <summary>
        /// Main page loaded. Initializes the SDK and creates the editing engine.
        /// </summary>
        private async void MainPage_Loaded(object sender, EventArgs e)
        {
            try
            {
                // Load the native GStreamer stack before touching any X-engine type.
                // Without it the first VideoEditCoreX call throws DllNotFoundException.
                await VisioForgeX.InitSDKAsync();

                IVideoView vv = videoView.GetVideoView();

                _core = new VideoEditCoreX(vv);

                _core.OnError += Core_OnError;
                _core.OnProgress += Core_OnProgress;
                _core.OnStop += Core_OnStop;

                lbStatus.Text = $"SDK v{VideoEditCoreX.SDK_Version}";
                pnMain.IsEnabled = true;
            }
            catch (Exception ex)
            {
                // Leave the controls disabled - without an engine none of them can do anything.
                lbStatus.Text = $"SDK init failed: {ex.Message}";
            }
        }

        /// <summary>
        /// Main page unloaded. Releases the engine and the SDK.
        /// </summary>
        private void MainPage_Unloaded(object sender, EventArgs e)
        {
            if (_core != null)
            {
                _core.OnError -= Core_OnError;
                _core.OnProgress -= Core_OnProgress;
                _core.OnStop -= Core_OnStop;

                _core.Stop();
                _core.Dispose();
                _core = null;
            }

            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Picks a video from the device gallery and appends it to the timeline.
        /// </summary>
        private async void btAdd_Clicked(object sender, EventArgs e)
        {
            try
            {
                var picked = await MediaPicker.Default.PickVideoAsync();
                if (picked == null)
                {
                    return;
                }

                var filename = await ResolveLocalPathAsync(picked);

                // Append to the end of the timeline - no insert time means "after the last clip".
                _core.Input_AddAudioVideoFile(filename);

                _clips.Add(filename);
                lbFiles.Text = $"{_clips.Count} clip(s): " + string.Join(", ", _clips.ConvertAll(Path.GetFileName));
            }
            catch (Exception ex)
            {
                // PickVideoAsync throws when the media permission is denied or no gallery app
                // is present, and the cache copy can fail on a full disk.
                lbStatus.Text = $"Could not add the clip: {ex.Message}";
            }
        }

        /// <summary>
        /// Empties the timeline.
        /// </summary>
        private void btClear_Clicked(object sender, EventArgs e)
        {
            _core.Stop();
            _core.Input_Clear_List();

            _clips.Clear();
            lbFiles.Text = "No clips added.";
            pbProgress.Progress = 0;
            lbStatus.Text = string.Empty;
        }

        /// <summary>
        /// Plays the timeline into the VideoView without writing a file.
        /// </summary>
        private void btPreview_Clicked(object sender, EventArgs e)
        {
            if (_clips.Count == 0)
            {
                lbStatus.Text = "Add at least one clip first.";
                return;
            }

            // A null output format is what puts the engine in preview mode.
            _core.Output_Format = null;
            _core.Start();

            lbStatus.Text = "Preview...";
        }

        /// <summary>
        /// Renders the timeline to an MP4 file in the app data directory.
        /// </summary>
        private void btRender_Clicked(object sender, EventArgs e)
        {
            if (_clips.Count == 0)
            {
                lbStatus.Text = "Add at least one clip first.";
                return;
            }

            var output = Path.Combine(FileSystem.Current.AppDataDirectory, $"joined_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");

            // H264EncoderBlock.GetDefaultSettings() prefers a hardware encoder and falls back
            // to software: VideoToolbox on Apple, MediaCodec on Android, NVENC/AMF/QSV on
            // Windows. MP4Output's own default only consults it on Android and hands every
            // other platform OpenH264, so passing it here is what keeps iOS and Windows on
            // hardware. Audio is left to MP4Output: AAC on Windows, MP3 elsewhere.
            _core.Output_Format = new MP4Output(output, H264EncoderBlock.GetDefaultSettings());
            _core.Start();

            lbStatus.Text = $"Rendering to {output}";
        }

        /// <summary>
        /// Stops the running preview or render.
        /// </summary>
        private void btStop_Clicked(object sender, EventArgs e)
        {
            _core.Stop();
            pbProgress.Progress = 0;
        }

        /// <summary>
        /// The engine reports errors on a background thread.
        /// </summary>
        private void Core_OnError(object sender, ErrorsEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => lbStatus.Text = e.Message);
        }

        /// <summary>
        /// Render progress, 0-100.
        /// </summary>
        private void Core_OnProgress(object sender, ProgressEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => pbProgress.Progress = e.Progress / 100.0);
        }

        /// <summary>
        /// Preview or render finished.
        /// </summary>
        private void Core_OnStop(object sender, StopEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                pbProgress.Progress = 0;
                lbStatus.Text = e.Successful ? "Completed successfully." : "Stopped with error.";
            });
        }

        /// <summary>
        /// Turns a picker result into a path the engine can open.
        /// </summary>
        /// <remarks>
        /// Android: MediaPicker already copies the asset into a cache path, so FullPath is
        /// absolute and usable as is. iOS: PHPicker hands MAUI an NSItemProvider and only the
        /// original filename survives in FullPath, so the stream has to be copied into our own
        /// cache to get a real filesystem path.
        /// </remarks>
        private static async Task<string> ResolveLocalPathAsync(FileResult picked)
        {
            if (Path.IsPathRooted(picked.FullPath) && File.Exists(picked.FullPath))
            {
                return picked.FullPath;
            }

            // Strip any separators the picker may have kept from the source asset path, then
            // prefix a GUID so picking the same clip twice does not overwrite a file the engine
            // may still be reading.
            var leaf = Path.GetFileName(picked.FileName ?? "clip");
            if (string.IsNullOrEmpty(leaf))
            {
                leaf = "clip";
            }

            var safeName = $"{Path.GetFileNameWithoutExtension(leaf)}_{Guid.NewGuid():N}{Path.GetExtension(leaf)}";
            var cachePath = Path.Combine(FileSystem.Current.CacheDirectory, safeName);

            using (var src = await picked.OpenReadAsync())
            using (var dst = File.Create(cachePath))
            {
                await src.CopyToAsync(dst);
            }

            return cachePath;
        }
    }
}
