﻿namespace Estel.Services.Api.ViewModels.Create
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCourseViewModel
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