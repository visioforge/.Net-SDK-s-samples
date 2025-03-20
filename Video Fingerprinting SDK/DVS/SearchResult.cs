namespace VisioForge_MMT
{
    using System.Collections.Generic;

    public class SearchResult 
    {
        public string GroupFile { get; set; }

        public List<string> Clones { get; private set; }

        public SearchResult()
        {
            Clones = new List<string>();
        }
    }
}
