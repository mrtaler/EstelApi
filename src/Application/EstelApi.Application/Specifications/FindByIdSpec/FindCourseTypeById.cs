namespace EstelApi.Application.Specifications.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindCourseTypeById : FindEntitiesById<CourseType, int> {
        public override Expression<Func<CourseType, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}