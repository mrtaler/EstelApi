namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands
{
    using System;

    /// <inheritdoc />
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        /// <inheritdoc />
        public RegisterNewCustomerCommand(
            string firstName,
            string lastName,
            string telephone,
            string company,
            Guid countryId,
            string addressCity,
            string addressZipCode,
            string addressAddressLine1,
            string addressAddressLine2)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Telephone = telephone;
            this.Company = company;
            this.CountryId = countryId;
            this.AddressCity = addressCity;
            this.AddressZipCode = addressZipCode;
            this.AddressAddressLine1 = addressAddressLine1;
            this.AddressAddressLine2 = addressAddressLine2;
        }



        // move to iN handler
        /*  public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }*/
    }
}