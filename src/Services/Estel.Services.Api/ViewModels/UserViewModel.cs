namespace Estel.Services.Api.ViewModels
{
    using System;

    public class UserViewModel
    {
        /// <inheritdoc />
        public UserViewModel()
        {
        }

        /// <summary>
        /// Gets or sets the identity id.
        /// </summary>
        public int IdentityId { get; set; }

        /// <summary>
        /// Gets or sets the Given name of this customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the surname of this customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets the full name of this customer
        /// </summary>
        public string FullName => $"{this.LastName} {this.FirstName} {this.MiddleName}";

        /// <summary>
        /// Gets or sets the telephone 
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTimeOffset BirthDate { get; set; }

        public bool IsEnabled { get; set; }

        public string LogoPath { get; set; }
    }
}