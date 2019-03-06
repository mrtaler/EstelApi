using System;
using EstelApi.Application.Cqrs.Commands.Base;
using EstelApi.Core.Seedwork.CoreCqrs.Commands;
using EstelApi.Core.Seedwork.CoreEntities;
using MediatR;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands
{
    public abstract class CustomerCommand : ICommand, IValidated, IRequest<CommandResponse<Customer>>
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public bool AlreadyValidated { get; set; }
    }
}
