using System.Collections.Generic;
using Lucene.Net.Documents;

namespace App_Code {
    public class SearchResults
    {
        public virtual IEnumerable<SearchResult> Documents { get; set; }
        public virtual int TotalCount { get; set; }
    }
}