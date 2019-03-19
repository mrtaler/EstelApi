namespace EstelApi.Core.Seedwork.Specifications.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IColumnSpecification<T>
    {
        /// <summary>
        /// Gets the includes.
        /// </summary>
        List<Expression<Func<T, string>>> Columns { get; set; }
    }
}
