namespace EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class AdditionalAmenityCourseInclude : BaseIncludeSpecification<AdditionalAmenityCourse>
    {
        public AdditionalAmenityCourseInclude()
        {
            //     this.AddInclude();
        }
    }

    public class CourseTopicsCourseInclude : BaseIncludeSpecification<CourseTopicsCourse>
    {
        public CourseTopicsCourseInclude()
        {
            //  this.AddInclude();
        }
    }

    public class WorkerInclude : BaseIncludeSpecification<Worker>
    {
        public WorkerInclude()
        {
            //   this.AddInclude();
        }
    }
}