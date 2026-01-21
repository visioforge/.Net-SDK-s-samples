using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core.VideoFingerPrinting;

namespace VisioForge_MMT_Live
{
    public class FingerprintLiveData : IDisposable
    {
        /// <summary>
        /// The data.
        /// </summary>
        public VFPSearchData Data;

        /// <summary>
        /// Gets the start time.
        /// </summary>
        public DateTime StartTime { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FingerprintLiveData"/> class.
        /// </summary>
        /// <param name="duration">The duration.</param>
        /// <param name="startTime">The start time.</param>
        public FingerprintLiveData(TimeSpan duration, DateTime startTime)
        {
            Data = new VFPSearchData(duration);
            StartTime = startTime;
        }

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();

            if (disposing)
            {
                Data?.Dispose();
            }
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FingerprintLiveData()
        {
            Dispose(false);
        }
    }
}
