namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events
{
    using System;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(
            Guid id,
            string firstName,
            string lastName,
            string telephone,
            string company,
            decimal creditLimit,
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
            this.CreditLimit = creditLimit;
            this.CountryId = countryId;
            this.AddressCity = addressCity;
            this.AddressZipCode = addressZipCode;
            this.AddressAddressLine1 = addressAddressLine1;
            this.AddressAddressLine2 = addressAddressLine2;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public decimal CreditLimit { get; set; }
        public Guid CountryId { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressAddressLine1 { get; set; }
        public string AddressAddressLine2 { get; set; }
    }
}