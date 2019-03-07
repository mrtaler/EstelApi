namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Validations
{
    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands;

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