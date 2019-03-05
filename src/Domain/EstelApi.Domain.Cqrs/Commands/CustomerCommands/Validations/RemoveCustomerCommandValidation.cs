using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Validations
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}