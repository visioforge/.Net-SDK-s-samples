using System.Drawing;

namespace Video_Mixing_Demo
{
    /// <summary>
    /// PIP info.
    /// </summary>
    public class PIPInfo
    {
        /// <summary>
        /// Gets or sets the filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets the rectangle.
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// Gets or sets the Z order.
        /// </summary>
        public int ZOrder { get; set; }

        /// <summary>
        /// Gets or sets the alpha.
        /// </summary>
        public float Alpha { get; set; }
    }
}
