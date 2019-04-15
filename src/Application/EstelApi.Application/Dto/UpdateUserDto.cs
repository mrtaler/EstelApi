namespace EstelApi.Application.Dto
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class UpdateUserDto
    {
        /// <summary>
        /// The customer identifier
        /// </summary>
        public int Id { get; set; }

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

        public int IdentityId { get; set; }

        public string MiddleName { get; set; }

        public DateTimeOffset BirthDate { get; set; }
    }
}