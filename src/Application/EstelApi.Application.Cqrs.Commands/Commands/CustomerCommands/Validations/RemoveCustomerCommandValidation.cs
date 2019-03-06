using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Validations
{
    public class RemoveCustomerCommandValidation : CustomerValidation<RemoveCustomerCommand>
    {
        public RemoveCustomerCommandValidation()
        {
            ValidateId();
        }
    }
}