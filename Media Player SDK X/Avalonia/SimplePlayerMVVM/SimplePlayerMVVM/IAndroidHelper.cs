using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlayerMVVM
{
    /// <summary>
    /// Android helper interface.
    /// </summary>
    public interface IAndroidHelper
    {
#if __ANDROID__
        /// <summary>
        /// Get context.
        /// </summary>
        global::Android.Content.Context GetContext();
#endif
    }
}
