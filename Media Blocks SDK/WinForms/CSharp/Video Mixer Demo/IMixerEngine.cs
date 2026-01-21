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
    /// <summary>
    /// The mixer engine interface.
    /// </summary>
    internal interface IMixerEngine
    {
        /// <summary>
        /// Occurs when error happened.
        /// </summary>
        event EventHandler<ErrorsEventArgs> OnError;

        /// <summary>
        /// Starts the mixer engine.
        /// </summary>
        /// <param name="filename1">The first filename.</param>
        /// <param name="filename2">The second filename.</param>
        /// <param name="videoView">The video view.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task StartAsync(string filename1, string filename2, IVideoView videoView);

        /// <summary>
        /// Stops the mixer engine.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task StopAsync();

        /// <summary>
        /// Adds a stream to the mixer.
        /// </summary>
        /// <param name="rect">The rectangle.</param>
        /// <param name="zorder">The Z-order.</param>
        void AddStream(Rect rect, uint zorder);
    }
}
