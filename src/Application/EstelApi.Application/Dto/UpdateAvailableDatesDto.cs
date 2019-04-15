namespace EstelApi.Application.Dto
{
    using System.ComponentModel.DataAnnotations;

    /// <inheritdoc cref="ICommand" />
    public class UpdateAvailableDatesDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Month { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string StartHour { get; set; }

        [Required]
        public string EndHour { get; set; }

        public int? CourseId { get; set; }
    }
}