namespace Simple_Video_Capture
{
    public class OutputFormatInfo
    {
        public OutputFormatInfo(OutputFormatInfoTag tag, string description, string extension)
        {
            Tag = tag;
            Description = description;
            Extension = extension;
        }

        public OutputFormatInfoTag Tag { get; }
        public string Description { get; set; }

        public string Extension { get; set; }
    }
}
