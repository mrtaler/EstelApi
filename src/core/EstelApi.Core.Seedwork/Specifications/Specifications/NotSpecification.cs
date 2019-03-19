namespace EstelApi.Core.Seedwork.Specifications.Specifications
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Interfaces;

    public class NotSpecification<T> : Specification<T>
       where T : class
    {
        private readonly ISpecification<T> other;

        public NotSpecification(ISpecification<T> other, int? skip, int? take)
        {
            this.other = other;
            if (skip.HasValue) this.Skip(skip.Value);
            if (take.HasValue) this.Take(take.Value);
        }

        public override Expression<Func<T, bool>> AsExpression()
        {
            var expression = this.other.AsExpression();

            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters);
        }
    }
}
