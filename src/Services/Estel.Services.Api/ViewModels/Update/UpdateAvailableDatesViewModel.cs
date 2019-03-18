﻿namespace Estel.Services.Api.ViewModels.Update
{
    using System.ComponentModel.DataAnnotations;

    public class UpdateAvailableDatesViewModel
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

        public int CourseId { get; set; }
    }
}