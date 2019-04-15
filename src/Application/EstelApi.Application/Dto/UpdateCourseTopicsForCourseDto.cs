namespace EstelApi.Application.Dto
{
    public class UpdateCourseTopicsForCourseDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseTopicName { get; set; }
    }
}