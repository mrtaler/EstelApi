using EstelApi.Domain.Cqrs.Commands.CustomerCommands.Commands;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}