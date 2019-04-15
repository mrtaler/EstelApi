namespace EstelApi.Application.Specifications.FindByAllFields
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Specifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindCourseTopics : Specification<CourseTopics>
    {
        private readonly CourseTopics availableDates;
        public FindCourseTopics(CourseTopics availableDates)
        {
            this.availableDates = availableDates;
        }

        public override Expression<Func<CourseTopics, bool>> AsExpression()
        {
            return p =>
                p.CourseTopicName == this.availableDates.CourseTopicName;
        }
    }
}