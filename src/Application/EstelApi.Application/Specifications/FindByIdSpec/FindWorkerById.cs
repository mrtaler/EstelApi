namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class FindWorkerById : FindEntitiesById<Worker, int> {
        public override Expression<Func<Worker, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}