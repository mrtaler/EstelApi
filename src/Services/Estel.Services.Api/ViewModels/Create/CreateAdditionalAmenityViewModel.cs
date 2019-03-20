namespace Estel.Services.Api.ViewModels.Create
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The create additional amenity view model.
    /// </summary>
    public class CreateAdditionalAmenityViewModel
    {
        /// <summary>
        /// Раименование Плюшек от трениннга (кофе, сертификаты, призы и тд.).
        /// </summary>
        [Required(ErrorMessage = "The Amenity Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Additional Amenity")]
        public string AdditionalAmenityName { get; set; }
    }
}