namespace Estel.Services.Api.ViewModels.Customer
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The create customer view model.
    /// </summary>
    public class CreateCustomerViewModel
    {
        /// <summary>
        /// The customer first name
        /// </summary>
        [Required(ErrorMessage = "The First Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The customer lastName
        /// </summary>
        [Required(ErrorMessage = "The Last Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the telephone 
        /// </summary>
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// Get or set the company name
        /// </summary>
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Company")]
        public string Company { get; set; }

        /// <summary>
        /// The country identifier
        /// </summary>
        [Required(ErrorMessage = "CountryId is Required")]
        [DisplayName("Country Id")]
        public Guid CountryId { get; set; }

        /// <summary>
        /// The address city
        /// </summary>
        [Required(ErrorMessage = " City is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("City")]
        public string AddressCity { get; set; }

        /// <summary>
        /// The address zip code
        /// </summary>
        [Required(ErrorMessage = "ZipCode is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address Zip Code")]
        public string AddressZipCode { get; set; }

        /// <summary>
        /// The address line 1
        /// </summary>
        [Required(ErrorMessage = "Address Line1 is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address Line1")]
        public string AddressAddressLine1 { get; set; }

        /// <summary>
        /// The address line 2
        /// </summary>
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address Line2")]
        public string AddressAddressLine2 { get; set; }
    }
}
