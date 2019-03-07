namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using System;

    /// <summary>
    /// The customer registered event.
    /// </summary>
    public class CustomerRegisteredEvent : Event
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Telephone { get; private set; }
        public string Company { get; private set; }
        public Guid CountryId { get; private set; }
        public string AddressCity { get; private set; }
        public string AddressZipCode { get; private set; }
        public string AddressAddressLine1 { get; private set; }
        public string AddressAddressLine2 { get; private set; }

        public CustomerRegisteredEvent(
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
            this.CountryId = countryId;
            this.AddressCity = addressCity;
            this.AddressZipCode = addressZipCode;
            this.AddressAddressLine1 = addressAddressLine1;
            this.AddressAddressLine2 = addressAddressLine2;
        }


    }
}
