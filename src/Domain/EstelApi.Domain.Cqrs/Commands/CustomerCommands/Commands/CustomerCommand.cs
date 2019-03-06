using System;
using EstelApi.Core.Seedwork.CoreCqrs.Commands;
using EstelApi.Domain.Cqrs.Base;
using EstelApi.Domain.Cqrs.Dto;
using MediatR;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands
{
    public abstract class CustomerCommand : ICommand, IValidated, IRequest<CommandResponse<CustomerDto>>
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public bool AlreadyValidated { get; set; }
    }
}
