namespace Estel.Services.Api.ViewModels.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCourseTopicsViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CourseTopicName { get; set; }
    }
}