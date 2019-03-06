using System;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public RegisterNewCustomerCommand()
        {
        
        }

        /*  public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }*/
    }
}