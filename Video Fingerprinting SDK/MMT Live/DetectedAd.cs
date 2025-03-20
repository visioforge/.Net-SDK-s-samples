using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisioForge_MMT_Live
{
    /// <summary>
    /// Detected ad.
    /// </summary>
    public class DetectedAd
    {
        /// <summary>
        /// Gets or sets timestamp.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets unique ad ID (Guid format).
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectedAd"/> class.
        /// </summary>
        public DetectedAd(DateTime timestamp)
        {
            Timestamp = timestamp;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DetectedAd"/> class.
        /// </summary>
        public DetectedAd()
        {
        }
    }
}
