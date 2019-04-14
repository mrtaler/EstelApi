namespace EstelApi.Application.ApplicationCqrs.Commands.Course.CreateNewCourse
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNewCourseDto 
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string DayDuration { get; set; }
        [Required]
        public decimal CourseCost { get; set; }
        [Required]
        public int CourseTypeId { get; set; }
    }
}