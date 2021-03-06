﻿namespace EstelApi.Application.Dto
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateNewAdditionalAmenityDto
    {
        /// <summary>
        /// Hаименование Плюшек от трениннга (кофе, сертификаты, призы и тд.).
        /// </summary>
        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}