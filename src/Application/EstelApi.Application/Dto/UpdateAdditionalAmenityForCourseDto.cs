namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourseTopicsForCourse
{
    public class UpdateAdditionalAmenityForCourseDto
    {
        public int Id { get; set; }
        public string AdditionalAmenityName { get; set; }
        public int CourseId { get; set; }
    }
}