using System;
using System.Diagnostics;
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
    /// link against VisioForge.Core / GStreamer — just raw POSIX socket writes. That rules out
    /// a shared-constants assembly; the wire-format constants below MUST be kept in sync by
    /// hand with the receiver at
    /// <c>_SOURCE/VisioForge.Core/GStreamer/_Apple/Sources/IOSBroadcastSourceX.cs</c>.
    /// Any layout or semantic change MUST also bump <see cref="ProtocolVersion"/> so an old
    /// host talking to a new extension (or vice versa) rejects the frames instead of
    /// silently reading garbage.
    ///
    /// Frame wire format (little-endian, 52-byte header):
    ///   uint32 magic       = 0x5646524D  ('VFRM')
    ///   uint8  version     = 1          (protocol version; receiver rejects unknown)
    ///   uint8  reserved[3] = 0          (padding; keeps subsequent fields 4-byte aligned)
    ///   uint32 width
    ///   uint32 height
    ///   uint32 format      = 1 for NV12
    ///   int64  pts_ns      (presentation timestamp from CMSampleBuffer)
    ///   int64  duration_ns
    ///   uint32 yStride
    ///   uint32 uvStride
    ///   uint32 ySize       = yStride * height
    ///   uint32 uvSize      = uvStride * ((height + 1) / 2)
    ///                        (ceiling division — for odd heights NV12's chroma plane has
    ///                        ceil(height/2) rows, not floor(height/2). Sender and receiver
    ///                        MUST agree; floor-vs-ceiling mismatch causes the receiver's
    ///                        size validation to drop the connection on portrait-orientation
    ///                        iPhone frames where height is sometimes odd.)
    ///   bytes  yPlane[ySize]
    ///   bytes  uvPlane[uvSize]
    /// </summary>
    [Register("SampleHandler")]
    public class SampleHandler : RPBroadcastSampleHandler
    {
        private const string AppGroupId = "group.com.visioforge.screencapture";
        private const string SocketFilename = "broadcast.sock";
        private const uint FrameMagic = 0x5646524D; // 'VFRM'
        // Bump whenever any field is added/removed/renumbered or its semantics change. The
        // receiver rejects frames with an unknown version instead of mis-parsing them.
        private const byte ProtocolVersion = 1;
        private const int HeaderSize = 52;
        private const uint FormatNV12 = 1;

        // POSIX constants for macOS / iOS.
        private const int AF_UNIX = 1;
        private const int SOCK_STREAM = 1;

        // Darwin socket option values for disabling SIGPIPE on send() to a disconnected peer.
        // Without SO_NOSIGPIPE, writing to a socket whose peer closed terminates the whole
        // broadcast-extension process (iOS delivers SIGPIPE and the default action is Term).
        private const int SOL_SOCKET = 0xffff;
        private const int SO_NOSIGPIPE = 0x1022;

        // Darwin errno values we care about.
        private const int EINTR = 4;

        // Rate limit for retrying the Unix-socket connect() after a failure. If the main
        // app wasn't running at BroadcastStarted, connect returns ENOENT and we'd otherwise
        // drop every subsequent frame forever. Try again at most once per this interval.
        private static readonly TimeSpan ConnectRetryInterval = TimeSpan.FromSeconds(2);

        // Volatile so the unlocked fast-path read in ProcessSampleBuffer sees an up-to-date
        // value instead of a cached register copy on ARM. Authoritative read/write still
        // happens inside _sockLock so the fd can't be closed while SendAll is mid-write.
        private volatile int _sockFd = -1;
        private readonly object _sockLock = new object();

        // Guards ConnectSocket against being entered concurrently from TryReconnect and
        // BroadcastStarted. Without this flag, an iOS 18 race where the first frame arrives
        // before BroadcastStarted completes could have TryReconnect release the lock after
        // setting _lastConnectTicks, then BroadcastStarted's ConnectSocket runs in parallel —
        // two sockets, only one stored in _sockFd, the other fd leaks for the lifetime of
        // the extension's ~50 MB memory budget.
        private bool _connecting;

        // Monotonic timestamp (ticks from Environment.TickCount64) of the last connect attempt,
        // read/written under _sockLock.
        private long _lastConnectTicks;

        // Cached AppGroupId from BroadcastStarted's setupInfo when the host passes one via the
        // picker, falling back to the compile-time default. setupInfo keys are controlled by
        // the broadcast picker in the host app, so we let the host override without recompiling
        // the extension.
        private string _activeAppGroupId = AppGroupId;

        public override void BroadcastStarted(NSDictionary<NSString, NSObject> setupInfo)
        {
            // The host app can pass a custom App Group ID through the broadcast picker's
            // setupInfo dictionary (under the "AppGroupId" key). Fall back to the compile-time
            // default so existing hosts keep working without changes.
            if (setupInfo != null)
            {
                using (var key = new NSString("AppGroupId"))
                {
                    if (setupInfo.TryGetValue(key, out var value) && value is NSString nsOverride)
                    {
                        var overrideId = nsOverride.ToString();
                        // Validate the override before using it. GetContainerUrl returns null
                        // for invalid ids so there's no filesystem escape, but App Group ids
                        // are a well-defined shape (group.<reverse-dns>, no path separators,
                        // reasonable length) — an out-of-spec value is almost certainly a
                        // misconfigured host and we'd rather fall back to the compile-time
                        // default than re-try on every sample.
                        if (!string.IsNullOrEmpty(overrideId)
                            && overrideId.Length < 100
                            && overrideId.StartsWith("group.", StringComparison.Ordinal)
                            && overrideId.IndexOfAny(new[] { '/', '\\', '\0' }) < 0)
                        {
                            _activeAppGroupId = overrideId;
                        }
                        else
                        {
                            Debug.WriteLine($"[SampleHandler] ignoring invalid AppGroupId override '{overrideId}', using default.");
                        }
                    }
                }
            }

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
                // Main app wasn't running at BroadcastStarted / peer vanished. Retry the
                // connect() periodically so we recover instead of dropping every subsequent
                // frame forever.
                TryReconnect();
                if (_sockFd < 0)
                {
                    return;
                }
            }

            try
            {
                // Capture the raw CVImageBuffer first so the NSObject peer is always
                // Disposed, even when the `as CVPixelBuffer` cast fails. Previously the
                // `using` only bound the cast result — a non-CVPixelBuffer subclass (other
                // CVImageBuffer shapes) returned null from the cast and leaked the original
                // wrapper once per sample.
                using var imageBuffer = sampleBuffer.GetImageBuffer();
                if (imageBuffer is not CVPixelBuffer pixelBuffer)
                {
                    return;
                }

                {
                    // Only NV12 is negotiated with ReplayKit by default.
                    var pixelFormat = pixelBuffer.PixelFormatType;
                    if (pixelFormat != CVPixelFormatType.CV420YpCbCr8BiPlanarVideoRange &&
                        pixelFormat != CVPixelFormatType.CV420YpCbCr8BiPlanarFullRange)
                    {
                        return;
                    }

                    // Check Lock's CVReturn before entering the try — if Lock fails, Unlock
                    // in finally would underflow the refcount and crash.
                    var lockResult = pixelBuffer.Lock(CVPixelBufferLock.ReadOnly);
                    if (lockResult != CVReturn.Success)
                    {
                        Debug.WriteLine($"[SampleHandler] CVPixelBuffer.Lock failed: {lockResult}");
                        return;
                    }

                    try
                    {
                        var width = (uint)pixelBuffer.Width;
                        var height = (uint)pixelBuffer.Height;
                        var yStride = (uint)pixelBuffer.GetBytesPerRowOfPlane(0);
                        var uvStride = (uint)pixelBuffer.GetBytesPerRowOfPlane(1);
                        var ySize = yStride * height;
                        // Ceiling division: NV12's chroma plane has ceil(height/2) rows.
                        // Truncating with `height / 2` underreports by one row when height
                        // is odd (iPhone portrait/landscape frames are routinely odd-height
                        // after rotation), which makes the receiver's size guard drop the
                        // connection. Receiver computes the same ceiling expression — both
                        // sides MUST stay in sync.
                        var uvSize = uvStride * ((height + 1) / 2);
                        var yBase = pixelBuffer.GetBaseAddress(0);
                        var uvBase = pixelBuffer.GetBaseAddress(1);
                        if (yBase == IntPtr.Zero || uvBase == IntPtr.Zero)
                        {
                            // Should not happen after a successful Lock(ReadOnly), but send()
                            // with IntPtr.Zero would segfault the extension — bail safely.
                            Debug.WriteLine("[SampleHandler] GetBaseAddress returned Zero after successful Lock");
                            return;
                        }

                        var ptsNs = CMTimeToNanoseconds(sampleBuffer.PresentationTimeStamp, fallbackNs: 0);
                        var durationNs = CMTimeToNanoseconds(sampleBuffer.Duration, fallbackNs: 1_000_000_000L / 60);

                        // Build the 52-byte header on the stack. Layout matches the protocol
                        // docblock above; stackalloc is zero-initialised so the reserved[3]
                        // padding at offsets 5-7 is already 0 without an explicit write.
                        Span<byte> header = stackalloc byte[HeaderSize];
                        WriteUInt32LE(header.Slice(0, 4), FrameMagic);
                        header[4] = ProtocolVersion; // reserved[3] at 5-7 stays zero
                        WriteUInt32LE(header.Slice(8, 4), width);
                        WriteUInt32LE(header.Slice(12, 4), height);
                        WriteUInt32LE(header.Slice(16, 4), FormatNV12);
                        WriteInt64LE(header.Slice(20, 8), ptsNs);
                        WriteInt64LE(header.Slice(28, 8), durationNs);
                        WriteUInt32LE(header.Slice(36, 4), yStride);
                        WriteUInt32LE(header.Slice(40, 4), uvStride);
                        WriteUInt32LE(header.Slice(44, 4), ySize);
                        WriteUInt32LE(header.Slice(48, 4), uvSize);

                        lock (_sockLock)
                        {
                            // Capture the fd under the lock so a concurrent CloseSocket can't
                            // close-and-recycle the kernel fd number while we're mid-send on it.
                            int fd = _sockFd;
                            if (fd < 0)
                            {
                                return;
                            }

                            if (!SendAll(fd, header) ||
                                !SendRegion(fd, yBase, (int)ySize) ||
                                !SendRegion(fd, uvBase, (int)uvSize))
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
                Debug.WriteLine("[SampleHandler] " + ex.Message);
            }
        }

        /// <summary>
        /// Convert a CMTime into nanoseconds using integer math, avoiding the precision loss
        /// and jitter of going through double. Returns <paramref name="fallbackNs"/> when the
        /// CMTime is invalid or timescale is zero.
        /// </summary>
        private static long CMTimeToNanoseconds(CMTime t, long fallbackNs)
        {
            // TimeScale == 0 is the invalid/indefinite sentinel across CMTime constants
            // (CMTimeInvalid, CMTimePositiveInfinity, CMTimeNegativeInfinity, CMTimeIndefinite
            // all have TimeScale == 0). Any sensible sample-buffer PTS has TimeScale > 0.
            if (t.TimeScale <= 0)
            {
                return fallbackNs;
            }

            // ns = value * 1e9 / timescale. Direct multiplication overflows when
            // t.Value > long.MaxValue / 1e9 (~9.2 seconds at a nanosecond timescale).
            // Split into quotient + remainder so the result stays exact in signed 64-bit
            // without going through double.
            long value = t.Value;
            int scale = t.TimeScale;
            long q = value / scale;
            long r = value % scale;
            return q * 1_000_000_000L + r * 1_000_000_000L / scale;
        }

        /// <summary>
        /// Attempt to re-establish the Unix-socket connection, bounded to at most one try
        /// every <see cref="ConnectRetryInterval"/>.
        /// </summary>
        private void TryReconnect()
        {
            lock (_sockLock)
            {
                if (_sockFd >= 0 || _connecting)
                {
                    return;
                }

                var now = Environment.TickCount64;
                if (_lastConnectTicks != 0 && now - _lastConnectTicks < (long)ConnectRetryInterval.TotalMilliseconds)
                {
                    return;
                }

                _lastConnectTicks = now;
                _connecting = true;
            }

            try
            {
                ConnectSocket();
            }
            finally
            {
                lock (_sockLock)
                {
                    _connecting = false;
                }
            }
        }

        private void ConnectSocket()
        {
            var socketPath = ResolveSocketPath();
            if (socketPath == null)
            {
                Debug.WriteLine($"[SampleHandler] App Group container '{_activeAppGroupId}' is not accessible — check that the entitlement is present in both the extension and the host app.");
                return;
            }

            int fd = socket(AF_UNIX, SOCK_STREAM, 0);
            if (fd < 0)
            {
                Debug.WriteLine($"[SampleHandler] socket() failed, errno={Marshal.GetLastPInvokeError()}");
                return;
            }

            // Disable SIGPIPE on this socket. A broadcast extension peer (the host app)
            // can vanish at any time; without SO_NOSIGPIPE the first send() after that
            // terminates the extension with SIGPIPE instead of returning EPIPE. If this
            // option can't be set we MUST NOT proceed — send() would kill the extension.
            int nosigpipe = 1;
            int setsockRc;
            unsafe
            {
                setsockRc = setsockopt(fd, SOL_SOCKET, SO_NOSIGPIPE, &nosigpipe, (uint)sizeof(int));
            }
            if (setsockRc != 0)
            {
                Debug.WriteLine($"[SampleHandler] setsockopt(SO_NOSIGPIPE) failed, errno={Marshal.GetLastPInvokeError()} — aborting to avoid SIGPIPE termination on peer close.");
                close(fd);
                return;
            }

            // sockaddr_un is 106 bytes on Darwin (sun_len, sun_family, sun_path[104]).
            var addr = new byte[106];
            addr[0] = 106; // sun_len
            addr[1] = AF_UNIX;
            var pathBytes = System.Text.Encoding.UTF8.GetBytes(socketPath);
            if (pathBytes.Length >= 104)
            {
                Debug.WriteLine($"[SampleHandler] socket path too long ({pathBytes.Length} bytes): {socketPath}");
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
                // ENOENT is expected when the main app isn't running — ProcessSampleBuffer
                // will retry via TryReconnect.
                Debug.WriteLine($"[SampleHandler] connect({socketPath}) failed, errno={Marshal.GetLastPInvokeError()}");
                close(fd);
                return;
            }

            lock (_sockLock)
            {
                if (_sockFd >= 0)
                {
                    // Lost the race with another ConnectSocket call — keep the already-stored
                    // fd and close the one we just connected instead of leaking it.
                    close(fd);
                    return;
                }

                _sockFd = fd;
                _lastConnectTicks = Environment.TickCount64;
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

        private bool SendAll(int fd, ReadOnlySpan<byte> data)
        {
            unsafe
            {
                fixed (byte* p = data)
                {
                    return SendAll(fd, (IntPtr)p, data.Length);
                }
            }
        }

        private bool SendRegion(int fd, IntPtr src, int size)
        {
            return SendAll(fd, src, size);
        }

        private bool SendAll(int fd, IntPtr data, int size)
        {
            var remaining = size;
            var ptr = data;
            while (remaining > 0)
            {
                // MSG_NOSIGNAL isn't defined on Darwin; the socket is opened with SO_NOSIGPIPE
                // in ConnectSocket() so send() returns EPIPE instead of terminating the process.
                var sent = send(fd, ptr, (UIntPtr)remaining, 0);
                if (sent < 0)
                {
                    // EINTR: a signal interrupted the call before any bytes were sent — retry.
                    // Other errors (EPIPE, ECONNRESET, ...) are fatal for this connection.
                    var err = Marshal.GetLastPInvokeError();
                    if (err == EINTR)
                    {
                        continue;
                    }

                    Debug.WriteLine($"[SampleHandler] send() failed, errno={err}");
                    return false;
                }
                // Per POSIX, send() on a SOCK_STREAM socket with a non-zero len never
                // returns 0 — success returns > 0, failure returns -1 with errno set.
                // No branch needed here: sent > 0 is the only remaining case.
                Debug.Assert(sent > 0, "send() returned 0 on SOCK_STREAM with nonzero len");
                ptr = IntPtr.Add(ptr, (int)sent);
                remaining -= (int)sent;
            }
            return true;
        }

        private string ResolveSocketPath()
        {
            // Dispose the NSUrl each call: in a memory-capped (~50 MB) broadcast extension
            // we can be called every 2 seconds from TryReconnect while the host app isn't
            // running, and leaking a native URL object per attempt eventually kills the
            // extension with the 50 MB OOM.
            using var container = NSFileManager.DefaultManager.GetContainerUrl(_activeAppGroupId);
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
        // SetLastError=true so Marshal.GetLastPInvokeError() surfaces errno for diagnostics.
        [DllImport("libSystem", EntryPoint = "socket", SetLastError = true)]
        private static extern int socket(int domain, int type, int protocol);

        [DllImport("libSystem", EntryPoint = "connect", SetLastError = true)]
        private static extern unsafe int connect(int sockfd, byte* addr, uint addrlen);

        [DllImport("libSystem", EntryPoint = "send", SetLastError = true)]
        private static extern nint send(int sockfd, IntPtr buf, UIntPtr len, int flags);

        [DllImport("libSystem", EntryPoint = "close", SetLastError = true)]
        private static extern int close(int fd);

        [DllImport("libSystem", EntryPoint = "setsockopt", SetLastError = true)]
        private static extern unsafe int setsockopt(int sockfd, int level, int optname, void* optval, uint optlen);

        /// <summary>
        /// Defensive cleanup. If the extension is torn down abnormally without
        /// BroadcastFinished being invoked, the socket fd would otherwise leak until the
        /// process exits.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                CloseSocket();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[SampleHandler] Dispose CloseSocket failed: " + ex.Message);
            }

            base.Dispose(disposing);
        }
    }
}
