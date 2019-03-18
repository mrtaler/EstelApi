namespace Estel.Services.Api.ViewModels.Customer
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The delete customer view model.
    /// </summary>
    public class DeleteCustomerViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}