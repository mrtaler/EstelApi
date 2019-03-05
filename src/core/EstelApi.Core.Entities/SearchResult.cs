using System.Collections.Generic;

namespace EstelApi.Core.Entities
{
    public class SearchResult<T> where T : class
    {
        public int TotalRecords { get; set; }

        public List<T> Items { get; set; }
    }


}
