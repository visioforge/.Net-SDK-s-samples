using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.VideoCapture;
using VisioForge.Core.Types.VideoEffects;

namespace Simple_Video_Capture
{
    public interface IVideoCaptureAccessor
    {
        event EventHandler<string> OnError;

        void SetOwnerWindow(System.Windows.Window window);

        object UIElement { get; }

        Version SDK_Version { get; }

        List<VideoCaptureDeviceInfo> Video_CaptureDevices { get; }

        List<AudioCaptureDeviceInfo> Audio_CaptureDevices { get; }

        List<string> Audio_OutputDevices { get; }

        List<OutputFormatInfo> OutputFormats { get; }

        void Audio_OutputDevice_Volume_Set(int volume);

        void Audio_OutputDevice_Balance_Set(int balance);

        VideoCaptureSource Video_CaptureDevice { get; set; }

        AudioCaptureSource Audio_CaptureDevice { get; set; }

        void DisplayConfigureDialog(OutputFormatInfoTag outputFormatInfoTag);

        void Audio_CaptureDevice_SettingsDialog_Show(string deviceName);

        void Video_CaptureDevice_SettingsDialog_Show(string deviceName);

        IVideoEffect AddImageLogoEffect();

        IVideoEffect AddTextLogoEffect();

        void EditEffect(IVideoEffect effect);

        void RemoveEffect(IVideoEffect effect);

        void SetEffectEnabledState(string name, bool state);

        void SetEffectValue(string name, int value);

        Task StartAsync(VideoCaptureStartParams startParams);

        Task<bool> PauseAsync();

        Task<bool> ResumeAsync();

        Task StopAsync();

        TimeSpan Duration_Time();

        Task<bool> SaveScreenshotAsync(string fileName);
    }
}
