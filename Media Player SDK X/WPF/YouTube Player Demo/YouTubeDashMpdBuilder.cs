using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using YoutubeDLSharp.Metadata;

namespace youtube_player_x
{
    /// <summary>
    /// Builds a synthetic DASH OnDemand MPD for a YouTube format URL so GStreamer's
    /// <c>dashdemux2</c> can handle seeking on fragmented MP4 streams that YouTube
    /// otherwise serves as single-file DASH fragments through plain https byte ranges.
    /// yt-dlp's current extractors do not expose a <c>manifest_url</c> for YouTube, so
    /// we probe the first few hundred kilobytes of the fragment, locate the <c>moov</c>
    /// and <c>sidx</c> boxes, and emit a one-period MPD whose <c>BaseURL</c> points at
    /// the original https URL and whose <c>SegmentBase</c>/<c>indexRange</c> delegates
    /// random access to <c>sidx</c>.
    /// </summary>
    public static class YouTubeDashMpdBuilder
    {
        private const long ProbeRangeBytes = 262144; // 256 KB is enough for every YouTube fragment observed so far.

        private static readonly HttpClient _http = CreateHttpClient();

        private static HttpClient CreateHttpClient()
        {
            var c = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30),
            };
            // googlevideo accepts a plain UA; using a realistic desktop Chrome one avoids
            // any client-class downgrades (ANDROID_VR-flavoured responses strip sidx).
            c.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/127.0.0.0 Safari/537.36");
            return c;
        }

        /// <summary>
        /// Probes the given YouTube video (and optional audio) format, writes a DASH
        /// OnDemand MPD to a temp file, and returns its path. Returns <c>null</c> when
        /// probing or parsing fails so the caller can fall back to the direct URL.
        /// </summary>
        public static async Task<string> BuildMpdAsync(
            FormatData video,
            FormatData audio,
            TimeSpan duration,
            CancellationToken ct)
        {
            if (video == null || string.IsNullOrEmpty(video.Url))
            {
                return null;
            }

            var videoRanges = await ProbeMp4Async(video.Url, ct);
            if (videoRanges == null)
            {
                return null;
            }

            Mp4Ranges audioRanges = null;
            if (audio != null && !string.IsNullOrEmpty(audio.Url))
            {
                audioRanges = await ProbeMp4Async(audio.Url, ct);
                if (audioRanges == null)
                {
                    // Audio probe failed but video succeeded — fall back gracefully by
                    // dropping audio from the MPD. dashdemux2 will still drive video seek.
                    audio = null;
                }
            }

            if (duration <= TimeSpan.Zero)
            {
                duration = TryParseDurFromUrl(video.Url) ?? TimeSpan.FromSeconds(1);
            }

            var path = Path.Combine(Path.GetTempPath(), $"visioforge-yt-dash-{Guid.NewGuid():N}.mpd");
            // Write directly to the file stream so XmlWriter emits encoding="utf-8" in the
            // XML declaration. Going through a StringBuilder would make the declaration say
            // utf-16 (because .NET strings are UTF-16) while the bytes on disk are UTF-8,
            // and GStreamer's mpdparser rejects the file as "Invalid manifest".
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                WriteMpdXml(fs, video, videoRanges, audio, audioRanges, duration);
            }

            return path;
        }

        private static async Task<Mp4Ranges> ProbeMp4Async(string url, CancellationToken ct)
        {
            try
            {
                using var req = new HttpRequestMessage(HttpMethod.Get, url);
                req.Headers.Range = new RangeHeaderValue(0, ProbeRangeBytes - 1);
                using var resp = await _http.SendAsync(req, HttpCompletionOption.ResponseContentRead, ct);
                if (!resp.IsSuccessStatusCode)
                {
                    return null;
                }

                // ReadAsByteArrayAsync(CancellationToken) is .NET 5+ only; the parameterless
                // overload is portable back to net472. The 30s HttpClient timeout still caps
                // the wait if the caller's token fires.
                var data = await resp.Content.ReadAsByteArrayAsync();
                return ParseMp4Ranges(data);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Walks the ISO BMFF top-level box list in <paramref name="data"/> and returns the
        /// inclusive byte ranges of <c>moov</c> and <c>sidx</c>. Returns <c>null</c> if either
        /// is missing or truncated by the probe window.
        /// </summary>
        private static Mp4Ranges ParseMp4Ranges(byte[] data)
        {
            long offset = 0;
            long len = data.Length;
            long moovEnd = -1;
            long sidxStart = -1;
            long sidxEnd = -1;

            while (offset + 8 <= len)
            {
                uint size32 = ReadUInt32BigEndian(data, (int)offset);
                string type = Encoding.ASCII.GetString(data, (int)offset + 4, 4);

                long boxSize;
                if (size32 == 1)
                {
                    if (offset + 16 > len)
                    {
                        break;
                    }

                    ulong size64 = ReadUInt64BigEndian(data, (int)offset + 8);
                    if (size64 < 16)
                    {
                        break;
                    }

                    boxSize = (long)size64;
                }
                else if (size32 == 0)
                {
                    // Extends to EOF — we can't compute an end within the probe window.
                    break;
                }
                else if (size32 < 8)
                {
                    break;
                }
                else
                {
                    boxSize = size32;
                }

                if (boxSize <= 0)
                {
                    break;
                }

                long boxEnd = offset + boxSize - 1;

                if (type == "moov")
                {
                    // moov must be fully inside the probe window so we can set Initialization
                    // range = [0, moovEnd]. If it straddles the window, bail out.
                    if (offset + boxSize > len)
                    {
                        return null;
                    }

                    moovEnd = boxEnd;
                }
                else if (type == "sidx")
                {
                    if (offset + boxSize > len)
                    {
                        return null;
                    }

                    sidxStart = offset;
                    sidxEnd = boxEnd;
                }

                if (moovEnd >= 0 && sidxStart >= 0)
                {
                    break;
                }

                offset += boxSize;
            }

            if (moovEnd < 0 || sidxStart < 0)
            {
                return null;
            }

            return new Mp4Ranges(moovEnd, sidxStart, sidxEnd);
        }

        /// <summary>
        /// Reads a 32-bit big-endian unsigned integer from <paramref name="data"/> at the
        /// given offset. Plain arithmetic so the code compiles on net472 without pulling
        /// in <c>System.Memory</c> for <see cref="System.Buffers.Binary.BinaryPrimitives"/>.
        /// </summary>
        private static uint ReadUInt32BigEndian(byte[] data, int offset)
        {
            return ((uint)data[offset] << 24)
                | ((uint)data[offset + 1] << 16)
                | ((uint)data[offset + 2] << 8)
                | data[offset + 3];
        }

        /// <summary>
        /// Reads a 64-bit big-endian unsigned integer from <paramref name="data"/> at the
        /// given offset.
        /// </summary>
        private static ulong ReadUInt64BigEndian(byte[] data, int offset)
        {
            ulong hi = ReadUInt32BigEndian(data, offset);
            ulong lo = ReadUInt32BigEndian(data, offset + 4);
            return (hi << 32) | lo;
        }

        private static TimeSpan? TryParseDurFromUrl(string url)
        {
            try
            {
                var uri = new Uri(url);
                var query = uri.Query;
                if (string.IsNullOrEmpty(query))
                {
                    return null;
                }

                foreach (var pair in query.TrimStart('?').Split('&'))
                {
                    var eq = pair.IndexOf('=');
                    if (eq <= 0)
                    {
                        continue;
                    }

                    if (!string.Equals(pair.Substring(0, eq), "dur", StringComparison.Ordinal))
                    {
                        continue;
                    }

                    var val = Uri.UnescapeDataString(pair.Substring(eq + 1));
                    if (double.TryParse(val, NumberStyles.Float, CultureInfo.InvariantCulture, out var d) && d > 0)
                    {
                        return TimeSpan.FromSeconds(d);
                    }
                }
            }
            catch
            {
                // bad URL or missing query — fall through to null
            }

            return null;
        }

        private static void WriteMpdXml(
            Stream output,
            FormatData video, Mp4Ranges v,
            FormatData audio, Mp4Ranges a,
            TimeSpan duration)
        {
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = new UTF8Encoding(false),
                CloseOutput = false,
            };

            using var w = XmlWriter.Create(output, settings);
            w.WriteStartDocument();
            w.WriteStartElement("MPD", "urn:mpeg:dash:schema:mpd:2011");
            w.WriteAttributeString("type", "static");
            w.WriteAttributeString("mediaPresentationDuration", IsoDuration(duration));
            w.WriteAttributeString("minBufferTime", "PT2S");
            w.WriteAttributeString("profiles", "urn:mpeg:dash:profile:isoff-on-demand:2011");

            w.WriteStartElement("Period");

            WriteVideoAdaptationSet(w, video, v);
            if (audio != null && a != null)
            {
                WriteAudioAdaptationSet(w, audio, a);
            }

            w.WriteEndElement(); // Period
            w.WriteEndElement(); // MPD
            w.WriteEndDocument();
        }

        private static void WriteVideoAdaptationSet(XmlWriter w, FormatData f, Mp4Ranges r)
        {
            w.WriteStartElement("AdaptationSet");
            w.WriteAttributeString("mimeType", GuessVideoMimeType(f));
            w.WriteAttributeString("segmentAlignment", "true");

            w.WriteStartElement("Representation");
            w.WriteAttributeString("id", "video");
            w.WriteAttributeString("bandwidth", ComputeBandwidth(f.VideoBitrate, f.Bitrate, 1_000_000).ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(f.VideoCodec) && f.VideoCodec != "none")
            {
                w.WriteAttributeString("codecs", f.VideoCodec);
            }

            if (f.Width.HasValue && f.Width.Value > 0)
            {
                w.WriteAttributeString("width", f.Width.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (f.Height.HasValue && f.Height.Value > 0)
            {
                w.WriteAttributeString("height", f.Height.Value.ToString(CultureInfo.InvariantCulture));
            }

            w.WriteElementString("BaseURL", f.Url);
            WriteSegmentBase(w, r);

            w.WriteEndElement(); // Representation
            w.WriteEndElement(); // AdaptationSet
        }

        private static void WriteAudioAdaptationSet(XmlWriter w, FormatData f, Mp4Ranges r)
        {
            w.WriteStartElement("AdaptationSet");
            w.WriteAttributeString("mimeType", GuessAudioMimeType(f));
            w.WriteAttributeString("segmentAlignment", "true");

            w.WriteStartElement("Representation");
            w.WriteAttributeString("id", "audio");
            w.WriteAttributeString("bandwidth", ComputeBandwidth(f.AudioBitrate, f.Bitrate, 128_000).ToString(CultureInfo.InvariantCulture));

            if (!string.IsNullOrEmpty(f.AudioCodec) && f.AudioCodec != "none")
            {
                w.WriteAttributeString("codecs", f.AudioCodec);
            }

            if (f.AudioSamplingRate.HasValue && f.AudioSamplingRate.Value > 0)
            {
                w.WriteAttributeString(
                    "audioSamplingRate",
                    ((int)f.AudioSamplingRate.Value).ToString(CultureInfo.InvariantCulture));
            }

            if (f.AudioChannels.HasValue && f.AudioChannels.Value > 0)
            {
                w.WriteStartElement("AudioChannelConfiguration");
                w.WriteAttributeString("schemeIdUri", "urn:mpeg:dash:23003:3:audio_channel_configuration:2011");
                w.WriteAttributeString("value", f.AudioChannels.Value.ToString(CultureInfo.InvariantCulture));
                w.WriteEndElement();
            }

            w.WriteElementString("BaseURL", f.Url);
            WriteSegmentBase(w, r);

            w.WriteEndElement(); // Representation
            w.WriteEndElement(); // AdaptationSet
        }

        private static void WriteSegmentBase(XmlWriter w, Mp4Ranges r)
        {
            w.WriteStartElement("SegmentBase");
            w.WriteAttributeString(
                "indexRange",
                r.SidxStart.ToString(CultureInfo.InvariantCulture) + "-" + r.SidxEnd.ToString(CultureInfo.InvariantCulture));
            w.WriteAttributeString("indexRangeExact", "true");
            w.WriteStartElement("Initialization");
            w.WriteAttributeString("range", "0-" + r.MoovEnd.ToString(CultureInfo.InvariantCulture));
            w.WriteEndElement(); // Initialization
            w.WriteEndElement(); // SegmentBase
        }

        private static int ComputeBandwidth(double? primary, double? fallback, int defaultBps)
        {
            double kbps = 0;
            if (primary.HasValue && primary.Value > 0)
            {
                kbps = primary.Value;
            }
            else if (fallback.HasValue && fallback.Value > 0)
            {
                kbps = fallback.Value;
            }

            return kbps <= 0 ? defaultBps : (int)(kbps * 1000);
        }

        private static string GuessVideoMimeType(FormatData f)
        {
            var ext = f.Extension?.ToLowerInvariant();
            return ext == "webm" ? "video/webm" : "video/mp4";
        }

        private static string GuessAudioMimeType(FormatData f)
        {
            var ext = f.Extension?.ToLowerInvariant();
            return ext == "webm" || ext == "weba" ? "audio/webm" : "audio/mp4";
        }

        private static string IsoDuration(TimeSpan t)
        {
            var secs = Math.Max(0.001, t.TotalSeconds);
            return "PT" + secs.ToString("0.###", CultureInfo.InvariantCulture) + "S";
        }

        private sealed class Mp4Ranges
        {
            public long MoovEnd { get; }
            public long SidxStart { get; }
            public long SidxEnd { get; }

            public Mp4Ranges(long moovEnd, long sidxStart, long sidxEnd)
            {
                MoovEnd = moovEnd;
                SidxStart = sidxStart;
                SidxEnd = sidxEnd;
            }
        }
    }
}
