using System;

namespace MediaBlocks_RTSP_MultiView_Demo
{
    /// <summary>
    /// Exception thrown when a video codec is not compatible with the target container format.
    /// </summary>
    public class CodecNotCompatibleException : Exception
    {
        public CodecNotCompatibleException(string message) : base(message)
        {
        }

        public CodecNotCompatibleException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
