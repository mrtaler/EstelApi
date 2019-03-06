using System;
using EstelApi.Application.Cqrs.Commands.Base;
using EstelApi.Core.Seedwork.CoreCqrs.Commands;
using EstelApi.Core.Seedwork.CoreEntities;
using MediatR;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands
{
    public class UpdateCustomerCommand : ICommand, IValidated, IRequest<CommandResponse<Customer>>
    {
        public UpdateCustomerCommand() { }
        public UpdateCustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }

        public Guid AggregateId { get; set; }
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime BirthDate { get; protected set; }

        public bool AlreadyValidated { get; set; }
        /*   public override bool IsValid()
           {
               ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
               return ValidationResult.IsValid;
           }*/
    }
}