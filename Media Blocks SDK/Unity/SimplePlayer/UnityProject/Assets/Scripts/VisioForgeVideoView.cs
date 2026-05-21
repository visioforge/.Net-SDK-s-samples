using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using VisioForge.Core.Types.Events;

namespace VisioForge.Unity
{
    /// <summary>How the video frame is fitted into the target RawImage.</summary>
    public enum VideoViewAspectMode
    {
        /// <summary>Fill the whole RawImage, ignoring the source aspect ratio (may distort).</summary>
        Stretch,

        /// <summary>Fit inside the RawImage preserving aspect; empty bars on the spare axis.</summary>
        Letterbox,

        /// <summary>Fill the RawImage preserving aspect; the overflowing edges are cropped.</summary>
        Crop
    }

    /// <summary>
    /// Reusable Unity "video view": renders VisioForge MediaBlocks <see cref="BufferSinkBlock"/>
    /// RGBA frames into a <see cref="RawImage"/>'s <see cref="Texture2D"/>. The SDK's UI layers
    /// ship a native VideoView control per platform; this is the Unity equivalent so samples
    /// don't re-implement the texture plumbing.
    ///
    /// - Zero per-frame allocation: frames are copied into a reused double buffer on the
    ///   GStreamer thread and swapped to the texture on the Unity main thread. (Allocating a
    ///   fresh array per frame drives Unity's GC hard enough to crash the Editor via the
    ///   GLib.Object finalizer race.)
    /// - Vertical flip: GStreamer rows are top-to-bottom, Unity textures bottom-to-top.
    /// - Aspect handling: Stretch / Letterbox / Crop via the RawImage RectTransform + uvRect.
    ///
    /// Usage:
    ///   _view = new VisioForgeVideoView(GetComponent&lt;RawImage&gt;(), VideoViewAspectMode.Letterbox);
    ///   bufferSink.OnVideoFrameBuffer += _view.OnFrameBuffer;   // wire the sink
    ///   void Update() => _view.Update();                        // pump on the main thread
    ///   void OnDestroy() => _view.Dispose();
    /// </summary>
    public sealed class VisioForgeVideoView
    {
        private readonly RawImage _rawImage;
        private readonly RectTransform _rect;
        private Texture2D _texture;

        private byte[] _backBuffer;
        private byte[] _frontBuffer;
        private readonly object _bufferLock = new object();
        private volatile bool _frameDirty;
        private int _frameByteCount;
        private int _frameWidth;
        private int _frameHeight;

        // Layout cache so the RectTransform/uvRect are only recomputed when something changes.
        private int _laidOutW, _laidOutH;
        private float _laidOutPW, _laidOutPH;
        private VideoViewAspectMode _laidOutMode = (VideoViewAspectMode)(-1);

        private volatile bool _disposed;

        /// <summary>Fit mode. Changing it re-applies layout on the next <see cref="Update"/>.</summary>
        public VideoViewAspectMode AspectMode { get; set; }

        /// <summary>The texture the frames are uploaded into (for advanced use).</summary>
        public Texture2D Texture => _texture;

        public VisioForgeVideoView(RawImage target, VideoViewAspectMode aspectMode = VideoViewAspectMode.Letterbox)
        {
            _rawImage = target != null ? target : throw new ArgumentNullException(nameof(target));
            _rect = _rawImage.rectTransform;
            AspectMode = aspectMode;

            _rawImage.color = Color.white;
            _texture = new Texture2D(2, 2, TextureFormat.RGBA32, false);
            _rawImage.texture = _texture;
        }

        /// <summary>
        /// Frame callback for <c>BufferSinkBlock.OnVideoFrameBuffer</c>. Runs on the GStreamer
        /// streaming thread — copies the frame into the back buffer, no Unity API calls here.
        /// </summary>
        public void OnFrameBuffer(object sender, VideoFrameXBufferEventArgs e)
        {
            if (_disposed || e.Frame == null)
                return;

            var frame = e.Frame;
            int size = frame.DataSize;
            if (size <= 0 || frame.Data == IntPtr.Zero)
                return;

            lock (_bufferLock)
            {
                if (_backBuffer == null || _backBuffer.Length != size)
                    _backBuffer = new byte[size];

                Marshal.Copy(frame.Data, _backBuffer, 0, size);
                _frameByteCount = size;
                _frameWidth = frame.Width;
                _frameHeight = frame.Height;
                _frameDirty = true;
            }
        }

