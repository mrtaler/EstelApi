using System;
using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Validations;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}