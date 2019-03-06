using System;
using System.ComponentModel.DataAnnotations;

namespace EstelApi.Application.ViewModels.Customer
{
    public class DeleteCustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}