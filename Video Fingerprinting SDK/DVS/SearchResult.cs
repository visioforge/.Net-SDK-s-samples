namespace DVS
{
    using System.Collections.Generic;

    public class SearchResult 
    {
        /// <summary>
        /// Gets or sets the group file.
        /// </summary>
        public string GroupFile { get; set; }

        /// <summary>
        /// Gets the clones.
        /// </summary>
        public List<string> Clones { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchResult"/> class.
        /// </summary>
        public SearchResult()
        {
            Clones = new List<string>();
        }
    }
}
