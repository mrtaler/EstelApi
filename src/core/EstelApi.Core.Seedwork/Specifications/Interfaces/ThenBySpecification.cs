namespace EstelApi.Core.Seedwork.Specifications.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The then by specification.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public class ThenBySpecification<T> : IOrderSpecification<T>
    {
        private readonly List<IOrderSpecification<T>> orderList;

        public ThenBySpecification(List<IOrderSpecification<T>> orderList, IOrderSpecification<T> right)
        {
            this.orderList = orderList;
            this.orderList.Add(right);
        }

        public ThenBySpecification<T> ThenBy(IOrderSpecification<T> other)
        {
            return new ThenBySpecification<T>(this.orderList, other);
        }

        public IOrderedQueryable<T> Invoke(IQueryable<T> query)
        {
            var orderedQuery = this.orderList[0].Invoke(query);
            for (var i = 1; i < this.orderList.Count; i++)
            {
                orderedQuery = this.orderList[i].Invoke(orderedQuery);
            }

            return orderedQuery;
        }

        public IOrderedQueryable<T> Invoke(IOrderedQueryable<T> query)
        {
            return this.orderList.Aggregate(query, (current, order) => order.Invoke(current));
        }

        public IOrderedEnumerable<T> Invoke(IEnumerable<T> collection)
        {
            var orderedCollection = this.orderList[0].Invoke(collection);
            for (var i = 1; i < this.orderList.Count; i++)
            {
                orderedCollection = this.orderList[i].Invoke(orderedCollection);
            }

            return orderedCollection;
        }

        public IOrderedEnumerable<T> Invoke(IOrderedEnumerable<T> collection)
        {
            return this.orderList.Aggregate(collection, (current, order) => order.Invoke(current));
        }
    }
}
