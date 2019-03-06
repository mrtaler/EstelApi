using System;
using EstelApi.Core.Seedwork.CoreCqrs.Commands;
using EstelApi.Domain.Cqrs.Base;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Validations;
using EstelApi.Domain.Cqrs.Dto;
using MediatR;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands
{
    public class UpdateCustomerCommand : ICommand, IValidated, IRequest<CommandResponse<CustomerDto>>
    {
        public UpdateCustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
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