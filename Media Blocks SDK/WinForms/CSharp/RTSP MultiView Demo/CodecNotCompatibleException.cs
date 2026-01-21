using System;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// Exception thrown when a video codec is not compatible with the target container format.
    /// </summary>
    public class CodecNotCompatibleException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodecNotCompatibleException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public CodecNotCompatibleException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodecNotCompatibleException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CodecNotCompatibleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
