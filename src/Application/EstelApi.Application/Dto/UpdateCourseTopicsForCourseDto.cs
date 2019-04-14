namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse
{
    using MediatR;

    public class UpdateCourseTopicsForCourseDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseTopicName { get; set; }
    }
}