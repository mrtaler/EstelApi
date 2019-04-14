namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateAvailableDatesForCourse
{
    public class UpdateAvailableDatesForCourseDto
    {
        public int CourseId { get; set; }
        public int Id { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
    }
}