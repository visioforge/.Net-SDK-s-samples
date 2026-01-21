using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.Types.Events;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// The play engine interface.
    /// </summary>
    internal interface IPlayEngine : IAsyncDisposable
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        string URL { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether audio is enabled.
        /// </summary>
        bool AudioEnabled { get; set; }

        /// <summary>
        /// Starts the engine asynchronously.
        /// </summary>
        /// <returns>True if started successfully; otherwise, false.</returns>
        Task<bool> StartAsync();

        /// <summary>
        /// Stops the engine asynchronously.
        /// </summary>
        /// <returns>True if stopped successfully; otherwise, false.</returns>
        Task<bool> StopAsync();

        /// <summary>
        /// Gets a value indicating whether the engine is started.
        /// </summary>
        /// <returns>True if started; otherwise, false.</returns>
        bool IsStarted();

        /// <summary>
        /// Occurs when an error happens.
        /// </summary>
        event EventHandler<ErrorsEventArgs> OnError;
    }
}
