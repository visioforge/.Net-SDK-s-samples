using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlayerMVVM
{
    public interface IAndroidHelper
    {
#if __ANDROID__
        global::Android.Content.Context GetContext();
#endif
    }
}
