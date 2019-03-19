namespace Estel.Services.Api.ViewModels.Create
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    public class CreateAdditionalAmenityViewModel
    {
        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}