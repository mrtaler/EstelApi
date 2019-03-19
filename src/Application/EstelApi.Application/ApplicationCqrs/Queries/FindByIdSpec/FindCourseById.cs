namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindCourseById : FindEntitiesById<Course, int> {
        public override Expression<Func<Course, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}