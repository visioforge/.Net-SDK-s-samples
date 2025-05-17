using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using VisioForge.Core;
using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioEncoders;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.AudioEncoders;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;

namespace RTSP_Capture_Original
{
    /// <summary>
    /// Console application for capturing RTSP camera streams and saving to an MP4 file.
    /// This demo showcases how to use the VisioForge MediaBlocks SDK to create a simple
    /// but powerful RTSP recording utility.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point for the application. Handles user input for RTSP connection
        /// parameters and file output settings, then initiates the recording process.
        /// </summary>
        /// <param name="args">Command line arguments (not used)</param>
        /// <returns>An async Task representing the execution of the application</returns>
        static async Task Main(string[] args)
        {
            Console.WriteLine("RTSP Camera to MP4 Capture Utility");
            Console.WriteLine("----------------------------------");
            Console.WriteLine();

            // Ask for RTSP URL - This is the address of the IP camera or RTSP stream
            Console.Write("Enter RTSP URL (e.g. rtsp://camera-ip:554/stream): ");
            string rtspUrl = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(rtspUrl))
            {
                Console.WriteLine("Invalid URL. Exiting...");
                return;
            }
            
            // Ask for credentials - Many IP cameras require authentication
            Console.Write("Enter username (press Enter if none): ");
            string username = Console.ReadLine();
            
            Console.Write("Enter password (press Enter if none): ");
            string password = Console.ReadLine();

