using System;
using System.Runtime.InteropServices;
using CoreMedia;
using CoreVideo;
using Foundation;
using ReplayKit;

namespace ScreenCaptureExtension
{
    /// <summary>
    /// Broadcast Upload Extension entry point. Receives system-wide screen sample buffers from
    /// ReplayKit and forwards each video frame over a Unix domain socket in the App Group shared
    /// container so the main app (running GStreamer) can consume them in real time.
    ///
    /// Memory budget is ~50 MB for broadcast extensions, so this class intentionally does not
    /// link against VisioForge.Core / GStreamer — just raw POSIX socket writes.
    ///
    /// Frame wire format (little-endian):
    ///   uint32 magic       = 0x5646524D  ('VFRM')
    ///   uint32 width
    ///   uint32 height
    ///   uint32 format      = 1 for NV12
    ///   int64  pts_ns      (presentation timestamp from CMSampleBuffer)
    ///   int64  duration_ns
    ///   uint32 yStride
    ///   uint32 uvStride
    ///   uint32 ySize       = yStride * height
    ///   uint32 uvSize      = uvStride * (height / 2)
    ///   bytes  yPlane[ySize]
    ///   bytes  uvPlane[uvSize]
    /// </summary>
    [Register("SampleHandler")]
    public class SampleHandler : RPBroadcastSampleHandler
    {
        private const string AppGroupId = "group.com.visioforge.screencapture";
        private const string SocketFilename = "broadcast.sock";
        private const uint FrameMagic = 0x5646524D; // 'VFRM'
        private const uint FormatNV12 = 1;

        // POSIX constants for macOS / iOS.
        private const int AF_UNIX = 1;
        private const int SOCK_STREAM = 1;

        private int _sockFd = -1;
        private readonly object _sockLock = new object();

        public override void BroadcastStarted(NSDictionary<NSString, NSObject> setupInfo)
        {
            ConnectSocket();
        }

        public override void BroadcastFinished()
        {
            CloseSocket();
        }

        public override void BroadcastPaused()
        {
            // Keep socket open — consumer treats the gap in PTS as a pause.
        }

        public override void BroadcastResumed()
        {
        }

        public override void ProcessSampleBuffer(CMSampleBuffer sampleBuffer, RPSampleBufferType sampleBufferType)
        {
            if (sampleBufferType != RPSampleBufferType.Video || sampleBuffer == null)
            {
                return;
            }

            if (_sockFd < 0)
            {
                return; // main app not listening / connection lost; drop frames silently
            }

            try
            {
                using (var pixelBuffer = sampleBuffer.GetImageBuffer() as CVPixelBuffer)
                {
                    if (pixelBuffer == null)
                    {
                        return;
                    }

                    // Only NV12 is negotiated with ReplayKit by default.
                    var pixelFormat = pixelBuffer.PixelFormatType;
                    if (pixelFormat != CVPixelFormatType.CV420YpCbCr8BiPlanarVideoRange &&
                        pixelFormat != CVPixelFormatType.CV420YpCbCr8BiPlanarFullRange)
                    {
                        return;
                    }

                    pixelBuffer.Lock(CVPixelBufferLock.ReadOnly);
                    try
                    {
                        var width = (uint)pixelBuffer.Width;
                        var height = (uint)pixelBuffer.Height;
                        var yStride = (uint)pixelBuffer.GetBytesPerRowOfPlane(0);
                        var uvStride = (uint)pixelBuffer.GetBytesPerRowOfPlane(1);
                        var ySize = yStride * height;
                        var uvSize = uvStride * (height / 2);
                        var yBase = pixelBuffer.GetBaseAddress(0);
                        var uvBase = pixelBuffer.GetBaseAddress(1);
                        var ptsNs = (long)(sampleBuffer.PresentationTimeStamp.Seconds * 1_000_000_000d);
                        var duration = sampleBuffer.Duration;
                        var durationSeconds = duration.Seconds;
                        if (double.IsNaN(durationSeconds) || double.IsInfinity(durationSeconds) || durationSeconds <= 0)
                        {
                            durationSeconds = 1.0 / 60.0;
                        }
                        var durationNs = (long)(durationSeconds * 1_000_000_000d);

                        // Build a 48-byte header on the stack. Layout matches the protocol docblock above.
                        Span<byte> header = stackalloc byte[48];
                        WriteUInt32LE(header.Slice(0, 4), FrameMagic);
                        WriteUInt32LE(header.Slice(4, 4), width);
                        WriteUInt32LE(header.Slice(8, 4), height);
                        WriteUInt32LE(header.Slice(12, 4), FormatNV12);
                        WriteInt64LE(header.Slice(16, 8), ptsNs);
                        WriteInt64LE(header.Slice(24, 8), durationNs);
                        WriteUInt32LE(header.Slice(32, 4), yStride);
                        WriteUInt32LE(header.Slice(36, 4), uvStride);
                        WriteUInt32LE(header.Slice(40, 4), ySize);
                        WriteUInt32LE(header.Slice(44, 4), uvSize);

                        lock (_sockLock)
                        {
                            if (_sockFd < 0)
                            {
                                return;
                            }

                            if (!SendAll(header) ||
                                !SendRegion(yBase, (int)ySize) ||
                                !SendRegion(uvBase, (int)uvSize))
                            {
                                CloseSocketLocked();
                            }
                        }
                    }
                    finally
                    {
                        pixelBuffer.Unlock(CVPixelBufferLock.ReadOnly);
                    }
                }
            }
            catch (Exception ex)
            {
                // Extensions can't really log; swallow to avoid cascading crashes.
                System.Diagnostics.Debug.WriteLine("[SampleHandler] " + ex.Message);
            }
        }

