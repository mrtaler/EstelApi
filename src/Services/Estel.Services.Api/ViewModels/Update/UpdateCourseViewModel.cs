namespace Estel.Services.Api.ViewModels.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCourseViewModel
    {
        [Required]
        public int Id { get; set; }
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