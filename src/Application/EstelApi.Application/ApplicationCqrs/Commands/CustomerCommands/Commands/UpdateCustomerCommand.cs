namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Commands
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The update customer command.
    /// </summary>
    public class UpdateCustomerCommand : CustomerCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand"/> class.
        /// </summary>
        public UpdateCustomerCommand()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCustomerCommand"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="telephone">
        /// The telephone.
        /// </param>
        /// <param name="company">
        /// The company.
        /// </param>
        /// <param name="countryId">
        /// The country id.
        /// </param>
        /// <param name="addressCity">
        /// The address city.
        /// </param>
        /// <param name="addressZipCode">
        /// The address zip code.
        /// </param>
        /// <param name="addressAddressLine1">
        /// The address address line 1.
        /// </param>
        /// <param name="addressAddressLine2">
        /// The address address line 2.
        /// </param>
        public UpdateCustomerCommand(
            Guid id,
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
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Telephone = telephone;
            this.Company = company;
            this.CreditLimit = this.CreditLimit;
            this.CountryId = countryId;
            this.AddressCity = addressCity;
            this.AddressZipCode = addressZipCode;
            this.AddressAddressLine1 = addressAddressLine1;
            this.AddressAddressLine2 = addressAddressLine2;
        }
    }
}