        private void ConnectSocket()
        {
            var socketPath = ResolveSocketPath();
            if (socketPath == null)
            {
                return;
            }

            int fd = socket(AF_UNIX, SOCK_STREAM, 0);
            if (fd < 0)
            {
                return;
            }

            // sockaddr_un is 106 bytes on Darwin (sun_len, sun_family, sun_path[104]).
            var addr = new byte[106];
            addr[0] = 106; // sun_len
            addr[1] = AF_UNIX;
            var pathBytes = System.Text.Encoding.UTF8.GetBytes(socketPath);
            if (pathBytes.Length >= 104)
            {
                close(fd);
                return;
            }
            Array.Copy(pathBytes, 0, addr, 2, pathBytes.Length);

            var rc = -1;
            unsafe
            {
                fixed (byte* addrPtr = addr)
                {
                    rc = connect(fd, addrPtr, (uint)addr.Length);
                }
            }

            if (rc != 0)
            {
                close(fd);
                return;
            }

            lock (_sockLock)
            {
                _sockFd = fd;
            }
        }

        private void CloseSocket()
        {
            lock (_sockLock)
            {
                CloseSocketLocked();
            }
        }

        private void CloseSocketLocked()
        {
            if (_sockFd >= 0)
            {
                close(_sockFd);
                _sockFd = -1;
            }
        }

        private bool SendAll(ReadOnlySpan<byte> data)
        {
            unsafe
            {
                fixed (byte* p = data)
                {
                    return SendAll((IntPtr)p, data.Length);
                }
            }
        }

        private bool SendRegion(IntPtr src, int size)
        {
            return SendAll(src, size);
        }

        private bool SendAll(IntPtr data, int size)
        {
            var remaining = size;
            var ptr = data;
            while (remaining > 0)
            {
                // MSG_NOSIGNAL isn't defined on Darwin — we rely on SO_NOSIGPIPE or ignore SIGPIPE below.
                var sent = send(_sockFd, ptr, (UIntPtr)remaining, 0);
                if (sent <= 0)
                {
                    return false;
                }
                ptr = IntPtr.Add(ptr, (int)sent);
                remaining -= (int)sent;
            }
            return true;
        }

        private static string ResolveSocketPath()
        {
            var container = NSFileManager.DefaultManager.GetContainerUrl(AppGroupId);
            if (container == null)
            {
                return null;
            }
            return System.IO.Path.Combine(container.Path, SocketFilename);
        }

        private static void WriteUInt32LE(Span<byte> dest, uint value)
        {
            dest[0] = (byte)(value & 0xFF);
            dest[1] = (byte)((value >> 8) & 0xFF);
            dest[2] = (byte)((value >> 16) & 0xFF);
            dest[3] = (byte)((value >> 24) & 0xFF);
        }

        private static void WriteInt64LE(Span<byte> dest, long value)
        {
            for (int i = 0; i < 8; i++)
            {
                dest[i] = (byte)((value >> (8 * i)) & 0xFF);
            }
        }

        // POSIX socket P/Invokes (Darwin libc is linked implicitly on iOS).
        [DllImport("libSystem", EntryPoint = "socket")]
        private static extern int socket(int domain, int type, int protocol);

        [DllImport("libSystem", EntryPoint = "connect")]
        private static extern unsafe int connect(int sockfd, byte* addr, uint addrlen);

        [DllImport("libSystem", EntryPoint = "send")]
        private static extern nint send(int sockfd, IntPtr buf, UIntPtr len, int flags);

        [DllImport("libSystem", EntryPoint = "close")]
        private static extern int close(int fd);
    }
}
