using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            this.ValidateName();
            this.ValidateBirthDate();
            this.ValidateEmail();
        }
    }
}