            // Ask for output file location - Default to the user's Videos folder
            string myVideosFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), "rtsp_capture.mp4");
            Console.WriteLine($"Enter output MP4 file path (default: {myVideosFolder}): ");
            string outputFilePath = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(outputFilePath))
            {
                outputFilePath = myVideosFolder;
            }

            // Make sure the directory exists for the output file
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Display recording information
            Console.WriteLine();
            Console.WriteLine($"Capturing from: {rtspUrl}");
            Console.WriteLine($"Saving to: {outputFilePath}");
            Console.WriteLine();
            Console.WriteLine("Press any key to stop recording...");

            try
            {
                // Create a cancellation token source to allow stopping the recording
                var cts = new CancellationTokenSource();
                
                // Start the recording process asynchronously
                var recordingTask = StartRecordingAsync(rtspUrl, username, password, outputFilePath, cts.Token);

                // Wait for the user to press a key to stop recording
                Console.ReadKey(true);
                Console.WriteLine("\nStopping recording...");
                cts.Cancel();

                // Wait for the recording task to complete after cancellation
                await recordingTask;
                Console.WriteLine("Recording completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during recording
                Console.WriteLine($"Error: {ex.Message}");
            }

            // Wait for user to exit
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);

            // Clean up the VisioForge SDK resources
            VisioForgeX.DestroySDK();
        }

        /// <summary>
        /// Starts the RTSP recording process and handles the recording session lifecycle.
        /// This method creates and configures the RTSPRecorder, updates the recording duration
        /// display, and properly cleans up when recording is stopped.
        /// </summary>
        /// <param name="rtspUrl">The URL of the RTSP stream to record</param>
        /// <param name="username">Username for RTSP authentication (can be empty)</param>
        /// <param name="password">Password for RTSP authentication (can be empty)</param>
        /// <param name="outputFilePath">Path where the MP4 file will be saved</param>
        /// <param name="cancellationToken">Token to signal when recording should stop</param>
        /// <returns>A task representing the recording process</returns>
        private static async Task StartRecordingAsync(string rtspUrl, string username, string password, string outputFilePath, CancellationToken cancellationToken)
        {
            // Create a timer to display recording duration, updating every second
            var durationTimer = new System.Timers.Timer(1000);
            var previousLine = "";
            
            // Create and use an instance of RTSPRecorder with using pattern for automatic disposal
            await using (var recorder = new RTSPRecorder())
            {
                // Set up event handlers for error and status notifications
                recorder.OnError += Recorder_OnError;
                recorder.OnStatusMessage += Recorder_OnStatusMessage;

                // Configure recording parameters
                recorder.Filename = outputFilePath;
                recorder.ReencodeAudio = true;  // Re-encode audio to ensure compatibility

                // Create RTSP settings with the provided credentials
                // The second parameter (true) enables audio if available in the stream
                var rtspSettings = new RTSPRAWSourceSettings(new Uri(rtspUrl), true);
                rtspSettings.Login = username;
                rtspSettings.Password = password;

                // Start the recording process
                Console.WriteLine("Starting recording...");
                if (await recorder.StartAsync(rtspSettings))
                {
                    Console.WriteLine("Recording started successfully.");
                    Console.WriteLine(); // Add a blank line before the duration counter
                    
                    // Set up the timer to display recording duration in the console
                    durationTimer.Elapsed += (sender, e) => 
                    {
                        try
                        {
                            // Get the current position (duration) from the pipeline
                            var duration = recorder.Pipeline.Position_Get();
                            var durationText = $"Recording duration: {duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";
                            
                            // Clear the previous line and write the new duration
                            // This creates an updating duration counter without adding new lines
                            if (!string.IsNullOrEmpty(previousLine))
                            {
                                Console.SetCursorPosition(0, Console.CursorTop);
                                Console.Write(new string(' ', previousLine.Length));
                                Console.SetCursorPosition(0, Console.CursorTop);
                            }
                            
                            Console.Write(durationText);
                            previousLine = durationText;
                        }
                        catch (Exception ex)
                        {
                            // Handle any exceptions during timer callback
                            Console.WriteLine($"\nError updating duration: {ex.Message}");
                        }
                    };
                    
                    // Start the duration timer
                    durationTimer.Start();

                    try
                    {
                        // Keep the recording running until cancellation is requested
                        // Polling at 100ms intervals to check for cancellation
                        while (!cancellationToken.IsCancellationRequested)
                        {
                            await Task.Delay(100, cancellationToken);
                        }
                    }
                    catch (TaskCanceledException)
                    {
                        // This exception is expected when the cancellation token is triggered
                        // No need to handle it specially as we're already stopping the recording
                    }
                    finally
                    {
                        // Cleanup: Stop and dispose of the duration timer
                        durationTimer.Stop();
                        durationTimer.Dispose();
                        
                        // Display the final recording duration
                        var finalDuration = recorder.Pipeline.Duration();
                        Console.WriteLine($"\nFinal recording duration: {finalDuration.Hours:D2}:{finalDuration.Minutes:D2}:{finalDuration.Seconds:D2}");
                        
                        // Stop the recording and cleanup event handlers
                        await recorder.StopAsync();
                        recorder.OnError -= Recorder_OnError;
                        recorder.OnStatusMessage -= Recorder_OnStatusMessage;
                    }
                }
                else
                {
                    // Handle the case where recording fails to start
                    durationTimer.Dispose();
                    Console.WriteLine("Failed to start recording.");
                }
            }
        }

        /// <summary>
        /// Event handler for status messages from the recorder.
        /// Displays status information to the console.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">The status message</param>
        private static void Recorder_OnStatusMessage(object sender, string e)
        {
            Console.WriteLine($"Status: {e}");
        }

        /// <summary>
        /// Event handler for error messages from the recorder.
        /// Displays error information to the console.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Error event arguments containing the error message</param>
        private static void Recorder_OnError(object sender, ErrorsEventArgs e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    /// <summary>
    /// RTSPRecorder class encapsulates the RTSP recording functionality using the MediaBlocks SDK.
    /// It creates a pipeline that connects an RTSP source to an MP4 sink, optionally with audio re-encoding.
    /// </summary>
    public class RTSPRecorder : IAsyncDisposable
    {
        /// <summary>
        /// The MediaBlocks pipeline that manages the flow of media data
        /// </summary>
        public MediaBlocksPipeline Pipeline { get; private set; }

        // Private fields for the MediaBlock components
        private MediaBlock _muxer;               // MP4 container muxer (sink)
        private RTSPRAWSourceBlock _rtspRawSource; // RTSP stream source
        private DecodeBinBlock _decodeBin;       // Audio decoder
        private AACEncoderBlock _audioEncoder;   // AAC audio encoder
        private bool disposedValue;              // Flag to prevent multiple disposals

        /// <summary>
        /// Event fired when an error occurs in the pipeline
        /// </summary>
        public event EventHandler<ErrorsEventArgs> OnError;

        /// <summary>
        /// Event fired when a status message is available
        /// </summary>
        public event EventHandler<string> OnStatusMessage;

        /// <summary>
        /// Output filename for the MP4 recording
        /// </summary>
        public string Filename { get; set; } = "output.mp4";

        /// <summary>
        /// Whether to re-encode audio to AAC format (recommended for compatibility)
        /// </summary>
        public bool ReencodeAudio { get; set; } = true;

        /// <summary>
        /// Starts the recording session by creating and configuring the MediaBlocks pipeline.
        /// </summary>
        /// <param name="rtspSettings">RTSP source configuration settings</param>
        /// <returns>True if the pipeline started successfully, false otherwise</returns>
        public async Task<bool> StartAsync(RTSPRAWSourceSettings rtspSettings)
        {
            // Create a new MediaBlocks pipeline
            Pipeline = new MediaBlocksPipeline();
            Pipeline.OnError += OnError;

            OnStatusMessage?.Invoke(this, "Creating pipeline...");

            // Create the RTSP source block with the provided settings
            _rtspRawSource = new RTSPRAWSourceBlock(rtspSettings);
            
            // Create the MP4 sink (muxer) block with the output filename
            _muxer = new MP4SinkBlock(new MP4SinkSettings(Filename));

            // Create a dynamic input pad on the muxer for the video stream
            var inputVideoPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Video);
            
            // Connect the RTSP video output to the muxer's video input
            Pipeline.Connect(_rtspRawSource.VideoOutput, inputVideoPad);

            // If audio is enabled in the RTSP stream settings, set up the audio path
            if (rtspSettings.AudioEnabled)
            {
                // Create a dynamic input pad on the muxer for the audio stream
                var inputAudioPad = (_muxer as IMediaBlockDynamicInputs).CreateNewInput(MediaBlockPadMediaType.Audio);

                if (ReencodeAudio)
                {
                    // If audio re-encoding is enabled (recommended for compatibility)
                    OnStatusMessage?.Invoke(this, "Setting up audio reencoding to AAC...");
                    
                    // Create a decoder block that only handles audio (not video or subtitles)
                    _decodeBin = new DecodeBinBlock(false, true, false)
                    {
                        DisableAudioConverter = true  // Let us handle conversion explicitly
                    };

                    // Create an AAC encoder with default settings
                    _audioEncoder = new AACEncoderBlock(new AVENCAACEncoderSettings());

                    // Connect the audio processing pipeline:
                    // RTSP audio output -> decoder -> AAC encoder -> muxer audio input
                    Pipeline.Connect(_rtspRawSource.AudioOutput, _decodeBin.Input);
                    Pipeline.Connect(_decodeBin.AudioOutput, _audioEncoder.Input);
                    Pipeline.Connect(_audioEncoder.Output, inputAudioPad);
                }
                else
                {
                    // If audio re-encoding is disabled, connect RTSP audio directly to the muxer
                    // Note: This may cause issues if the audio format is not compatible with MP4
                    Pipeline.Connect(_rtspRawSource.AudioOutput, inputAudioPad);
                }
            }

            // Start the pipeline
            OnStatusMessage?.Invoke(this, "Starting recording...");
            return await Pipeline.StartAsync();
        }

        /// <summary>
        /// Stops the recording by stopping the MediaBlocks pipeline.
        /// </summary>
        /// <returns>True if the pipeline stopped successfully, false otherwise</returns>
        public async Task<bool> StopAsync()
        {
            if (Pipeline == null)
                return false;

            OnStatusMessage?.Invoke(this, "Stopping recording...");
            Pipeline.OnError -= OnError;
            return await Pipeline.StopAsync();
        }

        /// <summary>
        /// Asynchronously disposes of the RTSPRecorder and all its resources.
        /// Implements the IAsyncDisposable pattern for proper resource cleanup.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            if (!disposedValue)
            {
                // Dispose of the pipeline if it exists
                if (Pipeline != null)
                {
                    Pipeline.OnError -= OnError;
                    await Pipeline.DisposeAsync();
                    Pipeline = null;
                }

                // Dispose of all MediaBlock components
                (_muxer as IDisposable)?.Dispose();
                _muxer = null;

                _rtspRawSource?.Dispose();
                _rtspRawSource = null;

                _decodeBin?.Dispose();
                _decodeBin = null;

                _audioEncoder?.Dispose();
                _audioEncoder = null;

                disposedValue = true;
            }
        }
    }
}