        /// <summary>Pump the latest frame to the texture. Call from a MonoBehaviour's Update().</summary>
        public void Update()
        {
            if (_disposed)
                return;

            byte[] toUpload = null;
            int width = 0, height = 0, count = 0;

            lock (_bufferLock)
            {
                if (_frameDirty)
                {
                    var tmp = _frontBuffer;
                    _frontBuffer = _backBuffer;
                    _backBuffer = tmp;

                    toUpload = _frontBuffer;
                    count = _frameByteCount;
                    width = _frameWidth;
                    height = _frameHeight;
                    _frameDirty = false;
                }
            }

            // Guard zero/invalid dimensions too: Texture2D.Reinitialize throws on a 0 dimension,
            // and LoadRawTextureData would mismatch the buffer size.
            if (toUpload == null || count <= 0 || width <= 0 || height <= 0)
                return;

            if (_texture.width != width || _texture.height != height)
                _texture.Reinitialize(width, height);

            _texture.LoadRawTextureData(toUpload);
            _texture.Apply(updateMipmaps: false);

            ApplyLayout(width, height);
        }

        private void ApplyLayout(int texW, int texH)
        {
            var parent = _rect.parent as RectTransform;
            float pw = parent != null ? parent.rect.width : texW;
            float ph = parent != null ? parent.rect.height : texH;
            if (pw <= 0f || ph <= 0f || texW <= 0 || texH <= 0)
                return;

            if (texW == _laidOutW && texH == _laidOutH && AspectMode == _laidOutMode
                && Mathf.Approximately(pw, _laidOutPW) && Mathf.Approximately(ph, _laidOutPH))
                return;

            _laidOutW = texW; _laidOutH = texH; _laidOutMode = AspectMode;
            _laidOutPW = pw; _laidOutPH = ph;

            // Base UV flips V (GStreamer top-down → Unity bottom-up).
            Rect uv = new Rect(0f, 1f, 1f, -1f);
            float videoAspect = (float)texW / texH;
            float parentAspect = pw / ph;

            switch (AspectMode)
            {
                case VideoViewAspectMode.Stretch:
                    FillParent();
                    break;

                case VideoViewAspectMode.Letterbox:
                    _rect.anchorMin = _rect.anchorMax = new Vector2(0.5f, 0.5f);
                    _rect.pivot = new Vector2(0.5f, 0.5f);
                    if (videoAspect > parentAspect)
                        _rect.sizeDelta = new Vector2(pw, pw / videoAspect);
                    else
                        _rect.sizeDelta = new Vector2(ph * videoAspect, ph);
                    break;

                case VideoViewAspectMode.Crop:
                    FillParent();
                    if (videoAspect > parentAspect)
                    {
                        // Video wider than the view → crop left/right.
                        float vis = parentAspect / videoAspect;
                        uv = new Rect((1f - vis) / 2f, 1f, vis, -1f);
                    }
                    else
                    {
                        // Video taller than the view → crop top/bottom.
                        float vis = videoAspect / parentAspect;
                        uv = new Rect(0f, 1f - (1f - vis) / 2f, 1f, -vis);
                    }
                    break;
            }

            _rawImage.uvRect = uv;
        }

        private void FillParent()
        {
            _rect.anchorMin = Vector2.zero;
            _rect.anchorMax = Vector2.one;
            _rect.offsetMin = Vector2.zero;
            _rect.offsetMax = Vector2.zero;
        }

        public void Dispose()
        {
            _disposed = true;

            // Detach from the RawImage before destroying the texture, otherwise a RawImage
            // that outlives this view keeps rendering a destroyed texture ("Can't use a
            // destroyed texture" spam).
            if (_rawImage != null)
                _rawImage.texture = null;

            if (_texture != null)
            {
                UnityEngine.Object.Destroy(_texture);
                _texture = null;
            }
        }
    }
}
