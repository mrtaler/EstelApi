namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindCourseTopicsById : FindEntitiesById<CourseTopics, int> {
        public override Expression<Func<CourseTopics, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}