namespace Estel.Services.Api.ViewModels.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCourseTypeViewModel
    {
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the course type name.
        /// </summary>
        [Required]
        public string CourseTypeName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Required]
        public string Description { get; set; }
    }
}