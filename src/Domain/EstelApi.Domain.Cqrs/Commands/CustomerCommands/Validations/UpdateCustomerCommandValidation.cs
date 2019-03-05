using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Validations
{
    public class UpdateCustomerCommandValidation : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}