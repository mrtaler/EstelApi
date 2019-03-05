using System;
using EstelApi.Core.Cqrs.Commands;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }
    }
}
