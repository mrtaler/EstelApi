namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done
{
    public class CourseTopicsCourse
    {
        public  int CourseId { get; set; }
        public  int CourseTopicsId { get; set; }
        public  Course Course { get; set; }
        public  CourseTopics CourseTopics { get; set; }
    }
}