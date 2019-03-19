namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindCourseAttendanceById : FindEntitiesById<CourseAttendance, int> {
        public override Expression<Func<CourseAttendance, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}