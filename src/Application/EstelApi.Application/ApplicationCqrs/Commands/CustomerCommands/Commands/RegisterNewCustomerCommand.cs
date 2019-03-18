namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands
{
    using System;

    /// <inheritdoc />
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand() { }

        /// <inheritdoc />
        public RegisterNewCustomerCommand(
            string firstName,
            string lastName,
            string telephone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Telephone = telephone;
        }



        // move to iN handler
        /*  public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }*/
    }
}