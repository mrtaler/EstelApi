namespace EstelApi.Application.Specifications.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class FindUserById : FindEntitiesById<User, int> {
        public override Expression<Func<User, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}