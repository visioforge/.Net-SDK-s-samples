using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;

namespace MediaBlocks_Video_Mixer_Demo
{
    internal interface IMixerEngine
    {
        /// <summary>
        /// Occurs when error happened.
        /// </summary>
        event EventHandler<ErrorsEventArgs> OnError;

        Task StartAsync(string filename1, string filename2, IVideoView videoView);

        Task StopAsync();

        void AddStream(Rect rect, int zorder);
    }
}
