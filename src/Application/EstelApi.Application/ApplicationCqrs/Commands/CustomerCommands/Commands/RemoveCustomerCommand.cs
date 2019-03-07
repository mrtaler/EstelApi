using System;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands
{
    public class RemoveCustomerCommand : CustomerCommand
    {
        public RemoveCustomerCommand(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public Guid AggregateId { get; set; }

        /* public override bool IsValid()
                {
                    ValidationResult = new RemoveCustomerCommandValidation().Validate(this);
                    return ValidationResult.IsValid;
                }*/
    }
}