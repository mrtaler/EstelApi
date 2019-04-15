namespace EstelApi.Application.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class CreateNewCourseTopicsDto 
    {
        /// <summary>
        /// Темы раскрываемые на курсах.
        /// </summary>

        [Required]
        public string CourseTopicName { get; set; }
    }
}