namespace EstelApi.Core.Seedwork.Specifications.Specifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The specification.
    /// </summary>
    /// <typeparam name="T">Entity for Specification
    /// </typeparam>
    public abstract class Specification<T> : ISpecification<T>
        where T : class
    {
        private int? skip;
        private int? take;

        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other, this.skip, this.take);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other, this.skip, this.take);
        }

        public ISpecification<T> Not()
        {
            return new NotSpecification<T>(this, this.skip, this.take);
        }

        public ISpecification<T> Skip(int count)
        {
            this.skip = count;
            return this;
        }

        public ISpecification<T> Take(int count)
        {
            this.take = count;
            return this;
        }

        public IQueryable<T> Invoke(IQueryable<T> query)
        {
            var result = query.Where(this.AsExpression());

            if (this.skip.HasValue) result = result.Skip(this.skip.Value);
            if (this.take.HasValue) result = result.Take(this.take.Value);

            return result;
        }

        public IEnumerable<T> Invoke(IEnumerable<T> collection)
        {
            var result = collection.Where(this.AsExpression().Compile());

            if (this.skip.HasValue) result = result.Skip(this.skip.Value);
            if (this.take.HasValue) result = result.Take(this.take.Value);

            return result;
        }

        public bool IsSatisfiedBy(T entity)
        {
            var predicate = this.AsExpression().Compile();
            return predicate(entity);
        }

        public abstract Expression<Func<T, bool>> AsExpression();
    }
}
