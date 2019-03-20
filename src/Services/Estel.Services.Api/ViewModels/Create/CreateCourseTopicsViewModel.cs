namespace Estel.Services.Api.ViewModels.Create
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The create course topics view model.
    /// </summary>
    public class CreateCourseTopicsViewModel
    {
        /// <summary>
        /// Темы раскрываемые на курсах.
        /// </summary>
       
        [Required]
        public string CourseTopicName { get; set; }
    }
}