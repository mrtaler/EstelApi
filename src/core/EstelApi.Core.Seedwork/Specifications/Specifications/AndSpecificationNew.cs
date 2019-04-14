namespace EstelApi.Core.Seedwork.Specifications.Specifications
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    /// <summary>
    /// The and specification new.
    /// </summary>
    /// <typeparam name="T">g
    /// </typeparam>
    public class AndSpecification<T> : Specification<T>
        where T : class
    {
        private readonly ISpecification<T> left;
        private readonly ISpecification<T> right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right, int? skip, int? take)
        {
            this.left = left;
            this.right = right;
            if (skip.HasValue) this.Skip(skip.Value);
            if (take.HasValue) this.Take(take.Value);
        }

        public override Expression<Func<T, bool>> AsExpression()
        {
            var leftExpression = this.left.AsExpression();
            var rightExpression = this.right.AsExpression();

            var andExpression = Expression.AndAlso(leftExpression.Body, Expression.Invoke(rightExpression, leftExpression.Parameters));

            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters);
        }
    }
}
