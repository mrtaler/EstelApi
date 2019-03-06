using System.Collections.Generic;

namespace EstelApi.Core.Seedwork.CoreEntities
{
    public class SearchResult<T> where T : class
    {
        public int TotalRecords { get; set; }

        public List<T> Items { get; set; }
    }


}
