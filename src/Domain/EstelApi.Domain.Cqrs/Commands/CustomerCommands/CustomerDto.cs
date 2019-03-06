using System;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
