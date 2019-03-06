using System;

namespace EstelApi.Application.ViewModels.Customer
{
    public class CustomerViewModelApp
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}