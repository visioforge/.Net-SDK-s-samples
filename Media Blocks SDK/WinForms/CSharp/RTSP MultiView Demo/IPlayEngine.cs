using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types.Events;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    internal interface IPlayEngine : IAsyncDisposable
    {
        string URL { get; set; }

        string Login { get; set; }

        string Password { get; set; }

        bool AudioEnabled { get; set; }

        Task<bool> StartAsync();

        Task<bool> StopAsync();

        bool IsStarted();

        event EventHandler<ErrorsEventArgs> OnError;
    }
}
