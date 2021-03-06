﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisioForge.Types;
using VisioForge.Types.VideoEffects;

namespace Simple_Video_Capture
{
    public interface IVideoCaptureAccessor
    {
        event EventHandler<string> OnError;

        void SetOwnerWindow(System.Windows.Window window);

        object UIElement { get; }

        Version SDK_Version { get; }
        string SDK_State { get; }
        List<VideoCaptureDeviceInfo> Video_CaptureDevicesInfo { get; }
        List<AudioCaptureDeviceInfo> Audio_CaptureDevicesInfo { get; }
        List<string> Audio_OutputDevices { get; }
        List<OutputFormatInfo> OutputFormats { get; }
        void Audio_OutputDevice_Volume_Set(int volume);
        void Audio_OutputDevice_Balance_Set(int balance);
        string Audio_CaptureDevice_Format { get; set; }
        string Audio_CaptureDevice_Line { get; set; }
        bool Video_CaptureDevice_IsAudioSource { get; set; }
        string Video_CaptureDevice { get; set; }
        string Audio_CaptureDevice { get; set; }
        void DisplayConfigureDialog(OutputFormatInfoTag outputFormatInfoTag);
        void Audio_CaptureDevice_SettingsDialog_Show(string deviceName);
        void Video_CaptureDevice_SettingsDialog_Show(string deviceName);
        IVFVideoEffect AddImageLogoEffect();
        IVFVideoEffect AddTextLogoEffect();
        void EditEffect(IVFVideoEffect effect);
        void RemoveEffect(IVFVideoEffect effect);
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
