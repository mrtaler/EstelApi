namespace EstelApi.Core.Seedwork.Specifications.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IIncludeSpecification<T>
    {
        /// <summary>
        /// Gets the includes.
        /// </summary>
        List<Func<IQueryable<T>, IQueryable<T>>> Includes { get; }

        /// <summary>
        /// The add include.
        /// </summary>
        /// <param name="includeExpression">
        /// The include expression.
        /// </param>
        void AddInclude(Func<IQueryable<T>, IQueryable<T>> includeExpression);
    }
}
