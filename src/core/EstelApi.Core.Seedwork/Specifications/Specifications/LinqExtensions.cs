namespace EstelApi.Core.Seedwork.Specifications.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The linq extensions.
    /// </summary>
    public static class LinqExtensions
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> query, ISpecification<T> specification)
        {
            return specification == null
                       ? throw new ArgumentNullException(nameof(specification))
                       : specification.Invoke(query);
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> query, ISpecification<T> specification)
        {
            return specification == null
                       ? throw new ArgumentNullException(nameof(specification))
                       : specification.Invoke(query);
        }
    }
}
