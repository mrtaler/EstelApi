namespace EstelApi.Application.Specifications.IncludeSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    /// <inheritdoc />
    public class BaseIncludeSpecification<TEntity> : IIncludeSpecification<TEntity>
    {
        /// <inheritdoc />
        public List<Func<IQueryable<TEntity>, IQueryable<TEntity>>> Includes { get; }
            = new List<Func<IQueryable<TEntity>, IQueryable<TEntity>>>();

        /// <inheritdoc />
        public void AddInclude(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeExpression)
        {
            this.Includes.Add(includeExpression);
        }
    }
}