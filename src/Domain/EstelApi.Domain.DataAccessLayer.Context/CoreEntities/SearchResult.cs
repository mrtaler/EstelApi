namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using System.Collections.Generic;

    public class SearchResult<T> where T : class
    {
        public int TotalRecords { get; set; }

        public List<T> Items { get; set; }
    }


}
