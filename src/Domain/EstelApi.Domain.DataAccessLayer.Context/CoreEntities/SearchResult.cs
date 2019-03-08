namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities
{
    using System.Collections.Generic;

    /// <summary>
    /// The search result.
    /// </summary>
    /// <typeparam name="T">Wrapped entity
    /// </typeparam>
    public class SearchResult<T> where T : class
    {
        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public List<T> Items { get; set; }
    }
}
