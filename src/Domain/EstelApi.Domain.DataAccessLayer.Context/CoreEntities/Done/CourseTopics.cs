namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    using System.Collections.Generic;

    using EstelApi.Core.Seedwork;

    public class CourseTopics : EntityInt
    {
        public string CourseTopicName { get; set; }


        public  ICollection<CourseTopicsCourse> Courses { get; set; }
    }
}