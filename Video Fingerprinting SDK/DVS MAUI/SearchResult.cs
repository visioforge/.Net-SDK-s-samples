namespace DVS_MAUI
{
    using System.Collections.Generic;

    public class SearchResult 
    {
        public string GroupFile { get; set; } = string.Empty;

        public List<string> Clones { get; private set; }

        public SearchResult()
        {
            Clones = new List<string>();
        }
    }
}