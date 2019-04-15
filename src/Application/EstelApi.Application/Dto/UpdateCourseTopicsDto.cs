namespace EstelApi.Application.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateCourseTopicsDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CourseTopicName { get; set; }
    }
}