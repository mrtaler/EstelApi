﻿namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using EstelApi.Core.Seedwork.Specifications.Specifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using System;
    using System.Linq.Expressions;

    public class FindAvailableDatesById : FindEntitiesById<AvailableDates, int>
    {
        public override Expression<Func<AvailableDates, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }

    public class FindAvailableDates : Specification<AvailableDates>
    {
        private readonly AvailableDates availableDates;
        public FindAvailableDates(AvailableDates availableDates)
        {
            this.availableDates = availableDates;
        }

        public override Expression<Func<AvailableDates, bool>> AsExpression()
        {
            return p =>
                p.Date == this.availableDates.Date &&
                p.EndHour == this.availableDates.EndHour &&
                p.StartHour == this.availableDates.StartHour &&
                p.Month == this.availableDates.Month;
        }
    }

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