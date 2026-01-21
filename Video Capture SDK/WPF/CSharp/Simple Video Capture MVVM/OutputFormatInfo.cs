namespace Simple_Video_Capture
{
    /// <summary>
    /// Output format info.
    /// </summary>
    public class OutputFormatInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFormatInfo"/> class.
        /// </summary>
        /// <param name="tag">Tag.</param>
        /// <param name="description">Description.</param>
        /// <param name="extension">Extension.</param>
        public OutputFormatInfo(OutputFormatInfoTag tag, string description, string extension)
        {
            Tag = tag;
            Description = description;
            Extension = extension;
        }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        public OutputFormatInfoTag Tag { get; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        public string Extension { get; set; }
    }
}
