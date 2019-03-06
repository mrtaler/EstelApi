using System;

namespace EstelApi.Domain.Cqrs.Dto
{
    public class CustomerDto
    {
        public CustomerDto() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
