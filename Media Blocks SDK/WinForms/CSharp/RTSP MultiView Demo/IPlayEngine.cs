using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    internal interface IPlayEngine : IDisposable
    {
        string URL { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        bool AudioEnabled { get; set; }

        Task<bool> StartAsync();

        Task<bool> StopAsync();

        bool IsStarted();
    }
}
