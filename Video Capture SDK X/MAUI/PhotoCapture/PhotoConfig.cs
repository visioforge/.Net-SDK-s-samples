using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoCapture
{
    /// <summary>
    /// Internal configuration class for maintaining the state of the photo capture application.
    /// </summary>
    internal static class PhotoConfig
    {
        /// <summary>
        /// Gets or sets the index of the currently active camera.
        /// </summary>
        public static int CurrentCamera { get; set; } = 0;
    }
}
