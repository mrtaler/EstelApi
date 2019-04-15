namespace EstelApi.Application.Dto
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UpdateAdditionalAmenityDto
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