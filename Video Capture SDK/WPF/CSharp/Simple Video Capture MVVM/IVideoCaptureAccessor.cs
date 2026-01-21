using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;

namespace Simple_Video_Capture
{
    /// <summary>
    /// Video capture accessor interface.
    /// </summary>
    public interface IVideoCaptureAccessor
    {
        /// <summary>
        /// Occurs when an error happens.
        /// </summary>
        event EventHandler<string> OnError;

        /// <summary>
        /// Sets the owner window.
        /// </summary>
        /// <param name="window">The owner window.</param>
        void SetOwnerWindow(System.Windows.Window window);

        /// <summary>
        /// Gets the UI element.
        /// </summary>
        object UIElement { get; }

        /// <summary>
        /// Gets the SDK version.
        /// </summary>
        Version SDK_Version { get; }

        /// <summary>
        /// Gets the video capture devices.
        /// </summary>
        ObservableCollection<VideoCaptureDeviceInfo> Video_CaptureDevices { get; }

        /// <summary>
        /// Gets the audio capture devices.
        /// </summary>
        ObservableCollection<AudioCaptureDeviceInfo> Audio_CaptureDevices { get; }

        /// <summary>
        /// Gets the audio output devices.
        /// </summary>
        ObservableCollection<string> Audio_OutputDevices { get; }

        /// <summary>
        /// Gets the output formats.
        /// </summary>
        ObservableCollection<OutputFormatInfo> OutputFormats { get; }

        /// <summary>
        /// Sets the volume of the audio output device.
        /// </summary>
        /// <param name="volume">The volume.</param>
        void Audio_OutputDevice_Volume_Set(int volume);

        /// <summary>
        /// Sets the balance of the audio output device.
        /// </summary>
        /// <param name="balance">The balance.</param>
        void Audio_OutputDevice_Balance_Set(int balance);

        /// <summary>
        /// Gets or sets the video capture device.
        /// </summary>
        VideoCaptureSource Video_CaptureDevice { get; set; }

        /// <summary>
        /// Gets or sets the audio capture device.
        /// </summary>
        AudioCaptureSource Audio_CaptureDevice { get; set; }

        /// <summary>
        /// Displays the configure dialog.
        /// </summary>
        /// <param name="outputFormatInfoTag">The output format info tag.</param>
        void DisplayConfigureDialog(OutputFormatInfoTag outputFormatInfoTag);

        /// <summary>
        /// Shows the audio capture device settings dialog.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        void Audio_CaptureDevice_SettingsDialog_Show(string deviceName);

        /// <summary>
        /// Shows the video capture device settings dialog.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        void Video_CaptureDevice_SettingsDialog_Show(string deviceName);

        /// <summary>
        /// Adds the image logo effect.
        /// </summary>
        /// <returns>The video effect.</returns>
        IVideoEffect AddImageLogoEffect();

        /// <summary>
        /// Adds the text logo effect.
        /// </summary>
        /// <returns>The video effect.</returns>
        IVideoEffect AddTextLogoEffect();

        /// <summary>
        /// Edits the effect.
        /// </summary>
        /// <param name="effect">The effect.</param>
        void EditEffect(IVideoEffect effect);

        /// <summary>
        /// Removes the effect.
        /// </summary>
        /// <param name="effect">The effect.</param>
        void RemoveEffect(IVideoEffect effect);

        /// <summary>
        /// Sets the state of the effect enabled.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="state">if set to <c>true</c> [state].</param>
        void SetEffectEnabledState(string name, bool state);

        /// <summary>
        /// Sets the effect value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        void SetEffectValue(string name, int value);

        /// <summary>
        /// Starts the asynchronous.
        /// </summary>
        /// <param name="startParams">The start parameters.</param>
        /// <returns>Task.</returns>
        Task StartAsync(VideoCaptureStartParams startParams);

        /// <summary>
        /// Pauses the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> PauseAsync();

        /// <summary>
        /// Resumes the asynchronous.
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> ResumeAsync();

        /// <summary>
        /// Stops the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StopAsync();

        /// <summary>
        /// Durations the time.
        /// </summary>
        /// <returns>TimeSpan.</returns>
        TimeSpan Duration_Time();

        /// <summary>
        /// Saves the screenshot asynchronous.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> SaveScreenshotAsync(string fileName);
    }
}
