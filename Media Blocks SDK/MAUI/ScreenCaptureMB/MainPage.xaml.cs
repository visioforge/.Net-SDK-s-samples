using System.Diagnostics;
using System.Globalization;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.X.Sinks;

namespace ScreenCaptureMB
{
    public partial class MainPage : ContentPage
    {
        private MediaBlocksPipeline _pipeline;

        private ScreenSourceBlock _source;

        private VideoRendererBlock _videoRenderer;

        private TeeBlock _videoTee;

        private MP4SinkBlock _mp4Sink;

        private H264EncoderBlock _h264Encoder;

        /// <summary>
        /// The position timer.
        /// </summary>
        private System.Timers.Timer _tmPosition = new System.Timers.Timer(500);

        public MainPage()
        {
            InitializeComponent();

            Loaded += MainPage_Loaded;

            _tmPosition.Elapsed += tmPosition_Elapsed;
        }

        private string GenerateFilename()
        {
            DateTime now = DateTime.Now;
#if __ANDROID__
            var filename =
 Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath, $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __IOS__ && !__MACCATALYST__
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#elif __MACCATALYST__
            var filename = Path.Combine("/tmp", $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#else
            var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), $"{now.Hour}_{now.Minute}_{now.Second}.mp4");
#endif

            return filename;
        }

        private async Task CreateEngineAsync()
        {
            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
                await _pipeline.DisposeAsync();
            }

            _pipeline = new MediaBlocksPipeline();

            _pipeline.OnError += _player_OnError;

            _source = new ScreenSourceBlock();
            _videoTee = new TeeBlock(2, MediaBlockPadMediaType.Video);

            var filename = GenerateFilename();
            lbFilename.Text = $"FILENAME: {filename}";
            lbFilename.IsVisible = true;
            _mp4Sink = new MP4SinkBlock(new MP4SinkSettings(filename));
            _h264Encoder = new H264EncoderBlock();

            IVideoView vv;
#if __MACCATALYST__
            vv = videoView;
#else
            vv = videoView.GetVideoView();
#endif

            _videoRenderer = new VideoRendererBlock(_pipeline, vv) { IsSync = false };

            _pipeline.Connect(_source.Output, _videoTee.Input);

            _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
            _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);

            _pipeline.Connect(_h264Encoder.Output, _mp4Sink.CreateNewInput(MediaBlockPadMediaType.Video));
        }

#if __IOS__ && !__MACCATALYST__
        private void RequestPhotoPermission()
        {
            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    Debug.WriteLine("Photo library access granted.");
                }
            });
        }
#endif

#if __IOS__ && !__MACCATALYST__
        private void AddVideoToPhotosLibrary(string filePath)
        {
            var fileUrl = Foundation.NSUrl.FromFilename(filePath);

            Photos.PHPhotoLibrary.RequestAuthorization(status =>
            {
                if (status == Photos.PHAuthorizationStatus.Authorized)
                {
                    Photos.PHPhotoLibrary.SharedPhotoLibrary.PerformChanges(() =>
                    {
                        // This line differs from the previous example
                        Photos.PHAssetChangeRequest.FromVideo(fileUrl);
                    }, (success, error) =>
                    {
                        if (success)
                        {
                            Debug.WriteLine("Video saved to Photos library.");
                        }
                        else
                        {
                            Debug.WriteLine($"Error saving video: {error?.LocalizedDescription}");
                        }
                    });
                }
            });
        }
#endif

        private void MainPage_Loaded(object sender, EventArgs e)
        {
            Window.Destroying += Window_Destroying;

#if __MACCATALYST__
            ScreenSourceBlock.AskPermissions();
#endif

#if __IOS__ && !__MACCATALYST__
            RequestPhotoPermission();
#endif
        }

        private async void Window_Destroying(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _player_OnError;
                await _pipeline.StopAsync();

                _pipeline.Dispose();
                _pipeline = null;
            }

            VisioForgeX.DestroySDK();
        }

        private async void OnStop(object sender, EventArgs e)
        {
            if (_pipeline != null)
            {
                _pipeline.OnError -= _player_OnError;
                await _pipeline.StopAsync();
            }
        }

        private void _player_OnError(object sender, VisioForge.Core.Types.Events.ErrorsEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }

        private async Task StopAllAsync()
        {
            if (_pipeline == null)
            {
                return;
            }

            _tmPosition.Stop();

            if (_pipeline != null)
            {
                await _pipeline.StopAsync();
            }
        }

        /// <summary>
        /// Handles the Elapsed event of the tmPosition control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private async void tmPosition_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_pipeline == null)
            {
                return;
            }

            try
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    if (_pipeline == null)
                    {
                        return;
                    }

                    lbDuration.Text = $"{(await _pipeline.Position_GetAsync()).ToString(@"hh\:mm\:ss", CultureInfo.InvariantCulture)}";
                });
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private async void btStart_Clicked(object sender, EventArgs e)
        {
            await CreateEngineAsync();

            await _pipeline.StartAsync();

            _tmPosition.Start();
        }

        private async void btStop_Clicked(object sender, EventArgs e)
        {
#if __IOS__ && !__MACCATALYST__
            var filename = _mp4Sink.GetFilenameOrURL();            
#endif

            await StopAllAsync();

            // save video to iOS photo library
#if __IOS__ && !__MACCATALYST__
            AddVideoToPhotosLibrary(filename);
#endif            

            lbFilename.IsVisible = false;
        }
    }
}
