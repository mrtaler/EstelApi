namespace EstelApi.Core.Seedwork.Specifications.OrderSpecification
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The order specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class OrderSpecification<T> : IOrderSpecification<T>
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        private OrderEn Order { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSpecification{T}"/> class.
        /// </summary>
        /// <param name="direction">
        /// The direction.
        /// </param>
        protected OrderSpecification(OrderEn direction)
        {
            this.Order = direction;
        }

        public ThenBySpecification<T> ThenBy(IOrderSpecification<T> other)
        {
            var orderList = new List<IOrderSpecification<T>> { this };
            return new ThenBySpecification<T>(orderList, other);
        }

        public IOrderedQueryable<T> Invoke(IQueryable<T> query)
        {
            return this.Order == OrderEn.Descending
                       ? query.OrderByDescending(this.AsExpression())
                       : query.OrderBy(this.AsExpression());
        }

        public IOrderedQueryable<T> Invoke(IOrderedQueryable<T> query)
        {
            return this.Order == OrderEn.Descending
                       ? query.ThenByDescending(this.AsExpression())
                       : query.ThenBy(this.AsExpression());
        }

        public IOrderedEnumerable<T> Invoke(IEnumerable<T> collection)
        {
            return this.Order == OrderEn.Descending
                       ? collection.OrderByDescending(this.AsExpression().Compile())
                       : collection.OrderBy(this.AsExpression().Compile());
        }

        public IOrderedEnumerable<T> Invoke(IOrderedEnumerable<T> collection)
        {
            return this.Order == OrderEn.Descending
                       ? collection.ThenByDescending(this.AsExpression().Compile())
                       : collection.ThenBy(this.AsExpression().Compile());
        }

        public abstract Expression<Func<T, IComparable>> AsExpression();

    }
}
