namespace Estel.Services.Api.ViewModels.Update
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UpdateAdditionalAmenityViewModel
    {
        [Required(ErrorMessage = "The Amenity Id is Required")]
        [DisplayName("Id Additional Amenity")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}