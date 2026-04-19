namespace SimpleVideoCaptureMVVM
{
    using System;

    /// <summary>
    /// Represents the platform information.
    /// </summary>
    public class PlatformInfo
    {
        /// <summary>
        /// Gets a value indicating whether the platform is mobile.
        /// </summary>
        public bool IsMobile { get; }

        /// <summary>
        /// Gets a value indicating whether the platform is desktop.
        /// </summary>
        public bool IsDesktop { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformInfo"/> class.
        /// </summary>
        public PlatformInfo()
        {
            IsMobile = OperatingSystem.IsAndroid() || OperatingSystem.IsIOS();
            IsDesktop = !IsMobile;
        }
    }
}
