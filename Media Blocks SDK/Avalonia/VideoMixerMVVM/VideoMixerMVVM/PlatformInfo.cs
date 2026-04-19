namespace VideoMixerMVVM
{
    using System;

    public class PlatformInfo
    {
        public bool IsMobile { get; }

        public bool IsDesktop { get; }

        public PlatformInfo()
        {
            IsMobile = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();
            IsDesktop = !IsMobile;
        }
    }
}
