using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlayerMVVM
{
    /// <summary>
    /// Represents a helper to get the Android context.
    /// </summary>
    public interface IAndroidHelper
    {
#if __ANDROID__
        /// <summary>
        /// Gets the Android context.
        /// </summary>
        global::Android.Content.Context GetContext();
#endif
    }
}
