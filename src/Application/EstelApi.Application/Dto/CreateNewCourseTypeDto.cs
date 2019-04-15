namespace EstelApi.Application.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNewCourseTypeDto
    {
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