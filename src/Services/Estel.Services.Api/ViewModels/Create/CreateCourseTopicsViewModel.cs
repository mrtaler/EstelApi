namespace Estel.Services.Api.ViewModels.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCourseTopicsViewModel
    {
        [Required]
        public string CourseTopicName { get; set; }
    }
}